using Microsoft.VisualBasic;
using Pallets;
using Pallets.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Prueba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shipments : Window
    {
        private double wWidth, wHeight, wTop, wLeft;
        private bool isMax = false;
        List<NumParte> numParteList, numParteListConMixedPallets, palletsAsortear, numParteFiltradoPO, npFiltrados;
        //ObservableCollection<NumParte> numParte;
        string country, vendorName, bol, vendorConf, trackingNum;
        List<string> POsFiltradas;
        //private DispatcherTimer timer;
        Storyboard loadingAnimation;

        public Shipments(string country, string vendorName, string bol, string vendor_conf, string trackingNum, string city)
        {
            //WindowChrome.SetWindowChrome(this, new WindowChrome());
            InitializeComponent();

            numParteFiltradoPO = new List<NumParte>();
            string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, "Flags", $"{country}.png");
            BitmapImage image = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            flagVendor.Source = image;

            this.country = country;
            this.vendorName = vendorName;
            this.bol = bol;
            this.vendorConf = vendor_conf;
            this.trackingNum = trackingNum;

            lblVendorName.Content = this.vendorName;
            lblBol.Content = this.bol;
            lblTrackingNum.Content = this.trackingNum;

            loadingAnimation = (Storyboard)FindResource("LoadingAnimation");
            loadingAnimation.Begin();

            if (city.Equals("Hermosillo"))
            {
                colSloc.Header = "Qty per Box";
                colPo.Header = "";
                bindingDataGridHmoDc(trackingNum);
            }
            else
            {
                bindingDataGrid(bol);
            }//fin if else
        }


        private async Task<List<NumParte>> LoadDataAsync(string bol)
        {
            List<NumParte> numParteList = new List<NumParte>();

            using (SqlConnection connection = new SqlConnection("Data Source=US194db122;Initial Catalog=Digitalization;User Id=Digital_View;Password=DigitalU$r;"))
            {
                await connection.OpenAsync();
                string query = "";

                //query = "SELECT \r\n\tI.PO_number,\r\n\tI.Material, \r\n\tI.Sloc,\r\n\tISNULL((MAX(I.Open_GR_qty) / (SELECT ShpQty FROM MaterialList WHERE Material = I.Material)), 1)\r\nFROM \r\n\tIntransit I\r\nWHERE \r\n\tI.PO_number = 'AZ04919087'\r\n\tAND Run_date = (\r\n\t\tSELECT MAX(Run_date)\r\n\t\tFROM Intransit\r\n\t\tWHERE I.PO_number = 'AZ04919087'\r\n\t)\r\nGROUP BY \r\n\tPO_number,\r\n\tMaterial, \r\n\tSloc\r\nORDER BY\r\n\tPO_number\r\nDESC";

                if (bol.Equals("Empty"))
                {
                    query = "SELECT \r\n\tI.PO_number,\r\n\tI.Material, \r\n\tI.Sloc,\r\n\tISNULL((MAX(I.Open_GR_qty) / (SELECT ShpQty FROM MaterialList WHERE Material = I.Material)), 1)\r\nFROM \r\n\tIntransit I\r\nWHERE \r\n\t(Vendor_Name = @vendorName AND Vendor_conf = @vendorConf)\r\n\tAND Run_date = (\r\n\t\tSELECT MAX(Run_date)\r\n\t\tFROM Intransit\r\n\t\tWHERE ((Vendor_Name = @vendorName AND Vendor_conf = @vendorConf))\r\n\t)\r\nGROUP BY \r\n\tPO_number,\r\n\tMaterial, \r\n\tSloc\r\nORDER BY\r\n\tPO_number\r\nDESC";
                }
                else
                {
                    query = "SELECT \r\n\tI.PO_number,\r\n\tI.Material, \r\n\tI.Sloc,\r\n\tISNULL((MAX(I.Open_GR_qty) / (SELECT ShpQty FROM MaterialList WHERE Material = I.Material)), 1)\r\nFROM \r\n\tIntransit I\r\nLEFT JOIN\r\n\tTracking T\r\nON \r\n\tT.ShipmntNbr = I.bill_of_lading\r\nWHERE \r\n\tbill_of_lading = @bol\r\n\tAND Run_date = (\r\n\t\tSELECT MAX(Run_date)\r\n\t\tFROM Intransit\r\n\t\tWHERE bill_of_lading = @bol\r\n\t)\r\nGROUP BY \r\n\tPO_number,\r\n\tMaterial, \r\n\tSloc,\r\n\tT.cartons\r\nORDER BY\r\n\tPO_number\r\nDESC;";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (bol.Equals("Empty"))
                    {
                        command.Parameters.Add("@vendorName", SqlDbType.VarChar).Value = vendorName; // Valor del parámetro
                        command.Parameters.Add("@vendorConf", SqlDbType.VarChar).Value = vendorConf; // Valor del parámetro
                    }
                    else
                    {
                        command.Parameters.Add("@bol", SqlDbType.VarChar).Value = bol; // Valor del parámetro
                    }

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string Po = (string)reader["PO_number"];
                            string Material = (string)reader["Material"];
                            string Sloc = (string)reader["Sloc"];
                            int Cartons = reader[3] == DBNull.Value ? 0 : Convert.ToInt32(reader[3]);

                            numParteList.Add(new NumParte("", Po, Material, Sloc, Cartons));
                        }//while
                    }//using
                }//using
                connection.Close();
            }//using

            return numParteList;
        }//LoadDataAsync

        private async Task<List<NumParte>> LoadDataAsyncHmoDc(string id)
        {
            List<NumParte> numParteList = new List<NumParte>();

            using (SqlConnection connection = new SqlConnection("Data Source=MXJ21DB100.tycoelectronics.net;Initial Catalog=Procurement;User Id=ProcurementUser;Password=ProcU$r;"))
            {
                await connection.OpenAsync();
                // string query = "SELECT MATERIAL, QTY, COUNT(MATERIAL) AS Cartons FROM Esquematicos_glog_det WHERE ID = @id  GROUP BY MATERIAL, QTY ORDER BY Cartons DESC";
                string query = "SELECT MATERIAL, CARTON_LICENSE_TAG, QTY FROM Esquematicos_glog_det WHERE ID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.VarChar).Value = id; // Valor del parámetro

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string Material = (string)reader["MATERIAL"];
                            string licenseTag = (string)reader["CARTON_LICENSE_TAG"];
                            int Sloc = Convert.ToInt32(reader["QTY"]);

                            numParteList.Add(new NumParte("", "", Material, Sloc + "", 0, licenseTag));
                        }//while
                    }//using
                }//using
                connection.Close();
            }//using

            return numParteList;
        }//LoadDataAsync

        private void AssignLocation(List<NumParte> lista)
        {
            palletsAsortear = new List<NumParte>();
            bool isA = true;
            int contador = 0, contadorA = 1, contadorB = 1, numParteInPallet = 1;
            for (int i = 0; i < lista.Count; i++)
            {

                if (lista[i].Tipo != null)
                {
                    if (lista[i].Tipo.Equals("Mixed"))
                    {
                        // if (contador > 20) contador = 1;
                        //lista[i].Location = (isA ? "A" : "B") + (isA ? contadorA : contadorB);
                        lista[i].Location = "Mix";
                        palletsAsortear.Add(lista[i]);
                    }
                    else if(lista[i].Tipo.Equals("Pallet"))
                    {
                        lista[i].Location = (isA ? "A" : "B") + (isA ? contadorA : contadorB);
                        palletsAsortear.Add(lista[i]);
                    }
                    else if (lista[i].Material.Equals("*****"))
                    {
                        lista[i].Location = (isA ? "A" : "B") + (isA ? contadorA : contadorB);
                        palletsAsortear.Add(lista[i]);

                        if (isA) { contadorA++; } else { contadorB++; }
                        if (contador % 5 == 0) isA = !isA;
                    }
                    else if (lista[i].Material.Equals("-----"))
                    {
                        lista[i].Location = "Mix";
                        palletsAsortear.Add(lista[i]);
                    }// fin if else// fin if else
                }// fin if lista[i].TrackingNo.Equals("Empty")

            }//fin for
        }//AssignLocation

        //private List<NumParte> AssignLocationTwo(List<NumParte> lista)
        //{
        //    List<NumParte> NuevasPalletsAsortear = new List<NumParte>();
        //    int contador = 1, page = 4 ;
        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //        if (lista[i].Tipo != null)
        //        {
        //            if (lista[i].Tipo.Equals("Mixed"))
        //            {
        //                if (contador > 20)
        //                {
        //                    contador = 1; 
        //                    page++;
        //                }

        //                lista[i].Location = "A" + contador;
        //                lista[i].Page = page;
        //                NuevasPalletsAsortear.Add(lista[i]);
        //            }
        //            else
        //            {
        //                if (lista[i].Material == "-----")
        //                {
        //                    if (contador > 20)
        //                    {
        //                        contador = 1;
        //                        page++;
        //                    }

        //                    lista[i].Location = "A" + contador;
        //                    lista[i].Page = page;
        //                    NuevasPalletsAsortear.Add(lista[i]);
        //                    contador++;
        //                }
        //                else if (lista[i].Pallets > 0)
        //                {
        //                    if (contador > 20)
        //                    {
        //                        contador = 1;
        //                        page++;
        //                    }

        //                    lista[i].Location = "A" + contador;
        //                    lista[i].Page = page;
        //                    NuevasPalletsAsortear.Add(lista[i]);
        //                    contador++;
        //                }// fin if lista[i].Pallets > 0
        //            }// fin if else
        //        }// fin if lista[i].TrackingNo.Equals("Empty")
        //    }//fin for
        //    return NuevasPalletsAsortear;
        //}//AssignLocation

        private async void bindingDataGrid(string bol)
        {
            // Llama a LoadDataAsync para cargar los datos inicialmente
            numParteList = await LoadDataAsync(bol);

            numParteList = numParteList.OrderByDescending(item => item.Cartons).ToList();
            npFiltrados = numParteList;
            //AssignLocation();

            //Hacer visibles los botones despues de la finalizacion de la carga
            btnSortingTwo.Visibility = Visibility.Visible;
            btnSortingNoTracking.Visibility = Visibility.Visible;
            lblLoading.Visibility = Visibility.Hidden;
            dgInTransit.Visibility = Visibility.Visible;
            btnSortingTwo.Visibility = Visibility.Visible;
            btnFilterByPo.Visibility = Visibility.Visible;

            //ver si vienen diferentes slocs
            var groupedBySloc = numParteList.GroupBy(obj => obj.Sloc);
            if (groupedBySloc.Count() > 1) MessageBox.Show(this, "Different Sloc in this shipment", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);

            //Mostrar en el Datagrid
            dgInTransit.ItemsSource = numParteList;

            //MixedPallet(numParteList);

            loadingAnimation.Stop();

        }//bindingData

        private async void bindingDataGridHmoDc(string id)
        {
            // Llama a LoadDataAsync para cargar los datos inicialmente
            numParteList = await LoadDataAsyncHmoDc(id);

            var summaryList = numParteList
                .GroupBy(n => new { n.Material, n.Sloc})
                .Select(group => new NumParte
                {
                    Material = group.Key.Material,
                    Sloc = group.Key.Sloc,
                    Cartons = group.Count()
                })
                .OrderByDescending(item => item.Cartons)
                .ToList();

            summaryList = summaryList.OrderByDescending(item => item.Cartons).ToList();
            npFiltrados = summaryList;
            //AssignLocation();

            //Hacer visibles los botones despues de la finalizacion de la carga
            btnSortingTwo.Visibility = Visibility.Visible;
            btnSortingNoTracking.Visibility = Visibility.Visible;
            lblLoading.Visibility = Visibility.Hidden;
            dgInTransit.Visibility = Visibility.Visible;
            btnSortingTwo.Visibility = Visibility.Visible;
            btnFilterByPo.Visibility = Visibility.Visible;


            //Mostrar en el Datagrid
            dgInTransit.ItemsSource = numParteList;

            //MixedPallet(numParteList);

            loadingAnimation.Stop();

        }//bindingData

        private void BindingDataGridFiltradoPorPO()
        {
            // Agrupar por Material
            var NumParteAgrupados = numParteFiltradoPO
                .GroupBy(p => new { p.Material, p.Sloc })
                .Select(group =>
                {
                    string material = group.Key.Material;
                    string sloc = group.Key.Sloc;
                    int totalCartons = group.Sum(p => p.Cartons);
                    NumParte nuevoNumParte = new NumParte("", "", material, sloc, totalCartons);

                    return nuevoNumParte;
                });

            NumParteAgrupados = NumParteAgrupados.OrderByDescending(np => np.Cartons);

            var groupedBySloc = NumParteAgrupados.GroupBy(obj => obj.Sloc);

            if (groupedBySloc.Count() > 1) MessageBox.Show(this, "Different Sloc in this shipment", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);

            palletsAsortear = new List<NumParte>(NumParteAgrupados);

            dgInTransit.ItemsSource = numParteFiltradoPO;

            MixedPallet(palletsAsortear);

        }//bindingData

        private void FilterByPO_Click(object sender, RoutedEventArgs e)
        {
            List<string> diferentesPOs = numParteList.Select(numParte => numParte.Po).Distinct().ToList();
            FilterByPo fbp = new FilterByPo(diferentesPOs, this);
            fbp.Show();
        }

        public void RecibirPOsFiltradas(List<string> listaPOsFiltradas)
        {
            POsFiltradas = listaPOsFiltradas;
            numParteFiltradoPO = numParteList.Where(p => POsFiltradas.Contains(p.Po)).ToList();
            npFiltrados = numParteFiltradoPO;
            BindingDataGridFiltradoPorPO();
        }

        private void MixedPallet(List<NumParte> listaNumParte)
        {
            var npConSpare = listaNumParte.Where(np => np.Spare > 0).ToList();
            var npSinSpare = listaNumParte.Where(np => np.Cartons >= 12).ToList();

            List<List<NumParte>> mixedPallets = new List<List<NumParte>>();
            List<NumParte> mixedPallet = new List<NumParte>();

            List<List<NumParte>> pallets = new List<List<NumParte>>();
            List<NumParte> palletElement = new List<NumParte>();


            numParteListConMixedPallets = new List<NumParte>();

            if (npSinSpare.Count() > 0) {
                int npInPallet = 0;
                foreach (var np in npSinSpare)
                {
                    if (np.Cartons >= 12 && np.Cartons <= 20)
                    {
                        if (npInPallet < 2)
                        {
                            palletElement.Add(np);
                            npInPallet++;
                        }
                        else {
                            pallets.Add(new List<NumParte>(palletElement));
                            palletElement.Clear();
                            palletElement.Add(np);
                            npInPallet = 0;
                        }
                    }
                    else {
                        palletElement.Add(np);
                        pallets.Add(new List<NumParte>(palletElement));
                        palletElement.Clear();
                    }// np.Cartons >= 12 && np.Cartons <= 18

                }//fin foreach var np in npSinSpare

                if (palletElement.Any()) pallets.Add(new List<NumParte>(palletElement));

                // Mostrar los pallets
                int palletNumber = 1;
                List<NumParte> npTemporales = new List<NumParte>();
                foreach (var pallet in pallets)
                {
                    foreach (var numParte in pallet)
                    {
                        npTemporales.Add(new NumParte("", "", numParte.Material, "", numParte.Cartons));
                        //MessageBox.Show(this, $"Num. Pallet: {palletNumber} Material: {numParte.Material}, PO: {numParte.Po}, Spare: {numParte.Spare}");
                        numParteListConMixedPallets.Add(new NumParte("Pallet", numParte.Po, numParte.Material, "", numParte.Sloc, numParte.Cartons));
                    }
                    NumParte tarimaMix = new NumParte(" ", "", "*****", "", 0);
                    tarimaMix.ListaNumParte = new List<NumParte>(npTemporales);

                    numParteListConMixedPallets.Add(tarimaMix);
                    //listaNumParte.Add(tarimaMix);
                    npTemporales.Clear();
                    palletNumber++;
                }//fin foreach var pallet in mixedPallets

            }//fin npSinSpare.Count() > 0
            if (npConSpare.Count() > 0)
            {
                //numParteListConMixedPallets.Add(new NumParte());

                // Mostrar los resultados
                foreach (var np in npConSpare)
                {
                    mixedPallet.Add(np);
                }//fin foreach var np in npConSpare

                mixedPallets.Add(new List<NumParte>(mixedPallet));
                mixedPallet.Clear();

                // Mostrar los pallets
                int palletNumber = 1;
                List<NumParte> npTemporales = new List<NumParte>();
                foreach (var pallet in mixedPallets)
                {
                    foreach (var numParte in pallet)
                    {
                        npTemporales.Add(new NumParte("", "", numParte.Material, "", numParte.Spare));
                        //MessageBox.Show(this, $"Num. Pallet: {palletNumber} Material: {numParte.Material}, PO: {numParte.Po}, Spare: {numParte.Spare}");
                        numParteListConMixedPallets.Add(new NumParte("Mixed", numParte.Po, numParte.Material, "", numParte.Sloc, numParte.Spare));
                    }
                    NumParte tarimaMix = new NumParte(" ", "", "-----", "", 0);
                    tarimaMix.ListaNumParte = new List<NumParte>(npTemporales);

                    numParteListConMixedPallets.Add(tarimaMix);
                    listaNumParte.Add(tarimaMix);
                    npTemporales.Clear();
                    palletNumber++;
                }//fin foreach var pallet in mixedPallets

                //AssignLocation(numParteListConMixedPallets);

                // Eliminar los NP con cero pallets
                //numParteListConMixedPallets.RemoveAll(item => item.ShouldRemove());
                // --------------------------------

            }

            //AssignLocation(listaNumParte);
            AssignLocation(numParteListConMixedPallets);

        }//MixedPallet

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
            {

                try { this.DragMove(); } catch { }

            }

        }//MouseDown

        private void PalletSortTwo_Click(object sender, RoutedEventArgs e)
        {
            // Llamada al InputBox
            string truckNumber = Interaction.InputBox("Truck number:", "Truck", "");

            // Verificar si se ingresó algo
            if (!string.IsNullOrEmpty(truckNumber))
            {

                // Agrupar por Material
                var NumParteAgrupados = npFiltrados
                    .GroupBy(p => new { p.Material, p.Sloc })
                    .Select(group =>
                    {
                        string material = group.Key.Material;
                        string sloc = group.Key.Sloc;
                        int totalCartons = group.Sum(p => p.Cartons);
                        NumParte nuevoNumParte = new NumParte("", "", material, sloc, totalCartons);
                        nuevoNumParte.RestarSobrantes();
                        return nuevoNumParte;
                    });

                NumParteAgrupados = NumParteAgrupados.OrderByDescending(np => np.Cartons);

                MixedPallet(new List<NumParte>(NumParteAgrupados));

                PalletsSorted palletSorted = new PalletsSorted(palletsAsortear, numParteListConMixedPallets, truckNumber, numParteList);
                palletSorted.Show();
            }
            else
            {
                MessageBox.Show("You must type the truck number");
            }
        }

    }//fin class
}

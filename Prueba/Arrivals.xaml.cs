using Pallets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Prueba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Arrivals : Window
    {
        private double wWidth, wHeight, wTop, wLeft;
        private string city;
        private bool isMax = false;
        List<Shipment> shipments, shipmentsFiltrados;
        List<string> uniqueCountries;
        //ObservableCollection<NumParte> numParte;
        //private DispatcherTimer timer;
        Storyboard loadingAnimation;
        MainWindow mainWindow;

        public Arrivals(string city, MainWindow mainWindow)
        {
            InitializeComponent();
            gridSearchCount.Visibility = Visibility.Hidden;
            this.city = city;
            this.mainWindow = mainWindow;

            dgInTransit.MouseDoubleClick += Intransit_MouseDoubleClick;

            loadingAnimation = (Storyboard)FindResource("LoadingAnimation");
            loadingAnimation.Begin();

            bindingDataGrid();

            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromMinutes(1); // Reemplaza 'x' con la cantidad de minutos deseada
            //timer.Tick += async (sender, e) => await ActualizarDataGrid();
            //timer.Start();
        }

        private void Intransit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Realiza aquí la acción que desees al hacer doble clic en una fila
            // Puedes acceder a la fila seleccionada a través de dataGrid.SelectedItem
            // Por ejemplo, para obtener un valor de la fila seleccionada:
            if (dgInTransit.SelectedItem != null)
            {
                var shipment = (Shipment)dgInTransit.SelectedItem;
                Shipments shipmentScreen = new Shipments(shipment.CountryOrigin, shipment.VendorName, shipment.Bol, shipment.Pgi, shipment.TrackingNo, "Default");
                mainWindow.ChangeScreen(shipmentScreen);
                //shipmentScreen.Show();
                //shipmentScreen.Activate();
            }
        }

        private string AssignOrigin(string vendor)
        {
            switch (vendor)
            {

                case "Deutsch Connectors Trading":
                    return "DE";

                case "Deutsch India Power Connectors":
                case "TE Connectivity India Pvt Ltd":
                    return "IN";

                case "Ladd Distribution LLC":
                case "ICT NA Virtual Plant":
                case "TE Connectivity":
                case "TE Connectivity - US":
                case "TE Connectivity Corporation":
                case "TE Connectivity Distribution":
                case "TE Connectivity Manufacturing":
                case "TE Greensboro":
                case "TE Kauffman Road":
                case "TE Lickdale":
                case "TE Tullahoma":
                    return "US";

                case "Raychem Shanghai Cable Accessories":
                case "TE Connectivity (Kunshan) Company":
                case "TE Connectivity (Shanghai)":
                case "TE Connectivity (Suzhou) Co Ltd":
                case "TE Connectivity (Weifang) Ltd":
                case "TE Connectivity Connectors (Suzhou)":
                case "Tyco Electronics (DongGuan) Ltd":
                case "Tyco Electronics (Kunshan) Co. Ltd.":
                case "Tyco Electronics (Qingdao) Ltd.":
                case "Tyco Electronics (Shenzhen) Co, Ltd":
                case "Tyco Electronics (Suzhou) Ltd.":
                case "Tyco Electronics (Zhuhai) Ltd":
                case "Tyco Electronics AMP Guangdong Ltd.":
                case "Tyco Electronics AMP Qingdao Ltd.":
                case "Tyco Electronics Shanghai Co. Ltd.":
                    return "CN";

                case "TE Connectivity HK Ltd":
                case "TE CONNECTIVITY HK LTD - WGQ":
                    return "HK";

                case "TE Connectivity Amermex":
                case "TE Connectivity AMP (HMO)":
                case "TE Connectivity ICT Empalme":
                case "TE Hermosillo Automotive":
                case "TE Empalme":
                case "Tyco Electronics Mexico S de RL de":
                    return "MX";

                case "TE Connectivity Australia Pty Ltd":
                    return "AU";

                case "TE Connectivity Brasil Industria de":
                    return "BR";

                case "TE Connectivity Malaysia Sdn. Bhd.":
                case "TE Connectivity Operations Sdn.Bhd.":
                    return "MY";

                case "TE Connectivity Morocco ICT":
                case "TE Connectivity Morocco SARL":
                    return "MA";

                case "TE Connectivity Trutnov s.r.o.":
                case "TESOG CZ Whse Dobrany":
                    return "CZ";

                case "Tyco Electronics AMP Korea Co Ltd":
                case "Tyco Electronics Raychem Korea Ltd. ":
                    return "KR";

                case "Tyco Electronics Holdings (Bermuda)":
                    return "BM";

                case "TYCO ELECTRONICS JAPAN G.K.":
                    return "JP";

                case "Tyco Electronics Singapore Pte Ltd":
                case "Tyco Electronics Technology (SIP)":
                    return "SG";

                default:
                    return "EMEA";

            }//fin switch
        } // AssignOrigin

        private async Task<List<Shipment>> LoadDataAsync()
        {
            List<Shipment> shipmentsList = new List<Shipment>();
            using (SqlConnection connection = new SqlConnection("Data Source=US194db122;Initial Catalog=Digitalization;User Id=Digital_View;Password=DigitalU$r;"))
            {
                await connection.OpenAsync();

                string query = "SELECT Subquery.Vendor_conf, Subquery.bill_of_lading, Subquery.Tracking_No, Subquery.Country_of_Origin, Subquery.Vendor_name, ROUND(SUM(Subquery.Pallets), 0) AS Pallets FROM (SELECT I.Vendor_conf, I.bill_of_lading, T.Tracking_No, T.Country_of_Origin, I.Vendor_name, I.PO_number, I.Material, I.Sloc, ((MAX(I.Open_GR_qty) * 1.0 / (SELECT ShpQty FROM MaterialList WHERE Material = I.Material)) / 26) AS Pallets FROM Intransit I LEFT JOIN Tracking T ON T.ShipmntNbr = I.bill_of_lading AND T.Materail = I.Material WHERE I.city LIKE '%" + city + "%' AND (I.Vendor_conf BETWEEN '2024-01-01' AND '2024-06-01') GROUP BY I.Vendor_conf, I.bill_of_lading, T.Tracking_No, T.Country_of_Origin, I.Vendor_name, I.PO_number, I.Material, I.Sloc, T.cartons) AS Subquery GROUP BY Subquery.Vendor_conf, Subquery.bill_of_lading, Subquery.Tracking_No, Subquery.Country_of_Origin, Subquery.Vendor_name ORDER BY Subquery.Vendor_conf DESC";
                //string query = "SELECT Subquery.Vendor_conf, Subquery.bill_of_lading, Subquery.Tracking_No, Subquery.Country_of_Origin, Subquery.Vendor_name, SUM(Subquery.Pallets) AS Pallets FROM (SELECT I.Vendor_conf, I.bill_of_lading, T.Tracking_No, T.Country_of_Origin, I.Vendor_name, I.PO_number, I.Material, I.Sloc, CASE WHEN T.cartons IS NULL THEN ROUND(((MAX(I.Open_GR_qty) * 1.0 / (SELECT ShpQty FROM MaterialList WHERE Material = I.Material)) / 26), 0) ELSE ROUND(( T.cartons / 26), 0) END AS Pallets FROM Intransit I LEFT JOIN Tracking T ON T.ShipmntNbr = I.bill_of_lading AND I.Material = T.Materail WHERE I.city LIKE '%" + city + "%' AND (I.Vendor_conf BETWEEN '2023-11-10' AND '2023-12-25') GROUP BY I.Vendor_conf, I.bill_of_lading, T.Tracking_No, T.Country_of_Origin, I.Vendor_name, I.PO_number, I.Material, I.Sloc, T.cartons) AS Subquery GROUP BY Subquery.Vendor_conf, Subquery.bill_of_lading, Subquery.Tracking_No, Subquery.Country_of_Origin, Subquery.Vendor_name ORDER BY Subquery.Vendor_conf DESC\r\n";
                //string query = "SELECT Subquery.Vendor_conf, Subquery.bill_of_lading, Subquery.Tracking_No, Subquery.Country_of_Origin, Subquery.Vendor_name, SUM(Subquery.Pallets) AS Pallets FROM (SELECT I.Vendor_conf, I.bill_of_lading, T.Tracking_No, T.Country_of_Origin, I.Vendor_name, I.PO_number, I.Material, I.Sloc, CASE WHEN T.cartons IS NULL THEN ROUND(((I.Open_GR_qty * 1.0 / (SELECT ShpQty FROM MaterialList WHERE Material = I.Material)) / 26), 0) ELSE ROUND(( T.cartons / 26), 0) END AS Pallets FROM Intransit I LEFT JOIN Tracking T ON T.ShipmntNbr = I.bill_of_lading AND I.Material = T.Materail WHERE I.city LIKE '%" + city + "%' AND (I.Vendor_conf BETWEEN '2023-11-10' AND '2023-12-25') GROUP BY I.Vendor_conf, I.bill_of_lading, T.Tracking_No, T.Country_of_Origin, I.Vendor_name, I.PO_number, I.Material, I.Sloc, I.Open_GR_qty, T.cartons) AS Subquery GROUP BY Subquery.Vendor_conf, Subquery.bill_of_lading, Subquery.Tracking_No, Subquery.Country_of_Origin, Subquery.Vendor_name\r\n";
                //string query = "SELECT DISTINCT Subquery.Vendor_conf, Subquery.bill_of_lading, Subquery.Country_of_Origin, Subquery.Vendor_name, SUM(Subquery.Pallets) AS Pallets FROM (SELECT I.Vendor_conf, I.bill_of_lading, T.Country_of_Origin, I.Vendor_name, I.PO_number, I.Material, I.Sloc, ROUND(((I.Open_GR_qty * 1.0 / (SELECT ShpQty FROM MaterialList WHERE Material = I.Material))/26), 0) AS Pallets FROM Intransit I LEFT JOIN Tracking T ON I.bill_of_lading = T.ShipmntNbr INNER JOIN (SELECT PO_number, Material, Sloc, MAX(Run_date) AS MaxRunDate FROM Intransit WHERE city LIKE '%Hermosillo%' AND (Vendor_conf BETWEEN '2023-10-15' AND '2023-11-15') GROUP BY PO_number, Material, Sloc) AS MaxDates ON I.PO_number = MaxDates.PO_number AND I.Material = MaxDates.Material AND I.Sloc = MaxDates.Sloc AND I.Run_date = MaxDates.MaxRunDate GROUP BY I.Vendor_conf, I.bill_of_lading, T.Country_of_Origin, I.Vendor_name, I.PO_number, I.Material, I.Sloc, I.Open_GR_qty) AS Subquery GROUP BY Subquery.Vendor_conf, Subquery.bill_of_lading, Subquery.Country_of_Origin, Subquery.Vendor_name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            DateTime fecha = (DateTime)reader["Vendor_conf"];
                            string? PGI_Date = fecha.ToString("yyyy-MM-dd");
                            string BillOfLading = reader["bill_of_lading"] == DBNull.Value ? "Empty" : (string)reader["bill_of_lading"];
                            string TrackingNo = reader["Tracking_No"] == DBNull.Value ? "Empty" : (string)reader["Tracking_No"];

                            string VendorName = (string)reader["Vendor_name"];
                            string Country = (string)(reader["Country_of_Origin"] == DBNull.Value ? AssignOrigin(VendorName) : reader["Country_of_Origin"]);

                            int Pallets = reader[5] == DBNull.Value ? 1 : Convert.ToInt32(reader[5]);
                            //int Cartons = reader[4] == DBNull.Value ? 1 : (int)reader[4];

                            shipmentsList.Add(new Shipment(null, PGI_Date, BillOfLading, TrackingNo, Country, VendorName, Pallets));
                        }//while
                    }//using
                }//using
                connection.Close();
            }//using

            return shipmentsList;
        }//LoadDataAsync

        private async void bindingDataGrid()
        {
            // Llama a LoadDataAsync para cargar los datos inicialmente
            shipments = await LoadDataAsync();

            var gruposAgrupados = shipments
                .GroupBy(s => new { s.Pgi, s.Bol, s.CountryOrigin, s.VendorName })
                .Select(grupo => new Shipment
                {
                    Pgi = grupo.Key.Pgi,
                    Bol = grupo.Key.Bol,
                    CountryOrigin = grupo.Key.CountryOrigin,
                    VendorName = grupo.Key.VendorName,
                    Cartons = grupo.Sum(s => s.Cartons)
                })
                .ToList();

            shipmentsFiltrados = shipments;

            lblNumShipments.Content = "Shipments: " + shipments.Count;

            dgInTransit.ItemsSource = shipments;
            loadingAnimation.Stop();
            lblLoading.Visibility = Visibility.Hidden;
            dgInTransit.Visibility = Visibility.Visible;
            gridSearchCount.Visibility = Visibility.Visible;

            uniqueCountries = shipments.Select(s => s.CountryOrigin).Distinct().ToList();
            uniqueCountries.Insert(0, "All");

            List<CountryElement> countryElements = new List<CountryElement>();
            foreach (var country in uniqueCountries)
            {
                countryElements.Add(new CountryElement { Abreviatura = country, RutaImagen = "/Flags/" + country });
            }

            cmbCountry.SelectedIndex = 0;
            cmbCountry.ItemsSource = countryElements;


        }//bindingData

        private void BusquedaShipment(object sender, TextChangedEventArgs e)
        {
            TextBox filtro = (TextBox)sender;
            ICollectionView view = CollectionViewSource.GetDefaultView(shipmentsFiltrados);

            if (filtro.Text.Length > 0)
            {
                hintTxtBuscar.Visibility = Visibility.Hidden;
            }
            else
            {
                hintTxtBuscar.Visibility = Visibility.Visible;
            }

            view.Filter = (o) =>
            {
                // Debes proporcionar una condición de filtro que devuelva true para los elementos que deseas mantener en la vista.
                // Por ejemplo, si tu lista contiene elementos de tipo Persona y deseas mostrar solo personas mayores de 18 años:
                if (o is Shipment shipmnt)
                {
                    return shipmnt.Bol.Contains(filtro.Text);
                }
                return false; // Filtro predeterminado: no mostrar ningún elemento si no se cumple la condición.
            };
            lblNumShipments.Content = "Shipments: " + view.Cast<object>().Count();
            dgInTransit.ItemsSource = view;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
            {

                try { this.DragMove(); } catch { }

            }

        }//MouseDown

        private void WindowClosed(object sender, EventArgs e)
        {
            if (shipments != null) shipments.Clear();
        }

        private void cmbCountrySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtén el ComboBox actual
            ComboBox comboBox = (ComboBox)sender;
            CountryElement elemento = (CountryElement)comboBox.SelectedItem;
            string elementoSeleccionado = (string)elemento.Abreviatura;

            if (elementoSeleccionado.Equals("All"))
            {
                shipmentsFiltrados = shipments;
            }
            else
            {
                shipmentsFiltrados = shipments.Where(s => s.CountryOrigin == elementoSeleccionado).ToList();
            }//fin if else elementoSeleccionado.Equals("None")

            txtBuscarBol.Text = "";
            lblNumShipments.Content = "Shipments: " + shipmentsFiltrados.Count;
            dgInTransit.ItemsSource = shipmentsFiltrados;

            // Haz algo con la lista filtrada, por ejemplo, mostrarla en otro control
            // listBoxEnvios.ItemsSource = enviosFiltrados;
        }//cmbCountrySelectionChanged

        private void MinimizeButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.WindowState = WindowState.Minimized;
            }
        }//Minimize

        private void MaximizeButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (isMax)
                {
                    MainMenu.CornerRadius = new CornerRadius(15);
                    //SideMenu.CornerRadius = new CornerRadius(15, 0, 0, 15);

                    this.WindowState = WindowState.Normal;
                    this.Left = wLeft; // Posición izquierda
                    this.Top = wTop; // Posición superior
                    this.Width = wWidth; // Ancho igual al área de trabajo
                    this.Height = wHeight;
                    isMax = false;
                }
                else
                {
                    MainMenu.CornerRadius = new CornerRadius(0);
                    //SideMenu.CornerRadius = new CornerRadius(0);

                    wWidth = this.Width;
                    wHeight = this.Height;
                    wLeft = this.Left;
                    wTop = this.Top;

                    // Ajusta el tamaño de la ventana para que no cubra la barra de tareas
                    this.WindowState = WindowState.Normal;
                    this.Left = 0; // Posición izquierda
                    this.Top = SystemParameters.WorkArea.Top; // Posición superior
                    this.Width = SystemParameters.WorkArea.Width; // Ancho igual al área de trabajo
                    this.Height = SystemParameters.WorkArea.Height; // Altura igual al área de trabajo
                    isMax = true;
                }
            }
        }//maximize

        private void CloseButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //timer.Stop();
                this.Close();
            }
        }//Close buton



    }//fin class
}

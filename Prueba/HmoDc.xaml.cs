using Pallets.Models;
using Prueba;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pallets
{
    public partial class HmoDc : Window
    {
        private double wWidth, wHeight, wTop, wLeft;
        private bool isMax = false;
        List<Shipment> shipments, shipmentsFiltrados;
        //ObservableCollection<NumParte> numParte;
        //private DispatcherTimer timer;
        Storyboard loadingAnimation;
        MainWindow mainWindow;
        public HmoDc(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            dgInTransit.MouseDoubleClick += Intransit_MouseDoubleClick;

            loadingAnimation = (Storyboard)FindResource("LoadingAnimation");
            loadingAnimation.Begin();

            bindingDataGrid();
        }

        private void Intransit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Realiza aquí la acción que desees al hacer doble clic en una fila
            // Puedes acceder a la fila seleccionada a través de dataGrid.SelectedItem
            // Por ejemplo, para obtener un valor de la fila seleccionada:
            if (dgInTransit.SelectedItem != null)
            {
                var shipment = (Shipment)dgInTransit.SelectedItem;
                //MessageBox.Show(shipment.Id + " " + shipment.Pgi + " " + shipment.VendorName);
                Shipments shipmentScreen = new Shipments(shipment.CountryOrigin, shipment.VendorName, "", shipment.Pgi, shipment.Id, "Hermosillo");
                mainWindow.ChangeScreen(shipmentScreen);
                //shipmentScreen.Show();
                //shipmentScreen.Activate();
            }
        }//fin Intransit_MouseDoubleClick

        private async Task<List<Shipment>> LoadDataAsync()
        {
            List<Shipment> shipmentsList = new List<Shipment>();
            using (SqlConnection connection = new SqlConnection("Data Source=MXJ21DB100.tycoelectronics.net;Initial Catalog=Procurement;User Id=ProcurementUser;Password=ProcU$r;"))
            {
                await connection.OpenAsync();

                string query = "SELECT ID, PLANTA, FECHA FROM Esquematicos_glog WHERE PLANTA LIKE '%ICT%' OR PLANTA LIKE '%AutoEMP%' ORDER BY FECHA DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            DateTime fecha = (DateTime)reader["FECHA"];
                            int? id = (int)reader["ID"];
                            string? PGI_Date = fecha.ToString("yyyy-MM-dd");
                            string BillOfLading = "";
                            string TrackingNo = "";

                            string VendorName = (string)reader["PLANTA"];
                            string Country = "MX";

                            int Pallets = 0;
                            //int Cartons = reader[4] == DBNull.Value ? 1 : (int)reader[4];

                            shipmentsList.Add(new Shipment(id+"", PGI_Date, BillOfLading, TrackingNo, Country, VendorName, Pallets));
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

            dgInTransit.ItemsSource = shipments;
            loadingAnimation.Stop();
            lblLoading.Visibility = Visibility.Hidden;
            dgInTransit.Visibility = Visibility.Visible;

        }//bindingData

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

    }// fin partial class
}// fin namespace

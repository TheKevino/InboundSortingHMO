using Pallets;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Prueba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double wWidth, wHeight, wTop, wLeft;
        private bool isMax = false;
        private Stack<UIElement> ventanaAnterior = new Stack<UIElement>();
        private string city;
        public MainWindow()
        {
            InitializeComponent();
            btnVolverAtras.Visibility = Visibility.Hidden;
            city = "";
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
            {

                try { this.DragMove(); } catch { }

            }

        }//MouseDown

        private void btnHermosilloClick(object sender, RoutedEventArgs e)
        {
            //Arrivals arrivalsScreen = new Arrivals("Hermosillo", this);
            HmoDc hmoDc = new HmoDc(this);
            lblWindow.Content = city = "Hermosillo DC Arrivals";
            ventanaAnterior.Push(contentControl.Content as UIElement);
            // Asignar el contenido de SecondWindow al ContentControl
            contentControl.Content = hmoDc.Content;
            btnVolverAtras.Visibility = Visibility.Visible;
        }

        private void btnEPClick(object sender, RoutedEventArgs e)
        {
            Arrivals arrivalsScreen = new Arrivals("El Paso", this);
            lblWindow.Content = city = "El Paso DC Arrivals";
            ventanaAnterior.Push(contentControl.Content as UIElement);
            // Asignar el contenido de SecondWindow al ContentControl
            contentControl.Content = arrivalsScreen.Content;
            btnVolverAtras.Visibility = Visibility.Visible;
        }

        public void ChangeScreen(Shipments shpScreen)
        {
            lblWindow.Visibility = Visibility.Collapsed;
            ventanaAnterior.Push(contentControl.Content as UIElement);
            // Asignar el contenido de SecondWindow al ContentControl
            contentControl.Content = shpScreen.Content;
            btnVolverAtras.Visibility = Visibility.Visible;
        }

        private void btnRegresar_click(object sender, RoutedEventArgs e)
        {
            if (ventanaAnterior.Count == 1)
            {
                btnVolverAtras.Visibility = Visibility.Hidden;

                lblWindow.Content = "Choose a City";
            }
            else if (ventanaAnterior.Count == 2)
            {
                lblWindow.Content = city;
                lblWindow.Visibility = Visibility.Visible;
            }
            // Verificar si hay contenido anterior en la pila
            if (ventanaAnterior.Count > 0)
            {
                // Sacar el contenido anterior de la pila y restaurarlo en el ContentControl
                contentControl.Content = ventanaAnterior.Pop();
            }
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
                Application.Current.Shutdown();
            }
        }//Close buton



    }//fin class
}

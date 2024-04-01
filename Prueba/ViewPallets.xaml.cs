using Pallets;
using Pallets.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Prueba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ViewPallets : Window
    {
        private double wWidth, wHeight, wTop, wLeft;
        private bool isMax = false;
        List<NumParte> numParte = new List<NumParte>();

        public ViewPallets(List<NumParte> numParte)
        {
            InitializeComponent();
            this.numParte = numParte;
            dgSortedPallets.ItemsSource = numParte;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
            {

                try { this.DragMove(); } catch { }

            }

        }//MouseDown

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
                //puertoSerial.Close();
                this.Close();
            }
        }//Close buton

    }//fin class
}

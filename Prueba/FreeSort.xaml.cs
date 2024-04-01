using Keyence.AutoID.SDK;
using Pallets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pallets
{
    /// <summary>
    /// Interaction logic for FreeSort.xaml
    /// </summary>
    public partial class FreeSort : Window
    {
        private double wWidth, wHeight, wTop, wLeft;
        private bool isMax = false;

        private ReaderAccessor escaner;
        private ReaderAccessor escaner2;
        private DispatcherTimer timerIndicadores;
        public FreeSort()
        {
            InitializeComponent();
        }

        private void bt_trigger_Click(object sender, RoutedEventArgs e)
        {
            //this.Topmost = true;

            // --------------- PARA INICIAR LOS LECTORES ---------------
            // Conectar comandos
            escaner.IpAddress = "200.14.36.13";
            escaner.Connect((data) =>
            {
                Dispatcher.BeginInvoke(new Action(() => Received(Encoding.ASCII.GetString(data))));
            });

            // Conectar comandos
            escaner2.IpAddress = "200.14.36.12";
            escaner2.Connect((data) =>
            {
                Dispatcher.BeginInvoke(new Action(() => Received(Encoding.ASCII.GetString(data))));
            });

            //Inicializar el temporizador
            timerIndicadores = new DispatcherTimer();
            timerIndicadores.Interval = TimeSpan.FromSeconds(1); // Ajusta el intervalo según sea necesario
            timerIndicadores.Tick += TimerIndicadores_Tick;
            timerIndicadores.Start();
            // ----------------------------------------------------------

            escaner.ExecCommand("LON");
            escaner2.ExecCommand("LON");
            btnScan.Visibility = Visibility.Collapsed;
            btnStop.Visibility = Visibility.Visible;
        }

        private void bt_stop_Click(object sender, RoutedEventArgs e)
        {
            //this.Topmost = false;

            timerIndicadores.Stop();

            escaner.ExecCommand("LOFF");
            escaner2.ExecCommand("LOFF");

            escaner.CloseFtp();
            escaner2.CloseFtp();

            escaner.Dispose();
            escaner2.Dispose();

            btnScan.Visibility = Visibility.Visible;
            btnStop.Visibility = Visibility.Collapsed;
        }

        private void TimerIndicadores_Tick(object sender, EventArgs e)
        {
            if (escaner.LastErrorInfo == ErrorCode.None || escaner.LastErrorInfo == ErrorCode.Timeout)
            {
                txtPartNumber.Text = "";
            }
            else
            {
                txtPartNumber.Text = escaner.LastErrorInfo.ToString();

                // Reconectar escáner
                escaner.Connect((data) =>
                {
                    Dispatcher.BeginInvoke(new Action(() => Received(Encoding.ASCII.GetString(data))));
                });
                // Reconectar escáner
                escaner2.Connect((data) =>
                {
                    Dispatcher.BeginInvoke(new Action(() => Received(Encoding.ASCII.GetString(data))));
                });

                //// Enviar trigger para limpiar el error
                //escaner.ExecCommand("LON");
                //escaner.ExecCommand("LOFF");
                //// Enviar trigger para limpiar el error
                //escaner2.ExecCommand("LON");
                //escaner2.ExecCommand("LOFF");
            }
        }

        private void Received(string receivedData)
        {
            //if (!receivedData.Equals("OpenFailed") && !receivedData.Equals("Closed"))
            //{
            //}
            txtPartNumber.Text = receivedData;
            LeerEtiqueta3S(receivedData);
            //MessageBox.Show(receivedData + " Proceso de recibo");
        }

        private void LeerEtiqueta3S(string receivedData)
        {
            //Match match;
            //string scannedPartNumber = receivedData;

            //// Esperar 2 segundos después del último cambio en el TextBox
            ////await Task.Delay(500);

            ////scannedPartNumber = "´=:06LT3SD27100017168PN1977622'1RVAQT750PO200228802193BT0228802193BX11DC23474";
            //// Utilizar Regex para encontrar la coincidencia en la cadena del código de barras
            //match = Regex.Match(scannedPartNumber, patron);
            //if (match.Success)
            //{
            //    // Obtener el valor capturado entre "PN" y "RVAQT"
            //    string valorExtraido = match.Groups[1].Value;
            //    valorExtraido = valorExtraido.Replace("'", "-");

            //    // Obtener la 3S
            //    match = Regex.Match(scannedPartNumber, patronTresS);
            //    string TresS_extraida = match.Groups[1].Value;

            //    //LOS LECTORES METEN CARACTERES NO IMPRIMIBLES, HAY QUE BORRARLOS, SON INVISIBLES PERO EN EL CODIGO SE INCLUYEN
            //    TresS_extraida = Regex.Replace(TresS_extraida, patronNoImprimibles, "");

            //    if (!(ListaTresS.Contains(TresS_extraida)))
            //    {

            //        string ubicacion = "";
            //        int cartones = 0;
            //        int conteo = 0;
            //        bool found = false, isMixedFull = true;

            //        //LOS LECTORES METEN CARACTERES NO IMPRIMIBLES, HAY QUE BORRARLOS, SON INVISIBLES PERO EN EL CODIGO SE INCLUYEN
            //        valorExtraido = Regex.Replace(valorExtraido, patronNoImprimibles, "");

            //        //NumParte resultadoBusqueda = numParteList.Find(x => x.Material == valorExtraido);
            //        List<NumParte> resultadosBusqueda = this.numParteList.Where(x => x.Material == valorExtraido).ToList();
            //        List<NumParte> resultadosMixed = mixedPallets.Where(p => p.ListaNumParte.Any(m => m.Material == valorExtraido)).ToList();
            //        resultadosBusqueda.AddRange(resultadosMixed);

            //        if (resultadosBusqueda.Any())
            //        {

            //            foreach (var resultado in resultadosBusqueda)
            //            {
            //                if (found) break;
            //                ubicacion = "";
            //                cartones = 0;
            //                conteo = 0;

            //                if (resultado.ListaNumParte.Count > 0) //SI ES MAYOR A CERO SIGNIFICA QUE SE TRATA DE UN MIXED PALLET
            //                {

            //                    foreach (var numParte in resultado.ListaNumParte)
            //                    {

            //                        //Debug.WriteLine("-------- var numParte in resultado.ListaNumParte --------");
            //                        //Debug.WriteLine("Material: " + numParte.Material + ", Conteo: " + numParte.Conteo + ", Cartones: " + numParte.Cartones);

            //                        if (numParte.Material.Equals(valorExtraido))
            //                        {
            //                            ubicacion = resultado.Location;
            //                            cartones = numParte.Cartones;
            //                            conteo = ++numParte.Conteo;
            //                            contadorCartones = contadorCartones + 1;

            //                            //puertoSerial.Write("0");
            //                            //MessageBox.Show("Total: " + resultado.getTotalCartonesMixedPallet() + " Llevas: " + resultado.getTotalConteoMixedPallets());
            //                            if (resultado.getTotalCartonesMixedPallet() == resultado.getTotalConteoMixedPallets())
            //                            {
            //                                resultado.Lleno = true;
            //                                resultado.OnPropertyChanged("Lleno");
            //                            }

            //                            //Debug.WriteLine("-------- numParte.Material.Equals(valorExtraido) && (numParte.Conteo < numParte.Cartones) --------");
            //                            //Debug.WriteLine("Ubicación: " + ubicacion + ", Cartones: " + cartones + ", Conteo: " + conteo);

            //                            ListaTresS.Add(TresS_extraida);
            //                            TresS += TresS_extraida + ",";
            //                            lblConteo.Content = contadorCartones + " / " + totalCartones;

            //                            //AutoReceive(TresS_extraida);//RECIBIR CARTON

            //                            found = true;
            //                            break;
            //                        }// fin if numParte.Material.Equals(valorExtraido) && (numParte.Conteo < numParte.Cartones)
            //                    }//fin foreach var numParte in resultado.ListaNumParte
            //                } //fin if resultado.ListaNumParte.Count > 0
            //                else
            //                {
            //                    foreach (var resultadoValidacion in resultadosBusqueda)
            //                    {
            //                        if (resultadoValidacion.getTotalConteoMixedPallets() >= resultadoValidacion.getTotalCartonesMixedPallet())
            //                        {
            //                            isMixedFull = true;
            //                        }
            //                        else
            //                        {
            //                            isMixedFull = false;
            //                            break;
            //                        }
            //                    }//fin foreach

            //                    if (resultado.NpContados < resultado.Cartons || isMixedFull)
            //                    {
            //                        ubicacion = resultado.Location;
            //                        cartones = resultado.Cartons;
            //                        conteo = ++resultado.NpContados;
            //                        contadorCartones = contadorCartones + 1;
            //                        //puertoSerial.Write("0");

            //                        if (conteo == cartones)
            //                        {
            //                            resultado.Lleno = true;
            //                            resultado.OnPropertyChanged("Lleno");
            //                            //MessageBox.Show("Debio haber cambiado");
            //                        }
            //                        // Obtener la 3S

            //                        ListaTresS.Add(TresS_extraida);
            //                        TresS += TresS_extraida + ",";

            //                        lblConteo.Content = contadorCartones + " / " + totalCartones;

            //                        //AutoReceive(TresS_extraida); //RECIBIR CARTON

            //                        //Debug.WriteLine("-------- ELSE resultado.ListaNumParte.Count > 0 --------");
            //                        //Debug.WriteLine("Ubicación: " + ubicacion + ", Cartones: " + cartones + ", Conteo: " + conteo);

            //                        break;
            //                    }
            //                }//fin resultado.ListaNumParte.Count > 0
            //            }//fin foreach var resultado in resultadosBusqueda


            //            if (ubicacion.Equals(""))
            //            {
            //                //puertoSerial.Write("1");
            //                //MessageBox.Show("El numero de parte " + valorExtraido + " ya esta ubicado en su totalidad\nConteo: " + conteo + " de " + cartones);
            //            }
            //            else
            //            {
            //                recibirScannedMaterial(new ScannedMaterial(valorExtraido, ubicacion));
            //                ChangeFirstRowColor();
            //                //MessageBox.Show("El numero de parte " + valorExtraido + " Va en:\n " + ubicacion + "\n" + conteo + "/" + cartones);
            //            }//fin ubicacion.Equals("")
            //            resultadosMixed.Clear();
            //            resultadosBusqueda.Clear();
            //        }
            //        else
            //        {
            //            //puertoSerial.Write("1");
            //            MessageBox.Show("This PN is not located in the layout.");
            //        }//fin if else resultadosBusqueda.Any()

            //    }
            //    else
            //    {
            //        //puertoSerial.Write("1");
            //        MessageBox.Show("PN already scanned");
            //    }//fin if else match.Success
            //}
            //else
            //{
            //    //puertoSerial.Write("1");
            //    MessageBox.Show("Unrecognized part number");
            //}
            //txtPartNumber.Text = "";
        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            // Reinicia el temporizador cada vez que se realiza un cambio en el TextBox
            //timer.Stop();
            //timer.Start();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
            {

                try { this.DragMove(); } catch { }

            }

            txtPartNumber.Focus();

        }//MouseDown

        private void MinimizeButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.WindowState = WindowState.Minimized;
            }
            txtPartNumber.Focus();
        }//Minimize

        private void MaximizeButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (isMax)
                {
                    PalletWindow.CornerRadius = new CornerRadius(15);
                    TopBorder.CornerRadius = new CornerRadius(15, 15, 0, 0);
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
                    PalletWindow.CornerRadius = new CornerRadius(0);
                    TopBorder.CornerRadius = new CornerRadius(0);
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
                }//fin if else isMax
            } //fin if else e.LeftButton == MouseButtonState.Pressed
            txtPartNumber.Focus();
        }//maximize

        private void CloseButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //timer.Stop();
                //timer.Close();
                //puertoSerial.Close();

                //if (timerIndicadores != null) timerIndicadores.Stop();

                //escaner.ExecCommand("LOFF");
                //escaner2.ExecCommand("LOFF");

                //escaner.CloseFtp();
                //escaner2.CloseFtp();

                //escaner.Dispose();
                //escaner2.Dispose();

                //numParteList.Clear();
                //mixedPallets.Clear();
                //tablaMixedPallets.Clear();
                //ListaTresS.Clear();
                //scanMaterial.Clear();

                this.Close();
            }
        }//Close buton

    }
}

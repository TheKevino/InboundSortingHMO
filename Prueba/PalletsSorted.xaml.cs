using Keyence.AutoID.SDK;
using Pallets.Models;
using Prueba;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Printing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace Pallets
{
    /// <summary>
    /// Interaction logic for PalletsSorted.xaml
    /// </summary>
    public partial class PalletsSorted : Window
    {
        private double wWidth, wHeight, wTop, wLeft;
        private bool isMax = false;
        string TresS, truckNumber;
        int totalCartones, contadorCartones = 0, conteoMixedPallet = 0, resultAndon = 0;

        // Definir el patrón de expresión regular para buscar el texto entre "PN" y "RVAQT"
        string patron = @"3S(.*?)";
        string patronTresS = @"LT(.*?)PN";
        string patronNoImprimibles = @"[\p{C}|\s]";

        public List<NumParte> numParteList { get; set; }
        public List<NumParte> licenseTagList { get; set; }
        public List<NumParte> mixedPallets { get; set; }
        public List<NumParte> tablaMixedPallets { get; set; }
        public List<string> ListaTresS { get; set; }

        List<ScannedMaterial> scanMaterial = new List<ScannedMaterial>();

        private Dictionary<Rectangle, NumParte> rectangulosPorNumParte = new Dictionary<Rectangle, NumParte>();

        private System.Timers.Timer timer;

        private ReaderAccessor escaner;
        private ReaderAccessor escaner2;

        private DispatcherTimer timerIndicadores;

        //SerialPort puertoSerial;

        public PalletsSorted(List<NumParte> numParteList, List<NumParte> tablaMixedPallets, string truckNumber, List<NumParte> licenseTagList)
        {
            InitializeComponent();

            resultAndon = NeUsbController.NeUsbController.NE_OpenDevice();

            if (resultAndon != 0)
            {
                MessageBox.Show("Unable to open andon.");
            }

            escaner = new ReaderAccessor();
            escaner2 = new ReaderAccessor();

            //string st = "";
            //Trace.WriteLine("PalletSorted");
            //foreach (var np in tablaMixedPallets)
            //{
            //    st += "\n" + np.Tipo + " " + np.Material + " " + np.Cartons + " " + np.Location;
            //}

            //Trace.Write(st);

            // Suscribirse al evento Loaded para establecer el foco inicialmente
            Loaded += PalletsSorted_Loaded;
            this.DataContext = numParteList;
            this.ListaTresS = new List<string>();

            this.numParteList = numParteList
                                .Where(np => np.Material == "*****" || np.Material == "-----")
                                .ToList();

            this.mixedPallets = new List<NumParte>();
            this.tablaMixedPallets = tablaMixedPallets;
            this.TresS = "";
            this.totalCartones = TotalCartones();
            lblConteo.Content = contadorCartones + " / " + totalCartones;
            this.truckNumber = truckNumber.Replace(" ", String.Empty);
            this.licenseTagList = licenseTagList;

            Dibujar_PalletsSortTwo(this.numParteList);

            timer = new System.Timers.Timer(500);
            timer.AutoReset = false; // El temporizador no se reiniciará automáticamente
            //Manejar el evento Elapsed del temporizador
            timer.Elapsed += Timer_Elapsed_Dos;

            //this.tablaMixedPallets = tablaMixedPallets;

            // --------------- PARA INICIAR LOS LECTORES ---------------
            // Conectar comandos
            //escaner.IpAddress = "200.14.36.13";
            //escaner.Connect((data) =>
            //{
            //    Dispatcher.BeginInvoke(new Action(() => Received(Encoding.ASCII.GetString(data))));
            //});

            //// Conectar comandos
            //escaner2.IpAddress = "200.14.36.12";
            //escaner2.Connect((data) =>
            //{
            //    Dispatcher.BeginInvoke(new Action(() => Received(Encoding.ASCII.GetString(data))));
            //});

            //// Inicializar el temporizador
            //timerIndicadores = new DispatcherTimer();
            //timerIndicadores.Interval = TimeSpan.FromSeconds(1); // Ajusta el intervalo según sea necesario
            //timerIndicadores.Tick += TimerIndicadores_Tick;
            //timerIndicadores.Start();
            // ----------------------------------------------------------

            //Dibujar_Pallets();
        }//fin constructor

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
            LeerEtiqueta3SAsync(receivedData);
            //MessageBox.Show(receivedData + " Proceso de recibo");
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

        public List<NumParte> GetNumParteList()
        {
            return numParteList;
        }

        public void Dibujar_PalletsSortTwo(List<NumParte> numParteList)
        {
            int contadorNP = numParteList.Count;

            // Iterar sobre la lista de objetos
            for (int i = 0; i < contadorNP; i++)
            {

                string updatedText = "";

                // Crear un rectángulo
                Grid grid = new Grid();
                grid.Margin = new Thickness(0, 0, 0, 1);

                Rectangle rectangle = new Rectangle();
                rectangle.Width = 180;
                rectangle.Height = 135;
                rectangle.Margin = new Thickness(5);

                TextBlock txtBlock = new TextBlock();
                txtBlock.HorizontalAlignment = HorizontalAlignment.Center;
                txtBlock.VerticalAlignment = VerticalAlignment.Center;
                txtBlock.TextAlignment = TextAlignment.Center;

                TextBlock txtBlockLocation = new TextBlock();
                txtBlockLocation.HorizontalAlignment = HorizontalAlignment.Center;
                txtBlockLocation.VerticalAlignment = VerticalAlignment.Center;
                txtBlockLocation.TextAlignment = TextAlignment.Center;

                if (numParteList[i] != null)
                {

                    if (numParteList[i].Lleno)
                    {
                        rectangle.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2E7D32"));
                    }
                    else
                    {
                        rectangle.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1b1b1b"));
                    }

                    numParteList[i].PropertyChanged += Status_PropertyChanged;
                    rectangulosPorNumParte[rectangle] = numParteList[i]; // <---------------- Aqui almaceno los rectangulos

                    rectangle.RadiusX = 10;
                    rectangle.RadiusY = 10;
                    rectangle.VerticalAlignment = VerticalAlignment.Bottom;
                    rectangle.HorizontalAlignment = HorizontalAlignment.Center;


                    if (numParteList[i].Material.Equals("-----"))
                    {
                        numParteList[i].Material = "Mixed";
                        mixedPallets.Add(numParteList[i]);
                        txtBlock.Text += numParteList[i].Material + ": 0/" + numParteList[i].getTotalCartonesMixedPallet() + "\n";

                        foreach (NumParte item in numParteList[i].ListaNumParte)
                        {
                            NumParte npTemporal = numParteList[i];
                            item.PropertyChanged += (sender, e) =>
                            {
                                // Asegúrate de ejecutar la modificación en el hilo de interfaz de usuario (UI thread)
                                txtBlock.Dispatcher.Invoke(() =>
                                {
                                    NumParte np = ((NumParte)sender);
                                    txtBlock.Text = $"{npTemporal.Material}: {npTemporal.getTotalConteoMixedPallets()} / {npTemporal.getTotalCartonesMixedPallet()}";
                                    txtBlockLocation.Text = "\n \n \n" + npTemporal.Location;
                                });
                            };
                        }//fin for
                    }
                    else
                    {
                        foreach (var np in numParteList[i].ListaNumParte)
                        {
                            updatedText += $"{np.Material}: 0/{np.Cartons}\n";
                        }//foreach

                        txtBlock.Text = updatedText;

                        foreach (var nParte in numParteList[i].ListaNumParte)
                        {
                            nParte.PropertyChanged += (sender, e) =>
                            {
                                if (e.PropertyName == "NpContados")
                                {
                                    updatedText = updatedText.Replace($"{nParte.Material}: {nParte.NpContados - 1}/{nParte.Cartons}", $"{nParte.Material}: {nParte.NpContados}/{nParte.Cartons}");
                                    txtBlock.Text = updatedText;
                                }
                            }; //fin PropertyChanged
                        }//foreach

                    }//fin if else

                    //txtBlock.Text += numParteList[i].Material + ": 0/" + numParteList[i].getTotalCartonesMixedPallet();

                    txtBlock.FontSize = numParteList[i].Material.Length > 9 ? 9 : 12;
                    //txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB3B"));
                    txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB3B"));

                    txtBlockLocation.Text += "\n\n\n\n" + numParteList[i].Location;
                    txtBlockLocation.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB3B"));
                    txtBlockLocation.FontSize = 20;
                }
                else
                {
                    rectangle.Fill = new SolidColorBrush(Colors.Transparent);
                    rectangle.Stroke = new SolidColorBrush(Colors.Black);

                    txtBlock.Text = "";
                }

                grid.Children.Add(rectangle);
                grid.Children.Add(txtBlock);
                grid.Children.Add(txtBlockLocation);
                //grid.Children.Add(txtBlock2);

                // Agregar el rectángulo al Grid correspondiente
                if (numParteList[i].Location.StartsWith('A'))
                {
                    if (ColCuatro.Children.Count < 5)
                    {
                        ColCuatro.Children.Add(grid);
                    }
                    else if (ColTres.Children.Count < 5)
                    {
                        ColTres.Children.Add(grid);
                    }
                    else if (ColDos.Children.Count < 5)
                    {
                        ColDos.Children.Add(grid);
                    }
                    else
                    {
                        ColUno.Children.Add(grid);
                    }
                }
                else
                { //si es B se viene para aca
                    if (ColCinco.Children.Count < 5)
                    {
                        ColCinco.Children.Add(grid);
                    }
                    else if (ColSeis.Children.Count < 5)
                    {
                        ColSeis.Children.Add(grid);
                    }
                    else if (ColSiete.Children.Count < 5)
                    {
                        ColSiete.Children.Add(grid);
                    }
                    else
                    {
                        ColOcho.Children.Add(grid);
                    }
                }//fin if else

            }//for int i = 0; i < numParteList.Count; i++

        }//Dibujar_PalletsSortTwo

        private int TotalCartones()
        {
            int totalCartones = 0;
            foreach (NumParte np in numParteList)
            {
                if (np.ListaNumParte.Count > 0)
                {
                    foreach (NumParte npMix in np.ListaNumParte)
                    {
                        totalCartones = totalCartones + npMix.Cartons;
                    }//fin foreach
                }
                else
                {
                    totalCartones = totalCartones + np.Cartons;
                }
            }//fin foreach
            return totalCartones;
        }//fin TotalCartones

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
            {

                try { this.DragMove(); } catch { }

            }

            txtPartNumber.Focus();

        }//MouseDown

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                colTable.Width = new GridLength(50);
                dgScannedMaterial.Visibility = Visibility.Collapsed;

                //get selected printer capabilities

                PrintCapabilities capabilities = printDialog.PrintQueue.GetPrintCapabilities(printDialog.PrintTicket);
                double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / this.ActualWidth, capabilities.PageImageableArea.ExtentHeight / PalletSorting.ActualHeight);

                //Transform the Visual to scale
                this.LayoutTransform = new ScaleTransform(scale, scale);

                //get the size of the printer page
                Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);

                //update the layout of the visual to the printer page size.

                this.Measure(sz);
                this.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));

                //now print the visual to printer to fit on the one page.
                printDialog.PrintVisual(PalletSorting, "PalletLayout");

            }
            dgScannedMaterial.Visibility = Visibility.Visible;
            colTable.Width = new GridLength(400);
            txtPartNumber.Focus();
        }// Imprimir_Click

        //private void txtPartNumberChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (!(txtPartNumber.Text.Equals("")))
        //    {
        //        timer.Stop();
        //        timer.Start();
        //    }
        //    // Detener el temporizador si está corriendo y reiniciar
        //}

        private async Task LeerEtiqueta3SAsync(string receivedData)
        {
            Match match;
            string scannedPartNumber = receivedData;
            string valorExtraido = "";
            // Esperar 2 segundos después del último cambio en el TextBox
            //await Task.Delay(500);

            //scannedPartNumber = "´=:06LT3SD27100017168PN1977622'1RVAQT750PO200228802193BT0228802193BX11DC23474";
            // Utilizar Regex para encontrar la coincidencia en la cadena del código de barras

            if (scannedPartNumber.Length > 0)
            {

                match = Regex.Match(scannedPartNumber, patron);
                if (match.Success)
                {
                    //LOS LECTORES METEN CARACTERES NO IMPRIMIBLES, HAY QUE BORRARLOS, SON INVISIBLES PERO EN EL CODIGO SE INCLUYEN
                    scannedPartNumber = Regex.Replace(scannedPartNumber, patronNoImprimibles, "");

                    NumParte npCon3S = licenseTagList.Find(item => item.Tres_s == scannedPartNumber);

                    if ((npCon3S != null) && !ListaTresS.Contains(npCon3S.Tres_s))
                    {

                        string ubicacion = "";
                        int cartones = 0;
                        int conteo = 0;
                        bool found = false, isMixedFull = true;

                        //LOS LECTORES METEN CARACTERES NO IMPRIMIBLES, HAY QUE BORRARLOS, SON INVISIBLES PERO EN EL CODIGO SE INCLUYEN
                        valorExtraido = npCon3S.Material;

                        //NumParte resultadoBusqueda = numParteList.Find(x => x.Material == valorExtraido);
                        List<NumParte> resultadosBusqueda = numParteList.Where(p => p.ListaNumParte.Any(m => m.Material == valorExtraido)).ToList();
                        List<NumParte> resultadosMixed = mixedPallets.Where(p => p.ListaNumParte.Any(m => m.Material == valorExtraido)).ToList();

                        if (resultadosMixed.Count > 0)
                        {
                            foreach (NumParte np in resultadosMixed[0].ListaNumParte)
                            {
                                if (np.Material == valorExtraido)
                                {
                                    resultadosBusqueda.Add(np);
                                    break;
                                }//fin if
                            }//fin foreach
                        }//fin if

                        //resultadosBusqueda.AddRange(resultadosMixed);

                        if (resultadosBusqueda.Any())
                        {
                            //MessageBox.Show("Se encontro");
                            foreach (var resultado in resultadosBusqueda)
                            {
                                if (found) break;
                                ubicacion = "";
                                cartones = 0;
                                conteo = 0;

                                if (resultado.ListaNumParte.Count > 0) //SI ES MAYOR A CERO SIGNIFICA QUE SE TRATA DE UN MIXED PALLET
                                {
                                    //MessageBox.Show("Se encontro en mixed pallet");
                                    foreach (NumParte numParte in resultado.ListaNumParte)
                                    {
                                        //Debug.WriteLine("-------- var numParte in resultado.ListaNumParte --------");
                                        //Debug.WriteLine("Material: " + numParte.Material + ", Conteo: " + numParte.Conteo + ", Cartones: " + numParte.Cartones);

                                        if (numParte.Material.Equals(valorExtraido))
                                        {
                                            //MessageBox.Show($"Se encontro el np {valorExtraido} en la lista {numParte.Material}");

                                            ubicacion = resultado.Location;
                                            cartones = numParte.Cartons;
                                            conteo = ++numParte.NpContados;
                                            contadorCartones = contadorCartones + 1;

                                            //MessageBox.Show("Total: " + resultado.getTotalCartonesMixedPallet() + " Llevas: " + resultado.getTotalConteoMixedPallets());

                                            //puertoSerial.Write("0");
                                            if (resultado.getTotalCartonesMixedPallet() == resultado.getTotalConteoMixedPallets())
                                            {
                                                resultado.Lleno = true;
                                                resultado.OnPropertyChanged("Lleno");
                                            }

                                            //Debug.WriteLine("-------- numParte.Material.Equals(valorExtraido) && (numParte.Conteo < numParte.Cartones) --------");
                                            //Debug.WriteLine("Ubicación: " + ubicacion + ", Cartones: " + cartones + ", Conteo: " + conteo);

                                            ListaTresS.Add(npCon3S.Tres_s);
                                            TresS += npCon3S.Tres_s + ",";
                                            lblConteo.Content = contadorCartones + " / " + totalCartones;

                                            // AutoReceive(TresS_extraida);//RECIBIR CARTON

                                            found = true;
                                            break;
                                        }// fin if numParte.Material.Equals(valorExtraido) && (numParte.Conteo < numParte.Cartones)
                                    }//fin foreach var numParte in resultado.ListaNumParte
                                } //fin if resultado.ListaNumParte.Count > 0
                                else
                                {
                                    foreach (var resultadoValidacion in resultadosBusqueda)
                                    {
                                        if (resultadoValidacion.getTotalConteoMixedPallets() >= resultadoValidacion.getTotalCartonesMixedPallet())
                                        {
                                            isMixedFull = true;
                                        }
                                        else
                                        {
                                            isMixedFull = false;
                                            break;
                                        }
                                    }//fin foreach

                                    if (resultado.NpContados < resultado.Cartons || isMixedFull)
                                    {
                                        ubicacion = resultado.Location;
                                        cartones = resultado.Cartons;
                                        conteo = ++resultado.NpContados;
                                        contadorCartones = contadorCartones + 1;
                                        //puertoSerial.Write("0");

                                        if (conteo == cartones)
                                        {
                                            resultado.Lleno = true;
                                            resultado.OnPropertyChanged("Lleno");
                                            //MessageBox.Show("Debio haber cambiado");
                                        }
                                        // Obtener la 3S

                                        ListaTresS.Add(npCon3S.Tres_s);
                                        TresS += npCon3S.Tres_s + ",";

                                        lblConteo.Content = contadorCartones + " / " + totalCartones;

                                        //AutoReceive(TresS_extraida); //RECIBIR CARTON

                                        //Debug.WriteLine("-------- ELSE resultado.ListaNumParte.Count > 0 --------");
                                        //Debug.WriteLine("Ubicación: " + ubicacion + ", Cartones: " + cartones + ", Conteo: " + conteo);

                                        break;
                                    }
                                }//fin resultado.ListaNumParte.Count > 0
                            }//fin foreach var resultado in resultadosBusqueda


                            if (ubicacion.Equals(""))
                            {
                                //puertoSerial.Write("1");
                                //MessageBox.Show("El numero de parte " + valorExtraido + " ya esta ubicado en su totalidad\nConteo: " + conteo + " de " + cartones);
                            }
                            else
                            {
                                recibirScannedMaterial(new ScannedMaterial(valorExtraido, ubicacion));
                                ChangeFirstRowColor();
                                resultAndon = NeUsbController.NeUsbController.NE_SetLight(NeUsbController.LEDColors.Green, NeUsbController.LEDPatterns.Continuous);
                                txtPartNumber.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#66BB6A"));

                                // Iterar sobre el diccionario para buscar una coincidencia con el contenido de la etiqueta
                                foreach (var item in rectangulosPorNumParte)
                                {
                                    // Iterar sobre la lista de números de parte dentro del NumParte actual
                                    foreach (var numParte in item.Value.ListaNumParte)
                                    {
                                        // Reemplaza 'Identificador' con la propiedad real que quieres comparar
                                        if (string.Equals(numParte.Material, valorExtraido, StringComparison.OrdinalIgnoreCase))
                                        {
                                            item.Key.Fill = new SolidColorBrush(Colors.Green);
                                            // Crear y configurar el timer
                                            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.5) };
                                            timer.Tick += (sender, args) =>
                                            {
                                                // Cambiar el color del rectángulo a negro
                                                item.Key.Fill = new SolidColorBrush(Colors.Black);
                                                // Detener el timer
                                                timer.Stop();
                                            };

                                            // Iniciar el timer
                                            timer.Start();
                                            break; // Rompe el bucle interno si encuentras una coincidencia
                                        }
                                    }
                                }

                                //MessageBox.Show("El numero de parte " + valorExtraido + " Va en:\n " + ubicacion + "\n" + conteo + "/" + cartones);
                            }//fin ubicacion.Equals("")
                             //resultadosMixed.Clear();
                            resultadosBusqueda.Clear();
                        }
                        else
                        {
                            //puertoSerial.Write("1");
                            //MessageBox.Show("This PN is not located in the layout.");
                            resultAndon = NeUsbController.NeUsbController.NE_SetLight(NeUsbController.LEDColors.Blue, NeUsbController.LEDPatterns.Continuous);
                            txtPartNumber.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#90CAF9"));
                        }//fin if else resultadosBusqueda.Any()

                    }
                    else
                    {
                        //puertoSerial.Write("1");
                        //MessageBox.Show("PN already scanned");
                        resultAndon = NeUsbController.NeUsbController.NE_SetLight(NeUsbController.LEDColors.Amber, NeUsbController.LEDPatterns.Continuous);
                        txtPartNumber.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB3B"));
                    }//fin if else match.Success
                }
                else
                {
                    //puertoSerial.Write("1");
                    //MessageBox.Show("Unrecognized part number");
                    resultAndon = NeUsbController.NeUsbController.NE_SetLight(NeUsbController.LEDColors.Red, NeUsbController.LEDPatterns.Continuous);
                    txtPartNumber.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EF5350"));
                }
                txtPartNumber.Text = "";
                // Espera 1 segundo utilizando Task.Delay
                await Task.Delay(1000);
                resultAndon = NeUsbController.NeUsbController.NE_SetLight(NeUsbController.LEDColors.OFF, NeUsbController.LEDPatterns.Continuous);
                txtPartNumber.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            }//fin scannedPartNumber.Length > 0
        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            // Reinicia el temporizador cada vez que se realiza un cambio en el TextBox
            timer.Stop();
            timer.Start();
        }

        private void Timer_Elapsed_Dos(object? sender, ElapsedEventArgs e)
        {

            // Este método se ejecutará después de 1 segundo de inactividad en el TextBox
            Dispatcher.Invoke(async () =>
            {
                Match match;
                string scannedPartNumber = txtPartNumber.Text;
                string valorExtraido = "";
                // Esperar 2 segundos después del último cambio en el TextBox
                //await Task.Delay(500);

                //scannedPartNumber = "´=:06LT3SD27100017168PN1977622'1RVAQT750PO200228802193BT0228802193BX11DC23474";
                // Utilizar Regex para encontrar la coincidencia en la cadena del código de barras

                if (scannedPartNumber.Length > 0)
                {

                    match = Regex.Match(scannedPartNumber, patron);
                    if (match.Success)
                    {
                        //LOS LECTORES METEN CARACTERES NO IMPRIMIBLES, HAY QUE BORRARLOS, SON INVISIBLES PERO EN EL CODIGO SE INCLUYEN
                        scannedPartNumber = Regex.Replace(scannedPartNumber, patronNoImprimibles, "");

                        NumParte npCon3S = licenseTagList.Find(item => item.Tres_s == scannedPartNumber);

                        if ((npCon3S != null) && !ListaTresS.Contains(npCon3S.Tres_s))
                        {

                            string ubicacion = "";
                            int cartones = 0;
                            int conteo = 0;
                            bool found = false, isMixedFull = true;

                            //LOS LECTORES METEN CARACTERES NO IMPRIMIBLES, HAY QUE BORRARLOS, SON INVISIBLES PERO EN EL CODIGO SE INCLUYEN
                            valorExtraido = npCon3S.Material;

                            //NumParte resultadoBusqueda = numParteList.Find(x => x.Material == valorExtraido);
                            List<NumParte> resultadosBusqueda = numParteList.Where(p => p.ListaNumParte.Any(m => m.Material == valorExtraido)).ToList();
                            List<NumParte> resultadosMixed = mixedPallets.Where(p => p.ListaNumParte.Any(m => m.Material == valorExtraido)).ToList();

                            if (resultadosMixed.Count > 0)
                            {
                                foreach (NumParte np in resultadosMixed[0].ListaNumParte)
                                {
                                    if (np.Material == valorExtraido)
                                    {
                                        resultadosBusqueda.Add(np);
                                        break;
                                    }//fin if
                                }//fin foreach
                            }//fin if

                            //resultadosBusqueda.AddRange(resultadosMixed);

                            if (resultadosBusqueda.Any())
                            {
                                //MessageBox.Show("Se encontro");
                                foreach (var resultado in resultadosBusqueda)
                                {
                                    if (found) break;
                                    ubicacion = "";
                                    cartones = 0;
                                    conteo = 0;

                                    if (resultado.ListaNumParte.Count > 0) //SI ES MAYOR A CERO SIGNIFICA QUE SE TRATA DE UN MIXED PALLET
                                    {
                                        //MessageBox.Show("Se encontro en mixed pallet");
                                        foreach (NumParte numParte in resultado.ListaNumParte)
                                        {
                                            //Debug.WriteLine("-------- var numParte in resultado.ListaNumParte --------");
                                            //Debug.WriteLine("Material: " + numParte.Material + ", Conteo: " + numParte.Conteo + ", Cartones: " + numParte.Cartones);

                                            if (numParte.Material.Equals(valorExtraido))
                                            {
                                                //MessageBox.Show($"Se encontro el np {valorExtraido} en la lista {numParte.Material}");

                                                ubicacion = resultado.Location;
                                                cartones = numParte.Cartons;
                                                conteo = ++numParte.NpContados;
                                                contadorCartones = contadorCartones + 1;

                                                //MessageBox.Show("Total: " + resultado.getTotalCartonesMixedPallet() + " Llevas: " + resultado.getTotalConteoMixedPallets());

                                                //puertoSerial.Write("0");
                                                if (resultado.getTotalCartonesMixedPallet() == resultado.getTotalConteoMixedPallets())
                                                {
                                                    resultado.Lleno = true;
                                                    resultado.OnPropertyChanged("Lleno");
                                                }

                                                //Debug.WriteLine("-------- numParte.Material.Equals(valorExtraido) && (numParte.Conteo < numParte.Cartones) --------");
                                                //Debug.WriteLine("Ubicación: " + ubicacion + ", Cartones: " + cartones + ", Conteo: " + conteo);

                                                ListaTresS.Add(npCon3S.Tres_s);
                                                TresS += npCon3S.Tres_s + ",";
                                                lblConteo.Content = contadorCartones + " / " + totalCartones;

                                                // AutoReceive(TresS_extraida);//RECIBIR CARTON

                                                found = true;
                                                break;
                                            }// fin if numParte.Material.Equals(valorExtraido) && (numParte.Conteo < numParte.Cartones)
                                        }//fin foreach var numParte in resultado.ListaNumParte
                                    } //fin if resultado.ListaNumParte.Count > 0
                                    else
                                    {
                                        foreach (var resultadoValidacion in resultadosBusqueda)
                                        {
                                            if (resultadoValidacion.getTotalConteoMixedPallets() >= resultadoValidacion.getTotalCartonesMixedPallet())
                                            {
                                                isMixedFull = true;
                                            }
                                            else
                                            {
                                                isMixedFull = false;
                                                break;
                                            }
                                        }//fin foreach

                                        if (resultado.NpContados < resultado.Cartons || isMixedFull)
                                        {
                                            ubicacion = resultado.Location;
                                            cartones = resultado.Cartons;
                                            conteo = ++resultado.NpContados;
                                            contadorCartones = contadorCartones + 1;
                                            //puertoSerial.Write("0");

                                            if (conteo == cartones)
                                            {
                                                resultado.Lleno = true;
                                                resultado.OnPropertyChanged("Lleno");
                                                //MessageBox.Show("Debio haber cambiado");
                                            }
                                            // Obtener la 3S

                                            ListaTresS.Add(npCon3S.Tres_s);
                                            TresS += npCon3S.Tres_s + ",";

                                            lblConteo.Content = contadorCartones + " / " + totalCartones;

                                            //AutoReceive(TresS_extraida); //RECIBIR CARTON

                                            //Debug.WriteLine("-------- ELSE resultado.ListaNumParte.Count > 0 --------");
                                            //Debug.WriteLine("Ubicación: " + ubicacion + ", Cartones: " + cartones + ", Conteo: " + conteo);

                                            break;
                                        }
                                    }//fin resultado.ListaNumParte.Count > 0
                                }//fin foreach var resultado in resultadosBusqueda


                                if (ubicacion.Equals(""))
                                {
                                    //puertoSerial.Write("1");
                                    //MessageBox.Show("El numero de parte " + valorExtraido + " ya esta ubicado en su totalidad\nConteo: " + conteo + " de " + cartones);
                                }
                                else
                                {
                                    recibirScannedMaterial(new ScannedMaterial(valorExtraido, ubicacion));
                                    ChangeFirstRowColor();
                                    resultAndon = NeUsbController.NeUsbController.NE_SetLight(NeUsbController.LEDColors.Green, NeUsbController.LEDPatterns.Continuous);
                                    txtPartNumber.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#66BB6A"));

                                    // Iterar sobre el diccionario para buscar una coincidencia con el contenido de la etiqueta
                                    foreach (var item in rectangulosPorNumParte)
                                    {
                                        // Iterar sobre la lista de números de parte dentro del NumParte actual
                                        foreach (var numParte in item.Value.ListaNumParte)
                                        {
                                            // Reemplaza 'Identificador' con la propiedad real que quieres comparar
                                            if (string.Equals(numParte.Material, valorExtraido, StringComparison.OrdinalIgnoreCase))
                                            {
                                                item.Key.Fill = new SolidColorBrush(Colors.Green);
                                                // Crear y configurar el timer
                                                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.5) };
                                                timer.Tick += (sender, args) =>
                                                {
                                                    // Cambiar el color del rectángulo a negro
                                                    item.Key.Fill = new SolidColorBrush(Colors.Black);
                                                    // Detener el timer
                                                    timer.Stop();
                                                };

                                                // Iniciar el timer
                                                timer.Start();
                                                break; // Rompe el bucle interno si encuentras una coincidencia
                                            }
                                        }
                                    }

                                    //MessageBox.Show("El numero de parte " + valorExtraido + " Va en:\n " + ubicacion + "\n" + conteo + "/" + cartones);
                                }//fin ubicacion.Equals("")
                                //resultadosMixed.Clear();
                                resultadosBusqueda.Clear();
                            }
                            else
                            {
                                //puertoSerial.Write("1");
                                //MessageBox.Show("This PN is not located in the layout.");
                                resultAndon = NeUsbController.NeUsbController.NE_SetLight(NeUsbController.LEDColors.Blue, NeUsbController.LEDPatterns.Continuous);
                                txtPartNumber.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#90CAF9"));
                            }//fin if else resultadosBusqueda.Any()

                        }
                        else
                        {
                            //puertoSerial.Write("1");
                            //MessageBox.Show("PN already scanned");
                            resultAndon = NeUsbController.NeUsbController.NE_SetLight(NeUsbController.LEDColors.Amber, NeUsbController.LEDPatterns.Continuous);
                            txtPartNumber.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB3B"));
                        }//fin if else match.Success
                    }
                    else
                    {
                        //puertoSerial.Write("1");
                        //MessageBox.Show("Unrecognized part number");
                        resultAndon = NeUsbController.NeUsbController.NE_SetLight(NeUsbController.LEDColors.Red, NeUsbController.LEDPatterns.Continuous);
                        txtPartNumber.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EF5350"));
                    }
                    txtPartNumber.Text = "";
                    // Espera 1 segundo utilizando Task.Delay
                    await Task.Delay(1000);
                    resultAndon = NeUsbController.NeUsbController.NE_SetLight(NeUsbController.LEDColors.OFF, NeUsbController.LEDPatterns.Continuous);
                    txtPartNumber.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                }//fin scannedPartNumber.Length > 0
            });
        }//Fin metodo

        public void recibirScannedMaterial(ScannedMaterial scannedMat)
        {
            scanMaterial.Insert(0, scannedMat);
            dgScannedMaterial.ItemsSource = scanMaterial.ToList();
            dgScannedMaterial.ScrollIntoView(scannedMat);
        }

        private void ChangeFirstRowColor()
        {
            if (dgScannedMaterial.Items.Count > 0)
            {
                var lastRow = dgScannedMaterial.ItemContainerGenerator.ContainerFromIndex(0) as DataGridRow;

                if (lastRow != null)
                {
                    // Cambiar el color de fondo de la última fila
                    lastRow.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD54F"));
                    lastRow.Foreground = Brushes.Black;
                }
            }
        }

        private void Status_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Lleno")
            {
                NumParte numParte = sender as NumParte; // Obtén el objeto NumParte afectado

                // Encuentra el rectángulo asociado a este objeto NumParte en el diccionario
                foreach (var entry in rectangulosPorNumParte)
                {
                    if (entry.Value == numParte)
                    {
                        Rectangle rectangulo = entry.Key; // Obtén el rectángulo asociado a este NumParte

                        // Actualiza el color del rectángulo basado en el estado de la propiedad Lleno
                        if (numParte.Lleno)
                        {
                            rectangulo.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2E7D32"));
                        }
                        else
                        {
                            rectangulo.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1b1b1b"));
                        }

                        // Sal del bucle una vez que hayas encontrado y actualizado el rectángulo
                        break;
                    }//fin if
                }//fin foreach
            }

        }//Status_PropertyChanged

        private void NumParteMixedPallet_ConteoChanged(object sender, int nuevoValorConteo, TextBlock txtBlock, NumParte numPartee)
        {
            // Actualizar el Label cuando cambie Cartones
            if (sender is NumParteMixedPallet numParte)
            {
                // Actualizar el texto del Label con el nuevo valor de Cartones
                txtBlock.Dispatcher.Invoke(() =>
                {
                    txtBlock.Text = $"{numPartee.getTotalConteoMixedPallets()} / {numPartee.getTotalCartonesMixedPallet()}";
                });
            }
        }

        private void PalletsSorted_Loaded(object sender, RoutedEventArgs e)
        {
            // Establecer el foco en el TextBox cuando se carga la ventana
            txtPartNumber.Focus();
        }

        private async void Receive_Click(object sender, RoutedEventArgs e)
        {
            //Obtener la ruta relativa del archivo VBScript
            string rutaScriptVB = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts", "Recibir.vbs");

            // Crear un proceso para ejecutar el script VBS sin argumentos
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = "cscript"; // Utiliza cscript para ejecutar scripts VBS desde la línea de comandos
            startInfo.Arguments = $"\"{rutaScriptVB}\" {TresS} {truckNumber.Replace(" ", String.Empty)}";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //this.Topmost = true;
            // Ejecutar el proceso en segundo plano
            await Task.Run(() =>
            {
                using (Process proceso = Process.Start(startInfo))
                {
                    if (proceso != null)
                    {
                        // Leer la salida estándar (si es necesario)
                        string resultado = proceso.StandardOutput.ReadToEnd();
                        proceso.WaitForExit();
                        TresS = "";
                    }
                }
            });
            //this.Topmost = false;

        }

        private async void AutoReceive(string etiqueta3S)
        {
            //Obtener la ruta relativa del archivo VBScript
            string rutaScriptVB = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts", "AutoReceive.vbs");

            // Crear un proceso para ejecutar el script VBS sin argumentos
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = "cscript"; // Utiliza cscript para ejecutar scripts VBS desde la línea de comandos
            startInfo.Arguments = $"\"{rutaScriptVB}\" {etiqueta3S} {truckNumber}";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;


            // Ejecutar el proceso en segundo plano
            await Task.Run(() =>
            {
                using (Process proceso = Process.Start(startInfo))
                {
                    if (proceso != null)
                    {
                        // Leer la salida estándar (si es necesario)
                        string resultado = proceso.StandardOutput.ReadToEnd();
                        proceso.WaitForExit();
                        TresS = "";
                    }
                }
            });

        }

        //public void OnWindowClosing(object sender, CancelEventArgs e)
        //{
        //    //puertoSerial.Close();
        //    timer.Close();
        //}

        private void ViewPallets_Click(object sender, RoutedEventArgs e)
        {
            ViewPallets vPallets = new ViewPallets(tablaMixedPallets);
            vPallets.Show();
        }

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

                if (timerIndicadores != null) timerIndicadores.Stop();

                escaner.ExecCommand("LOFF");
                escaner2.ExecCommand("LOFF");

                escaner.CloseFtp();
                escaner2.CloseFtp();

                escaner.Dispose();
                escaner2.Dispose();

                numParteList.Clear();
                mixedPallets.Clear();
                tablaMixedPallets.Clear();
                ListaTresS.Clear();
                scanMaterial.Clear();

                this.Close();
            }
        }//Close buton


    }//fin clase
}

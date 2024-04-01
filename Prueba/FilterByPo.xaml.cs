using Prueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pallets
{
    /// <summary>
    /// Interaction logic for FilterByPo.xaml
    /// </summary>
    public partial class FilterByPo : Window
    {
        List<string> listaPOs, POsSeleccionadas;
        Shipments shipmentsScreen;
        public FilterByPo( List<string> listaPOs, Shipments shipmentsScreen )
        {
            InitializeComponent();
            this.listaPOs = listaPOs;
            this.shipmentsScreen = shipmentsScreen;
            POsSeleccionadas = new List<string>();
            EnlistarPOs();
        }

        private void EnlistarPOs() {
            foreach (string po in listaPOs)
            {
                if (!po.Equals(""))
                {
                    // Crear un nuevo CheckBox con el valor de PO correspondiente
                    CheckBox checkBoxPO = new CheckBox();
                    checkBoxPO.Content = po;
                    checkBoxPO.Margin = new Thickness(5);

                    // Manejar el evento Checked para saber cuándo se marca o desmarca un checkbox
                    checkBoxPO.Checked += (sender, e) =>
                    {
                        // Acción al marcar el checkbox
                        // Por ejemplo: Mostrar el valor seleccionado
                        var selectedPO = ((CheckBox)sender).Content as string;
                        if (selectedPO != null)
                        {
                            POsSeleccionadas.Add(selectedPO);
                        }
                    };

                    // Agregar el checkbox al ListBox
                    spContenedor.Children.Add(checkBoxPO);
                }//fin if
            }//fin foreach
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            shipmentsScreen.RecibirPOsFiltradas(POsSeleccionadas);
            listaPOs.Clear();
            POsSeleccionadas.Clear();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pallets.Models
{
    public class NumParteMixedPallet : INotifyPropertyChanged
    {
        string material;
        int cartones;
        int conteo;

        public NumParteMixedPallet(string material, int cartones)
        {
            this.Material = material;
            this.Cartones = cartones;
            this.Conteo = 0;
            //this.Conteo = cartones-2;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Material { get => material; set => material = value; }
        public int Cartones { get => cartones; set => cartones = value; }
        public int Conteo
        {
            get { return conteo; }
            set
            {
                if (conteo != value)
                {
                    conteo = value;
                    OnPropertyChanged("Conteo");
                }
            }
        }//fin conteo

    }
}

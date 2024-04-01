using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Pallets.Models
{
    public class NumParte : INotifyPropertyChanged
    {
        double maximo_cajas_por_tarima = 26.0;

        private string? tipo;
        private string? po;
        private string? material;
        private string? sloc;
        private string tres_s;
        private int cartons;

        private int pallets;
        private int spare;
        private int numPallet;
        private string location;

        private List<NumParte> listaNumParte;
        private int npContados;
        private bool lleno;

        public NumParte(string? type, string? po, string? material, string? sloc, int cartons)
        {
            Tipo = type;
            Po = po;
            Material = material;
            Sloc = sloc;
            Cartons = cartons;
            this.NumPallet = 0;
            calcularPalletsSpare();
            ListaNumParte = new List<NumParte>();
            NpContados = 0;
            //NpContados = cartons - 2;
            Lleno = false;
        }

        public NumParte(string? type, string? po, string? material, string? sloc, int cartons, string tres_s)
        {
            Tipo = type;
            Po = po;
            Material = material;
            Sloc = sloc;
            Cartons = cartons;
            this.NumPallet = 0;
            Tres_s = tres_s;
            calcularPalletsSpare();
            ListaNumParte = new List<NumParte>();
            NpContados = 0;
            //NpContados = cartons - 2;
            Lleno = false;
        }

        public NumParte(string type, string? po, string? material, string location, string? sloc, int cartons)
        {
            Tipo = type;
            Po = po;
            Material = material;
            Location = location;
            Sloc = sloc;
            Cartons = cartons;
            ListaNumParte = new List<NumParte>();
            NpContados = 0;
            //NpContados = cartons - 2;
            calcularPalletsSpare();
            Lleno = false;
        }

        public NumParte() { }

        public string? Po { get => po; set => po = value; }
        public string? Material { get => material; set => material = value; }
        public string? Sloc { get => sloc; set => sloc = value; }
        public int Cartons { get => cartons; set => cartons = value; }
        public int Pallets { get => pallets; set => pallets = value; }
        public int Spare { get => spare; set => spare = value; }
        public int NumPallet { get => numPallet; set => numPallet = value; }
        public string Location { get => location; set => location = value; }
        public List<NumParte> ListaNumParte { get => listaNumParte; set => listaNumParte = value; }
        public string? Tipo { get => tipo; set => tipo = value; }
        public int NpContados 
        {
            get { return npContados; }
            set
            {
                if (npContados != value)
                {
                    npContados = value;
                    OnPropertyChanged("NpContados");
                }
            }
        }
        public bool Lleno
        {
            get { return lleno; }
            set
            {
                if (lleno != value)
                {
                    lleno = value;
                    OnPropertyChanged("Lleno");
                }
            }
        }

        public string? Tres_s { get => tres_s; set => tres_s = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool ShouldRemove()
        {
            return Pallets == 0 && Tipo != "Mixed" && (Material != null && !(Material.Equals("-----"))) || (Po == null && Material == null);
        }

        private void calcularPalletsSpare()
        {
            int pallets = (int)Math.Floor((double)(Cartons / 35.0));
            int spare = (int)(Math.Floor(this.Cartons % 35.0));


            if (spare > 12)
            {
                while (spare > 12)
                {
                    pallets++;
                    spare = spare - (int)maximo_cajas_por_tarima;
                }//fin while spare >= 12
            }//fin if spare >= 12

            if (spare < 0) spare = 0;

            this.Pallets = pallets;
            this.Spare = spare;

        }//calcularPalletsSpare

        private void calcularMixedPallets()
        {
            int pallets = (int)Math.Floor((double)(Cartons / 26.0));
            int spare = (int)(Math.Floor(this.Cartons % 26.0));


            if (spare >= 15)
            {
                while (spare >= 15)
                {
                    pallets++;
                    spare = spare - (int)maximo_cajas_por_tarima;
                }//fin while spare >= 12
            }//fin if spare >= 12

            if (spare < 0) spare = 0;

            this.Pallets = pallets;
            this.Spare = spare;

        }//calcularPalletsSpare

        public int getTotalCartonesMixedPallet()
        {
            if (this.ListaNumParte.Count == 0)
            {
                return this.cartons;
            }
            else
            {
                int totalCartones = 0;
                foreach (var numParte in this.ListaNumParte)
                {
                    totalCartones += numParte.Cartons;
                }//fin foreach
                return totalCartones;
            }//fin if
        }// getTotalCartonesMixedPallet

        public int getTotalConteoMixedPallets()
        {
            int totalConteo = 0;
            if (this.ListaNumParte.Count > 0)
            {
                foreach (var numParte in this.ListaNumParte)
                {
                    totalConteo += numParte.NpContados;
                }//fin foreach
            } else
            {
                totalConteo = NpContados;
            }
            return totalConteo;
        }// getTotalCartonesMixedPallet

        public void RestarSobrantes() {
            Cartons = Cartons - Spare;
        }

    }//fin class
}//fin namespace

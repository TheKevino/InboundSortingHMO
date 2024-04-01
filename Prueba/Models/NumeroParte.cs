using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Models
{
    class NumeroParte {
        int largoTarima = 48, anchoTarima = 48, alturaTarima = 40;
        int largoDisponible = 48, anchoDisponible = 48, altoDisponible = 40;

        double volumenTarima = 48 * 40 * 48; // Ancho x Altura x Largo

        private string material;
        private int quantity;
        private int qtyPerBox;
        private int totalCajas;

        private double length;
        private double width;
        private double height;
        private double volumeBox;
        private string measures;

        private int totalNiveles;
        private int totalAncho;
        private int totalLargo;
        private string boxArrangment;

        private int capacity;
        private int qtyPallets;
        private int spare;
        private int cajasPorTarima;

        public NumeroParte(string material, int quantity, double length, double width, double height) {

            this.Material = material;
            this.Quantity = quantity;

            this.QtyPerBox = (this.Quantity == 0)
               ? 0
               : (this.Quantity <= 1000000)
                   ? (int)(Math.Ceiling(this.Quantity * 0.01))
                   : (int)(Math.Ceiling(this.Quantity * 0.001));

            this.TotalCajas = (this.QtyPerBox == 0)
                    ? 0
                    : this.Quantity / this.QtyPerBox;

            this.Length = length;
            this.Width = width;
            this.Height = height;
            this.VolumeBox = Math.Round( (this.Width * this.Height * this.Length), 2);
            this.Measures = this.Width + " x " + this.Height + " x " + this.Length;

            this.TotalNiveles = calcularNiveles();
            this.TotalAncho = calcularAncho();
            this.TotalLargo = calcularLargo();
            this.Capacity = this.TotalNiveles * this.TotalAncho * this.TotalLargo;
            //this.BoxArrangment = this.TotalAncho + "x" + this.TotalNiveles + "x" + this.TotalLargo;
            this.BoxArrangment = Acomodamiento();

            this.QtyPallets = (int) Math.Round( (decimal) this.TotalCajas / (decimal) this.Capacity);
            this.Spare = (int) Math.Floor( (decimal) this.TotalCajas % (decimal) this.Capacity);

            if (this.QtyPallets == 0 && this.Capacity > 0)
            {
                if (this.TotalCajas >= 10)
                {
                    this.QtyPallets++;
                    this.Spare = this.Spare - this.TotalCajas;
                    this.CajasPorTarima = this.TotalCajas;
                }
            }
            else
            {
                this.CajasPorTarima = (int) Math.Ceiling(volumenTarima / this.VolumeBox);

            }//fin if else

            if (this.Spare >= 10)
            {
                while (this.Spare >= 10)
                {

                    this.QtyPallets++;
                    this.Spare = this.Spare - this.Capacity;

                }//fin while
            }//fin if

            if (this.Spare < 0) this.Spare = 0;

        }//fin constructor

        public string Material { get => material; set => material = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int QtyPerBox { get => qtyPerBox; set => qtyPerBox = value; }
        public int TotalCajas { get => totalCajas; set => totalCajas = value; }
        public double Length { get => length; set => length = value; }
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }
        public double VolumeBox { get => volumeBox; set => volumeBox = value; }
        public string Measures { get => measures; set => measures = value; }
        public int TotalNiveles { get => totalNiveles; set => totalNiveles = value; }
        public int TotalAncho { get => totalAncho; set => totalAncho = value; }
        public int TotalLargo { get => totalLargo; set => totalLargo = value; }
        public string BoxArrangment { get => boxArrangment; set => boxArrangment = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int QtyPallets { get => qtyPallets; set => qtyPallets = value; }
        public int Spare { get => spare; set => spare = value; }
        public int CajasPorTarima { get => cajasPorTarima; set => cajasPorTarima = value; }

        public int calcularNiveles()
        {

            int niveles = (int)Math.Ceiling(alturaTarima / this.Height);

            //        if( (this.height * niveles) > ( alturaTarima + 2 ) ){
            //            niveles = (int) Math.floor( alturaTarima / this.height );
            //        }

            return niveles;

        }//fin metodo

        public int calcularAncho()
        {

            int anchoCajas = (int) Math.Ceiling(anchoTarima / this.Width);

            if ((this.Width * anchoCajas) > anchoTarima)
            {
                anchoCajas = (int) Math.Floor(anchoTarima / this.Width);
            }

            return anchoCajas;

        } //fin metodo

        public int calcularLargo()
        {

            int largoCajas = (int) Math.Ceiling(largoTarima / this.Length);

            if ((this.Length * largoCajas) > largoTarima)
            {
                largoCajas = (int) Math.Floor(largoTarima / this.Length);
            }

            return largoCajas;

        }//fin metodo

        private string Acomodamiento()
        {
            int CajasAncho = 0, CajasAlto = 0, CajasLargo = 0;
            string Gira = "";
            // Bucle para acomodar cajas en la tarima
            for (double x = anchoDisponible; x > 0; x -= Width)
            {
                Gira += x + " ";
                if (x >= 0) {
                    CajasAncho++;
                    
                }

            }//fin for X

            return Gira;

        }//fin metodo

    }//fin clase
}//fin namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pallets.Models
{
    public class Shipment
    {
        double maximo_cajas_por_tarima = 26.0;
        string id;
        string pgi;
        string bol;
        string trackingNo;
        string countryOrigin;
        string vendorName;
        int cartons;
        int pallets;
        int spare;

        public Shipment()
        {
        }
        public Shipment(string? id, string pgi, string bol, string trackingNo, string countryOrigin, string vendorName, int pallets)
        {
            Id = id;
            Pgi = pgi;
            Bol = bol;
            TrackingNo = trackingNo;
            CountryOrigin = countryOrigin;
            VendorName = vendorName;
            Pallets = pallets == 0 ? 1 : pallets;
            //Cartons = cartons;
            //calcularPalletsSpare();
        }

        public string Pgi { get => pgi; set => pgi = value; }
        public string Bol { get => bol; set => bol = value; }
        public string CountryOrigin { get => countryOrigin; set => countryOrigin = value; }
        public string VendorName { get => vendorName; set => vendorName = value; }
        public int Cartons { get => cartons; set => cartons = value; }
        public int Pallets { get => pallets; set => pallets = value; }
        public int Spare { get => spare; set => spare = value; }
        public string TrackingNo { get => trackingNo; set => trackingNo = value; }
        public string Id { get => id; set => id = value; }

        private void calcularPalletsSpare()
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

            if (pallets == 0) pallets = 1;

            this.Pallets = pallets;
            this.Spare = spare;

        }//calcularPalletsSpare

    }//fin class
}//fin namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pallets.Models
{
    public class ScannedMaterial
    {
        string material;
        string location;

        public ScannedMaterial(string material, string location)
        {
            this.Material = material;

            if (location.Equals("Mix")) { 
                this.Location = location;
            }
            else
            {
                if (location.StartsWith('A'))
                {
                    this.Location = location + "       ";
                }
                else
                {
                    this.Location = "         " + location;
                }//fin if else
            }//fin if else
        }//ScannedMaterial

        public string Material { get => material; set => material = value; }
        public string Location { get => location; set => location = value; }
    }
}

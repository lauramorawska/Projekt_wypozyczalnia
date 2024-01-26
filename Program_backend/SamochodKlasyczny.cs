using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projekt
{
   
    public class SamochodKlasyczny : Samochod 
    {

        public SamochodKlasyczny()
        {
            
        }

        public SamochodKlasyczny(string marka, string model, string numerRejestracyjny, int rokProdukcji, decimal cenaZaDzienWypozyczenia, decimal kaucja, EnumStan stan)
    : base(marka, model, numerRejestracyjny, rokProdukcji, kaucja, stan)
        {
            this.CzyDostepny = true;
        }

        public override string ToString()
        {
            return $"Samochód klasyczny {base.ToString()}";
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projekt
{
    public enum EnumDach { miekki, sztywny }
    public class SamochodCabriolet : Samochod
    {
        EnumDach dach;
        public  EnumDach Dach { get => dach; set => dach = value; }

        public SamochodCabriolet()
        {
            
        }

        public SamochodCabriolet(string marka, string model, string numerRejestracyjny, int rokProdukcji, decimal cenaZaDzienWypozyczenia, EnumDach dach, decimal kaucja, EnumStan stan)
    : base(marka, model, numerRejestracyjny, rokProdukcji, kaucja, stan)
        {
            this.Dach = dach;
            this.CzyDostepny = true;
        }

        public override string ToString()
        {
            return $"Cabriolet {base.ToString()}, rodzaj dachu: {Dach}";
        }

    }
}

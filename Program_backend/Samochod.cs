using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt
{

    public enum EnumStan { dzialajacy, naprawiany, zepsuty }
    
    [DataContract]
   // [JsonConverter(typeof(SamochodConverter))]
    [KnownType(typeof(SamochodCabriolet))]
    [KnownType(typeof(SamochodSportowy))]
    [KnownType(typeof(SamochodKlasyczny))]
    [KnownType(typeof(SamochodWieloosobowy))]

    [XmlInclude(typeof(SamochodCabriolet))]
    [XmlInclude(typeof(SamochodKlasyczny))]
    [XmlInclude(typeof(SamochodSportowy))]
    [XmlInclude(typeof(SamochodWieloosobowy))]

    [Table("Samochody")]
    public abstract  class Samochod : ICloneable
    {
        string marka;
        string model;
        string numerRejestracyjny;
        bool czyDostepny;
        int rokProdukcji;
        EnumStan stan;
        decimal kaucja;

        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public string NumerRejestracyjny { get => numerRejestracyjny; set => numerRejestracyjny = value; }
        public bool CzyDostepny { get => czyDostepny; set => czyDostepny = value; }
        public int RokProdukcji { get => rokProdukcji; set => rokProdukcji = value; }
        public decimal Kaucja { get => kaucja; set => kaucja = value; }
        public EnumStan Stan { get => stan; set => stan = value; }

        public virtual List<SamochodSportowy> SamochodySport { get; set; }
        public virtual List<SamochodKlasyczny> SamochodyKlas { get; set; }
        public virtual List<SamochodWieloosobowy> SamoWielo { get; set; }
        public virtual List<SamochodCabriolet> SamochodyCab { get; set; }
        [Key]
        public int SamochodId { get; set; }
        public int WypozyczalniaId { get; set; }
        public virtual Wypozyczalnia Wypozyczalnia { get; set; }

        public Samochod()
        {
            Marka = string.Empty; Model = string.Empty;
            NumerRejestracyjny = "AA-0000";
            CzyDostepny = false;
            RokProdukcji = 0000;
            Kaucja = 0;
            stan = EnumStan.dzialajacy;

        }
        
        public Samochod(string marka) :this()
        {
            this.marka = marka;
        }
        [JsonConstructor]
        public Samochod(string marka, string model, string numerRejestracyjny, int rokProdukcji, decimal kaucja, EnumStan stan) : this(marka)
        {
            this.Marka = marka;
            this.Model = model;
            this.NumerRejestracyjny = numerRejestracyjny;
            this.CzyDostepny = true;
            this.RokProdukcji = rokProdukcji;
            this.Stan = stan;
            this.Kaucja = kaucja; 
        }


        public object Clone()
        {
            MemoryStream ms = new();
            DataContractSerializer dcs = new(typeof(Samochod));
            dcs.WriteObject(ms, this);
            ms.Position = 0;
            return (Samochod?)dcs.ReadObject(ms);
        }

        public override string ToString()
        {
            return $"{Marka} {Model}, Rok Produkcji: {RokProdukcji}, Numer Rejestracji: ({NumerRejestracyjny})" +
                $" dostepność: {(CzyDostepny ? "Dostępny" : "Niedostępny")}, Stan Samochodu: {Stan}, Kaucja za samochód :{kaucja:C}";
        }
    }
}

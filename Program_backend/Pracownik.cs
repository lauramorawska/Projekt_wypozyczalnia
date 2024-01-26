using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projekt
{
    public enum EnumRola { obsluga_klienta, obsluga_techniczna, obsluga_finansowa, kierownik }
    [Table("Pracownicy")]
    public class Pracownik : ICloneable, IEquatable<Pracownik>, IComparable<Pracownik>
    {
        string imie;
        string nazwisko;
        string pesel;
        bool dostepny; 
        string nrTelefonu;
        EnumRola rola;
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Pesel
        {
            get => pesel; set
            {
                if (!Regex.IsMatch(value, @"^\d{11}"))
                {
                    throw new BlednyPeselException("Niepoprany numer Pesel!");
                }
                pesel = value;
            }
        }
        public bool Dostepny { get => dostepny; set => dostepny = value; }
        public string NrTelefonu
        {
            get => nrTelefonu; set
            {
                if (!Regex.IsMatch(value, @"^\d{9}"))
                {
                    throw new BlednyNumerTelefonuException("Niepoprawny numer telefonu!");
                }
                nrTelefonu = value;
            }

        }
        [Key]
        public int PracownikId {  get; set; }
        
        public EnumRola Rola { get => rola; set => rola = value; }

        public Pracownik()
        {

        }
        [JsonConstructor]
        public Pracownik(string imie, string nazwisko, string pesel, bool dostepny, string nrTelefonu, EnumRola rola) : this()
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Pesel = pesel;
            this.Dostepny = dostepny;
            this.NrTelefonu = nrTelefonu;
            this.Rola = rola;
            
        }

        public int CompareTo(Pracownik? other)
        {
            if (other == null) { return -1; }
            int cmp = Nazwisko.CompareTo(other.Nazwisko);
            if (cmp != 0) { return cmp; }  
            return Imie.CompareTo(other.Imie);
        }


        public object Clone()
        {
            return MemberwiseClone();
        }

        public bool Equals(Pracownik? other)
        {
            if (other == null) return false;
            return Pesel.Equals(other.Pesel);
        }
        public override string ToString()
        {
            string numer = nrTelefonu.Substring(0, 3) + "-" + nrTelefonu.Substring(3, 3) + "-" + nrTelefonu.Substring(6, 3);
          
            return $"Pracownik: {Imie} {Nazwisko}, Numer Telefonu: {NrTelefonu}, PESEL: {Pesel}, Dostepność pracownika: {(Dostepny ? "Dostępny" : "Niedostępny")}, Rola: {Rola}" ;
        }
    }
}

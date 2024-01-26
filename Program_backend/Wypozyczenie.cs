using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt
{
    [Table("Wypozyczenia")]
    public class Wypozyczenie : ICloneable
    {
        static int nrWypozyczenia;
        DateTime dataWypozyczenia;
        DateTime dataZwrotu;
        Samochod samochod;
        private Klient klient;
        decimal cenaZaDzienWypozyczenia;
        decimal kaucja;
        Pracownik pracownik;
        int aktualnyNumer;

        public decimal CenaZaDzienWypozyczenia { get => cenaZaDzienWypozyczenia; set => cenaZaDzienWypozyczenia = value; }
        public int AktualnyNumer { get => aktualnyNumer; set => aktualnyNumer = value; }
        public static int NrWypozyczenia { get => nrWypozyczenia; set => nrWypozyczenia = value; }
        public DateTime DataWypozyczenia { get => dataWypozyczenia; set => dataWypozyczenia = value; }
        public DateTime DataZwrotu{ get => dataZwrotu; set => dataZwrotu = value; }
        [Key]
        public int WypozyczenieId { get; set; }
        public int WypozyczalniaId { get; set; }
        public virtual Wypozyczalnia Wypozyczalnia { get; set; }

        public Samochod Samochod { get => samochod; set => samochod = value; }
        public Klient Klient { get => klient; set => klient = value; }

        static Wypozyczenie()
        {
            NrWypozyczenia = 1;
        }

        public Wypozyczenie()
        {

        }

        public Wypozyczenie(Pracownik pracownik,DateTime dataWypozyczenia, DateTime dataZwrotu, Samochod samochod, Klient klient, decimal cenaZaDzienWypozyczenia) : this()
        {
            this.DataWypozyczenia = dataWypozyczenia;
            this.dataZwrotu = dataZwrotu;
            this.Samochod = samochod;
            this.Klient = klient;
            this.CenaZaDzienWypozyczenia = cenaZaDzienWypozyczenia;
            this.AktualnyNumer = NrWypozyczenia;
            NrWypozyczenia += 1;
            this.Kaucja=samochod.Kaucja;
            this.Pracownik = pracownik; 
        }

      

        public decimal Kaucja { get => kaucja; set => kaucja = value; }
        public Pracownik Pracownik { get => pracownik; set => pracownik = value; }

        public decimal Kwota()
        {
            decimal dni = (decimal)(DataZwrotu - DataWypozyczenia).TotalDays;
            return CenaZaDzienWypozyczenia * dni;
        }

        public void PrzedluzWypozyczenie(int liczbaDni)
        {
            if (liczbaDni <= 0)
            {
                throw new BledyException("Liczba dni musi być większa niż zero.");
            }

            DateTime nowaDataZwrotu = dataZwrotu.AddDays(liczbaDni);

            if (nowaDataZwrotu < dataWypozyczenia)
            {
                throw new BlednaDataZwrotuException("Nowa data zwrotu nie może być wcześniejsza niż data wypożyczenia.");
            }

            dataZwrotu = nowaDataZwrotu;
        }

        public object Clone()
        {
            Wypozyczenie clonedWypozyczenie = new Wypozyczenie(
                pracownik.Clone() as Pracownik,
                dataWypozyczenia,
                dataZwrotu,
                samochod.Clone() as Samochod,
                klient.Clone() as Klient,
                cenaZaDzienWypozyczenia
            )
            {
                kaucja = samochod.Kaucja 
            };

            return clonedWypozyczenie;
        }

        public override string ToString()
        {
            string pracownikInfo = (Pracownik != null) ? $"{Pracownik.Imie} {Pracownik.Nazwisko}" : "Brak informacji o pracowniku";
            string samochodInfo = (Samochod != null) ? $"{Samochod.Marka} {Samochod.Model}" : "Brak informacji o samochodzie";
            string klientInfo = (Klient != null) ? $"{Klient.Imie} {Klient.Nazwisko}" : "Brak informacji o kliencie";

            return $"ID Wypożyczenia: {AktualnyNumer}, Pracownik obsługujący: {pracownikInfo}, " +
                   $"Imie i nazwisko klienta: {klientInfo}, Data Wypożyczenia: {DataWypozyczenia:yyyy-MM-dd} Data Zwrotu: {dataZwrotu:yyyy-MM-dd}, " +
                   $"Należność od odbiorcy: {Kwota():C}, Kaucja: {Kaucja:C}, Samochód: {samochodInfo}, dostępność samochodu: {(samochod.CzyDostepny ? "Dostępny" : "Niedostępny")}";
        }
    }
}

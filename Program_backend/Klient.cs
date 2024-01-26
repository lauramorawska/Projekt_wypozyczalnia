using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt
{
    /// <summary>
    /// Klasa reprezentująca informacje o kliencie.
    /// </summary>

    [Table("Klienci")]
    public class Klient : ICloneable, IComparable<Klient>
    {
        private string imie;
        private string nazwisko;
        private string numerTelefonu;
        private string nrDowoduOsobistego;

        /// <summary>
        /// Pobiera numer dowodu osobistego klienta. Srawdza czy format jest poprawny (3 litery, 4 cyfry - jesli nie, wyrzuca wyjatek BledyNrDowoduException 
        /// </summary>
        public string NrDowoduOsobistego
        {
            get => nrDowoduOsobistego; set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{3}\d{6}$"))
                {
                    throw new BledyNrDowoduException("Niepoprawne Dane!");
                }
                nrDowoduOsobistego = value;
            }
        }

        /// <summary>
        /// Pobiera lub ustawia imię klienta.
        /// </summary>
        public string Imie { get => imie; set => imie = value; }

        /// <summary>
        /// Pobiera lub ustawia nazwisko klienta.
        /// </summary>
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }

        /// <summary>
        /// Pobiera lub ustawia numer telefonu klienta.
        /// </summary>
        public string NumerTelefonu { get => numerTelefonu; set => numerTelefonu = value; }

        /// <summary>
        /// Konstruktor domyślny, tworzy instancję klasy Klient z pustymi danymi.
        /// </summary>
        public Klient()
        {
            this.Imie = string.Empty;
            this.Nazwisko = string.Empty;
            this.NumerTelefonu = string.Empty;
            this.nrDowoduOsobistego = string.Empty;
        }

        /// <summary>
        /// Konstruktor, który inicjalizuje instancję klasy Klient danymi przekazanymi jako parametry.
        /// </summary>
        [JsonConstructor]
        public Klient(string imie, string nazwisko, string numerTelefonu, string nrDowoduOsobistego) : this()
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.NumerTelefonu = numerTelefonu;
            this.nrDowoduOsobistego = nrDowoduOsobistego;
        }

        /// <summary>
        /// Metoda implementująca interfejs ICloneable, umożliwiająca klonowanie obiektu klasy Klient.
        /// </summary>
        /// <returns>Nowa instancja klasy Klient, będąca kopią bieżącej instancji.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Metoda implementująca interfejs IComparable<Klient>, umożliwiająca porównanie dwóch obiektów klasy Klient na podstawie nazwiska i imienia.
        /// </summary>
        /// <param name="other">Inny obiekt klasy Klient do porównania.</param>
        /// <returns>Wartość ujemna, jeśli bieżący obiekt jest przed other w porządku alfabetycznym, wartość dodatnia, jeśli jest po other, 0 jeśli są równe.</returns>
        public int CompareTo(Klient? other)
        {
            if (other == null) { return -1; }
            int cmp = Nazwisko.CompareTo(other.Nazwisko);
            if (cmp != 0) { return cmp; }  // czyli albo wcześniej w alfabecie albo później
            return Imie.CompareTo(other.Imie);
        }

        /// <summary>
        /// Przesłonięta metoda ToString() zwracająca czytelny tekstowy opis obiektu klasy Klient.
        /// </summary>
        /// <returns>Czytelny tekstowy opis obiektu klasy Klient.</returns>
        public override string ToString()
        {
            string numer = NumerTelefonu.Substring(0, 3) + "-" + NumerTelefonu.Substring(3, 3) + "-" + NumerTelefonu.Substring(6, 3);
            return $"{Imie} {Nazwisko}, Telefon Kontaktowy: {numer}, Numer Dowodu Osobistego: {nrDowoduOsobistego}";
        }

        /// <summary>
        /// Pobiera lub ustawia unikalny identyfikator klienta.
        /// </summary>
        [Key]
        public int KlientId { get; set; }

        /// <summary>
        /// Pobiera lub ustawia identyfikator wypożyczalni, z którą klient jest powiązany.
        /// </summary>
        public int WypozyczalniaId { get; set; }

        /// <summary>
        /// Pobiera lub ustawia właściwość reprezentującą powiązaną wypożyczalnię.
        /// </summary>
        public virtual Wypozyczalnia Wypozyczalnia { get; set; }
    }
}


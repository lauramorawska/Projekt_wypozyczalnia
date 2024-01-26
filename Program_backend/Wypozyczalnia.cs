using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Json;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt
{
    [Serializable]
    [Table("Wypozyczalnia")]
    public class Wypozyczalnia : IWypozyczanie
    {
        
        string nazwa;
        List<Wypozyczenie> wypozyczenia;
        List<Pracownik> pracownicy;
        List<Klient> klienci;
        List<Samochod> samochody;
        decimal kasa;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public List<Wypozyczenie> Wypozyczenia { get => wypozyczenia; set => wypozyczenia = value; }
        public List<Pracownik> Pracownicy { get => pracownicy; set => pracownicy = value; }
        public List<Klient> Klienci { get => klienci; set => klienci = value; }
        public List<Samochod> Samochody { get => samochody; set => samochody = value; }
        
        public decimal Kasa { get => kasa; set => kasa = value; }

        [Key]
        public int WypozyczalniaId { get; set; }
        public virtual List<Pracownik> Pracownik { get; set; }
        public virtual List<Klient> Klient { get; set; }
        public virtual List<Samochod> Samochod { get; set; }
        public virtual List<Wypozyczenie> Wypozyczenie { get; set; }

        public Wypozyczalnia()
        {
            Wypozyczenia = new List<Wypozyczenie>();
            Pracownicy = new List<Pracownik>();
            Klienci = new List<Klient>();
            Samochody = new List<Samochod>();

            Kasa = 0;
        }
        public Wypozyczalnia(string nazwa) : this()
        {
            this.Nazwa = nazwa;
        }
        public void DodajKlienta(Klient k)
        {
            Klienci.Add(k);
        }

        public void SortujNazwiskoImie()
        {
            Wypozyczenia.Sort((w1, w2) => w2.Klient.CompareTo(w1.Klient));
        }

        public void SortujNazwiskoImieKlienta()
        {
            Klienci.Sort();
        }

        public void SortujNazwiskoImiePracownika()
        {
            Pracownicy.Sort();
        }

        public void DodajPracownika(Pracownik p)
        {
            Pracownicy.Add(p);


        }
        public string WypiszPracownikow()
        {
            if (pracownicy.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Pracownicy:");
                foreach (Pracownik p in pracownicy)
                {
                    string numer = p.NrTelefonu.Substring(0, 3) + "-" + p.NrTelefonu.Substring(3, 3) + "-" + p.NrTelefonu.Substring(6, 3);
                    stringBuilder.AppendLine(p.ToString());

                }
                return stringBuilder.ToString();
            }
            return null;
        }

        public string WypiszKlientow()
        {
            if (klienci.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Klienci:");
                foreach (Klient k in klienci)
                {
                    string numer = k.NumerTelefonu.Substring(0, 3) + "-" + k.NumerTelefonu.Substring(3, 3) + "-" + k.NumerTelefonu.Substring(6, 3);
                    stringBuilder.AppendLine(k.ToString());

                }
                return stringBuilder.ToString();
            }
            return null;
        }


        public void UsunPracownika(Pracownik p)
        {
            Pracownicy.Remove(p);
        }
        public void NoweWypozyczenie(Wypozyczenie wypo)
        {
            Wypozyczenia.Add(wypo);
            if (!Klienci.Contains(wypo.Klient))
            {
                Klienci.Add(wypo.Klient);
            }
        }

        public void DodajAuto(Samochod sam)
        {
            Samochody.Add(sam);
        }
        public void UsunAuto(Samochod sam)
        {
            Samochody.Remove(sam);
        }
        public string WypiszSamochody()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Auta");
            foreach (Samochod sam in Samochody)
            {
                sb.AppendLine(sam.ToString());
            }
            return sb.ToString();
        }
        public string WypiszStanKasy()
        {
            return $"Stan Kasy to: {Kasa:C}";
        }
        public string ZnajdzAktualnieWypozyczoneAuta()
        {
            StringBuilder sb = new StringBuilder();
            List<Wypozyczenie> lista = new List<Wypozyczenie>();
            foreach (Wypozyczenie wyp in wypozyczenia)
            {

                if (wyp.Samochod.CzyDostepny == true)
                {

                }
                else
                {
                    lista.Add(wyp);
                }

            }
            if (lista != null)
            {
                sb.AppendLine("Aktualnie wypozyczone:");
                foreach (Wypozyczenie samochod in lista)
                {
                    sb.AppendLine(samochod.Samochod.ToString());
                }
                return sb.ToString();
            }
            else
            {
                return null;
            }
        }
        public string ZnajdzAktualnieWypozyczenia()
        {
            StringBuilder sb = new StringBuilder();
            List<Wypozyczenie> lista = new List<Wypozyczenie>();
            foreach (Wypozyczenie wyp in wypozyczenia)
            {

                if (wyp.Samochod.CzyDostepny == true)
                {

                }
                else
                {
                    lista.Add(wyp);
                }

            }
            if (lista != null)
            {
                sb.AppendLine("Aktualne wypozyczenia:");
                foreach (Wypozyczenie samochod in lista)
                {
                    sb.AppendLine(samochod.ToString());
                }
                return sb.ToString();
            }
            else
            {
                return null;
            }
        }

        public List<Wypozyczenie> ZnajdzAktualnieWypozyczeniaLista()
        {
            List<Wypozyczenie> lista = new List<Wypozyczenie>();
            foreach (Wypozyczenie wyp in wypozyczenia)
            {

                if (wyp.Samochod.CzyDostepny == true)
                {

                }
                else
                {
                    lista.Add(wyp);
                }

            }
            return lista;
            
            
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Wypozyczenia != null)
            {
                sb.AppendLine("Lista samochodow:");
                foreach (var samochod in Samochody)
                {
                    sb.AppendLine(samochod.ToString());
                }
                sb.AppendLine("Lista Pracownikow:");
                foreach(var pracownik in Pracownicy)
                {
                    sb.AppendLine(pracownik.ToString());
                }
                sb.AppendLine("Lista Wypozyczen:");
                foreach(var wypozyczenie in Wypozyczenia)
                {
                    sb.AppendLine(wypozyczenie.ToString());
                }
                return sb.ToString();

            }
            else
            {
                return null;
            }

        }
        public void ZmienStatusSamochodu(Samochod samochod)

        {
            if (samochod.CzyDostepny == true)
            {
                samochody.Remove(samochod);
                samochod.CzyDostepny = true;
                samochody.Add(samochod);
            }
            else
            {
                samochody.Remove(samochod);
                samochod.CzyDostepny = false;
                samochody.Add(samochod);
            }
        }
        public void WypozyczSamochod(Wypozyczenie wypo)
        {
            if(wypo.DataWypozyczenia != DateTime.Now)
            {
                wypo.DataWypozyczenia = DateTime.Now;
            }
            wypo.Samochod.CzyDostepny = false;
            ZmienStatusSamochodu(wypo.Samochod);
            Kasa += wypo.Samochod.Kaucja;
        }

        public void OddanieSamochodu(Wypozyczenie wypo, bool CzySprawny)
        {
            if(wypo.Samochod.CzyDostepny == false)
            {
                if (wypo.DataZwrotu != DateTime.Now)
                {
                    wypo.DataZwrotu = DateTime.Now;
                }
                wypo.Samochod.CzyDostepny = true;
                ZmienStatusSamochodu(wypo.Samochod);
                if (CzySprawny == true)
                {
                    Kasa -= Convert.ToDecimal(wypo.Samochod.Kaucja);
                    Kasa += Convert.ToDecimal(wypo.Kwota());
                }
                else
                {
                    Kasa += Convert.ToDecimal(wypo.Kwota());
                    wypo.Samochod.Stan = EnumStan.zepsuty;
                }
            }else
            {
                throw new ArgumentException();
            }
            
            
        }


        public bool JestPracownikiem(Pracownik p) 
        {
            Pracownik? pracownik = Pracownicy.FirstOrDefault(c => c.Equals(p));

            return pracownik != null;
        }



        public void ZapiszJSON(string nazwa)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonstr =
            JsonConvert.SerializeObject(this,Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            File.WriteAllText(nazwa, jsonstr);
        }

        public static Wypozyczalnia? OdczytJSON(string nazwa)
        {
            if (!File.Exists(nazwa)) { return null; }
            string jsonstr = File.ReadAllText(nazwa);

            
            var tt = JsonConvert
            .DeserializeObject<Wypozyczalnia>(jsonstr, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            return tt;
        }

        public void Zapisz(string nazwaPliku)
        {
            using StreamWriter sw = new(nazwaPliku);
            XmlSerializer xs = new(typeof(Wypozyczalnia));
            xs.Serialize(sw, this);
        }

        public static Wypozyczalnia? Odczytaj(string nazwaPliku)
        {
            if (!File.Exists(nazwaPliku))
            {
                return null;
            }
            using StreamReader sr = new StreamReader(nazwaPliku);
            XmlSerializer xs = new(typeof(Wypozyczalnia));
            return xs.Deserialize(sr) as Wypozyczalnia;


        }
        public void ZapiszDoBazy()
        {
            using var db = new WypozyczalniaDbContext();
            Console.WriteLine("Trwa zapisywanie...");
            db.Wypozyczalnie.Add(this);
            db.SaveChanges();
            Console.WriteLine("Zapisano!");
        }

        public void OdczytBazyDanych()
        {
            var db = new WypozyczalniaDbContext();
            Wypozyczalnia z = new Wypozyczalnia();
            int zespolId = db.Wypozyczalnie.Max(z => z.WypozyczalniaId);
            var zbaza = db.Wypozyczalnie.Find(WypozyczalniaId);
            z.WypozyczalniaId = zbaza.WypozyczalniaId;
            z.nazwa = zbaza.Nazwa;
            z.kasa = zbaza.Kasa;
        }


    }
}

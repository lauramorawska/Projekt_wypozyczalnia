using Projekt;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestProjektu
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestKlientCompareTo() //Sprawdza, czy metoda zwraca -1, gdy drugi obiekt (other) jest null.
        {
            // Arrange
            Klient klient = new Klient();
            Klient other = null;

            // Act
            int result = klient.CompareTo(other);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CompareTo_TeSameObiektyTest() // Sprawdza czy metoda zwraca 0 jesli obiekty s¹ takie same
        {
            // Arrange
            Klient klient = new Klient { Nazwisko = "Kowalski", Imie = "Jan" };
            Klient other = new Klient { Nazwisko = "Kowalski", Imie = "Jan" };

            // Act
            int result = klient.CompareTo(other);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareTo_InneNazwiskoTest()
        {
            // Arrange
            Klient klient = new Klient { Nazwisko = "Kowalski", Imie = "Jan" };
            Klient other = new Klient { Nazwisko = "Nowak", Imie = "Zbigniew" };

            // Act
            int result = klient.CompareTo(other);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareTo_ToSamoNazwisko_InneImieTest() //inne imie, to samo nazwisko
        {
            // Arrange
            Klient klient = new Klient { Nazwisko = "Kowalski", Imie = "Jan" };
            Klient other = new Klient { Nazwisko = "Kowalski", Imie = "Anna" };

            // Act
            int result = klient.CompareTo(other);

            // Assert
            Assert.AreEqual(1, result);
        }

        //test Konstruktora Pracownik
        [TestMethod]
        public void Constructor_Test_Pracownik()
        {
            // Arrange
            string imie = "Jan";
            string nazwisko = "Kowalski";
            string pesel = "12345678901";
            bool dostepny = true;
            string nrTelefonu = "123456789";
            EnumRola rola = EnumRola.obsluga_klienta; 

            // Act
            Pracownik pracownik = new Pracownik(imie, nazwisko, pesel, dostepny, nrTelefonu, rola);

            // Assert
            Assert.AreEqual(imie, pracownik.Imie);
            Assert.AreEqual(nazwisko, pracownik.Nazwisko);
            Assert.AreEqual(pesel, pracownik.Pesel);
            Assert.AreEqual(dostepny, pracownik.Dostepny);
            Assert.AreEqual(nrTelefonu, pracownik.NrTelefonu);
            Assert.AreEqual(rola, pracownik.Rola);
        }

        
        //test - wyrzucanie wyj¹tku przed³u¿ania wypo¿yczenia

    
        [TestMethod]
        public void PrzedluzWypozyczenie_LiczbaDniTest()
        {
            // Arrange
            Wypozyczenie wypozyczenie = new Wypozyczenie();
            int liczbaDni = 0;

            // Act & Assert
            Assert.ThrowsException<BledyException>(() => wypozyczenie.PrzedluzWypozyczenie(liczbaDni));
        }

        //Test czy lista samochodów po wywolaniu konstrutkora nie jest nullem
        [TestMethod]
        public void Samochody_czyNull_UnitTest()
        {
            // Arrange
            Wypozyczalnia wypozyczalnia = new Wypozyczalnia();

            // Act & Assert
            Assert.IsNotNull(wypozyczalnia.Samochody);
        }

        //Test metody DodajKlienta()

        [TestMethod]
        public void DodajKlienta_UnitTest()
        {
            // Arrange
            Wypozyczalnia wypo = new Wypozyczalnia();
            Klient klient = new Klient(); 
            // Act
            wypo.DodajKlienta(klient);

            // Assert
            List<Klient> Klienci = wypo.Klienci;
            Assert.IsNotNull(Klienci);
            Assert.AreEqual(1, Klienci.Count);
            Assert.AreEqual(klient, Klienci[0]);
        }


    }

}

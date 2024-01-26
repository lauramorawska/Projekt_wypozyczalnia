using Projekt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    public partial class DodajWypozyczenieWindow : Window
    {
        private string filename;

        Wypozyczenie wypozyczenie;

        public static Wypozyczalnia wypozyczalnia = new Wypozyczalnia();

        public DodajWypozyczenieWindow()
        {
            InitializeComponent();
            wypozyczalnia = WypozyczeniaWindow.wypozyczalnia;
            Wypozyczalnia w = wypozyczalnia;
            cbKlienci.ItemsSource = new ObservableCollection<Klient>(wypozyczalnia.Klienci);
            cbPracownicy.ItemsSource = new ObservableCollection<Pracownik>(wypozyczalnia.Pracownicy);
            cbSamochody.ItemsSource = new ObservableCollection<Samochod>(wypozyczalnia.Samochody);


        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            bool res = false;
            Wypozyczenie w = new Wypozyczenie();
            if (datePickerDataWyp.SelectedDate != null
                && datePickerDataZwrotu.SelectedDate != null
                && cbKlienci.SelectedItem != null
                && cbSamochody.SelectedItem != null
                && !string.IsNullOrEmpty(txtCenaZaDzien.Text)
                
                && cbPracownicy.SelectedItem != null)
            {


                DateTime datawyp = datePickerDataWyp.SelectedDate ?? DateTime.MinValue;
                DateTime datazwrotu = datePickerDataZwrotu.SelectedDate ?? DateTime.MinValue;
                if (!decimal.TryParse(txtCenaZaDzien.Text, out decimal cenazadzien) || cenazadzien <= 0)
                {
                    MessageBox.Show("Błąd: Cena za dzień musi być liczbą.", "Błąd");
                    return;
                }
                if (datazwrotu < datawyp)
                {
                    MessageBox.Show("Błąd: Data zwrotu nie może być wcześniejsza niż data wypożyczenia.", "Błąd");
                    return;
                }

                w.DataWypozyczenia= datawyp ;
                w.DataZwrotu = datazwrotu ;
                w.CenaZaDzienWypozyczenia = cenazadzien;
                
                cbKlienci.ItemsSource = wypozyczalnia.Klienci;
                cbKlienci.DisplayMemberPath = "Nazwisko";

                cbPracownicy.ItemsSource = wypozyczalnia.Pracownicy;
                cbPracownicy.DisplayMemberPath = "Nazwisko";

                w.Klient = (Klient)cbKlienci.SelectedItem;
                w.Pracownik = (Pracownik)cbPracownicy.SelectedItem;
                if (!w.Pracownik.Dostepny)
                {
                    MessageBox.Show("Pracownik jest na urlopie. Wybierz innego pracownika.");
                    return;
                }
                w.Samochod = (Samochod)cbSamochody.SelectedItem;
                int maxNumer = wypozyczalnia.Wypozyczenia.Max(wyp => wyp.AktualnyNumer);
                w.AktualnyNumer = maxNumer + 1;
                w.Kaucja=w.Samochod.Kaucja;
            }
            else
            {
                MessageBox.Show("Błąd: Wszystkie pola muszą być uzupełnione.", "Błąd");
                return;
            }
            if (w!=null) 
            {
                wypozyczalnia.NoweWypozyczenie(w);
            }
            DialogResult = res;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void cbPracownicy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

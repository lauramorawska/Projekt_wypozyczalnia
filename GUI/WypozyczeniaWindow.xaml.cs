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
    public partial class WypozyczeniaWindow : Window
    {
        public static Wypozyczalnia wypozyczalnia;
       
        string filename;
        private List<Wypozyczenie> aktualneWypozyczenia;

        public WypozyczeniaWindow()
        {
            InitializeComponent();

        }

        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = Environment.CurrentDirectory;  // ustawiam konkretny dokument
            dlg.Filter = "xml files (*.zml)|*.xml"; // filtrujemy pliki z rozszerzeniem xml
            Nullable<bool> result = dlg.ShowDialog();
            //bool? result = dlg.ShowDialog();   to samo co wyzej 
            if (result == true)
            {
                string filename = dlg.FileName;
                wypozyczalnia = Wypozyczalnia.Odczytaj(filename);
                if (wypozyczalnia is not null)
                {

                    LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(wypozyczalnia.Wypozyczenia);
                }
            }
        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            if (filename is not null)
            {
                wypozyczalnia.Zapisz(filename);
            }
            else
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;

                    wypozyczalnia.Zapisz(filename);
                }
            }
        }


        private void MenuZakoncz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LstWypozyczenia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void BtnCofnij_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

         private void BtnWypozyczSamochod_Click(object sender, RoutedEventArgs e)
         {
            if (wypozyczalnia is not null)
            {
                if (LstWypozyczenia.SelectedIndex > -1 && wypozyczalnia is not null)
                {
                    Wypozyczenie wybraneWypozyczenie = LstWypozyczenia.SelectedItem as Wypozyczenie;



                    if (wybraneWypozyczenie.Pracownik.Dostepny)
                    {
                        if (wybraneWypozyczenie.Samochod.CzyDostepny == true)
                        {
                            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz wypożyczyć ten samochód?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question);

                            if (result == MessageBoxResult.Yes)
                            {
                                LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(wypozyczalnia.Wypozyczenia);
                                wypozyczalnia.WypozyczSamochod(LstWypozyczenia.SelectedItem as Wypozyczenie);
                                AktualizujListeWypozyczen();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ten samochód jest już wypożyczony.", "Informacja");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pracownik obsługujący to wypożyczenie jest na urlopie. Konieczne znalezienie zastępstwa! Dodaj nowe wypożyczenie z tymi samymi danymi, ale innym pracownikiem obsługującym");
                    }
                }else
                {
                    MessageBox.Show("Najpierw wybierz wypożyczenie", "Informacja");
                }
            
                
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie", "Informacja");
            }
        }
       


        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia != null)
            {
                Wypozyczenie w = new Wypozyczenie();
                DodajWypozyczenieWindow dww = new();
                bool? res = dww.ShowDialog();
                if (res == true && wypozyczalnia is not null)
                {
                    wypozyczalnia.NoweWypozyczenie(w);
                    LstWypozyczenia.ItemsSource =
                        new ObservableCollection<Wypozyczenie>(wypozyczalnia.Wypozyczenia);
                }
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie", "Informacja");
            }
        }

        private void BtnAktualneWypozyczenia_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia != null)
            {
                aktualneWypozyczenia = wypozyczalnia.ZnajdzAktualnieWypozyczeniaLista();
                LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(aktualneWypozyczenia);
            }else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie", "Informacja");
            }
        }

        private void BtnZwrocSamochod_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia != null)
            {
                if (LstWypozyczenia.SelectedIndex > -1 && wypozyczalnia is not null)
                {
                    Wypozyczenie wybraneWypozyczenie = LstWypozyczenia.SelectedItem as Wypozyczenie;

                    if (wybraneWypozyczenie != null)
                    {
                        try
                        {
                            if (wybraneWypozyczenie.Samochod.CzyDostepny == false)
                            {
                                MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz oddać samochód?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question);

                                if (result == MessageBoxResult.Yes)
                                {
                                    wypozyczalnia.OddanieSamochodu(wybraneWypozyczenie, true);
                                    AktualizujListeWypozyczen();
                                    decimal kwota = wybraneWypozyczenie.Kwota();
                                    MessageBox.Show($"Kwota do zapłacenia: {kwota:C}");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ten samochód został już oddany.", "Informacja");
                            }
                        }
                        catch (ArgumentException)
                        {
                            MessageBox.Show("Błąd: Ten samochód został już oddany.", "Błąd");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie wybrano żadnego wypożyczenia.", "Informacja");
                    }
                }
                else
                {
                    MessageBox.Show("Najpierw wybierz wypożyczenie", "Informacja");
                }
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie", "Informacja");
            }
        }


        private void AktualizujListeWypozyczen()
        {
            if (wypozyczalnia != null)
            {
                List<Wypozyczenie> aktualneWypozyczenia = wypozyczalnia.ZnajdzAktualnieWypozyczeniaLista();
                LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(aktualneWypozyczenia);
            }else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie", "Informacja");
            }
        }

        private void BtnPelnaListaWypozyczen_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia != null)
            {
                LstWypozyczenia.ItemsSource =
                        new ObservableCollection<Wypozyczenie>(wypozyczalnia.Wypozyczenia);
            }else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie", "Informacja");
            }
        }
    }
}

using Newtonsoft.Json;
using Projekt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace GUI
{

    public partial class PracownicyWindow : Window
    {
        Wypozyczalnia wypozyczalnia;


        public PracownicyWindow()
        {
            InitializeComponent();
            //LstPracownicy = new ObservableCollection<Pracownik>();
            //WczytajPracownikowZPliku();

        }

        private string filename;


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

                    LstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(wypozyczalnia.Pracownicy);
                }
            }
        }

        private void MenuZakoncz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }





        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia != null)
            {
                Pracownik p = new();
                DodajPracownikaWindow dpw = new(p);
                bool? res = dpw.ShowDialog();
                if (res == true && wypozyczalnia is not null)
                {
                    wypozyczalnia.DodajPracownika(p);
                    LstPracownicy.ItemsSource =
                        new ObservableCollection<Pracownik>(wypozyczalnia.Pracownicy);
                }
            }
            else
            {
                MessageBox.Show("Najpierw Wczytaj wypozyczalnie!");
                return;
            }

        }

        private void BtnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia != null)
            {
                if (LstPracownicy.SelectedIndex > -1 && wypozyczalnia is not null)
                {
                    var result = MessageBox.Show("Czy na pewno chcesz usunać tego pracownika?", "Ostrzeżenie", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        wypozyczalnia.Pracownicy.Remove(LstPracownicy.SelectedItem as Pracownik);
                        LstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(wypozyczalnia.Pracownicy);
                    }
                    else
                    {

                    }

                }
                else
                {
                    MessageBox.Show("Najpierw Wybierz pracownika!");
                }
            }
            else
            {

                MessageBox.Show("Najpierw Wczytaj wypozyczalnie!");
                return;
            }

        }


        private void BtnSortuj_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia != null)
            {
                if (wypozyczalnia.Pracownicy is not null)
                {
                    wypozyczalnia.SortujNazwiskoImiePracownika();
                    LstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(wypozyczalnia.Pracownicy);
                    MessageBox.Show("Posortowano!");
                }
            }
            else
            {
                MessageBox.Show("Najpierw Wczytaj wypozyczalnie!");
                return;
            }
        }




        private void BtnCofnij_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void LstPracownicy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnUrlop_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia != null)
            {
                if (LstPracownicy.SelectedIndex > -1 && wypozyczalnia is not null) // czy cos zostalo wybrane?
                {
                    Pracownik p = LstPracownicy.SelectedItem as Pracownik;
                    if (p is not null) // czy nie jest null
                    {
                        p.Dostepny = false;
                        LstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(wypozyczalnia.Pracownicy);
                    }
                }
                else
                {
                    MessageBox.Show("Najpierw Wybierz pracownika!");
                }
            }
            else
            {
                MessageBox.Show("Najpierw Wczytaj wypozyczalnie!");
                return;
            }


        }

        private void BtnPraca_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia != null)
            {
                Pracownik p = LstPracownicy.SelectedItem as Pracownik;
                if (p is not null) // czy nie jest null
                {
                    p.Dostepny = true;
                    LstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(wypozyczalnia.Pracownicy);
                }
                else
                {
                    MessageBox.Show("Najpierw Wybierz pracownika!");
                }
            }
            else
            {

                MessageBox.Show("Najpierw Wczytaj wypozyczalnie!");
                return;

            }
        }
    }
}

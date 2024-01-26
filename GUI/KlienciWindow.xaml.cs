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
    /// <summary>
    /// Logika interakcji dla klasy KlienciWindow.xaml
    /// </summary>
    public partial class KlienciWindow : Window
    {
        Wypozyczalnia wypozyczalnia;



        public Klient K { get; set; }

        public KlienciWindow()
        {
            InitializeComponent();

        }



        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia != null)
            {
                Klient k = new();
                DodajKlientaWindow kw = new(k);
                bool? res = kw.ShowDialog();
                if (res == true && wypozyczalnia is not null)

                    wypozyczalnia.DodajKlienta(k);
                LstKlienci.ItemsSource =
                    new ObservableCollection<Klient>(wypozyczalnia.Klienci);
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
                if (LstKlienci.SelectedIndex > -1 && wypozyczalnia is not null)
                {
                    var result = MessageBox.Show("Czy na pewno chcesz usunać tego klienta?", "Ostrzeżenie", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        wypozyczalnia.Klienci.Remove(LstKlienci.SelectedItem as Klient);
                        LstKlienci.ItemsSource = new ObservableCollection<Klient>(wypozyczalnia.Klienci);
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Najpierw Wybierz Klienta!");
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
                if (wypozyczalnia.Klienci is not null)
                {
                    wypozyczalnia.SortujNazwiskoImieKlienta();
                    LstKlienci.ItemsSource = new ObservableCollection<Klient>(wypozyczalnia.Klienci);
                    MessageBox.Show("Posortowano Klientow!");
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

        private void LstKlienci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;

                wypozyczalnia.Zapisz(filename);
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

                    LstKlienci.ItemsSource = new ObservableCollection<Klient>(wypozyczalnia.Klienci);
                }
            }
        }

        private void MenuZakoncz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}

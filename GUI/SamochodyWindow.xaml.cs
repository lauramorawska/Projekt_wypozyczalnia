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
    /// Logika interakcji dla klasy SamochodyWindow.xaml
    /// </summary>
    public partial class SamochodyWindow : Window
    {
        Wypozyczalnia wypozyczalnia;
        private string filename;




        public SamochodyWindow()
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

                    LstSamochody.ItemsSource = new ObservableCollection<Samochod>(wypozyczalnia.Samochody);
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

        private void LstPracownicy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnCofnij_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void BtnKlasyczny_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia is not null)
            {
                SamochodKlasyczny s = new();
                DodajSamochodKlasycznyWindow dskw = new(s);
                bool? res = dskw.ShowDialog();
                if (res == true && wypozyczalnia is not null)
                {
                    wypozyczalnia.DodajAuto(s);
                    LstSamochody.ItemsSource =
                        new ObservableCollection<Samochod>(wypozyczalnia.Samochody);
                }
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie", "Informacja");
            }
        }

        private void BtnSportowy_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia is not null)
            {
                SamochodSportowy s = new();
                DodajSamochodSportowyWindow dssw = new(s);
                bool? res = dssw.ShowDialog();
                if (res == true && wypozyczalnia is not null)
                {
                    wypozyczalnia.DodajAuto(s);
                    LstSamochody.ItemsSource =
                        new ObservableCollection<Samochod>(wypozyczalnia.Samochody);
                }
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie", "Informacja");
            }

        }

        private void BtnWieloosobowy_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia is not null)
            {
                SamochodWieloosobowy s = new();
                DodajSamochodWieloosobowyWindow dsww = new(s);
                bool? res = dsww.ShowDialog();
                if (res == true && wypozyczalnia is not null)
                {
                    wypozyczalnia.DodajAuto(s);
                    LstSamochody.ItemsSource =
                        new ObservableCollection<Samochod>(wypozyczalnia.Samochody);
                }
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie", "Informacja");
            }

        }

        private void BtnCabriolet_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia is not null)
            {
                SamochodCabriolet s = new();
                DodajSamochodCabrioletWindow dscw = new DodajSamochodCabrioletWindow(s);
                bool? res = dscw.ShowDialog();
                if (res == true && wypozyczalnia is not null)
                {
                    wypozyczalnia.DodajAuto(s);
                    LstSamochody.ItemsSource =
                        new ObservableCollection<Samochod>(wypozyczalnia.Samochody);
                }
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie", "Informacja");
            }

        }

        private void BtnWypozyczoneAuta_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia is not null)
            {
                string aktualnieWypozyczoneAuta = wypozyczalnia.ZnajdzAktualnieWypozyczoneAuta();
                MessageBox.Show(aktualnieWypozyczoneAuta, "Aktualnie Wypożyczone Samochody");
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie");
            }
        }

        private void BtnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczalnia is not null)
            {
                if (LstSamochody.SelectedIndex > -1)
                {
                    var result = MessageBox.Show("Czy na pewno chcesz usunać ten samochód?", "Ostrzeżenie", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        wypozyczalnia.Samochody.Remove(LstSamochody.SelectedItem as Samochod);
                        LstSamochody.ItemsSource = new ObservableCollection<Samochod>(wypozyczalnia.Samochody);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Najpierw wybierz samochód!");
                }
            }
            else
            {
                MessageBox.Show("Najpierw wczytaj wypożyczalnie!");
            }
        }
    }
}

using Newtonsoft.Json.Linq;
using Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy DodajKlientaWindow.xaml
    /// </summary>
    public partial class DodajKlientaWindow : Window
    {
        Klient klient;
        //private Klient editedKlient;


        public DodajKlientaWindow()
        {
            InitializeComponent();
        }

        public DodajKlientaWindow(Klient klient) : this()
        {
            this.klient = klient;
            //this.editedKlient = klient.Clone() as Klient;

            // Populate TextBox values based on the selected Klient's data
            TxtImie.Text = klient.Imie;
            TxtNazwisko.Text = klient.Nazwisko;
            TxtNrTelefonu.Text = klient.NumerTelefonu;
            TxtNrDowodu.Text = klient.NrDowoduOsobistego;

        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            bool res = false;

            if (!string.IsNullOrEmpty(TxtImie.Text)
                && !string.IsNullOrEmpty(TxtNazwisko.Text)
                && !string.IsNullOrEmpty(TxtNrTelefonu.Text)
                && !string.IsNullOrEmpty(TxtNrDowodu.Text))

            {
                klient.Imie = TxtImie.Text;
                klient.Nazwisko = TxtNazwisko.Text;

                if (!Regex.IsMatch(TxtNrTelefonu.Text, @"^\d{9}"))
                {
                    MessageBox.Show("Zly numer telefonu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
                else
                {
                    klient.NumerTelefonu = TxtNrTelefonu.Text;

                }

               

                if (!Regex.IsMatch(TxtNrDowodu.Text, @"^[A-Z]{3}\d{6}$"))
                {
                    MessageBox.Show("Zly numer dowodu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
                else
                {
                    klient.NrDowoduOsobistego = TxtNrDowodu.Text;


                }

                res = true;


            }
            else
            {
                MessageBox.Show("Błąd: Wszystkie pola muszą być uzupełnione.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DialogResult = res;

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

        }
    }
}

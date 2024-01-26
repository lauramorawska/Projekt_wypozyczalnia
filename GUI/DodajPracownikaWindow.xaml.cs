using Newtonsoft.Json.Linq;
using Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
    /// Logika interakcji dla klasy DodajPracownikaWindow.xaml
    /// </summary>
    public partial class DodajPracownikaWindow : Window
    {
        
        Pracownik pracownik;
        private ZapisPracownikaDelegate zapiszPracownika;
        public DodajPracownikaWindow()
        {
            InitializeComponent();
        }

        public DodajPracownikaWindow(Pracownik pracownik):this()
        {
            this.pracownik = pracownik;

        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            bool res = false;

            if (!string.IsNullOrEmpty(TxtImie.Text)
                && !string.IsNullOrEmpty(TxtNazwisko.Text)
                && !string.IsNullOrEmpty(TxtPesel.Text)
                && CmbDostepnosc.SelectedItem != null
                && !string.IsNullOrEmpty(TxtNrTelefonu.Text)
                && CmbRola.SelectedItem != null)
            {
                pracownik.Imie = TxtImie.Text;
                pracownik.Nazwisko = TxtNazwisko.Text;
                if (!Regex.IsMatch(TxtPesel.Text, @"^\d{11}"))
                {
                    MessageBox.Show("Zly pesel", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
                else
                {
                    pracownik.Pesel = TxtPesel.Text;

                }


                pracownik.Dostepny = (CmbDostepnosc.SelectedItem as ComboBoxItem)?.Content.ToString() == "Tak";

                if (!Regex.IsMatch(TxtNrTelefonu.Text, @"^\d{9}"))
                {
                    MessageBox.Show("Zly numer telefonu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
                else
                {
                    pracownik.NrTelefonu = TxtNrTelefonu.Text;

                }

                
                if (CmbRola.SelectedItem is ComboBoxItem selectedRoleItem)
                {
                    EnumRola selectedRola;
                    if (Enum.TryParse(selectedRoleItem.Name, out selectedRola))
                    {
                        pracownik.Rola = selectedRola;
                        res = true;
                    }
                    else
                    {
                        MessageBox.Show("Źle wybrana rola", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }


              this.zapiszPracownika=MainWindow.ZapisPracownika;
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

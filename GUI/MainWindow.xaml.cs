using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Projekt;

namespace GUI
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public delegate void ZapisPracownikaDelegate(Pracownik pracownik);
    public partial class MainWindow : Window
    {
        
        Wypozyczalnia wypozyczalnia;

        public MainWindow()
        {
            InitializeComponent();
            SoundPlayer muzyka = new SoundPlayer("Muzyka.wav");
            muzyka.PlayLooping();
        }
        public static void ZapisPracownika(Pracownik pracownik)
        {
            try
            {
                using (StreamWriter sw = new(Convert.ToString(pracownik.NrTelefonu)))
                {
                    XmlSerializer xs = new(typeof(Pracownik));
                    xs.Serialize(sw, pracownik);
                }
            }
            catch { }
        }
        private void BtnPracownicy_Click(object sender, RoutedEventArgs e)
        {

            PracownicyWindow pw = new PracownicyWindow();
            pw.Show();
            this.Close();
           
        }
       

        private void BtnKlienci_Click(object sender, RoutedEventArgs e)
        {
            KlienciWindow kw = new KlienciWindow();
            kw.Show();
            this.Close();

        }

        private void BtnSamochody_Click(object sender, RoutedEventArgs e)
        {
            SamochodyWindow sw = new SamochodyWindow();
            sw.Show();
            this.Close();
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

                    TxtNazwaWypozyczalni.Text = wypozyczalnia.Nazwa;
                }
            }
        }

        private void MenuZakoncz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnWypozyczenia_Click(object sender, RoutedEventArgs e)
        {
            WypozyczeniaWindow ww = new WypozyczeniaWindow();
            ww.Show();
            this.Close();

        }

        private void PokażStanKasy_Click(object sender, RoutedEventArgs e)
        {
            if(wypozyczalnia != null)
            {
                stanKasyTextBlock.Text = wypozyczalnia.WypiszStanKasy();
            }else
            {
                MessageBox.Show("Najpierw Wczytaj wypozyczalnie!");
                return;
            }
        }
    }
    public class ZapisPracownikaException:Exception 
    {
    }
}

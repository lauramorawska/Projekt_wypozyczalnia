﻿using Projekt;
using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy DodajSamochodCabrioletWindow.xaml
    /// </summary>
    public partial class DodajSamochodCabrioletWindow : Window
    {
        SamochodCabriolet samochod;
        public DodajSamochodCabrioletWindow()
        {
            InitializeComponent();
        }
        public DodajSamochodCabrioletWindow(SamochodCabriolet samochod) :this()
        {
            this.samochod = samochod;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            bool res = false;

            if (!string.IsNullOrEmpty(TxtMarka.Text)
                && !string.IsNullOrEmpty(TxtModel.Text)
                && !string.IsNullOrEmpty(TxtNrRejestracyjny.Text)
                && CmbDostepnosc.SelectedItem != null
                && !string.IsNullOrEmpty(TxtRokProdukcji.Text)
                && CmbStan.SelectedItem != null)
            {
                samochod.Marka= TxtMarka.Text;
                samochod.Model= TxtModel.Text;
                samochod.NumerRejestracyjny = TxtNrRejestracyjny.Text;
                samochod.CzyDostepny= (CmbDostepnosc.SelectedItem as ComboBoxItem)?.Content.ToString() == "Tak";

                

                if (CmbStan.SelectedItem is ComboBoxItem selectedStanItem)
                {
                    EnumStan selectedStan;
                    if (Enum.TryParse(selectedStanItem.Name, out selectedStan))
                    {
                        samochod.Stan = selectedStan;
                        res = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid stan selection", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                if (CmbDach.SelectedItem is ComboBoxItem selectedDachItem)
                {
                    EnumDach selectedDach;
                    if (Enum.TryParse(selectedDachItem.Name, out selectedDach))
                    {
                        samochod.Dach = selectedDach;
                        res = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid dach selection", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                if (!int.TryParse(TxtRokProdukcji.Text, out int rokProdukcji) || rokProdukcji <= 0)
                {
                    MessageBox.Show("Błąd: Cena za dzień musi być liczbą.", "Błąd");
                    return;
                }
                else
                {
                    samochod.RokProdukcji = rokProdukcji;
                }


            }
            else
            {
                MessageBox.Show("Błąd: Wszystkie pola muszą być uzupełnione.", "Błąd");
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

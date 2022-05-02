using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Trabajo1
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Combate : Page
    {
        public Combate()
        {
            this.InitializeComponent();
        }
        private void EnterMap(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Map));
        }
        private void Settings(object sender, RoutedEventArgs e)
        {
            if (settingGrid.Visibility == Visibility.Visible)
            {
                settingGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                settingGrid.Visibility = Visibility.Visible;
            }
        }
        private void EnterSpells(object sender, RoutedEventArgs e)
        {
            if(OpenBook.Visibility == Visibility.Visible)
            {
                ClosedBook.Visibility = Visibility.Visible;
                OpenBook.Visibility = Visibility.Collapsed;
                SpellGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                OpenBook.Visibility = Visibility.Visible;
                ClosedBook.Visibility = Visibility.Collapsed;
                SpellGrid.Visibility = Visibility.Visible;

            }
        }
        private void ReturnMenu(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void NewTurn(object sender, RoutedEventArgs e)
        {
            int newTurn = int.Parse(Turn.Text);
            if (newTurn > 9)
            {
                Frame.Navigate(typeof(Map));
            }
            else Turn.Text = Convert.ToString(newTurn += 1);
        }
        private void SpellFrost(object sender, RoutedEventArgs e)
        {
            if(Frost.BorderThickness == new Thickness(0))
            {
                Frost.BorderThickness = new Thickness(5);
                Fireball.BorderThickness = new Thickness(0);

            }
            else Frost.BorderThickness = new Thickness(0);
        }
        private void SpellFire(object sender, RoutedEventArgs e)
        {
            if (Fireball.BorderThickness == new Thickness(0))
            {
                Fireball.BorderThickness = new Thickness(5);
                Frost.BorderThickness = new Thickness(0);

            }
            else Fireball.BorderThickness = new Thickness(0);
        }
    }
}


//e61610 rojo
//00c8f8 azul

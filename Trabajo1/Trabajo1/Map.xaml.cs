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
    public sealed partial class Map : Page
    {
        public Map()
        {
            this.InitializeComponent();
            mapGrid.Visibility = Visibility.Visible;
        }
        private void EnterResources(object sender, RoutedEventArgs e)
        {
            mapGrid.Visibility = Visibility.Collapsed;
            resourcesGrid.Visibility = Visibility.Visible;
        }
        private void EnterTroops(object sender, RoutedEventArgs e)
        {
            mapGrid.Visibility = Visibility.Collapsed;
            troopsGrid.Visibility = Visibility.Visible;
        }
        private void EnterCombat(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Combate));
        }
        private void Settings(object sender, RoutedEventArgs e)
        {
            mapGrid.Visibility = Visibility.Collapsed;
            settingGrid.Visibility = Visibility.Visible;
        }
        private void ReturnMap(object sender, RoutedEventArgs e)
        {
            mapGrid.Visibility = Visibility.Visible;
            troopsGrid.Visibility = Visibility.Collapsed;
            resourcesGrid.Visibility = Visibility.Collapsed;
            settingGrid.Visibility = Visibility.Collapsed;

        }
        private void ReturnMenu(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void StoreButton1_onClick(object sender, RoutedEventArgs e)
        {
            if(int.Parse(oro.Text) >= 100)
            {
                int newOro = int.Parse(oro.Text);
                oro.Text = Convert.ToString(newOro -= 100);

                int newMadera = int.Parse(madera.Text);
                madera.Text = Convert.ToString(newMadera += 1);
                if(newOro < 100)
                {
                    StoreButton1.IsEnabled = false;
                }
            }
        }
        private void StoreButton2_onClick(object sender, RoutedEventArgs e)
        {
            if (int.Parse(mineral.Text) >= 1)
            {
                int newMineral = int.Parse(mineral.Text);
                mineral.Text = Convert.ToString(newMineral -= 1);

                int newPiedra = int.Parse(piedra.Text);
                piedra.Text = Convert.ToString(newPiedra += 4);
                if (newMineral < 1)
                {
                    StoreButton2.IsEnabled = false;
                }
            }
        }
        //private void CommandBar_KeyDown(object sender, KeyRoutedEventArgs e)
        //{
        //    if (e.Key == Windows.System.VirtualKey.Tab)
        //    {
        //        e.Handled = true;
        //        DependencyObject candidate = null;
        //        candidate = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Next);
        //        (candidate as Control).Focus(FocusState.Keyboard);
        //    }
        //}
    }
}

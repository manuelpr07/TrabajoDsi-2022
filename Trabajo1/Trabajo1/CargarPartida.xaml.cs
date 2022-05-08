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
    public sealed partial class CargarPartida : Page
    {
        private string Idiomas;
        public CargarPartida()
        {
            this.InitializeComponent();
            Idiomas = "spanish";
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }
        private void ReturnMap(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), Idiomas);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Idiomas = e.Parameter as string;
            ChangeLenguages(Idiomas);
        }
        private void ChangeLenguages(string l)
        {
            if (l == "spanish")
            {
                cargarT.Text = "Cargar Partida";
            }
            else if (l == "english")
            {
                cargarT.Text = "Load Game";
            }
            else if (l == "french")
            {
                cargarT.Text = "Chargement du jeu";
            }
        }

        private void TextBox_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var c = sender as TextBox;
            if (c.Text != null)
            {
                c.SetValue(BackgroundProperty, "#CC00C3FF");
                c.SetValue(BackgroundProperty, "Black");
            }
            else
            {
                c.SetValue(BackgroundProperty, "DarkCyan");
                c.SetValue(ForegroundProperty, "DarkGray");
            }
        }
    }
}

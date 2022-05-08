using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Trabajo1
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string Idiomas;
        static double volumeAux = 0;
        public static MediaPlayer player;
        public MainPage()
        {
            this.InitializeComponent();
            Idiomas = "spanish";
            LenguageBox.Text = "Español";
            Español.IsSelected = true;
            ElementSoundPlayer.Volume = 0;
            player = App.getPlayer();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Idiomas = e.Parameter as string;
            if (Idiomas == "spanish")
            {
                Español.IsSelected = true;
            }
            else if (Idiomas == "english")
            {
                Ingles.IsSelected = true;
            }
            else if (Idiomas == "french")
            {
                Frances.IsSelected = true;
            }
            ChangeLenguages(Idiomas);

            if (player.Volume != 0)
            {
                music.Value = player.Volume*10;
            }
        }

        private void Page1Button_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Map), Idiomas);
        }
        private void Page2Button_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CargarPartida), Idiomas);
        }
        private void ReturnMap(object sender, RoutedEventArgs e)
        {
            settingGrid.Visibility = Visibility.Collapsed;
            MainGrid.Visibility = Visibility.Visible;
        }
        private void SettingsButton(object sender, RoutedEventArgs e)
        {
            settingGrid.Visibility = Visibility.Visible;
            MainGrid.Visibility = Visibility.Collapsed;
        }
        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Español.IsSelected)
            {
                Idiomas = "spanish";
            }
            else if (Ingles.IsSelected)
            {
                Idiomas = "english";
            }
            else if (Frances.IsSelected)
            {
                Idiomas = "french";
            }

            ChangeLenguages(Idiomas);
        }
        private void ChangeLenguages(string l)
        {
            if (l == "spanish")
            {
                //Main Grid
                nuevaPartida.Content = "Nueva Partida";
                cargarPartida.Content = "Cargar Partida";
                modosDeJuego.Content = "Modos de Juego";
                config.Content = "Configuración";

                //Config Grid
                ConfigT.Text = "Configuración";
                musicaT.Text = "Música";
                LenguageBox.Header = "Cambia de Idioma";
            }
            else if (l == "english")
            {
                //Main Grid
                nuevaPartida.Content = "New game";
                cargarPartida.Content = "Load Game";
                modosDeJuego.Content = "Game modes";
                config.Content = "Setting";

                //Config Grid
                ConfigT.Text = "Setting";
                musicaT.Text = "Music";
                LenguageBox.Header = "Change Lenguage";
            }
            else if (l == "french")
            {
                //Main Grid
                nuevaPartida.Content = "Nouveau jeu";
                cargarPartida.Content = "Chargement du jeu";
                modosDeJuego.Content = "Modes de jeu";
                config.Content = "Paramètre";

                //Config Grid
                ConfigT.Text = "Paramètre";
                musicaT.Text = "Musique";
                LenguageBox.Header = "Changer la Langue";
            }
        }
        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (e.NewValue == 0)
            {
                player.Volume = 0;
            }
            else if (e.NewValue == 100) player.Volume = 1;
            else
            {
                if (e.NewValue > e.OldValue) //Subir volumen 
                {

                    if (player.Volume + 0.01 <= 1) player.Volume += (e.NewValue - e.OldValue) / 10;
                }
                else if (e.NewValue < e.OldValue) //Bajar Volumen 
                {
                    if (player.Volume - 0.01 >= 0) player.Volume += (e.NewValue - e.OldValue) / 10; ;
                }
            }
        }
    }
}

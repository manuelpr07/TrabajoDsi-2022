﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Gaming.Input;
using Windows.UI.Core;
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
        private string Idiomas;

        CoreCursor CursorHand = null;

        private readonly object myLock = new object();
        private List<Gamepad> myGamepads = new List<Gamepad>();
        private Gamepad mainGamepad;

        private GamepadReading reading, prereading;
        private GamepadVibration vibration;

        DispatcherTimer GamePadTimer;
        public Combate()
        {
            this.InitializeComponent();
            CursorHand = new CoreCursor(CoreCursorType.Hand, 0);
            Window.Current.CoreWindow.PointerCursor = CursorHand;
            Idiomas = "spanish";

            Gamepad.GamepadAdded += (object sender, Gamepad e) =>
            {
                // comprueba si el gamepad está en la lista de myGamepads, si no lo añade
                lock (myLock)
                {
                    bool gamepadInList = myGamepads.Contains(e);

                    if (!gamepadInList)
                    {
                        myGamepads.Add(e);
                        mainGamepad = myGamepads[0];
                    }
                }
            };
            Gamepad.GamepadRemoved += (object sender, Gamepad e) =>
            {
                lock (myLock)
                {
                    int indexRemoved = myGamepads.IndexOf(e);

                    if (indexRemoved > -1)
                    {
                        if (mainGamepad == myGamepads[indexRemoved])
                        {
                            mainGamepad = null;
                        }

                        myGamepads.RemoveAt(indexRemoved);
                    }
                }
            };
        }

        void LeeMando()
        {
            if (mainGamepad != null)
            {
                prereading = reading;
                reading = mainGamepad.GetCurrentReading();
            }

        }
        //void FeedBack()
        //{
        //    if (int.Parse(Turn.Text) > 9)
        //    {
        //        vibration.RightMotor = 0.8;
        //        vibration.LeftMotor = 0.8;
        //    }
        //    else
        //    {
        //        vibration.RightMotor = 0.0;
        //        vibration.LeftMotor = 0.0;
        //    }
        //}
            void GamePadTimer_Tick(object sender, object e)
        { //Función de respuesta al Timer cada 0.01s
            if (mainGamepad != null)
            {
                LeeMando(); //Lee GamePAd
                //FeedBack();
            }
        }
        public void GamePadTimerSetup()
        {
            GamePadTimer = new DispatcherTimer();
            GamePadTimer.Tick += GamePadTimer_Tick;
            GamePadTimer.Interval = new TimeSpan(100000);
            GamePadTimer.Start();
        }
        private void EnterMap(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Map), Idiomas);
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
                //MAIN GRID
                turno.Text = "TURNO";
                ordTropas.Text = "ORDEN DE TROPAS";

                //SPELL GRID
                Hechizos.Text = "LIBRO DE HECHIZOS";
                NomCong.Text = "CONGELACIÓN";
                ManaCong.Text = "20 Maná";
                TextCong.Text = "Causa que un enemigo se quede congelado durante un turno, perdiéndolo y recibiendo un poco de daño.";
                NomFueg.Text = "BOLA DE FUEGO";
                ManaCong.Text = "40 Maná";
                TextCong.Text = "Cae una bola de fuego en un rango de casillas de 3x3 causando mucho daño y causando quemadura a las tropas afectadas";

                //SETTINGS GRID
                ConfigT.Text = "CONFIGURACIÓN";
                musicaT.Text = "MUSICA";
                LenguageBox.Header = "Cambia el Idioma";
                GuartarT.Content = "GUARDAR Y SALIR";
            }
            else if (l == "english")
            {
                //MAIN GRID
                turno.Text = "TURN";
                ordTropas.Text = "TROOPS ORDER";

                //SPELL GRID
                Hechizos.Text = "SPELBOOK";
                NomCong.Text = "FROST";
                ManaCong.Text = "20 Mana";
                TextCong.Text = "Causes an enemy to freeze for one turn, losing it and taking some damage.";
                NomFueg.Text = "FIREBALL";
                ManaCong.Text = "40 Mana";
                TextCong.Text = "Drops a fireball in a range of 3x3 squares dealing high damage and burning affected troops.";

                //SETTINGS GRID
                ConfigT.Text = "CONFIGURATION";
                musicaT.Text = "MUSIC";
                LenguageBox.Header = "Change Lenguage";
                GuartarT.Content = "SAVE AND QUIT";
            }
            else if (l == "french")
            {
                //MAIN GRID
                turno.Text = "TOUR";
                ordTropas.Text = "ORDRE DES TROUPES";

                //SPELL GRID
                Hechizos.Text = "LIVRE DE SORTILÈGES";
                NomCong.Text = "GEL";
                ManaCong.Text = "20 Mana";
                TextCong.Text = "Provoque le gel d'un ennemi pendant un tour, le perd et subit des dégâts.";
                NomFueg.Text = "BOULE DE FEU";
                ManaCong.Text = "40 Mana";
                TextCong.Text = "Lâche une boule de feu dans une plage de 3x3 carrés infligeant des dégâts importants et brûlant les troupes affectées.";

                //SETTINGS GRID
                ConfigT.Text = "PARAMÈTRE";
                musicaT.Text = "MUSIQUE";
                LenguageBox.Header = "Changer la Langue";
                GuartarT.Content = "SAUVEGARDER ET QUITTER";
            }
        }
    }
}


﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Gaming.Input;
using Windows.Media.Playback;
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
    class NavigationInfo
    {
        public string idioma;
        public int[] troops = new int[7];
        public int[] resources = new int[4];
        public int[] resourcesProd = new int[4];
    }
    public sealed partial class Map : Page
    {
        private string Idiomas;
        static double volumeAux = 0;
        public static MediaPlayer player;
        CoreCursor CursorArrow = null;


        public Map()
        {
            this.InitializeComponent();
            CursorArrow = new CoreCursor(CoreCursorType.Arrow, 0);
            Window.Current.CoreWindow.PointerCursor = CursorArrow;
            mapGrid.Visibility = Visibility.Visible;
            Idiomas = "spanish";
            LenguageBox.Text = "Español";
            Español.IsSelected = true;
            ElementSoundPlayer.Volume = 1;
            player = App.getPlayer();
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
            this.Frame.Navigate(typeof(Combate), SetNavigationInfo());
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) 
        {
            NavigationInfo a = e.Parameter as NavigationInfo;

            if (a == null)
            {
                a = new NavigationInfo();
                a.idioma = "spanish";
            }
            else
            {
                GetNavigationInfo(a);
            }
            Idiomas = e.Parameter as string;
            if(Idiomas == "spanish")
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
            Frame.Navigate(typeof(MainPage), Idiomas);
        }
        private void MoveToCastle(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Castle), SetNavigationInfo());
        }
        private void StoreButton1_onClick(object sender, RoutedEventArgs e)
        {
            if(int.Parse(oro.Text) >= 100)
            {
                int newOro = int.Parse(oro.Text) - 100;
                oro.Text = Convert.ToString(newOro);

                int newMadera = int.Parse(madera.Text) + 1;
                madera.Text = Convert.ToString(newMadera);
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
                int newMineral = int.Parse(mineral.Text) - 1;
                mineral.Text = Convert.ToString(newMineral);

                int newPiedra = int.Parse(piedra.Text) + 4;
                piedra.Text = Convert.ToString(newPiedra);
                if (newMineral < 1)
                {
                    StoreButton2.IsEnabled = false;
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int newDay = int.Parse(dia.Text) + 1;
            int newMonth = int.Parse(mes.Text);
            int newWeek = int.Parse(semana.Text);
            if (newDay > 7)
            {
                newDay = 1;
                newWeek = int.Parse(semana.Text) + 1;
                if (newWeek > 4)
                {
                    newWeek = 1;
                    newMonth = int.Parse(mes.Text) + 1;        
                }
            }

            int newOro = int.Parse(oro.Text) + int.Parse(oroPN.Text);
            oro.Text = newOro.ToString();

            if( int.Parse(dia.Text)%7 == 0)
            {
                int newMad = int.Parse(madera.Text) + int.Parse(madPN.Text);
                madera.Text = newMad.ToString();

                int newPied = int.Parse(piedra.Text) + int.Parse(piedPN.Text);
                piedra.Text = newPied.ToString();

                int newMin = int.Parse(mineral.Text) + int.Parse(minPN.Text);
                mineral.Text = newMin.ToString();
            }

            dia.Text = Convert.ToString(newDay);
            semana.Text = Convert.ToString(newWeek);
            mes.Text = Convert.ToString(newMonth);
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

                //MAP GRID
                calendario.Text = "CALENDARIO";
                semanaT.Text = "Semana:";
                mesT.Text = "Mes:";
                diaT.Text = "Dia:";

                //SETTINGS GRID
                ConfigT.Text = "CONFIGURACIÓN";
                musicaT.Text = "MUSICA";
                LenguageBox.Header = "Cambia el Idioma";
                GuartarT.Content = "GUARDAR Y SALIR";

                //ARMY GRID
                MTropas.Text = "MENÚ DE TROPAS";
                NTropas.Text = "NÚMERO DE TROPAS";
                IcTropas.Text = "ICONO";
                NomTropas.Text = "NOMBRE";
                CanTropas.Text = "CANTIDAD";
                GuerTropas.Text = "GUERREROS";
                ArqTropas.Text = "ARQUEROS";
                PiqTropas.Text = "PIQUEROS";
                CabTropas.Text = "CABALLEROS";
                TempTropas.Text = "TEMPLARIOS";
                DragTropas.Text = "DRAGONES";
                AngTropas.Text = "ÁNGELES";
                FormTropas.Text = "FORMACIÓN DE TU EJÉRCITO";

                //RESOURCES GRID
                MRecursos.Text = "MENÚ DE RECURSOS";
                NRecursos.Text = "NÚMERO DE RECURSOS";
                IcRecursos.Text = "ICONO";
                NomRecursos.Text = "NOMBRE";
                CantRecursos.Text = "CANTIDAD";
                ProdRecursos.Text = "PRODUCCIÓN";
                OroRecursos.Text = "MONEDAS";
                MadRecursos.Text = "MADERA";
                PiedRecursos.Text = "PIEDRA";
                MinRecursos.Text = "MINERALES";
                oProdRecursos.Text = "+450/DIA";
                mProdRecursos.Text = "+14/SEMANA";
                pProdRecursos.Text = "+16/SEMANA";
                miProdRecursos.Text = "+5/SEMANA";
                IntRecursos.Text = "INTERCAMBIO DIARIO";
            }
            else if (l == "english")
            {

                //MAP GRID
                calendario.Text = "CALENDAR";
                semanaT.Text = "Week:";
                mesT.Text = "Month:";
                diaT.Text = "Day:";

                //SETTINGS GRID
                ConfigT.Text = "CONFIGURATION";
                musicaT.Text = "MUSIC";
                LenguageBox.Header = "Change Lenguage";
                GuartarT.Content = "SAVE AND QUIT";

                //ARMY GRID
                MTropas.Text = "TROOPS MENU";
                NTropas.Text = "TROOPS NUMBER";
                IcTropas.Text = "ICON";
                NomTropas.Text = "NAME";
                CanTropas.Text = "QUANTITY";
                GuerTropas.Text = "WARRIORS";
                ArqTropas.Text = "ARCHERS";
                PiqTropas.Text = "PICKEMEN";
                CabTropas.Text = "KNIGHTS";
                TempTropas.Text = "TEMPLAR";
                DragTropas.Text = "DRAGONS";
                AngTropas.Text = "ANGELS";
                FormTropas.Text = "ARMY FORMATION";

                //RESOURCES GRID
                MRecursos.Text = "RESOURCES MENU";
                NRecursos.Text = "NUMBER OF RESOURCES";
                IcRecursos.Text = "ICON";
                NomRecursos.Text = "NAME";
                CantRecursos.Text = "QUANTITY";
                ProdRecursos.Text = "PRODUCTION";
                OroRecursos.Text = "COINS";
                MadRecursos.Text = "WOOD";
                PiedRecursos.Text = "STONE";
                MinRecursos.Text = "MINERALS";
                oProdRecursos.Text = "+450/DAY";
                mProdRecursos.Text = "+14/WEEK";
                pProdRecursos.Text = "+16/WEEK";
                miProdRecursos.Text = "+5/WEEK";
                IntRecursos.Text = "DAILY OFFER";
            }
            else if (l == "french")
            {
                //MAP GRID
                calendario.Text = "Calendrier";
                semanaT.Text = "Semaine:";
                mesT.Text = "Mois:";
                diaT.Text = "Jour:";

                //SETTINGS GRID
                ConfigT.Text = "PARAMÈTRE";
                musicaT.Text = "MUSIQUE";
                LenguageBox.Header = "Changer la Langue";
                GuartarT.Content = "SAUVEGARDER ET QUITTER";

                //ARMY GRID
                MTropas.Text = "MENU DES TROUPES";
                NTropas.Text = "NOMBRE DE TROUPES";
                IcTropas.Text = "ICÔNE";
                NomTropas.Text = "NOM";
                CanTropas.Text = "CUNATITÉ";
                GuerTropas.Text = "GUERRIERS";
                ArqTropas.Text = "ARCHERS";
                PiqTropas.Text = "FOUS";
                CabTropas.Text = "MESSIEURS";
                TempTropas.Text = "TEMPLIERS";
                DragTropas.Text = "DRAGONS";
                AngTropas.Text = "ANGES";
                FormTropas.Text = "FORMATION DE L'ARMÉE";

                //RESOURCES GRID
                MRecursos.Text = "MENU DES RESSOURCES";
                NRecursos.Text = "NOMBRE DE RESSOURCES";
                IcRecursos.Text = "ICÔNE";
                NomRecursos.Text = "NOM";
                CantRecursos.Text = "CUNATITÉ";
                ProdRecursos.Text = "PRODUCTION";
                OroRecursos.Text = "DEVISE";
                MadRecursos.Text = "BOIS";
                PiedRecursos.Text = "PIEDRA";
                MinRecursos.Text = "CALCUL";
                oProdRecursos.Text = "+450/Jour";
                mProdRecursos.Text = "+14/SEMAINE";
                pProdRecursos.Text = "+16/SEMAINE";
                miProdRecursos.Text = "+5/SEMAINE";
                IntRecursos.Text = "ÉCHANGE QUOTIDIEN";
            }
        }
        private NavigationInfo SetNavigationInfo()
        {
            NavigationInfo a = new NavigationInfo();
            //recursos
            a.resources[0] = int.Parse(oro.Text);
            a.resources[1] = int.Parse(madera.Text);
            a.resources[2] = int.Parse(piedra.Text);
            a.resources[3] = int.Parse(mineral.Text);

            //prod recursos
            a.resourcesProd[0] = int.Parse(oroPN.Text);
            a.resourcesProd[1] = int.Parse(madPN.Text);
            a.resourcesProd[2] = int.Parse(piedPN.Text);
            a.resourcesProd[3] = int.Parse(minPN.Text);

            //tropas
            a.troops[0] = int.Parse(gNumber.Text);
            a.troops[1] = int.Parse(arqNumber.Text);
            a.troops[2] = int.Parse(pNumber.Text);
            a.troops[3] = int.Parse(cNumber.Text);
            a.troops[4] = int.Parse(tNumber.Text);
            a.troops[5] = int.Parse(dNumber.Text);
            a.troops[6] = int.Parse(aNumber.Text);

            a.idioma = Idiomas;

            return a;
        }
        private void GetNavigationInfo(NavigationInfo a)
        {
            //recursos
            oro.Text = a.resources[0].ToString();
            madera.Text = a.resources[1].ToString();
            piedra.Text = a.resources[2].ToString();
            mineral.Text = a.resources[3].ToString();

            //prod recursos
            oroPN.Text = a.resourcesProd[0].ToString();
            madPN.Text = a.resourcesProd[1].ToString();
            piedPN.Text = a.resourcesProd[2].ToString();
            minPN.Text = a.resourcesProd[3].ToString();

            //tropas
            gNumber.Text = a.troops[0].ToString();
            arqNumber.Text = a.troops[1].ToString();
            pNumber.Text = a.troops[2].ToString();
            cNumber.Text = a.troops[3].ToString();
            tNumber.Text = a.troops[4].ToString();
            dNumber.Text = a.troops[5].ToString();
            aNumber.Text = a.troops[6].ToString();

            if(!string.IsNullOrWhiteSpace(a.idioma))
            {
                Idiomas = a.idioma;
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

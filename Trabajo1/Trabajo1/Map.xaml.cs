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
        private string Idiomas;
        public Map()
        {
            this.InitializeComponent();
            mapGrid.Visibility = Visibility.Visible;
            Idiomas = "spanish";
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
            this.Frame.Navigate(typeof(Combate), Idiomas);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) 
        {          
            Idiomas = e.Parameter as string;
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
            int newYear = int.Parse(año.Text);
            if (newDay > 30)
            {
                newDay = 1;
                newMonth = int.Parse(mes.Text) + 1;
                if (newMonth > 12)
                {
                    newMonth = 1;
                    newYear = int.Parse(mes.Text) + 1;
                }
            }
            dia.Text = Convert.ToString(newDay);
            mes.Text = Convert.ToString(newMonth);
            año.Text = Convert.ToString(newYear);
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
                añoT.Text = "Año:";
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
                añoT.Text = "Year:";
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
                añoT.Text = "An:";
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

    }
}

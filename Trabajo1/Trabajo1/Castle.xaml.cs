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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Trabajo1
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Castle : Page
    {
        private string Idiomas;
        public static MediaPlayer player;
        public Castle()
        {
            this.InitializeComponent();
            ElementSoundPlayer.Volume = 1;
            player = App.getPlayer();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigationInfo a = e.Parameter as NavigationInfo;

            if (a == null)
            {
                Idiomas = "spanish";
            }
            else
            {
                GetNavigationInfo(a);
            }
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
                double aux = player.Volume * 10;
                player.Volume = 0;
                music.Value = aux;
            }
        }
        private void Settings(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Collapsed;
            settingGrid.Visibility = Visibility.Visible;
        }
        private void ReturnMenu(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), Idiomas);
        }
        private void ReturnMap(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Map), SetNavigationInfo());
        }
        private void ReturnCastle(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Visible;
            troopsGrid.Visibility = Visibility.Collapsed;
            resourcesGrid.Visibility = Visibility.Collapsed;
            settingGrid.Visibility = Visibility.Collapsed;
            windmillGrid.Visibility = Visibility.Collapsed;
            barracksGrid.Visibility = Visibility.Collapsed;

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
                //TITLE
                CastleT.Text = "TU cASTILLO";

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

                //WINDMILL GRID 
                molinoText.Text = "CAPATAZ";
                mejoraProdText.Text = "MEJORA DE PRODUCCIÓN";
                mOroProdNom.Text = "Mina de Oro";
                mOroProdTiemp.Text = "/dia";
                mOroProdNiv.Text = "Nivel: ";
                mMadProdNom.Text = "Cabaña del Leñador";
                mMadProdTiemp.Text = "/semana";
                mMadProdNiv.Text = "Nivel: ";
                mPiedProdNom.Text = "Cantera";
                mPiedProdTiemp.Text = "/semana";
                mPiedProdNiv.Text = "Nivel: ";
                mMinProdNom.Text = "Mina de Cristales";
                mMinProdTiemp.Text = "/semana";
                mMinProdNiv.Text = "Nivel: ";

                //BARRACKS GRID
                barracksText.Text = "BARRACONES";
                reclutText.Text = "RECLUTAMIENTO DE TROPAS";
                soldadoN.Text = "Guerreros";
                gCosteT.Text = "Coste: ";
                arqueroN.Text = "Arqueros";
                aCosteT.Text = "Coste: ";
                piqueroN.Text = "Piqueros";
                pCosteT.Text = "Coste: ";
                caballeroN.Text = "Caballeros";
                cCosteT.Text = "Coste: ";
                templarioN.Text = "Templarios";
                tCosteT.Text = "Coste: ";
                dragonesN.Text = "Dragones";
                dCosteT.Text = "Coste: ";
                angelesN.Text = "Ángeles";
                aCosteT.Text = "Coste: ";
            }
            else if (l == "english")
            {
                //TITLE
                CastleT.Text = "YOUR CASTLE";

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
                PiqTropas.Text = "PIKEMEN";
                CabTropas.Text = "KNIGHTS";
                TempTropas.Text = "TEMPLARS";
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

                //WINDMILL GRID 
                molinoText.Text = "FOREMAN";
                mejoraProdText.Text = "PRODUCTION UPGRADE";
                mOroProdNom.Text = "Gold Mine";
                mOroProdTiemp.Text = "/day";
                mOroProdNiv.Text = "Level: ";
                mMadProdNom.Text = "Lumberjack's Hut";
                mMadProdTiemp.Text = "/week";
                mMadProdNiv.Text = "Level: ";
                mPiedProdNom.Text = "Quarry";
                mPiedProdTiemp.Text = "/week";
                mPiedProdNiv.Text = "Level: " ;
                mMinProdNom.Text = "Crystal Mine";
                mMinProdTiemp.Text = "/week";
                mMinProdNiv.Text = "Level: ";

                //BARRACKS GRID
                barracksText.Text = "BARRACKS";
                reclutText.Text = "RECRUITMENT OF TROOPS";
                soldadoN.Text = "Warriors";
                gCosteT.Text = "Cost: ";
                arqueroN.Text = "Archers";
                aCosteT.Text = "Cost: ";
                piqueroN.Text = "Pikemen";
                pCosteT.Text = "Cost: ";
                caballeroN.Text = "Knights";
                cCosteT.Text = "Cost: ";
                templarioN.Text = "Templars";
                tCosteT.Text = "Cost: ";
                dragonesN.Text = "Dragons";
                dCosteT.Text = "Cost: ";
                angelesN.Text = "Angels";
                aCosteT.Text = "Cost: ";
            }
            else if (l == "french")
            {
                //TITLE
                CastleT.Text = "VOTRE CHÂTEAU";

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

                //WINDMILL GRID 
                molinoText.Text = "CONTREMAÎTRE";
                mejoraProdText.Text = "AMÉLIORATION DE LA PRODUCTION";
                mOroProdNom.Text = "Mine d'or";
                mOroProdTiemp.Text = "/jour";
                mOroProdNiv.Text = "Niveau: ";
                mMadProdNom.Text = "Cabane du bûcheron";
                mMadProdTiemp.Text = "/semaine";
                mMadProdNiv.Text = "Niveau: ";
                mPiedProdNom.Text = "Carrière";
                mPiedProdTiemp.Text = "/semaine";
                mPiedProdNiv.Text = "Niveau: ";
                mMinProdNom.Text = "Mine de cristal";
                mMinProdTiemp.Text = "/semaine";
                mMinProdNiv.Text = "Niveau:";

                //BARRACKS GRID
                barracksText.Text = "CASERNE";
                reclutText.Text = "RECRUTEMENT DES TROUPES";
                soldadoN.Text = "Guerriers";
                gCosteT.Text = "Coût: ";
                arqueroN.Text = "Archers";
                aCosteT.Text = "Coût: ";
                piqueroN.Text = "Fous";
                pCosteT.Text = "Coût: ";
                caballeroN.Text = "Messieurs";
                cCosteT.Text = "Coût: ";
                templarioN.Text = "Templiers";
                tCosteT.Text = "Coût: ";
                dragonesN.Text = "Dragons";
                dCosteT.Text = "Coût: ";
                angelesN.Text = "Anges";
                aCosteT.Text = "Coût: ";
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

            if (!string.IsNullOrWhiteSpace(a.idioma))
            {
                Idiomas = a.idioma;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int newD = int.Parse(dNumber.Text);
            dNumber.Text = (newD + 1).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int newArq = int.Parse(arqNumber.Text);
            arqNumber.Text = (newArq-1).ToString();
        }
        private void StoreButton1_onClick(object sender, RoutedEventArgs e)
        {
            if (int.Parse(oro.Text) >= 100)
            {
                int newOro = int.Parse(oro.Text) - 100;
                oro.Text = Convert.ToString(newOro);

                int newMadera = int.Parse(madera.Text) + 1;
                madera.Text = Convert.ToString(newMadera);
                if (newOro < 100)
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
        private void EnterResources(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Collapsed;
            resourcesGrid.Visibility = Visibility.Visible;
        }
        private void EnterTroops(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Collapsed;
            troopsGrid.Visibility = Visibility.Visible;
        }
        private void EnterWindmill(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Collapsed;
            windmillGrid.Visibility = Visibility.Visible;
        }
        private void EnterBarracks(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Collapsed;
            barracksGrid.Visibility = Visibility.Visible;
        }
        private void OroUp(object sender, RoutedEventArgs e)
        {
            int newOro = int.Parse(mOroProdNumb.Text) + 150;
            mOroProdNumb.Text = newOro.ToString();
            oroPN.Text = newOro.ToString();
            int newNiv = int.Parse(mOroProdNivNumb.Text) + 1;
            mOroProdNivNumb.Text = newNiv.ToString();
        }
        private void MadUp(object sender, RoutedEventArgs e)
        {
            int newMad = int.Parse(mMadProdNumb.Text) + 7;
            mMadProdNumb.Text = newMad.ToString();
            madPN.Text = newMad.ToString();
            int newNiv = int.Parse(mMadProdNivNumb.Text) + 1;
            mMadProdNivNumb.Text = newNiv.ToString();
        }
        private void PiedUp(object sender, RoutedEventArgs e)
        {
            int newPied = int.Parse(mPiedProdNumb.Text) + 7;
            mPiedProdNumb.Text = newPied.ToString();
            piedPN.Text = newPied.ToString();
            int newNiv = int.Parse(mPiedProdNivNumb.Text) + 1;
            mPiedProdNivNumb.Text = newNiv.ToString();
        }
        private void MinUp(object sender, RoutedEventArgs e)
        {
            int newMin = int.Parse(mMinProdNumb.Text) + 2;
            mMinProdNumb.Text = newMin.ToString();
            minPN.Text = newMin.ToString();
            int newNiv = int.Parse(mMinProdNivNumb.Text) + 1;
            mMinProdNivNumb.Text = newNiv.ToString();
        }
        private void ReclGuerreros(object sender, RoutedEventArgs e)
        {
            int newG = int.Parse(gNumber.Text) + 1;
            gNumber.Text = newG.ToString();
            int newOro = int.Parse(oro.Text) - int.Parse(gCoste.Text);
            oro.Text = newOro.ToString();
            CheckResources();
        }
        private void ReclArqueros(object sender, RoutedEventArgs e)
        {
            int newA = int.Parse(arqNumber.Text) + 1;
            arqNumber.Text = newA.ToString();
            int newOro = int.Parse(oro.Text) - int.Parse(arqCoste.Text);
            oro.Text = newOro.ToString();
            CheckResources();

        }
        private void ReclPiqueros(object sender, RoutedEventArgs e)
        {
            int newP = int.Parse(pNumber.Text) + 1;
            pNumber.Text = newP.ToString();
            int newOro = int.Parse(oro.Text) - int.Parse(pCoste1.Text);
            oro.Text = newOro.ToString();
            int newPied = int.Parse(piedra.Text) - int.Parse(pCoste2.Text);
            piedra.Text = newPied.ToString();
            CheckResources();
        }
        private void ReclCaballeros(object sender, RoutedEventArgs e)
        {
            int newC = int.Parse(cNumber.Text) + 1;
            cNumber.Text = newC.ToString();
            int newOro = int.Parse(oro.Text) - int.Parse(cCoste1.Text);
            oro.Text = newOro.ToString();
            int newMad = int.Parse(madera.Text) - int.Parse(cCoste2.Text);
            madera.Text = newMad.ToString();
            CheckResources();

        }
        private void ReclTemplarios(object sender, RoutedEventArgs e)
        {
            int newT = int.Parse(tNumber.Text) + 1;
            tNumber.Text = newT.ToString();
            int newOro = int.Parse(oro.Text) - int.Parse(tCoste1.Text);
            oro.Text = newOro.ToString();
            int newMad = int.Parse(madera.Text) - int.Parse(tCoste2.Text);
            madera.Text = newMad.ToString();
            int newPied = int.Parse(piedra.Text) - int.Parse(tCoste3.Text);
            piedra.Text = newPied.ToString();
            CheckResources();
        }
        private void ReclDragones(object sender, RoutedEventArgs e)
        {
            int newD = int.Parse(dNumber.Text) + 1;
            dNumber.Text = newD.ToString();
            int newOro = int.Parse(oro.Text) - int.Parse(dCoste1.Text);
            oro.Text = newOro.ToString();
            int newMad = int.Parse(madera.Text) - int.Parse(dCoste2.Text);
            madera.Text = newMad.ToString();
            int newPied = int.Parse(piedra.Text) - int.Parse(dCoste3.Text);
            piedra.Text = newPied.ToString();
            CheckResources();
        }
        private void ReclAngeles(object sender, RoutedEventArgs e)
        {
            int newA = int.Parse(aNumber.Text) + 1;
            aNumber.Text = newA.ToString();
            int newOro = int.Parse(oro.Text) - int.Parse(aCoste1.Text);
            oro.Text = newOro.ToString();
            int newMad = int.Parse(madera.Text) - int.Parse(aCoste2.Text);
            madera.Text = newMad.ToString();
            int newPied = int.Parse(piedra.Text) - int.Parse(aCoste3.Text);
            piedra.Text = newPied.ToString();
            int newMin = int.Parse(mineral.Text) - int.Parse(aCoste4.Text);
            mineral.Text = newPied.ToString();
            CheckResources();
        }
        private void CheckResources()
        {
            if (int.Parse(oro.Text) < int.Parse(arqCoste.Text))
            {
                arqButton.IsEnabled = false;
            }
            if (int.Parse(oro.Text) < int.Parse(gCoste.Text))
            {
                guerButton.IsEnabled = false;
            }
            if (int.Parse(oro.Text) < int.Parse(pCoste1.Text) || int.Parse(piedra.Text) < int.Parse(pCoste2.Text))
            {
                piqButton.IsEnabled = false;
            }
            if (int.Parse(oro.Text) < int.Parse(cCoste1.Text) || int.Parse(madera.Text) < int.Parse(cCoste2.Text))
            {
                cabButton.IsEnabled = false;
            }
            if (int.Parse(oro.Text) < int.Parse(tCoste1.Text) || int.Parse(madera.Text) < int.Parse(tCoste2.Text) || int.Parse(piedra.Text) < int.Parse(tCoste3.Text))
            {
                tempButton.IsEnabled = false;
            }
            if (int.Parse(oro.Text) < int.Parse(dCoste1.Text) || int.Parse(madera.Text) < int.Parse(dCoste2.Text) || int.Parse(piedra.Text) < int.Parse(dCoste3.Text))
            {
                dragButton.IsEnabled = false;
            }
            if (int.Parse(oro.Text) < int.Parse(aCoste1.Text) || int.Parse(madera.Text) < int.Parse(aCoste2.Text) || int.Parse(piedra.Text) < int.Parse(aCoste3.Text) || int.Parse(mineral.Text) < int.Parse(aCoste4.Text))
            {
                angButton.IsEnabled = false;
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

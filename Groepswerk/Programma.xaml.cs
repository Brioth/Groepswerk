﻿using System;
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

namespace Groepswerk
{
    /* --Programma--
     * MainWindow voor de hele toepassing
     * In het frame wordt de gekozen page weergegeven
     * In XAML de menuItems toevoegen en in code deze al dan niet zichtbaar maken afhankelijk of de gebruiker lln of lk is
     * In Code ook de click_events voor de menuItems
     * Programma heeft ook een actieve gebruiker propertie, deze wordt weergegeven in de titelbalk
     * Author: Carmen Celen
     * Date: 27/03/2015
     */
    public partial class Programma : Window
    {
        //Lokale variabelen
        private Gebruiker actieveGebruiker;

        //Constructors
        public Programma()
        {
            InitializeComponent();
            programma.WindowState = WindowState.Maximized;
            Login login = new Login();
            framePages.Navigate(login);
            maakMenuLeeg();
        }

        //Events
        private void MnuStop_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult stoppen = MessageBox.Show("Ben je zeker dat je wilt stoppen?", "Stop", MessageBoxButton.YesNo);
            switch (stoppen)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    Application.Current.Shutdown();
                    break;
                default:
                    break;
            }
        }
        private void MnuHome_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult home = MessageBox.Show("Wil je terug naar het login scherm gaan?", "Home", MessageBoxButton.YesNo);
            switch (home)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    Login login = new Login();
                    framePages.Navigate(login);
                    this.ActieveGebruiker = null; //uitloggen
                    break;
                default:
                    break;
            }
        }
        //aanpassen oefeningen
        private void MnuRekenen_Click(object sender, RoutedEventArgs e)
        {
            //Vincent
        }

        //Author: Thomas Cox
        //Date: 22/04/2015
        private void MnuTaalMakkelijk_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1Makkelijk oefNederlandsMakkelijk = new OefNederlands1Makkelijk();
            framePages.Navigate(oefNederlandsMakkelijk);
        }
        private void MnuTaalGemiddeld_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1Gemiddeld oefNederlandsGemiddeld = new OefNederlands1Gemiddeld();
            framePages.Navigate(oefNederlandsGemiddeld);
        }
        private void MnuTaalMoeilijk_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1Moeilijk oefNederlandsMoeilijk = new OefNederlands1Moeilijk();
            framePages.Navigate(oefNederlandsMoeilijk);
        }
        //Author: Seppe
        private void MnuWO_Click(object sender, RoutedEventArgs e)
        {
            //Seppe
        }

        //aanpassen oefening
        //Author: Thomas Cox
        //Date: 22/04/2015
        private void MnuBewerkenMakkelijk_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1AanpassenMakkelijk oefNederlandsAanpassenMakkelijk = new OefNederlands1AanpassenMakkelijk();
            framePages.Navigate("OefNederlands1AanpassenMakkelijk");
        }
        private void MnuBewerkenGemiddeld_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1AanpassenGemiddeld oefNederlandsAanpassenGemiddeld = new OefNederlands1AanpassenGemiddeld();
            framePages.Navigate(oefNederlandsAanpassenGemiddeld);
        }
        private void MnuBewerkenMoeilijk_Click(object sender, RoutedEventArgs e)
        {
            OefNederlands1AanpassenMoeilijk nederlandsOefAanpassenMoeilijk = new OefNederlands1AanpassenMoeilijk();
            framePages.Navigate(nederlandsOefAanpassenMoeilijk);
        }

        private void MnuIndOv_Click(object sender, RoutedEventArgs e)
        {
            Gebruikerdetails detailsMenu = new Gebruikerdetails(ActieveGebruiker);
            framePages.Navigate(detailsMenu);
        }
        private void MnuKlasOver_Click(object sender, RoutedEventArgs e)
        {
            GemiddeldesKlas klasGemMenu = new GemiddeldesKlas();
            framePages.Navigate(klasGemMenu);
        }
        private void MnuNieuweGebr_Click(object sender, RoutedEventArgs e)
        {
            NieuweGebruiker nieuweGebruikerMenu = new NieuweGebruiker();
            framePages.Navigate(nieuweGebruikerMenu);
        }
        private void MnuAccBewerk_Click(object sender, RoutedEventArgs e)
        {
            AccountBeheer accountBeheerMenu = new AccountBeheer(ActieveGebruiker);
            framePages.Navigate(accountBeheerMenu);
        }
        private void MnuKlaslijstBewerk_Click(object sender, RoutedEventArgs e)
        {
            BewerkKlasLijst bewerkKlasMenu = new BewerkKlasLijst();
            framePages.Navigate(bewerkKlasMenu);
        }

        //Methods
        private void pasBalkAan() //hier beschikbaarheid menu's aanpassen
        {
            if (ActieveGebruiker != null)
            {
                switch (ActieveGebruiker.Type)
                {
                    case "lln":
                        maakMenuLeeg();
                        mnuAcc.Visibility = Visibility.Collapsed;
                        mnuOefBew.Visibility = Visibility.Collapsed;
                        mnuOefeningen.Visibility = Visibility.Visible;
                        mnuStat.Visibility = Visibility.Collapsed;
                        break;
                    case "lk":
                        maakMenuLeeg();
                        mnuAcc.Visibility = Visibility.Visible;
                        mnuOefBew.Visibility = Visibility.Visible;
                        mnuOefeningen.Visibility = Visibility.Collapsed;
                        mnuStat.Visibility = Visibility.Visible;
                        break;
                    default:
                        maakMenuLeeg();
                        break;
                }
            }
            else
            {
                maakMenuLeeg();
            }
        }
        private void maakMenuLeeg() //Standaard menu zonder gebruiker
        {
            mnuBasis.Visibility = Visibility.Visible;
            mnuAcc.Visibility = Visibility.Collapsed;
            mnuOefBew.Visibility = Visibility.Collapsed;
            mnuOefeningen.Visibility = Visibility.Collapsed;
            mnuStat.Visibility = Visibility.Collapsed;
        }

        //Properties
        public Gebruiker ActieveGebruiker
        {
            get
            {
                return actieveGebruiker;
            }
            set
            {
                actieveGebruiker = value;
                this.Title = Convert.ToString(ActieveGebruiker);
                pasBalkAan();
            }
        }

        
    }
}

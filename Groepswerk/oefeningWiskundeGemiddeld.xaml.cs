﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Groepswerk
{
    //Author: Vincent Vandoninck
    //Date: 03/05/2015

    // Random getallen genereren en deze uitrekenen. De uitkomst hiervan opslaan in een lijst.
    // Deze lijst vergelijken met de ingevoerde antwoorden van de gebruiker en het aantal juiste antwoorden weergeven als punten.
    // 

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class oefeningWiskundeGemiddeld : Page
    {
        //Lokale variabelen
        Gebruiker actieveGebruiker;
        private int oefeningPunten;
        private Random RandomTest = new Random();
        private int randomGetal1, randomGetal2, randomGetal3;
        private int randomTeken1;
        private String[] OpgaveLijst = new String[10];
        private int[] oplossingLijst = new int[10];
        private List<int> randomLijst = new List<int>();
        private int begin, eind;
        private int totaalTijd;
        private Stopwatch tijdTeller;
        private string moeilijkheidsgraad = "MED";
        //private List<String> ranges = new List<String>;
        //constructors

        public oefeningWiskundeGemiddeld(Gebruiker actieveGebruiker)
        {
           
            InitializeComponent();
            this.actieveGebruiker = actieveGebruiker;
            tijdTeller = new Stopwatch();
            tijdTeller.Start();
            // of 2 random getallen tss 10 laten maken en die uitkomst ervan laten berekenen en opslaan in lijst (txt bestand)
            // lijst vergelijken met de user input

            VulRanges();

            for (int i = 0; i < 10; i++)
            {
                randomGetal1 = RandomTest.Next(begin, eind +1);
                randomGetal2 = RandomTest.Next(begin, eind +1);
                randomGetal3 = RandomTest.Next(begin, eind +1);
                randomTeken1 = RandomTest.Next(0, 2);

                // eerst uitkomst berekenen en die opslaan in labels
                // uitkomst ingeven als gebruiker en testen met verbeterknop

                if (randomTeken1 == 1)
                {
                    oplossingLijst[i] = randomGetal1 * randomGetal2 + randomGetal3;
                    randomLijst.Add(oplossingLijst[i]);


                    OpgaveLijst[i] = (randomGetal1.ToString() + " x " + (randomGetal2.ToString()) + " + " + (randomGetal3.ToString()));

                }
                else
                {
                    oplossingLijst[i] = randomGetal1 * randomGetal2 - randomGetal3;
                    randomLijst.Add(oplossingLijst[i]);

                    OpgaveLijst[i] = (randomGetal1.ToString() + " x " + (randomGetal2.ToString()) + " - " + randomGetal3.ToString());
                }

                opgaveblock1.Content = OpgaveLijst[0];
                opgaveblock2.Content = OpgaveLijst[1];
                opgaveblock3.Content = OpgaveLijst[2];
                opgaveblock4.Content = OpgaveLijst[3];
                opgaveblock5.Content = OpgaveLijst[4];
                opgaveblock6.Content = OpgaveLijst[5];
                opgaveblock7.Content = OpgaveLijst[6];
                opgaveblock8.Content = OpgaveLijst[7];
                opgaveblock9.Content = OpgaveLijst[8];
                opgaveblock10.Content = OpgaveLijst[9];
            }
        }
        //methodes

        private void VulRanges()
        {
            StreamReader reader = File.OpenText(@"rangesWiskunde.txt");
            string gelezen = reader.ReadLine();
            char[] scheiding = { ';' };

            while (gelezen != null)
            {
                string[] deel = gelezen.Split(scheiding);
                if (deel[0].Equals("gemiddeld"))
                {
                    begin = Convert.ToInt32( deel[1]);
                    eind = Convert.ToInt32(deel[2]);
            }
                gelezen = reader.ReadLine();
            }
            reader.Close();
        }

        private void schrijfpunten()
        {
            ResultatenLijst lijst = new ResultatenLijst("OefResultatenWiskGem.txt");
            Resultaat behaaldResultaat = new Resultaat(actieveGebruiker.Id, oefeningPunten, totaalTijd, lijst);

            if (behaaldResultaat.IndexOud == -1)
            {
                lijst.Add(behaaldResultaat);
            }
            else
            {
                lijst.Add(behaaldResultaat);
                lijst.RemoveAt(behaaldResultaat.IndexOud);
            }
            lijst.SchrijfLijst("OefResultatenWiskGem.txt");
        }

        //author: Vincent Vandoninck
        //date: 28/04/2015

        //events
        private void verbeterButton_Click(object sender, RoutedEventArgs e)
        {
            oefeningPunten = 0;
            tijdTeller.Stop();
            totaalTijd = Convert.ToInt32(tijdTeller.ElapsedMilliseconds / 1000);
            {
                try
                {
                    if ((oplossingLijst[0]).Equals(dropLabel1.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel1.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel1.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[1]).Equals(dropLabel2.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel2.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel2.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[2]).Equals(dropLabel3.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel3.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel3.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[3]).Equals(dropLabel4.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel4.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel4.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[4]).Equals(dropLabel5.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel5.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel5.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[5]).Equals(dropLabel6.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel6.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel6.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[6]).Equals(dropLabel7.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel7.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel7.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[7]).Equals(dropLabel8.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel8.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel8.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[8]).Equals(dropLabel9.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel9.Background = Brushes.Green;
                    }

                    else
                    {
                        dropLabel9.Background = Brushes.Red;
                    }
                    if ((oplossingLijst[9]).Equals(dropLabel10.Text.Trim()))
                    {
                        oefeningPunten++;
                        dropLabel10.Background = Brushes.Green;
                    }
                    else
                    {
                        dropLabel10.Background = Brushes.Red;
                    }
                    Punten.Text = ("u heeft  " + oefeningPunten + " punten behaald. ");
                    schrijfpunten();
                 
                    verbeterButton.IsEnabled = false;
                    AlleGebruikersLijst lijst = new AlleGebruikersLijst();
                     foreach (Gebruiker item in lijst)
                      {
                        if (actieveGebruiker.Id.Equals(item.Id))
                        {
                           item.SetGameTijd(oefeningPunten , moeilijkheidsgraad);
                        }
                      }
                    lijst.SchrijfLijst();
                     
                }
                   

                catch (FormatException)
                {
                    MessageBox.Show("zet 0 als je het antwoord niet weet");
                }
            }
        }
        private void terugButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult terug = MessageBox.Show("Ben je zeker dat je terug wilt naar het leerlingenmenu?", "Terug", MessageBoxButton.YesNo);
            switch (terug)
            {
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    LeerlingMenu terugMenu = new LeerlingMenu(actieveGebruiker);
                this.NavigationService.Navigate(terugMenu);
                    break;
                default:
                    break;
            }
        }
        private void opnieuwButton_Click(object sender, RoutedEventArgs e)
        {
            oefeningWiskundeGemiddeld oefWiskundeGemiddeldPagina = new oefeningWiskundeGemiddeld(actieveGebruiker);
            this.NavigationService.Navigate(oefWiskundeGemiddeldPagina);
        }
    }
}

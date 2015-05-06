﻿using System;
using System.Collections.Generic;
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
    // Author: Thomas Cox
    // Date: 19/04/2015
    public partial class OefNederlands1AanpassenGemiddeld : Page
    {
        private OefeningLijst lijstOefeningen;
        private IList<string> opgaves, oplossing1, oplossing2, oplossing3, correcteOplossing;
        private int geselecteerdeIndex;
        private Gebruiker actieveGebruiker;
        public OefNederlands1AanpassenGemiddeld(Gebruiker actieveGebruiker)
        {
            InitializeComponent();
            this.actieveGebruiker = actieveGebruiker;
            lijstOefeningen = new OefeningLijst("gemiddeld");
            for (int i = 0; i < lijstOefeningen.Count; i++)
            {
                opgaves.Add(lijstOefeningen[i].opgave);
                oplossing1.Add(lijstOefeningen[i].oplossing1);
                oplossing2.Add(lijstOefeningen[i].oplossing2);
                oplossing3.Add(lijstOefeningen[i].oplossing3);
                correcteOplossing.Add(lijstOefeningen[i].correcteOplossing);
            }
            OpgaveSelecteren.ItemsSource = opgaves;
        }
        private void OpgaveSelecteren_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            geselecteerdeIndex = OpgaveSelecteren.SelectedIndex;
            Opgave.Text = opgaves[geselecteerdeIndex];
            Oplossing1.Text = oplossing1[geselecteerdeIndex];
            Oplossing2.Text = oplossing2[geselecteerdeIndex];
            Oplossing3.Text = oplossing3[geselecteerdeIndex];
            CorrecteOplossing.Text = correcteOplossing[geselecteerdeIndex];
        }

        private void AanpasKnop_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"OefNederlands1Gemiddeld.txt", String.Empty);
            StreamWriter writer = File.AppendText(@"OefNederlands1Gemiddeld.txt");
            foreach (Oefening oef in lijstOefeningen)
            {

                writer.WriteLine(oef.opgave + ";" + oef.oplossing1 + ";" + oef.oplossing2 + ";" + oef.oplossing3 + ";" + oef.correcteOplossing);
            }
            writer.Close();
        }

        
    }
}

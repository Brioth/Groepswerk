﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Groepswerk
{
    /* --AlleGebruikersLijst--
     * Klasse van alle gebruikers in 1 lijst
     * Methode SchrijfLijst() om (aangepaste) lijst naar txtbestand te schrijven
     * Author: Carmen Celen
     * Date: 03/04/2015
     */
    public class AlleGebruikersLijst : List<Gebruiker>
    {
        //Lokale variabelen

        //Constructors
        public AlleGebruikersLijst()
        {
            try
            {
                StreamReader bestandAcc = File.OpenText(@"Accounts.txt");
                string regel = bestandAcc.ReadLine();
                char[] scheiding = { ';' };

                while (regel != null)
                {
                    string[] woorden = regel.Split(scheiding);
                    for (int i = 0; i < woorden.Length; i++)
                    {
                        woorden[i] = woorden[i].Trim();
                    }

                    Gebruiker gebruiker = new Gebruiker(woorden[0], woorden[1], Convert.ToInt32(woorden[2]), woorden[3], woorden[4], woorden[5], Convert.ToInt32(woorden[6]));
                    this.Add(gebruiker);
                    regel = bestandAcc.ReadLine();
                }
                bestandAcc.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Bestand Accounts.txt niet gevonden");
            }
        }

        //Events

        //Methods
        public void SchrijfLijst()
        {
            File.WriteAllText(@"Accounts.txt", String.Empty);
            StreamWriter schrijver = File.AppendText(@"Accounts.txt");
            foreach (Gebruiker item in this)
            {
                schrijver.WriteLine(item.SchrijfString());
            }
            schrijver.Close();
        }

        //Properties
    }
}

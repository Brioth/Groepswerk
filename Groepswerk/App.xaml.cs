﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_startup(object sender, StartupEventArgs e)
        {
            Programma programma = new Programma();
            programma.Show();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Groepswerk
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    /// 
    
    public partial class Login : Page
    {
        private Accountlijst accountLijst;
        private Klaslijst klasLijst;
        private Gebruiker selectedGebruiker;
        private string selectedKlas;
        //Constructors

        public Login()
        {
            InitializeComponent();
            klasLijst = new Klaslijst();
            boxKlas.ItemsSource = klasLijst;
            boxKlas.SelectedIndex = 0;
        }

        //Events

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            loginHandler();

        }

        private void pswBox_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                loginHandler();
            }
        }

        private void boxKlas_Changed(object sender, SelectionChangedEventArgs e)
        {
           selectedKlas =Convert.ToString(boxKlas.SelectedItem);
            if (accountLijst != null)
            {
                accountLijst.Clear();
            }
            accountLijst = new Accountlijst(selectedKlas);
            boxLogin.ItemsSource = accountLijst;
            boxLogin.SelectedIndex = 0;
        }


        //Methods
        //public static class StringCipher
        //{
        //    //encrypteren van het wachtwoord
        //    private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

        //    // This constant is used to determine the keysize of the encryption algorithm.
        //    private const int keysize = 256;
        //    public static string Encrypt(string plainText, string passPhrase)
        //    {
        //        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        //        using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
        //        {
        //            byte[] keyBytes = password.GetBytes(keysize / 8);
        //            using (RijndaelManaged symmetricKey = new RijndaelManaged())
        //            {
        //                symmetricKey.Mode = CipherMode.CBC;
        //                using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
        //                {
        //                    using (MemoryStream memoryStream = new MemoryStream())
        //                    {
        //                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        //                        {
        //                            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
        //                            cryptoStream.FlushFinalBlock();
        //                            byte[] cipherTextBytes = memoryStream.ToArray();
        //                            return Convert.ToBase64String(cipherTextBytes);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        private void loginHandler()
        {

            selectedGebruiker = (Gebruiker)boxLogin.SelectedItem;
           
            bool pswOk = checkPsw(selectedGebruiker);
            

            if (pswOk == true)
            {
                Programma basisScherm = (Programma)Application.Current.MainWindow;
                basisScherm.ActieveGebruiker = selectedGebruiker;

                if (selectedGebruiker.Type.Equals("lk"))
                {
                    GemiddeldesKlas gemKlasMenu = new GemiddeldesKlas();
                    this.NavigationService.Navigate(gemKlasMenu);
                }
                else
                {
                    LeerlingMenu llnMenu = new LeerlingMenu(selectedGebruiker);
                    this.NavigationService.Navigate(llnMenu);
                }
            }
            else
            {
                MessageBox.Show("Het wachtwoord is foutief", "Foutief wachtwoord", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private bool checkPsw(Gebruiker selectedGebruiker)
        {
            string gok = pswBox.Password;
           // string plaintext = "encryptie";
           // string encryptedstring = StringCipher.Encrypt(plaintext, gok);
           // MessageBox.Show(encryptedstring);
           if (selectedGebruiker.Psw.Equals(gok))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Properties
    }
}

using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RSA_Algorithm_App.Utility;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace RSA_Algorithm_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Algorithm rsa = new Algorithm();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            rsa.N = rsa.CalculateN(Convert.ToInt32(insertNumberP.Text), Convert.ToInt32(insertNumberQ.Text));
            rsa.Phi = rsa.CalculatePhi(Convert.ToInt32(insertNumberP.Text), Convert.ToInt32(insertNumberQ.Text));
            rsa.E = rsa.CalculateE(rsa.Phi, rsa.N);

            MessageBox.Show(rsa.E.ToString());
            decryptTextBox.Text = rsa.Encrypt(encryptTextBox.Text, rsa.E, rsa.N);
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
           
            rsa.D = rsa.ModuloInverse(rsa.E, rsa.Phi);

            encryptTextBox.Text = rsa.Decrypt(decryptTextBox.Text, rsa.D, rsa.N);
        }
    }
}

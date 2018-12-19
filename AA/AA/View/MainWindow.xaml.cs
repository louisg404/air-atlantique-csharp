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
using MySql.Data.MySqlClient;

namespace AA
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new View.HOME();
        }

        //Accueil
        private void Button_Click_HOME(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.HOME();
        }

        //Avions
        private void Button_Click_avions(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.Avions();
        }
        private void Button_Click_Insert_Avion(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.InsertAvion();
        }

        //Vols
        private void Button_Click_vols(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.Vols();
        }
        private void Button_Click_Insert_Vol(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.InsertVol();
        }

        //Aeroports
        private void Button_Click_aeroports(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.Aeroports();
        }
        private void Button_Click_Insert_Aeroport(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.InsertAeroport();
        }

        //Clients
        private void Button_Click_clients(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.Client();
        }

        //Déconnexion
        private void Button_Click_Deco(object sender, RoutedEventArgs e)
        {

            View.connexion_inscription co_inscr = new View.connexion_inscription();
            co_inscr.Show();
            this.Close();
        }
    }
   
}

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
using System.Windows.Shapes;

namespace AA.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindowClient.xaml
    /// </summary>
    public partial class MainWindowClient : Window
    {
        public MainWindowClient()
        {
            InitializeComponent();
            MainClient.Content = new View.HOME();
        }
        //Accueil
        private void Button_Click_HOME(object sender, RoutedEventArgs e)
        {
            MainClient.Content = new View.HOME();
        }

            
        //Vols
        private void Button_Click_vols(object sender, RoutedEventArgs e)
        {
            MainClient.Content = new View.Vols();
        }
       
        //Aeroports
        private void Button_Click_aeroports(object sender, RoutedEventArgs e)
        {
            MainClient.Content = new View.Aeroports();
        }
       
        //Déconnexion
        private void Button_Click_Deco(object sender, RoutedEventArgs e)
        {
            connexion_inscription co_inscr = new connexion_inscription();
            co_inscr.Show();
            this.Close();
        }
    }
}

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
using System.Collections.ObjectModel;

namespace AA.View
{
    /// <summary>
    /// Logique d'interaction pour Inscription.xaml
    /// </summary>
    public partial class Inscription : Window
    {
        public Inscription()
        {
            InitializeComponent();
        }
        private void Button_Click_Insert_Client(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ViewModel.ClientBinder> UserExist = new ObservableCollection<ViewModel.ClientBinder>();
            Model.DAL.DALClient bdd = new Model.DAL.DALClient();
            bdd.AddClient(UserExist, nom.Text, prenom.Text, pseudo.Text, mail.Text, password.Text);

            if (UserExist.Count() != 0)
            {
                MessageBox.Show("Pseudo ou mail existe déjà");

            }
            else
            {
                nom.Clear();
                prenom.Clear();
                pseudo.Clear();
                mail.Clear();
                password.Clear();
                View.connexion_inscription co = new View.connexion_inscription();
                co.Show();
                this.Close();
            }
        }  
            private void Button_Click_Retour(object sender, RoutedEventArgs e)
            {
            View.connexion_inscription co = new View.connexion_inscription();
            co.Show();
            this.Close();
        }
        
    }
}

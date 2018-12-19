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
using System.Collections.ObjectModel;
namespace AA.View
{
    /// <summary>
    /// Logique d'interaction pour inscription.xaml
    /// </summary>
    public partial class connexion_inscription : Window
    {
        public connexion_inscription()
        {
            InitializeComponent();
        }
        private void Button_Click_Connect(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ViewModel.ClientBinder> Actifclients = new ObservableCollection<ViewModel.ClientBinder>();
            ObservableCollection<ViewModel.ClientBinder> Actifadmin = new ObservableCollection<ViewModel.ClientBinder>();
            Model.DAL.DALClient bdd = new Model.DAL.DALClient();
            bdd.getClient(Actifclients,Actifadmin,pseudo.Text, password.Password);

            if(Actifclients.Count() == 0)
            {
                if (Actifadmin.Count == 0)
                {
                    MessageBox.Show("Erreur d'identification");
                }
                else
                {
                    MainWindow main = new MainWindow();
                    // Show window modelessly
                    // NOTE: Returns without waiting for window to close
                    main.Show();
                    this.Close();
                }
            }else if (Actifclients.Count() == 0)
            {
                MessageBox.Show("Erreur d'identification client");

            }
            else
            {
                MainWindowClient mainclient = new MainWindowClient();
                // Show window modelessly
                // NOTE: Returns without waiting for window to close
                mainclient.Show();
                this.Close();
            }

        }
        private void Button_Click_Inscriptioon(object sender, RoutedEventArgs e)
        {
            View.Inscription insrc = new View.Inscription();
            // Show window modelessly
            // NOTE: Returns without waiting for window to close
            insrc.Show();
            this.Close();
        }

        public void quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

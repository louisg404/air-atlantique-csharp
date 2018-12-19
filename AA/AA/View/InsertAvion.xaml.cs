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

namespace AA.View
{
    /// <summary>
    /// Logique d'interaction pour InsertAvion.xaml
    /// </summary>
    public partial class InsertAvion 
    {
        public InsertAvion()
        {
            InitializeComponent();
        }
        private void Button_Click_Insert_Avion(object sender, RoutedEventArgs e)
        {
            Model.DAL.DALAvion bdd = new Model.DAL.DALAvion();
            bdd.AddAvion(matricule.Text,motorisation.Text,type.Text,Convert.ToInt32(capacite.Text),Convert.ToInt32(premiere.Text), Convert.ToInt32(business.Text),Convert.ToInt32(premium.Text),Convert.ToInt32(economique.Text));
            matricule.Clear();
            motorisation.Clear();
            type.Clear();
            capacite.Clear();
            premiere.Clear();
            business.Clear();
            premium.Clear();
            economique.Clear();
        }
    }
}

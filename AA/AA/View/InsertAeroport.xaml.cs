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
    /// Logique d'interaction pour InsertAeroport.xaml
    /// </summary>
    public partial class InsertAeroport 
    {
        public InsertAeroport()
        {
            InitializeComponent();
        }
        private void Button_Click_Insert_Aeroport(object sender, RoutedEventArgs e)
        {
            Model.DAL.DALAeroport bdd = new Model.DAL.DALAeroport();
            bdd.AddAeroport(libelle.Text, aita.Text, ville.Text, pays.Text);

            libelle.Clear();
            aita.Clear();
            ville.Clear();
            pays.Clear();
        }
    }
}

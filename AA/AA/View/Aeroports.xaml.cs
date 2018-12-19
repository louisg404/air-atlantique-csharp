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
using System.Data;
using System.Collections.ObjectModel;

namespace AA.View
{
    /// <summary>
    /// Logique d'interaction pour Aeroports.xaml
    /// </summary>
    public partial class Aeroports : Page
    {
       
        ObservableCollection<ViewModel.AeroportBinder> listeaeroports = new ObservableCollection<ViewModel.AeroportBinder>();
        public Aeroports()
        {
            InitializeComponent();
            Model.DAL.DALAeroport bdd = new Model.DAL.DALAeroport();
            
            bdd.SelectAeroport(listeaeroports);
            dataGrid1.ItemsSource = listeaeroports;
        }
    }
}

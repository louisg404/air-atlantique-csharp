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
    /// Logique d'interaction pour Avions.xaml
    /// </summary>
    public partial class Avions : Page
    {
       
        ObservableCollection<ViewModel.AvionBinder> listeavions = new ObservableCollection<ViewModel.AvionBinder>();
        public Avions()
        {
            InitializeComponent();
            Model.DAL.DALAvion bdd = new Model.DAL.DALAvion();            
            bdd.SelectAvions(listeavions);
            dataGrid1.ItemsSource = listeavions;
        }
    }
}

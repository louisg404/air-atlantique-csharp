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
    public partial class Vols : Page
    {
       
        ObservableCollection<ViewModel.VolBinder> listevols = new ObservableCollection<ViewModel.VolBinder>();
        public Vols()
        {
            InitializeComponent();
            Model.DAL.DALVol bdd = new Model.DAL.DALVol();
            
            bdd.SelectVol(listevols);
            dataGrid1.ItemsSource = listevols;
        }
    }
}

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
    /// Logique d'interaction pour Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        ObservableCollection<ViewModel.ClientBinder> listeclients = new ObservableCollection<ViewModel.ClientBinder>();
        public Client()
        {
            InitializeComponent();
            Model.DAL.DALClient bdd = new Model.DAL.DALClient();

            bdd.SelectClient(listeclients);
            dataGrid1.ItemsSource = listeclients;
        }
    }
}

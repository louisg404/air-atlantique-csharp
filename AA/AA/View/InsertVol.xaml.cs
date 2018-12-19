using RoyT.TimePicker;
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
    /// Logique d'interaction pour InsertAvion.xaml
    /// </summary>
    public partial class InsertVol
    {
        public InsertVol()
        {
            ObservableCollection<ViewModel.AvionBinder> listeavions = new ObservableCollection<ViewModel.AvionBinder>();
            InitializeComponent();
            Model.DAL.DALAvion bdd = new Model.DAL.DALAvion();

            bdd.SelectAvions(listeavions);
            avion.ItemsSource = listeavions;
        }
        private void Button_Click_Insert_Vol(object sender, RoutedEventArgs e)
        {
            Model.DAL.DALVol bdd = new Model.DAL.DALVol();
            ViewModel.AvionBinder matricule = avion.SelectedItem as ViewModel.AvionBinder;


            //Convertir la date DD/MM/YYYY en YYYY-MM-DD
            string sdateD = dateD.Text;
            string[] depart = sdateD.Split('/');
            string dayD = depart[0];
            string monthD = depart[1];
            string yearD = depart[2];
            string dateDepart = yearD + "-" + monthD + "-" + dayD;

            string sdateA = dateA.Text;
            string[] arrivee = sdateA.Split('/');
            string dayA = arrivee[0];
            string monthA = arrivee[1];
            string yearA = arrivee[2];
            string dateArrivee = yearA + "-" + monthA + "-" + dayA;

            DigitalTime a = heureA.Time;
            int ha = a.Hour;
            int ma = a.Minute;
            string dateHeureA = dateArrivee + " " + ha + ":" + ma;

            DigitalTime d = heureD.Time;
            int hd = d.Hour;
            int md = d.Minute;
            string dateHeureD = dateDepart + " " + hd + ":" + md;

            bdd.AddVol(dateHeureA, dateHeureD, lieuA.Text, lieuD.Text, Convert.ToInt32(nbPassager.Text), matricule.IdProperty);

            lieuA.Clear();
            lieuD.Clear();
            nbPassager.Clear();
        }
        private void avion_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}

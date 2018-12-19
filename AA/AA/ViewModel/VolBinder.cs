using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace AA.ViewModel
{
    public class VolBinder : INotifyPropertyChanged
    {
        private int id;
        private string dateHeureA;
        private string dateHeureD;
        private int annule;
        private string lieuA;
        private string lieuD;
        private int nbPassager;
        private ViewModel.AvionBinder avion;

        public int IdProperty
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("IdProperty");
            }
        }

        public string DateHeureAProperty
        {
            get { return dateHeureA; }
            set
            {
                dateHeureA = value;
                OnPropertyChanged("dateHeureAProperty");
            }
        }

        public string DateHeureDProperty
        {
            get { return dateHeureD; }
            set
            {
                dateHeureD = value;
                OnPropertyChanged("dateHeureDProperty");
            }
        }

        public int AnnuleProperty
        {
            get { return annule; }
            set
            {
                annule = value;
                OnPropertyChanged("AnnuleProperty");
            }
        }

        public string LieuAProperty
        {
            get { return lieuA; }
            set
            {
                lieuA = value;
                OnPropertyChanged("LieuAProperty");
            }
        }

        public string LieuDProperty
        {
            get { return lieuD; }
            set
            {
                lieuD = value;
                OnPropertyChanged("LieuDProperty");
            }
        }

        public int NbPassagerProperty
        {
            get { return nbPassager; }
            set
            {
                nbPassager = value;
                OnPropertyChanged("NbPassagerProperty");
            }
        }

        public ViewModel.AvionBinder AvionProperty
        {
            get { return avion; }
            set
            {
                avion = value;
                OnPropertyChanged("AvionProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                Model.DAL.DALVol bdd = new Model.DAL.DALVol();
                bdd.UpdateVol(this);
            }
        }

        public VolBinder(int id, string dateHeureA, string dateHeureD, int annule, string lieuA, string lieuD, int nbPassager, ViewModel.AvionBinder avion)
        {
            this.IdProperty = id;
            this.DateHeureAProperty = dateHeureA;
            this.DateHeureDProperty = dateHeureD;
            this.AnnuleProperty = annule;
            this.LieuAProperty = lieuA;
            this.LieuDProperty = lieuD;
            this.NbPassagerProperty = nbPassager;
            this.AvionProperty = avion;
        }
    }
}

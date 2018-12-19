using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace AA.ViewModel
{
   public class AvionBinder : INotifyPropertyChanged
    {
        private int id;
        private string matricule;
        private string motorisation;
        private int maintenance;
        private int disponible;
        private string type;
        private int capacite;
        private int premiere;
        private int business;
        private int premium;
        private int economique;

        public int IdProperty
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("IdProperty");
            }
        }

        public string MatriculeProperty
        {
            get { return matricule; }
            set
            {
                matricule = value;
                OnPropertyChanged("MatriculeProperty");
            }
        }

        public string MotorisationProperty
        {
            get { return motorisation; }
            set
            {
                motorisation = value;
                OnPropertyChanged("MotorisationProperty");
            }
        }

        public int MaintenanceProperty
        {
            get { return maintenance; }
            set
            {
                maintenance = value;
                OnPropertyChanged("MaintenanceProperty");
            }
        }

        public int DisponibleProperty
        {
            get { return disponible; }
            set
            {
                disponible = value;
                OnPropertyChanged("DisponibleProperty");
            }
        }

        public string TypeProperty
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("TypeProperty");
            }
        }

        public int CapaciteProperty
        {
            get { return capacite; }
            set
            {
                capacite = value;
                OnPropertyChanged("CapaciteProperty");
            }
        }

        public int PremiereProperty
        {
            get { return premiere; }
            set
            {
                premiere = value;
                OnPropertyChanged("PremiereProperty");
            }
        }

        public int BusinessProperty
        {
            get { return business; }
            set
            {
                business = value;
                OnPropertyChanged("BusinessProperty");
            }
        }

        public int PremiumProperty
        {
            get { return premium; }
            set
            {
                premium = value;
                OnPropertyChanged("PremiumProperty");
            }
        }

        public int EconomiqueProperty
        {
            get { return economique; }
            set
            {
                economique = value;
                OnPropertyChanged("EconomiqueProperty");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                Model.DAL.DALAvion bdd = new Model.DAL.DALAvion();
                bdd.UpdateAvion(this);
            }
        }

        public AvionBinder(int id,string matricule, string motorisation, int maintenance, int disponible, string type, int capacite, int premiere, int business, int premium, int economique)
        {
            this.IdProperty = id;
            this.MatriculeProperty = matricule;
            this.MotorisationProperty = motorisation;
            this.MaintenanceProperty = maintenance;
            this.DisponibleProperty = disponible;
            this.TypeProperty = type;
            this.CapaciteProperty = capacite;
            this.PremiereProperty = premiere;
            this.BusinessProperty = business;
            this.PremiumProperty = premium;
            this.EconomiqueProperty = economique;
        }
    }
}

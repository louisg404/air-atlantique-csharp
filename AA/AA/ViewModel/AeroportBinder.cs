using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace AA.ViewModel
{
   public class AeroportBinder : INotifyPropertyChanged
    {
        private int id;
        private string libelle;
        private string aita;
        private string ville;
        private string pays;

        public int IdProperty
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("IdProperty");
            }
        }
        public string LibelleProperty
        {
            get { return libelle; }
            set
            {
                libelle = value;
                OnPropertyChanged("LibelleProperty");
            }
        }

        public string AitaProperty
        {
            get { return aita; }
            set
            {
                aita = value;
                OnPropertyChanged("AitaProperty");
            }
        }

        public string VilleProperty
        {
            get { return ville; }
            set
            {
                ville = value;
                OnPropertyChanged("VilleProperty");
            }
        }

        public string PaysProperty
        {
            get { return pays; }
            set
            {
                pays = value;
                OnPropertyChanged("PaysProperty");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                Model.DAL.DALAeroport bdd = new Model.DAL.DALAeroport();
                bdd.UpdateAeroport(this);
            }
        }

        public AeroportBinder(int id, string libelle, string aita, string ville, string pays)
        {
            this.IdProperty = id;
            this.LibelleProperty = libelle;
            this.AitaProperty = aita;
            this.VilleProperty = ville;
            this.PaysProperty = pays;
        }
    }
}

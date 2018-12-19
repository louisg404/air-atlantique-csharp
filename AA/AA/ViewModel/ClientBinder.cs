using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace AA.ViewModel
{
    public class ClientBinder : INotifyPropertyChanged
    {
        private int id;
        private string nom;
        private string prenom;
        private string mail;
        private string pseudo;
        private string password;
        private int admin;

        public int IdProperty
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("IdProperty");
            }
        }

        public string NomProperty
        {
            get { return nom; }
            set
            {
                nom = value;
                OnPropertyChanged("NomProperty");
            }
        }

        public string PrenomProperty
        {
            get { return prenom; }
            set
            {
                prenom = value;
                OnPropertyChanged("PrenomProperty");
            }
        }

        

        public string MailProperty
        {
            get { return mail; }
            set
            {
                mail = value;
                OnPropertyChanged("MailProperty");
            }
        }

        public string PseudoProperty
        {
            get { return pseudo; }
            set
            {
                pseudo = value;
                OnPropertyChanged("PseudoProperty");
            }
        }

        public string PasswordProperty
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("PasswordProperty");
            }
        }
        public int AdminProperty
        {
            get { return admin; }
            set
            {
                admin = value;
                OnPropertyChanged("adminProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                Model.DAL.DALClient bdd = new Model.DAL.DALClient();
                bdd.UpdateClient(this);
            }
        }

        public ClientBinder(int id, string nom, string prenom,  string mail, string pseudo, string password,int admin)
        {
            this.IdProperty = id;
            this.NomProperty = nom;
            this.PrenomProperty = prenom;
            this.MailProperty = mail;
            this.PseudoProperty = pseudo;
            this.PasswordProperty = password;
            this.AdminProperty = admin;
        }
    }
}


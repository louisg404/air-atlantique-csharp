using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.ObjectModel;

namespace AA.Model.DAL
{
    public class DALAeroport
    {
        private MySqlConnection connection;

        // Constructeur
        public DALAeroport()
        {
            
        }

        // Méthode pour initialiser la connexion
       

        public void SelectAeroport(ObservableCollection<ViewModel.AeroportBinder> listeaeroports)
        {
            try
            {
                ConnectionBdd bdd = new ConnectionBdd();
                MySqlConnection connection = bdd.getConnection();
                // Requête SQL            
                string query = "SELECT * from aeroport";
               
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string LibelleProperty = reader.GetString(1);
                    string AitaProperty = reader.GetString(2);
                    string VilleProperty = reader.GetString(3);
                    string PaysProperty = reader.GetString(4);

                    ViewModel.AeroportBinder unaeroport = new ViewModel.AeroportBinder(Id, LibelleProperty, AitaProperty, VilleProperty, PaysProperty);
                   
                    listeaeroports.Add(unaeroport);
                }

                //Fermeture de la connexion
                reader.Close();
                this.connection.Close();
               
            }
            catch
            {
                // Gestion des erreurs :
                // Possibilité de créer un Logger pour les exceptions SQL reçus
                // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
            }
        }
        // Méthode pour ajouter un aeroport
        public void AddAeroport(string libelle, string aita, string ville, string pays)
         {
             try
             {
                // Ouverture de la connexion SQL
                ConnectionBdd bdd = new ConnectionBdd();
                MySqlConnection connection = bdd.getConnection();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand cmd = connection.CreateCommand();

                 cmd.CommandText = "INSERT INTO aeroport (libelle, aita, ville, pays) VALUES (@libelle,@aita,@ville,@pays)";

                 cmd.Parameters.AddWithValue("@libelle", libelle);
                 cmd.Parameters.AddWithValue("@aita", aita);
                 cmd.Parameters.AddWithValue("@ville", ville);
                 cmd.Parameters.AddWithValue("@pays", pays);

                 // Exécution de la commande SQL
                 cmd.ExecuteNonQuery();

                 // Fermeture de la connexion
                 connection.Close();
             }
             catch (MySqlException ex)
             {
                 switch (ex.Number)
                 {
                    case 0:
                        MessageBox.Show("Impossible de se connecter au serveur");
                        break;
                    case 1045:
                        MessageBox.Show("Utilisateur ou mot de passe invalide");
                        break;
                }
                 // Gestion des erreurs :
                 // Possibilité de créer un Logger pour les exceptions SQL reçus
                 // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.

             }
         }

        public void UpdateAeroport(ViewModel.AeroportBinder a)
         {
            ConnectionBdd bdd = new ConnectionBdd();
            MySqlConnection connection = bdd.getConnection();

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE aeroport SET `libelle`=@libelle,`aita`=@aita,`ville`=@ville,`pays`=@pays WHERE id=@id";

            cmd.Parameters.AddWithValue("@libelle", a.LibelleProperty);
            cmd.Parameters.AddWithValue("@aita", a.AitaProperty);
            cmd.Parameters.AddWithValue("@ville", a.VilleProperty);
            cmd.Parameters.AddWithValue("@pays", a.PaysProperty);
            cmd.Parameters.AddWithValue("@id", a.IdProperty);
            
            cmd.ExecuteNonQuery();
        }
    }
}
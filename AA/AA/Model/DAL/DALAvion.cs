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
    public class DALAvion
    {
        
        //private MySqlConnection connection;

        // Constructeur
        public DALAvion()
        {

        }

        // Méthode pour initialiser la connexion
        public void SelectAvions(ObservableCollection<ViewModel.AvionBinder> listeavions)
        {

            try
            {
                ConnectionBdd bdd = new ConnectionBdd();
                MySqlConnection connection = bdd.getConnection();
                // Requête SQL            
                string query = "SELECT * from avion";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string MatriculeProprty = reader.GetString(1);
                    string MotorisationProperty = reader.GetString(2);
                    int MaintenanceProperty = reader.GetInt32(3);
                    int DisponibleProperty = reader.GetInt32(4);
                    string TypeProperty = reader.GetString(5);
                    int CapaciteProperty = reader.GetInt32(6);
                    int PremiereProperty = reader.GetInt32(7);
                    int BusinessProperty = reader.GetInt32(8);
                    int PremiumProperty = reader.GetInt32(9);
                    int EconomiqueProperty = reader.GetInt32(10);
                    ViewModel.AvionBinder unavion = new ViewModel.AvionBinder(Id,MatriculeProprty, MotorisationProperty, MaintenanceProperty, DisponibleProperty, TypeProperty, CapaciteProperty, PremiereProperty, BusinessProperty, PremiumProperty, EconomiqueProperty);

                    listeavions.Add(unavion);
                }

                //Fermeture de la connexion
                reader.Close();
                connection.Close();

            }
            catch
            {
                // Gestion des erreurs :
                // Possibilité de créer un Logger pour les exceptions SQL reçus
                // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
            }
            //  return listeavions;
        }

        public static ViewModel.AvionBinder SelectAvion(int idavion)
        {
            ViewModel.AvionBinder unavion = null;
            try
            {
                ConnectionBdd bdd = new ConnectionBdd();
                MySqlConnection connection = bdd.getConnection();
                // Requête SQL            
                string query = "SELECT * from avion where id="+ idavion + "";
               
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string MatriculeProprty = reader.GetString(1);
                    string MotorisationProperty = reader.GetString(2);
                    int MaintenanceProperty = reader.GetInt32(3);
                    int DisponibleProperty = reader.GetInt32(4);
                    string TypeProperty = reader.GetString(5);
                    int CapaciteProperty = reader.GetInt32(6);
                    int PremiereProperty = reader.GetInt32(7);
                    int BusinessProperty = reader.GetInt32(8);
                    int PremiumProperty = reader.GetInt32(9);
                    int EconomiqueProperty = reader.GetInt32(10);
                    unavion = new ViewModel.AvionBinder(Id,MatriculeProprty, MotorisationProperty, MaintenanceProperty, DisponibleProperty, TypeProperty, CapaciteProperty, PremiereProperty, BusinessProperty, PremiumProperty, EconomiqueProperty);
                }

                //Fermeture de la connexion
                reader.Close();
                connection.Close();
                return unavion;
            }
            catch
            {
                // Gestion des erreurs :
                // Possibilité de créer un Logger pour les exceptions SQL reçus
                // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
            }
            return unavion;
        }
        // Méthode pour ajouter un avion
         public void AddAvion(string matricule,string motorisation, string type ,int capacite, int premiere, int business, int premium, int economique)
         {
             try
             {
                ConnectionBdd bdd = new ConnectionBdd();
                MySqlConnection connection = bdd.getConnection();
                // Ouverture de la connexion SQL
               

                 // Création d'une commande SQL en fonction de l'objet connexion
                 MySqlCommand cmd = connection.CreateCommand();

                 cmd.CommandText = "INSERT INTO avion (matricule,motorisation,maintenance,disponible,type,capacite,premiere,business,premium,economique) VALUES (@matricule,@motorisation,@maintenance,@disponible,@type,@capacite,@premiere,@business,@premium,@economique)";

                cmd.Parameters.AddWithValue("@matricule", matricule);
                cmd.Parameters.AddWithValue("@motorisation", motorisation);
                 cmd.Parameters.AddWithValue("@maintenance", 0);
                 cmd.Parameters.AddWithValue("@disponible", 0);
                 cmd.Parameters.AddWithValue("@type", type);
                 cmd.Parameters.AddWithValue("@capacite", capacite);
                 cmd.Parameters.AddWithValue("@premiere",premiere);
                 cmd.Parameters.AddWithValue("@business", business);
                 cmd.Parameters.AddWithValue("@premium", premium);
                 cmd.Parameters.AddWithValue("@economique", economique);

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

        public void UpdateAvion(ViewModel.AvionBinder a)
         {
            ConnectionBdd bdd = new ConnectionBdd();
            MySqlConnection connection = bdd.getConnection();
           
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE avion SET `matricule`=@matricule,`motorisation`=@motorisation,`maintenance`=@maintenance,`disponible`=@disponible,`type`=@type,`capacite`=@capacite,`premiere`=@premiere,`business`=@business,`premium`=@premium,`economique`=@economique  WHERE id=@id";

            cmd.Parameters.AddWithValue("@matricule", a.MatriculeProperty);
            cmd.Parameters.AddWithValue("@motorisation", a.MotorisationProperty);
            cmd.Parameters.AddWithValue("@maintenance", a.MaintenanceProperty);
            cmd.Parameters.AddWithValue("@disponible", a.DisponibleProperty);
            cmd.Parameters.AddWithValue("@type", a.TypeProperty);
            cmd.Parameters.AddWithValue("@capacite", a.CapaciteProperty);
            cmd.Parameters.AddWithValue("@premiere", a.PremiereProperty);
            cmd.Parameters.AddWithValue("@business", a.BusinessProperty);
            cmd.Parameters.AddWithValue("@premium", a.PremiumProperty);
            cmd.Parameters.AddWithValue("@economique", a.EconomiqueProperty);
            cmd.Parameters.AddWithValue("@id", a.IdProperty);

            //cmd.Parameters.AddWithValue("@id", a.IdProperty);
            //  MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
       





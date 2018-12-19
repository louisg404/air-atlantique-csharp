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
    public class DALVol
    {

       //private MySqlConnection connection;

        // Constructeur
        public DALVol()
        {
           
        }

        // Méthode pour initialiser la connexion
       /* private void InitConnexion()
        {
            // Création de la chaîne de connexion
            
        }*/

        public void SelectVol(ObservableCollection<ViewModel.VolBinder> listevols)
        {
            try
            {
                ConnectionBdd bdd = new ConnectionBdd();
                MySqlConnection connection = bdd.getConnection();
                // Requête SQL            
                string query = "SELECT * from vols";
               
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    int idAvion = reader.GetInt32(1);
                    string DateHeureAProperty = reader.GetDateTime(2).ToString();
                    string DateHeureDProperty = reader.GetDateTime(3).ToString();
                    int AnnuleProperty = reader.GetInt32(4);
                    string LieuAProperty = reader.GetString(5);
                    string LieuDProperty = reader.GetString(6);
                    int NbPassagerProperty = reader.GetInt32(7);

                    ViewModel.VolBinder unvol = new ViewModel.VolBinder(Id, DateHeureAProperty, DateHeureDProperty, AnnuleProperty, LieuAProperty, LieuDProperty, NbPassagerProperty, Model.DAL.DALAvion.SelectAvion(idAvion));

                    listevols.Add(unvol);
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
           
        }
        // Méthode pour ajouter un vol
        public void AddVol(string dateHeureA, string dateHeureD, string lieuA, string lieuD, int nbPassager,int idavion)
        {
            try
            {
                // Ouverture de la connexion SQL
                ConnectionBdd bdd = new ConnectionBdd();
                MySqlConnection connection = bdd.getConnection();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "INSERT INTO vols (dateHeureA,dateHeureD,lieuA,lieuD,nbPassager,idAvion) VALUES (@dateHeureA,@dateHeureD,@lieuA,@lieuD,@nbPassager,@idAvion)";

                cmd.Parameters.AddWithValue("@dateHeureA", dateHeureA);
                cmd.Parameters.AddWithValue("@dateHeureD", dateHeureD);
                cmd.Parameters.AddWithValue("@lieuA", lieuA);
                cmd.Parameters.AddWithValue("@lieuD", lieuD);
                cmd.Parameters.AddWithValue("@nbPassager", nbPassager);
                cmd.Parameters.AddWithValue("@idAvion",idavion);

                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
             
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

        public void UpdateVol(ViewModel.VolBinder v)
        {
            ConnectionBdd bdd = new ConnectionBdd();
            MySqlConnection connection = bdd.getConnection();
            DateTime dd = Convert.ToDateTime(v.DateHeureDProperty);
            DateTime da = Convert.ToDateTime(v.DateHeureAProperty);
            
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "UPDATE vols SET `dateHeureA`=@dateHeureA,`dateHeureD`=@dateHeureD,`annule`=@annule,`lieuA`=@lieuA,`lieuD`=@lieuD,`nbPassager`=@nbPassager WHERE id=@id";

            cmd.Parameters.AddWithValue("@dateHeureA", da);
            cmd.Parameters.AddWithValue("@dateHeureD", dd);
            cmd.Parameters.AddWithValue("@annule", v.AnnuleProperty);
            cmd.Parameters.AddWithValue("@lieuA", v.LieuAProperty);
            cmd.Parameters.AddWithValue("@lieuD", v.LieuDProperty);
            cmd.Parameters.AddWithValue("@nbPassager", v.NbPassagerProperty);
            cmd.Parameters.AddWithValue("@id", v.IdProperty);
            
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        
    }
    
}






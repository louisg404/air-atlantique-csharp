using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace AA.Model.DAL
{
    public class ConnectionBdd
    {
        private MySqlConnection connection;

        // Constructeur
       

        // Méthode pour initialiser la connexion
        public ConnectionBdd()
        {
            // Création de la chaîne de connexion
            string connectionString = "SERVER=127.0.0.1; DATABASE=projetcs; UID=root; PASSWORD=";
            connection = new MySqlConnection(connectionString);
            connection.Open();
            
        }
         public MySqlConnection getConnection()
        {
          
            return connection;
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AnnonceBDD
{
    internal class BDDAnnonce : DbContext
    {
        #region Méthodes d'initialisation de la base de données
        /// <summary>
        /// Méthode de configuration de la connexion à la base de données.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Bibliotheque;Integrated Security=true");
            optionsBuilder.UseSqlite($@"Data Source={Path.Combine(Directory.GetCurrentDirectory(), "BDDAnnonce.db")}");
        }

        /// <summary>
        /// Méthode contenant le code lié aux contraintes du modèle de données et aux données présentes par défaut
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contraintes liées au modèle de la BDD

            #endregion

            #region Données présentes par défaut dans la BDD

            #endregion
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2_Gabriel_Lavoie.Models;

namespace TP2_Gabriel_Lavoie.Controllers
{
    public class LivresController : Controller
    {
        string chaineConnexion = @"Data Source=(LocalDb)\ProjectModels;Initial Catalog=bdgplcc; Integrated Security =true";

        // GET: Livres
        public ActionResult CollectionLivres()
        {
            DataTable tabLivres= new DataTable();
            using(SqlConnection connexion = new SqlConnection(chaineConnexion))
            {
                connexion.Open();
                SqlDataAdapter adapter= new SqlDataAdapter("SELECT * FROM Livres", connexion);
                adapter.Fill(tabLivres);
            }
            return View(tabLivres);
        }

        // GET: Livres
        public ActionResult Acceuil()
        {
            return View();
        }

        // GET: Livres
       
       
        // GET: Livres/Create
        public ActionResult CreateLivres()
        {
            return View(new Livres());
        }

        // POST: Livres/Create
        [HttpPost]
        public ActionResult CreateLivres(Livres livre)
        {
            try
            {
                using (SqlConnection connexion = new SqlConnection(chaineConnexion))
                {
                    connexion.Open();
                    string requete = "INSERT INTO livres VALUES(@Titre,@Auteur,@Categorie)";
                    SqlCommand command = new SqlCommand(requete, connexion);
                    command.Parameters.AddWithValue("@Titre", livre.Titre);
                    command.Parameters.AddWithValue("@Auteur", livre.Auteur);
                    command.Parameters.AddWithValue("@Categorie", livre.Categorie);
                    command.ExecuteNonQuery();
                }

                return RedirectToAction("Acceuil");
            }
            catch
            {
                return View();
            }
        }
        // GET: Livres/Edit/5
        public ActionResult EditLivre(int id)
        {
            Livres livre = new Livres();
            DataTable tabLivres = new DataTable();
            using (SqlConnection connexion = new SqlConnection(chaineConnexion))
            {
                connexion.Open();
                string requete = "SELECT * FROM livres WHERE Id =@Id";
                SqlDataAdapter adapter = new SqlDataAdapter(requete, connexion);
                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
                adapter.Fill(tabLivres);
            }
            if (tabLivres.Rows.Count == 1)
            {
                livre.Id = Convert.ToInt32(tabLivres.Rows[0][0].ToString());
                livre.Titre = tabLivres.Rows[0][1].ToString();
                livre.Auteur = tabLivres.Rows[0][2].ToString();
                livre.Categorie = tabLivres.Rows[0][3].ToString();
                return View(livre);
            }
            else
            {
                return RedirectToAction("Acceuil");
            }
        }

        // POST: Livres/Edit/5
        [HttpPost]
        public ActionResult EditLivre(Livres livre)
        {
            try
            {
                using (SqlConnection connexion = new SqlConnection(chaineConnexion))
                {
                    connexion.Open();
                    string requete = "UPDATE livres SET Titre=@Titre, Auteur=@Auteur, Categorie=@Categorie WHERE Id=@Id";
                    SqlCommand command = new SqlCommand(requete, connexion);
                    command.Parameters.AddWithValue("@Id", livre.Id);
                    command.Parameters.AddWithValue("@Titre", livre.Titre);
                    command.Parameters.AddWithValue("@Auteur", livre.Auteur);
                    command.Parameters.AddWithValue("@Categorie", livre.Categorie);
                    command.ExecuteNonQuery();
                }

                return RedirectToAction("CollectionLivres");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livres/Delete/5
        public ActionResult DeleteLivre(int id)
        {
            return View();
        }

        // POST: Livres/Delete/5
        [HttpPost]
        public ActionResult DeleteLivre(int id, FormCollection collection)
        {
            try
            {
                using (SqlConnection connexion = new SqlConnection(chaineConnexion))
                {
                    connexion.Open();
                    string requete = "DELETE FROM livres WHERE Id=@Id";
                    SqlCommand command = new SqlCommand(requete, connexion);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                return RedirectToAction("CollectionLivres");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Membres()
        {
            DataTable tabMembres = new DataTable();
            using (SqlConnection connexion = new SqlConnection(chaineConnexion))
            {
                connexion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM membres", connexion);
                adapter.Fill(tabMembres);
            }
            return View(tabMembres);
        }

        // GET: Livres/Create
        public ActionResult CreateMembres()
        {
            return View(new Membres());
        }

        // POST: Livres/Create
        [HttpPost]
        public ActionResult CreateMembres(Membres membres)
        {
            try
            {
                using (SqlConnection connexion = new SqlConnection(chaineConnexion))
                {
                    connexion.Open();
                    string requete = "INSERT INTO membres VALUES(@Prenom, @Nom, @Courriel, @Telephone)";
                    SqlCommand command = new SqlCommand(requete, connexion);
                    command.Parameters.AddWithValue("@Prenom", membres.Prenom);
                    command.Parameters.AddWithValue("@Nom", membres.Nom);
                    command.Parameters.AddWithValue("@Courriel", membres.Courriel);
                    command.Parameters.AddWithValue("@Telephone", membres.Telephone);
                    command.ExecuteNonQuery();
                }

                return RedirectToAction("Acceuil");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditMembres(int id)
        {
            Membres membres = new Membres();
            DataTable tabMembre = new DataTable();
            using (SqlConnection connexion = new SqlConnection(chaineConnexion))
            {
                connexion.Open();
                string requete = "SELECT * FROM membres WHERE Id =@Id";
                SqlDataAdapter adapter = new SqlDataAdapter(requete, connexion);
                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
                adapter.Fill(tabMembre);
            }
            if (tabMembre.Rows.Count == 1)
            {
                membres.Id = Convert.ToInt32(tabMembre.Rows[0][0].ToString());
                membres.Prenom = tabMembre.Rows[0][1].ToString();
                membres.Nom = tabMembre.Rows[0][2].ToString();
                membres.Courriel = tabMembre.Rows[0][3].ToString();
                membres.Telephone = tabMembre.Rows[0][4].ToString();
                return View(membres);
            }
            else
            {
                return RedirectToAction("Acceuil");
            }
        }

        // POST: Livres/Edit/5
        [HttpPost]
        public ActionResult EditMembres(Membres membres)
        {
            try
            {
                using (SqlConnection connexion = new SqlConnection(chaineConnexion))
                {
                    connexion.Open();
                    string requete = "UPDATE membres SET Prenom=@Prenom, Nom=@Nom, Courriel=@Courriel WHERE Id=@Id";
                    SqlCommand command = new SqlCommand(requete, connexion);
                    command.Parameters.AddWithValue("@Id", membres.Id);
                    command.Parameters.AddWithValue("@Prenom", membres.Prenom);
                    command.Parameters.AddWithValue("@Nom", membres.Nom);
                    command.Parameters.AddWithValue("@Courriel", membres.Courriel);
                    command.Parameters.AddWithValue("@Telephone", membres.Telephone);
                    command.ExecuteNonQuery();
                }

                return RedirectToAction("Membres");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteMembres(int id)
        {
            return View();
        }

        // POST: Livres/Delete/5
        [HttpPost]
        public ActionResult DeleteMembres(int id, FormCollection collection)
        {
            try
            {
                using (SqlConnection connexion = new SqlConnection(chaineConnexion))
                {
                    connexion.Open();
                    string requete = "DELETE FROM membres WHERE Id=@Id";
                    SqlCommand command = new SqlCommand(requete, connexion);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                return RedirectToAction("Membres");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livres
        public ActionResult Pret()
        {
            DataTable tabPret = new DataTable();
            using (SqlConnection connexion = new SqlConnection(chaineConnexion))
            {
                connexion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM pret", connexion);
                adapter.Fill(tabPret);
            }
            return View(tabPret);
        }


        // GET: Livres/Create
        public ActionResult CreatePret()
        {
            return View(new Pret());
        }

        // POST: Livres/Create
        [HttpPost]
        public ActionResult CreatePret(Pret pret)
        {
            try
            {
                using (SqlConnection connexion = new SqlConnection(chaineConnexion))
                {
                    connexion.Open();
                    string requete = "INSERT INTO pret VALUES(@IdLivres,@IdMembres,@Date); SELECT CAST(scope_identity() AS int)";
                    SqlCommand command = new SqlCommand(requete, connexion);
                    command.Parameters.AddWithValue("@IdLivres", pret.IdLivres);
                    command.Parameters.AddWithValue("@IdMembres", pret.IdMembres);
                    command.Parameters.AddWithValue("@Date", pret.Date);
                    var newId = command.ExecuteScalar();
                    

                    if (pret.EstRetard())
                    {
                        string requeteRetard = "INSERT INTO retard VALUES(@IdLivres, @IdMembres, @IdPret, @Date)";
                        SqlCommand commandRetard = new SqlCommand(requeteRetard, connexion);
                        commandRetard.Parameters.AddWithValue("@IdLivres", pret.IdLivres);
                        commandRetard.Parameters.AddWithValue("@IdMembres", pret.IdMembres);
                        commandRetard.Parameters.AddWithValue("@IdPret", newId);
                        commandRetard.Parameters.AddWithValue("@Date", pret.Date.AddDays(7));
                        commandRetard.ExecuteNonQuery();
                    }
                }
                return RedirectToAction("Acceuil");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeletePret(int id)
        {
            return View();
        }

        // POST: Livres/Delete/5
        [HttpPost]
        public ActionResult DeletePret(int id, FormCollection collection)
        {
            try
            {
                using (SqlConnection connexion = new SqlConnection(chaineConnexion))
                {
                    connexion.Open();
                    string requete = "DELETE FROM pret WHERE Id=@Id";
                    SqlCommand command = new SqlCommand(requete, connexion);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                return RedirectToAction("Pret");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Retard()
        {
            DataTable tabRetard = new DataTable();
            using (SqlConnection connexion = new SqlConnection(chaineConnexion))
            {
                connexion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM retard", connexion);
                adapter.Fill(tabRetard);
            }
            return View(tabRetard);
        }
    }
}

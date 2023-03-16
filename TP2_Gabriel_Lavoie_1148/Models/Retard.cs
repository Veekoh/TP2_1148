using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP2_Gabriel_Lavoie.Models
{
    public class Retard
    {
        public int Id { get; set; }
        public int IdLivres { get; set; }
        public int IdMembres { get; set; }
        public int IdPret { get; set; }
        public DateTime Date { get; set; }
        
        public Retard() { }
        public Retard(int id, int idLivre, int idMembre, int idPret, DateTime date)
        {
            Id = id;
            IdLivres = idLivre;
            IdMembres = idMembre;
            IdPret = idPret;
            Date = date;
        }
    }
}
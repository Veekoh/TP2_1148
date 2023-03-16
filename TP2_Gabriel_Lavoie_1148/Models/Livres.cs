using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace TP2_Gabriel_Lavoie.Models
{
    public class Livres
    {
        public int Id { get; set; }
        [DisplayName("Titre du Livre")]
        public string Titre { get; set; }
        [DisplayName("Nom de l'auteur")]
        public string Auteur { get; set; }
        [DisplayName("Categorie du livre")]
        public string Categorie { get; set; }

    }
}
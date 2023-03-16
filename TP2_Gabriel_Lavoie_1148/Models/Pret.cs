using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP2_Gabriel_Lavoie.Models
{
    public class Pret
    {
        public int Id { get; set; }
        public int IdLivres { get; set; }
        public int IdMembres { get; set;}
        public DateTime Date { get; set; }

        public bool EstRetard()
        {
            if (DateTime.Now >= Date.AddDays(7))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cours02_Vues.Models
{
    public class Personne
    {
        public int IdPersonne { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public int Age { get; set; }

        public int Pays { get; set; }
    }
}

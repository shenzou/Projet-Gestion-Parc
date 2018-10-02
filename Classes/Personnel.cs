using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    abstract class Personnel
    {
        public string fonction;
        public int matricule;
        public string nom;
        public string prenom;
        public TypeSexe sexe;

        public Personnel(int matricule, string nom, string prenom, TypeSexe sexe, string fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;

        }

        public abstract override string ToString();

    }
}

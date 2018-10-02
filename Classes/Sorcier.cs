using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Sorcier:Personnel
    {
        public List<string> pouvoirs;
        Grade tatouage;

        public Sorcier(List<string> pouvoirs, Grade tatouage, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) :base(matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.tatouage = tatouage;
            this.pouvoirs = new List<string>();
            pouvoirs.ForEach(this.pouvoirs.Add);

        }
        public override string ToString()
        {
            string listepouvoirs="";
            pouvoirs.ForEach((pouvoir) => listepouvoirs = listepouvoirs + pouvoir + "-");
            /*
            return "Matricule: " + matricule + " Nom: " + nom + " Prénom: " + prenom + " Sexe: " + sexe + " Fonction: " + fonction + " Liste des pouvoirs: " + listepouvoirs  + " Tatouage: " + tatouage;
            */
            return "Sorcier" + ";" + matricule + ";" + nom + ";" + prenom + ";" + sexe + ";" + fonction + ";" + tatouage + ";" + listepouvoirs;
    }
    }
}

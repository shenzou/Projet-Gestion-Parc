using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Demon:Monstre
    {
        int force;
        public Demon(int force, Attraction affectation, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) : base(affectation,cagnotte,matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.affectation = affectation;
            this.cagnotte = cagnotte;
            if (this.affectation != null){
                this.affectation.equipe.Add(this);
            }
            this.force = force;
        }

        public Demon(int force, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) : base(cagnotte, matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.cagnotte = cagnotte;
            if (this.affectation != null)
            {
                this.affectation.equipe.Add(this);
            }
            this.force = force;
        }

        /*
        public override string ToString()
        {
            return "Matricule: " + matricule + " Nom: " + nom + " Prénom: " + prenom + " Sexe: " + sexe + " Fonction: " + fonction + " Affectation: " + affectation + " Cagnotte: " + cagnotte + " Force: " + force;
        }
        */
        public override string ToString()
        {
            string idAttract = "neant";
            if (affectation != null)
            {
                idAttract = Convert.ToString(affectation.identifiant);
            }
            return "Demon" + ";" + matricule + ";" + nom + ";" + prenom + ";" + sexe + ";" + fonction + ";" + cagnotte + ";" + idAttract +";" + force;
        }
    }
}

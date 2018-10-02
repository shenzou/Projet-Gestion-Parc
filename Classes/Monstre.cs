using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Monstre:Personnel,IComparable
    {
        public Attraction affectation;
        public int cagnotte;

        public Monstre(Attraction affectation, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) :base(matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.affectation = affectation;
            this.cagnotte = cagnotte;
        }

        public Monstre(int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) : base(matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.cagnotte = cagnotte;
        }

        public override string ToString()
        {
            string idAttract = "neant";
            if(affectation!=null)
            {
                idAttract = Convert.ToString(affectation.identifiant);
            }
            return "Monstre" + ";" + matricule + ";" + nom + ";" + prenom + ";" + sexe + ";" + fonction + ";"  + cagnotte + ";" + idAttract;
        }

        //inutile
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Monstre otherMonstre = obj as Monstre;
            if (otherMonstre != null)
            {
                    return this.cagnotte.CompareTo(otherMonstre.cagnotte);
            }
            else
                throw new ArgumentException("Object is not a Monstre");
        }

    }
}

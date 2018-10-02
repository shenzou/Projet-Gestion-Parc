using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.App.Classes
{
    class Zombie:Monstre
    {
        int degreDecomposition;
        CouleurZ teint;
        public int DegreDecomposition
        {
            get { return this.degreDecomposition; }
            set
            {
                if (value != this.degreDecomposition)
                {
                    if(value>10)
                    {
                        this.degreDecomposition = 10;
                    }
                    else if(value<1)
                    {
                        this.degreDecomposition = 1;
                    }
                    else
                    this.degreDecomposition = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public CouleurZ Teint
        {
            get { return this.teint; }
            set
            {
                if (value != this.teint)
                {
                    this.teint = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Zombie(int degreDecomposition, CouleurZ teint, Attraction affectation, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) : base(affectation,cagnotte,matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.affectation = affectation;
            if (this.affectation != null)
            {
                this.affectation.Equipe.Add(this);
            }
            this.cagnotte = cagnotte;
            this.degreDecomposition = degreDecomposition;
            this.teint = teint;
        }
        public Zombie(int degreDecomposition, CouleurZ teint, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) : base(cagnotte, matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.cagnotte = cagnotte;
            this.degreDecomposition = degreDecomposition;
            this.teint = teint;
        }

        /*
        public override string ToString()
        {
            return "Matricule: " + matricule + " Nom: " + nom + " Prénom: " + prenom + " Sexe: " + sexe + " Fonction: " + fonction + " Affectation: " + affectation + " Cagnotte: " + cagnotte + " Degré de décomposition: " + degreDecomposition+" Teint: "+teint;
        }
        */
        public override string ToString()
        {
            string idAttract = "neant";
            if (affectation != null)
            {
                idAttract = Convert.ToString(affectation.identifiant);
            }
            return "Zombie" + ";" + matricule + ";" + nom + ";" + prenom + ";" + sexe + ";" + fonction + ";" + cagnotte + ";" + idAttract + ";" + teint + ";" + degreDecomposition;
        }
    }
}

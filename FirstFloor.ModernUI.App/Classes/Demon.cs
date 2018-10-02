using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FirstFloor.ModernUI.App.Classes
{
    class Demon:Monstre
    {
        int force;
        public int Force
        {
            get { return this.force; }
            set
            {
                if (value != this.force)
                {
                    if(value>10)
                    {
                        this.force = 10;
                    }
                    else if(value<10)
                    {
                        this.force = 0;
                    }
                    else
                    this.force = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
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
                this.affectation.Equipe.Add(this);
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
                this.affectation.Equipe.Add(this);
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

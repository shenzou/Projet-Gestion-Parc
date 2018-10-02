﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class LoupGarou:Monstre
    {
        double indiceCruaute;
        public LoupGarou(double indiceCruaute, Attraction affectation, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) : base(affectation,cagnotte,matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.affectation = affectation;
            if (this.affectation != null)
            {
                this.affectation.equipe.Add(this);
            }
            this.cagnotte = cagnotte;
            this.indiceCruaute=indiceCruaute;
        }

        public LoupGarou(double indiceCruaute, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) : base( cagnotte, matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.cagnotte = cagnotte;
            this.indiceCruaute = indiceCruaute;
        }

        /*
        public override string ToString()
        {
            return "Matricule: " + matricule + " Nom: " + nom + " Prénom: " + prenom + " Sexe: " + sexe + " Fonction: " + fonction + " Affectation: " + affectation + " Cagnotte: " + cagnotte + " Indice de cruauté: " + indiceCruaute;
        }
        */
        public override string ToString()
        {
            string idAttract = "neant";
            if (affectation != null)
            {
                idAttract = Convert.ToString(affectation.identifiant);
            }
            return "LoupGarou" + ";" + matricule + ";" + nom + ";" + prenom + ";" + sexe + ";" + fonction + ";" + cagnotte + ";" + idAttract + ";" + indiceCruaute;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class RollerCoaster:Attraction
    {
        public int ageMinimum;
        TypeCategorie categorie;
        public float tailleMinimum;
        public RollerCoaster(int ageMinimum, TypeCategorie categorie, float tailleMinimum, bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin):base(besoinSpecifique,equipe,identifiant,nbMinMonstre,nom,typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.equipe = equipe;
            this.identifiant = identifiant;

            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;

            this.typeDeBesoin = typeDeBesoin;
            this.ageMinimum = ageMinimum;
            this.categorie = categorie;
            this.tailleMinimum = tailleMinimum;
        }

        public override string ToString()
        {
            /*
            string listeEquipe = "";
            equipe.ForEach((Monstre) => listeEquipe = listeEquipe + Monstre + " ,");
            */
            return "RollerCoaster" + ";" + identifiant + ";" + nom + ";" + nbMinMonstre + ";" + besoinSpecifique + ";" + typeDeBesoin + ";" + categorie + ";" + ageMinimum + ";" + tailleMinimum;
        }
    }
}

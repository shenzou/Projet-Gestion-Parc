using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class DarkRide:Attraction
    {
        public TimeSpan duree;
        bool vehicule;
        public DarkRide(TimeSpan duree, bool vehicule, bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin):base(besoinSpecifique,dureeMaintenance,equipe,identifiant,maintenance,natureMaintenance,nbMinMonstre,nom,ouvert,typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.dureeMaintenance = dureeMaintenance;
            this.equipe = equipe;
            this.identifiant = identifiant;
            this.maintenance = maintenance;
            this.natureMaintenance = natureMaintenance;
            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;
            this.ouvert = ouvert;
            this.typeDeBesoin = typeDeBesoin;
            this.duree = duree;
            this.vehicule = vehicule;

        }

        
        public DarkRide(TimeSpan duree, bool vehicule, bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin) : base(besoinSpecifique, equipe, identifiant, nbMinMonstre, nom, typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.equipe = equipe;
            this.identifiant = identifiant;
            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;
            this.typeDeBesoin = typeDeBesoin;
            this.duree = duree;
            this.vehicule = vehicule;

        }

        public override string ToString()
        {
            /*
            string listeEquipe = "";
            equipe.ForEach((Monstre) => listeEquipe = listeEquipe + Monstre + " ,");
            */
            return "DarkRide" + ";" + identifiant + ";" + nom + ";" + nbMinMonstre + ";" + besoinSpecifique + ";" + typeDeBesoin + ";" + duree + ";" + vehicule;
        }

    }
}

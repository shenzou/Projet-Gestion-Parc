using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    class Spectacle:Attraction
    {
        public List<DateTime> horaire;
        public int nombrePlaces;
        string nomSalle;

        public Spectacle(List<DateTime> horaire, int nombrePlaces, string nomSalle,bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin):base(besoinSpecifique,dureeMaintenance,equipe,identifiant,maintenance,natureMaintenance,nbMinMonstre,nom,ouvert,typeDeBesoin)
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
            this.nombrePlaces = nombrePlaces;
            this.nomSalle = nomSalle;

            horaire.ForEach(this.horaire.Add);

        }

        public Spectacle(List<DateTime> horaire, int nombrePlaces, string nomSalle, bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin) : base(besoinSpecifique, equipe, identifiant, nbMinMonstre, nom, typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
           
            this.equipe = equipe;
            this.identifiant = identifiant;
            
            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;
           
            this.typeDeBesoin = typeDeBesoin;
            this.nombrePlaces = nombrePlaces;
            this.nomSalle = nomSalle;
            this.horaire = new List<DateTime>();
            horaire.ForEach(this.horaire.Add);
        }

        public override string ToString()
        {
            /*
            string listeEquipe = "";
            equipe.ForEach((Monstre) => listeEquipe = listeEquipe + Monstre + " ,");
            */
            string listeHoraires = "";
            horaire.ForEach((dateTime) => listeHoraires = listeHoraires + dateTime.Hour + ":" + dateTime.Minute + " ");
            return "Spectacle" + ";" + identifiant + ";" + nom + ";" + nbMinMonstre + ";" + besoinSpecifique + ";" + typeDeBesoin + ";" + nomSalle + ";" + nombrePlaces + ";" + listeHoraires;
        }
    }
}

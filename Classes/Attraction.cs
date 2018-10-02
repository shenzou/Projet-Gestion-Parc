using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    abstract class Attraction
    {
        public bool besoinSpecifique;
        public TimeSpan dureeMaintenance;
        public List<Monstre> equipe;
        public int identifiant;
        public bool maintenance;
        public string natureMaintenance;
        public int nbMinMonstre;
        public string nom;
        public bool ouvert;
        public string typeDeBesoin;

        public Attraction(bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin)
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
        }

        public Attraction(bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.equipe = equipe;
            this.identifiant = identifiant;
            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;
            this.typeDeBesoin = typeDeBesoin;
        }

    }
}

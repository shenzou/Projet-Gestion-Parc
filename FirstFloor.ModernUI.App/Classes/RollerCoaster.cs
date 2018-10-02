using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.App.Classes
{
    class RollerCoaster:Attraction
    {
        public int ageMinimum;
        TypeCategorie categorie;
        public float tailleMinimum;
        public int AgeMinimum
        {
            get { return this.ageMinimum; }
            set
            {
                if (value != this.ageMinimum)
                {
                    this.ageMinimum = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public TypeCategorie Categorie
        {
            get { return this.categorie; }
            set
            {
                if (value != this.categorie)
                {
                    this.categorie = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public float TailleMinimum
        {
            get { return this.tailleMinimum; }
            set
            {
                if (value != this.tailleMinimum)
                {
                    this.tailleMinimum = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public RollerCoaster(int ageMinimum, TypeCategorie categorie, float tailleMinimum, bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin):base(besoinSpecifique,equipe,identifiant,nbMinMonstre,nom,ouvert,typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.equipe = equipe;
            this.identifiant = identifiant;

            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;
            this.ouvert = ouvert;
            this.typeDeBesoin = typeDeBesoin;
            this.ageMinimum = ageMinimum;
            this.categorie = categorie;
            this.tailleMinimum = tailleMinimum;
        }

        public RollerCoaster(int ageMinimum, TypeCategorie categorie, float tailleMinimum, bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin) : base(besoinSpecifique, equipe, identifiant, nbMinMonstre, nom, typeDeBesoin)
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

        public RollerCoaster(int ageMinimum, TypeCategorie categorie, float tailleMinimum, bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin) : base(besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.equipe = equipe;
            this.identifiant = identifiant;
            this.dureeMaintenance = dureeMaintenance;
            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;
            this.maintenance = maintenance;
            this.natureMaintenance = natureMaintenance;
            this.typeDeBesoin = typeDeBesoin;
            this.ageMinimum = ageMinimum;
            this.categorie = categorie;
            this.tailleMinimum = tailleMinimum;
            this.ouvert = ouvert;
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

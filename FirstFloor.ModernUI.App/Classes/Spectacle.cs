using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.App.Classes
{
    class Spectacle:Attraction
    {
        public List<DateTime> horaire;
        public int nombrePlaces;
        string nomSalle;
        public string Horaire
        {
            get
            {
                string texte = "";
                foreach (DateTime element in horaire)
                {
                    texte = texte + element +"\n";

                }
                return texte;
            }
            set { }
        }
        public int NombrePlaces
        {
            get { return this.nombrePlaces; }
            set
            {
                if (value != this.nombrePlaces)
                {
                    this.nombrePlaces = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string NomSalle
        {
            get { return this.nomSalle; }
            set
            {
                if (value != this.nomSalle)
                {
                    this.nomSalle = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Spectacle(List<DateTime> horaire, int nombrePlaces, string nomSalle,bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> Equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin):base(besoinSpecifique,dureeMaintenance,Equipe,identifiant,maintenance,natureMaintenance,nbMinMonstre,nom,ouvert,typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.dureeMaintenance = dureeMaintenance;
            this.Equipe = Equipe;
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

        public Spectacle(List<DateTime> horaire, int nombrePlaces, string nomSalle, bool besoinSpecifique, List<Monstre> Equipe, int identifiant, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin) : base(besoinSpecifique, Equipe, identifiant, nbMinMonstre, nom, ouvert, typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
           
            this.Equipe = Equipe;
            this.identifiant = identifiant;
            
            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;
            this.ouvert = ouvert;
            this.typeDeBesoin = typeDeBesoin;
            this.nombrePlaces = nombrePlaces;
            this.nomSalle = nomSalle;
            this.horaire = new List<DateTime>();
            horaire.ForEach(this.horaire.Add);
        }

        public Spectacle(List<DateTime> horaire, int nombrePlaces, string nomSalle, bool besoinSpecifique, List<Monstre> Equipe, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin) : base(besoinSpecifique, Equipe, identifiant, nbMinMonstre, nom, typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;

            this.Equipe = Equipe;
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
            Equipe.ForEach((Monstre) => listeEquipe = listeEquipe + Monstre + " ,");
            */
            string listeHoraires = "";
            horaire.ForEach((dateTime) => listeHoraires = listeHoraires + dateTime.Hour + ":" + dateTime.Minute + " ");
            return "Spectacle" + ";" + identifiant + ";" + nom + ";" + nbMinMonstre + ";" + besoinSpecifique + ";" + typeDeBesoin + ";" + nomSalle + ";" + nombrePlaces + ";" + listeHoraires;
        }
    }
}

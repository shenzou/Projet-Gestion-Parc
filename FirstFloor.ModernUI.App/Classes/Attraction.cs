using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace FirstFloor.ModernUI.App.Classes
{
    abstract class Attraction : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
        public Attraction() { }
        public string TypeOf
        {
            get { return this.GetType().Name.ToString(); }
        }
        public bool BesoinSpecifique
        {
            get { return this.besoinSpecifique; }
            set
            {
                if (value != this.besoinSpecifique)
                {   
                    if(!this.besoinSpecifique)
                    {
                        this.typeDeBesoin = "";
                    }
                    this.besoinSpecifique = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public TimeSpan DureeMaintenance
        {
            get { return this.dureeMaintenance; }
            set
            {
                if (value != this.dureeMaintenance)
                {
                    this.dureeMaintenance = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public List<Monstre> Equipe
        {
            get { return this.equipe; }
            set
            {
                if(value!=this.equipe)
                {
                    this.equipe = value;
                    NotifyPropertyChanged();
                }
                
            }
            
        }
        public int Identifiant
        {
            get { return this.identifiant; }
            set
            {
                if (value != this.identifiant)
                {
                    bool exist = false;
                    for(int i=0; i<Administration.listeAttractions.Count; i++)
                    {
                        if(value==Administration.listeAttractions[i].Identifiant)
                        {
                            exist = true;
                        }
                    }
                    if(!exist)
                    {
                        this.identifiant = value;
                        NotifyPropertyChanged();
                    }
                    
                }
            }
        }
        public bool Maintenance
        {
            get { return this.maintenance; }
            set
            {
                if (value != this.maintenance)
                {
                    this.maintenance = value;
                    if(!this.maintenance)
                    {
                        TimeSpan temp = new TimeSpan();
                        this.dureeMaintenance = temp;
                        this.natureMaintenance = "";
                        
                        NotifyOtherPropertyChanged("DureeMaintenance");
                        NotifyOtherPropertyChanged("NatureMaintenance");
                        
                    }
                    NotifyPropertyChanged();
                }
            }
        }
        public string NatureMaintenance
        {
            get { return this.natureMaintenance; }
            set
            {
                if (value != this.natureMaintenance)
                {
                    if(!Maintenance)
                    {
                        
                    }
                    else
                    this.natureMaintenance = value;
                    
                    NotifyPropertyChanged();
                }
            }
        }
        public int NbMinMonstre
        {
            get { return this.nbMinMonstre; }
            set
            {
                if (value != this.nbMinMonstre)
                {
                    if(value<0)
                    {
                        this.nbMinMonstre = 0;
                    }
                    else if(value>20)
                    {
                        this.nbMinMonstre = 20;
                    }
                    else
                    this.nbMinMonstre = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Nom
        {
            get { return this.nom; }
            set
            {
                if (value != this.nom)
                {
                    this.nom = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool Ouvert
        {
            get { return this.ouvert; }
            set
            {
                if (value != this.ouvert)
                {
                    if (value) { if (NbMinMonstre <= Equipe.Count()) { this.ouvert = value; NotifyPropertyChanged(); } else { this.ouvert = false; NotifyPropertyChanged(); } }
                    else { this.ouvert = value; NotifyPropertyChanged(); }
                    
                }
            }
        }

        public string TypeDeBesoin
        {
            get { return this.typeDeBesoin; }
            set
            {
                if (value != this.typeDeBesoin)
                {
                    this.typeDeBesoin = value;
                    NotifyPropertyChanged();
                }
            }
        }

      
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void NotifyOtherPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

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

        public Attraction(bool besoinSpecifique, List<Monstre> equipe, int identifiant, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.equipe = equipe;
            this.identifiant = identifiant;
            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;
            this.ouvert = ouvert;
            this.typeDeBesoin = typeDeBesoin;
        }
    }
}

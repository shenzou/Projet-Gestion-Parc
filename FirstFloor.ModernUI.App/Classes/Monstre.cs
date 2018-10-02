using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FirstFloor.ModernUI.App.Classes
{
    class Monstre : Personnel/*,IComparable*/
    {
        public Attraction affectation;
        public int cagnotte;
        public Attraction Affectation
        {
            get { return this.affectation; }
            set {
                if (value != this.affectation & value != null)
                {
                    this.affectation.Equipe.Remove(this);
                    this.affectation = value;
                    this.affectation.Equipe.Add(this);
                    NotifyPropertyChanged();
                }
                else if(value==null & value!=this.affectation)
                {
                    this.affectation.Equipe.Remove(this);
                    this.affectation = value;
                    NotifyPropertyChanged();

                }
            }
            
        }
        
        public int Cagnotte
        {
            get { return this.cagnotte; }
            set
            {
                if (value != this.cagnotte)
                {
                    if (value < 50) //Changement de la cagnotte et affectation du monstre aux barbe à papa (<50)
                    {

                        List<Boutique> listeBoutiqueTemp = new List<Boutique>();
                        listeBoutiqueTemp = Administration.listeAttractions.OfType<Boutique>().ToList();

                        foreach (Boutique b in listeBoutiqueTemp)
                        {
                            if (b.Type == TypeBoutique.barbeAPapa)
                            {
                                this.affectation.Equipe.Remove(this);
                                this.affectation = b;
                                b.Equipe.Add(this);
                                
                                NotifyPropertyChanged("Affectation");
                                break;


                            }
                        }
                    }
                    else if (value > 500 && this.GetType() == typeof(Zombie)) //Désaffectation du zombie de son attraction (>500)
                    {
                        
                        List<AttractionNull> listeAttractionNull = new List<AttractionNull>();
                        listeAttractionNull = Administration.listeAttractions.OfType<AttractionNull>().ToList();
                        foreach (AttractionNull b in listeAttractionNull)
                        {
                            
                                this.affectation.Equipe.Remove(this);
                                this.affectation = b;
                                b.Equipe.Add(this);
                                NotifyPropertyChanged("Affectation");
                                break;


                            
                        }
                    }
                    else if (value > 500 && this.GetType() == typeof(Demon)) //Désaffectation du démon de son attraction (>500)
                    {
                        
                        List<AttractionNull> listeAttractionNull = new List<AttractionNull>();
                        listeAttractionNull = Administration.listeAttractions.OfType<AttractionNull>().ToList();
                        foreach (AttractionNull b in listeAttractionNull)
                        {

                            this.affectation.Equipe.Remove(this);
                            this.affectation = b;
                            b.Equipe.Add(this);
                            NotifyPropertyChanged("Affectation");
                            break;



                        }
                    }
                    this.cagnotte = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public SortableBindingList<Attraction> ListeAttractions
        {
            get { 
                return Administration.listeAttractions;
            }
        }

        public Monstre(bool b,Attraction affectation, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) : base(matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.affectation = affectation;
            this.affectation.Equipe.Add(this);
            this.cagnotte = cagnotte;
        }
        public Monstre(Attraction affectation, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) : base(matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.affectation = affectation;
            this.cagnotte = cagnotte;
        }

        public Monstre(int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction) : base(matricule, nom, prenom, sexe, fonction)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.fonction = fonction;
            this.cagnotte = cagnotte;
        }

        public override string ToString()
        {
            string idAttract = "neant";
            if (affectation != null)
            {
                idAttract = Convert.ToString(affectation.identifiant);
            }
            return "Monstre" + ";" + matricule + ";" + nom + ";" + prenom + ";" + sexe + ";" + fonction + ";" + cagnotte + ";" + idAttract;
        }

        //    //inutile
        //    public int CompareTo(object obj)
        //    {
        //        if (obj == null) return 1;

        //        Monstre otherMonstre = obj as Monstre;
        //        if (otherMonstre != null)
        //        {
        //                return this.cagnotte.CompareTo(otherMonstre.cagnotte);
        //        }
        //        else
        //            throw new ArgumentException("Object is not a Monstre");
        //    }

        //}
    }
}

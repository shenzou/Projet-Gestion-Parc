using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace FirstFloor.ModernUI.App.Classes
{
    abstract class Personnel: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string Type
        {
            get { return this.GetType().Name.ToString(); }
        }
        public string fonction;
        public int matricule;
        public string nom;
        public string prenom;
        public TypeSexe sexe;
        public string Fonction {
            get { return this.fonction; }
            set { if (value != this.fonction)
                {
                    this.fonction = value;
                    NotifyPropertyChanged();
                } }
        }
        public int Matricule
        {
            get { return this.matricule; }
            set
            {
                if (value != this.matricule)
                {
                    bool flag = true;
                    foreach (Personnel p in Administration.listePersonnel)
                    {

                        if (p.Matricule == value)
                        {
                            flag = false;
                            

                        }
                        if(this.matricule== 66655)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        this.matricule = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }
        public string Nom { 
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
        public string Prenom
        {
            get { return this.prenom; }
            set
            {
                if (value != this.prenom)
                {
                    this.prenom = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public TypeSexe Sexe
        {
            get { return this.sexe; }
            set
            {
                if (value != this.sexe)
                {
                    this.sexe = value;
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
        public Personnel(int matricule, string nom, string prenom, TypeSexe sexe, string fonction)
        {
            this.Matricule = matricule;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Sexe = sexe;
            this.Fonction = fonction;

        }

        public abstract override string ToString();

    }
}

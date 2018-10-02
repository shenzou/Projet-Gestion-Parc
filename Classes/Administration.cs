﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilRouge
{
    class Administration
    {
        public List<Attraction> listeAttractions;
        public List<Personnel> listePersonnel;
        public Administration(List<Attraction> listeAttractions, List<Personnel> listePersonnel)
        {
            this.listeAttractions = listeAttractions;
            this.listePersonnel = listePersonnel;
        }



        public void AjouterSorcier(List<string> listePouvoirs, Grade tatouage, int matricule, string nom, string prenom, TypeSexe sexe, string fonction)
        {
            bool flag = true; //Utilisé pour savoir si le matricule existe déjà.
            foreach (Personnel p in listePersonnel)
            {
                if (matricule == p.matricule)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                Sorcier s = new Sorcier(listePouvoirs, tatouage, matricule, nom, prenom, sexe, fonction);
                listePersonnel.Add(s); //Création du nouveau monstre et ajout à la liste
            }

        }
        public void AjouterLoupGarou(double indiceCruaute, Attraction affectation, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction)
        {
            bool flag = true; //Utilisé pour savoir si le matricule existe déjà.
            foreach (Personnel p in listePersonnel)
            {
                if (matricule == p.matricule)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                LoupGarou l = new LoupGarou(indiceCruaute, affectation, cagnotte, matricule, nom, prenom, sexe, fonction);
                listePersonnel.Add(l); //Création du nouveau monstre et ajout à la liste
                if (affectation != null) { l.affectation.equipe.Add(l); }
            }


        }
        public void AjouterZombie(int degreDecomposition, CouleurZ teint, Attraction affectation, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction)
        {
            bool flag = true; //Utilisé pour savoir si le matricule existe déjà.
            foreach (Personnel p in listePersonnel)
            {
                if (matricule == p.matricule)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                Zombie z = new Zombie(degreDecomposition, teint, affectation, cagnotte, matricule, nom, prenom, sexe, fonction);
                listePersonnel.Add(z); //Création du nouveau monstre et ajout à la liste
                if (affectation != null) { z.affectation.equipe.Add(z); }
            }
        }
        public void AjouterFantome(Attraction affectation, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction)
        {
            bool flag = true; //Utilisé pour savoir si le matricule existe déjà.
            foreach (Personnel p in listePersonnel)
            {
                if (matricule == p.matricule)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                Fantome f = new Fantome(affectation, cagnotte, matricule, nom, prenom, sexe, fonction);
                listePersonnel.Add(f); //Création du nouveau monstre et ajout à la liste
                if (affectation != null) { f.affectation.equipe.Add(f); }
            }
        }
        public void AjouterDemon(int force, Attraction affectation, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction)
        {
            bool flag = true; //Utilisé pour savoir si le matricule existe déjà.
            foreach (Personnel p in listePersonnel)
            {
                if (matricule == p.matricule)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                Demon d = new Demon(force, affectation, cagnotte, matricule, nom, prenom, sexe, fonction);
                listePersonnel.Add(d); //Création du nouveau monstre et ajout à la liste
                if (affectation != null) { d.affectation.equipe.Add(d); }
            }
        }
        public void AjouterVampire(double indiceLuminosite, Attraction affectation, int cagnotte, int matricule, string nom, string prenom, TypeSexe sexe, string fonction)
        {
            bool flag = true; //Utilisé pour savoir si le matricule existe déjà.
            foreach (Personnel p in listePersonnel)
            {
                if (matricule == p.matricule)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                Vampire v = new Vampire(indiceLuminosite, affectation, cagnotte, matricule, nom, prenom, sexe, fonction);
                listePersonnel.Add(v); //Création du nouveau monstre et ajout à la liste
                if (affectation != null) { v.affectation.equipe.Add(v); }
            }
        }
        public void AjouterRollercoaster(int ageMinimum, TypeCategorie categorie, int tailleMinimum, bool besoinSpecifique, int identifiant, int nbMinMonstre, string nom, string typedeBesoin)
        { 
            bool flag = true; //Utilisé pour savoir si le matricule existe déjà.
            foreach (Attraction a in listeAttractions)
            {
                if (identifiant == a.identifiant)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                List<Monstre> equipe = new List<Monstre>();
                RollerCoaster r = new RollerCoaster(ageMinimum, categorie, tailleMinimum, besoinSpecifique, equipe, identifiant, nbMinMonstre, nom, typedeBesoin);
                listeAttractions.Add(r); //Création de la nouvelle attraction et ajout à la liste

            }

        }
        public void AjouterDarkRide(TimeSpan duree, bool vehicule, bool besoinSpecifique, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin)
        {
            bool flag = true; //Utilisé pour savoir si le matricule existe déjà.
            foreach (Attraction a in listeAttractions)
            {
                if (identifiant == a.identifiant)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                List<Monstre> equipe = new List<Monstre>();
                DarkRide r = new DarkRide(duree, vehicule, besoinSpecifique, equipe, identifiant, nbMinMonstre, nom, typeDeBesoin);
                listeAttractions.Add(r); //Création de la nouvelle attraction et ajout à la liste

            }

        }
        public void AjouterBoutique(TypeBoutique type, bool besoinSpecifique, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin)
        {
            bool flag = true; //Utilisé pour savoir si le matricule existe déjà.
            foreach (Attraction a in listeAttractions)
            {
                if (identifiant == a.identifiant)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                List<Monstre> equipe = new List<Monstre>();
                Boutique b = new Boutique(type, besoinSpecifique, equipe, identifiant, nbMinMonstre, nom, typeDeBesoin);
                listeAttractions.Add(b); //Création de la nouvelle attraction et ajout à la liste

            }

        }
        public void AjouterSpectacle(List<DateTime> horaire, int nombrePlaces, string nomSalle, bool besoinSpecifique, int identifiant, int nbMinMonstre, string nom, string typeDeBesoin)
        {
            bool flag = true; //Utilisé pour savoir si le matricule existe déjà.
            foreach (Attraction a in listeAttractions)
            {
                if (identifiant == a.identifiant)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                List<Monstre> equipe = new List<Monstre>();
                Spectacle s = new Spectacle(horaire, nombrePlaces, nomSalle, besoinSpecifique, equipe, identifiant, nbMinMonstre, nom, typeDeBesoin);
                listeAttractions.Add(s); //Création de la nouvelle attraction et ajout à la liste

            }

        }

        public void ChangerFonction(Personnel p, string fonction) //Changement d'une variable donnée
        {
            p.fonction = fonction;

        }
        public void ChangerAffectation(Monstre m, Attraction affectation) //Changement d'une variable donnée
        {
            m.affectation.equipe.Remove(m);
            m.affectation = affectation;
            m.affectation.equipe.Add(m);

        }

        public void ChangerPouvoirs(Sorcier s, List<string> pouvoirs) //Changement d'une variable donnée
        {
            s.pouvoirs = pouvoirs;
        }

        public void ToggleBesoinSpecifique(Attraction a) //Changement d'une variable donnée
        {
            a.besoinSpecifique = !a.besoinSpecifique;
        }

        public void ChangerDureeMaintenance(Attraction a, TimeSpan duree) //Changement d'une variable donnée
        {
            a.dureeMaintenance = duree;
        }

        public void ToggleMaintenance(Attraction a) //Changement d'une variable donnée
        {
            a.maintenance = !a.maintenance;
        }
        public void ChangerNatureMaintenance(Attraction a, string natureMaintenance) //Changement d'une variable donnée
        {
            a.natureMaintenance = natureMaintenance;
        }
        public void ToggleOuvert(Attraction a) //Changement d'une variable donnée
        {
            a.ouvert = !a.ouvert;
        }
        public void ChangerTypeDeBesoin(Attraction a, string typeDeBesoin) //Changement d'une variable donnée
        {
            a.typeDeBesoin = typeDeBesoin;
        }
        public void ChangerDuree(DarkRide d, TimeSpan duree) //Changement d'une variable donnée
        {
            d.duree = duree;
        }
        public void ChangerHoraire(Spectacle s, List<DateTime> horaire) //Changement d'une variable donnée
        {
            s.horaire = horaire;
        }

        public void ChangerNombrePlaces(Spectacle s, int nombrePlaces) //Changement d'une variable donnée
        {
            s.nombrePlaces = nombrePlaces;
        }

        public void ChangerAgeMinimum(RollerCoaster r, int ageMinimum) //Changement d'une variable donnée
        {
            r.ageMinimum = ageMinimum;
        }

        public void ChangerTailleMinimum(RollerCoaster r, float tailleMinimum) //Changement d'une variable donnée
        {
            r.tailleMinimum = tailleMinimum;
        }
        public List<Boutique> ListeBoutiques() //Permet de renvoyer une liste contenant toutes les boutiques
        {
            List<Boutique> listeBoutiques = new List<Boutique>();
            listeBoutiques = listeAttractions.OfType<Boutique>().ToList();
            return listeBoutiques;

        }
        public List<DarkRide> ListeDarkRides() //Permet de renvoyer une liste contenant tous les darkrides
        {
            List<DarkRide> listeDarkRides = new List<DarkRide>();
            listeDarkRides = listeAttractions.OfType<DarkRide>().ToList();
            return listeDarkRides;

        }
        public List<RollerCoaster> ListeRollerCoasters() //Permet de renvoyer une liste contenant tous les rollercoaster
        {
            List<RollerCoaster> listeRollerCoasters = new List<RollerCoaster>();
            listeRollerCoasters = listeAttractions.OfType<RollerCoaster>().ToList();
            return listeRollerCoasters;

        }
        public List<Spectacle> ListeSpectacles() //Permet de renvoyer une liste contenant tous les spectacles
        {
            List<Spectacle> listeSpectacles = new List<Spectacle>();
            listeSpectacles = listeAttractions.OfType<Spectacle>().ToList();
            return listeSpectacles;

        }
        public List<Demon> ListeDemons() //Permet de renvoyer une liste contenant tous les démons
        {
            List<Demon> listeDemons = new List<Demon>();
            listeDemons = listePersonnel.OfType<Demon>().ToList();
            return listeDemons;
        }
        public List<Fantome> ListeFantomes() //Permet de renvoyer une liste contenant tous les fantomes
        {
            List<Fantome> listeFantomes = new List<Fantome>();
            listeFantomes = listePersonnel.OfType<Fantome>().ToList();
            return listeFantomes;
        }
        public List<LoupGarou> ListeLoupGarous() //Permet de renvoyer une liste contenant tous les loup garou
        {
            List<LoupGarou> listeLoupGarous = new List<LoupGarou>();
            listeLoupGarous = listePersonnel.OfType<LoupGarou>().ToList();
            return listeLoupGarous;
        }
        public List<Monstre> ListeMonstres() //Permet de renvoyer une liste contenant tous les monstres
        {
            List<Monstre> listeMonstres = new List<Monstre>();
            listeMonstres = listePersonnel.OfType<Monstre>().ToList();
            return listeMonstres;
        }
        public List<Sorcier> ListeSorciers() //Permet de renvoyer une liste contenant tous les sorciers
        {
            List<Sorcier> listeSorciers = new List<Sorcier>();
            listeSorciers = listePersonnel.OfType<Sorcier>().ToList();
            return listeSorciers;
        }
        public List<Vampire> ListeVampires() //Permet de renvoyer une liste contenant tous les vampires
        {
            List<Vampire> listeVampires = new List<Vampire>();
            listeVampires = listePersonnel.OfType<Vampire>().ToList();
            return listeVampires;
        }
        public List<Zombie> ListeZombies() //Permet de renvoyer une liste contenant tous les zombies
        {
            List<Zombie> listeZombies = new List<Zombie>();
            listeZombies = listePersonnel.OfType<Zombie>().ToList();
            return listeZombies;
        }
        
        public void ChangerCagnotte(int e, Monstre m)
        {
            m.cagnotte = m.cagnotte + e;

            if (m.cagnotte < 50) //Changement de la cagnotte et affectation du monstre aux barbe à papa (<50)
            {

                List<Boutique> listeBoutiqueTemp = new List<Boutique>();
                listeBoutiqueTemp = listeAttractions.OfType<Boutique>().ToList();

                foreach (Boutique b in listeBoutiqueTemp)
                {
                    if (b.Type == TypeBoutique.barbeAPapa)
                    {
                        m.affectation.equipe.Remove(m);
                        m.affectation = b;
                        b.equipe.Add(m);
                        break;


                    }
                }
            }
            else if (m.cagnotte > 500 && m.GetType() == typeof(Zombie)) //Désaffectation du zombie de son attraction (>500)
            {
                List<Monstre> listeMonstreTemp = new List<Monstre>();
                listeMonstreTemp.Add(m);
                List<Zombie> listeZombieTemp = new List<Zombie>();
                listeZombieTemp = listeMonstreTemp.Cast<Zombie>().ToList();
                listeZombieTemp[0].affectation.equipe.Remove(listeZombieTemp[0]);
                listeZombieTemp[0].affectation = null;
            }
            else if (m.cagnotte > 500 && m.GetType() == typeof(Demon)) //Désaffectation du démon de son attraction (>500)
            {
                List<Monstre> listeMonstreTemp = new List<Monstre>();
                listeMonstreTemp.Add(m);
                List<Demon> listeDemonTemp = new List<Demon>();
                listeDemonTemp = listeMonstreTemp.Cast<Demon>().ToList();
                listeDemonTemp[0].affectation.equipe.Remove(listeDemonTemp[0]);
                listeDemonTemp[0].affectation = null;
            }
        }

        public void PersonnelTriMatricule(bool ascendant) //Tri par matricule
        {
            if (!ascendant)
            {
                var orderedListDescending = listePersonnel.OrderByDescending(personnel => personnel.matricule);
                listePersonnel = new List<Personnel>(orderedListDescending);

            }
            else
            {
                var orderedList = listePersonnel.OrderBy(personnel => personnel.matricule);
                listePersonnel = new List<Personnel>(orderedList);
            }
        }
        public void PersonnelTriNom(bool ascendant) //Tri par nom
        {
            if (!ascendant)
            {
                var orderedListDescending = listePersonnel.OrderByDescending(personnel => personnel.nom);
                listePersonnel = new List<Personnel>(orderedListDescending);

            }
            else
            {
                var orderedList = listePersonnel.OrderBy(personnel => personnel.nom);
                listePersonnel = new List<Personnel>(orderedList);
            }

        }
        public void PersonnelTriFonction(bool ascendant) //Tri par fonction
        {
            if (!ascendant)
            {
                var orderedListDescending = listePersonnel.OrderByDescending(personnel => personnel.fonction);
                listePersonnel = new List<Personnel>(orderedListDescending);

            }
            else
            {
                var orderedList = listePersonnel.OrderBy(personnel => personnel.fonction);
                listePersonnel = new List<Personnel>(orderedList);
            }
        } 
        public void PersonnelTriPrenom(bool ascendant) //Tri par prénom
        {
            if (!ascendant)
            {
                var orderedListDescending = listePersonnel.OrderByDescending(personnel => personnel.prenom);
                listePersonnel = new List<Personnel>(orderedListDescending);

            }
            else
            {
                var orderedList = listePersonnel.OrderBy(personnel => personnel.prenom);
                listePersonnel = new List<Personnel>(orderedList);
            }
        }
        public void PersonnelTriSexe(bool ascendant) //Tri par sexe
        {
            if (!ascendant)
            {
                var orderedListDescending = listePersonnel.OrderByDescending(personnel => personnel.sexe);
                listePersonnel = new List<Personnel>(orderedListDescending);

            }
            var orderedList = listePersonnel.OrderBy(personnel => personnel.sexe);
            listePersonnel = new List<Personnel>(orderedList);
        }
        public List<Monstre> MonstreTriCagnotte(bool ascendant) //Tri des monstres par cagnotte
        {
            List<Monstre> listeMonstres = ListeMonstres();
            if (!ascendant)
            {
                var orderedListDescending = listeMonstres.OrderByDescending(monstre => monstre.cagnotte);
                listeMonstres = new List<Monstre>(orderedListDescending);
                return listeMonstres;

            }
            else
            {
                var orderedList = listeMonstres.OrderBy(monstre => monstre.cagnotte);
                listeMonstres = new List<Monstre>(orderedList);
                return listeMonstres;
            }

        }
        public void AttractionTriIdentifiant(bool ascendant) //Tri par ID
        {
            if (!ascendant)
            {
                var orderedListDescending = listeAttractions.OrderByDescending(attraction => attraction.identifiant);
                listeAttractions = new List<Attraction>(orderedListDescending);

            }
            else
            {
                var orderedList = listeAttractions.OrderBy(attraction => attraction.identifiant);
                listeAttractions = new List<Attraction>(orderedList);
            }
        }
        public void AttractionTriNom(bool ascendant) //Tri par nom
        {
            if (!ascendant)
            {
                var orderedListDescending = listeAttractions.OrderByDescending(attraction => attraction.nom);
                listeAttractions = new List<Attraction>(orderedListDescending);

            }
            else {
                var orderedList = listeAttractions.OrderBy(attraction => attraction.nom);
                listeAttractions = new List<Attraction>(orderedList);
            }
        }
        public void AttractionTriMaintenance(bool ascendant) //Tri par maintenance
        {
            if (!ascendant)
            {
                var orderedListDescending = listeAttractions.OrderByDescending(attraction => attraction.maintenance);
                listeAttractions = new List<Attraction>(orderedListDescending);

            }
            else
            {
                var orderedList = listeAttractions.OrderBy(attraction => attraction.maintenance);
                listeAttractions = new List<Attraction>(orderedList);
            }
        }
        public void AttractionTriBesoinSpecifique(bool ascendant) //Tri par besoin spécifique
        {
            if (!ascendant)
            {
                var orderedListDescending = listeAttractions.OrderByDescending(attraction => attraction.besoinSpecifique);
                listeAttractions = new List<Attraction>(orderedListDescending);

            }
            else
            {
                var orderedList = listeAttractions.OrderBy(attraction => attraction.besoinSpecifique);
                listeAttractions = new List<Attraction>(orderedList);
            }
        }

        public void SauvegarderFichier() //Sauvegarde sur le PC du CSV final (modifié)
        {
            string adresse = "Final.csv";
            StreamWriter ecriture = new StreamWriter(adresse);
            for(int i=0; i<listeAttractions.Count; i++) //Ecrit l'ensemble des attractions
            {
                ecriture.WriteLine(listeAttractions[i].ToString()); 
            }
            foreach(var substring in listePersonnel) //Ecrit l'ensemble du personnel
            {
                ecriture.WriteLine(substring);
            }
            ecriture.Close();
            Console.WriteLine("Fichier créé: " + adresse);
        }
        
        public void CSVToAdmin(List<string[]> data) //Lecture du fichier CSV, instanciation des éléments et rangement dans leurs listes correspondantes
        {
            List<Boutique> listeBoutique = new List<Boutique>();
            List<DarkRide> listeDarkRide = new List<DarkRide>();
            List<RollerCoaster> listeRollerCoaster = new List<RollerCoaster>();
            List<Spectacle> listeSpectacle = new List<Spectacle>();
            List<Sorcier> listeSorcier = new List<Sorcier>();
            List<Monstre> listeMonstre = new List<Monstre>();
            List<Demon> listeDemon = new List<Demon>();
            List<Fantome> listeFantome = new List<Fantome>();
            List<LoupGarou> listeLoupGarou = new List<LoupGarou>();
            List<Vampire> listeVampire = new List<Vampire>();
            List<Zombie> listeZombie = new List<Zombie>();

            List<Monstre> listNeant = new List<Monstre>();
            Boutique neant = new Boutique(TypeBoutique.nourriture, false, listNeant, 0, 0, "neant", ""); //Affectée à tous les monstres sans attraction

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i][0] == "Boutique")
                {
                    TypeBoutique type;
                    bool besoinSpecifique;
                    if (data[i][6] == "souvenir")
                    {
                        type = TypeBoutique.souvenir;
                    }
                    else if (data[i][6] == "barbeAPapa")
                    {
                        type = TypeBoutique.barbeAPapa;
                    }
                    else
                    {
                        type = TypeBoutique.nourriture;
                    }
                    if (data[i][4] == "false" || data[i][4] == "False")
                    {
                        besoinSpecifique = false;
                    }
                    else { besoinSpecifique = true; }
                    List<Monstre> equipe = new List<Monstre>();
                    int ID = int.Parse(data[i][1]);
                    int nbMinMonstre = int.Parse(data[i][3]);
                    string nom = data[i][2];
                    string typeBesoin = data[i][5];
                    Boutique boutique = new Boutique(type, besoinSpecifique, equipe, ID, nbMinMonstre, nom, typeBesoin);
                    listeBoutique.Add(boutique);
                }
                
                if (data[i][0] == "DarkRide")
                {
                    int ID = int.Parse(data[i][1]);
                    string nom = data[i][2];
                    int nbMonstre = int.Parse(data[i][3]);
                    bool besoinSpecifique;
                    if (data[i][4] == "false" || data[i][4] == "False")
                    {
                        besoinSpecifique = false;
                    }
                    else { besoinSpecifique = true; }
                    string typeBesoin = data[i][5];
                    TimeSpan duree = TimeSpan.Parse(data[i][6]);
                    bool vehicule;
                    if (data[i][6] == "false" || data[i][6] == "False")
                    {
                        vehicule = false;
                    }
                    else { vehicule = true; }
                    List<Monstre> equipe = new List<Monstre>();
                    DarkRide darkRide = new DarkRide(duree, vehicule, besoinSpecifique, equipe, ID, nbMonstre, nom, typeBesoin);
                    listeDarkRide.Add(darkRide);
                }
                if (data[i][0] == "RollerCoaster")
                {
                    int ageMinimum = int.Parse(data[i][7]);
                    TypeCategorie type;
                    bool besoinSpecifique;
                    if (data[i][6] == "assise")
                    {
                        type = TypeCategorie.assise;
                    }
                    else if (data[i][6] == "inversee")
                    {
                        type = TypeCategorie.inversee;
                    }
                    else
                    {
                        type = TypeCategorie.bobsleigh;
                    }
                    float tailleMinimum = float.Parse(data[i][8]);
                    if (data[i][4] == "false" || data[i][4] == "False")
                    {
                        besoinSpecifique = false;
                    }
                    else { besoinSpecifique = true; }
                    List<Monstre> equipe = new List<Monstre>();
                    int ID = int.Parse(data[i][1]);
                    int nbMinMonstre = int.Parse(data[i][3]);
                    string nom = data[i][2];
                    string typeBesoin = data[i][5];
                    RollerCoaster rollerCoaster = new RollerCoaster(ageMinimum, type, tailleMinimum, besoinSpecifique, equipe, ID, nbMinMonstre, nom, typeBesoin);
                    listeRollerCoaster.Add(rollerCoaster);
                }
                if (data[i][0] == "Spectacle")
                {
                    List<DateTime> horaires = new List<DateTime>();
                    string horaire = data[i][8];
                    string[] tabHoraires = horaire.Split(' ');
                    int count = tabHoraires.Length;
                    //int countChar = tabHoraires[count-1].Length;
                    if(tabHoraires[count-1]=="")
                    {
                        string[] tempTab = new string[count - 2];
                        for(int j=0; j<tempTab.Length; j++)
                        {
                            tempTab[j] = tabHoraires[j];
                        }
                        tabHoraires = tempTab;
                    }
                    foreach (var substring in tabHoraires)
                    {
                        DateTime dateTime = DateTime.ParseExact(substring,"HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                        horaires.Add(dateTime);
                    }
                    int nbPlaces = int.Parse(data[i][7]);
                    string nomSalle = data[i][6];
                    bool besoinSpecifique;
                    if (data[i][4] == "false" || data[i][4] == "False")
                    {
                        besoinSpecifique = false;
                    }
                    else { besoinSpecifique = true; }
                    List<Monstre> equipe = new List<Monstre>();
                    int ID = int.Parse(data[i][1]);
                    int nbMinMonstre = int.Parse(data[i][3]);
                    string nom = data[i][2];
                    string typeBesoin = data[i][5];
                    Spectacle spectacle = new Spectacle(horaires, nbPlaces, nomSalle, besoinSpecifique, equipe, ID, nbMinMonstre, nom, typeBesoin);
                    listeSpectacle.Add(spectacle);
                }
            }

            listeBoutique.ForEach(listeAttractions.Add);
            listeDarkRide.ForEach(listeAttractions.Add);
            listeRollerCoaster.ForEach(listeAttractions.Add);
            listeSpectacle.ForEach(listeAttractions.Add);

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i][0] == "Sorcier")
                {
                    int matricule = int.Parse(data[i][1]);
                    string nom = data[i][2];
                    string prenom = data[i][3];
                    TypeSexe type;
                    if (data[i][4] == "femelle")
                    {
                        type = TypeSexe.femelle;
                    }
                    else if (data[i][4] == "male")
                    {
                        type = TypeSexe.male;
                    }
                    else
                    {
                        type = TypeSexe.autre;
                    }
                    string fonction = data[i][5];
                    Grade grade;
                    if (data[i][6] == "novice")
                    {
                        grade = Grade.novice;
                    }
                    else if (data[i][4] == "mega")
                    {
                        grade = Grade.mega;
                    }
                    else if (data[i][6] == "giga")
                    {
                        grade = Grade.giga;
                    }
                    else
                    {
                        grade = Grade.strata;
                    }
                    List<string> pouvoirs = new List<string>();
                    string pouvoir = data[i][7];
                    string[] tabPouvoirs = pouvoir.Split('-');
                    foreach (var substring in tabPouvoirs)
                    {
                        pouvoirs.Add(substring);
                    }
                    Sorcier sorcier = new Sorcier(pouvoirs, grade, matricule, nom, prenom, type, fonction);
                    listeSorcier.Add(sorcier);
                }
                if (data[i][0] == "Monstre")
                {
                    int matricule = int.Parse(data[i][1]);
                    string nom = data[i][2];
                    string prenom = data[i][3];
                    TypeSexe type;
                    if (data[i][4] == "femelle")
                    {
                        type = TypeSexe.femelle;
                    }
                    else if (data[i][4] == "male")
                    {
                        type = TypeSexe.male;
                    }
                    else
                    {
                        type = TypeSexe.autre;
                    }
                    string fonction = data[i][5];
                    int cagnotte = int.Parse(data[i][6]);
                    Attraction attractionTemp;
                    if (data[i][7] != null && data[i][7] != "neant" && data[i][7] != "parc" && data[i][7] != "" && data[i][7] != "0")
                    {
                        string attract = data[i][7];
                        int attraction = int.Parse(attract);
                        bool flag = false;
                        foreach (var substring in listeAttractions)
                        {
                            if (substring.identifiant == attraction)
                            {
                                attractionTemp = substring;
                                Monstre monstre = new Monstre(attractionTemp, cagnotte, matricule, nom, prenom, type, fonction);
                                listeMonstre.Add(monstre);
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            Monstre monstre = new Monstre(neant, cagnotte, matricule, nom, prenom, type, fonction);
                            listeMonstre.Add(monstre);
                        }
                    }
                    else
                    {
                        Monstre monstre = new Monstre(neant, cagnotte, matricule, nom, prenom, type, fonction);
                        listeMonstre.Add(monstre);
                    }

                }
                if (data[i][0] == "Demon")
                {
                    int matricule = int.Parse(data[i][1]);
                    string nom = data[i][2];
                    string prenom = data[i][3];
                    TypeSexe type;
                    if (data[i][4] == "femelle")
                    {
                        type = TypeSexe.femelle;
                    }
                    else if (data[i][4] == "male")
                    {
                        type = TypeSexe.male;
                    }
                    else
                    {
                        type = TypeSexe.autre;
                    }
                    string fonction = data[i][5];
                    int cagnotte = int.Parse(data[i][6]);
                    int force = int.Parse(data[i][8]);
                    Attraction attractionTemp;
                    if (data[i][7] != null && data[i][7] != "neant" && data[i][7] != "parc" && data[i][7] != "" && data[i][7] != "0")
                    {
                        int attraction = int.Parse(data[i][7]);
                        bool flag = false;
                        foreach (var substring in listeAttractions)
                        {
                            if (substring.identifiant == attraction)
                            {
                                attractionTemp = substring;
                                Demon demon = new Demon(force, attractionTemp, cagnotte, matricule, nom, prenom, type, fonction);
                                listeDemon.Add(demon);
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            Demon demon = new Demon(force, neant, cagnotte, matricule, nom, prenom, type, fonction);
                            listeDemon.Add(demon);
                        }
                    }
                    else
                    {
                        Demon demon = new Demon(force, neant, cagnotte, matricule, nom, prenom, type, fonction);
                        listeDemon.Add(demon);
                    }

                }
                if (data[i][0] == "Fantome")
                {
                    int matricule = int.Parse(data[i][1]);
                    string nom = data[i][2];
                    string prenom = data[i][3];
                    TypeSexe type;
                    if (data[i][4] == "femelle")
                    {
                        type = TypeSexe.femelle;
                    }
                    else if (data[i][4] == "male")
                    {
                        type = TypeSexe.male;
                    }
                    else
                    {
                        type = TypeSexe.autre;
                    }
                    string fonction = data[i][5];
                    int cagnotte = int.Parse(data[i][6]);
                    Attraction attractionTemp;
                    if (data[i][7] != null && data[i][7] != "neant" && data[i][7] != "parc" && data[i][7] != "" && data[i][7] != "0")
                    {
                        int attraction = int.Parse(data[i][7]);
                        bool flag = false;
                        foreach (var substring in listeAttractions)
                        {
                            if (substring.identifiant == attraction)
                            {
                                attractionTemp = substring;
                                Fantome fantome = new Fantome(attractionTemp, cagnotte, matricule, nom, prenom, type, fonction);
                                listeFantome.Add(fantome);
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            Fantome fantome = new Fantome(neant, cagnotte, matricule, nom, prenom, type, fonction);
                            listeFantome.Add(fantome);
                        }
                    }
                    else
                    {
                        Fantome fantome = new Fantome(neant, cagnotte, matricule, nom, prenom, type, fonction);
                        listeFantome.Add(fantome);
                    }
                }
                if (data[i][0] == "LoupGarou")
                {
                    int matricule = int.Parse(data[i][1]);
                    string nom = data[i][2];
                    string prenom = data[i][3];
                    TypeSexe type;
                    if (data[i][4] == "femelle")
                    {
                        type = TypeSexe.femelle;
                    }
                    else if (data[i][4] == "male")
                    {
                        type = TypeSexe.male;
                    }
                    else
                    {
                        type = TypeSexe.autre;
                    }
                    string fonction = data[i][5];
                    int cagnotte = int.Parse(data[i][6]);
                    Attraction attractionTemp;
                    double indiceCruaute = double.Parse(data[i][8]);
                    if (data[i][7] != null && data[i][7] != "neant" && data[i][7] != "parc" && data[i][7] != "" && data[i][7] != "0")
                    {
                        int attraction = int.Parse(data[i][7]);
                        bool flag = false;
                        foreach (var substring in listeAttractions)
                        {
                            if (substring.identifiant == attraction)
                            {
                                attractionTemp = substring;
                                LoupGarou loup = new LoupGarou(indiceCruaute, attractionTemp, cagnotte, matricule, nom, prenom, type, fonction);
                                listeLoupGarou.Add(loup);
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            LoupGarou loup = new LoupGarou(indiceCruaute, neant, cagnotte, matricule, nom, prenom, type, fonction);
                            listeLoupGarou.Add(loup);
                        }
                    }
                    else
                    {
                        LoupGarou loup = new LoupGarou(indiceCruaute, neant, cagnotte, matricule, nom, prenom, type, fonction);
                        listeLoupGarou.Add(loup);
                    }
                }
                if (data[i][0] == "Zombie")
                {
                    int matricule = int.Parse(data[i][1]);
                    string nom = data[i][2];
                    string prenom = data[i][3];
                    TypeSexe type;
                    if (data[i][4] == "femelle")
                    {
                        type = TypeSexe.femelle;
                    }
                    else if (data[i][4] == "male")
                    {
                        type = TypeSexe.male;
                    }
                    else
                    {
                        type = TypeSexe.autre;
                    }
                    string fonction = data[i][5];
                    int cagnotte = int.Parse(data[i][6]);
                    Attraction attractionTemp; CouleurZ couleur; int degreDecomposition = int.Parse(data[i][9]);
                    if (data[i][8] == "grisatre")
                    {
                        couleur = CouleurZ.grisatre;
                    }
                    else
                    {
                        couleur = CouleurZ.bleuatre;
                    }
                    if (data[i][7] != null && data[i][7] != "neant" && data[i][7] != "parc" && data[i][7] != "" && data[i][7] != "0")
                    {
                        int attraction = int.Parse(data[i][7]);
                        bool flag = false;
                        foreach (var substring in listeAttractions)
                        {
                            if (substring.identifiant == attraction)
                            {
                                attractionTemp = substring;
                                Zombie zombie = new Zombie(degreDecomposition, couleur, attractionTemp, cagnotte, matricule, nom, prenom, type, fonction);
                                listeZombie.Add(zombie);
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            Zombie zombie = new Zombie(degreDecomposition, couleur, neant, cagnotte, matricule, nom, prenom, type, fonction);
                            listeZombie.Add(zombie);
                        }
                    }
                    else
                    {
                        Zombie zombie = new Zombie(degreDecomposition, couleur, neant, cagnotte, matricule, nom, prenom, type, fonction);
                        listeZombie.Add(zombie);
                    }
                }
                if (data[i][0] == "Vampire")
                {
                    int matricule = int.Parse(data[i][1]);
                    string nom = data[i][2];
                    string prenom = data[i][3];
                    TypeSexe type;
                    if (data[i][4] == "femelle")
                    {
                        type = TypeSexe.femelle;
                    }
                    else if (data[i][4] == "male")
                    {
                        type = TypeSexe.male;
                    }
                    else
                    {
                        type = TypeSexe.autre;
                    }
                    string fonction = data[i][5];
                    int cagnotte = int.Parse(data[i][6]);
                    Attraction attractionTemp;
                    double indiceLum = double.Parse(data[i][8]);
                    if (data[i][7] != null && data[i][7] != "neant" && data[i][7] != "parc" && data[i][7] != "" && data[i][7] != "0")
                    {
                        int attraction = int.Parse(data[i][7]);
                        bool flag = false;
                        foreach (var substring in listeAttractions)
                        {
                            if (substring.identifiant == attraction)
                            {
                                attractionTemp = substring;
                                Vampire vampire = new Vampire(indiceLum, attractionTemp, cagnotte, matricule, nom, prenom, type, fonction);
                                listeVampire.Add(vampire);
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            Vampire vampire = new Vampire(indiceLum, neant, cagnotte, matricule, nom, prenom, type, fonction);
                            listeVampire.Add(vampire);
                        }
                    }
                    else
                    {
                        Vampire vampire = new Vampire(indiceLum, neant, cagnotte, matricule, nom, prenom, type, fonction);
                        listeVampire.Add(vampire);
                    }

                }
            }

            Console.WriteLine(data.Count + " éléments ajoutés:");
            //Ajout des types particuliers à la liste globale "personnel".
            listeSorcier.ForEach(listePersonnel.Add);
            listeMonstre.ForEach(listePersonnel.Add);
            listeDemon.ForEach(listePersonnel.Add);
            listeFantome.ForEach(listePersonnel.Add);
            listeLoupGarou.ForEach(listePersonnel.Add);
            listeVampire.ForEach(listePersonnel.Add);
            listeZombie.ForEach(listePersonnel.Add);

            foreach (var substring in listeAttractions)
            {
                Console.WriteLine(substring.identifiant + " " + substring.nom + " " + substring.GetType());
            }
            foreach (var substring in listePersonnel)
            {
                Console.WriteLine(substring.matricule + " " + substring.nom + " " + substring.prenom + " " + substring.sexe + " " + substring.fonction + " " + substring.GetType());
            }


        }
    }
}

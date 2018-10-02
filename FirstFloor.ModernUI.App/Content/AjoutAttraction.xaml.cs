using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using FirstFloor.ModernUI.App.Classes;

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for AjoutAttraction.xaml
    /// </summary>
    public partial class AjoutAttraction : UserControl
    {
        double defaultHeight;

        public AjoutAttraction()
        {
            
            InitializeComponent();
            defaultHeight = typeBesoin.Height;
            int x = 0;
            for (x = 0; x <= 72; x++)
            {
                dureeMaintenance.Items.Add(Convert.ToString(x));
            }
            typeAttraction.Items.Add("DarkRide");
            typeAttraction.Items.Add("Boutique");
            typeAttraction.Items.Add("RollerCoaster");
            typeAttraction.Items.Add("Spectacle");
            for (int y = 0; y <= 60; y++)
            {
                duree.Items.Add(Convert.ToString(y));
            }
            for(int a=0; a<=18; a++)
            {
                ageMin.Items.Add(Convert.ToString(a));
            }
            typeBout.Items.Add(TypeBoutique.barbeAPapa);
            typeBout.Items.Add(TypeBoutique.nourriture);
            typeBout.Items.Add(TypeBoutique.souvenir);
            catRoll.Items.Add(TypeCategorie.assise);
            catRoll.Items.Add(TypeCategorie.inversee);
            catRoll.Items.Add(TypeCategorie.bobsleigh);
            for(float b = 1; b<1.80; b+=0.01f)
            {
                tailleMin.Items.Add(Convert.ToString(b));
            }
            for(int c = 0; c<= 300; c+=5)
            {
                nbPlaces.Items.Add(Convert.ToString(c));
            }
        }


        void OnLoaded(object sender, RoutedEventArgs e)
        {
            // select first control on the form
            Keyboard.Focus(this.id);

        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        
        private void EnvoiClick(object sender, RoutedEventArgs e)
        {
            bool flagID = true;
            for(int i=0; i<Administration.listeAttractions.Count; i++)
            {
                if(id.Text == Convert.ToString(Administration.listeAttractions[i].Identifiant))
                {
                    flagID = false;
                }
            }

            if (flagID)
            {
                if (id.Text != null && nom.Text != null)
                {
                    if (ouvertOUI.IsChecked == true ^ ouvertNON.IsChecked == true)
                    {
                        if (exactitude.IsChecked == true)
                        {
                            if (maintenanceOUI.IsChecked == true ^ maintenanceNON.IsChecked == true)
                            {
                                if (maintenanceOUI.IsChecked == true)
                                {
                                    if (dureeMaintenance.Text != null && natureMaintenance.Text != null)
                                    {
                                        try
                                        {
                                            string stringBesoinSpecifique;
                                            if (besoinSpeOUI.IsChecked == true)
                                            {
                                                stringBesoinSpecifique = "1";
                                            }
                                            else
                                            {
                                                stringBesoinSpecifique = "0";
                                            }
                                            string stringDureeMaintenance = dureeMaintenance.Text;
                                            string stringID = id.Text;
                                            //string stringMaintenance;
                                            string stringNatureMaintenance = natureMaintenance.Text;
                                            string stringNbMinMonstre = Convert.ToString(nbSlider.Value);
                                            string stringNom = nom.Text;
                                            string stringOuvert;
                                            if (ouvertOUI.IsChecked == true)
                                            {
                                                stringOuvert = "1";
                                            }
                                            else
                                            {
                                                stringOuvert = "0";
                                            }
                                            string stringTypeDeBesoin = typeBesoin.Text;
                                            string connectionString = "SERVER=35.195.241.250; PORT=3306; DATABASE=zombillenium; UID=root; PASSWORD=abcd1234;";
                                            MySqlConnection connection = new MySqlConnection(connectionString);
                                            connection.Open();
                                            MySqlCommand command = connection.CreateCommand();
                                            command.CommandText = "INSERT INTO zombillenium.attraction (besoinSpecifique, dureeMaintenance, ID, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin) VALUES ('" + stringBesoinSpecifique + "','" + stringDureeMaintenance + "','" + stringID + "','" + "0" + "','" + stringNatureMaintenance + "','" + stringNbMinMonstre + "','" + stringNom + "','" + stringOuvert + "','" + stringTypeDeBesoin + "');";

                                            MySqlDataReader reader;
                                            reader = command.ExecuteReader();



                                            bool boolBesoinSpecifique;
                                            if (besoinSpeOUI.IsChecked == true)
                                            {
                                                boolBesoinSpecifique = true;
                                            }
                                            else
                                            {
                                                boolBesoinSpecifique = false;
                                            }
                                            bool boolOuvert;
                                            if (ouvertOUI.IsChecked == true)
                                            {
                                                boolOuvert = true;
                                            }
                                            else
                                            {
                                                boolOuvert = false;
                                            }
                                            TimeSpan dureeMaint = TimeSpan.FromHours(Convert.ToInt32(dureeMaintenance.Text));
                                            List<Monstre> temp = new List<Monstre>();
                                            int idClass = Convert.ToInt32(id.Text);
                                            int minMonstreClass = Convert.ToInt32(stringNbMinMonstre);
                                            List<Attraction> list1 = new List<Attraction>();
                                            TimeSpan dureeClass = TimeSpan.FromMinutes(Convert.ToInt32(duree.Text));
                                            bool vehicule;
                                            if (vehiculeOUI.IsChecked == true)
                                            {
                                                vehicule = true;
                                            }
                                            else
                                            {
                                                vehicule = false;
                                            }
                                            TypeBoutique typebouti = (TypeBoutique)typeBout.SelectedItem;
                                            int ageMini = Convert.ToInt32(ageMin.Text);
                                            TypeCategorie typeCat = (TypeCategorie)catRoll.SelectedItem;
                                            float tailleMini = float.Parse(tailleMin.Text);
                                            List<DateTime> horaires = new List<DateTime>();
                                            int places = Convert.ToInt32(nbPlaces.Text);

                                            if (typeAttraction.Text == "DarkRide")
                                            {
                                                DarkRide attract1 = new DarkRide(dureeClass, vehicule, boolBesoinSpecifique, dureeMaint, temp, idClass, true, stringNatureMaintenance, minMonstreClass, stringNom, boolOuvert, stringTypeDeBesoin);
                                                list1.Add(attract1);
                                                Console.WriteLine(attract1);
                                            }
                                            else if (typeAttraction.Text == "Boutique")
                                            {

                                                Boutique attract1 = new Boutique(typebouti, boolBesoinSpecifique, dureeMaint, temp, idClass, true, stringNatureMaintenance, minMonstreClass, stringNom, boolOuvert, stringTypeDeBesoin);
                                                list1.Add(attract1);
                                            }
                                            else if (typeAttraction.Text == "RollerCoaster")
                                            {
                                                RollerCoaster attract1 = new RollerCoaster(ageMini, typeCat, tailleMini, boolBesoinSpecifique, temp, idClass, minMonstreClass, stringNom, boolOuvert, stringTypeDeBesoin);
                                                list1.Add(attract1);
                                            }
                                            else
                                            {
                                                Spectacle attract1 = new Spectacle(horaires, places, nomSalle.Text, boolBesoinSpecifique, dureeMaint, temp, idClass, true, stringNatureMaintenance, minMonstreClass, stringNom, boolOuvert, stringTypeDeBesoin);
                                                list1.Add(attract1);
                                            }

                                            //Attraction attract1 = new Attraction(boolBesoinSpecifique, dureeMaint, temp, idClass, true, 
                                            //    stringNatureMaintenance, minMonstreClass, stringNom, boolOuvert, stringTypeDeBesoin);
                                            Administration.listeAttractions.Add(list1[0]);
                                            //Administration.listeAttractions.ForEach(Console.WriteLine);

                                            if (reader.Read())
                                            {
                                                affichage.Text = reader.GetString(0);
                                            }
                                            else affichage.Text = "Attraction ajoutée";


                                            connection.Close();
                                        }
                                        catch
                                        {
                                            MessageBoxResult result = MessageBox.Show("Type de valeur d'entrée incorrect: vérifier le matricule (entier) et le sexe (M, F ou A)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                                            //label1.Content = "Type de valeur d'entrée incorrect: vérifier le matricule (entier) et le sexe (M, F ou A)";
                                        }
                                    }
                                    else
                                    {
                                        affichage.Text = "Informations manquantes. Merci de remplir la durée de maintenance et sa nature.";
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        string stringBesoinSpecifique;
                                        if (besoinSpeOUI.IsChecked == true)
                                        {
                                            stringBesoinSpecifique = "1";
                                        }
                                        else
                                        {
                                            stringBesoinSpecifique = "0";
                                        }
                                        //string stringDureeMaintenance = dureeMaintenance.Text;
                                        string stringID = id.Text;
                                        //string stringMaintenance;
                                        //string stringNatureMaintenance = natureMaintenance.Text;
                                        string stringNbMinMonstre = Convert.ToString(nbSlider.Value);
                                        string stringNom = nom.Text;
                                        string stringOuvert;
                                        if (ouvertOUI.IsChecked == true)
                                        {
                                            stringOuvert = "1";
                                        }
                                        else
                                        {
                                            stringOuvert = "0";
                                        }
                                        string stringTypeDeBesoin = typeBesoin.Text;

                                        try
                                        {
                                            string connectionString = "SERVER=35.195.241.250; PORT=3306; DATABASE=zombillenium; UID=root; PASSWORD=abcd1234;";
                                            MySqlConnection connection = new MySqlConnection(connectionString);
                                            connection.Open();
                                            MySqlCommand command = connection.CreateCommand();
                                            command.CommandText = "INSERT INTO zombillenium.attraction (besoinSpecifique, ID, maintenance, nbMinMonstre, nom, ouvert, typeDeBesoin) VALUES ('" + stringBesoinSpecifique + "','" + stringID + "','" + "0" + "','" + stringNbMinMonstre + "','" + stringNom + "','" + stringOuvert + "','" + stringTypeDeBesoin + "');";

                                            MySqlDataReader reader;
                                            reader = command.ExecuteReader();

                                            if (reader.Read())
                                            {
                                                affichage.Text = reader.GetString(0);
                                            }
                                            else affichage.Text = "Attraction ajoutée";


                                            connection.Close();
                                        }
                                        catch
                                        {
                                            affichage.Text = "Attraction non ajoutée à la base de données.";
                                        }


                                        bool boolBesoinSpecifique;
                                        if (besoinSpeOUI.IsChecked == true)
                                        {
                                            boolBesoinSpecifique = true;
                                        }
                                        else
                                        {
                                            boolBesoinSpecifique = false;
                                        }
                                        bool boolOuvert;
                                        if (ouvertOUI.IsChecked == true)
                                        {
                                            boolOuvert = true;
                                        }
                                        else
                                        {
                                            boolOuvert = false;
                                        }
                                        //TimeSpan dureeMaint = TimeSpan.FromHours(Convert.ToInt32(dureeMaintenance.Text));
                                        List<Monstre> temp = new List<Monstre>();
                                        int idClass = Convert.ToInt32(id.Text);
                                        int minMonstreClass = Convert.ToInt32(stringNbMinMonstre);
                                        List<Attraction> list1 = new List<Attraction>();
                                        TimeSpan dureeClass = TimeSpan.FromMinutes(Convert.ToInt32(duree.Text));
                                        bool vehicule;
                                        if (vehiculeOUI.IsChecked == true)
                                        {
                                            vehicule = true;
                                        }
                                        else
                                        {
                                            vehicule = false;
                                        }
                                        TypeBoutique typebouti = (TypeBoutique)typeBout.SelectedItem;
                                        int ageMini = Convert.ToInt32(ageMin.Text);
                                        TypeCategorie typeCat = (TypeCategorie)catRoll.SelectedItem;
                                        float tailleMini = float.Parse(tailleMin.Text);
                                        List<DateTime> horaires = new List<DateTime>();
                                        int places = Convert.ToInt32(nbPlaces.Text);

                                        if (typeAttraction.Text == "DarkRide")
                                        {
                                            DarkRide attract1 = new DarkRide(dureeClass, vehicule, boolBesoinSpecifique, temp, idClass, minMonstreClass, stringNom, boolOuvert, stringTypeDeBesoin);
                                            list1.Add(attract1);
                                            Console.WriteLine(attract1);
                                        }
                                        else if (typeAttraction.Text == "Boutique")
                                        {

                                            Boutique attract1 = new Boutique(typebouti, boolBesoinSpecifique, temp, idClass, minMonstreClass, stringNom, boolOuvert, stringTypeDeBesoin);
                                            list1.Add(attract1);
                                        }
                                        else if (typeAttraction.Text == "RollerCoaster")
                                        {
                                            RollerCoaster attract1 = new RollerCoaster(ageMini, typeCat, tailleMini, boolBesoinSpecifique, temp, idClass, minMonstreClass, stringNom, boolOuvert, stringTypeDeBesoin);
                                            list1.Add(attract1);
                                        }
                                        else
                                        {
                                            Spectacle attract1 = new Spectacle(horaires, places, nomSalle.Text, boolBesoinSpecifique, temp, idClass, minMonstreClass, stringNom, boolOuvert, stringTypeDeBesoin);
                                            list1.Add(attract1);
                                        }

                                        //Attraction attract1 = new Attraction(boolBesoinSpecifique, dureeMaint, temp, idClass, true, 
                                        //    stringNatureMaintenance, minMonstreClass, stringNom, boolOuvert, stringTypeDeBesoin);
                                        Administration.listeAttractions.Add(list1[0]);

                                        if (affichage.Text != "Attraction non ajoutée à la base de données.")
                                        {
                                            affichage.Text = "Attraction ajoutée.";
                                        }
                                        else
                                        {
                                            affichage.Text = "Attraction ajoutée au programme, mais pas à la base de données MySQL.";
                                        }

                                    }
                                    catch
                                    {
                                        MessageBoxResult result = MessageBox.Show("Type de valeur d'entrée incorrect: vérifier le matricule (entier) et le sexe (M, F ou A)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                                        //label1.Content = "Type de valeur d'entrée incorrect: vérifier le matricule (entier) et le sexe (M, F ou A)";
                                    }
                                }
                            }
                            else
                            {
                                affichage.Text = "Merci d'indiquer si l'attraction est en maintenance.";
                            }
                        }
                        else
                        {
                            affichage.Text = "Merci de confirmer l'exactitude des informations en cochant la case.";
                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                affichage.Text = "Matricule déjà existant. Merci de le changer.";
            }
        }

        private void nbSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {            
           
        }

        private void maintenanceOUI_Checked(object sender, RoutedEventArgs e)
        {
            Maint.Visibility = Visibility.Visible;
            natMaint.Visibility = Visibility.Visible;
            Maint.Height = defaultHeight;
            natMaint.Height = defaultHeight;
            Form.UpdateLayout();
        }

        private void maintenanceNON_Checked(object sender, RoutedEventArgs e)
        {
            Maint.Visibility = Visibility.Hidden;
            natMaint.Visibility = Visibility.Hidden;
            Maint.Height = 0;
            natMaint.Height = 0;
            Form.UpdateLayout();
        }

        private void besoinSpeOUI_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void besoinSpeNON_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void typeAttraction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string text = (sender as ComboBox).SelectedItem as string;
            if (text=="Boutique")
            {
                dure.Visibility = Visibility.Hidden;
                dure.Height = 0;
                vehic.Visibility = Visibility.Hidden;
                vehic.Height = 0;
                ageM.Visibility = Visibility.Hidden;
                ageM.Height = 0;
                nombPlaces.Visibility = Visibility.Hidden;
                nombPlaces.Height = 0;
                nomSall.Visibility = Visibility.Hidden;
                nomSall.Height = 0;
                cateRoll.Visibility = Visibility.Hidden;
                cateRoll.Height = 0;
                typBout.Visibility = Visibility.Visible;
                typeBout.Height = defaultHeight;
                tailMin.Visibility = Visibility.Hidden;
                tailMin.Height = 0;
            }
            if (text == "DarkRide")
            {
                dure.Visibility = Visibility.Visible;
                dure.Height = defaultHeight;
                vehic.Visibility = Visibility.Visible;
                vehic.Height = defaultHeight;
                ageM.Visibility = Visibility.Hidden;
                ageM.Height = 0;
                nombPlaces.Visibility = Visibility.Hidden;
                nombPlaces.Height = 0;
                nomSall.Visibility = Visibility.Hidden;
                nomSall.Height = 0;
                cateRoll.Visibility = Visibility.Hidden;
                cateRoll.Height = 0;
                typBout.Visibility = Visibility.Hidden;
                typBout.Height = 0;
                tailMin.Visibility = Visibility.Hidden;
                tailMin.Height = 0;
            }
            if (text == "Spectacle")
            {
                dure.Visibility = Visibility.Hidden;
                dure.Height = 0;
                vehic.Visibility = Visibility.Hidden;
                vehic.Height = 0;
                ageM.Visibility = Visibility.Hidden;
                vehic.Height = 0;
                nombPlaces.Visibility = Visibility.Visible;
                vehic.Height = defaultHeight;
                nomSall.Visibility = Visibility.Visible;
                nomSall.Height = defaultHeight;
                cateRoll.Visibility = Visibility.Hidden;
                cateRoll.Height = 0;
                typBout.Visibility = Visibility.Hidden;
                typeBout.Height = 0;
                tailMin.Visibility = Visibility.Hidden;
                tailMin.Height = 0;
            }
            if (text == "RollerCoaster")
            {
                dure.Visibility = Visibility.Hidden;
                dure.Height = 0;
                vehic.Visibility = Visibility.Hidden;
                vehic.Height = 0;
                ageM.Visibility = Visibility.Visible;
                ageM.Height = defaultHeight;
                nombPlaces.Visibility = Visibility.Hidden;
                nombPlaces.Height = 0;
                nomSall.Visibility = Visibility.Hidden;
                nomSall.Height = 0;
                cateRoll.Visibility = Visibility.Visible;
                cateRoll.Height = defaultHeight;
                typBout.Visibility = Visibility.Hidden;
                typeBout.Height = 0;
                tailMin.Visibility = Visibility.Hidden;
                tailMin.Height = 0;
            }
            Form.UpdateLayout();

        }
    }
}

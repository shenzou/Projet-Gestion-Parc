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
    /// Interaction logic for ControlsStylesSampleForm.xaml
    /// </summary>
    public partial class ajoutPerso : UserControl
    {

        double defaultHeight;

        public ajoutPerso()
        {
            InitializeComponent();

            defaultHeight = TextLastName.Height;
            this.Loaded += OnLoaded;
           
            typePersonnel.Items.Add("Monstre");
            typePersonnel.Items.Add("Sorcier");
            for(int i=0; i<Administration.listeAttractions.Count; i++)
            {
                affectation.Items.Add(Administration.listeAttractions[i].Nom);
            }
            typeMonstre.Items.Add("");
            typeMonstre.Items.Add("Demon");
            typeMonstre.Items.Add("Fantome");
            typeMonstre.Items.Add("LoupGarou");
            typeMonstre.Items.Add("Vampire");
            typeMonstre.Items.Add("Zombie");

            teint.Items.Add(CouleurZ.bleuatre);
            teint.Items.Add(CouleurZ.grisatre);

            sexe.Items.Add(TypeSexe.male);
            sexe.Items.Add(TypeSexe.femelle);
            sexe.Items.Add(TypeSexe.autre);

            listeGrades.Items.Add(Grade.giga);
            listeGrades.Items.Add(Grade.mega);
            listeGrades.Items.Add(Grade.novice);
            listeGrades.Items.Add(Grade.strata);
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            // select first control on the form
            Keyboard.Focus(this.TextFirstName);
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }


        private void EnvoiClick(object sender, RoutedEventArgs e)
        {
            if (TextFirstName.Text != null && TextLastName != null && TextAddress.Text != null
                && TextCity.Text != null)
            {
                string fonction = TextAddress.Text;
                string matricule = TextCity.Text;
                string prenom = TextFirstName.Text;
                string nom = TextLastName.Text;
                string sexeString;
                if  (sexe.Text == "male") {sexeString = "M"; } else if (sexe.Text == "femelle") { sexeString = "F"; } else sexeString = "A";
                bool flagMatricule = true;

                for(int i=0; i<Administration.listePersonnel.Count; i++)
                {
                    if(matricule==Convert.ToString(Administration.listePersonnel[i].Matricule))
                    {
                        flagMatricule = false;
                    }
                }

                if (flagMatricule)
                {
                    if (exactitude.IsChecked == true)
                    {
                        try
                        {
                            try
                            {
                                string connectionString = "SERVER=35.195.241.250; PORT=3306; DATABASE=zombillenium; UID=root; PASSWORD=abcd1234;";
                                MySqlConnection connection = new MySqlConnection(connectionString);
                                connection.Open();
                                MySqlCommand command = connection.CreateCommand();
                                command.CommandText = "INSERT INTO zombillenium.personnel (fonction, matricule, nom, prenom, sexe) VALUES ('" + fonction + "','" + matricule + "','" + nom + "','" + prenom + "','" + sexeString + "');";

                                MySqlDataReader reader;
                                reader = command.ExecuteReader();

                                if (reader.Read())
                                {
                                    affichage.Text = reader.GetString(0);
                                }
                                else affichage.Text = "Personnel ajouté";


                                connection.Close();
                            }
                            catch
                            {
                                affichage.Text = "Non ajouté à la base de données";
                            }

                            TypeSexe typeSe = (TypeSexe)sexe.SelectedItem;
                            int matriculeInt = Convert.ToInt32(TextCity.Text);
                            Grade typeGrade = (Grade)listeGrades.SelectedItem;
                            string pouvoirs = listePouvoirs.Text;
                            List<string> pouvoirsList = new List<string>();
                            pouvoirsList = pouvoirs.Split(';').ToList();
                            int cagnotteInt = 0;
                            try { cagnotteInt = Convert.ToInt32(cagnotte.Text); } catch { }

                            List<Attraction> affectationListe = new List<Attraction>();
                            for (int i = 0; i < Administration.listeAttractions.Count; i++)
                            {
                                if (affectation.Text == Administration.listeAttractions[i].Nom)
                                {
                                    if (affectation.Text != "néant")
                                    {
                                        affectationListe.Add(Administration.listeAttractions[i]);
                                        break;
                                    }
                                }
                            }

                            int forceInt = 0;
                            try { forceInt = Convert.ToInt32(nbForce.Value); } catch { }

                            double cruauteDouble = 0;
                            try { cruauteDouble = Convert.ToDouble(nbCruaute.Value); } catch { }

                            double luminDouble = 0;
                            try { luminDouble = Convert.ToDouble(nbLumin.Value); } catch { }

                            int decompInt = 0;
                            try { decompInt = Convert.ToInt32(nbDecomp.Value); } catch { }

                            CouleurZ typeTeint = (CouleurZ)teint.SelectedItem;

                            List<Personnel> list1 = new List<Personnel>();

                            if (affectationListe.Count == 0)
                            {
                                if (typePersonnel.Text == "Sorcier")
                                {
                                    Sorcier perso1 = new Sorcier(pouvoirsList, typeGrade, matriculeInt, nom, prenom, typeSe, fonction);
                                    list1.Add(perso1);
                                }
                                else
                                {
                                    if (typeMonstre.Text == "Demon")
                                    {
                                        Demon perso1 = new Demon(forceInt, Administration.listeAttractions[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                        list1.Add(perso1);
                                    }
                                    else if (typeMonstre.Text == "Fantome")
                                    {
                                        Fantome perso1 = new Fantome(Administration.listeAttractions[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                        list1.Add(perso1);
                                    }
                                    else if (typeMonstre.Text == "LoupGarou")
                                    {
                                        LoupGarou perso1 = new LoupGarou(cruauteDouble, Administration.listeAttractions[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                        list1.Add(perso1);
                                    }
                                    else if (typeMonstre.Text == "Vampire")
                                    {
                                        Vampire perso1 = new Vampire(luminDouble, Administration.listeAttractions[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                        list1.Add(perso1);
                                    }
                                    else if (typeMonstre.Text == "Zombie")
                                    {
                                        Zombie perso1 = new Zombie(decompInt, typeTeint, Administration.listeAttractions[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                        list1.Add(perso1);
                                    }
                                    else
                                    {

                                        Monstre perso1 = new Monstre(true, Administration.listeAttractions[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                        list1.Add(perso1);
                                    }
                                }


                            }
                            else
                            {

                                if (typeMonstre.Text == "Demon")
                                {
                                    Demon perso1 = new Demon(forceInt, affectationListe[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                    list1.Add(perso1);
                                }
                                else if (typeMonstre.Text == "Fantome")
                                {
                                    Fantome perso1 = new Fantome(affectationListe[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                    list1.Add(perso1);
                                }
                                else if (typeMonstre.Text == "LoupGarou")
                                {
                                    LoupGarou perso1 = new LoupGarou(cruauteDouble, affectationListe[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                    list1.Add(perso1);
                                }
                                else if (typeMonstre.Text == "Vampire")
                                {
                                    Vampire perso1 = new Vampire(luminDouble, affectationListe[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                    list1.Add(perso1);
                                }
                                else if (typeMonstre.Text == "Zombie")
                                {
                                    Zombie perso1 = new Zombie(decompInt, typeTeint, affectationListe[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                    list1.Add(perso1);
                                }
                                else
                                {
                                    Monstre perso1 = new Monstre(true, affectationListe[0], cagnotteInt, matriculeInt, nom, prenom, typeSe, fonction);
                                    list1.Add(perso1);
                                }
                            }
                            Administration.listePersonnel.Add(list1[0]);
                            if (affichage.Text != "Non ajouté à la base de données")
                            {
                                affichage.Text = "Personnel ajouté";
                            }
                            else
                            {
                                affichage.Text = "Personnel ajouté au programme, mais pas à la base de données MySQL.";
                            }

                        }

                        catch
                        {
                            MessageBoxResult result = MessageBox.Show("Type de valeur d'entrée incorrect: vérifier les informations saisies.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                    else { affichage.Text = "Merci de confirmer l'exactitude des informations en cochant la case."; }
                }
                else
                {
                    affichage.Text = "Ce matricule existe déjà. Merci de le changer.";
                }
            }
            else { affichage.Text = "Veuillez vérifier les informations saisies."; }



        }

        private void typePersonnel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;
            if (text=="Monstre")
            {
                panelMonstres.Visibility = Visibility.Visible;
                panelMonstres.Height = defaultHeight;
                panelGrade.Visibility = Visibility.Hidden;
                panelPouvoirs.Visibility = Visibility.Hidden;
                panelGrade.Height = 0;
                panelPouvoirs.Height = 0;
                panelAffectation.Visibility = Visibility.Visible;
                panelCagnotte.Visibility = Visibility.Visible;
                panelAffectation.Height = defaultHeight;
                panelCagnotte.Height = defaultHeight;
            }
            else
            {
                panelMonstres.Visibility = Visibility.Hidden;
                panelMonstres.Height = 0;
                panelGrade.Visibility = Visibility.Visible;
                panelPouvoirs.Visibility = Visibility.Visible;
                panelGrade.Height = defaultHeight;
                panelPouvoirs.Height = defaultHeight;
                panelAffectation.Visibility = Visibility.Hidden;
                panelCagnotte.Visibility = Visibility.Hidden;
                panelAffectation.Height = 0;
                panelCagnotte.Height = 0;
                panelForce.Visibility = Visibility.Hidden;
                panelForce.Height = 0;
                panelCruaute.Visibility = Visibility.Hidden;
                panelCruaute.Height = 0;
                panelLuminosite.Visibility = Visibility.Hidden;
                panelLuminosite.Height = 0;
                panelTeint.Visibility = Visibility.Hidden;
                panelTeint.Height = 0;
                panelDecomposition.Visibility = Visibility.Hidden;
                panelDecomposition.Height = 0;
            }
        }

        private void sexe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void typeMonstre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;
            if(text=="Demon")
            {
                panelForce.Visibility = Visibility.Visible;
                panelForce.Height = defaultHeight;
                panelCruaute.Visibility = Visibility.Hidden;
                panelCruaute.Height = 0;
                panelLuminosite.Visibility = Visibility.Hidden;
                panelLuminosite.Height = 0;
                panelTeint.Visibility = Visibility.Hidden;
                panelTeint.Height = 0;
                panelDecomposition.Visibility = Visibility.Hidden;
                panelDecomposition.Height = 0;
            }
            else if(text=="LoupGarou")
            {
                panelForce.Visibility = Visibility.Hidden;
                panelForce.Height = 0;
                panelCruaute.Visibility = Visibility.Visible;
                panelCruaute.Height = defaultHeight;
                panelLuminosite.Visibility = Visibility.Hidden;
                panelLuminosite.Height = 0;
                panelTeint.Visibility = Visibility.Hidden;
                panelTeint.Height = 0;
                panelDecomposition.Visibility = Visibility.Hidden;
                panelDecomposition.Height = 0;
            }
            else if(text=="Vampire")
            {
                panelForce.Visibility = Visibility.Hidden;
                panelForce.Height = 0;
                panelCruaute.Visibility = Visibility.Hidden;
                panelCruaute.Height = 0;
                panelLuminosite.Visibility = Visibility.Visible;
                panelLuminosite.Height = defaultHeight;
                panelTeint.Visibility = Visibility.Hidden;
                panelTeint.Height = 0;
                panelDecomposition.Visibility = Visibility.Hidden;
                panelDecomposition.Height = 0;
            }
            else if(text=="Zombie")
            {
                panelForce.Visibility = Visibility.Hidden;
                panelForce.Height = 0;
                panelCruaute.Visibility = Visibility.Hidden;
                panelCruaute.Height = 0;
                panelLuminosite.Visibility = Visibility.Hidden;
                panelLuminosite.Height = 0;
                panelTeint.Visibility = Visibility.Visible;
                panelTeint.Height = defaultHeight;
                panelDecomposition.Visibility = Visibility.Visible;
                panelDecomposition.Height = defaultHeight;
            }
            else
            {
                panelForce.Visibility = Visibility.Hidden;
                panelForce.Height = 0;
                panelCruaute.Visibility = Visibility.Hidden;
                panelCruaute.Height = 0;
                panelLuminosite.Visibility = Visibility.Hidden;
                panelLuminosite.Height = 0;
                panelTeint.Visibility = Visibility.Hidden;
                panelTeint.Height = 0;
                panelDecomposition.Visibility = Visibility.Hidden;
                panelDecomposition.Height = 0;
            }
        }

        private void nbForce_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void nbDecomp_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void nbCruaute_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void nbLumin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}

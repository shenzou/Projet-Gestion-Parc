﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using FirstFloor.ModernUI.App.Classes;
using FirstFloor.ModernUI.Windows;

namespace FirstFloor.ModernUI.App.Content
{
    // taken from MSDN (http://msdn.microsoft.com/en-us/library/system.windows.controls.datagrid.aspx)
    //public enum Sexe { None, New, Processing, Shipped, Received };
    //public class Personnel
    //{
    //    public int Matricule { get; set; }
    //    public string Nom { get; set; }
    //    public string Prenom { get; set; }
    //    public string fonction{ get; set; }
    //    public Sexe Status { get; set; }
    //}


    /// <summary>
    /// Interaction logic for ControlsStylesDataGrid.xaml
    /// </summary>
    public partial class PersonnelDataGrid : UserControl, IContent
    {
        public PersonnelDataGrid()
        {
            InitializeComponent();

            
            DataContext = Administration.listePersonnel;


        }
        Personnel objEmpToEdit;
        //A modifier, problemes d'equipe
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (objEmpToEdit == null)
            {
                MessageBox.Show("Erreur de séléction");
            }
            else if (objEmpToEdit.Matricule== 66655)
            {
                MessageBox.Show("Vous ne pouvez pas licencier Sirius Jefferson");

            }
            else
            {
                if (objEmpToEdit.GetType().IsSubclassOf(typeof(Monstre)) || objEmpToEdit.GetType() == typeof(Monstre))
                { List<Personnel> listPerso = new List<Personnel>() { objEmpToEdit };
                    List<Monstre> listMonstre = new List<Monstre>();
                    listMonstre = listPerso.OfType<Monstre>().ToList();
                    listMonstre[0].Affectation = null;
                }
            
                
                
                
                Administration.listePersonnel.Remove(objEmpToEdit);
                MessageBox.Show("Personnel enlevé");
            }
            
        }
        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objEmpToEdit = DG1.SelectedItem as Personnel;
        }
        public void OnFragmentNavigation(Windows.Navigation.FragmentNavigationEventArgs e)
        {
        }

        public void OnNavigatedFrom(Windows.Navigation.NavigationEventArgs e)
        {
        }

        public void OnNavigatedTo(Windows.Navigation.NavigationEventArgs e)
        {
            DataContext = null;           //setting datacontext empty at first
            DataContext = Administration.listePersonnel;  //and setting it to the static ViewModel i created       
        }

        public void OnNavigatingFrom(Windows.Navigation.NavigatingCancelEventArgs e)
        {
        }


    }

}

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
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for LoremIpsumSplit.xaml
    /// </summary>
    public partial class BDDSplit : UserControl, IContent
    {
        public BDDSplit()
        {
            InitializeComponent();
        }

        public void OnFragmentNavigation(Windows.Navigation.FragmentNavigationEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(Windows.Navigation.NavigationEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(Windows.Navigation.NavigationEventArgs e)
        {
             
            //throw new NotImplementedException();
        }

        public void OnNavigatingFrom(Windows.Navigation.NavigatingCancelEventArgs e)
        {
            throw new NotImplementedException();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bddattract.Refresh();
            bddpers.Refresh();
        }

        private void bddpers_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

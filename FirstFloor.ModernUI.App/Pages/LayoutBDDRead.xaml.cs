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

namespace FirstFloor.ModernUI.App.Pages
{
    /// <summary>
    /// Interaction logic for LayoutSplit.xaml
    /// </summary>
    public partial class LayoutBDDRead : UserControl, IContent
    {
        public LayoutBDDRead()
        {
            InitializeComponent();
        }

        public void OnFragmentNavigation(Windows.Navigation.FragmentNavigationEventArgs e)
        {
        }

        public void OnNavigatedFrom(Windows.Navigation.NavigationEventArgs e)
        {
        }

        public void OnNavigatedTo(Windows.Navigation.NavigationEventArgs e)
        {
        }

        public void OnNavigatingFrom(Windows.Navigation.NavigatingCancelEventArgs e)
        {
        }
    }
}

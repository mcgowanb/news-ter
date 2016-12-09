using System;
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

namespace NewsTer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Article> articles;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }
        private void CloseApp()
        {
            Application.Current.Shutdown();
        }

        private void MenuItemClose_Click(object sender, RoutedEventArgs e)
        {
            CloseApp();
        }

        private void OnCloseCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            CloseApp();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetComboBoxList();
            btnViewArticle.IsEnabled = false;
        }

        public void SetComboBoxList()
        {
            List<NewsSitePairs> list = new List<NewsSitePairs>();
            NewsSitePairs theJournal = new NewsSitePairs("The Journal", Utility.GetWebURI(Utility.WebSites.TheJournal));
            list.Add(theJournal);
            NewsSitePairs dailyEdge = new NewsSitePairs("The Daily Edge", Utility.GetWebURI(Utility.WebSites.TheDailyEdge));
            list.Add(dailyEdge);
            NewsSitePairs the42 = new NewsSitePairs("The 42", Utility.GetWebURI(Utility.WebSites.The42));
            list.Add(the42);

            cbxWebSites.DisplayMemberPath = "_Key";
            cbxWebSites.ItemsSource = list;
        }

        private void btnGetArticles_Click(object sender, RoutedEventArgs e)
        {
            NewsSitePairs selectedURI = cbxWebSites.SelectedItem as NewsSitePairs;
            string URI = (selectedURI != null) ? selectedURI._Value : null;
            if (URI != null)
            {
                XmlParser parser = new XmlParser(URI);
                articles = parser.FetchArticles();
                lbxNewsArticles.ItemsSource = articles;
            }
            else
            {
                String message = "You have not selected a website to load news articles for.\nPlease choose an option and try again";
                MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cbxWebSites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox selecton = sender as ComboBox;
            NewsSitePairs selected = selecton.SelectedItem as NewsSitePairs;
            if (!String.IsNullOrEmpty(selected._Value))
            {
                btnViewArticle.IsEnabled = true;
            }
            else
            {
                btnViewArticle.IsEnabled = false;
            }
        }
    }
}

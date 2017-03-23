using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TweetSharp;

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
            Uri uri = new Uri("http://www.google.ie");
            //wbDisplay.Source = uri;
            SetComboBoxList();
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

        }


        private void cbxWebSites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //NewsSitePairs selectedURI = cbxWebSites.SelectedItem as NewsSitePairs;
            //string URI = (selectedURI != null) ? selectedURI._Value : null;
            //if (URI != null)
            //{
            //    XmlParser parser = new XmlParser(URI);
            //    articles = parser.FetchArticles();
            //    lbxNewsArticles.ItemsSource = articles;
            //}
            //else
            //{
            //    String message = "You have not selected a website to load news articles for.\nPlease choose an option and try again";
            //    MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
        }

        private void lbxNewsArticles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Article article = lbxNewsArticles.SelectedItem as Article;
            //Uri uri = new Uri(article.GUID);
            //if (uri.IsAbsoluteUri)
            //{
            //    System.Diagnostics.Process.Start(article.GUID);
            //}
            //else
            //{
            //    MessageBox.Show("Error with URL, please try again");

            //}
           
        }

        private void btnLoadTweets_Click(object sender, RoutedEventArgs e)
        {
            TwitterFactory tf = new TwitterFactory(
                Properties.Settings.Default.AccessToken,
                Properties.Settings.Default.AccessSecret,
                Properties.Settings.Default.ConsumerKey,
                Properties.Settings.Default.ConsumerSecret,
                Properties.Settings.Default.UserID
                );

            IEnumerable<TwitterStatus> currentTweets = tf.LoadTimeline();
            lbxTweets.ItemsSource = currentTweets;
        }

        private void lbxTweets_MouseClick(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void lbxTweets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TwitterStatus selected = lbxTweets.SelectedItem as TwitterStatus;
            if (selected != null)
            {
                String s = String.Format("{0}{1}", Utility.BASELINE_URL, selected.IdStr);
                wbDisplay.Source = new Uri(s);
            }
        }

        private void WebSiteButton_Checked(object sender, RoutedEventArgs e)
        {
            XmlParser parser = new XmlParser("http://thejournal.ie/feed");
            articles = parser.FetchArticles();
            lbxArticles.ItemsSource = articles;
        }
    }
}

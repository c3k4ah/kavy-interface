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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kavy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<TextBlock> textBlocks = new List<TextBlock>();
        public MainWindow()
        {
            InitializeComponent();
            AddTextBlocks();
            textList.ItemsSource = textBlocks;
        }
        private void AddTextBlocks()
        {
            for (int i = 0; i < 5; i++)
            {
                textBlocks.Add(new TextBlock { Text = $"TextBlock {i + 1}" });
            }
        }

        // ========================= BACKEND IMPLEMENTATIONS ========================
        // ********** clients **********
        private int clientId {get; set;}
        private string nomClient {get; set;}

        private void Message_txtChange(object sender, TextChangedEventArgs e)
        {
            nomClient = SendEventMessage.Text;
           
        }
        public void CreateClients(object sender, RoutedEventArgs e) {
            Clients clients = new Clients();
            clients.create(this.nomClient);
            SendEventMessage.Clear();
        }

        public List<Dictionary<string, object>> findallClients() {
            Clients clients = new Clients();
            return clients.findall();
        }

        public Dictionary<string, object> findoneClients() {
            Clients clients = new Clients();
            return clients.findone(this.clientId);
        }

        public void updateClients(object sender, RoutedEventArgs e) {
            Clients clients = new Clients();
            clients.update(this.nomClient, this.clientId);
        }

        public void deleteClients(object sender, RoutedEventArgs e) {
            Clients clients = new Clients();
            clients.delete(this.clientId);
        }

        // ********** archives **********
        private int archiveId {get; set;}
        private string titreArchive {get; set;}
        private string descriptionArchive {get; set;}
        private int listeIdArchive {get; set;}
        private string searchArchive {get; set;}

        public void createArchives(object sender, RoutedEventArgs e) {
            Archives archives = new Archives();
            archives.create(this.titreArchive, this.descriptionArchive, this.listeIdArchive);
        }

        public List<Dictionary<string, object>> findallArchives() {
            Archives archives = new Archives();
            return archives.Findall();
        }

        public Dictionary<string, object> findoneArchives() {
            Archives archives = new Archives();
            return archives.findone(this.archiveId);
        }

        public List<Dictionary<string, object>> findByListeIdArchives() {
            Archives archives = new Archives();
            return archives.findByListeId(this.listeIdArchive);
        }

        public List<Dictionary<string, object>> findByClientIdArchives() {
            Archives archives = new Archives();
            return archives.findByClientId(this.clientId);
        }

        public List<Dictionary<string, object>> filtreArchives() {
            Archives archives = new Archives();
            return archives.filtre(this.searchArchive);
        }

        public void updateArchives(object sender, RoutedEventArgs e) {
            Archives archives = new Archives();
            archives.update(this.titreArchive, this.descriptionArchive, this.archiveId);
        }

        public void deleteArchives(object sender, RoutedEventArgs e) {
            Archives archives = new Archives();
            archives.delete(this.archiveId);
        }
        // ***********************************
    }
}

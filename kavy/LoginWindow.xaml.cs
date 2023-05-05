using System;
using System.Runtime.Caching;
using System.Windows;

namespace kavy
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private bool isAdmin {get; set;}
        private string nomAuth {get; set;}
        private string passwordAuth {get; set;}

        public void authentifier() {
            Auth auth = new Auth();
            if(this.isAdmin) {
                int response = auth.Admin(this.nomAuth, this.passwordAuth);
                if(response > 0) {
                    Console.WriteLine("Correct !");
                    MemoryCache cache = MemoryCache.Default;
                    cache.Add("adminId", $"{response}", DateTimeOffset.Now.AddMinutes(30));

                    var loginPage = new MainWindow();
                    loginPage.Show();
                    this.Close();
                }
                else Console.WriteLine("Incorrect !");
            }
            else {
                int response = auth.Client(this.nomAuth, this.passwordAuth);
                if(response > 0){
                    Console.WriteLine("Correct !");
                    MemoryCache cache = MemoryCache.Default;
                    cache.Add("clientId", $"{response}", DateTimeOffset.Now.AddMinutes(30));

                    var loginPage = new UserPage();
                    loginPage.Show();
                    this.Close();
                }
                else Console.WriteLine("Incorrect !");
            }
        }
        private void saveCache()
        {
            // Création d'un objet MemoryCache
            MemoryCache cache = MemoryCache.Default;

            // Ajout d'une clé-valeur dans le cache avec une durée de vie de 10 minutes
            cache.Add("adminId", "value", DateTimeOffset.Now.AddMinutes(30));

        }
    }
}

using System;
using System.Runtime.Caching;
using System.Windows;
using System.Windows.Controls;

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

        public void changeAdminValue(object sender, RoutedEventArgs e)
        {
            this.isAdmin = MyToggleButton.IsChecked ?? false;
          

        }
        public void loginClick(object sender, RoutedEventArgs e) 
        {
            
            this.nomAuth = UserName.Text;
            this.passwordAuth = UserPass.Text;

            this.authentifier();
        }
        public void authentifier() {
          
            Auth auth = new Auth();

            if(this.isAdmin) {
                int response = auth.Admin(this.nomAuth, this.passwordAuth);
                if(response > 0) {
                    Console.WriteLine("Correct !");
                    MemoryCache cache = MemoryCache.Default;
                    cache.Add("adminId", $"{response}", DateTimeOffset.Now.AddMinutes(30));
                    UserName.Clear();
                    UserPass.Clear();
                    var adminPage = new MainWindow();
                    adminPage.Show();
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
                    UserName.Clear();
                    UserPass.Clear();
                    var userPage = new UserWindow();
                    userPage.Show();
                    this.Close();
                }
                else Console.WriteLine("Incorrect !");
            }
        }
      
    }
}

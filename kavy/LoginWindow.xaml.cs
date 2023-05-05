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
using System.Windows.Shapes;

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
                    var loginPage = new UserPage();
                    loginPage.Show();
                    this.Close();
                }
                else Console.WriteLine("Incorrect !");
            }
        }
    }
}

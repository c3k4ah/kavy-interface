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

        private void saveCache()
        {
            // Création d'un objet MemoryCache
            MemoryCache cache = MemoryCache.Default;

            // Ajout d'une clé-valeur dans le cache avec une durée de vie de 10 minutes
            cache.Add("key", "value", DateTimeOffset.Now.AddMinutes(10));

        }


    }
}

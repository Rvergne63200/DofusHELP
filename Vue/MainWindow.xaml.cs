using Modele;
using System.Windows;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Jeu Jeu { get; set; } = new Jeu();
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}

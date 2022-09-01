using System.Windows;
using System.Windows.Controls;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour ClassDescribe.xaml
    /// </summary>
    public partial class ClassDescribe : UserControl
    {
        public static readonly DependencyProperty ClasseProperty = DependencyProperty.Register("Classe", typeof(ClasseView), typeof(ClassDescribe));
        public string Classe
        {
            get { return (string)GetValue(ClasseProperty); }
            set { SetValue(ClasseProperty, value); }
        }
        public ClassDescribe()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}

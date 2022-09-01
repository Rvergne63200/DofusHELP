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

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class ClassButton : UserControl
    {
        /// <summary>
        /// DependencyProperty pour la propriété du Control 'ImageSource'
        /// </summary>
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(string), typeof(ClassButton));
        /// <summary>
        /// Propriété 'ImageSource' qui référence les données de la DependencyProperty 'ImageSourceProperty'
        /// </summary>
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        /// <summary>
        /// DependencyProperty pour la propriété du Control 'ClassName'
        /// </summary>
        public static readonly DependencyProperty ClassNameProperty = DependencyProperty.Register("ClassName", typeof(string), typeof(ClassButton));
        /// <summary>
        /// Propriété 'ClassName' qui référence les données de la DependencyProperty 'ClassNameProperty'
        /// </summary>
        public string ClassName
        {
            get { return (string)GetValue(ClassNameProperty); }
            set { SetValue(ClassNameProperty, value); }
        }
        public ClassButton()
        {
            InitializeComponent();
            DataContext = this; //Nécessaire pour le Binding avec le .xaml. Son dataContext est lui-même, donc quand on bind sur une propriété il cherche dans ce fichier
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bonjour");
        }
    }
}

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
    /// Logique d'interaction pour InterfaceEquip.xaml
    /// </summary>
    public partial class InterfaceEquip : UserControl
    {
        public static readonly DependencyProperty ClasseProperty = DependencyProperty.Register("Classe", typeof(ClasseView), typeof(InterfaceEquip));
        public string Classe
        {
            get { return (string)GetValue(ClasseProperty); }
            set { SetValue(ClasseProperty, value); }
        }
        public InterfaceEquip()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}

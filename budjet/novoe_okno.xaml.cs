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

namespace budjet
{
    /// <summary>
    /// Логика взаимодействия для novoe_okno.xaml
    /// </summary>
    public partial class novoe_okno : Window
    {
        public string MyChlen_is_BIG;
        public novoe_okno()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyChlen_is_BIG = Type_text.Text;
            DialogResult = true;
        }
    }
}

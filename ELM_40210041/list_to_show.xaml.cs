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

namespace ELM_40210041
{
    /// <summary>
    /// Interaction logic for list_to_show.xaml
    /// </summary>
    public partial class list_to_show : Window
    {
        public list_to_show()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            list_to_show list_Window = new list_to_show();

            list_Window.Hide();
        }
    }
}

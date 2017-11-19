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

namespace ELM_40210041
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Help_Click(object sender, RoutedEventArgs e)
        {
            //show pop up window with instructions on use
            MessageBox.Show("**How to Use Euston Leisure Messaging**\n\n\n" +
                "SMS: Please enter a valid phone number and type your message in the message field.\n\n" +
                "E-Mail: Please enter a valid email (eg. euston@leisure.com), add a subject and type your message into the message field.\n\n" +
                "Tweet: Please enter a valid Twitter handle (eg. @EustonLeisure) and type your message into the message field" +
                " (Don't forget to  tag us and add hashtags so we can see your tweet!).");
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            // clear the text boxes
            txt_Message.Clear();
            txt_Sender.Clear();
            txt_Subject.Clear();
        }

        private void btn_List_Click(object sender, RoutedEventArgs e)
        {
            // show the second window
            list_to_show list_Window = new list_to_show();
            list_Window.Show();
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

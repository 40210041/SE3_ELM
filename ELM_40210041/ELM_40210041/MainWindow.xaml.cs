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
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace ELM_40210041
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Body body = new Body();
        Sender senders = new Sender(); //just sender wouldnt work 
  
        public MainWindow()
        {
            InitializeComponent();
        }


        private void txt_Sender_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex reg_Tweet = new Regex(@"^@");
            Regex reg_SMS = new Regex(@"\d{11}");
            //Regex reg_Tag = new Regex(@"^#");

            //tweet
            if (reg_Tweet.IsMatch(txt_Sender.Text))
            {
                lbl_Type.Content = "Tweet";
                txt_Sender.MaxLength = 15;
                txt_Message.MaxLength = 140;
                txt_Subject.IsEnabled = false;
            }
            //sms
            else if (reg_SMS.IsMatch(txt_Sender.Text))
            {
                lbl_Type.Content = "SMS Text Message";
                txt_Message.MaxLength = 140;
                txt_Subject.IsEnabled = false;
            }
            //nothing
            else
            {
                lbl_Type.Content = "No Message Type Detected...";
            }

            //email
            try
            {
                MailAddress reg_Email = new MailAddress(txt_Sender.Text);
                lbl_Type.Content = "E-Mail";
                txt_Message.MaxLength = 1028;
                txt_Subject.IsEnabled = true;
                txt_Subject.MaxLength = 20;
            }
            catch
            {

            }

        }


        // help click
        private void btn_Help_Click(object sender, RoutedEventArgs e)
        {
            //show pop up window with instructions on use
            MessageBox.Show("**How to Use Euston Leisure Messaging**\n\n\n" +
                "SMS: Please enter a valid phone number and type your message in the message field.\n\n" +
                "E-Mail: Please enter a valid email (eg. euston@leisure.com), add a subject and type your message into the message field.\n\n" +
                "Tweet: Please enter a valid Twitter handle (eg. @EustonLeisure) and type your message into the message field" +
                " (Don't forget to  tag us and add hashtags so we can see your tweet!).");
        }


        // clear click
        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            // clear the text boxes
            txt_Message.Clear();
            txt_Sender.Clear();
            txt_Subject.Clear();
            lbl_IDgen.Content = "";
            lbl_Type.Content = "No Message Type Detected...";
        }


        // list click
        private void btn_List_Click(object sender, RoutedEventArgs e)
        {
            // show the second window
            list_to_show list_Window = new list_to_show();
            list_Window.Show();
        }


        // submit click
        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            body.Message = txt_Message.Text;
            body.Subject = txt_Subject.Text;
            senders.Sender_ID = txt_Sender.Text;

            MessageBox.Show("What we have: \n" + body.Message + "\n" + body.Subject + "\n" + senders.Sender_ID);
        }
    }
}

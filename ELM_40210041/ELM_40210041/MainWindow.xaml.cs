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
using System.Runtime.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace ELM_40210041
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        Body body = new Body(); 

        public MainWindow()
        {
            InitializeComponent();
        }

        //change the message type
        public void txt_Sender_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex reg_Tweet = new Regex(@"^@");
            Regex reg_SMS = new Regex(@"\d{11}");

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
                lbl_IDgen.Content = "";
            }

            //email
            try
            {
                MailAddress reg_Email = new MailAddress(txt_Sender.Text);
                lbl_Type.Content = "E-Mail";
                txt_Message.MaxLength = 1028;
                txt_Sender.MaxLength = 50;
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
                " (Don't forget to  tag us and add hashtags so we can see your tweet!).\n\n" +
                "Message ID's are generated after submission, and are used as references.");
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

        //generate the id
        public void gen_ID ()
        {
            Random generate = new Random();

            if (lbl_Type.Content == "Tweet")
            {
                int gen_ID = generate.Next(000000000, 999999999);
                lbl_IDgen.Content = "T" + gen_ID;
            }
            else if (lbl_Type.Content == "SMS Text Message")
            {
                int gen_ID = generate.Next(000000000, 999999999);
                lbl_IDgen.Content = "S" + gen_ID;
            }
            else if (lbl_Type.Content == "E-Mail")
            {
                int gen_ID = generate.Next(000000000, 999999999);
                lbl_IDgen.Content = "E" + gen_ID;
            }
            else
            {
                lbl_IDgen.Content = "";
            }
        }

        public void append_Hashtag()
        {
            Regex reg_Tag = new Regex(@"^#");
        }

        public void create_JSON()
        {
            JSON_File json_file = new JSON_File
            {
                SenderID = txt_Sender.Text,
                MessageBody = txt_Message.Text,
                MessageSubject = txt_Subject.Text,
                MessageType = Convert.ToString(lbl_Type.Content),
                MessageID = Convert.ToString(lbl_IDgen.Content) 
            };

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + lbl_IDgen.Content +".txt", JsonConvert.SerializeObject(json_file));
        }


        public void get_JSON()
        {

        }



        // submit click
        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        { 
            body.Message = txt_Message.Text;
            body.Subject = txt_Subject.Text;
            body.Sender_ID = txt_Sender.Text;



            gen_ID();
            create_JSON();

            MessageBox.Show("Message submitted with: \n" +
                "Sender: " + body.Sender_ID + "\n" +
                "Subject: "+ body.Subject + "\n" +
                "Message: " + body.Message);
        }
    }
}

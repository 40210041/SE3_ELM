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
        private void txt_Sender_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex reg_Tweet = new Regex(@"^@");
            Regex reg_SMS = new Regex(@"\d{11}");

            //tweet
            if (reg_Tweet.IsMatch(txt_Sender.Text))
            {
                body.Type = "Tweet";
                lbl_Type.Content = "Tweet";
                txt_Sender.MaxLength = 15;
                txt_Message.MaxLength = 140;
                txt_Subject.IsEnabled = false;
            }
            //sms
            else if (reg_SMS.IsMatch(txt_Sender.Text))
            {
                body.Type = "SMS";
                lbl_Type.Content = "SMS Text Message";
                txt_Sender.MaxLength = 11;
                txt_Message.MaxLength = 140;
                txt_Subject.IsEnabled = false;
            }
            //nothing
            else
            {
                body.Type = "";
                lbl_Type.Content = "No Message Type Detected...";
                lbl_IDgen.Content = "";
            }

            //email
            try
            {
                MailAddress reg_Email = new MailAddress(txt_Sender.Text);
                body.Type = "E-Mail";
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


        //generate the id
        public void gen_ID()
        {
            Random generate = new Random();
            int gen_ID = generate.Next(000000000, 999999999);
            int result = check_BodyType(body.Type, gen_ID);

            if (result == 1)
            {
                lbl_IDgen.Content = "T" + gen_ID;
            }
            else if (result == 2)
            {
                lbl_IDgen.Content = "S" + gen_ID;
            }
            else if (result == 3)
            {
                lbl_IDgen.Content = "E" + gen_ID;
            }
            else
            {
                lbl_IDgen.Content = "";
            }
        }

        public int check_BodyType(string bodyTypeContents, int generated_ID)
        {
            if (bodyTypeContents == "Tweet")
            {
                lbl_IDgen.Content = "T" + generated_ID;
                return 1;
            }
            else if (bodyTypeContents == "SMS")
            {
                lbl_IDgen.Content = "S" + generated_ID;
                return 2;
            }
            else if (bodyTypeContents == "E-Mail")
            {
                lbl_IDgen.Content = "E" + generated_ID;
                return 3;
            }
            else
            {
                lbl_IDgen.Content = "";
                return 4;
            }
        }



        //update the lists
        public void append_Lists()
        {
            lst_Mention.Items.Clear();
            lst_Trending.Items.Clear();

            Regex reg_Tag = new Regex(@"#\S+");
            Regex reg_Men = new Regex(@"@\S+");

            //int count_Tag = 0;
            //int count_Men = 0;

            if (checkType_Tweet(body.Type) == true)
            {
                foreach (Match match in reg_Tag.Matches(txt_Message.Text))
                {
                    //count_Tag += 1;
                    lst_Trending.Items.Add(match.Value);
                    //lst_Trending.Items.Add(count_Tag + ": " + match.Value);
                }

                foreach (Match match in reg_Men.Matches(txt_Message.Text))
                {
                    //count_Men += 1;
                    lst_Mention.Items.Add(match.Value);
                    //lst_Mention.Items.Add(count_Men + ": " + match.Value);
                }
            }
        }
        
        //check if the type is tweet for appending to lists
        public bool checkType_Tweet(string message_Type)
        {
            if (message_Type == "Tweet")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // create json files
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

        //load json files
        public void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            string open_file = AppDomain.CurrentDomain.BaseDirectory + @"\" + txt_jsonload.Text + ".txt";

            if (string.IsNullOrWhiteSpace(txt_jsonload.Text))
            {
                MessageBox.Show("Please enter a Message ID!");
            }
            else if (File.Exists(open_file))
            { 
                JSON_File json_load = JsonConvert.DeserializeObject<JSON_File>(File.ReadAllText(open_file));

                txt_Sender.Text = json_load.SenderID;
                txt_Message.Text = json_load.MessageBody;
                txt_Subject.Text = json_load.MessageSubject;
                lbl_IDgen.Content = json_load.MessageID;
                lbl_Type.Content = json_load.MessageType;

                append_Lists();
            }
            
        }

        // submit click
        public void btn_Submit_Click(object sender, RoutedEventArgs e)
        { 
            body.Message = txt_Message.Text;
            body.Subject = txt_Subject.Text;
            body.Sender_ID = txt_Sender.Text;
            body.Type = Convert.ToString(lbl_Type.Content);

            gen_ID();
            body.Message_ID = Convert.ToString(lbl_IDgen.Content);


            create_JSON();

            append_Lists();

            MessageBox.Show("Message submitted with: \n" +
                "Sender ID: " + body.Message_ID + "\n" +
                "Type: " + body.Type + "\n" +
                "Sender: " + body.Sender_ID + "\n" +
                "Subject: "+ body.Subject + "\n" +
                "Message: " + body.Message);
        }

    }
}

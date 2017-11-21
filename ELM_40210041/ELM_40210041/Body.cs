using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ELM_40210041
{
    public class Body
    {
        private string sender_ID;
        private string type;
        private string subject;
        private string message; //email only
        private string message_ID;

        public string Sender_ID
        {
            get
            {
                return sender_ID;
            }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Please enter a valid ID (Phone Number, E-Mail Address or Twitter Handle)");
                    }
                }

                catch (Exception except_senID)
                {
                    //Show the error message 
                    MessageBox.Show("Error: " + except_senID.Message);
                }
                //Saves the value inputted into the textbox
                sender_ID = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Please enter your message into the message field!");
                    }
                }

                catch (Exception except_mess)
                {
                    MessageBox.Show("Error: " + except_mess.Message);
                }
                message = value;
            }
        }

        public string Message_ID
        {
            get
            {
                return message_ID;
            }
            set
            {
                /*try
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Please enter ")
                    }
                }*/

                message_ID = value;
            }
        }

    }
}

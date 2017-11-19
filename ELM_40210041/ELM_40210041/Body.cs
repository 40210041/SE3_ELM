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
        private string type;
        private string subject;
        private string message; //email only
        private string message_ID;
        private string hashtag;

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

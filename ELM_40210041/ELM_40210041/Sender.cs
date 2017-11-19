using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ELM_40210041
{
    public class Sender
    {
        private string sender_ID;

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

    }
}

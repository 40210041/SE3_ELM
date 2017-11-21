using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace ELM_40210041
{
    public class JSON_File
    {
        private string json_Sender_ID;
        private string json_Type;
        private string json_Subject;
        private string json_Message; //email only
        private string json_Message_ID;
        private string json_Hashtag;

        public string Json_Sender_ID
        {
            get
            {
                return json_Sender_ID;
            }
            set
            {
                json_Sender_ID = value;
            }
        }

        public string Json_Type
        {
            get
            {
                return json_Type;
            }
            set
            {
                json_Type = value;
            }
        }

        public string Json_Subject
        {
            get
            {
                return json_Subject;
            }
            set
            {
                json_Subject = value;
            }
        }

        public string Json_Message
        {
            get
            {
                return json_Message;
            }
            set
            {
                json_Message = value;
            }
        }

        public string Json_Message_ID
        {
            get
            {
                return json_Message_ID;
            }
            set
            {
                json_Message_ID = value;
            }
        }

        public string Json_Hashtag
        {
            get
            {
                return json_Hashtag;
            }
            set
            {
                json_Hashtag = value;
            }
        }

    }
}

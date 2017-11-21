using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace ELM_40210041
{
    public class JSON_File
    {
        private string senderID;
        private string messageType;
        private string messageSubject;
        private string messageBody;
        private string messageID;

        public string SenderID
        {
            get
            {
                return senderID;
            }
            set
            {
                senderID = value;
            }
        }

        public string MessageType
        {
            get
            {
                return messageType;
            }
            set
            {
                messageType = value;
            }
        }

        public string MessageSubject
        {
            get
            {
                return messageSubject;
            }
            set
            {
                messageSubject = value;
            }
        }

        public string MessageBody
        {
            get
            {
                return messageBody;
            }
            set
            {
                messageBody = value;
            }
        }

        public string MessageID
        {
            get
            {
                return messageID;
            }
            set
            {
                messageID = value;
            }
        }

    }
}

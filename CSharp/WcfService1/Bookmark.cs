using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestAPIns
{
    [DataContract]
    public class Bookmark
    {
        
        public Person owner;
        [DataMember]
        public long id;
        [DataMember]
        public string url;
        [DataMember]
        public string description;

        Bookmark()
        {
            id = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
        }
    }
}
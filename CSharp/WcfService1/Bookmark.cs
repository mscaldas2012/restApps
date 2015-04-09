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
        
        public Person Owner;
        [DataMember(Name="id")]
        public long ID;
        [DataMember(Name = "url")]
        public string Url;
        [DataMember(Name = "description")]
        public string Description;

        Bookmark()
        {
            ID = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
        }
    }
}
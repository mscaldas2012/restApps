using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestAPIns
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string Name;
        [DataMember]
        public string Age;
        [DataMember]
        public List<Bookmark> bookmarks;

    } 
}
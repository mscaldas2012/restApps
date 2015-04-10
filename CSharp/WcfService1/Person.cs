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
        [DataMember(Name="id")]
        public int ID;
        [DataMember(Name="name")]
        public string Name;
        [DataMember(Name="age")]
        public string Age;
        [DataMember(Name="bookmarks")]
        public List<Bookmark> Bookmarks;

    } 
}
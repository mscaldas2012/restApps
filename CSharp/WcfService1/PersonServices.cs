using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;

namespace TestAPIns
{
    [AspNetCompatibilityRequirements
       (RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PersonServices : IPersonServices
    {
        List<Person> persons = new List<Person>();
        int personCount = 0;

        public Person CreatePerson(Person createPerson)
        {
            createPerson.ID = (++personCount);
            persons.Add(createPerson);
            return createPerson;
        }
        //This method can filter Person objects by passing a query parameter "name". Ex.: ?name=Yoda
        public List<Person> GetAllPerson()
        {
            string name = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["name"];
            if (name == null || name.Length == 0)
            {
                return persons;
            }
            else
            {
                return persons.FindAll(e => e.Name.Contains(name));
            }
        }

        public Person GetAPerson(string id)
        {
           return persons.FirstOrDefault(e => e.ID ==  Convert.ToInt32(id));
        }

        public Person UpdatePerson(string id, Person updatePerson)
        {
            Person p = GetAPerson(id);
            p.Name = updatePerson.Name;
            p.Age = updatePerson.Age;
            return p;
        }

        public void DeletePerson(string id)
        {
            persons.RemoveAll(e => e.ID == Convert.ToInt32(id));
        }

        #region bookmark sub-services

        public List<Bookmark> getBookmarks(string userId)
        {
            Person p = GetAPerson(userId);
            if (p != null)
            {
                return p.bookmarks;
            }
            else
            {
                return null; //error out!
            }
        }
        public Bookmark getABookmark(string userId, string bmId)
        {
            Person p = GetAPerson(userId);
            if (p!= null) 
            {
                return p.bookmarks.FirstOrDefault(e => e.id == Convert.ToInt64(bmId));
            }
            return null;
        }

        public Bookmark addBookmark(string userId, Bookmark bookmark)
        {
            Person p = GetAPerson(userId);
            List<Bookmark> b = p.bookmarks;
            if (b == null) {
                b = new List<Bookmark>();
            }
             b.Add(bookmark);
             p.bookmarks = b;
             bookmark.owner = p;
             bookmark.id =(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
            return bookmark;
        }

        public Bookmark updateBookmark(string userId, string bmId, Bookmark updateBookmark)
        {
            Person p = GetAPerson(userId);
            //List<Bookmark> b = p.bookmarks;
            Bookmark b = p.bookmarks.FirstOrDefault(e => e.id == Convert.ToInt64(bmId));
            b.url = updateBookmark.url;
            b.description = updateBookmark.description;

            return b;
        }
        public void deleteBookmark(string userId, string bmId)
        {
            Person p = GetAPerson(userId);
            p.bookmarks.RemoveAll(e => e.id == Convert.ToInt64(bmId));
        }

        #endregion 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace TestAPIns
{
    [ServiceContract]
    public interface IPersonServices
    {
        //Had to change the UriTemplate. If using the same as GetAllPerson, it was never POSTing, only using GET.    
        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        Person CreatePerson(Person createPerson);

        [OperationContract]
        [WebGet(UriTemplate = "")]
        List<Person> GetAllPerson();

        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        Person GetAPerson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        Person UpdatePerson(string id, Person updatePerson);

        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void DeletePerson(string id);

        [OperationContract]
        [WebGet(UriTemplate = "{userId}/bookmark")]
        List<Bookmark> getBookmarks(string userId);

        [OperationContract]
        [WebInvoke(UriTemplate = "{userId}/bookmark", Method = "POST")]
        Bookmark addBookmark(string userId, Bookmark bookmark);

        [OperationContract]
        [WebGet(UriTemplate = "{userId}/bookmark/{bmId}")]
        Bookmark getABookmark(string userId, string bmId);

        [OperationContract]
        [WebInvoke(UriTemplate = "{userId}/bookmark/{bmId}", Method = "PUT")]
        Bookmark updateBookmark(string userId, string bmId, Bookmark bookmark);

        [OperationContract]
        [WebInvoke(UriTemplate = "{userId}/bookmark/{bmId}", Method = "DELETE")]
        void deleteBookmark(string userId, string bmId);
        

    }     
}

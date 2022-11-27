using EntityLayer.Request;
using EntityLayer.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StoreCommunication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoreCommServices" in both code and config file together.
    [ServiceContract]
    public interface IStoreCommServices
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
                 BodyStyle = WebMessageBodyStyle.Bare,
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "/RegisterPharmacy")]
        AddPharmacyResponse AddPharmacy(AddPharmacyRequest pharmacy);

        [OperationContract]
        [WebGet(
                 BodyStyle = WebMessageBodyStyle.Bare,
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "/GetPharmacies/{searchTerm}")]
        GetPharmacyResponse GetPharmacies(string searchTerm);
    }
}

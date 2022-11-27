using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using EntityLayer.DTO;

namespace EntityLayer.Response
{
    [DataContract]
    public class AddPharmacyResponse : BaseResponse
    {
        [DataMember(Order = 1)]
        public int PharmacyID { get; set; }

        [DataMember(Order = 2)]
        public bool IsLoggedIn { get; set; }

        [DataMember(Order = 3)]
        public string Token { get; set; }
    }
}

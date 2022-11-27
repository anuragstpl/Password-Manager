using EntityLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EntityLayer.Response
{
    [DataContract]
    public class GetPharmacyResponse : BaseResponse
    {
        [DataMember]
        public List<PharmacyDTO> listPharmacies { get; set; }
    }
}

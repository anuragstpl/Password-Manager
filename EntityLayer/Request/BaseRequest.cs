using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EntityLayer.Request
{
    [DataContract]
    public class BaseRequest
    {
        [DataMember]
        public string AuthToken { get; set; }
    }
}

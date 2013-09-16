using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public decimal Cantidad { get; set; }
    }
}
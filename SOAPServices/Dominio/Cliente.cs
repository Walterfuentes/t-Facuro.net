using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{   [DataContract]
    public class Cliente
    {   [DataMember]
        public int Ruc { get; set; }
        [DataMember]
        public String Nombre { get; set; }
    }
}
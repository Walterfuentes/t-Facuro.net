using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SOAPServices.Dominio
{   
    [DataContract]
    public class ClienteInexistenteError
    {
        [DataMember]
        public int CodigoError { get; set; }
        [DataMember]
        public string MensajeError { get; set; }

    }
}
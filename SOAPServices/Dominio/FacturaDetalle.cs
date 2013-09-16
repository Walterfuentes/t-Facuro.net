using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace SOAPServices.Dominio
{

    [DataContract]
    public class FacturaDetalle
    {
        [DataMember]
        public FacturaDetallePK Pk { get; set; }
        [DataMember]
        public decimal Cantidad { get; set; }
        [DataMember]
        public decimal Subtotal { get; set; }
    }


    [DataContract]
    public class FacturaDetallePK
    {
        [DataMember]
        public int Factura { get; set; }
        [DataMember]
        public Producto Producto { get; set; }

        public override bool Equals(object obj)
        {
            if (Factura == ((FacturaDetallePK)obj).Factura ||
                Producto == ((FacturaDetallePK)obj).Producto)
                return true;
            return false;       
        }

        public override int GetHashCode()
        {
            return Factura;
        }
    }
}
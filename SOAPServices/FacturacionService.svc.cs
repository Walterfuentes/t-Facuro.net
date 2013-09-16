using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOAPServices.Persistencia;
using SOAPServices.Dominio;

namespace SOAPServices
{
     public class FacturacionService : IFacturacionService
    {
         private ClienteDAO clienteDAO = new ClienteDAO();
         private ProductoDAO productoDAO = new ProductoDAO();
         private FacturaDAO facturaDAO = new FacturaDAO();
         private FacturaDetalleDAO facturaDetalleDAO = new FacturaDetalleDAO();

        public Factura Facturar(int rucCliente, List<Item> items)
        {

            Cliente cliente = clienteDAO.Obtener(rucCliente);
            if (cliente == null)
                throw new FaultException<ClienteInexistenteError>(
                    new ClienteInexistenteError()
            {
                CodigoError = 10,
                MensajeError = "EL Cliente con RUC "+ rucCliente+" No Existe",
            });

            Factura factura = new Factura()
            {
                Cliente = cliente,
                Fecha = DateTime.Now,
                Total = 0m,
            };
            factura = facturaDAO.Crear(factura);
            Producto producto = null;
            FacturaDetalle facturadetalle = null;
            decimal total = 0m;
            foreach (Item item in items)
            {
                producto = productoDAO.Obtener(item.Codigo);
                facturadetalle = new FacturaDetalle()
                {

                    Pk = new FacturaDetallePK()
                    {
                        Factura = factura.Numero,
                        Producto = producto
                    },
                    Cantidad = item.Cantidad,
                    Subtotal = item.Cantidad * producto.Precio
                };
                total = total + facturadetalle.Subtotal;
                facturaDetalleDAO.Crear(facturadetalle);   
            }
            factura.Total = total;
            factura = facturaDAO.Modificar(factura);
            return factura;
        }

        public ICollection<Factura> ListarFacturas()
        {
            return facturaDAO.ListarTodos();
        }
    }
}

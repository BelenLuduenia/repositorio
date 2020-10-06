using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA
{
    public class Factura // clase Factura
    {
        #region Propiedades
        // propiedades que tiene la factura y que de alguna manera cuando aprieto nueva factura se tienen que presentar e ir cargando

        public DateTime Fecha;

        public String NumeroFactura = ""; // alt shift para poner lo mismo en las propiedades
        public String Cliente = "";
        public String CUIT = "";

        public decimal Bruto = 0;
        public decimal Iva = 0;
        public decimal Total = 0;


        // esto es un arreglo de un objeto de una clase prograada por mi
        public RngFactura[] listaRngFactura = new RngFactura[10]; // aca defini una nueva propiedad de la clase factura, que es un arreglo de renglones de factura 
        private int indice = 0;


        #endregion


        #region Constructor
        /// <summary>
        /// constructor de objeto de clase factura
        /// </summary>
        /// 
        public Factura() // este metodo se va a ejecutar cuando yo haga el new factura // es mi constructor, lo que hace es llenar algunas cosas
        {
            Fecha = DateTime.Now;// para la fecha automatica
            // todo: numero de la factura nueva
        }


        #endregion

        #region Metodo

        // metodo que adiciona renglon, este es un metodo que adiciona a mi lista de renglones, un renglon nuevo
        public void AddRngfactura(RngFactura rngFacturaObj) // o renglon, ya que puede tener cualquier nombre
        {
            // todo: controlar error de sobrepasar capacidad del arreglo
            listaRngFactura[indice] = rngFacturaObj;

            indice = indice + 1; // el indice me permite incorporar un elemento nuevo 

        }

        public string MuestraRenglones() // me muestra todos los renglones de la factura
        {
            string RenglonesTxt = "";

            for (int i = 0; i < indice; i++)
            {

                RenglonesTxt = RenglonesTxt + listaRngFactura[i].MuestraRenglon() + "\r\n";

            }
            return RenglonesTxt;
        }

        // metodo para calcular IVA
        
        public decimal CalcularIva()
        {
           decimal calciva = 0.21m;
            return Bruto * (calciva);
        }

        // metodo para calcular total

        public decimal CalcularTotal()
        {

            return Bruto + CalcularIva();
        }

       

        #endregion


    }
}

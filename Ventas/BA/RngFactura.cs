using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BA
{
    public class RngFactura
    {
        // definimos las propiedades de la clase RngFactura
        #region Propiedades
        public decimal Cantidad = 0;
        public string Producto = ""; // tiene el valor inicial  vacio
        public decimal Unitario = 0;


        #endregion

        #region Constructor

        #endregion

        #region Metodos

        public decimal Total()
        {
            return Cantidad * Unitario;

        }


        public string MuestraRenglon() // este metodo me muestra un renglon en particular, retorna en la propiedad text del lbl renglon
        {
            return Cantidad.ToString(" #,##0.00") + " - "
                + Producto + "  "
                + Unitario.ToString(" #,##0.00") + "   " 
                + Total().ToString(" #,##0.00");

        }



       
        #endregion


    }

    // cuando ponemos la propiedad del label (txttotales) que pertenece a $ totales, le ponemos read only, controa si se puede cambiar el texto en el control de edicion, en nuestro caso no se puede hacer 

}

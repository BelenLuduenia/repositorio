using BA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FE
{


    // este formulario trabaja con un objeto de la clase factura que esta en el (BA)
    public partial class frmFactura : Form
    {
        #region Propiedades
        // instanciar
        Factura facturaobj; // defino un objeto facturaobj de la clase Factura 0 BA.Factura facturaobj;
        RngFactura rngFacturaObj; // defino un objeto de la clase renglonfactura
        Decimal total = 0;


        #endregion

        #region Constructor

        public frmFactura()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        // primero 
        private void btnnuevafactura_Click(object sender, EventArgs e)
        {
            LimpiarControles(); // llamamos a un metodo que se llama limpar controles
            NuevaFactura(); // llamamos a un metodo que se llama nueva factura

        }
        private void btnconfirmar_Click(object sender, EventArgs e)
        {
            limpiaencabezados();
            //validar datos del encabezado

            if (txtcliente.Text == "" || txtcuit.Text == "" || txtnumero.Text == "") // si en la propiedad text borrado todos los espacios en blanco de principio a final es igual a vacio entonces, 
            {
                lblerrorencabezado.Text = " falta datos del encabezado "; // este lbl no se ve en el formulario pero si no se llenan todos los campos aparece 
                txtnumero.Focus(); // este es un metodo pero que no tiene argumento y lo que hace es poner foco en el txtnumero en este caso.
            }
            else
            {
                // llenar propiedades del encabezado

                facturaobj.NumeroFactura = txtnumero.Text;
                facturaobj.Cliente = txtcliente.Text;
                facturaobj.CUIT = txtcuit.Text;
                facturaobj.Fecha = System.Convert.ToDateTime(txtfecha.Text);// esto me permite modificar la fecha y q no sea si o si la del dia de hoy, puede ser la de ayer

                // continuar 
                lblerrorencabezado.Text = "";
                panelrenglones.Enabled = true;
                txtcantidad.Focus();

            }



        }

        // el  boton cargar producto que se ve  en la factura, tiene como nombre lblnuevorenglon como propidad
        private void btnNuevoRenglon_Click(object sender, EventArgs e)
        {
            rngFacturaObj = new RngFactura(); // inicializo 
            rngFacturaObj.Cantidad = System.Convert.ToDecimal(txtcantidad.Text);
            rngFacturaObj.Producto = txtproducto.Text;
            rngFacturaObj.Unitario = System.Convert.ToDecimal(txtunitario.Text);
            txttotales.Text = rngFacturaObj.Total().ToString("#,##0.0");
            // en la propiedad txttotales, se va a ejecutar un metodo llamado total del objeto rngfacturaobj, este metodo esta en la clase rngfactura
            //  txttotales.Text = system.convert.to string (rngFacturaObj.Total()); es otro ejemplo para poner el to string.

            facturaobj.AddRngfactura(rngFacturaObj); // la factura dentro de su lista va a gregando nuevos renglones

            MuetraRenglones();

            // metodo para calcular Bruto
            bruto();

          
            // el lbl iva, en su propiedad text, toma el valor que  resulte de calcular el metodo (calcularIva), que esta en la clase factura.
            lblIva.Text = facturaobj.CalcularIva().ToString("#,##0.00");

            //el lbl total, en su propiedad text,toma el valor que resulte de calcular el metodo (calcularTotal), que esta en la clase factura.
             lblTotal.Text = facturaobj.CalcularTotal().ToString("#,##0.00");


        }


        #endregion

        #region Metodos
        // metodo limpiar controles para que los txt queden en blanco cada vez que apriete el boton nueva factura.
        private void LimpiarControles()
        {
            //todo:cualquier cosa --- esto sirve para q te deje un mensaje de cosas que tengo q arreglar
            lblBruto.Text = "";
            txtcliente.Text = "";
            txtcuit.Text = "";
            txtfecha.Text = "";
            lblIva.Text = "";
            txtnumero.Text = "";
            lblTotal.Text = "";
            panelrenglones.Enabled = false; // desabilitas el panel renglon hasta que se apriete el boton confirmar 
        }

        // el metodo nueva factura me va a generar un objeto( facturaobj) de clase factura para que empezemos de cero con todos los valores
        private void NuevaFactura()
        // cuando aprieto nueva factura yo quiero que facturaobj se inicialize y sea igual a Factura, entonces cuando pase a new Factura en la clase Factura(BA) se me va a ejecutar un metodo del mismo nombre

        {
            facturaobj = new Factura(); // creo el objeto facturaobj de la clase factura // lo q estoy diciendo es que facturaobj se construya con el constructor de factura.
            txtfecha.Text = facturaobj.Fecha.ToString("dd/MM/yyyyy"); // (" HH:mm") para la hora si quisiera
           

            // todo: ACTUALIZAR NUMERO DE FACTURA

            txtnumero.Focus();
        }

        // metodo para limpiar encabezado

        private void limpiaencabezados() // este metodo me borra los espacios en blanco
        {
            txtcliente.Text = txtcliente.Text.Trim(); // me borra los espacios en blanco de izquierda y derecha (trim)
            txtcuit.Text = txtcuit.Text.Trim();
            txtnumero.Text = txtnumero.Text.Trim();


        }


        // metodo muestra regnglones, lo que hace es darle valor a la propiedad text del label, llamando a un metodo( muesrarenglon) del objeto( rngfacturaobj)
        private void MuetraRenglones()
        {
            // todo: mostrar todos los renglones
            lblRenglon.Text = facturaobj.MuestraRenglones(); //  la propiedad text de lblrenglon, va a llamar a un metodo muestrarenglon del objeto rngfactura, el metodo 
            // muetrarenglon esta en rngfactura 
        }


        // metodo para Bruto
        private void bruto()
        {
            total = total + (rngFacturaObj.Total());
            lblBruto.Text = (total).ToString();

            // ahora mi propiedad Bruto, de la clase factura, toma el valor del label bruto
            facturaobj.Bruto = System.Convert.ToDecimal(lblBruto.Text);
        }

        #endregion

    }

    /*private void Bruto()
        {

            // sumar
            if (lblBruto.Text=="")
            {
                lblBruto.Text = txttotales.Text;
            }
            else
            {
                lblBruto.Text = (Convert.ToDecimal(lblBruto.Text) + rngFacturaObj.Total()).ToString();

            }

            // ahora mi propiedad bruto, de la clase factura, toma el valor del label bruto
            facturaobj.Bruto = System.Convert.ToDecimal(lblBruto.Text);
        }*/



    // ahora mi propiedad bruto, toma el valor del label bruto
    //facturaobj.Bruto = System.Convert.ToDecimal(lblBruto.Text);

    // lbl iva va a ser igual al metodo para sacar el iva y mi propiedad iva toma ese valor
    //lblIva.Text = facturaobj.CalcularIva().ToString();
    //facturaobj.Iva = System.Convert.ToDecimal(lblIva.Text);


    // lbl total va a ser igual al metodo para sacar el total y mi propiedad total toma ese valor

    //lblTotal.Text = facturaobj.CalcularTotal().ToString();
    //facturaobj.Total = System.Convert.ToDecimal(lblTotal.Text);


    // IVA
    // lblIva.Text = ((Convert.ToDecimal(lblBruto.Text) * 21 / 100).ToString());

    //TOTAL
    //  lblTotal.Text = (Convert.ToDecimal(lblBruto.Text) + Convert.ToDecimal(lblIva.Text)).ToString();





}

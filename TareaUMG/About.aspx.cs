using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TareaUMG
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        DataClasses1DataContext dba = new DataClasses1DataContext("");


        protected void BtnGuardar1_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);
                string nombre = TxtNombre.Text;
                decimal costo = decimal.Parse(TxtCosto.Text);
                decimal precio = decimal.Parse(TxtPrecio.Text);
                int stock = int.Parse(TxtStock.Text);

                var st = new PRODUCTOS
                {
                    CODIGO = codigo,
                    NOMBRE = nombre,
                    COSTO = costo,
                    PRECIO = precio,
                    STOCK = stock
                };

                dba.PRODUCTOS.InsertOnSubmit(st);
                dba.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Ingreso de datos');", true);

                cargaDatos1();
                limpiarCarjas1();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }

        }


        protected void BtnActualizar1_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);
                string nombre = TxtNombre.Text;
                decimal costo = decimal.Parse(TxtCosto.Text);
                decimal precio = decimal.Parse(TxtPrecio.Text);
                int stock = int.Parse(TxtStock.Text); ;

                var stupdate = (from producto in dba.PRODUCTOS where producto.CODIGO == codigo select producto).First();
                stupdate.NOMBRE = nombre;
                stupdate.COSTO = costo;
                stupdate.PRECIO = precio;
                stupdate.STOCK = stock;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Actualizado los datos');", true);

                cargaDatos1();
                limpiarCarjas1();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }

        }

        void cargaDatos1()
        {
            var query = from producto in dba.PRODUCTOS select producto;
            VistaProducto.DataSource = query;
            VistaProducto.DataBind();
        }

        void limpiarCarjas1()
        {
            this.TxtCodigo.Text = "";
            this.TxtNombre.Text = "";
            this.TxtCosto.Text = "";
            this.TxtPrecio.Text = "";
            this.TxtStock.Text = "";
            TxtCodigo.Focus();
        }

        protected void chk1_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            CheckBox cd = (CheckBox)VistaProducto.Rows[rowind].FindControl("chk");
            if (cd.Checked == true)
            {
                TxtCodigo.Text = VistaProducto.Rows[rowind].Cells[1].Text;
                TxtNombre.Text = VistaProducto.Rows[rowind].Cells[2].Text;
                TxtCosto.Text = VistaProducto.Rows[rowind].Cells[3].Text;
                TxtPrecio.Text = VistaProducto.Rows[rowind].Cells[4].Text;
                TxtStock.Text = VistaProducto.Rows[rowind].Cells[5].Text;
            }
            else
            {
                this.TxtCodigo.Text = "";
                this.TxtNombre.Text = "";
                this.TxtCosto.Text = "";
                this.TxtPrecio.Text = "";
                this.TxtStock.Text = "";
                TxtCodigo.Focus();
            }
        }

        protected void BtnEliminar1_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);


                var stEliminar = (from producto in dba.PRODUCTOS where producto.CODIGO == codigo select producto).First();
                dba.PRODUCTOS.DeleteOnSubmit(stEliminar);
                dba.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Eliminados los datos');", true);

                cargaDatos1();
                limpiarCarjas1();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void BtnBuscar1_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text != string.Empty)
            {
                var stBuscar = from producto in dba.PRODUCTOS where producto.CODIGO == int.Parse(TxtCodigo.Text) select producto;
                VistaProducto.DataSource = stBuscar;
                VistaProducto.DataBind();
            }
        }

    }
}
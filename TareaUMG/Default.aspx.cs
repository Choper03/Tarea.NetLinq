using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TareaUMG
{
    public partial class _Default : Page
    {
        protected void Page_Load1(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaDatos1();
            }

        }

        DataClasses1DataContext dba = new DataClasses1DataContext("");


        protected void BtnGuardar1_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);
                string nombre = TxtNombre.Text;
                string apellido = TxtApellido.Text;
                string direccion = TxtDireccion.Text;
                decimal saldo = decimal.Parse(TxtSueldo.Text);
                string estado = TxtEstado.Text;

                var st = new PROVEEDORES
                {
                    CODIGO = codigo,
                    NOMBRE = nombre,
                    APELLIDO = apellido,
                    DIRECCION = direccion,
                    SALDO = saldo,
                    ESTADO = estado
                };

                dba.PROVEEDORES.InsertOnSubmit(st);
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
                string apellido = TxtApellido.Text;
                string direccion = TxtDireccion.Text;
                decimal saldo = decimal.Parse(TxtSueldo.Text);

                var stupdate = (from proveedor in dba.PROVEEDORES where proveedor.CODIGO == codigo select proveedor).First();
                stupdate.NOMBRE = nombre;
                stupdate.APELLIDO = apellido;
                stupdate.DIRECCION = direccion;
                stupdate.SALDO = saldo;
                dba.SubmitChanges();

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
            var query = from proveedor in dba.PROVEEDORES select proveedor;
            VistaProveedor.DataSource = query;
            VistaProveedor.DataBind();
        }

        void limpiarCarjas1()
        {
            this.TxtCodigo.Text = "";
            this.TxtNombre.Text = "";
            this.TxtApellido.Text = "";
            this.TxtDireccion.Text = "";
            this.TxtSueldo.Text = "";
            this.TxtEstado.Text = "";
            TxtCodigo.Focus();
        }

        protected void chk1_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            CheckBox cd = (CheckBox)VistaProveedor.Rows[rowind].FindControl("chk");
            if (cd.Checked == true)
            {
                TxtCodigo.Text = VistaProveedor.Rows[rowind].Cells[1].Text;
                TxtNombre.Text = VistaProveedor.Rows[rowind].Cells[2].Text;
                TxtApellido.Text = VistaProveedor.Rows[rowind].Cells[3].Text;
                TxtDireccion.Text = VistaProveedor.Rows[rowind].Cells[4].Text;
                TxtSueldo.Text = VistaProveedor.Rows[rowind].Cells[5].Text;
            }
            else
            {
                this.TxtCodigo.Text = "";
                this.TxtNombre.Text = "";
                this.TxtApellido.Text = "";
                this.TxtDireccion.Text = "";
                this.TxtSueldo.Text = "";
                TxtCodigo.Focus();
            }
        }

        protected void BtnEliminar1_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);


                var stEliminar = (from proveedor in dba.PROVEEDORES where proveedor.CODIGO == codigo select proveedor).First();
                dba.PROVEEDORES.DeleteOnSubmit(stEliminar);
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
                var stBuscar = from proveedor in dba.PROVEEDORES where proveedor.CODIGO == int.Parse(TxtCodigo.Text) select proveedor;
                VistaProveedor.DataSource = stBuscar;
                VistaProveedor.DataBind();
            }
        }
    }
}
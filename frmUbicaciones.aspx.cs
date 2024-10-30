using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace Ubicaciones_JOVT
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        ubicaciones_BLL oUbicacionesBLL;
        ubicaciones_DAL oUbicacionesDal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarUbicaciones();
            }
        }

        //Metodo encargado de listar los datos de la BD en un GRIDVIew
        public void ListarUbicaciones()
        {
            oUbicacionesDal = new ubicaciones_DAL();
            gvUbicaciones.DataSource = oUbicacionesDal.Listar();
            gvUbicaciones.DataBind();
        }


        //Metodo encargado de recolectar los datos de nuestra interfaz
        public ubicaciones_BLL datosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new ubicaciones_BLL();


            //Recolectar datos de la capa de presentación
            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.Ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLat.Text;
            oUbicacionesBLL.Longitud = txtLong.Text;

            return oUbicacionesBLL;
        }

        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDal = new ubicaciones_DAL();
            oUbicacionesDal.Agregar(datosUbicacion());
            ListarUbicaciones();//Para mostrarlo en el GV   
        }

        protected void ModificarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDal = new ubicaciones_DAL();
            oUbicacionesDal.Modificar(datosUbicacion());
            ListarUbicaciones();
        }

        protected void EliminarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDal = new ubicaciones_DAL();
            oUbicacionesDal.Eliminar(datosUbicacion());
            ListarUbicaciones();
        }

        protected void SeleccionarRegistro(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int FilaSeleccionada = int.Parse(e.CommandArgument.ToString());

            txtID.Value = gvUbicaciones.Rows[FilaSeleccionada].Cells[1].Text;
            txtUbicacion.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[2].Text;
            txtLat.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[3].Text;
            txtLong.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[4].Text;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnAgregar.Enabled = true;
        }
    }
}
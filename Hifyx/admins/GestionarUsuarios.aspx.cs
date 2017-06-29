using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admins_GestionarUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnModificar.Visible = false;
        btnGuardar.Visible = false;
        btnNuevo.Visible = true;
        btnAnadir.Visible = false;
        btnEliminar.Visible = false;
        btnCancelar.Visible = false;
        DeshabilitarControles();
        txtDni.Enabled = false;
    }
    protected void gridUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        DeshabilitarControles();
        string StrDni = gridUsuarios.SelectedRow.Cells[1].Text;
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "SELECT id_usuario, email, contrasena, rol, nombre, fecha_expiracion, codigo_actual " + 
            " FROM usuarios WHERE id_usuario = '" + StrDni + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                txtDni.Text = reader.GetString(0);
                txtEmail.Text = reader.GetString(1);
                txtPassword.Text = reader.GetString(2);
                ddlRol.SelectedItem.Selected = false;
                ddlRol.SelectedItem.Text = reader.GetString(3);
                txtNombre.Text = reader.GetString(4);
                if (reader.GetDateTime(5) != null)
                    txtFechaExp.Text = string.Format("{0:MM/dd/yyyy}", reader.GetDateTime(5));
                if (reader.GetSqlString(6) != "" || reader.GetSqlString(6) != null)
                    txtCodigoAct.Text = reader.GetString(6);
            }
            else
            {
                lblMensajes.Text = "No existen registros de esa consulta.";
            }
            reader.Close();
            comando.Dispose();
            conexion.Close();
            btnNuevo.Visible = true;
            btnModificar.Visible = true;
            btnEliminar.Visible = true;
            btnGuardar.Visible = false;
            btnEliminar.Visible = true;
            btnCancelar.Visible = false;
        }
        catch (SqlException ex)
        {
            string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            lblMensajes.Text = StrError;
            return;
        }
        DeshabilitarControles();
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        btnModificar.Visible = false;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        btnAnadir.Visible = true;
        btnEliminar.Visible = false;
        btnCancelar.Visible = true;
        txtDni.Focus();
        ddlRol.DataBind();
        gridUsuarios.SelectedIndex = -1;
        HabilitarControles();
        LimpiarCampos();
        txtDni.Enabled = true;
    }
    protected void btnAnadir_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        String strDni, strEmail, strPassword, strRol, strNombre, strFecha, strCodigo;
        strDni = txtDni.Text;
        strEmail = txtEmail.Text;
        strPassword = txtPassword.Text;
        strRol = ddlRol.SelectedItem.Text;
        strNombre = txtNombre.Text;
        strFecha = txtFechaExp.Text;
        strCodigo = txtCodigoAct.Text;

        if(strDni != "" && strEmail != "" && strPassword != "" && strRol != "" && strNombre != "")
        {
            string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
            string StrComandoSql = "INSERT USUARIOS (id_usuario, email, contrasena, rol, nombre, fecha_expiracion, codigo_actual) VALUES (" +
                    "'" + strDni + "','" + strEmail + "','" + strPassword + "','" + strRol + "','" + strNombre + "', '" + strFecha + "','" + strCodigo + "');";
            try
            {
                SqlConnection conexion = new SqlConnection(StrCadenaConexion);
                SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
                comando.Connection.Open();
                Int32 inRegistrosAfectados = comando.ExecuteNonQuery();
                comando.Connection.Close();
                if (inRegistrosAfectados == 1)
                    lblMensajes.Text = "Registro insertado correctamente.";
                else
                    lblMensajes.Text = "Error al insertar el registro.";
                txtDni.Enabled = true;
                btnNuevo.Visible = true;
                btnAnadir.Visible = false;
                btnModificar.Visible = false;
                btnGuardar.Visible = false;
                btnEliminar.Visible = false;
                btnCancelar.Visible = false;
                gridUsuarios.SelectedIndex = -1;
                LimpiarCampos();
                gridUsuarios.DataBind();
            }
            catch (SqlException ex)
            {
                string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                lblMensajes.Text = StrError;
                return;
            }
            txtDni.Enabled = false;
            DeshabilitarControles();
            gridUsuarios.DataBind();
            gridUsuarios.SelectedIndex = -1;
        } else {
            lblMensajes.Text = "No puede haber ningún campo vacío.";

        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        btnModificar.Visible = false;
        btnGuardar.Visible = true;
        btnNuevo.Visible = false;
        btnAnadir.Visible = false;
        btnEliminar.Visible = false;
        btnCancelar.Visible = true;
        txtEmail.Focus();
        HabilitarControles();
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        String strEmail, strPassword, strRol, strNombre, strFecha, strCodigo;
        strEmail = txtEmail.Text;
        strPassword = txtPassword.Text;
        strRol = ddlRol.SelectedItem.Text;
        strNombre = txtNombre.Text;
        strFecha = txtFechaExp.Text;
        strCodigo = txtCodigoAct.Text;

        if (txtDni.Text != "" && strEmail != "" && strPassword != "" && strRol != "" && strNombre != "")
        {
            string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
            string StrComandoSql = "UPDATE usuarios SET email='" + strEmail + "', contrasena='" + strPassword + 
                "', rol='" + strRol + "', nombre='" + strNombre + "', fecha_expiracion='" + strFecha + "',codigo_actual='" + strCodigo + 
                "' WHERE id_usuario = '" + txtDni.Text + "';";

            try
            {
                SqlConnection conexion = new SqlConnection(StrCadenaConexion);
                SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
                comando.Connection.Open();
                Int32 inRegistrosAfectados = comando.ExecuteNonQuery();
                comando.Connection.Close();
                if (inRegistrosAfectados == 1)
                    lblMensajes.Text = "Registro actualizado correctamente.";
                else
                    lblMensajes.Text = "Error al actualizar el registro.";
                btnModificar.Visible = false;
                btnGuardar.Visible = false;
                btnNuevo.Visible = true;
                btnAnadir.Visible = false;
                btnEliminar.Visible = false;
                btnCancelar.Visible = false;
                gridUsuarios.DataBind();
                ddlRol.DataBind();
                LimpiarCampos();
                DeshabilitarControles();
                gridUsuarios.SelectedIndex = -1;
            }
            catch (SqlException ex)
            {
                string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                lblMensajes.Text = StrComandoSql;
                btnModificar.Visible = false;
                btnGuardar.Visible = false;
                btnNuevo.Visible = true;
                btnAnadir.Visible = false;
                btnEliminar.Visible = false;
                btnCancelar.Visible = false;
                LimpiarCampos();
                DeshabilitarControles();
                gridUsuarios.SelectedIndex = -1;
                return;
            }
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        String strDni;
        strDni = txtDni.Text;
        string StrCadConex = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComSql = "DELETE FROM usuarios WHERE id_usuario='" + strDni + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadConex);
            SqlCommand comando = new SqlCommand(StrComSql, conexion);
            comando.Connection.Open();
            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();
            comando.Connection.Close();
            if (inRegistrosAfectados == 1)
                lblMensajes.Text = "Usuario eliminado correctamente.";
            else
                lblMensajes.Text = "Error al eliminar el usuario.";
            btnModificar.Visible = false;
            btnGuardar.Visible = false;
            btnNuevo.Visible = true;
            btnAnadir.Visible = false;
            btnEliminar.Visible = false;
            btnCancelar.Visible = false;
            ddlRol.DataBind();
            gridUsuarios.DataBind();
            LimpiarCampos();
            gridUsuarios.SelectedIndex = -1;
        }
        catch (SqlException ex)
        {
            string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            lblMensajes.Text = StrError;
            return;
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        btnModificar.Visible = false;
        btnGuardar.Visible = false;
        btnNuevo.Visible = true;
        btnAnadir.Visible = false;
        btnEliminar.Visible = false;
        btnCancelar.Visible = false;
        ddlRol.DataBind();
        LimpiarCampos();
        DeshabilitarControles();
        gridUsuarios.SelectedIndex = -1;
    }
    protected void DeshabilitarControles()
    {
        txtEmail.Enabled = false;
        txtPassword.Enabled = false;
        ddlRol.Enabled = false;
        txtNombre.Enabled = false;
        txtFechaExp.Enabled = false;
        txtCodigoAct.Enabled = false;
    }
    protected void HabilitarControles()
    {
        txtEmail.Enabled = true;
        txtPassword.Enabled = true;
        ddlRol.Enabled = true;
        txtNombre.Enabled = true;
        txtFechaExp.Enabled = true;
        txtCodigoAct.Enabled = true;
    }
    protected void LimpiarCampos()
    {
        txtDni.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
        txtNombre.Text = "";
        txtFechaExp.Text = "";
        txtCodigoAct.Text = "";
    }

    protected void gridUsuarios_PageIndexChanged (object sender, EventArgs e)
    {
        LimpiarCampos();
        gridUsuarios.SelectedIndex = -1;
        DeshabilitarControles();

        btnNuevo.Visible = true;
        btnAnadir.Visible = false;
        btnModificar.Visible = false;
        btnGuardar.Visible = false;
        btnEliminar.Visible = false;
        btnCancelar.Visible = false;
    }
}
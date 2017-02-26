using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_DatosPersonales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDni.Enabled = false;
        btnModificar.Visible = true;
        btnGuardar.Visible = false;
        btnCancelar.Visible = false;
        DeshabilitarControles();
    }

    protected void CargarDatosTexto()
    {
        // String strDni, strEmail, strNombre, strFecha, strCodigo;
        txtDni.Text = (string)(Session["id_usuario"]); //(Convert.ToString(Session["id_usuario"]));
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "SELECT id_usuario, email, nombre, fecha_expiracion, codigo_actual " +
            " FROM usuarios WHERE id_usuario = '" + txtDni.Text + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
//          txtDni.Text = strDni;
//          strEmail = reader.GetString(1);
//          strNombre = reader.GetString(2);
//          strFecha = "Fecha de expiración: " + string.Format("{0:MM/dd/yyyy}", reader.GetDateTime(3)) + ".";
//          strCodigo = reader.GetString(4);
            txtEmail.Text = reader.GetString(1);
            txtNombre.Text = reader.GetString(2);
            txtCodigo.Text = reader.GetString(4);
            FormView1.DataBind();
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
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        btnModificar.Visible = false;
        btnGuardar.Visible = true;
        btnCancelar.Visible = true;
        HabilitarControles();
        CargarDatosTexto();
        txtEmail.Focus();
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        txtDni.Text = (string)(Session["id_usuario"]); //(Convert.ToString(Session["id_usuario"]));
        String strEmail, strNombre, strPass1, strPass2, strNuevoCod;
        strPass1 = txtPass1.Text;
        strPass2 = txtPass2.Text;
        strEmail = txtEmail.Text;
        strNombre = txtNombre.Text;
        strNuevoCod = txtCodigo.Text;

        if (strPass1 == strPass2)
        {
            if (txtDni.Text != "" && strEmail != "" && strPass1 != "" && strNuevoCod != "")
            {
                string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                    Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
                string StrComandoSql = "UPDATE usuarios SET email='" + txtEmail.Text + "', contrasena='" + strPass1 + 
                    "', nombre='" + strNombre + "', codigo_actual='" + strNuevoCod + "' WHERE id_usuario='" + txtDni.Text + "';";
                try
                {
                    SqlConnection conexion = new SqlConnection(StrCadenaConexion);
                    SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
                    comando.Connection.Open();
                    Int32 inRegistrosAfectados = comando.ExecuteNonQuery();
                    comando.Connection.Close();
                    if (inRegistrosAfectados == 1)
                        lblMensajes.Text = "Datos actualizados correctamente.";
                    else
                        lblMensajes.Text = "Error al actualizar los datos.";
                    btnModificar.Visible = true;
                    btnGuardar.Visible = false;
                    btnCancelar.Visible = false;
                    DeshabilitarControles();
                    FormView1.DataBind();
                    CargarDatosTexto();
                    VaciarCamposTexto();
                }
                catch (SqlException ex)
                {
                    string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                    StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                    StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                    lblMensajes.Text = StrComandoSql;
                    btnModificar.Visible = false;
                    btnGuardar.Visible = true;
                    btnCancelar.Visible = true;
                    return;
                }
            } else
            {
                lblMensajes.Text = "Campos requeridos: Email, Pass, Nombre y Código.";
                VaciarCamposTexto();
            }
        }
        else
        {
            lblMensajes.Text = "La contraseña debe coincidir.";
            VaciarCamposTexto();
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        btnModificar.Visible = true;
        btnGuardar.Visible = false;
        btnCancelar.Visible = false;
        DeshabilitarControles();
        VaciarCamposTexto();
    }
    protected void VaciarCamposTexto()
    {
        txtDni.Text = "";
        txtEmail.Text = "";
        txtNombre.Text = "";
        txtPass1.Text = "";
        txtPass2.Text = "";
        txtCodigo.Text = "";
    }
    protected void DeshabilitarControles()
    {
        txtEmail.Enabled = false;
        txtNombre.Enabled = false;
        txtPass1.Enabled = false;
        txtPass2.Enabled = false;
        txtCodigo.Enabled = false;
    }
    protected void HabilitarControles()
    {
        txtEmail.Enabled = true;
        txtNombre.Enabled = true;
        txtPass1.Enabled = true;
        txtPass2.Enabled = true;
        txtCodigo.Enabled = true;
    }
}

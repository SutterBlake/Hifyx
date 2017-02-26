using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDni.Focus();
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        string strDni, strEmail, strNombre, strPassword, strPassword2;
        strDni = txtDni.Text;
        strEmail = txtEmail.Text;
        strNombre = txtNombre.Text;
        strPassword = txtPassword1.Text;
        strPassword2 = txtPassword2.Text;

        if (txtPassword1.Text == txtPassword2.Text && txtPassword1.Text != "")
        {
            if (strDni != "" && strEmail != "" && strNombre != "")
            {
                string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                    Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
                string strComandoSql_1 = "INSERT USUARIOS " + "(id_usuario, email, contrasena, rol, nombre) VALUES (" +
                    "'" + strDni + "','" + strEmail + "','" + strPassword + "','U','" + strNombre + "');";

                SqlConnection conexion = new SqlConnection(StrCadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                SqlTransaction tran = conexion.BeginTransaction();
                comando.Transaction = tran;
                try
                {
                    comando.CommandText = strComandoSql_1;
                    comando.ExecuteNonQuery();
                    tran.Commit();
                    Response.Write("<script>alert('Usuario introducido correctamente.');</script>");
                }
                catch (SqlException ex)
                {
                    tran.Rollback();
                    string StrError = "<p>Se han producido errores durante el registro</p>";
                    StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                    StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                    lblMensajes.Text = StrError;

                    txtDni.Text = "";
                    txtEmail.Text = "";
                    txtNombre.Text = "";
                    txtPassword1.Text = "";
                    txtPassword2.Text = "";
                }
                finally
                {
                    conexion.Close();
                }
            } else
            {
                lblMensajes.Text = "No puede haber ningún campo vacío.";
            }
        }
        else
        {
            lblMensajes.Text = "Se ha producido un error. Valores de contraseña no coincidentes";
        }
    }

    protected void btnVaciar_Click(object sender, EventArgs e)
    {
        txtDni.Text = "";
        txtEmail.Text = "";
        txtNombre.Text = "";
        txtPassword1.Text = "";
        txtPassword2.Text = "";
    }
}
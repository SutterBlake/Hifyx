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
        string strDni, strEmail, strNombre, strPassword, fechaExp;
        strDni = txtDni.Text;
        strEmail = txtEmail.Text;
        strNombre = txtNombre.Text;
        int anyo = DateTime.Now.Year, mes = DateTime.Now.Month+1, dia = DateTime.Now.Day;
        fechaExp = anyo.ToString() + "-" + mes.ToString() + "-" + dia.ToString();

    /*  
    Insertamos la fecha en una variable string, porque si lo hacemos con un constructor 
    nos la crea con delimitadores / , y al insertarlo en la BBDD tienen que ser - .
        fechaExp = Convert.ToString(new DateTime(anyo, mes, dia));
    */
        if (txtPassword1.Text != "" && txtPassword1.Text == txtPassword2.Text)
        {
            strPassword = txtPassword1.Text;
            if (strDni != "" && strEmail != "" && strNombre != "")
            {
                string RutaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" + Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
                string SentenciaSql = "INSERT INTO USUARIOS VALUES ('" + strDni + "','" + strEmail + "','" + strPassword + "','U','" + strNombre + "','" + fechaExp + "','');";
                SqlConnection conexion = new SqlConnection(RutaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                SqlTransaction transac = conexion.BeginTransaction();
                comando.Transaction = transac;
                try
                {
                    comando.CommandText = SentenciaSql;
                    comando.ExecuteNonQuery();
                    transac.Commit();
                    lblMensajes.Text = "<div class='alert alert-info'><strong>" + txtNombre.Text + "</strong>, tu cuenta expira el " + Convert.ToDateTime(fechaExp).ToString("dd / MM / yyyy") + ".</div>";
                    txtDni.Text = "";
                    txtEmail.Text = "";
                    txtNombre.Text = "";
                }
                catch (SqlException exc)
                {
                    transac.Rollback();
                    lblMensajes.Text = "<div class='alert alert-danger'><strong>Se han producido errores durante el registro.</strong><br /><br />" +
                        "<strong>Código:</strong> " + exc.Number + ".<br /><strong>Descripción:</strong> " + exc.Message + ".</div>";
                }
                finally
                {
                    conexion.Close();
                }
            }
            else
            {
                lblMensajes.Text = "<p>Los siguientes campos son obligatorios:</p>" + "<ul><li>DNI</li><li>Email</li><li>Nombre</li></ul>";
                txtPassword1.Text = strPassword;
                txtPassword2.Text = strPassword;
            }
        }
        else
            lblMensajes.Text = "Las contraseñas deben coincidir.";
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
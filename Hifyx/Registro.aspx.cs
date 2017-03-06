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
    protected void CamposRequeridos()
    {
    }
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        string strDni, strEmail, strNombre, strPassword, fechaExp;
        strDni = txtDni.Text;
        strEmail = txtEmail.Text;
        strNombre = txtNombre.Text;
        strPassword = txtPassword1.Text;
        int anyo = DateTime.Now.Year, mes = DateTime.Now.Month+1, dia = DateTime.Now.Day;
        fechaExp = anyo.ToString() + "-" + mes.ToString() + "-" + dia.ToString();
/*  
    Insertamos la fecha en una variable string, porque si lo hacemos con un constructor 
    nos la crea con delimitadores / , y al insertarlo en la BBDD tienen que ser - .
        fechaExp = Convert.ToString(new DateTime(anyo, mes, dia));
*/
        if (strDni != "" && strEmail != "" && strNombre != "")
        {
            if (strPassword != "" && strPassword == txtPassword2.Text)
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
                    lblMensajes.Text = "Usuario " + txtNombre.Text + ", tu cuenta expira el día " + Convert.ToDateTime(fechaExp).ToString("dd/MM/yyyy") + ".";
                    txtDni.Text = "";
                    txtEmail.Text = "";
                    txtNombre.Text = "";
                    Session["registrado"] = strDni;
                    Response.Redirect("~/Login.aspx");
                }
                catch (SqlException exc)
                {
                    transac.Rollback();
                    lblMensajes.Text = "<p>Se han producido errores durante el registro</p><div>Código: " + exc.Number + "</div><div>Descripción: " + exc.Message + "</div>";
                }
                finally
                {
                    conexion.Close();
                }
            }
            else
            {
                lblMensajes.Text = "<div>Campos obligatorios: DNI, Email, Nombre</div>";
                txtPassword1.Text = strPassword;
                txtPassword2.Text = strPassword;
            }
        }
        else
        {
            CamposRequeridos();
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
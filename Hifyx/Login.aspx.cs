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
        if(Session["registrado"] != null)
        {
            Login1.UserName = Session["registrado"].ToString();
            Session.Remove("registrado");
        }
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        DateTime fechaAct = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "SELECT id_usuario, rol, nombre, fecha_expiracion FROM USUARIOS ";
        StrComandoSql = StrComandoSql + " WHERE id_usuario='" + Login1.UserName + "' ";
        StrComandoSql = StrComandoSql + "AND contrasena='" + Login1.Password + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                Session.Add("id_usuario", reader.GetString(0));
                Session.Add("rol", reader.GetString(1));
                Session.Add("nombre", reader.GetString(2));
                Session.Add("fechaExp", Convert.ToString(reader.GetDateTime(3)));
                e.Authenticated = true;
                reader.Close();
                comando.Dispose();
                conexion.Close();
                if (Convert.ToString(Session["rol"]) == "A")
                    Response.Redirect("~/admins/Default.aspx");
                if (Convert.ToString(Session["rol"]) == "U")
                {
                    if (Convert.ToDateTime(Session["fechaExp"]) < System.DateTime.Now)
                    {
                        //Response.Write("<script>alert('Tu codigo ha caducado. Introduce uno nuevo en tu perfil.');</script>");
                        Session["caducado"] = true;
                    }
                    Response.Redirect("~/users/Default.aspx");
                }
            }
            else
            {
                e.Authenticated = false;
                reader.Close();
                comando.Dispose();
                conexion.Close();
            }
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
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class users_Videos : System.Web.UI.Page
{
    String strPelicula;

    protected void Page_Load(object sender, EventArgs e)
    {
        HabDeshabBoton();
    }
    protected void CargarDatosTexto()
    {
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "SELECT titulo, director, genero, anyo, sinopsis, url, id_video " +
            " FROM videos WHERE titulo = '" + strPelicula + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            txtTitulo.Text = reader.GetString(0);
            txtDirector.Text = reader.GetString(1);
            txtGenero.Text = reader.GetString(2);
            txtAnyo.Text = reader.GetInt32(3).ToString();
            txtSinopsis.Text = reader.GetString(4);
            Session["urlPelicula"] = reader.GetString(5);
            Session["idPelicula"] = reader.GetInt32(6);
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
    protected void HabDeshabBoton()
    {
        lblMensajes.Text = "";
        if (gridVideos.SelectedIndex >= 0)
        {
            btnAbrirEnlace.Visible = true;
            btnAgregarFavs.Visible = true;
        }
        else
        {
            btnAbrirEnlace.Visible = false;
            btnAgregarFavs.Visible = false;
        }
    }
    protected void VaciarDatos()
    {
        txtTitulo.Text = "";
        txtDirector.Text = "";
        txtGenero.Text = "";
        txtAnyo.Text = "";
        txtSinopsis.Text = "";
    }
    protected void gridVideos_SelectedIndexChanged(object sender, EventArgs e)
    {
        strPelicula = gridVideos.SelectedRow.Cells[1].Text;
        CargarDatosTexto();
        HabDeshabBoton();
    }
    protected void btnAbrirEnlace_Click(object sender, EventArgs e)
    {
        HabDeshabBoton();
        Response.Redirect(Convert.ToString(Session["urlPelicula"]));
    }
    protected void btnAgregarFavs_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "INSERT INTO videos_repro VALUES ('" + Session["idPelicula"] + "', '" + 
            (Convert.ToString(Session["id_usuario"])) + "', '" + fechaActual + "');";

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();
            comando.Connection.Close();
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
            {
                lblMensajes.Text = "¡Ya tienes este vídeo en tu lista de favoritos!";
            }
            else
            {
                string StrError = "<p>Se han producido errores en el acceso a la base de datos de vídeos.</p>";
                StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                lblMensajes.Text = StrError;
                return;
            }
        }
    }


    protected void gridVideos_PageIndexChanged(object sernder, EventArgs e)
    {
        VaciarDatos();
        gridVideos.SelectedIndex = -1;
        HabDeshabBoton();
    }
}
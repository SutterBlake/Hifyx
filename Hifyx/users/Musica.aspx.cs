using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_Musica : System.Web.UI.Page
{
    string strCancion;

    protected void Page_Load(object sender, EventArgs e)
    {
        HabDeshabBoton();
    }
    protected void CargarDatosTexto()
    {
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "SELECT titulo, grupo, album, genero, anyo, discografica, url, id_cancion " +
            " FROM canciones WHERE titulo = '" + strCancion + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            txtTitulo.Text = reader.GetString(0);
            txtGrupo.Text = reader.GetString(1);
            txtAlbum.Text = reader.GetString(2);
            txtGenero.Text = reader.GetString(3);
            txtAnyo.Text = (Convert.ToString(reader.GetInt32(4)));
            txtDiscografica.Text = reader.GetString(5);
            Session["urlCancion"] = reader.GetString(6);
            Session["idCancion"] = reader.GetInt32(7);
            HabDeshabBoton();
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
        if (gridMusica.SelectedIndex >= 0)
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
        txtGrupo.Text = "";
        txtAlbum.Text = "";
        txtGenero.Text = "";
        txtAnyo.Text = "";
        txtDiscografica.Text = "";
    }
    protected void gridMusica_SelectedIndexChanged(object sender, EventArgs e)
    {
        strCancion = gridMusica.SelectedRow.Cells[1].Text;
        CargarDatosTexto();
        HabDeshabBoton();
    }
    protected void btnAbrirEnlace_Click(object sender, EventArgs e)
    {
        HabDeshabBoton();
        Response.Redirect(Convert.ToString(Session["urlCancion"]));
    }
    protected void btnAgregarFavs_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "INSERT INTO canciones_repro VALUES ('" + Session["idCancion"] + "', '" +
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
                lblMensajes.Text = "¡Ya tienes esta canción en tu lista de favoritos!";
            }
            else
            {
                string StrError = "<p>Se han producido errores en el acceso a la base de datos de canciones.</p>";
                StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                lblMensajes.Text = StrError;
                return;
            }
        }
    }


    protected void gridMusica_PageIndexChanged(object sender, EventArgs e)
    {
        VaciarDatos();
        gridMusica.SelectedIndex = -1;
        HabDeshabBoton();
    }
}
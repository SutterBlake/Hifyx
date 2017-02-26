using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_Favoritos : System.Web.UI.Page
{
    string strTitulo, strElemento, strUrl;
    int strIdElemento;

    protected void Page_Load(object sender, EventArgs e)
    {
        DeshabilitarBotones();
    }
    protected void HabilitarBotones()
    {
        btnReproducir.Visible = true;
        btnQuitarFavs.Visible = true;
    }
    protected void DeshabilitarBotones()
    {
        btnReproducir.Visible = false;
        btnQuitarFavs.Visible = false;
    }
    protected void DefinirIdVideo()
    {
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "SELECT id_video FROM videos WHERE titulo='" + Convert.ToString(Session["titElemento"]) + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            Session["idElemento"] = reader.GetInt32(0);
            reader.Close();
            comando.Dispose();
            conexion.Close();
        }
        catch (SqlException)
        {

        }
    }
    protected void BorrarVideo()
    {
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "DELETE FROM videos_repro WHERE id_video=" + Session["idElemento"] + " AND usuario='" + Convert.ToString(Session["id_usuario"]) + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            comando.Connection.Open();
            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();
            comando.Connection.Close();
            gridVideos.DataBind();
            gridVideos.SelectedIndex = -1;
        }
        catch (SqlException ex)
        {
            string StrError = "<p>Se han producido errores en el acceso a la base de datos de vídeos.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            lblMensajes.Text = StrError;
            return;
        }
    }
    protected void DefinirIdCancion()
    {
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "SELECT id_cancion FROM canciones WHERE titulo='" + Convert.ToString(Session["titElemento"]) + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            Session["idElemento"] = reader.GetInt32(0);
            reader.Close();
            comando.Dispose();
            conexion.Close();
        }
        catch (SqlException)
        {

        }
    }
    protected void BorrarCancion()
    {
        DefinirIdCancion();

        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "DELETE FROM canciones_repro WHERE id_cancion=" + Session["idElemento"] + " AND usuario='" + Convert.ToString(Session["id_usuario"]) + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            comando.Connection.Open();
            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();
            comando.Connection.Close();
            gridCanciones.DataBind();
            gridCanciones.SelectedIndex = -1;
        }
        catch (SqlException ex)
        {
            string StrError = "<p>Se han producido errores en el acceso a la base de datos de canciones.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            lblMensajes.Text = StrError;
            return;
        }
    }
    protected void gridVideos_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        gridCanciones.SelectedIndex = -1;
        Session["titElemento"] = gridVideos.SelectedRow.Cells[1].Text;
        HabilitarBotones();
    }
    protected void gridCanciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        gridVideos.SelectedIndex = -1;
        Session["titElemento"] = gridCanciones.SelectedRow.Cells[1].Text;
        HabilitarBotones();
    }
    protected void btnQuitarFavs_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        if (gridVideos.SelectedIndex != -1)
        {
            DefinirIdVideo();
            BorrarVideo();
            gridVideos.DataBind();
        }
        if (gridCanciones.SelectedIndex != -1)
        {
            DefinirIdCancion();
            BorrarCancion();
            gridCanciones.DataBind();
        }
    }
    protected void gridVideos_PageIndexChanged(object sender, EventArgs e)
    {
        gridVideos.SelectedIndex = -1;
        DeshabilitarBotones();
    }
    protected void gridCanciones_PageIndexChanged(object sender, EventArgs e)
    {
        gridCanciones.SelectedIndex = -1;
        DeshabilitarBotones();
    }
    protected void btnReproducir_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
               Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql;

        if (gridCanciones.SelectedIndex != -1)
        {
            DefinirIdCancion();
            StrComandoSql = "SELECT url FROM canciones WHERE id_cancion='" + Session["idElemento"] + "';";
            try
            {
                SqlConnection conexion = new SqlConnection(StrCadenaConexion);
                SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                Session["urlElemento"] = reader.GetString(0);
                reader.Close();
                conexion.Close();
            }
            catch (SqlException ex)
            {
                string StrError = "<p>Se han producido errores en el acceso a la base de datos de canciones.</p>";
                StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                lblMensajes.Text = StrError;
                return;
            }
        }
        if (gridVideos.SelectedIndex != -1)
        {
            DefinirIdVideo();
            StrComandoSql = "SELECT url FROM videos WHERE id_video='" + Session["idElemento"] + "';";
            try
            {
                SqlConnection conexion = new SqlConnection(StrCadenaConexion);
                SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                Session["urlElemento"] = reader.GetString(0);
                reader.Close();
                conexion.Close();
            }
            catch (SqlException ex)
            {
                string StrError = "<p>Se han producido errores en el acceso a la base de datos de vídeos.</p>";
                StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                lblMensajes.Text = StrError;
                return;
            }
        }

        Response.Redirect(Convert.ToString(Session["urlElemento"]));
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admins_GestionarVideos : System.Web.UI.Page
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
        txtId.Enabled = false;
    }
    protected void gridVideos_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        DeshabilitarControles();
        string StrVideo = gridVideos.SelectedRow.Cells[1].Text;
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "SELECT id_video, titulo, director, sinopsis, genero, anyo, url " +
            " FROM videos WHERE id_video = '" + StrVideo + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                txtId.Text = (reader.GetInt32(0).ToString());
                txtTitulo.Text = reader.GetString(1);
                txtDirector.Text = reader.GetString(2);
                txtSinopsis.Text = reader.GetString(3);
                txtGenero.Text = reader.GetString(4);
                txtAnyo.Text = reader.GetInt32(5).ToString();
                txtUrl.Text = reader.GetString(6);
            }
            else
            {
                lblMensajes.Text = "No existen registros de esa película.";
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
        LimpiarCampos();
        HabilitarControles();
        txtId.Enabled = true;
        txtId.Focus();
        gridVideos.SelectedIndex = -1;
    }
    protected void btnAnadir_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        String strId, strTitulo, strDirector, strSinopsis, strGenero, strAnyo, strUrl;
        strId = txtId.Text;
        strTitulo = txtTitulo.Text;
        strDirector = txtDirector.Text;
        strSinopsis = txtSinopsis.Text;
        strGenero = txtGenero.Text;
        strAnyo = txtAnyo.Text;
        strUrl = txtUrl.Text;

        if (strId != "" && strTitulo != "" && strDirector != "" && strSinopsis != "" && strGenero != "" && strAnyo != "" && strUrl != "")
        {
            string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
            string StrComandoSql = "INSERT videos (id_video, titulo, director, sinopsis, genero, anyo, url) VALUES (" +
                "'" + strId + "','" + strTitulo + "','" + strDirector + "','" + strSinopsis + "','" + strGenero + "','" + strAnyo + "', '" + strUrl + "');";
            try
            {
                SqlConnection conexion = new SqlConnection(StrCadenaConexion);
                SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
                comando.Connection.Open();
                Int32 inRegistrosAfectados = comando.ExecuteNonQuery();
                comando.Connection.Close();
                if (inRegistrosAfectados == 1)
                    lblMensajes.Text = "Vídeo insertado correctamente.";
                else
                    lblMensajes.Text = "Error al insertar el vídeo.";
                txtId.Enabled = true;
                btnNuevo.Visible = true;
                btnAnadir.Visible = false;
                btnModificar.Visible = true;
                btnGuardar.Visible = false;
                btnEliminar.Visible = false;
                btnCancelar.Visible = false;
                gridVideos.SelectedIndex = -1;
                LimpiarCampos();
                gridVideos.DataBind();
            }
            catch (SqlException ex)
            {
                string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                lblMensajes.Text = StrError;
                return;
            }
            txtId.Enabled = false;
            DeshabilitarControles();
            gridVideos.DataBind();
            gridVideos.SelectedIndex = -1;
        }
        else
        {
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
        txtTitulo.Focus();
        HabilitarControles();
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        String strTitulo, strDirector, strSinopsis, strGenero, strAnyo, strUrl;
        strTitulo = txtTitulo.Text;
        strDirector = txtDirector.Text;
        strSinopsis = txtSinopsis.Text;
        strGenero = txtGenero.Text;
        strAnyo = txtAnyo.Text;
        strUrl = txtUrl.Text;

        if (txtId.Text != "" && strTitulo != "" && strDirector != "" && strSinopsis != "" && strGenero != "" && strAnyo != "" && strUrl != "")
        {
            string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
            string StrComandoSql = "UPDATE videos SET titulo='" + strTitulo + "', director='" + strDirector + "', sinopsis='" + strSinopsis + "', genero='" + strGenero + 
                "', anyo='" + strAnyo + "', url='" + strUrl + "' WHERE id_video = '" + txtId.Text + "';";

            try
            {
                SqlConnection conexion = new SqlConnection(StrCadenaConexion);
                SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
                comando.Connection.Open();
                Int32 inRegistrosAfectados = comando.ExecuteNonQuery();
                comando.Connection.Close();
                if (inRegistrosAfectados == 1)
                    lblMensajes.Text = "Vídeo actualizado correctamente.";
                else
                    lblMensajes.Text = "Error al actualizar el vídeo.";
                btnModificar.Visible = false;
                btnGuardar.Visible = false;
                btnNuevo.Visible = true;
                btnAnadir.Visible = false;
                btnEliminar.Visible = false;
                btnCancelar.Visible = false;
                gridVideos.DataBind();
                LimpiarCampos();
                DeshabilitarControles();
                gridVideos.SelectedIndex = -1;
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
                gridVideos.SelectedIndex = -1;
                return;
            }
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        String strId;
        strId = txtId.Text;
        string StrCadConex = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComSql = "DELETE FROM videos WHERE id_video='" + strId + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadConex);
            SqlCommand comando = new SqlCommand(StrComSql, conexion);
            comando.Connection.Open();
            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();
            comando.Connection.Close();
            if (inRegistrosAfectados == 1)
                lblMensajes.Text = "Vídeo eliminado correctamente.";
            else
                lblMensajes.Text = "Error al eliminar el vídeo.";
            btnModificar.Visible = false;
            btnGuardar.Visible = false;
            btnNuevo.Visible = true;
            btnAnadir.Visible = false;
            btnEliminar.Visible = false;
            btnCancelar.Visible = false;
            gridVideos.DataBind();
            LimpiarCampos();
            gridVideos.SelectedIndex = -1;
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
        LimpiarCampos();
        DeshabilitarControles();
        gridVideos.SelectedIndex = -1;
    }
    protected void DeshabilitarControles()
    {
        txtTitulo.Enabled = false;
        txtDirector.Enabled = false;
        txtSinopsis.Enabled = false;
        txtGenero.Enabled = false;
        txtAnyo.Enabled = false;
        txtUrl.Enabled = false;
    }
    protected void HabilitarControles()
    {
        txtTitulo.Enabled = true;
        txtDirector.Enabled = true;
        txtSinopsis.Enabled = true;
        txtGenero.Enabled = true;
        txtAnyo.Enabled = true;
        txtUrl.Enabled = true;
    }
    protected void LimpiarCampos()
    {
        txtId.Text = "";
        txtTitulo.Text = "";
        txtDirector.Text = "";
        txtSinopsis.Text = "";
        txtGenero.Text = "";
        txtAnyo.Text = "";
        txtUrl.Text = "";
    }

    
    protected void gridVideos_PageIndexChanged(object sender, EventArgs e)
    {
        LimpiarCampos();
        gridVideos.SelectedIndex = -1;
        DeshabilitarControles();

        btnNuevo.Visible = true;
        btnAnadir.Visible = false;
        btnModificar.Visible = false;
        btnGuardar.Visible = false;
        btnEliminar.Visible = false;
        btnCancelar.Visible = false;
    }
}
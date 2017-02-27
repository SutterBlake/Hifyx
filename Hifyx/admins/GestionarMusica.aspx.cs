using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admins_GestionarMusica : System.Web.UI.Page
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
    protected void gridMusica_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        DeshabilitarControles();
        string StrCancion = gridMusica.SelectedRow.Cells[1].Text;
        string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
            Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
        string StrComandoSql = "SELECT id_cancion, titulo, grupo, album, genero, anyo, discografica, url " +
            " FROM canciones WHERE id_cancion='" + StrCancion + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                txtId.Text = reader.GetInt32(0).ToString();
                txtTitulo.Text = reader.GetString(1);
                txtGrupo.Text = reader.GetString(2);
                txtAlbum.Text = reader.GetString(3);
                txtGenero.Text = reader.GetString(4);
                txtAnyo.Text = reader.GetInt32(5).ToString();
                txtDiscografica.Text = reader.GetString(6);
                txtUrl.Text = reader.GetString(7);
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
        LimpiarCampos();
        HabilitarControles();
        txtId.Enabled = true;
        txtId.Focus();
        gridMusica.SelectedIndex = -1;
    }
    protected void btnAnadir_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";
        String strId, strTitulo, strGrupo, strAlbum, strGenero, strDiscografica, strAnyo, strUrl;
        strId = txtId.Text;
        strTitulo = txtTitulo.Text;
        strGrupo = txtGrupo.Text;
        strAlbum = txtAlbum.Text;
        strGenero = txtGenero.Text;
        strDiscografica = txtDiscografica.Text;
        strAnyo = txtAnyo.Text;
        strUrl = txtUrl.Text;

        if (strId != "" && strTitulo != "" && strGrupo != "" && strAlbum != "" && strGenero != "" && strAnyo != "" && strUrl != "")
        {
            string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
            string StrComandoSql = "INSERT canciones (id_cancion, titulo, grupo, album, genero, anyo, discografica, url) VALUES ('" + 
                strId + "','" + strTitulo + "','" + strGrupo + "','" + strAlbum + "','" + strGenero + "', '" + strAnyo + "', '" +
                strDiscografica + "', '" + strUrl + "');";
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
                txtId.Enabled = true;
                btnNuevo.Visible = true;
                btnAnadir.Visible = false;
                btnModificar.Visible = false;
                btnGuardar.Visible = false;
                btnEliminar.Visible = false;
                btnCancelar.Visible = false;
                gridMusica.SelectedIndex = -1;
                LimpiarCampos();
                gridMusica.DataBind();
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
        String strId, strTitulo, strGrupo, strAlbum, strGenero, strDiscografica, strAnyo, strUrl;
        strId = txtId.Text;
        strTitulo = txtTitulo.Text;
        strGrupo = txtGrupo.Text;
        strAlbum = txtAlbum.Text;
        strGenero = txtGenero.Text;
        strDiscografica = txtDiscografica.Text;
        strAnyo = txtAnyo.Text;
        strUrl = txtUrl.Text;

        if (strId != "" && strTitulo != "" && strGrupo != "" && strAlbum != "" && strGenero != "" && strAnyo != "" && strUrl != "")
        {
            string StrCadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=" +
                Server.MapPath("~/App_Data/bbdd_hifyx.mdf") + ";Integrated Security=True;Connect Timeout=30";
            string StrComandoSql = "UPDATE canciones SET titulo='" + strTitulo + "', grupo='" + strGrupo + "', album='" + strAlbum + 
                "', genero='" + strGenero + "', discografica='" + strDiscografica + "', anyo='" + strAnyo + "', url='" + strUrl +
                "' WHERE id_cancion = '" + txtId.Text + "';";

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
                gridMusica.DataBind();
                LimpiarCampos();
                DeshabilitarControles();
                gridMusica.SelectedIndex = -1;
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
                gridMusica.SelectedIndex = -1;
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
        string StrComSql = "DELETE FROM canciones WHERE id_cancion='" + strId + "';";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadConex);
            SqlCommand comando = new SqlCommand(StrComSql, conexion);
            comando.Connection.Open();
            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();
            comando.Connection.Close();
            if (inRegistrosAfectados == 1)
                lblMensajes.Text = "Canción eliminada correctamente.";
            else
                lblMensajes.Text = "Error al eliminar la canción.";
            btnModificar.Visible = false;
            btnGuardar.Visible = false;
            btnNuevo.Visible = true;
            btnAnadir.Visible = false;
            btnEliminar.Visible = false;
            btnCancelar.Visible = false;
            gridMusica.DataBind();
            LimpiarCampos();
            gridMusica.SelectedIndex = -1;
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
        gridMusica.SelectedIndex = -1;
    }
    protected void DeshabilitarControles()
    {
        txtTitulo.Enabled = false;
        txtGrupo.Enabled = false;
        txtAlbum.Enabled = false;
        txtGenero.Enabled = false;
        txtDiscografica.Enabled = false;
        txtAnyo.Enabled = false;
        txtUrl.Enabled = false;
    }
    protected void HabilitarControles()
    {
        txtTitulo.Enabled = true;
        txtGrupo.Enabled = true;
        txtAlbum.Enabled = true;
        txtGenero.Enabled = true;
        txtDiscografica.Enabled = true;
        txtAnyo.Enabled = true;
        txtUrl.Enabled = true;
    }
    protected void LimpiarCampos()
    {
        txtId.Text = "";
        txtTitulo.Text = "";
        txtGrupo.Text = "";
        txtAlbum.Text = "";
        txtGenero.Text = "";
        txtDiscografica.Text = "";
        txtAnyo.Text = "";
        txtUrl.Text = "";
    }

    protected void gridMusica_PageIndexChanged (object sender, EventArgs e)
    {
        LimpiarCampos();
        gridMusica.SelectedIndex = -1;
        DeshabilitarControles();

        btnNuevo.Visible = true;
        btnAnadir.Visible = false;
        btnModificar.Visible = false;
        btnGuardar.Visible = false;
        btnEliminar.Visible = false;
        btnCancelar.Visible = false;
    }
}
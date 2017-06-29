using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["caducado"]) == true)
        {
            Response.Write("<script>alert('Tu código ha caducado. Introduce uno nuevo en tu perfil.');</script>");
            Response.Redirect("~/users/DatosPersonales.aspx");
        }
        lblBienvenida.Text = "¡Bienvenido, " + Convert.ToString(Session["nombre"]) + "!";
    }
}
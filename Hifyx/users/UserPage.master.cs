using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_UserPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = HttpContext.Current.Request.Url.AbsolutePath;

        if (Convert.ToString(Session["rol"]) != "U")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (Convert.ToBoolean(Session["caducado"]) == true && path != "/users/DatosPersonales.aspx" && path != "/users/CerrarSesion.aspx")
        {
            Response.Redirect("~/users/DatosPersonales.aspx");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admins_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblBienvenida.Text = "Panel de administración. Bienvenido, " + Convert.ToString(Session["nombre"]) + ".";
    }
}
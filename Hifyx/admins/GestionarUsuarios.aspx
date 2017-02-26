<%@ Page Title="" Language="C#" MasterPageFile="~/admins/AdminPage.master" AutoEventWireup="true" CodeFile="GestionarUsuarios.aspx.cs" Inherits="admins_GestionarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Hifix - Gestionar Usuarios</title>
    <script type="text/javascript">
        function confirmar() {
            if (window.confirm("¿Deseas eliminar este usuario?") == true) {
                return true;
            } else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="adminContenedor">
        <div id="adminDatosIzquierda">
            <h2 style="text-align: center;">Gestionar usuarios</h2><br />
            <p style="text-align: justify;">Para añadir un nuevo usuario, pincha en el botón Nuevo. Si vas cambiar los datos de un usuario, simplemente selecciona uno y pincha en el botón Modificar. Si quieres eliminar un usuario, selecciona el afortunado y pincha en Eliminar (pedirá confirmación).</p>
            <asp:Label ID="lblMensajes" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [usuarios]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT [rol] FROM [usuarios]"></asp:SqlDataSource>
            <asp:gridview runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="7" ID="gridUsuarios" OnSelectedIndexChanged="gridUsuarios_SelectedIndexChanged" DataKeyNames="id_usuario" AllowSorting="True" OnPageIndexChanged="gridUsuarios_PageIndexChanged">
                <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="&gt;&gt;" >
                    <HeaderStyle Width="50px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="id_usuario" HeaderText="DNI" ReadOnly="True" SortExpression="id_usuario">
                    <HeaderStyle Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email">
                    <HeaderStyle Width="170px"  />
                    </asp:BoundField>
                    <asp:BoundField DataField="contrasena" HeaderText="Contraseña" SortExpression="contrasena">
                    <HeaderStyle Width="110px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="rol" HeaderText="Rol" SortExpression="rol">
                    <HeaderStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre">
                    <HeaderStyle Width="130px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fecha_expiracion" HeaderText="Expira el" SortExpression="fecha_expiracion" DataFormatString="{0:MM/dd/yyyy}">
                    <HeaderStyle Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codigo_actual" HeaderText="Código" SortExpression="codigo_actual">
                    <HeaderStyle Width="100px" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                <PagerSettings FirstPageText="Primera" LastPageText="Última" NextPageText="Siguiente" PreviousPageText="Anterior" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" HorizontalAlign="Center" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:gridview>
        </div>
        <div id="adminDatosDerecha">
                <div class="etiquetaLineaDatos">
                    <span>DNI</span>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <span>Email</span>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="campoLinea form-control" TextMode="Email"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <span>Contraseña</span>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <span>Rol</span>
                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="campoLinea form-control" Width="75px" DataSourceID="SqlDataSource2" DataTextField="rol" DataValueField="rol">
                        <asp:ListItem Selected="True">U</asp:ListItem>
                        <asp:ListItem>A</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="etiquetaLineaDatos">
                    <span>Nombre</span>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <span>Fecha de expiración</span>
                    <asp:TextBox ID="txtFechaExp" runat="server" CssClass="campoLinea form-control" TextMode="DateTime"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <span>Código actual</span>
                    <asp:TextBox ID="txtCodigoAct" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="botonera">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnAnadir" runat="server" Text="Añadir" OnClick="btnAnadir_Click" CssClass="btn btn-default" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-default" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" OnClientClick="return confirmar();" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" />
                </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/users/UserPage.master" AutoEventWireup="true" CodeFile="DatosPersonales.aspx.cs" Inherits="users_DatosPersonales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Hifyx - Datos Personales</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="userMultimedia">
        <div id="userListaContenido">
            <h2 style="text-align: center;">Datos Personales</h2><br />
            <p style="text-align: justify;">En esta página podrás revisar y cambiar tus datos personales.</p><br />
            <asp:Label ID="lblMensajes" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id_usuario], [email], [nombre], [fecha_expiracion], [codigo_actual] FROM [usuarios] WHERE ([id_usuario] = @id_usuario)">
                <SelectParameters>
                    <asp:SessionParameter Name="id_usuario" SessionField="id_usuario" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:FormView ID="FormView1" runat="server" DataKeyNames="id_usuario" DataSourceID="SqlDataSource1">
                <EditItemTemplate>
                    id_usuario:
                    <asp:Label ID="id_usuarioLabel1" runat="server" Text='<%# Eval("id_usuario") %>' />
                    <br />
                    email:
                    <asp:TextBox ID="emailTextBox" runat="server" Text='<%# Bind("email") %>' />
                    <br />
                    nombre:
                    <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
                    <br />
                    fecha_expiracion:
                    <asp:TextBox ID="fecha_expiracionTextBox" runat="server" Text='<%# Bind("fecha_expiracion") %>' />
                    <br />
                    codigo_actual:
                    <asp:TextBox ID="codigo_actualTextBox" runat="server" Text='<%# Bind("codigo_actual") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    id_usuario:
                    <asp:TextBox ID="id_usuarioTextBox" runat="server" Text='<%# Bind("id_usuario") %>' />
                    <br />
                    email:
                    <asp:TextBox ID="emailTextBox" runat="server" Text='<%# Bind("email") %>' />
                    <br />
                    nombre:
                    <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
                    <br />
                    fecha_expiracion:
                    <asp:TextBox ID="fecha_expiracionTextBox" runat="server" Text='<%# Bind("fecha_expiracion") %>' />
                    <br />
                    codigo_actual:
                    <asp:TextBox ID="codigo_actualTextBox" runat="server" Text='<%# Bind("codigo_actual") %>' />
                    <br />
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insertar" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                </InsertItemTemplate>
                <ItemTemplate>
                    DNI:
                    <br />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="id_usuarioLabel" runat="server" Text='<%# Eval("id_usuario") %>' />
                    <br />
                    Email:
                    <br />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="emailLabel" runat="server" Text='<%# Bind("email") %>' />
                    <br /> Nombre:
                    <br />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="nombreLabel" runat="server" Text='<%# Bind("nombre") %>' />
                    <br />
                    Caduca el:
                    <br />
                    &nbsp;&nbsp;&nbsp; <asp:Label ID="fecha_expiracionLabel" runat="server" Text='<%# Bind("fecha_expiracion", "{0:d}") %>' />
                    <br />
                    Código:
                    <br />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="codigo_actualLabel" runat="server" Text='<%# Bind("codigo_actual") %>' />
                    <br />

                </ItemTemplate>
            </asp:FormView>
        </div>
        <div id="userInfoContenido">
                <div class="etiquetaLineaDatos">
                    <asp:Label ID="lblDni" runat="server" Text="DNI"></asp:Label>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="campoLinea form-control" TextMode="Email"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <asp:Label ID="lblPass1" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="txtPass1" runat="server" CssClass="campoLinea form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <asp:Label ID="lblPass2" runat="server" Text="Repetir contraseña"></asp:Label>
                    <asp:TextBox ID="txtPass2" runat="server" CssClass="campoLinea form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos" id="pass2">
                    <asp:Label ID="lblCodigo" runat="server" Text="Código"></asp:Label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="botonera">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-default" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" />
                </div>
        </div>
    </div>
</asp:Content>

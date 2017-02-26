<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Hifix - Registro</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 style="text-align: center;">Registro</h2>
    <asp:Label ID="lblMensajes" style="color:red;" runat="server" Text=""></asp:Label>
    <div id="formRegistro">
        <div id="contenedorRegistro">
            <div class="etiquetaLinea">
                    <span>DNI</span>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
            </div>
            <div class="etiquetaLinea">
                    <span>Email</span>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="campoLinea form-control" TextMode="Email"></asp:TextBox>
            </div>
            <div class="etiquetaLinea">
                    <span>Nombre</span>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
            </div>
            <div class="etiquetaLinea">
                    <span>Contraseña</span>
                    <asp:TextBox ID="txtPassword1" runat="server" CssClass="campoLinea form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="etiquetaLinea">
                    <span>Confirmar contraseña</span>
                    <asp:TextBox ID="txtPassword2" runat="server" CssClass="campoLinea form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="boton">
                <asp:Button ID="btnInsertar" runat="server" CssClass="btn btn-primary" Text="Insertar" OnClick="btnInsertar_Click" />
                <asp:Button ID="btnVaciar" runat="server" CssClass="btn btn-danger" Text="Vaciar" OnClick="btnVaciar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
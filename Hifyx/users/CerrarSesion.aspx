<%@ Page Title="" Language="C#" MasterPageFile="~/users/UserPage.master" AutoEventWireup="true" CodeFile="CerrarSesion.aspx.cs" Inherits="users_CerrarSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Hifyx - ¿Cerrar sesión?</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>¿Cerrar sesión?</h2><br />
    <asp:Button ID="btnAceptar" runat="server" text="Aceptar" OnClick="btnAceptar_Click" />
    <asp:Button ID="btnCancelar" runat="server" text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>


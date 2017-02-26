<%@ Page Title="" Language="C#" MasterPageFile="~/admins/AdminPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admins_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Hifix - Panel de administración</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblBienvenida" runat="server" Text="" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <p>Desde este panel podrás gestionar los usuarios, vídeos o música. Siendo más detallados, podrás consultar todos los usuarios registrados en la BBDD, y lo mismo con los vídeos y música.</p>
    <div class="btn-group btn-group-justified" style="margin-top:30px;">
        <a href="GestionarUsuarios.aspx" class="btn btn-primary">Gestionar Usuarios</a>
        <a href="GestionarVideos.aspx" class="btn btn-primary" >Gestionar Vídeos</a>
        <a href="GestionarMusica.aspx" class="btn btn-primary">Gestionar Música</a>
    </div>
</asp:Content>
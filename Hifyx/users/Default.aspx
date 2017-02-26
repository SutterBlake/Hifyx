<%@ Page Title="" Language="C#" MasterPageFile="~/users/UserPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="users_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Hifyx - Inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblBienvenida" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <p>Desde este panel podrás acceder a la lista de vídeos, la lista de música, tu lista de favoritos o tu panel de datos personales.</p>
    <div class="btn-group btn-group-justified" style="margin-top:30px;">
        <a href="Videos.aspx" class="btn btn-primary">Vídeos</a>
        <a href="Musica.aspx" class="btn btn-primary">Música</a>
        <a href="Favoritos.aspx" class="btn btn-primary">Favoritos</a>
        <a href="DatosPersonales.aspx" class="btn btn-primary">Datos personales</a>
    </div>
</asp:Content>


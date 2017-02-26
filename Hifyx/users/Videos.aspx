<%@ Page Title="" Language="C#" MasterPageFile="~/users/UserPage.master" AutoEventWireup="true" CodeFile="Videos.aspx.cs" Inherits="users_Videos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Hifyx - Vídeos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="userMultimedia">
        <div id="userListaContenido">
            <h2 style="text-align:center;">Lista de vídeos</h2><br />
            <p style="text-align:justify;">En esta página puedes ver la lista de vídeos y seleccionar uno para ver los detalles y reproducirlo.</p><br />
            <asp:Label ID="lblMensajes" runat="server" Text="" ForeColor="red"></asp:Label><br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [titulo], [director] FROM [videos]"></asp:SqlDataSource>
            <asp:GridView ID="gridVideos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" PageSize="8" OnSelectedIndexChanged="gridVideos_SelectedIndexChanged" OnPageIndexChanged="gridVideos_PageIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:BoundField DataField="titulo" HeaderText="Título" SortExpression="titulo">
                    <HeaderStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="director" HeaderText="Director" SortExpression="director">
                    <HeaderStyle Width="200px" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        <div id="userInfoContenido">
            <div class="etiquetaLineaDatos">
                <span>Título</span>
                <asp:TextBox ID="txtTitulo" runat="server" Enabled="false" CssClass="campoLinea form-control"></asp:TextBox>
            </div>
            <div class="etiquetaLineaDatos">
                <span>Director</span>
                <asp:TextBox ID="txtDirector" runat="server" Enabled="false" CssClass="campoLinea form-control"></asp:TextBox>
            </div>
            <div class="etiquetaLineaDatos">
                <span>Género</span>
                <asp:TextBox ID="txtGenero" runat="server" Enabled="false" CssClass="campoLinea form-control"></asp:TextBox>
            </div>
            <div class="etiquetaLineaDatos">
                <span>Año</span>
                <asp:TextBox ID="txtAnyo" runat="server" Enabled="false" CssClass="campoLinea form-control"></asp:TextBox>
            </div>
            <div class="etiquetaSinopsis">
                <span>Sinopsis</span>
                <asp:TextBox ID="txtSinopsis" runat="server" Enabled="false" CssClass="campoLinea form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>
            <div class="botonMultimedia">
                <asp:Button ID="btnAbrirEnlace" runat="server" Text="Reproducir" CssClass="btn btn-primary" OnClick="btnAbrirEnlace_Click" />
                <asp:Button ID="btnAgregarFavs" runat="server" Text="Me gusta" CssClass="btn btn-success" Visible="False" OnClick="btnAgregarFavs_Click" />
            </div>
        </div>
    </div>
</asp:Content>
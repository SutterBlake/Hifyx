<%@ Page Title="" Language="C#" MasterPageFile="~/users/UserPage.master" AutoEventWireup="true" CodeFile="Favoritos.aspx.cs" Inherits="users_Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Hifyx - Favoritos</title>
    <script type="text/javascript">
        function confirmar() {
            if (window.confirm("¿Deseas eliminar este elemento?") == true) {
                return true;
            } else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="userMultimedia">
        <div class="panelFavoritos">
            <h2 style="text-align:center;">Canciones favoritas</h2><br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT canciones.titulo, canciones.grupo, canciones.genero, canciones_repro.fecha FROM canciones INNER JOIN canciones_repro ON canciones.id_cancion = canciones_repro.id_cancion WHERE (canciones_repro.usuario = @id_usuario)">
                <SelectParameters>
                    <asp:SessionParameter Name="id_usuario" SessionField="id_usuario" Type="String" DefaultValue="999999999" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="gridCanciones" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="480px" OnSelectedIndexChanged="gridCanciones_SelectedIndexChanged" OnPageIndexChanged="gridCanciones_PageIndexChanged" PageSize="7">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="Repro." ShowSelectButton="True" />
                    <asp:BoundField DataField="titulo" HeaderText="Título" SortExpression="titulo" >
                    </asp:BoundField>
                    <asp:BoundField DataField="grupo" HeaderText="Grupo" SortExpression="grupo" >
                    </asp:BoundField>
                    <asp:BoundField DataField="genero" HeaderText="Género" SortExpression="genero" >
                    </asp:BoundField>
                    <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Añadido" SortExpression="fecha" />
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
        <div class="panelFavoritos">
            <h2 style="text-align:center;">Vídeos favoritos</h2><br />
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT videos.titulo, videos.director, videos.genero, videos_repro.fecha FROM videos INNER JOIN videos_repro ON videos.id_video = videos_repro.id_video WHERE (videos_repro.usuario = @id_usuario)">
                <SelectParameters>
                    <asp:SessionParameter Name="id_usuario" SessionField="id_usuario" Type="String" DefaultValue="999999999" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="gridVideos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" Width="480px" OnSelectedIndexChanged="gridVideos_SelectedIndexChanged" OnPageIndexChanged="gridVideos_PageIndexChanged" PageSize="7">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="Repro." ShowSelectButton="True" />
                    <asp:BoundField DataField="titulo" HeaderText="Título" SortExpression="titulo" />
                    <asp:BoundField DataField="director" HeaderText="Director" SortExpression="director" />
                    <asp:BoundField DataField="genero" HeaderText="Género" SortExpression="genero" />
                    <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Añadido" SortExpression="fecha" />
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
    </div>
    <div id="userFavBotonera">
        <div class="botonera">
            <asp:Label ID="lblMensajes" runat="server" Text="" ForeColor="red"></asp:Label><br /><br />
            <asp:Button ID="btnReproducir" runat="server" Text="Reproducir" CssClass="btn btn-primary" OnClick="btnReproducir_Click" />
            <asp:Button ID="btnQuitarFavs" runat="server" Text="Ya no me gusta" CssClass="btn btn-danger" OnClick="btnQuitarFavs_Click" />
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/admins/AdminPage.master" AutoEventWireup="true" CodeFile="GestionarVideos.aspx.cs" Inherits="admins_GestionarVideos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Hifyx - Gestionar Vídeos</title>
    <script type="text/javascript">
        function confirmar() {
            if (window.confirm("¿Deseas eliminar este vídeo?") == true) {
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
            <h2 style="text-align:center;">Gestionar vídeos</h2><br />
            <p style="text-align:justify;">Para añadir un nuevo vídeo, pincha en el botón Nuevo. Si vas cambiar los datos de un vídeo, simplemente selecciona uno y pincha en el botón Modificar. Si quieres eliminar un vídeo, selecciona el afortunado y pincha en Eliminar (pedirá confirmación).</p>
            <asp:Label ID="lblMensajes" runat="server" Text="" ForeColor="red"></asp:Label><br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id_video], [titulo], [director], [sinopsis], [genero], [anyo] FROM [videos]"></asp:SqlDataSource>
            <asp:GridView ID="gridVideos" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id_video" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gridVideos_SelectedIndexChanged" PageSize="4" OnPageIndexChanged="gridVideos_PageIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="&gt;&gt;" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_video" HeaderText="ID" ReadOnly="True" SortExpression="id_video" >
                    </asp:BoundField>
                    <asp:BoundField DataField="titulo" HeaderText="Título" SortExpression="titulo" >
                    <HeaderStyle Width="125px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="director" HeaderText="Director" SortExpression="director" >
                    <HeaderStyle Width="125px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sinopsis" HeaderText="Sinopsis" SortExpression="sinopsis" >
                    </asp:BoundField>
                    <asp:BoundField DataField="genero" HeaderText="Género" SortExpression="genero" >
                    </asp:BoundField>
                    <asp:BoundField DataField="anyo" HeaderText="Año" SortExpression="anyo" />
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
        <div id="adminDatosDerecha">
                <div class="etiquetaLineaDatos">
                    <span>ID Vídeo</span>
                    <asp:TextBox ID="txtId" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <span>Título</span>
                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <span>Director</span>
                    <asp:TextBox ID="txtDirector" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaMultiLineaDatos">
                    <span>Sinopsis</span>
                    <asp:TextBox ID="txtSinopsis" runat="server" CssClass="campoLinea form-control" Rows="5" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <span>Género</span>
                    <asp:TextBox ID="txtGenero" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <span>Año</span>
                    <asp:TextBox ID="txtAnyo" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLineaDatos">
                    <span>URL</span>
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/admins/AdminPage.master" AutoEventWireup="true" CodeFile="GestionarMusica.aspx.cs" Inherits="admins_GestionarMusica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Hifix - Gestionar Música</title>
    <script type="text/javascript">
        function confirmar() {
            if (window.confirm("¿Deseas eliminar esta canción?") == true) {
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
            <h2 style="text-align:center;">Gestionar música</h2><br />
            <p style="text-align:justify;">Para añadir una nueva canción, pincha en el botón Nuevo. Si vas cambiar los datos de una canción, simplemente selecciona uno y pincha en el botón Modificar. Si quieres eliminar una canción, selecciona el afortunado y pincha en Eliminar (pedirá confirmación).</p>
            <asp:Label ID="lblMensajes" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id_cancion], [titulo], [grupo], [album], [genero], [anyo] FROM [canciones]"></asp:SqlDataSource>
            <asp:GridView ID="gridMusica" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id_cancion" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" PageSize="7" OnSelectedIndexChanged="gridMusica_SelectedIndexChanged" OnPageIndexChanged="gridMusica_PageIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="&gt;&gt;" />
                    <asp:BoundField DataField="id_cancion" HeaderText="ID" ReadOnly="True" SortExpression="id_cancion" >
                    <HeaderStyle Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="titulo" HeaderText="Título" SortExpression="titulo" >
                    </asp:BoundField>
                    <asp:BoundField DataField="grupo" HeaderText="Grupo" SortExpression="grupo" >
                    </asp:BoundField>
                    <asp:BoundField DataField="album" HeaderText="Álbum" SortExpression="album" >
                    </asp:BoundField>
                    <asp:BoundField DataField="genero" HeaderText="Género" SortExpression="genero" >
                    </asp:BoundField>
                    <asp:BoundField DataField="anyo" HeaderText="Año" SortExpression="anyo" >
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
        <div id="adminDatosDerecha">
            
                <div class="etiquetaLinea">
                    <span>ID Canción</span>
                    <asp:TextBox ID="txtId" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLinea">
                    <span>Título</span>
                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLinea">
                    <span>Grupo</span>
                    <asp:TextBox ID="txtGrupo" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLinea">
                    <span>Álbum</span>
                    <asp:TextBox ID="txtAlbum" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLinea">
                    <span>Género</span>
                    <asp:TextBox ID="txtGenero" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLinea">
                    <span>Discográfica</span>
                    <asp:TextBox ID="txtDiscografica" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLinea">
                    <span>Año</span>
                    <asp:TextBox ID="txtAnyo" runat="server" CssClass="campoLinea form-control"></asp:TextBox>
                </div>
                <div class="etiquetaLinea">
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


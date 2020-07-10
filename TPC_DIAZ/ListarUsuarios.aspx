<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="TPC_DIAZ.ListarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <label style="margin-top: 30px; margin-left:10px; margin-bottom:10px; font-size:x-large; font-style:inherit">Lista de Usuarios</label>
    <asp:Button ID="btnAgregarUsuario" style="margin-top: 10px;" ControlStyle-CssClass="btn btn-success mb-4 btn-sm" runat="server" Text="Agregar" OnClick="btnAgregarUsuario_Click"/>
    <div class="container">
        <asp:GridView CssClass="table" ID="dgvUsuario" runat="server" AutoGenerateColumns="false" Height="200px" Width="400px" OnSelectedIndexChanged="dgvUsuario_SelectedIndexChanged"  OnRowCommand="dgvUsuario_RowCommand"   >
            <Columns>
                <asp:BoundField HeaderText="IdUsuario" DataField="IdUsuario" ItemStyle-CssClass="oculto text-center" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-CssClass="text-center" />          
                <asp:BoundField HeaderText="Clave" DataField="Clave" ItemStyle-CssClass="text-center"/>       
                <asp:BoundField HeaderText="Permiso" DataField="Permiso" ItemStyle-CssClass="text-center"/>       
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" CommandName="Eliminar" />
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-info" Text="Modificar" CommandName="Modificar" />
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-primary" Text="Ver detalles" CommandName="Detalles" />
            </Columns>
        </asp:GridView>
        
    </div>
</asp:Content>

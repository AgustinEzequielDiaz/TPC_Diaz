<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaTipoUsuario.aspx.cs" Inherits="TPC_DIAZ.ListaTipoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Lista de tipos de usuarios</h1>
       <div class="container">
        <asp:GridView CssClass="table" ID="dgvTiposUsuarios" runat="server" AutoGenerateColumns="false" Height="200px" Width="400px" OnSelectedIndexChanged="dgvTiposUsuarios_SelectedIndexChanged"  OnRowCommand="dgvTiposUsuarios_RowCommand" >
            <Columns>
                <asp:BoundField HeaderText="IdTiposUsuario" DataField="IdTiposUsuario" ItemStyle-CssClass="oculto text-center" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-CssClass="text-center" />
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" CommandName="Eliminar"/>
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-info" Text="Modificar" CommandName="Modificar"/>
            </Columns>
        </asp:GridView>
        <asp:Button ID="BtnAgregarTipoUsuario" runat="server" Text="Agregar" OnClick="BtnAgregarTipoUsuario_Click"   />
    </div>
</asp:Content>

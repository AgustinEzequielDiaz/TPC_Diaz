<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarPersonas.aspx.cs" Inherits="TPC_DIAZ.ListarPersonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de Personas</h1>
    <div class="container">
        <asp:GridView CssClass="table" ID="dgvPersona" runat="server" AutoGenerateColumns="false" Height="200px" Width="400px" OnSelectedIndexChanged="dgvPersona_SelectedIndexChanged" OnRowCommand="dgvPersona_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="IdPersona" DataField="IdPersona" ItemStyle-CssClass="oculto text-center" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-CssClass="text-center" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Imagen" DataField="Imagen" />
                <asp:BoundField HeaderText="DNI" DataField="DNI" />
                <asp:BoundField HeaderText="Direccion" DataField="direccion.Calle"/>
                <asp:BoundField HeaderText="Numero" DataField="direccion.Numero" />
                <asp:BoundField HeaderText="CP" DataField="direccion.CP" />
                <asp:BoundField HeaderText="Localidad" DataField="direccion.Localidad" />
                <asp:BoundField HeaderText="Provincia" DataField="direccion.Provincia" />
                <asp:BoundField HeaderText="Email" DataField="contacto.Email" />
                <asp:BoundField HeaderText="Telefono" DataField="contacto.Telefono" />               
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" CommandName="Select" />
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Modificar" CommandName="Modificar" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="ButtonPersona" runat="server" Text="Agregar" OnClick="ButtonPersona_Click" />
    </div>

    
</asp:Content>

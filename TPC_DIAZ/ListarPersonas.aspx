<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarPersonas.aspx.cs" Inherits="TPC_DIAZ.ListarPersonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de Personas</h1>
    <%--<asp:Button ID="AgregarNuevoMaterial" ControlStyle-CssClass="btn btn-success mb-4 btn-sm" CommandName="AgregarMaterial" runat="server" Text="Agregar material" OnClick="AgregarNuevoMaterial_Click" />--%>
      <style>
        .oculto {
            display: none;
        }
    </style>
    <div class="container">
        <asp:GridView CssClass="table" ID="dgvPersona" runat="server" AutoGenerateColumns="false" Height="200px" Width="400px" OnSelectedIndexChanged="dgvPersona_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="IdPersona" DataField="IdPersona" ItemStyle-CssClass="oculto text-center" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-CssClass="text-center" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="DNI" DataField="DNI" />
                <asp:BoundField HeaderText="FechaNacimiento" DataField="FechaNac" />
                <asp:BoundField HeaderText="FechaRegistracion" DataField="FechaReg" />
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" CommandName="Select" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="ButtonPersona" runat="server" Text="Agregar" OnClick="ButtonPersona_Click" />
    </div>

    
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignacionMateriales.aspx.cs" Inherits="TPC_DIAZ.AsignacionMateriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <h1>Asignacion Materiales</h1>
    <div class="container">
        <asp:GridView CssClass="table" ID="dgvAsignacion" runat="server" AutoGenerateColumns="false" Height="200px" Width="400px" OnSelectedIndexChanged="dgvPersona_SelectedIndexChanged" OnRowCommand="dgvPersona_RowCommand">
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

    <%--DROPDOWN DE VEHICULOS O DGV CON LOS VEHICULOS Y NOMBRE DEL CONDUCTOR, AGREGANDO FILTRADO.--%>
</asp:Content>

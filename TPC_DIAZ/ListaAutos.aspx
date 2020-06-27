<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaAutos.aspx.cs" Inherits="TPC_DIAZ.ListaAutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Lista de vehiculos</h1>
       <div class="container">
        <asp:GridView CssClass="table" ID="dgvAutos" runat="server" AutoGenerateColumns="false" Height="200px" Width="400px" OnSelectedIndexChanged="dgvAutos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="IdAuto" DataField="IdAuto" ItemStyle-CssClass="oculto text-center" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Modelo" DataField="Modelo" ItemStyle-CssClass="text-center" />
                <asp:BoundField HeaderText="Patente" DataField="Patente" />
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" CommandName="Select" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="ButtonAuto" runat="server" Text="Agregar" OnClick="ButtonAuto_Click" />
    </div>
</asp:Content>

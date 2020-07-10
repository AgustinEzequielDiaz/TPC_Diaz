<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaAutos.aspx.cs" Inherits="TPC_DIAZ.ListaAutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <label style="margin-top: 30px; margin-left:10px; margin-bottom:10px; font-size:x-large; font-style:inherit">Lista de vehiculos</label>
        <asp:Button ID="ButtonAuto" style="margin-top: 10px;" ControlStyle-CssClass="btn btn-success mb-4 btn-sm" runat="server" Text="Agregar" OnClick="ButtonAuto_Click" />
       <div class="container">
        <asp:GridView CssClass="table" ID="dgvAutos" runat="server" AutoGenerateColumns="false" Height="200px" Width="400px" OnSelectedIndexChanged="dgvAutos_SelectedIndexChanged" OnRowCommand="dgvAutos_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="IdAuto" DataField="IdAuto" ItemStyle-CssClass="oculto text-center" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Modelo" DataField="Modelo" ItemStyle-CssClass="text-center" />
                <asp:BoundField HeaderText="Patente" DataField="Patente" />
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" CommandName="Eliminar"/>
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-info" Text="Modificar" CommandName="Modificar"/>
            </Columns>
        </asp:GridView>        
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockMateriales.aspx.cs" Inherits="TPC_DIAZ.StockMateriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de Materiales</h1>
     <style>
        .oculto {
            display: none;
        }
    </style>
    <div class="container">
        <asp:GridView CssClass="table" ID="dgvCarrito" runat="server" AutoGenerateColumns="false" Height="200px" Width="400px" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="oculto text-center" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-CssClass="text-center" />
                <asp:BoundField HeaderText="Caracteristicas" DataField="Descripcion" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" CommandName="Select" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="ButtonCategoria" runat="server" Text="Button" OnClick="ButtonCategoria_Click" />
    </div>

    <asp:Table ID="Table1" runat="server" class="table table-sm table-dark">
     
    </asp:Table>
</asp:Content>

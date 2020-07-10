<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaStockAuto.aspx.cs" Inherits="TPC_DIAZ.ListaStockAuto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .titulo{
            margin-top:30px;
            margin-bottom:10px;
            margin-left:10px;
        }
    </style>  
    <div class="titulo">
    <asp:Label ID="lblTitulo" style="margin-top: 50px; font-size:x-large; font-style:inherit" runat="server" Text="Stock vehiculo"></asp:Label>
       </div>
        <div class="container">
        <asp:GridView CssClass="table" ID="dgvStockAuto" runat="server" AutoGenerateColumns="false" Height="200px" Width="400px" OnSelectedIndexChanged="dgvStockAuto_SelectedIndexChanged"  OnRowCommand="dgvStockAuto_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
               <%-- <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" ItemStyle-CssClass="oculto text-center" HeaderStyle-CssClass="oculto" />--%>
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" ItemStyle-CssClass="text-center" />
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" CommandName="Eliminar"/>
                <%--<asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-info" Text="Modificar" CommandName="Modificar"/>--%>
            </Columns>
        </asp:GridView>
        <%--<asp:Button ID="ButtonStockAuto" runat="server" Text="Agregar" OnClick="ButtonAuto_Click" />--%>
    </div>
</asp:Content>

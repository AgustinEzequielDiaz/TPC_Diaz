<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockMateriales.aspx.cs" Inherits="TPC_DIAZ.StockMateriales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Lista de Materiales</h1>
    <asp:Button ID="AgregarNuevoMaterial" ControlStyle-CssClass="btn btn-success mb-4 btn-sm" CommandName="AgregarMaterial" runat="server" Text="Agregar material" OnClick="AgregarNuevoMaterial_Click" />
    <style>
        .oculto {
            display: none;
        }
    </style>

 <%--    <div class="container">
        <asp:GridView CssClass="table" ID="dgvMaterial" runat="server" AutoGenerateColumns="false" Height="200px" Width="400px" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="oculto text-center" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-CssClass="text-center" />
                <asp:BoundField HeaderText="Caracteristicas" DataField="Descripcion" />
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" CommandName="Select" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="ButtonMaterial" runat="server" Text="Button" OnClick="ButtonMaterial_Click" />
    </div>

    <asp:Table ID="Table1" runat="server" class="table table-sm table-dark">
    </asp:Table>--%>

    <div class="card mb-3" style="max-width: 340px; margin-left: 10px; margin-right: 10px">
        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <div class="row no-gutters">
                    <div class="col-md-4">
                        <img src="<%#Eval("Imagen") %>" class="card-img" alt="..." style="max-width: 100px; max-height: 100px; margin-left: 30px; margin-right: 30px; margin-top: 10px">
                    </div>
                    <div class="col-md-8">
                        <div class="card-body">
                            <h5 class="card-title" style="font-size: 10px"><%#Eval("Nombre")%></h5>
                            <p class="card-text" style="font-size: 10px"><%#Eval("Descripcion")%></p>
                            <p class="card-text" style="font-size: 10px">Cantidad:<%#Eval("Cantidad")%></p>
                            <p class="card-text" style="font-size: 10px"><small class="text-muted"><%#Eval("Categoria.Id")%></small></p>
                            <asp:Button ID="Button1" CommandArgument='<%#Eval("Id")%>' ControlStyle-CssClass="btn btn-warning mb-4 btn-sm" CommandName="IdMaterialModificar" runat="server" Text="Modificar" OnClick="ButtonModificarMaterial_Click" />
                            <asp:Button ID="Button2" CommandArgument='<%#Eval("Id")%>' ControlStyle-CssClass="btn btn-danger mb-4 btn-sm" CommandName="IdMaterialEliminado" runat="server" Text="Eliminar" OnClick="ButtonEliminarMaterial_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

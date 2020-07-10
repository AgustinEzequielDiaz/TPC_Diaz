<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Inherits="TPC_DIAZ.AgregarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Agregar nueva categoria</h1>
    <div class="container">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Nombre</label>
                <asp:TextBox ID="NombreCategoria" runat="server" CssClass="form-control is-valid" placeholder="Ingrese el nombre" />
                <%--<input class="form-control" id="NombreAgregar" placeholder="Ingrese el nombre">--%>
            </div>
        </div>
        <div class="form-row">
        </div>
        </div>
         <asp:Button ID="ButtonAgregarCategoria" runat="server" Text="Button" OnClick="ButtonAgregarCategoria_Click" />

       <%-- <button type="submit" class="btn btn-primary">Agregar</button>--%>
</asp:Content>

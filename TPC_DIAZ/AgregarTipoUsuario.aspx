<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarTipoUsuario.aspx.cs" Inherits="TPC_DIAZ.AgregarTipoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Agregar nuevo tipo de usuario</h1>
    <div class="container">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Nombre</label>
                <asp:TextBox ID="NombreTipoAgregar" runat="server" CssClass="form-control is-valid" placeholder="Ingrese el nombre" />
                <%--<input class="form-control" id="NombreAgregar" placeholder="Ingrese el nombre">--%>
            </div>
            <h5>Seleccionar los permisos que tiene, coming soon.....</h5>
        </div>
        </div>
         <asp:Button ID="ButtonAgregarTipo" runat="server" Text="Button" OnClick="ButtonAgregarTipo_Click" />
      
</asp:Content>

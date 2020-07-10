<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="TPC_DIAZ.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>CREANDO USUARIO</h1>
    <div class="container">
        <label>Nombre</label>
        <asp:TextBox ID="NombreUsuario" runat="server" CssClass="form-control is-valid" placeholder="Eliga un nombre de usuario" />
        <%--<input type="text" class="form-control" id="DescripcionAgregar" placeholder="Ingrese una descripcion">--%>
        <label>Clave</label>
        <asp:TextBox ID="ClaveUsuario" runat="server" CssClass="form-control is-valid" placeholder="Ingrese la clave" />
        <%--<input class="form-control" id="NombreAgregar" placeholder="Ingrese el nombre">--%>
        <label>Repetir clave</label>
        <asp:TextBox ID="ClaveRepetida" runat="server" CssClass="form-control is-valid" placeholder="Confirme la clave" />
        <%--<input type="text" class="form-control" id="DescripcionAgregar" placeholder="Ingrese una descripcion">--%>
    </div>
    <asp:Button ID="ButtonRegistrar" style="margin-left:110px; margin-top:20px;" ControlStyle-CssClass="btn btn-success mb-4 btn-sm" runat="server" Text="Registrar" OnClick="ButtonRegistrar_Click" />
</asp:Content>

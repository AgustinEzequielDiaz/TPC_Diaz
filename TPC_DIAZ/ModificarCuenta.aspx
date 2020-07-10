<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCuenta.aspx.cs" Inherits="TPC_DIAZ.ModificarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>MODIFICAR CUENTA</h1>
    <div class="container">
        <div class="row">
            <div class="col">
                <h2>Datos de la cuenta</h2>
                <div class="form-group">
                    <label>Nombre</label>
                    <asp:TextBox ID="NombreUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su nombre" />
                </div>
<%--                <div class="form-group">
                    <label>Clave anterior</label>
                    <asp:TextBox ID="ClaveAnterior" runat="server" CssClass="form-control" placeholder="Ingrese su clave anterior" />
                </div>--%>
                <div class="form-group">
                    <label>Clave nueva</label>
                    <asp:TextBox ID="ClaveUsuario" runat="server" CssClass="form-control" placeholder="Ingrese la clave nueva" />
                </div>
                <div class="form-group">
                    <label>Permiso</label>
                    <asp:TextBox ID="PermisoUsario" runat="server" CssClass="form-control" placeholder="Ingrese el permiso" />
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="BtnModificarCuenta" runat="server" Text="Modificar" OnClick="BtnModificarCuenta_Click"/>

</asp:Content>

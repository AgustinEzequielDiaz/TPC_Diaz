<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="TPC_DIAZ.ModificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>MODIFICAR DATOS USUARIO</h1>
    <div class="container">
        <div class="row">
            <div class="col">
                <h2>Datos personales</h2>
                <div class="form-group">
                    <label>Nombre</label>
                    <asp:TextBox ID="NombrePersona" runat="server" CssClass="form-control" placeholder="Ingrese su nombre" />
                </div>
                <div class="form-group">
                    <label>Apellido</label>
                    <asp:TextBox ID="ApellidoPersona" runat="server" CssClass="form-control" placeholder="Ingrese su apellido" />
                </div>
                <div class="form-group">
                    <label>DNI</label>
                    <asp:TextBox ID="DNIPersona" runat="server" CssClass="form-control" placeholder="Ingrese su DNI" />
                </div>
                <div class="form-group">
                    <label>Imagen</label>
                    <asp:TextBox ID="ImagenPersona" runat="server" CssClass="form-control" placeholder="Ingrese la direccion de la imagen" />
                </div>
            </div>

            <div class="col">
                <h2>Direccion</h2>
                <div class="form-group">
                    <label>Calle</label>
                    <asp:TextBox ID="CallePersona" runat="server" CssClass="form-control" placeholder="Ingrese la calle" />
                </div>
                <div class="form-group">
                    <label>Numero</label>
                    <asp:TextBox ID="NumeroPersona" runat="server" CssClass="form-control" placeholder="Ingrese la altura de la calle" />
                </div>
                <div class="form-group">
                    <label>C.P.:</label>
                    <asp:TextBox ID="CPPersona" runat="server" CssClass="form-control" placeholder="Ingrese su codigo postal" />
                </div>
                <div class="form-group">
                    <label>Localidad</label>
                    <asp:TextBox ID="LocalidadPersona" runat="server" CssClass="form-control" placeholder="Ingrese su localidad" />
                </div>
                <div class="form-group">
                    <label>Provincia</label>
                    <asp:TextBox ID="ProvinciaPersona" runat="server" CssClass="form-control" placeholder="Ingrese la provincia" />
                </div>
            </div>
            <div class="col">
                <h2>Contacto</h2>
                <div class="form-group">
                    <label>Email</label>
                    <asp:TextBox ID="EmailPersona" runat="server" CssClass="form-control" placeholder="Ingrese su correo" />
                </div>
                <div class="form-group">
                    <label>Telefono/Celular</label>
                    <asp:TextBox ID="TelefonoPersona" runat="server" CssClass="form-control" placeholder="Ingrese su numero" />
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="BtnModificarUsuario" runat="server" Text="Modificar" OnClick="BtnModificarUsuario_Click"/>
</asp:Content>

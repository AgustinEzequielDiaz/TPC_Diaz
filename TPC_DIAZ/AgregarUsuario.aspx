<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="TPC_DIAZ.AgregarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>USUARIO NUEVO</h1>
    <div class="container">
        <div class="row">
            <div class="col">
                <h2>Datos personales</h2>
                <div class="form-group">
                    <label>Nombre</label>
                    <asp:TextBox ID="NombreUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su nombre" />
                </div>
                <div class="form-group">
                    <label>Apellido</label>
                    <asp:TextBox ID="ApellidoUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su apellido" />
                </div>
                <div class="form-group">
                    <label>DNI</label>
                    <asp:TextBox ID="DNIUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su DNI" />
                </div>
                <div class="form-group">
                    <label>Fecha Nacimiento</label>
                    <asp:TextBox ID="FechaNacUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su fecha de nacimiento" />
                </div>
            </div>

            <div class="col">
                <h2>Direccion</h2>
            <div class="form-group">
                <label>Calle</label>
                <asp:TextBox ID="CalleUsuario" runat="server" CssClass="form-control" placeholder="Ingrese la calle" />
            </div>
            <div class="form-group">
                <label>Numero</label>
                <asp:TextBox ID="AlturaUsuario" runat="server" CssClass="form-control" placeholder="Ingrese la altura de la calle" />
            </div>
               <div class="form-group">
                <label>C.P.:</label>
                <asp:TextBox ID="CPUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su codigo postal" />
            </div>
                   <div class="form-group">
                <label>Localidad</label>
                <asp:TextBox ID="LocalidadUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su localidad" />
            </div>
            </div>
            <div class="col">
                <h2>Contacto</h2>
                <div class="form-group">
                    <label>Email</label>
                    <asp:TextBox ID="EmailUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su correo" />
                </div>
                <div class="form-group">
                    <label>Telefono/Celular</label>
                    <asp:TextBox ID="TelefonoUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su numero" />
                </div>
            </div>
        </div>
     </div>
    
    <asp:Button ID="ButtonAgregarUsuario" runat="server" Text="Continuar" OnClick="ButtonAgregarUsuario_Click" />    
    
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TPC_DIAZ.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1></h1>
    <div class="container">
        <%--<div class="text-center">
            <div class="form-signin">--%>
        <div class="row" style="margin-right:300px">
            <div class="col">
            </div>
            <div class="col">
                <div class="form-group" style="margin-left:40px">
                    <img class="mb-4" src="http://www.seguridadase.com.ar/wp-content/uploads/2015/12/logoASE-02.png" alt="" width="200" height="210">
                </div>
                <div class="form-group">
                    <asp:TextBox ID="NombreUsuario" runat="server" CssClass="form-control" class="mr-2" placeholder="Ingrese su usuario" />
                </div>
                <div class="form-group">
                    <asp:TextBox ID="PassUsuario" runat="server" class="mb-4" CssClass="form-control" TextMode="Password" placeholder="Ingrese su contraseña" />
                </div>
                <%--<div class="form-group">
                    <div class="checkbox mb-3">
                        <asp:CheckBox ID="Recordar" runat="server" Text="Recordar" />
                    </div>
                </div>--%>
                <div class="form-group">
                    <asp:Button ID="IngresarUsuario" type="submit" class="btn btn-lg btn-primary btn-block mb-4" runat="server" Text="Ingresar" OnClick="IngresarUsuario_Click"/>
                </div>
                <div class="form-group">
                    <asp:LinkButton ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click">Registrarme</asp:LinkButton>
                </div>
                <div class="form-group">
                    <p class="mt-5 mb-3 text-muted">© 2017-2018</p>
                </div>
            </div>
        </div>
    </div>




    <%--  <asp:TextBox ID="PassUsuario" runat="server" class="mb-4" CssClass="form-control" TextMode="Password" placeholder="Ingrese su contraseña" />

                <div class="checkbox mb-3">
                    <asp:CheckBox ID="Recordar" runat="server" Text="Recordar" />
                </div>

                <asp:Button ID="IngresarUsuario" type="submit" class="btn btn-lg btn-primary btn-block mb-4" runat="server" Text="Ingresar" />
            </div>
        </div>
        <p class="mt-5 mb-3 text-muted">© 2017-2018</p>--%>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMaterial.aspx.cs" Inherits="TPC_DIAZ.AgregarMaterial" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Agregar nuevo material</h1>
    <div class="container">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Nombre</label>
                <asp:TextBox ID="NombreAgregar" runat="server" CssClass="form-control is-valid" required="" placeholder="Ingrese el nombre" />
                <%--<input class="form-control" id="NombreAgregar" placeholder="Ingrese el nombre">--%>
            </div>
            <div class="form-group">
                <label>Descripcion</label>
                <asp:TextBox ID="DescripcionAgregar" runat="server" CssClass="form-control is-valid" required="" placeholder="Ingrese una descripcion" />
                <%--<input type="text" class="form-control" id="DescripcionAgregar" placeholder="Ingrese una descripcion">--%>
            </div>
        </div>
        <div class="form-row">
        <div class="form-group col-md-6">
            <label>Imagen</label>
            <asp:TextBox ID="ImagenAgregar" runat="server" CssClass="form-control is-valid" placeholder="Cargar imagen" />
            <%--<input type="text" class="form-control" id="ImagenAgregar" placeholder="Cargar imagen">--%>
        </div>
        <div class="form-group ">
            <label>Cantidad</label>
            <asp:TextBox ID="CantidadAgregar" runat="server" CssClass="form-control is-valid" required="" placeholder="Indica la cantidad" />
            <%--<input type="text" class="form-control" id="CantidadAgregar" placeholder="Indica la cantidad">--%>
        </div>
        </div>
            <div class="form-group">
                <label>Categoria</label>               
                <asp:DropDownList ID="DdlCategoria" Cssclass="form-control is-valid" runat="server" OnSelectedIndexChanged="DdlCategoria_SelectedIndexChanged"/>
                <asp:Button ID="btnAgregarCategoria" runat="server" Text="AgregarCat" CommandName="AgregarCategoria" OnClick="btnAgregarCategoria_Click"/>

                <%--<select id="CategoriaAgregar" class="form-control">
                    <option selected>Seleccionar</option>
                    <option>...</option>
                </select>--%>
            </div>
        </div>
         <asp:Button ID="ButtonAgregar" runat="server" Text="Button" OnClick="ButtonAgregar_Click" />
       <%-- <button type="submit" class="btn btn-primary">Agregar</button>--%>
</asp:Content>

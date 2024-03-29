﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarMaterial.aspx.cs" Inherits="TPC_DIAZ.ModificarArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Modificar material</h1>
    <div class="container">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Nombre</label>
                <asp:TextBox ID="NombreModificar" runat="server" CssClass="form-control is-valid" placeholder="Ingrese el nombre" />
                <%--<input class="form-control" id="NombreAgregar" placeholder="Ingrese el nombre">--%>
            </div>
            <div class="form-group">
                <label>Descripcion</label>
                <asp:TextBox ID="DescripcionModificar" runat="server" CssClass="form-control is-valid" placeholder="Ingrese una descripcion" />
                <%--<input type="text" class="form-control" id="DescripcionAgregar" placeholder="Ingrese una descripcion">--%>
            </div>
        </div>
        <div class="form-row">
        <div class="form-group col-md-6">
            <label>Imagen</label>
            <asp:TextBox ID="ImagenModificar" runat="server" CssClass="form-control is-valid" placeholder="Cargar imagen" />
            <%--<input type="text" class="form-control" id="ImagenAgregar" placeholder="Cargar imagen">--%>
        </div>
        <div class="form-group ">
            <label>Cantidad</label>
            <asp:TextBox ID="CantidadModificar" runat="server" CssClass="form-control is-valid" placeholder="Indica la cantidad" />
            <%--<input type="text" class="form-control" id="CantidadAgregar" placeholder="Indica la cantidad">--%>
        </div>
        </div>
            <div class="form-group">
                <label>Categoria</label>
                <asp:TextBox ID="CategoriaModificar" runat="server" CssClass="form-control is-valid" placeholder="Indica la categoria" />
                <%--<asp:DropDownList ID="CategoriaAgregar" runat="server"/>--%>
                <%--<select id="CategoriaAgregar" class="form-control">
                    <option selected>Seleccionar</option>
                    <option>...</option>
                </select>--%>
            </div>
        </div>
         <asp:Button ID="ButtonModificar" runat="server" Text="Button" OnClick="ButtonModificar_Click" />
       <%-- <button type="submit" class="btn btn-primary">Agregar</button>--%>
</asp:Content>

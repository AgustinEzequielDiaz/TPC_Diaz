<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarAuto.aspx.cs" Inherits="TPC_DIAZ.ModificarAuto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <h1> Modificar vehiculo</h1>
    <div class="container">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Patente</label>
                <asp:TextBox ID="PatenteModificar" runat="server" CssClass="form-control is-valid" placeholder="Ingrese la patente" />
                <%--<input class="form-control" id="NombreAgregar" placeholder="Ingrese el nombre">--%>
            </div>
            <div class="form-group">
                <label>Modelo</label>
                <asp:TextBox ID="ModeloModificar" runat="server" CssClass="form-control is-valid" placeholder="Ingrese el modelo" />
                <%--<input type="text" class="form-control" id="DescripcionAgregar" placeholder="Ingrese una descripcion">--%>
            </div>
             <div class="form-group">
                <label>Conductor</label>               
                <asp:DropDownList ID="DdlConductor" Cssclass="form-control is-valid" runat="server" OnSelectedIndexChanged="DdlConductor_SelectedIndexChanged"  />
            </div>
        </div>
        </div>
         <asp:Button ID="ButtonModificar" runat="server" Text="Aceptar" OnClick="ButtonModificar_Click"/>
</asp:Content>

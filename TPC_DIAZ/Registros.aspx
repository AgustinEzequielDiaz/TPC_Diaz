<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registros.aspx.cs" Inherits="TPC_DIAZ.Registros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Registros de asignacion   </h1>
    <div class="container">
        <asp:GridView CssClass="table bg-light" ID="dgvRegistros" runat="server" AutoGenerateColumns="false" Height="600px" Width="800px">
            <Columns>
                <asp:BoundField HeaderText="Usuario" DataField="usuario.Nombre" ItemStyle-CssClass="text-center" />
                <asp:BoundField HeaderText="Nombre" DataField="material.Nombre" ItemStyle-CssClass="text-center" />
                <asp:BoundField HeaderText="Descripcion" DataField="material.Descripcion" />
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                <asp:BoundField HeaderText="Patente" DataField="IdAuto.Patente" />
                <asp:BoundField DataFormatString="{0:d}" HeaderText ="Fecha de asignacion" DataField="IdAsignar.FechaAsignacion"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

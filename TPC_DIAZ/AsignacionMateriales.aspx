<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignacionMateriales.aspx.cs" Inherits="TPC_DIAZ.AsignacionMateriales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="color:brown">Asignacion de materiales</h1>
    <div class="card" style="width: 25%">

        <style>
            .oculto {
                display: none;
            }
        </style>
        <div class="container">
            <div class="row">
                <div class="col-sm"  style="width:150px">
                    <asp:GridView CssClass="table" ID="dgvAsignacion" runat="server" AutoGenerateColumns="false" Height="200px" Width="400px" HeaderStyle-BorderStyle="Double" HeaderStyle-CssClass="alert-danger" OnSelectedIndexChanged="dgvAsignacion_SelectedIndexChanged" OnRowCommand="dgvAsignacion_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="oculto text-center" HeaderStyle-CssClass="oculto" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-CssClass="text-center" />
                            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" ItemStyle-CssClass="text-center"/>
                            <asp:BoundField HeaderText="Stock" DataField="Stock" ItemStyle-CssClass="text-center" />
                            
                            <asp:ButtonField ControlStyle-CssClass="list-group-item btn btn-outline-danger Contenido pl-5 pr-5" HeaderText="Opcion" HeaderStyle-CssClass=" font-weight-bolder Header LetrasHeader " ButtonType="Link" Text="-" CommandName="Restar" />
                            <asp:BoundField HeaderText="Retiro" DataField="Cantidad" ItemStyle-CssClass="text-center"/>
                            <asp:ButtonField ControlStyle-CssClass="list-group-item btn btn-outline-danger Contenido pl-5 pr-5" HeaderText="Opcion" HeaderStyle-CssClass=" font-weight-bolder Header LetrasHeader " ButtonType="Link" Text="+" CommandName="Agregar" />
                            
                            <%--<asp:BoundField HeaderText="Cantidad" DataField="Cantidad" ItemStyle-CssClass="text-center"/>--%>
                            <%--<asp:BoundField HeaderText="Cantidad" DataField="Cantidad"/>--%>
                            <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" CommandName="Select" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-sm" style="width:150px; margin-left:300px; margin-top:-70px">
                <h1 style="color:forestgreen">Seleccionar vehiculo</h1>
                    <asp:GridView CssClass="table" ID="dgvConductor" runat="server" AutoGenerateColumns="false" Height="100px" Width="200px" HeaderStyle-BorderStyle="Double" HeaderStyle-CssClass="alert-success" OnSelectedIndexChanged="dgvConductor_SelectedIndexChanged" OnRowCommand="dgvConductor_RowCommand">
                        <Columns>
                             <asp:BoundField HeaderText="Id" DataField="IdAuto" ItemStyle-CssClass="oculto text-center" HeaderStyle-CssClass="oculto" />
                            <asp:BoundField HeaderText="Patente" DataField="Patente" ItemStyle-CssClass="text-center" />
                            <asp:BoundField HeaderText="Modelo" DataField="Modelo" ItemStyle-CssClass="text-center" />
                            <%--<asp:BoundField HeaderText="Cantidad" DataField="Cantidad"/>--%>
                            <asp:ButtonField HeaderText="" ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="ASIGNAR" CommandName="AsignarStock" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


    <%--DROPDOWN DE VEHICULOS O DGV CON LOS VEHICULOS Y NOMBRE DEL CONDUCTOR, AGREGANDO FILTRADO.--%>
</asp:Content>

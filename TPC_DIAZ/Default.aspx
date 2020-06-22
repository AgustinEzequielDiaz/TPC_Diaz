<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_DIAZ._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>ASESORAMIENTO EN SEGURIDAD ELECTRONICA</h1>
    <div class="row">
        <div class="col">
            <h3>Instalaciones</h3>
            <div id="carouselExampleControls" class="carousel slide w-50 h-50" data-ride="carousel">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img class="d-block w-100" src="Image/InstalacionTesoro.jpg" alt="First slide" width="800" height="300">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="Image/InstalacionTesoroDoble.jpg" alt="Second slide" width="800" height="300">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="Image/InstalacionGaveta.jpg" alt="Third slide" width="800" height="300">
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
        <div class="col">
            <h3>Service</h3>
            <div id="carouselService" class="carousel slide w-50 h-50" data-ride="carousel">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img class="d-block w-100" src="Image/InstalacionSalaTecnica.jpg" alt="First slide" width="800" height="300">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="Image/MIO.jpg" alt="Second slide" width="800" height="300">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="Image/InstalacionGaveta.jpg" alt="Third slide" width="800" height="300">
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselService" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselService" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
         <div class="col">
            <h3>Deposito</h3>
            <div id="carouselDeposito" class="carousel slide w-50 h-50" data-ride="carousel">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img class="d-block w-100" src="Image/InstalacionSalaTecnica.jpg" alt="First slide" width="800" height="300">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="Image/MIO.jpg" alt="Second slide" width="800" height="300">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="Image/InstalacionGaveta.jpg" alt="Third slide" width="800" height="300">
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselDeposito" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselDeposito" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
    </div>

</asp:Content>

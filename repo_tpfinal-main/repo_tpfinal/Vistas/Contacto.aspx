<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Vistas.Contacto" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/template_home_v1.css" />
    <link rel="stylesheet" href="css/template.css" />

    <title>Contacto</title>
    <script src="/js/fontAwesome.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="logo">
                <img src="/img/logo.jpg" class="LogoImagen" />
            </div>
            <div class="header">
                <asp:TextBox ID="txtBuscar" runat="server" name="search" placeholder="Buscar" class="bus" autocomplete="off" AutoPostBack="True" OnTextChanged="txtBuscar_TextChanged" TabIndex="1" onkeyup="RefreshUpdatePanel()" onfocus="this.selectionStart = this.selectionEnd = this.value.length;"></asp:TextBox>
            </div>
            <div class="iconos">
                <div runat="server" id="accesoAdmin" style="margin-right: 1.5rem;"></div>
                <div runat="server" id="infoUser"></div>
                <%--<a href="/IniciarSesion.aspx" class="fas fa-user user"><div id="UsuarioLogueadoNombre" runat="server" style="font-size:20px"></div><div id="UsuarioLogueadoApellido" runat="server" style="font-size:20px;text-decoration: none;"></div></a>--%>
                <a href="/Carrito.aspx" class="fas fa-shopping-cart cart" style="margin-right: 1.5rem;">
                    <div id="datosCarrito" runat="server" style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size: 20px; text-decoration: none;"></div>
                </a>
                <div runat="server" id="IconoSalir"></div>
            </div>
            <div class="navbar">
                <ul class="nav">
                    <li class="name">
                        <a href="/Home.aspx">Home</a>
                    </li>
                    <li id="CargameLasCats" class="name" runat="server">
                        <!--Aca deberian ir las categorias-->
                    </li>
                    <li class="name">
                        <a href="/Contacto.aspx">Contacto</a>
                    </li>
                </ul>
            </div>
            <div class="content">
                <div style="display: inline-block">
                        <h1>Contacto</h1>
                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3293.1778509203173!2d-58.681470684180354!3d-34.37139655275091!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x95bca0efe9045f6d%3A0x642b3555782f21e1!2sAv.%20Italia%209999%2C%20Dique%20Luj%C3%A1n%2C%20Provincia%20de%20Buenos%20Aires!5e0!3m2!1ses!2sar!4v1605586886867!5m2!1ses!2sar" width="1500" height="600" frameborder="0" style="border: 0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>

                    <div id="DatosSucur" style="margin-bottom:25px" runat="server">
                        
                    </div>
                </div>
            </div>
            <div class="footer">
                <!-- Iconos de redes sociales -->
                <h2 class="contactenos">Contactenos</h2>
                <ul style="text-align: left">
                    <li class="redes">
                        <a href="https://www.instagram.com/"><i class="fab fa-instagram-square tamIcoRed"><b style="padding-left: 10px; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Instagram</b></i></a>
                    </li>
                    <li class="redes">
                        <a href="https://twitter.com/"><i class="fab fa-twitter tamIcoRed"><b style="padding-left: 10px; padding-top: 0px; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Twitter</b></i></a>
                    </li>
                    <li class="redes">
                        <a href="https://facebook.com/"><i class="fab fa-facebook-square tamIcoRed"><b style="padding-left: 10px; padding-top: 0px; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Facebook</b></i></a>
                    </li>
                    <li class="redes">
                        <a href="https://github.com/"><i class="fab fa-github tamIcoRed"><b style="padding-left: 10px; padding-top: 0px; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">GitHub</b></i></a>
                    </li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>

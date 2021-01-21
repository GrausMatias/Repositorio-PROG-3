<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Vistas.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="StyleSheet" ; href="/css/iniciosesion.css" ; type="text/css" />
    <link rel="stylesheet" href="css/template_home_v1.css"/>
     <link rel="stylesheet" href="css/template.css"/>

    <title>inicio de sesion</title>
    <script src="/js/fontAwesome.js"></script>
  </head>
<body>
    <form id="formulario" runat="server">
    <div class="container">
        <div class="logo" >
            <img src="/img/logo.jpg" class="LogoImagen" />
        </div>
        <div class="header" >

            <asp:TextBox ID="txtBuscar" runat="server" name="search" placeholder="Buscar" class="bus" autocomplete="off" AutoPostBack="True" OnTextChanged="txtBuscar_TextChanged" TabIndex="1" onkeyup="RefreshUpdatePanel()" onfocus="this.selectionStart = this.selectionEnd = this.value.length;"></asp:TextBox>
        </div>
        <div class="iconos" >
            <div runat="server" id="accesoAdmin" style="margin-right: 1.5rem;"></div>
           <div runat="server" id="infoUser"></div>
            <%--<a href="/IniciarSesion.aspx" class="fas fa-user user"><div id="UsuarioLogueadoNombre" runat="server" style="font-size:20px"></div><div id="UsuarioLogueadoApellido" runat="server" style="font-size:20px;text-decoration: none;"></div></a>--%>
            <a href="/Carrito.aspx" class="fas fa-shopping-cart cart" style="margin-right: 1.5rem;"><div id="datosCarrito" runat="server" style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;font-size:20px;text-decoration: none;"></div></a>
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
        <div class="content" >
        
            <!--Bloque de registro-->
    <div class="posicionamiento">
      <div class="titulo">
        <label>Iniciar sesion</label>
        <hr />
      </div>

      
        <div class="posicion1">
          <div class="datos">
            <div class="usuario">
              <label>Usuario</label>
            </div>
            <div class="txtDatosUsu">
                <asp:TextBox ID="txtUsuario" Class="txtASP" runat="server" style="width: 70%;background-color:rgba(62, 164, 148, 0.51);font-size:21px"></asp:TextBox>
            </div>

            <div class="contrac">
              <div class="lblCampo">Contraseña:</div>
              <div class="txtDatosCon">
                  <asp:TextBox ID="txtContraseña" type="password" Class="txtASP" style="width: 70%;background-color:rgba(62, 164, 148, 0.51);font-size:21px" runat="server"></asp:TextBox>
                  <br />
              </div>
            </div>
            <div class="datDivision">
              <div class="botonInicio">
                  <asp:Button ID="btnIniciarSesion" runat="server" class="inicio" OnClick="btnIniciarSesion_Click" Text="Iniciar Sesion" />
                  <br />
                  <asp:Label ID="lblMensaje" style="font-size:13px" runat="server"></asp:Label>
              </div>
            </div>
          </div>
        </div>
        <div class="posicion2">
            <div class="datosCrear">
              <div class="crear">
                <label>¿No tenes cuenta? ¡Registrate ahora! </label>
              </div>
            </div>
              <div class="Redireccion">
                <div class="botonemp">
                    <asp:Button ID="btnIniciarRegistro" class="inicio" runat="server" Text="Iniciar" OnClick="btnIniciarRegistro_Click" />
                </div>
              </div>
          </div>
      
    </div>
            </div>
    <!---->
        <div class="footer" >
        <!-- Iconos de redes sociales -->
            <h2 class="contactenos">Contactenos</h2>
            <ul style="text-align:left">
              <li class="redes">
                <a href="https://www.instagram.com/"><i class="fab fa-instagram-square tamIcoRed"><b style="padding-left:10px;font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Instagram</b></i></a>
              </li>
              <li class="redes">
                <a href="https://twitter.com/"><i class="fab fa-twitter tamIcoRed"><b style="padding-left:10px;padding-top:0px;font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Twitter</b></i></a>
              </li>
              <li class="redes">
                <a href="https://facebook.com/"><i class="fab fa-facebook-square tamIcoRed"><b style="padding-left:10px;padding-top:0px;font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Facebook</b></i></a>
              </li>
              <li class="redes">
                 <a href="https://github.com/"><i class="fab fa-github tamIcoRed"><b style="padding-left:10px;padding-top:0px;font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">GitHub</b></i></a>
              </li>
            </ul>
        </div>
    </div>
        </form>
</body>
</html>



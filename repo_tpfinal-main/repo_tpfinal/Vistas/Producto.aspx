<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Vistas.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/template.css"/>
    <link rel="StyleSheet" href="/css/producto.css" ; type="text/css" />

    <link href="https://fonts.googleapis.com/css2?family=Rubik:wght@300&display=swap" rel="stylesheet" />    
    <title>Producto</title>
    <script src="/js/fontAwesome.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
  </head>
<body>
        <form id="form1" runat="server">
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
        <div class="navbar" style="z-index: 2;" >
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
    
        <asp:HiddenField ID="selectCant" runat="server"/>
    <!-------------------------------------------------------------------------->
    <div class="conteiner" style="margin:20px 15% 20px 15%;z-index: 0;">

      <div class="Producto" style="text-align:center" id="imagenProducto" runat="server">
        
          <label  style="display:block; margin-top:2%" id="lblNoPro" runat="server"></label>
          
        
      </div>
      <div class="datosPro">
        <div id="datosDelProducto" runat="server">

         </div>
        <div>
          <h3>Cantidad: <asp:DropDownList class="txtASP" style="height: 39px;border-radius: 10px;color:white;" ID="ddlCantidadSeleccion" runat="server" onchange="cambio()">
          </asp:DropDownList></h3>
        </div>
        <div class="disponibles">
        </div>
        <div>
          <asp:button runat="server" ID="bntAgregarProdCarrito" style="width: 90%" class="btnASP" text="Agregar al carrito" OnClick="bntAgregarProdCarrito_Click"/>
        </div>
        <div class="vacio">&nbsp</div>
      </div>

      <div class="descripcion" id="descripcion" runat="server">
        
      </div>
    </div>

    </div>
    <!-------------------------------------------------------------------------->
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
    <script>
        function cambio() {
            document.getElementById('selectCant').value = $("#ddlCantidadSeleccion").val();
            return true;
        }
    </script>
</html>

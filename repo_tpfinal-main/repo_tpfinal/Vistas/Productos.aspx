<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Vistas.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/css/template.css"/>
    <link rel="StyleSheet" ; href="/css/categorias.css" ; type="text/css" />

    <title>Productos</title>
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
   
    <!-------------------------------------------------------------------------->
    <div style="margin-left:15px;margin-top:25px;width:230px;float:left;Background-color: #99DBCF;border-radius:10px;margin-bottom:25px">
      <ul style="padding-top:10px;text-align:left;padding-left:15px">
          <asp:HiddenField ID="hidden" runat="server" />
          <asp:HiddenField ID="HiddenPrecioMin" runat="server" />
          <asp:HiddenField ID="HiddenPrecioMax" runat="server" />
        <li style="width:100%;font-size: 20px;">
          Filtrar por:
          <ul>
            <li>Orden Precio
              <ul>
                <li><asp:Button class="btnASP" ID="btnMayorPrecio" runat="server" Text="Mayor precio" OnClick="btnMayorPrecio_Click" style="height: 30px" />  </li>
                <li><asp:Button class="btnASP" ID="btnMenorPrecio" runat="server" Text="Menor precio" OnClick="btnMenorPrecio_Click" style="margin-top:5px;height: 30px"/></li>
              </ul>
            </li>
            <li>
              Orden Tiempo
        &nbsp;<ul>
                <li><asp:Button class="btnASP" ID="btnMasViejo" runat="server" Text="Mas viejo" OnClick="btnMasViejo_Click" style="height: 30px;width: 85%;" /></li>
                <li><asp:Button class="btnASP" ID="btnMasNuevo" runat="server" Text="Mas nuevo" OnClick="btnMasNuevo_Click" style="margin-top:5px;height: 30px;width: 85%;" /></li>
              </ul>
            </li>
            <li>
              Marca
              <ul>
                <li>
                    <asp:DropDownList class="txtASP" ID="ddMarcas" runat="server" style="height: 39px;width: 115px;border-radius: 10px;color:white;" onchange="cambio()" OnSelectedIndexChanged="ddMarcas_SelectedIndexChanged" AppendDataBoundItems="true" ViewStateMode="Enabled" AutoPostBack="True" >
                    </asp:DropDownList>
                  </li>
              </ul>
            </li>
            <li>
              Precio
              <ul>
                  <%--<label>maximo</label>--%>
                <li>$ <input class="btnASP" id="txtMaximo" style="width:70%;height: 30px" type="number" min="0" placeholder="Max" runat="server" onchange="cambioDePrecio()"/></li>
                    <%--<label>minimo</label>--%>
                <li style="margin-top:5px">$ <input class="btnASP" id="txtMinimo" style="width:70%;height: 30px" type="number" min="0" placeholder="Min" runat="server" onchange="cambioDePrecio()"/></li>
              </ul>
                <asp:Button class="btnASP" ID="btnAplicarPrecio"  runat="server" Text="Aplicar" style="margin-top:5px;height: 30px;width: 85%;"  OnClick="btnAplicarPrecio_Click" />
            </li>
          </ul>
        </li>
      </ul>
    </div>
    <!-------------------------------------------------------------------------->
    <div id="productosCategorias" class="productosCategorias" runat="server">
      <!--Aca deberian ir los productos-->

  </div>
            <asp:Label ID="LblNoPro" runat="server"></asp:Label>
   </div>
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
            document.getElementById('hidden').value = $("#ddMarcas").val();
            return true;
        }
    </script>
    <script>
        function cambioDePrecio() {
            if ($("#txtMinimo").val() == "") {
                document.getElementById('HiddenPrecioMin').value = "0";
            } else {
                document.getElementById('HiddenPrecioMin').value = $("#txtMinimo").val();
            }
            if ($("#txtMaximo").val() == "") {
                document.getElementById('HiddenPrecioMax').value = "0"
            } else {
                document.getElementById('HiddenPrecioMax').value = $("#txtMaximo").val();
            }
            return true;
        }
    </script>
</html>

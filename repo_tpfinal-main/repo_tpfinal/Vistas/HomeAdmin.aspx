<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="Vistas.HomeAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/template_admin.css"/>
    <link rel="stylesheet" href="css/AdminHome.css"/>


    <title>Home - Admin</title>
    <script src="/js/fontAwesome.js"></script>
  </head>
<body>
     <div class="container">
            <div class="logo" >
                <img src="/img/logo.jpg" class="LogoImagen" />
            </div>
            <div class="header" >
                <a href="Home.aspx" style="width:25%;background-color:aliceblue;height: 30px;border-radius:10px;margin-top:10px;text-decoration:none;font-size:24px;color:gray;margin-left: 40px;">IR A LA WEB</a>
            </div>
            <div class="iconos" >
                <div runat="server" id="IconoSalir"></div>
                </div>
            <div class="navbar" >
               <ul class="nav">
                <li><a href="/HomeAdmin.aspx">Home</a></li>
                <li><a href="#">Administrar</a>
                <ul>
                        <li><a href="#">Productos</a>
                            <ul>
                                <li><a href="/AdminListPro.aspx">Listar</a></li>
                                <li><a href="/AdminCrearPro.aspx">Crear</a></li>
                            </ul>
                        </li>
                        <li><a href="#">Usuarios</a>
                            <ul>
                                <li><a href="/AdminListUsu.aspx">Listar</a></li>
                                <li><a href="/AdminEliminarUsuarios.aspx">Eliminar</a></li>
                                <li><a href="/AdminCrearAdministrador.aspx">Crear</a></li>
                            </ul>
                        </li>
                        <li><a href="#">Marcas</a>
                            <ul>
                                <li><a href="/AdminListMarcas.aspx">Listar</a></li>
                                <li><a href="/AdminCrearMarca.aspx">Crear</a></li>
                            </ul>
                        </li>
                        <li><a href="#">Categorias</a>
                            <ul>
                                <li><a href="/AdminListCategoria.aspx">Listar</a></li>
                                <li><a href="/AdminCrearCategoria.aspx">Crear</a></li>
                            </ul>
                        </li>

                    </ul>
            </li>
            <li><a href="#">Registros</a>
                <ul>
                        <li><a href="/Reporte1.aspx">Reporte 1</a></li>
                        <li><a href="/Reporte2.aspx">Reporte 2</a></li>
                        <li><a href="/Reporte3.aspx">Reporte 3</a></li>
                    </ul>
            </li>
            <li><a href="/AdminHistorialVentas.aspx">Historial de ventas</a></li>
        </ul>
        </div>
        <div class="content" >
        
            <!------------------------------------------------------------>

            <div class="englobamiento" style="margin-bottom:25px">
                <div class="DivAdmin">
                    <div class="HomeText">
                        <h2 id="PorcentajesProd" runat="server"></h2>
                    </div>
                    <div id="CantidadDeProductos" runat="server">
                    </div>
                </div>
                <div class="DivAdmin" id="CantidadNumPro" runat="server">
                </div>
               
                <div class="DivAdmin" runat="server">
                    <div class="HomeText">
                        <h2 id="PorcentajesUsu" runat="server"></h2>
                    </div>
                    <div id="CantidadAdmin" runat="server">
                    </div>
                </div>
                <div class="DivAdmin" id="CantidadNumUsu" runat="server">
                </div>
            </div>
                <%--<h2>Administradores</h2><label>Cantidad de usuarios administradores</label>
                <h2>Productos publicados</h2><label>Cantidad de productos publicados</label>--%>

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
</body>
</html>
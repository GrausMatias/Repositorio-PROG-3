<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCrearCategoria.aspx.cs" Inherits="Vistas.AdminCrearCategoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="StyleSheet" href="/css/template_admin.css"type="text/css" />

    <title>Nueva Categoria</title>
    <script src="/js/fontAwesome.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <div class="logo" >
            <img src="/img/logo.jpg" class="LogoImagen" />
        </div>
        <div class="header" >
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
            <li><a href="#">Reportes</a>
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
    <div style="display: inline-block;width: 70%;">
        <div style="background-color: rgba(197, 93, 102, 0.404);border-radius: 8px; text-align:center;margin-top:25px;margin-bottom:25px">
            <h1 style="padding-top: 20px;">Crear categoria</h1>
            <hr style="width:90%" />
            <div style="margin-right:5%">
                <table style="width: 100%">
                    <tbody>
                            <tr>
                                <td style="width: 50%; font-size: 18px">
                                    <h3 style="display: inline;">Nombre categoria :</h3>
                                </td>
                                <td style="width: 50%">
                                    <asp:TextBox class="txtASP" style="width:80%" ID="txtCategoria" runat="server" required="true"></asp:TextBox>
                                </td>
                            </tr>
                         <tr>
                                <td style="width: 50%; font-size: 18px">
                                    <h3 style="display: inline;">Imagen :</h3>
                                </td>
                                <td style="width: 50%">
                                    <asp:TextBox class="txtASP" style="width:80%" ID="txtImagen" runat="server" required="true"></asp:TextBox>
                                </td>
                            </tr>
                    </tbody>
                </table>
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </div>
            <div style="padding-bottom: 25px; text-align:center; margin-top:3%; height: 35px;">
                <asp:Button class="btnASP" style="width:50%" ID="BtnCrearCate" runat="server" Height="40px" OnClick="BtnCrearCate_Click" Text="CREAR CATEGORIA" Width="143px" />
                <asp:Button class="btnASP" style="width:30%" ID="BtnCancelar" runat="server" Height="40px" OnClick="BtnCancelar_Click" Text="CANCELAR" Width="143px" />
            &nbsp;</div>
        </div>
    </div>
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
</html>

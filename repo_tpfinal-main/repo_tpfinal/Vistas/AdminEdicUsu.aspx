<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEdicUsu.aspx.cs" Inherits="Vistas.WebForm14" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="StyleSheet" href="/css/template_admin.css"type="text/css" />

    <title>Editar Usuarios - Admin</title>
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
      <div style="display: inline-block;width: 50%;max-width:380px">
        <div style="background-color: rgba(197, 93, 102, 0.404);border-radius: 8px; text-align:center;margin-top:25px;margin-bottom:25px">
         <h1 style="padding-top: 20px;">Edicion del usuario</h1>
            <hr style="width:90%" />
            <div style="width:100%;text-align:center;margin:0;display: table-footer-group;margin-left:25%;margin-right:25%">
            <div style="width:0%;display:inline-block;margin-right: 50px">
                    <ul style="font-size:18px;text-align:left;display:inline-block;width:50%">
                        <li style="height: 35px; width: 25%; margin-bottom: 14px">ID</li>
                        <li style="height: 35px; width: 25%; margin-bottom: 14px">Nombre</li>
                        <li style="height: 35px; width: 25%; margin-bottom: 14px">Apellido</li>
                        <li style="height: 35px; width: 25%; margin-bottom: 14px">Email</li>
                        <li style="height: 35px; width: 25%; margin-bottom: 14px">Direccion</li>
                        <li style="height: 35px; width: 25%; margin-bottom: 14px">Usuario</li>
                        <li style="height: 35px; width: 25%; margin-bottom: 14px">Telefono</li>
                    </ul>
               </div>
            <div style="width:86%;display:inline-block;">
                <ul style="font-size:18px;text-align:left;display:inline-block;margin-right:1%">
                       <li style="height: 35px;width: 40%;margin-bottom:15px">
                           <asp:TextBox CssClass="txtDeshabilitado" ID="txtIdUsuario" TextMode ="Number" runat="server" ></asp:TextBox>
                       </li>
                       <li style="height: 35px;width: 40%;margin-bottom:15px">
                           <asp:TextBox class="txtASP" ID="txtNombre" runat="server" required="true"></asp:TextBox>
                       </li>
                       <li style="height: 35px;width: 40%;margin-bottom:15px">
                            <asp:TextBox class="txtASP" ID="txtApellido" runat="server" required="true"></asp:TextBox>
                       </li>
                       <li style="height: 35px;width: 40%;margin-bottom:15px">
                           <asp:TextBox class="txtASP" ID="txtEmail"  TextMode="Email" runat="server" required="true"></asp:TextBox>
                        </li>
                        <li style="height: 35px;width: 40%;margin-bottom:15px">
                           <asp:TextBox class="txtASP" ID="txtDireccion"  runat="server" required="true"></asp:TextBox>
                       </li>
                       <li style="height: 35px;width: 40%;margin-bottom:15px">
                           <asp:TextBox class="txtASP" ID="txtNombredeUsuario"  runat="server" required="true"></asp:TextBox>
                       </li>
                       <li style="height: 35px;width: 40%;margin-bottom:15px">
                           <asp:TextBox class="txtASP" ID="txtTelefono" TextMode ="Number" runat="server" required="true"></asp:TextBox>
                       </li>
                     
                   </ul>
               </div>
           </div>
         <div style="padding-bottom: 25px; text-align:center; margin-top:3%;height: 35px;">
               <asp:Button class="btnASP" ID="btnGuardar" onclientclick="return confirm('¿Esta seguro que desea continuar?');" runat="server" OnClick="btnGuardar_Click" Text="Guardar" style="width:30%" />
               <button class="btnASP" id="btnCancelar" runat="server" style="width:30%" type="button" onclick="cancelar()">Cancelar</button>
         </div>
          <asp:Label ID="lblMensajedeActualizacion" runat="server" BackColor="#FF9999"></asp:Label>
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
    <script>
        function cancelar() {
            if (confirm('¿Desea Cancelar la edicion del Usuario?')) {
                window.location.href = '/AdminListUsu.aspx';
            }
        }
    </script>
</html>
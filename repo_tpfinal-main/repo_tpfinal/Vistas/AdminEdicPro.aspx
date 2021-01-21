<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEdicPro.aspx.cs" Inherits="Vistas.AdminEdicPro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="StyleSheet" href="/css/template_admin.css" type="text/css" />

    <title>Editar Productos - Admin</title>
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
                <div style="display: inline-block; width: 60%;">
                    <div style="background-color: rgba(197, 93, 102, 0.404); border-radius: 8px; text-align: center; margin-top: 25px; margin-bottom: 25px">
                        <h1 style="padding-top: 20px;">Edicion de producto</h1>
                        <hr style="width: 90%" />
                        <ul style="font-size: 18px; text-align: left; display: inline-block; width: 15%; margin-left: 2%">
                            <li style="height: 35px; width: 25%; margin-bottom: 14px">Modelo</li>
                            <li style="height: 35px; width: 25%; margin-bottom: 14px">Marca</li>
                            <li style="height: 35px; width: 25%; margin-bottom: 14px">Categoria</li>
                            <li style="height: 35px; width: 25%; margin-bottom: 14px">Stock</li>
                            <li style="height: 35px; width: 25%; margin-bottom: 88px">Precio unitario</li>
                            <li style="height: 35px; width: 25%; margin-bottom: 95px">Descripcion</li>
                            <li style="height: 35px; width: 25%; margin-bottom: 14px">Direccion Imagen</li>
                            <li style="height: 35px; width: 25%; margin-bottom: 14px">Estado</li>
                        </ul>
                        <div style="width: 70%; display: inline-block;">
                            <ul style="font-size: 18px; text-align: left; display: inline-block; width: 95%; margin-right: 1%">
                                <li style="height: 35px; width: 80%; margin-bottom: 15px">
                                    <asp:TextBox class="txtASP" ID="txtModelo" runat="server" Style="width: 100%; font-size: 18px; height: 60%; -moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" required="true"></asp:TextBox>
                                </li>
                                <li style="height: 35px; width: 80%; margin-bottom: 15px">
                                    <asp:DropDownList class="txtASP" ID="ddMarca" runat="server" Style="width: 100%; font-size: 18px; -moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" required="true"></asp:DropDownList>
                                </li>
                                <li style="height: 35px; width: 80%; margin-bottom: 15px">
                                    <asp:DropDownList class="txtASP" ID="ddCategoria" runat="server" Style="width: 100%; font-size: 18px; -moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" required="true"></asp:DropDownList>
                                </li>
                                <li style="height: 35px; width: 80%; margin-bottom: 15px">
                                    <asp:TextBox class="txtASP" ID="txtStock" runat="server" TextMode="Number" min="1" Style="width: 100%; font-size: 18px; height: 60%; -moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" required="true"></asp:TextBox>
                                </li>
                                <li style="height: 35px; width: 80%; margin-bottom: 15px">
                                    <asp:TextBox class="txtASP" ID="txtPrecio" runat="server" onkeypress="return isNumberKey(event)" min="1" Style="width: 100%; font-size: 18px; height: 60%; -moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" required="true"></asp:TextBox>
                                </li>
                                <li style="height: 180px; width: 80%; margin-bottom: 15px">
                                    <asp:TextBox class="txtASP" ID="txtDescripcion" TextMode="MultiLine" runat="server" Style="width: 100%; font-size: 15px; height: 90%; resize: none; -moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" required="true"></asp:TextBox>
                                </li>
                                <li style="height: 35px; width: 80%; margin-bottom: 15px">
                                    <asp:TextBox class="txtASP" ID="txtDireccionImagen" runat="server" Style="width: 100%; font-size: 18px; height: 60%; -moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" required="true"></asp:TextBox>
                                </li>
                                <li style="height: 35px; width: 80%; margin-bottom: 15px">
                                    <asp:DropDownList class="txtASP" ID="ddEstado" runat="server" Style="width: 100%; font-size: 18px; -moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" required="true"></asp:DropDownList>
                                </li>

                            </ul>
                        </div>
                        <div style="padding-bottom: 25px; padding-top: 10px; text-align: center; height: 35px;">
                            <asp:Button class="btnASP" ID="btnGuardar" runat="server" OnClientClick="return confirm('¿Esta seguro que desea guardar los cambios?');" Text="Guardar cambios" OnClick="btnGuardar_Click" Style="width: 30%; min-width: 150px" />
                            <button class="btnASP" id="btnCancelar" type="button" runat="server" onclick="btnCancelar_click()" style="width: 25%">Cancelar</button>
                        </div>
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
<script type="text/javascript">
    function btnCancelar_click() {
        if (confirm('¿Desea Cancelar la edicion del producto?')) {
            window.location.href = '/AdminListPro.aspx';
        }
    }
</script>
    <script type="text/Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
</html>

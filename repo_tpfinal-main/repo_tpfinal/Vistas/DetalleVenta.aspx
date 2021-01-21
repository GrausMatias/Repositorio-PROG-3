<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleVenta.aspx.cs" Inherits="Vistas.DetalleVenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="StyleSheet" href="/css/template.css"type="text/css" />

    <title>detalle Venta</title>
    <script src="/js/fontAwesome.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 45%;
        }
    </style>
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
                        <a href="home.aspx">Home</a>
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
                <!------------------------------------------------------------>
                <div style="margin-left:15px;margin-top:25px;width:230px;float:left;Background-color: #99DBCF;border-radius:10px;margin-bottom:25px;">
                    <h2>CUENTA</h2>
                    <ul style="padding-top:10px;text-align:left;padding-left:15px;padding-right:15px">
                            <li><button class="btnASP" id="botonDatos" type="button" style="height: 30px;width:100%" onclick="botonDatos_click()">Datos</button>  </li>
                            <li><button class="btnASP" id="botonCompras" type="button" style="margin-top:5px;height: 30px;width:100%" onclick="botonCompras_click()">Compras</button></li>
                    </ul>
                </div>
                <!------------------------------------------------------------->
                <div style="background-color: #b4dee0c2;width: 60%;display: inline-block;padding-bottom: 2rem;border-radius: 10px;margin-bottom: 20px;padding-top: 1rem;margin-left: 20%;margin-right: 20%;margin-top: 1rem;display:block">
                        <h1 style="padding-top: 20px; text-align: center; margin: 0px; font-size: 40px">Detalle compra</h1>
                        <hr style="width: 90%" />
                        <div style="width: 100%">
                        </div>
                        <br />
                        <div style="font-size: 20px; margin-left: 5%; width: 100%; text-align: center;" class="auto-style1">
                            <asp:GridView ID="grdDetalleVentasUsuario" CssClass="GridViewStyled" runat="server" CellPadding="4" AllowPaging="True" ForeColor="#333333" GridLines="None" PageSize="5" OnSelectedIndexChanging="grdDetalleVentasUsuario_SelectedIndexChanging">
                                <AlternatingRowStyle BackColor="#BCC8C3" ForeColor="" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#90648B" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#11999e" Font-Bold="True" ForeColor="White" CssClass="headerTable" Height="50px" />
                                <PagerStyle BackColor="#6D887D" ForeColor="White" HorizontalAlign="Center" CssClass="footerTable" Height="50px" />
                                <RowStyle BackColor="#F4F6F5" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                        <div>
                                <asp:Button CssClass="btnASP" ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver a Compras" style="margin-top:15px" />
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
<!-- BUSQUEDA -->
<!-- CADA VEZ QUE CAMBIA LA LETRA HACE POSTBACK -->
<script type="text/javascript">
    function RefreshUpdatePanel() {
        __doPostBack('<%= txtBuscar.ClientID %>', '');
    };
</script>
<!-- SI HIZO POSTBACK PARA SEGUIR ESCRIBIENDO NORMAL PONGO EL CURSOR AL FINAL -->
<script type="text/javascript">
    function SetCursorToTextEnd(textControlID) {
        document.getElementById("txtBuscar").focus();
        var text = document.getElementById(textControlID);
        if (text != null && text.value.length > 0) {
            if (text.createTextRange) {
                var FieldRange = text.createTextRange();
                FieldRange.moveStart('character', text.value.length);
                FieldRange.collapse();
                FieldRange.select();
            }
        }
    }
</script>
<!-- CADA VEZ QUE ENTRO PONGO LA BUSQUEDA ACTIVA -->
<script type="text/javascript">
    document.getElementById("txtBuscar").focus();
</script>
<script type="text/javascript">
    function botonDatos_click() {
        window.location.href = '/Datos.aspx';
    }
</script>
<script type="text/javascript">
    function botonCompras_click() {
        window.location.href = '/Compras.aspx';
    }
</script>
</html>

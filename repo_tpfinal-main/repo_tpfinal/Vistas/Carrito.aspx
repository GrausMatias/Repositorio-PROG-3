<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Vistas.WebForm16" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/template.css"/>
    <link rel="StyleSheet" ; href="/css/carrito.css" ; type="text/css" />

    <title>Carrito</title>
    <script src="/js/fontAwesome.js"></script>
  </head>

  <body>
      <form id="carrito" runat="server">
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

                  <!-------------------------------------------------------------------------->
                  <div style="display: inline-block; width: 60%;">
                      <div style="background-color: white; border-radius: 8px; text-align: center; margin-top: 25px; margin-bottom: 25px">
                          <label style="font-size: 25px" class="titulo">Carrito de compras</label>
                          <div style="margin-top: 15px">
                              <asp:Label ID="lblMensajeCompra" runat="server" Style="font-size: 20px"></asp:Label>
                          </div>
                          <asp:GridView style="width: 80%; margin-left: 10%; margin-top: 2%;" ID="grdCarrito" runat="server" AutoGenerateColumns="False" OnRowDeleting="grdCarrito_RowDeleting" OnRowDataBound="grdCarrito_RowDataBound" BorderStyle="None" BorderWidth="0px" GridLines="None" RowStyle-BorderStyle="None">
                              <Columns>
                                  <asp:TemplateField HeaderText="ID" ShowHeader="False" Visible="False">
                                      <ItemTemplate>
                                          <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID_PRODUCTO") %>'>></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField>
                                      <ItemTemplate>
                                          <asp:Image ID="ImageProd" ImageUrl='<%# Bind("IMAGEN") %>' style="border-radius:10px;width:80%;max-height:150px" runat="server" />
                                      </ItemTemplate>
                                      <HeaderStyle Width="15%" />
                                      <ItemStyle Width="25%" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Producto">
                                      <ItemTemplate>
                                          <asp:Label ID="lblNombre" runat="server" style="width:25%;" Text='<%# Bind("NOMBRE") %>'>></asp:Label>
                                      </ItemTemplate>
                                      <HeaderStyle Width="25%" />
                                      <ItemStyle Width="20%" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Cantidad">
                                      <ItemTemplate>
                                          <asp:Label ID="lblCantidad" runat="server" style="width:10%;" Text='<%# Bind("CANTIDAD") %>'>></asp:Label>
                                      </ItemTemplate>
                                      <HeaderStyle Width="10%" />
                                      <ItemStyle Width="10%" />
                                  </asp:TemplateField>
                                  <asp:TemplateField>
                                      <ItemTemplate>
                                          <asp:Label  ID="lblPrecioUPESOS" runat="server" Text="$" style="width:0.1%"></asp:Label>
                                      </ItemTemplate>
                                      <HeaderStyle/>
                                      <ItemStyle/>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Precio Unitario">
                                      <ItemTemplate>
                                          <asp:Label ID="lblPrecioU" runat="server" style="width:15%;" Text='<%# Bind("PRECIO") %>'>></asp:Label>
                                      </ItemTemplate>
                                      <HeaderStyle Width="10%" />
                                      <ItemStyle Width="10%" />
                                  </asp:TemplateField>
                                  <asp:TemplateField>
                                      <ItemTemplate>
                                          <asp:Label  ID="lblPrecioPESOS" runat="server" Text="$" style="width:0.1%"></asp:Label>
                                      </ItemTemplate>
                                      <HeaderStyle/>
                                      <ItemStyle/>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Precio">
                                      <ItemTemplate>
                                          <asp:Label ID="lblPrecio" runat="server" style="width:20%;" Text='<%# Bind("PRECIO") %>'>></asp:Label>
                                      </ItemTemplate>
                                      <HeaderStyle Width="10%" />
                                      <ItemStyle Width="10%" />
                                  </asp:TemplateField>
                                  <asp:TemplateField ShowHeader="False" ItemStyle-CssClass="ultimo">
                                      <ItemTemplate>
                                          <asp:LinkButton ID="LinkButton1" runat="server" style="width:10%;" CausesValidation="False" CommandName="Delete" Text="Eliminar"><i style="text-decoration: none;color: brown;font-size: 30px;" class="far fa-trash-alt"></i></asp:LinkButton>
                                      </ItemTemplate>
                                      <HeaderStyle Width="10%" />
                                  </asp:TemplateField>
                              </Columns>
                              <RowStyle CssClass="rcgvTD"/>
                              <AlternatingRowStyle Height="50px" CssClass="rowAlterna"/>
                          </asp:GridView>
                          <div style="margin-bottom:20px">
                              <table id="tablaTotal" runat="server"  style="width:90%;">
                                  <tr style="width: 100%; margin-bottom: 50px">
                                      <td style="width: 25%"></td>
                                      <td style="width: 25%; font-size: 18px;text-align: end"><strong>TOTAL :</strong>
                                      </td>
                                      <td id="TOTAL" runat="server" style="width: 25%; font-size: 18px; margin-left: 20%"></td>

                                      <td style="width: 25%"></td>
                                      <td></td>
                                  </tr>
                                  </table>
                          </div>
                          <div runat="Server" id="OpcionesDePago">
                              <table  style="width:100%;text-align:left;padding-left:5%;padding-right:5%">
                                  <tr style="margin-top: 2%; margin-bottom: 5%">
                                      <td>
                                          <table style="width:100%">
                                              <tr style="width:100%">
                                                  <td style="width:25%"><strong>Modo de envio</strong></td>
                                                  <td style="width:25%">
                                                      <asp:DropDownList CssClass="txtASP" style="width:75%;-moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" ID="ddlModoEnvio" runat="server" required="true">
                                                      </asp:DropDownList>
                                                  </td>
                                                  <td style="width:25%"><strong>Modo de pago</strong></td>
                                                  <td style="width:25%">
                                                      <asp:DropDownList CssClass="txtASP" style="width:75%;-moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" ID="ddlMododePago" runat="server" required="true">
                                                      </asp:DropDownList>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td style="width:25%"><strong>Escoja sucursal</strong> </td>
                                                  <td style="width:25%">
                                                      <asp:DropDownList CssClass="txtASP" style="width:75%;-moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" ID="ddlSucursales" runat="server" AutoPostBack="True" ValidateRequestMode="Disabled" required="true">
                                                      </asp:DropDownList>
                                                  </td>
                                                  <td style="width:25%"><strong>Numero de tarjeta</strong></td>
                                                  <td style="width:25%">
                                                      <asp:TextBox CssClass="txtASP" type="number" maxlength="5" style="width:75%;-moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" ID="txtNroTarjeta" runat="server" required="true"></asp:TextBox>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td style="width:25%"></td>
                                                  <td style="width:25%"></td>
                                                  <td style="width:25%"><strong>Código de seguridad de su tarjeta</strong></td>
                                                  <td style="width:25%">
                                                      <asp:TextBox CssClass="txtASP" type="number" maxlength="5" style="width:75%;-moz-box-sizing: content-box; -webkit-box-sizing: content-box; box-sizing: content-box;" ID="txtNroSeguridad" runat="server" required="true"></asp:TextBox>
                                                  </td>
                                              </tr>
                                          </table>
                                      </td>
                                  </tr>
                              </table>
                          </div>
                          <br />
                      </div>
                      <div style="margin-bottom:25px">
                          <button runat="server" id="btnVaciarCarrito" type="button" class="btnASP" style="width: 40%;" onclick="btnVaciar_Click()">Vaciar Carrito</button>
                          <asp:Button runat="server" ID="btnFinalizarCompra" CssClass="btnASP" Style="width: 40%;" OnClick="btnFinalizarCompra_Click" Text="FINALIZAR COMPRA" />
                      </div>
                  </div>


              </div>
          <div class="footer" >
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
    function btnVaciar_Click() {
        if (confirm('¿Desea limpiar el carrito?')) {
            window.location.href = '/Carrito.aspx?Vaciar=true';
        }
    }
    </script>
</html>

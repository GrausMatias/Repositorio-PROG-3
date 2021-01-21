<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="Vistas.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="StyleSheet" ; href="/css/home.css" ; type="text/css" />
    <link rel="StyleSheet" ; href="/css/footer.css" ; type="text/css" />
    <link rel="StyleSheet" ; href="/css/header.css" ; type="text/css" />
    <link rel="StyleSheet" ; href="/css/categorias.css" ; type="text/css" />

    <title>Categoria</title>
    <script src="https://kit.fontawesome.com/475f4f5709.js"></script>
  </head>
<body>
    <header>
      <div class="EspacioLogo">
        <img src="/img/logo.jpg" ; class="Logo" />
      </div>

      <div class="EspacioBuscador">
        <input
          type="text"
          name="search"
          placeholder="Buscar"
          class="bus"
          autocomplete="off"
        />
      </div>
      <div class="EspacioAtajos">
        <a href="/carrito.html" class="fas fa-user user"></a>

        <a href="/carrito.html" class="fas fa-shopping-cart cart"></a>
      </div>
      <div class="EspacioBarraNavegacion">
        <ul class="nav">
          <li class="name">
            <a href="#">Home</a>
          </li>
          <li class="name">
            <a href="#">Categorias</a>
            <ul>
              <li>
                <a href="/categoria.html">Monitores</a>
              </li>
              <li>
                <a href="/categoria.html">Televisores</a>
              </li>
              <li>
                <a href="/categoria.html">Tablet</a>
              </li>
              <li>
                <a href="/categoria.html">Celulares</a>
              </li>
            </ul>
          </li>
          <li class="name">
            <a href="#">Contacto</a>
          </li>
        </ul>
      </div>
      
    </header>
   
    <!-------------------------------------------------------------------------->
    <div class="filtros">
      <ul>
        <li>
          Filtrar por:
          <ul class="espacio">
            <li class="espacio">
              Orden precio
              <ul>
                <li>mayor</li>
                <li>menor</li>
              </ul>
            </li>
            <li class="espacio">
              Ordenar 
              <ul>
                <li>mas nuevo</li>
                <li>mas viejo</li>
              </ul>
            </li>
            <li class="espacio">
              Marca
              <ul>
                <li>marca1</li>
                <li>marca2</li>
                <li>marca3</li>
              </ul>
            </li>
            <li class="espacio">
              Precio
              <ul>
                <label>maximo</label>
                <li>$<input class="minimo" type="text"></li>
                <label>minimo</label>
                <li>$<input class="maximo" type="text"></li>
              </ul>
            </li>
          </ul>
        </li>
      </ul>
    </div>
    <!-------------------------------------------------------------------------->
    <div class="productosCategorias">
      
      <a class="p1" href="/categoria.html">
        <label class="lblp1">producto 1</label>
      </a>
      <a class="p2" href="/categoria.html">
        <label class="lblp2">producto 2</label>
      </a>
      <a class="p3" href="/categoria.html">
        <label class="lblp3">producto 3</label>
      </a>
      <a class="p4" href="/categoria.html">
        <label class="lblp4">producto 4</label>
      </a>
      <a class="p5" href="/categoria.html">
        <label class="lblp5">producto 5</label>
      </a>
      <a class="p6" href="/categoria.html">
        <label class="lblp6">producto 6</label>
      </a>
      <a class="p7" href="/categoria.html">
        <label class="lblp7">producto 7</label>
      </a>
      <a class="p8" href="/categoria.html">
        <label class="lblp8">producto 8</label>
      </a>
      
  </div>
   
    <!-------------------------------------------------------------------------->
    <footer>
      <div class="DivFoot">
        <h2 class="cont">Contactenos</h2>
        <!-- Iconos de redes sociales -->
        <ul>
          <li class="primerIco">
            <a href="https://www.instagram.com/"
              ><i class="fab fa-instagram-square tamIcoRed" ;></i
            ></a>
          </li>
          <li class="icoRedes">
            <a href="https://twitter.com/"
              ><i class="fab fa-twitter tamIcoRed"></i
            ></a>
          </li>
          <li class="icoRedes">
            <a href="https://facebook.com/"
              ><i class="fab fa-facebook-square tamIcoRed"></i
            ></a>
          </li>
          <li class="icoRedes">
            <a href="https://github.com/"
              ><i class="fab fa-github tamIcoRed"></i
            ></a>
          </li>
        </ul>
        <ul>
          <li class="primero">
            <i>Instagram</i>
          </li>
          <li class="redes">
            <i>Twitter</i>
          </li>
          <li class="redes">
            <i>Facebook</i>
          </li>
          <li class="redes">
            <i>Github</i>
          </li>
        </ul>
      </div>
    </footer>
</body>
</html>

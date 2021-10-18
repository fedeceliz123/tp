<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InterfazU.Paginas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Css/LoginCss.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body class="fondo-login">
    <form id="form1" runat="server">
        <div class="fondo">
                 <div class="formulario">
                      <img src="../Resources/logo.png" class="imagen-logo" />

                    <div class="input-group mb-2 tamano">
                       
                        <asp:TextBox runat="server" ID="tbUsuario" type="text" CssClass="form-control entrada" placeholder="Usuario"  />
                    </div>
                    <div class="input-group mb-2 tamano">
                        
                         <asp:TextBox runat="server" ID="tbClave" type="password" CssClass="form-control entrada2" placeholder="Contraseña"   />
                        <button class="btn btn-primary entrada3" type="button" id="button-addon1"><i class="fas fa-eye"></i></button>
                       

                        
                    </div>
                    <div>
                        <a  class="link-log">Recuperar Clave</a>
                    </div>
                    <div>
                        <asp:Button runat="server" CssClass="btn btn-primary m-4 "  Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click"/>
                        
                    </div>
            </div>
             

        </div>

        
    </form>
</body>
</html>

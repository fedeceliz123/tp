<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loandig.aspx.cs" Inherits="WebStagePro.Paginas.Loandig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

      <link href="../Content/bootstrap.css" rel="stylesheet" />
  
    
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <style>
        .contenedorLoad{
            height:100vh;
            display:flex;
            flex-direction:column;
            justify-content:center;
            align-items:center;
            background-color:dimgrey
        }

        .imagenRadio{
                border-style:dotted;
                border-color:#E09B30;
                border-radius:50%;
                border-width:10px;
                margin:5px;
                animation: loading 5s ease infinite;
        }
          .imagenRadio3{
                border-style:dotted;
                border-color:#E09B30;
                border-radius:50%;
                border-width:0px;
                
               
                animation: loading 5s ease infinite;
        }
        .imagenRadio2{
                border-style:dotted;
                border-color:#E09B30;
                border-radius:50%;
                border-width:10px;
                margin:10px;
                animation: loading2 5s ease infinite;
        }

        @keyframes loading2{
            
            
            0%{
                transform: rotate(0deg);
                   
            }
            50%{
                transform:  rotate(180deg);
              

            }
            100%{
                transform:rotate(360deg);
                 

            }



        }
          @keyframes loading{
            0%{
                transform:rotate(0deg);
                   
            }
            50%{
                transform:rotate(-180deg);
                   
            }
            100%{
                transform:rotate(-360deg);
                   

            }



        }

          
        
    </style>


</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedorLoad">
        <div  >
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableCdn="true"></asp:ScriptManager>
            <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>
            <div class="imagenRadio2" >
            <div class="imagenRadio3">
                <div class="imagenRadio">

                <asp:Image ID="imgLoading" runat="server" ImageUrl="~/Imagenes/logo.png" Height="300px" />
                </div>
            </div>
                </div>
          
        </div>
            
           <h1  style="color:white">Cagando ...</h1>
        </div>
        
    </form>
</body>
</html>

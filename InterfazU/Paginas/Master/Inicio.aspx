<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/Master.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="InterfazU.Paginas.Master.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  <link href="../../Content/bootstrap.css" rel="stylesheet" />
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Css/InicioCSS.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    
    <div class="container">
        <div class="row centrar">
            
            


         <asp:Calendar ID="Calendar1" runat="server" BackColor="#999999" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" Height="70%">
                <SelectedDayStyle BackColor="#0066FF" />
            </asp:Calendar>
            </div>
            
        
         
</div>



    
    


</asp:Content>





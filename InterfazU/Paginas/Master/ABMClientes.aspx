<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/Master.Master" AutoEventWireup="true" CodeBehind="ABMClientes.aspx.cs" Inherits="InterfazU.Paginas.Master.ABMClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" />
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">


        <div class="row ml-5 mt-5">
            <div class="col-xl-2 col-md-4 col-sm-1"></div>
            <div class="col-xl-5 col-md-4 col-sm-11">
                <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"  ></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Dni:"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"  ></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                <div class="row">
                    <div class="input-group ">
                        
                         <asp:TextBox runat="server" ID="tbFechaN" type="text" CssClass="form-control entrada2" Enabled="false"    />
                        
                        <asp:ImageButton ID="ImageButton1" runat="server"  ImageUrl="../../Resources/calendario1.png" Height="38px" Width="55px" CssClass="btn btn-primary" OnClick="ImageButton1_Click"/>
                                      
                    </div>
                    <asp:Calendar ID="Calendar1" runat="server" Width="70%" style="margin-left:30px;" Visible="false" OnSelectionChanged="Calendar1_SelectionChanged" BorderStyle="Double" BorderWidth="2px" BackColor="White" BorderColor="#0066FF" DayNameFormat="Shortest" FirstDayOfWeek="Monday" Font-Bold="True" Font-Italic="True" Font-Names="Arial" Font-Overline="False" ForeColor="#0066FF">
                        <TitleStyle BackColor="#0066FF" ForeColor="White" />
                    </asp:Calendar>
                </div>

           
                
                
           </div>
            <div class="col-xl-5 col-md-4 col-sm-11">

                 <asp:Label ID="Label2" runat="server" Text="Apellido::"></asp:Label>
                 <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="Sexo:"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" >
                    <asp:ListItem>Seleccionar</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                    <asp:ListItem>M</asp:ListItem>
                 </asp:DropDownList>
                 
                <asp:Label ID="Label6" runat="server" Text="Nombre:"></asp:Label>
                 <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>

            </div>

        </div>
    </div>

    

    </div>
</asp:Content>

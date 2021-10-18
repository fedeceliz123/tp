<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/Master.Master" AutoEventWireup="true" CodeBehind="ListarEmpleados.aspx.cs" Inherits="InterfazU.Paginas.Master.ListarEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" />

    <script type="text/javascript">

        function seleccion(obj) {
            var row = obj.parentNode.parentNode;

            if (obj.checked) {
                row.style.backgroundColor = "blue";
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container"  >
        <div class="row" style="height:40vh;">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

         <div class="row" style="height:60vh; padding-left:10%;">
             <asp:GridView ID="gvEmp" runat="server" AutoGenerateColumns="False" CssClass="table" OnSelectedIndexChanged="gvEmp_SelectedIndexChanged" 
                  DataKeyNames="dni" OnRowCommand="gvEmp_RowCommand" BorderStyle="None"
                  >
                 <Columns>
                    
                    
                     <asp:BoundField HeaderText="DNI" DataField="dni"  >
                     <HeaderStyle BorderStyle="Double" BorderWidth="2px" HorizontalAlign="Justify" VerticalAlign="Middle" />
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="Nombre" DataField="nombre" >
                     <HeaderStyle BorderStyle="Double" BorderWidth="2px" HorizontalAlign="Center" VerticalAlign="Middle" />
                     <ItemStyle Width="200px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="APELLIDO" DataField="apellido" >
                     <HeaderStyle BorderStyle="Double" BorderWidth="2px" HorizontalAlign="Center" VerticalAlign="Middle" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="Puesto" DataField="puesto" ControlStyle-Width="500px" >
                     

<ControlStyle Width="500px"></ControlStyle>
                     <HeaderStyle BorderStyle="Double" BorderWidth="2px" HorizontalAlign="Center" VerticalAlign="Top" />
                     

                     </asp:BoundField>
                     
                     
                     <asp:ButtonField ButtonType="Button" CommandName="editar" Text="Editar" ControlStyle-CssClass="btn btn-primary" >
                     
                                    
                     
                     


<ControlStyle CssClass="btn btn-primary"></ControlStyle>
                     <HeaderStyle BorderStyle="Double" HorizontalAlign="Center" VerticalAlign="Middle" />
                     <ItemStyle Width="100px" />
                     
                                    
                     
                     


                     </asp:ButtonField>
                     <asp:ButtonField ButtonType="Button" CommandName="eliminar" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" >
                     
                                    
                     
                     

<ControlStyle CssClass="btn btn-danger"></ControlStyle>
                     <ItemStyle Width="100px" />
                     </asp:ButtonField>
                     
                                    
                     
                     

                     <asp:ButtonField ButtonType="Button" CommandName="detalle" Text="Detalles" ControlStyle-CssClass="btn btn-success">
                     <ItemStyle Width="100px" />
                     </asp:ButtonField>
                     
                                    
                     
                     

                 </Columns>

                 

             </asp:GridView>
        </div>

    </div>


</asp:Content>

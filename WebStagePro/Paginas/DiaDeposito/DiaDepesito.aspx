<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="DiaDepesito.aspx.cs" Inherits="WebStagePro.Paginas.DiaDeposito.DiaDepesito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

         <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid" style="height:auto; background-color:white; min-height:100vh; min-width:600px">
         
     <div class="row" style="padding-top:30px">
            <h3 style="margin-left:10px">Pesonal para deposito</h3>

        </div>
       <hr />
         <div class="row" style="padding-top:30px">
             <div class="col-lg-4 col-10">
          <asp:TextBox ID="txtPersonal" runat="server" CssClass="form-control"></asp:TextBox>

             </div>
             <div class="col-lg-2 col-2">
                 <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
             </div>
        </div>
       <hr />    

          <div class="row"  style="padding-top:30px"">
          
            <div class="col-lg-6 col-sm-12">
                <asp:GridView ID="GVPersonal" runat="server" AutoGenerateColumns="false" DataKeyNames="dni" OnRowCommand="GVPersonal_RowCommand" CssClass="table table-hover table-dark">
                    <Columns>
                        <asp:BoundField HeaderText="Dni" DataField="dni" />
                         <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="apellido"/>
                        <asp:BoundField HeaderText="Puesto" DataField="puesto" />
                       
                        <asp:ButtonField CommandName="Agregar" ControlStyle-CssClass="btn btn-success"  HeaderText="Carga" ButtonType="Image" ImageUrl="~/Imagenes/V.png">
                            
<ControlStyle CssClass="btn btn-success" Height="40px" Width="50px"></ControlStyle>
                </asp:ButtonField>
                    </Columns>

                </asp:GridView>
              
               
        </div>
              
              <div class="col-lg-6 col-sm-12">
                <div class="row" style="margin-left:5px;margin-right:5px">

                        <asp:Label ID="Label2" runat="server" Text="DNI"></asp:Label>
                
                <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>


                </div>
                  
                  
                  
                  <div class="row" style="margin-left:5px;margin-right:5px">

               <asp:Label ID="Label1" runat="server" Text="Nombre y Apellido"></asp:Label>
                
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                  </div>

                   <div class="row" style="margin-left:5px;margin-right:5px">

               <asp:Label ID="Label3" runat="server" Text="Fecha"></asp:Label>
                
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control"  TextMode="Date" ></asp:TextBox>
                  </div>
                 
                  


                  <div class="row" style="padding-top:30px ;margin-left:5px;margin-right:5px; margin-bottom:10px" >
                      <div class="col-2">
                      <asp:Button ID="btnAgregar" runat="server" Text="Cargar"  CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>

                      </div>
                     
                      
                      <div class="col-2">
                     
                          <asp:Button ID="btnVolver" runat="server" Text="Volver"  CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
                      </div>
                  </div>
            
               
        </div>






    </div>
     


    </div>

         <!--Modal Carga -->
 <div class="modal fade" id="modalCarga" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                
                 <asp:Label ID="lblCarga" runat="server" Text="" CssClass="col-form-label-lg text-bold"></asp:Label>

                
             </div>
             <div class="modal-body">
                 <div style="text-align:center">

                 <asp:Image ID="imgCarga" runat="server" Height="150px" />
                 <br />
                   <br />
                 <asp:Label ID="lblAccion" runat="server" Text="" CssClass="col-form-label-md text-bold"></asp:Label>
                 </div>
             </div>
             <div class="modal-footer">
                 
               <button class="btn btn-primary" data-dismiss="modal">OK</button>
             </div>
         </div>
     </div>
 </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>

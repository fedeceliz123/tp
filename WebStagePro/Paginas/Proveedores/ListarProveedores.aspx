<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="ListarProveedores.aspx.cs" Inherits="WebStagePro.Paginas.Proveedores.ListarProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <link href="../../Content/bootstrap.css" rel="stylesheet" />
  
    
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />

    
 
    <script src="../../Scripts/bootstrap.js"></script>
     <style>
        .contenedorLoad{
           
            display:flex;
            flex-direction:column;
            justify-content:center;
            align-items:center;
            background-color:dimgrey;
          
            
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


   
    
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    

    <div class="container-fluid" style="height:auto; background-color:white; min-width:600px">

        
        <div class="row" style="padding-top:30px">

            <div class="col-lg-5 col-8">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="col-lg-2 col-1">
                  <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
              </div>

        </div>
            <div class="row" style="margin-top:10px;margin-left:10px">
                <asp:CheckBox ID="chActivo" runat="server"  Text="-Listar Inactivos"  AutoPostBack="false" CssClass="col-form-label-md text-bold" OnCheckedChanged="chActivo_CheckedChanged" />
            </div>
        <hr />
        <div class="row">
            <div class="col-lg-3  col-8">
            <h3>Lista de proveedores</h3>

            </div>
            <div class="col-lg-2 col-2">
                <asp:Button ID="Button1" runat="server" Text="Cargar Nuevo" CssClass="btn btn-success"  OnClick="Button1_Click"/>
            </div>
        </div>
        <hr />

        <div class="row" style="min-height:600px" >


        <asp:GridView ID="GVProveedores" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-dark" DataKeyNames="Cuit" OnRowCommand="GVProveedores_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Cuit" DataField="Cuit" />
                <asp:BoundField HeaderText="Razon Social" DataField="Razon Social"/>
                <asp:BoundField HeaderText="Nombre Fantasia" DataField="Nombre Fantasia"/>
                <asp:BoundField HeaderText="Rubro" DataField="Rubro"/>
                      <asp:ButtonField CommandName="Ver" ControlStyle-CssClass="btn btn-success"  HeaderText="Ver" ButtonType="Image" ImageUrl="~/Imagenes/Lupa2.png">
<ControlStyle CssClass="btn btn-success" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
                <asp:ButtonField CommandName="Editar" ControlStyle-CssClass="btn btn-primary" HeaderText="Editar" ButtonType="Image" ImageUrl="~/Imagenes/editar.png" >
<ControlStyle CssClass="btn btn-primary" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
               <asp:ButtonField CommandName="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" ButtonType="Image" ImageUrl="~/Imagenes/eliminar.png">
          
<ControlStyle CssClass="btn btn-danger" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
            </Columns>



        </asp:GridView>


        </div>

    </div>

        <!--Modal editar -->
 <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                 <asp:Label ID="lblModal" runat="server"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                 <asp:Label ID="Label1" runat="server" Text="Cuit"></asp:Label>
                 <asp:TextBox ID="txtCuit" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>                                         
                               
                                
                 <asp:Label ID="Label3" runat="server" Text="Razon social"></asp:Label>
                 <asp:TextBox ID="txtRazonS" runat="server" CssClass="form-control"></asp:TextBox>
                 
                  <asp:Label ID="Label6" runat="server" Text="Nombre fantasia"></asp:Label>
                 <asp:TextBox ID="txtNombreF" runat="server" CssClass="form-control" ></asp:TextBox>
                 
                 <asp:Label ID="Label7" runat="server" Text="Tipo iva"></asp:Label>
                 <asp:DropDownList ID="selectIva" runat="server" CssClass="form-select">
                     <asp:ListItem Value="Monotributo A">
                         Monotributo A
                     </asp:ListItem>
                      <asp:ListItem Value="Monotributo B">
                         Monotributo B
                     </asp:ListItem>
                      <asp:ListItem Value="Monotributo C">
                         Monotributo C
                     </asp:ListItem>
                      <asp:ListItem Value="Monotributo D">
                         Monotributo D
                     </asp:ListItem>
                      <asp:ListItem Value="Monotributo E">
                         Monotributo E
                     </asp:ListItem>
                      <asp:ListItem Value="Monotributo F">
                         Monotributo F
                     </asp:ListItem>
                      <asp:ListItem Value="Monotributo G">
                         Monotributo G
                     </asp:ListItem>
                      <asp:ListItem Value="Monotributo H">
                         Monotributo H
                     </asp:ListItem>
                 </asp:DropDownList>
                 

                 <asp:Label ID="Label4" runat="server" Text="Rubro"></asp:Label>
                 <asp:TextBox ID="txtRubro" runat="server" CssClass="form-control"  ></asp:TextBox>

                 <asp:Label ID="Label5" runat="server" Text="Fecha de ingreso"></asp:Label>                 
            
             <asp:TextBox ID="txtFechaingreso"  runat="server" AutoCompleteType="Disabled"  MaxLength="10" CssClass="form-control" TextMode="Date" ></asp:TextBox>
            
                 <asp:Label ID="Label8" runat="server" Text="Fecha de egreso" Visible="false"></asp:Label>
                  <asp:TextBox ID="txtFechaSal"  runat="server" AutoCompleteType="Disabled"  MaxLength="10" CssClass="form-control" TextMode="Date" Visible="false" ></asp:TextBox>
                 <asp:Label ID="Label9" runat="server" Text="Motivo de egreso" Visible="false"></asp:Label>
              <asp:TextBox ID="txtMot"  runat="server" AutoCompleteType="Disabled"  MaxLength="10" CssClass="form-control" Visible="false" ></asp:TextBox>

                    <hr />
                   <asp:Label ID="Label11" runat="server" Text="Datos geogravicos"></asp:Label>  
                 <hr />
                 <asp:Label ID="Label10" runat="server" Text="Pais"></asp:Label>                 
            
             <asp:TextBox ID="txtPais"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <asp:Label ID="Label12" runat="server" Text="Provincia"></asp:Label>                 
            
             <asp:TextBox ID="txtProvincia"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>

                  <asp:Label ID="Label13" runat="server" Text="Localidad"></asp:Label>                 
            
             <asp:TextBox ID="txtLocalidad"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>

                  <asp:Label ID="Label14" runat="server" Text="CP"></asp:Label>                 
            
             <asp:TextBox ID="txtCP"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control" TextMode="Number"  ></asp:TextBox>
                  <asp:Label ID="Label15" runat="server" Text="Barrio"></asp:Label>                 
            
             <asp:TextBox ID="txtBarrio"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <asp:Label ID="Label16" runat="server" Text="Calle"></asp:Label>                 
            
             <asp:TextBox ID="txtCalle"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <asp:Label ID="Label17" runat="server" Text="N°"></asp:Label>                 
            
             <asp:TextBox ID="txtN"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  TextMode="Number" ></asp:TextBox>
                  <asp:Label ID="Label18" runat="server" Text="Piso"></asp:Label>                 
            
             <asp:TextBox ID="txtPiso"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  TextMode="Number" ></asp:TextBox>
                  <asp:Label ID="Label19" runat="server" Text="Dpto"></asp:Label>                 
            
             <asp:TextBox ID="txtDpto"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <asp:Label ID="Label20" runat="server" Text="Mzna"></asp:Label>                 
            
             <asp:TextBox ID="txtMzna"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <asp:Label ID="Label21" runat="server" Text="Lote"></asp:Label>                 
            
             <asp:TextBox ID="txtLodte"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <hr />
                   <asp:Label ID="Label22" runat="server" Text="Datos de contacto"></asp:Label>  
                 <hr />
          <asp:Label ID="Label23" runat="server" Text="Codigo de area"></asp:Label>                 
            
             <asp:TextBox ID="txtCodArea"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  TextMode="Number" ></asp:TextBox>
                  <asp:Label ID="Label24" runat="server" Text="Telefono"></asp:Label>                 
            
             <asp:TextBox ID="txtTelefono"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  TextMode="Number"></asp:TextBox>
                  <asp:Label ID="Label25" runat="server" Text="Email"></asp:Label>                 
            
             <asp:TextBox ID="txtMail"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control" TextMode="Email" ></asp:TextBox>
                 
             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnReactivar" runat="server" Text="Reactivar" CssClass="btn btn-success"  OnClick="btnReactivar_Click" />
                 <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-success"  OnClick="btnEditar_Click" />
                 <button class="btn btn-primary" data-dismiss="modal">Cancelar</button>
             </div>
         </div>
     </div>

   

 </div>

      <!--Modal Eliminar -->
 <div class="modal fade" id="modalEliminar" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                 <asp:Label ID="lblEliminar" runat="server" Text="Esta seguro que desea eliminar este proveedor"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                 <asp:Label ID="Label2" runat="server" Text="Motivo:" CssClass="form-label text-bold" ></asp:Label>
                 <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control"></asp:TextBox>
             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger"  OnClick="btnEliminar_Click" />
                 <button class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="MaterialReparar.aspx.cs" Inherits="WebStagePro.Paginas.MaterialReparar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid" style="height:auto; background-color:white; min-width:600px">
         <div class="row" style="padding-top:30px">
            <h3 style="margin-left:10px">Material a reparar</h3>

        </div>
       <hr />

        <div class="row" style="padding-top:30px">
             <div class="col-lg-4 col-10">
          <asp:TextBox ID="txtMaterial" runat="server" CssClass="form-control"></asp:TextBox>

             </div>
             <div class="col-lg-2 col-2">
                 <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
             </div>
        </div>
       <hr />


            <div class="row"  style="padding-top:30px" >



                <div class ="col-lg-6 col-12">

                     <asp:GridView ID="GVMaterial" runat="server" AutoGenerateColumns="false" DataKeyNames="Codigo" OnRowCommand="GVMaterial_RowCommand" CssClass="table table-hover table-dark">
                    <Columns>
                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                         <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                        <asp:BoundField HeaderText="Modelo" DataField="Modelo"/>
                        <asp:BoundField HeaderText="Medida" DataField="Medida" />
                        <asp:BoundField HeaderText="Formato" DataField="Formato"/>
                        <asp:ButtonField CommandName="Agregar" ControlStyle-CssClass="btn btn-success"  HeaderText="Carga" ButtonType="Image" ImageUrl="~/Imagenes/V.png">
                            
<ControlStyle CssClass="btn btn-success" Height="40px" Width="50px"></ControlStyle>
                </asp:ButtonField>
                    </Columns>

                </asp:GridView>



                </div>
                <div class ="col-lg-5 col-11  " >

            <div class="row">

               
               <asp:Label ID="Label2" runat="server" Text="Codigo" CssClass="ml-3 "></asp:Label>

                
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control ml-4 "></asp:TextBox>
              
               
               
        </div>
              <div class="row">
               <asp:Label ID="Label1" runat="server" Text="Cantidad" CssClass="ml-3" ></asp:Label>
                
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control ml-4" type="number"></asp:TextBox>
             
               
        </div>
    


    
          
            <div class="row">
               <asp:Label ID="Label3" runat="server" Text="Fecha ingreso" CssClass="ml-3"></asp:Label>
                
                <asp:TextBox ID="txtFechaI" runat="server" CssClass="form-control ml-4" type="date"></asp:TextBox>
              
               
        </div>
              <div class="row">
               <asp:Label ID="Label4" runat="server" Text="Detalle" CssClass="ml-3"></asp:Label>
                
                <asp:TextBox ID="txtDetalle" runat="server" CssClass="form-control ml-4" Height="150px"  type="text" TextMode="MultiLine" Rows="10" ></asp:TextBox>
             
               
        </div>
    
         <!--botones-->

       <div class="row ml-3" style="padding-top:30px;padding-bottom:30px" >
                <div class="col-2 col-md-2 col-lg-2">
                  <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="btn btn-primary" OnClick="btnCargar_Click"  />

                </div>
                <div class="col-2 col-md-2 col-lg-2">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click"  />

                </div>
            </div></div>
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

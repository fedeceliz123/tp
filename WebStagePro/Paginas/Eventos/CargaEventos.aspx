<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="CargaEventos.aspx.cs" Inherits="WebStagePro.Paginas.Eventos.CargaEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
               <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container-fluid" style="height:100%; background-color:white; min-width:600px;min-height:900px">

        <div class="row" style="padding-top:30px">
            <h3 style="margin-left:10px">Carga de eventos</h3>

        </div>
       <hr />   
            <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label2" runat="server" Text="Cliente"></asp:Label>
                
            <div class="row">

                <div class="col-lg-11 col-10">
            <asp:DropDownList ID="selectClientes" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>

                </div>
                <div class="col-lg-1 col-2">
                    <asp:ImageButton ID="btnMasCliente" runat="server" ImageUrl="../../Imagenes/mas.jpg"  Height="30px"  CssClass="imagenmas" OnClick="btnMasCliente_Click" />
                </div>
                    
                </div>
                

            </div>              
               
              <div class="col-lg-6 col-sm-12">
                     <asp:Label ID="Label6" runat="server" Text="Encargado"></asp:Label>
                
<div class="row">

                <div class="col-lg-11 col-10">
            <asp:DropDownList ID="selectEncargado" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:DropDownList>

                </div>
                <div class="col-lg-1 col-2">
                    <asp:ImageButton ID="btnMasEncargado" runat="server" ImageUrl="../../Imagenes/mas.jpg"  Height="30px"  CssClass="imagenmas" OnClick="btnMasEncargado_Click" />
                </div>
                    
                </div>
               
               
        </div>
        </div>
   

            <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">

                
                <asp:Label ID="Label1" runat="server" Text="Fecha de inicio"></asp:Label>
                
                <asp:TextBox ID="txtFechaI" runat="server" CssClass="form-control" type="date"></asp:TextBox>

             
              
               
        </div>
              <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label4" runat="server" Text="Fecha de fin"></asp:Label>
                
                <asp:TextBox ID="txtFechaF" runat="server" CssClass="form-control" type="date"></asp:TextBox>
             
               
        </div>
    </div>

        <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label5" runat="server" Text="Lugar"></asp:Label>
       <asp:TextBox ID="txtLugar" runat="server" CssClass="form-control" ></asp:TextBox>

              
               
        </div>
              <div class="col-lg-6 col-sm-12">
            
               <asp:Label ID="Label3" runat="server" Text="Hora de inicio"></asp:Label>
                
                  <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                      <asp:ListItem Value="00:00">00:00</asp:ListItem>
                      <asp:ListItem Value="01:00">01:00</asp:ListItem>
                      <asp:ListItem Value="02:00">02:00</asp:ListItem>
                      <asp:ListItem Value="03:00">03:00</asp:ListItem>
                      <asp:ListItem Value="04:00">04:00</asp:ListItem>
                      <asp:ListItem Value="05:00">05:00</asp:ListItem>
                      <asp:ListItem Value="06:00">06:00</asp:ListItem>
                      <asp:ListItem Value="07:00">07:00</asp:ListItem>
                      <asp:ListItem Value="08:00">08:00</asp:ListItem>
                      <asp:ListItem Value="09:00">09:00</asp:ListItem>
                      <asp:ListItem Value="10:00">10:00</asp:ListItem>
                      <asp:ListItem Value="11:00">11:00</asp:ListItem>
                      <asp:ListItem Value="12:00">12:00</asp:ListItem>
                      <asp:ListItem Value="13:00">13:00</asp:ListItem>
                      <asp:ListItem Value="14:00">14:00</asp:ListItem>
                      <asp:ListItem Value="15:00">15:00</asp:ListItem>
                      <asp:ListItem Value="16:00">16:00</asp:ListItem>
                      <asp:ListItem Value="17:00">17:00</asp:ListItem>
                      <asp:ListItem Value="18:00">18:00</asp:ListItem>
                      <asp:ListItem Value="19:00">19:00</asp:ListItem>
                      <asp:ListItem Value="20:00">20:00</asp:ListItem>
                      <asp:ListItem Value="21:00">21:00</asp:ListItem>
                      <asp:ListItem Value="22:00">22:00</asp:ListItem>
                      <asp:ListItem Value="23:00">23:00</asp:ListItem>

                  </asp:DropDownList>
               
        </div>
    </div>

          <div class="row"  style="padding-top:30px" >
          
        <%--    <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label7" runat="server" Text="Total"></asp:Label>
       <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" type="number" ></asp:TextBox>

              
               
        </div>--%>
              <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label8" runat="server" Text="Detalle"></asp:Label>
                
               <asp:TextBox ID="txtDetalle" runat="server" CssClass="form-control" Height="150px"  type="text" TextMode="MultiLine" Rows="10"  ></asp:TextBox>


               
        </div>
    </div>

       <div class="row" style="padding-top:30px;padding-bottom:30px" >
                <div class="col-2 col-md-2 col-lg-1">
                  <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="btn btn-primary" OnClick="btnCargar_Click"  />

                </div>
                <div class="col-2 col-md-2 col-lg-1">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click"  />

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

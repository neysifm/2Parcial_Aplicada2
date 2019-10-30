<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroParcial.aspx.cs" Inherits="_2Parcial_Aplicada2.Registros.RegistroParcial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header text-center">
    <h2>Registro Parcial</h2>
    </div>

<div class="container-fluid">
<div class="card text-center bg-light">
<div class="card-header"><%:Page.Title %></div>

    <div class="form-row">
            <%--ID--%>
            <div class="col-lg-6">
             <div class="form-group mx-sm-3 mb-2">
                <div class="col-sm-10">
                <label for="EstudianteID" runat="server">ID</label>
                <asp:TextBox ID="EstudianteID" runat="server" TextMode="Number"  CssClass="form-control" placeHolder="ID"></asp:TextBox>
                </div>
                </div>
                <asp:Button ID="BuscarButton" Text="Buscar" OnClick="BuscarButton_Click" class="btn btn-primary mb-2" runat="server" />  
             </div>

            <%--FECHA--%>
            <div class="col-lg-6">
             <div class="form-group">
                <div class="col-sm-10">
                <label for="FechaTextBox" runat="server">Fecha</label>
                <asp:TextBox ID="FechaTextBox" runat="server"  CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
              </div>
              </div>
         </div>

</div>
</div>
</asp:Content>

<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApresentacaoContatosUserControl.ascx.cs" Inherits="DBS.ContatosInternos.ApresentacaoContatos.ApresentacaoContatosUserControl" %>

<SharePoint:CssRegistration ID="CssRegistration1" runat="server" Name="/_layouts/DBS.ContatosInternos/ContatosInternos.css"></SharePoint:CssRegistration>



<%--<table id="tabela_contatos" border="0" cellpadding="0" cellspacing="0" class="tabela_contatos">

    <tr class="cabecalho_tabela_contatos">
        <td>Departamento</td>
        <td>Colaborador</td>
        <td>Ramal</td>
        <td>ID Radio</td>
        <td>Celular</td>
        <td>E-mail</td>

    </tr>


</table>--%>


<p class="subtitulo_pagina">:: Pessoas e Setores</p>
<p>&nbsp;</p>

<asp:Table ID="tabela_contatos" runat="server" CssClass="grid_tabela" Width="100%" >

</asp:Table>

<p>&nbsp;</p>






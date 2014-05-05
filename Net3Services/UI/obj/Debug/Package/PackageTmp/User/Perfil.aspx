<%@ Page ValidateRequest="true" Title="Perfil - Net3Services" Language="C#" MasterPageFile="~/User/Master.Master"
    AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="UI.User.Perfil" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="n3s" TagName="atualizacoes" Src="../Componentes/Atualizacoes.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Perfil.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <script type="text/javascript">
        $(document).ready(function () {
            var usu = $("#pageUsu").val();
            
            $('#<%= btnAddToNetwork.ClientID %>').click(function () {
                var elem = $(this).closest('.item');
                $.confirm({
                    'title': 'Adicionar Contato',
                    'message': 'Deseja realmente adicionar este usuário ao seu network?',
                    'buttons': {
                        'Sim': {
                            'action': function () {
                                $.ajax({
                                    type: "POST",
                                    url: "Perfil.aspx/AdicionaNetwork",
                                    data: "{}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: location.reload()
                                    });
                        }
                        }, 'Não': { /* Não faz nada e fecha a mensagem */ }
                    }
                });
            });

        /* Abre o light box de solicitar orçamento */
        $('#<%= solicitarOrcamento.ClientID %>').colorbox({
            width: "50%",
            height: "50%",
            transition: "fade",
            iframe: true,
            escKey: true,
            xhrError: "Falha ao carregar conteúdo"
        });
    });
    </script>
    <asp:UpdatePanel ID="upConteudo" runat="server">
        <ContentTemplate>
            <input type="hidden" id="pageUsu" value="<%= this.pageUsu %>" />
            <header>
              <h1><asp:Label ID="lblNome" runat="server" /></h1>
              <p>
                <asp:LinkButton ID="btnAddToNetwork" CssClass="button add" runat="server" Visible="true">Adicionar</asp:LinkButton>
                <a id="solicitarOrcamento" class="button money" runat="server" href="SocilicarOrcamento.aspx?id=this.usu">Solicitar Orçamento</a>
                <asp:HyperLink ID="hlEditar" CssClass="button edit" runat="server">Editar Perfil</asp:HyperLink>
              </p>
            </header>
            <br />
            <div id="info">
                <font class="iconesUm">&#85;</font><font class="subTitulo">Informações Pessoais</font>
                <br />
                <div id="infoEsquerda">
                  <ul>
                    <li title="Data de Nascimento"><font class="iconesDois">5</font><asp:Label ID="lblInfoDaraNasc" runat="server" /></li>
                    <li title="CPF"><font class="iconesDois">)</font><asp:Label ID="lblInfoCpf" runat="server" /></li>
                    <li title="RG"><font class="iconesDois">)</font><asp:Label ID="lblInfoRg" runat="server" /></li>
                    <li title="E-mail"><font class="iconesDois">@</font><asp:Label ID="lblInfoEmail" runat="server" /></li>
                    <li title="Site"><font class="iconesDois">w</font><asp:Label ID="lblInfoSite" runat="server" /></li>
                    <li title="Sexo"><font class="iconesDois">g</font><asp:Label ID="lblInfoSexo" runat="server" /></li>
                  </ul>
                </div>
                <div id="infoDireita">
                  <ul>
                    <li title="Telefone 1"><font class="iconesDois">c</font><asp:Label ID="lblInfoTelUm" runat="server" /></li>
                    <li title="Telefone 2"><font class="iconesDois">c</font><asp:Label ID="lblInfoTelDois" runat="server" /></li>
                    <li title="Celular 1"><font class="iconesDois">N</font><asp:Label ID="lblInfoCelUm" runat="server" /></li>
                    <li title="Celular 2"><font class="iconesDois">N</font><asp:Label ID="lblInfoCelDois" runat="server" /></li>
                  </ul>
                </div>
              </div>
            <div id="servs">
                <font class="iconesDois">(</font><font class="subTitulo">Serviços</font>
                <br />
                Serviços Contratados:
                <asp:Rating ID="ratServiContratados" runat="server" FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" WaitingStarCssClass="savedRatingStar" StarCssClass="ratingStar" ReadOnly="true" />
                <br />
                Serviços Prestados:
                <asp:Rating ID="ratServiPrestados" runat="server" FilledStarCssClass="filledRatingStar"
                    EmptyStarCssClass="emptyRatingStar" WaitingStarCssClass="savedRatingStar" StarCssClass="ratingStar"
                    ReadOnly="true" />
            </div>
            <div id="mapas">
                <font class="iconesDois">,</font><font class="subTitulo">Localização</font>
                <br />
                Colocar mapa com a localização cadastrada pela pessoa aqui (Marcinho)
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

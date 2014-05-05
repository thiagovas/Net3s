<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true"
    CodeBehind="CadServicos.aspx.cs" Inherits="UI.User.CadServicos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Forms.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../Scripts/Plugins-full.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () {
                $('#btnSalvar').click(function () {
                    var validade = true;
                    validade = $('#<%= txtNome.ClientID  %>').validarNome();
                    validade = $('#<%= txtPreco.ClientID  %>').validarNumero();
                    validade = $('#<%= txtDescricao.ClientID  %>').validarDescricao();

                    if (validade) {
                        var nome = $('#<%= txtNome.ClientID  %>').val();
                        var preco = $('#<%= txtPreco.ClientID  %>').val();
                        var uniMedida = $('#<%= ddlUnidadeMed.ClientID  %>').val();
                        var categoria = $('#<%= ddlCategoria.ClientID  %>').val();
                        var descricao = $('#<%= txtDescricao.ClientID  %>').val();

                        var regional = $('#<%= rbSim.ClientID  %>').is(':checked');
                        var nivelRegionalidade = "";

                        if (regional)
                            nivelRegionalidade = $('#<%= ddlNivelRegionalidade.ClientID  %>').val();

                        $.ajax({
                            type: "POST",
                            url: "CadServicos.aspx/CadastrarServico",
                            data: "{'nome':'" + nome + "','categoria':'" + categoria + "','preco':'" + preco + "','descricao':'" + descricao + "','regional':'" + regional + "', 'nivelRegionalidade':'" + nivelRegionalidade + "', 'uniMedida':'" + uniMedida + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (msg) {
                                enviarAlerta(msg.d);
                            }
                        });
                    }
                });
            });

            $('#btnSalvar').click(function () {
                var validade = true;
                validade = $('#<%= txtNome.ClientID  %>').validarNome();
                validade = $('#<%= txtPreco.ClientID  %>').validarNumero();
                validade = $('#<%= txtDescricao.ClientID  %>').validarDescricao();

                if (validade) {
                    var nome = $('#<%= txtNome.ClientID  %>').val();
                    var preco = $('#<%= txtPreco.ClientID  %>').val();
                    var uniMedida = $('#<%= ddlUnidadeMed.ClientID  %>').val();
                    var categoria = $('#<%= ddlCategoria.ClientID  %>').val();
                    var descricao = $('#<%= txtDescricao.ClientID  %>').val();

                    var regional = $('#<%= rbSim.ClientID  %>').is(':checked');
                    var nivelRegionalidade = "";

                    if (regional)
                        nivelRegionalidade = $('#<%= ddlNivelRegionalidade.ClientID  %>').val();

                    $.ajax({
                        type: "POST",
                        url: "CadServicos.aspx/CadastrarServico",
                        data: "{'nome':'" + nome + "','categoria':'" + categoria + "','preco':'" + preco + "','descricao':'" + descricao + "','regional':'" + regional + "', 'nivelRegionalidade':'" + nivelRegionalidade + "','uniMedida':'" + uniMedida + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            enviarAlerta(msg.d);
                        }
                    });
                }
            });
        });
    </script>
    <asp:ScriptManager ID="myScriptManager" runat="server" EnablePageMethods="true" />
    <br />
    <asp:Panel ID="panelConteudo" runat="server">
        <asp:UpdatePanel ID="upTela" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <h2>Cadastro de Serviço</h2>
                <div id="formNet3s">
                    <label>Nome do Serviço:</label>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="40" TabIndex="1" autofocus placeholder="Informe o nome do serviço" />
                    <a href="../Help/nomeServicoHelp.html?width=360" id="help1" class="jTip" name="Nome do Serviço:">?</a>
                    <label>Preço:</label>
                    <asp:TextBox runat="server" ID="txtPreco" MaxLength="9" TabIndex="2" placeholder="Infome o preço a ser cobrado pelo serviço" />
                    <a href="../Help/precoServicoHelp.html?width=360" id="help2" class="jTip" name="Preço do Serviço:">?</a>
                    <label>Uni. Medida:</label>
                    <asp:DropDownList ID="ddlUnidadeMed" runat="server" TabIndex="3">
                        <asp:ListItem>Alqueire</asp:ListItem>
                        <asp:ListItem>Ano</asp:ListItem>
                        <asp:ListItem>Are</asp:ListItem>
                        <asp:ListItem>Arroba</asp:ListItem>
                        <asp:ListItem>Caixa</asp:ListItem>
                        <asp:ListItem>Cent&#237;metro linear</asp:ListItem>
                        <asp:ListItem>Cent&#237;metro&#178;</asp:ListItem>
                        <asp:ListItem>Cent&#237;metro&#179;</asp:ListItem>
                        <asp:ListItem>Dec&#226;metro</asp:ListItem>
                        <asp:ListItem>Decigrama</asp:ListItem>
                        <asp:ListItem>Dec&#237;metro</asp:ListItem>
                        <asp:ListItem>Dia</asp:ListItem>
                        <asp:ListItem>Empreitada</asp:ListItem>
                        <asp:ListItem>Gal&#227;o</asp:ListItem>
                        <asp:ListItem>Grama</asp:ListItem>
                        <asp:ListItem>Gr&#227;o metrico</asp:ListItem>
                        <asp:ListItem>Fardo</asp:ListItem>
                        <asp:ListItem>Hectare</asp:ListItem>
                        <asp:ListItem>Hect&#244;metro</asp:ListItem>
                        <asp:ListItem>Hora</asp:ListItem>
                        <asp:ListItem>Jardas</asp:ListItem>
                        <asp:ListItem>L&#233;guas</asp:ListItem>
                        <asp:ListItem>Libras</asp:ListItem>
                        <asp:ListItem>M&#234;s</asp:ListItem>
                        <asp:ListItem>Metro linear</asp:ListItem>
                        <asp:ListItem>Metro&#178;</asp:ListItem>
                        <asp:ListItem>Metro&#179;</asp:ListItem>
                        <asp:ListItem>Miligrama</asp:ListItem>
                        <asp:ListItem>Milhas</asp:ListItem>
                        <asp:ListItem>Milimetro</asp:ListItem>
                        <asp:ListItem>Minuto</asp:ListItem>
                        <asp:ListItem>On&#231;a</asp:ListItem>
                        <asp:ListItem>P&#233;s</asp:ListItem>
                        <asp:ListItem>Polegadas</asp:ListItem>
                        <asp:ListItem>Polegadas&#178;</asp:ListItem>
                        <asp:ListItem>Quilate</asp:ListItem>
                        <asp:ListItem>Quilograma</asp:ListItem>
                        <asp:ListItem>Quilometro linear</asp:ListItem>
                        <asp:ListItem>Quil&#244;metro&#178;</asp:ListItem>
                        <asp:ListItem>Semana</asp:ListItem>
                        <asp:ListItem>Tonel</asp:ListItem>
                        <asp:ListItem>Tonelada</asp:ListItem>
                        <asp:ListItem>Unidade</asp:ListItem>
                    </asp:DropDownList>
                    <a href="../Help/uniMedServicoHelp.html?width=360" id="help4" class="jTip" name="Unidade de Medida:">?</a>
                    <label>Categoria:</label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" TabIndex="4">
                        <asp:ListItem Value="teste">Advocacia</asp:ListItem>
                        <asp:ListItem Value="teste">Artesanatos e Hobbies</asp:ListItem>
                        <asp:ListItem Value="teste">Autmóveis e Veículos</asp:ListItem>
                        <asp:ListItem Value="teste">Beleza e Estetica</asp:ListItem>
                        <asp:ListItem Value="teste">Casa e Decoração</asp:ListItem>
                        <asp:ListItem Value="teste">Construção Civil</asp:ListItem>
                        <asp:ListItem Value="teste">Consultoria</asp:ListItem>
                        <asp:ListItem>Cultura e Arte</asp:ListItem>
                        <asp:ListItem>Educação</asp:ListItem>
                        <asp:ListItem>Esporte</asp:ListItem>
                        <asp:ListItem>Festas e Eventos</asp:ListItem>
                        <asp:ListItem>Fotografia</asp:ListItem>
                        <asp:ListItem>Gastronomia</asp:ListItem>
                        <asp:ListItem>Informática e Tecnologia</asp:ListItem>
                        <asp:ListItem>Jardinagem</asp:ListItem>
                        <asp:ListItem>Jogos e Enrtetenimento</asp:ListItem>
                        <asp:ListItem>Manutenção Doméstica</asp:ListItem>
                        <asp:ListItem>Marketing e Comunicação</asp:ListItem>
                        <asp:ListItem>Medicina Alternativa</asp:ListItem>
                        <asp:ListItem>Moda, Roupas e Acessórios</asp:ListItem>
                        <asp:ListItem>Música</asp:ListItem>
                        <asp:ListItem>Saúde</asp:ListItem>
                        <asp:ListItem>Segurança</asp:ListItem>
                        <asp:ListItem>Serviços Gerais</asp:ListItem>
                        <asp:ListItem>Transportes</asp:ListItem>
                        <asp:ListItem>Turismo e Lazer</asp:ListItem>
                        <asp:ListItem>Veterinária</asp:ListItem>
                    </asp:DropDownList>
                    <a href="../Help/categoriaServicoHelp.html?width=360" id="help5" class="jTip" name="Categoria:">?</a>
                    <label>Regional:</label>
                    <asp:RadioButton ID="rbSim" runat="server" Text="Sim" OnCheckedChanged="rbSim_CheckedChanged"
                                AutoPostBack="true" TabIndex="5"/>
                    <asp:RadioButton ID="rbNao" runat="server" Text="Não" OnCheckedChanged="rbNao_CheckedChanged"
                                AutoPostBack="true" TabIndex="6" />
                    <a href="../Help/regionalServicoHelp.html?width=360" id="help6" class="jTip" name="Serviço Regional:">?</a>
                    <label>Nivel Regionalidade:</label>
                    <asp:DropDownList ID="ddlNivelRegionalidade" runat="server" TabIndex="7">
                        <asp:ListItem>País</asp:ListItem>
                        <asp:ListItem>Estado</asp:ListItem>
                        <asp:ListItem>Cidade</asp:ListItem>
                    </asp:DropDownList>
                    <a href="../Help/nivelRegServicoHelp.html?width=360" id="help7" class="jTip" name="Nivel de Regionalidade:">?</a>
                    <label class="labelCadServ">
                        Descrição:</label>
                    <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" MaxLength="400" TabIndex="8" placeholder="Insira uma breve descrição sobre o serviço" />
                    <a href="../Help/descricaoServicoHelp.html?width=360" id="help8" class="jTip" name="Descrição do Serviço:">?</a>
                    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                    <a href="#" class="button save" id="btnSalvar" TabIndex="9">Salvar</a>
                    <label id='msgErro'></label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:PlaceHolder ID="PlaceHolderSemPermisao" runat="server"></asp:PlaceHolder>
</asp:Content>

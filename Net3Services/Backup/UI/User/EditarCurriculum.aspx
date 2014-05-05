<%@ Page Title="Curriculum - Net3Services" Language="C#" MasterPageFile="~/User/Master.Master"
    AutoEventWireup="true" CodeBehind="EditarCurriculum.aspx.cs" Inherits="UI.User.Curriculum" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Forms.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/LightBox.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/Curriculum.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/TabControl.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/Atualizacoes.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../Scripts/Plugins-full.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /* Aplica as mascaras */
            $('#<%= txtDataPre.ClientID %>').mask("99/99/9999");
            $('#<%= txtDataCert.ClientID %>').mask("99/99/9999");
            $('#<%= txtDataInicio.ClientID %>').mask("99/99/9999");
            $('#<%= txtDataFimExp.ClientID %>').mask("99/99/9999");
            $('#<%= txtDataTermino.ClientID %>').mask("99/99/9999");
            $('#<%= txtDataInicioExp.ClientID %>').mask("99/99/9999");
            
            /* Abre as divs de cadastro */
            $('.tituloCad').click(function () {
                $(this).next(".cadastro").slideToggle('slow');
                var arredondar = $(this).attr("gambs");

                if (arredondar == "redondo") {
                    $(this).css('border-bottom-left-radius', '0px');
                    $(this).css('border-bottom-right-radius', '0px');
                    $(this).attr("gambs", "nope");
                }
                else {
                    $(this).css('border-radius', '10px');
                    $(this).attr("gambs", "redondo");
                }
            });

            /* Telas de confirmação de exclusão */
            $("a[name='excluirIdi']").click(function () {
                var elem = $(this).closest('.item');
                var index = $(this).attr("index");
                var id = $("#valId").val();

                $.confirm({
                    'title': 'Excluir Idioma',
                    'message': 'Tem certeza que deseja remover este idioma de seu currículo?',
                    'buttons': {
                        'Sim': {
                            'action': function () {
                                $.ajax({
                                    type: "POST",
                                    url: "EditarCurriculum.aspx/ExcluirIdioma",
                                    data: "{'id':'" + id + "', 'index': '" + index + "'}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: location.reload()
                                });
                            }
                        }, 'Não': { /* Não faz nada e fecha a mensagem */
                        }
                    }
                });
            });

            $("a[name='excluirCert']").click(function () {
                var elem = $(this).closest('.item');
                var index = $(this).attr("index");
                var id = $("#valId").val();

                $.confirm({
                    'title': 'Excluir Certificado',
                    'message': 'Tem certeza que deseja remover este certificado de seu currículo?',
                    'buttons': {
                        'Sim': {
                            'action': function () {
                                $.ajax({
                                    type: "POST",
                                    url: "EditarCurriculum.aspx/ExcluirCertificado",
                                    data: "{'id':'" + id + "', 'index': '" + index + "'}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: location.reload()
                                });
                            }
                        }, 'Não': { /* Não faz nada e fecha a mensagem */
                        }
                    }
                });
            });

            $("a[name='excluirPre']").click(function () {
                var elem = $(this).closest('.item');
                var index = $(this).attr("index");
                var id = $("#valId").val();

                $.confirm({
                    'title': 'Excluir Prêmio',
                    'message': 'Tem certeza que deseja remover este prêmio de seu currículo?',
                    'buttons': {
                        'Sim': {
                            'action': function () {
                                $.ajax({
                                    type: "POST",
                                    url: "EditarCurriculum.aspx/ExcluirPremio",
                                    data: "{'id':'" + id + "', 'index': '" + index + "'}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: location.reload()
                                });
                            }
                        }, 'Não': { /* Não faz nada e fecha a mensagem */
                        }
                    }
                });
            });

            $("a[name='excluirExp']").click(function () {
                var elem = $(this).closest('.item');
                var index = $(this).attr("index");
                var id = $("#valId").val();

                $.confirm({
                    'title': 'Excluir Experiência',
                    'message': 'Tem certeza que deseja remover esta experiência de seu currículo?',
                    'buttons': {
                        'Sim': {
                            'action': function () {
                                $.ajax({
                                    type: "POST",
                                    url: "EditarCurriculum.aspx/ExcluirExperiencia",
                                    data: "{'id':'" + id + "', 'index': '" + index + "'}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: location.reload()
                                });
                            }
                        }, 'Não': { /* Não faz nada e fecha a mensagem */
                        }
                    }
                });
            });


            $("a[name='excluirCur']").click(function () {
                var elem = $(this).closest('.item');
                var index = $(this).attr("index");
                var id = $("#valId").val();

                $.confirm({
                    'title': 'Excluir Curso',
                    'message': 'Tem certeza que deseja remover este curso de seu currículo?',
                    'buttons': {
                        'Sim': {
                            'action': function () {
                                $.ajax({
                                    type: "POST",
                                    url: "EditarCurriculum.aspx/ExcluirCurso",
                                    data: "{'id':'" + id + "', 'index': '" + index + "'}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: location.reload()
                                });
                            }
                        }, 'Não': { /* Não faz nada e fecha a mensagem */
                        }
                    }
                });
            });

            /* Exibir light box de edição */
            $("a[name='editarExp']").colorbox({
                width: "50%",
                height: "50%",
                transition: "fade",
                iframe: true,
                escKey: true,
                xhrError: "Falha ao carregar conteúdo",
                onClosed: function () { location.reload(true); }
            });

            $("a[name='editarIdi']").colorbox({
                width: "50%",
                height: "50%",
                transition: "fade",
                iframe: true,
                escKey: true,
                xhrError: "Falha ao carregar conteúdo",
                onClosed: function () { location.reload(true); }
            });

            $("a[name='editarCur']").colorbox({
                width: "50%",
                height: "50%",
                transition: "fade",
                iframe: true,
                escKey: true,
                xhrError: "Falha ao carregar conteúdo",
                onClosed: function () { location.reload(true); }
            });

            $("a[name='editarPre']").colorbox({
                width: "50%",
                height: "50%",
                transition: "fade",
                iframe: true,
                escKey: true,
                xhrError: "Falha ao carregar conteúdo",
                onClosed: function () { location.reload(true); }
            });

            $("a[name='editarCert']").colorbox({
                width: "50%",
                height: "50%",
                transition: "fade",
                iframe: true,
                escKey: true,
                xhrError: "Falha ao carregar conteúdo",
                onClosed: function () { location.reload(true); }
            });
        });
    </script>
    <input type="hidden" id="valId" value="<%= this.pageUsu %>" />
    <asp:ScriptManager ID="myScriptManager" runat="server" />
    <h1>
        Editar Currículo</h1>
    <br />
    <ul class="tabs">
        <li><a href="#tabs1">Cursos</a></li>
        <li><a href="#tabs2">Idiomas</a></li>
        <li><a href="#tabs3">Experiências</a></li>
        <li><a href="#tabs4">Certificados</a></li>
        <li><a href="#tabs5">Prêmios</a></li>
    </ul>
    <div class="tab_container">
        <!-- Cursos -->
        <div id="tabs1" class="tab_content">
            <asp:Panel ID="panelAddCursos" runat="server" DefaultButton="btnCadCurso">
                <div id="tituloCadCursos" class="tituloCad" gambs="redondo">
                    Cadastrar Curso</div>
                <div class="cadastro">
                    <asp:UpdatePanel ID="upCursos" runat="server">
                        <contenttemplate>
                            <div id="formNet3s">
                                <label>
                                    Nome Curso:</label>
                                <asp:TextBox ID="txtNomeCurso" runat="server" placeholder="Nome do curso ralizado"></asp:TextBox>
                                <br />
                                <label>
                                    Nome Instituição:</label>
                                <asp:TextBox ID="txtNomeInstiruicao" runat="server" placeholder="Nome da instituição na qual o curso foi ministrado"></asp:TextBox>
                                <br />
                                <label>
                                    Data de Inicio:</label>
                                <asp:TextBox ID="txtDataInicio" runat="server" placeholder="Data de inicio do curso"></asp:TextBox>
                                <br />
                                <label>
                                    Data de Termino:</label>
                                <asp:TextBox ID="txtDataTermino" runat="server" placeholder="Data de termino do curso"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Button ID="btnCadCurso" runat="server" Text="Salvar" CssClass="button save"
                                    OnClick="btnCadCurso_Click" />
                            </div>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </div>
            </asp:Panel>
            <asp:UpdatePanel ID="upMostrarCursos" runat="server" UpdateMode="Conditional">
                <contenttemplate>
                    <asp:PlaceHolder ID="phCursos" runat="server"></asp:PlaceHolder>
                </contenttemplate>
            </asp:UpdatePanel>
        </div>
        <!-- Idiomas -->
        <div id="tabs2" class="tab_content">
            <asp:Panel ID="panelAddIdiomas" runat="server">
                <div id="cadIdioma" class="tituloCad" gambs="redondo">
                    Cadastrar Idiomas</div>
                <div class="cadastro">
                    <asp:UpdatePanel ID="upIdioma" runat="server">
                        <contenttemplate>
                            <div id="formNet3s">
                                <label>
                                    Nome Idioma:</label>
                                <asp:TextBox ID="txtNomeIdioma" runat="server" placeholder="Nome do idioma falado"></asp:TextBox>
                                <label>
                                    Fluência:</label>
                                <asp:DropDownList ID="ddlFluencia" runat="server">
                                    <asp:ListItem Value="Iniciante">Iniciante</asp:ListItem>
                                    <asp:ListItem Value="Intermerdiario">Intermerdiário</asp:ListItem>
                                    <asp:ListItem Value="Avancado">Avançado</asp:ListItem>
                                    <asp:ListItem Value="Fluente">Fluente</asp:ListItem>
                                    <asp:ListItem Value="Nativo">Nativo</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <br />
                                <asp:Button ID="btnCadIdioma" runat="server" Text="Salvar" CssClass="button save"
                                    OnClick="btnCadIdioma_Click" />
                            </div>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </div>
            </asp:Panel>
            <asp:UpdatePanel ID="upMostrarIdioma" runat="server" UpdateMode="Conditional">
                <contenttemplate>
                    <asp:PlaceHolder ID="phIdiomas" runat="server"></asp:PlaceHolder>
                </contenttemplate>
            </asp:UpdatePanel>
        </div>
        <!-- Experiências -->
        <div id="tabs3" class="tab_content">
            <asp:Panel ID="panelAddExperiencias" runat="server">
                <div id="divTituloExp" class="tituloCad" gambs="redondo">
                    Cadastrar Expêrincia</div>
                <div class="cadastro">
                    <asp:UpdatePanel ID="upCadExp" runat="server">
                        <contenttemplate>
                            <div id="formNet3s">
                                <label>Nome Empresa:</label>
                                <asp:TextBox ID="txtNomeEmpresa" runat="server" placeholder="Nome da empresa em que trabalhou"></asp:TextBox>
                                <label>Este é seu emprego atual?</label>
                                <asp:RadioButton ID="rbSim" runat="server" Text="Sim" GroupName="radioExp" OnCheckedChanged="rbSim_CheckedChanged"
                                AutoPostBack="true" />
                                <asp:RadioButton ID="rbNao" runat="server" Text="Não" GroupName="radioExp" OnCheckedChanged="rbNao_CheckedChanged"
                                AutoPostBack="true" Checked="true" />
                                <label>Data de Inicio:</label>
                                <asp:TextBox ID="txtDataInicioExp" runat="server" placeholder="Data de inicio da experiência"></asp:TextBox>
                                <label>Data de Termino:</label>
                                <asp:TextBox ID="txtDataFimExp" runat="server" placeholder="Data de termino da experiência"></asp:TextBox>
                                <label>Atividades Realizadas:</label>
                                <asp:TextBox ID="txtAtividadesExp" runat="server" TextMode="MultiLine" MaxLength="400" placeholder="Insira uma breve descrição sobre as atividades realizadas durante este emprego" />
                                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                                <asp:Button ID="btnCadExperiencia" runat="server" Text="Salvar" CssClass="button save"
                                    OnClick="btnCadExperiencia_Click" />
                            </div>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </div>
            </asp:Panel>
            <asp:UpdatePanel ID="upExperiencias" runat="server" UpdateMode="Conditional">
                <contenttemplate>
                    <asp:PlaceHolder ID="phExperiencias" runat="server"></asp:PlaceHolder>
                </contenttemplate>
            </asp:UpdatePanel>
        </div>
        <!-- Certificados -->
        <div id="tabs4" class="tab_content">
            <asp:Panel ID="panelAddCertificados" runat="server">
            <div class="tituloCad" gambs="redondo">
                    Cadastrar Certificado</div>
                <div class="cadastro">
                    <asp:UpdatePanel ID="upCarCert" runat="server">
                        <contenttemplate>
                            <div id="formNet3s">
                                <label>Nome Certificado:</label>
                                <asp:TextBox ID="txtNomeCert" runat="server" placeholder="Nome do certificado recebido"></asp:TextBox>
                                <label>Nome Instituição:</label>
                                <asp:TextBox ID="txtNomeInstCert" runat="server" placeholder="Nome da instituição que expediu o certificado"></asp:TextBox>
                                <label>Data de Expedição:</label>
                                <asp:TextBox ID="txtDataCert" runat="server" placeholder="Data de expedição do certificado"></asp:TextBox>
                                <label>Descrição:</label>
                                <asp:TextBox ID="txtDescCert" runat="server" TextMode="MultiLine" MaxLength="400" placeholder="Descrição sobre as qualificações garantidas por este certificado" />
                                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                                <asp:Button ID="btnCadCert" runat="server" Text="Salvar" CssClass="button save" OnClick="btnCadCert_Click" />
                            </div>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </div>
            </asp:Panel>
            <asp:UpdatePanel ID="upCertificados" runat="server" UpdateMode="Conditional">
                <contenttemplate>
                    <asp:PlaceHolder ID="phCertificados" runat="server"></asp:PlaceHolder>
                </contenttemplate>
            </asp:UpdatePanel>
        </div>
        <!-- Prêmios -->
        <div id="tabs5" class="tab_content">
            <asp:Panel ID="panelAddPremios" runat="server">
                <div class="tituloCad" gambs="redondo">
                    Cadastrar Prêmio</div>
                <div class="cadastro">
                    <asp:UpdatePanel ID="upCadPre" runat="server">
                        <contenttemplate>
                            <div id="formNet3s">
                                <label>Nome Instituição:</label>
                                <asp:TextBox ID="txtNomeInstPre" runat="server" placeholder="Nome da instituição que concedeu o prêmio"></asp:TextBox>
                                <label>Nome do Prêmio:</label>
                                <asp:TextBox ID="txtNomePremio" runat="server" placeholder="Nome do prêmio recebido"></asp:TextBox>
                                <label>Data de Expedicao:</label>
                                <asp:TextBox ID="txtDataPre" runat="server" placeholder="Data de expedição do prêmio"></asp:TextBox>
                                <label>Descrição:</label>
                                <asp:TextBox ID="txtDescPre" runat="server" TextMode="MultiLine" MaxLength="400" placeholder="Insira uma breve descrição sobre as atividades realizadas para conquista do prêmio" />
                                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                                <asp:Button ID="btnCadPremio" runat="server" Text="Salvar" CssClass="button save" OnClick="btnCadPremio_Click"/>
                            </div>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </div>
            </asp:Panel>
            <asp:UpdatePanel ID="upPremios" runat="server" UpdateMode="Conditional">
                <contenttemplate>
                    <asp:PlaceHolder ID="phPremios" runat="server"></asp:PlaceHolder>
                </contenttemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

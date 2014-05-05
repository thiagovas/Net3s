<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterarSenha.aspx.cs" Inherits="UI.User.AlterarSenha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formRecuperarSenha" runat="server">
    <div>
        <label>Senha&nbsp;atual:&nbsp;</label>
        <input type="text" name="txtSenhaAtual" id="txtSenhaAtual" maxlength="34" /><br />
        <label>
        <label>Nova&nbsp;Senha:&nbsp;</label>
        <input type="text" name="txtNovasenha" id="txtNovaSenha" maxlength="34" /><br />
        <label>Confirmar&nbsp;nova&nbsp;senha:&nbsp;</label>
        <input type="text" name="txtConfirmNovaSenha" id="txtConfirmNovaSenha" maxlength="34" /><br />
        <a href="#" id="btnSalvar">Salvar&nbsp;altera&ccedil;&otilde;es</a>
    </div>
    </form>
</body>
</html>

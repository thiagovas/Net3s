using System;
using BoletoNet;

public partial class Bancos_Sicredi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime vencimento = DateTime.Now.AddDays(1);

        Instrucao_Sicredi item1 = new Instrucao_Sicredi(9, 5);
        Instrucao_Sicredi item2 = new Instrucao_Sicredi();

        Cedente c = new Cedente("10.823.650/0001-90", "SAFIRALIFE", "4406", "22324");
        c.Codigo = 13000;

        Boleto b = new Boleto(vencimento, 0.1m, "176", "00000001", c);
        b.NumeroDocumento = "00000001";

        b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
        b.Sacado.Endereco.End = "Endereço do seu Cliente ";
        b.Sacado.Endereco.Bairro = "Bairro";
        b.Sacado.Endereco.Cidade = "Cidade";
        b.Sacado.Endereco.CEP = "00000000";
        b.Sacado.Endereco.UF = "UF";

        // Exemplo de como adicionar mais informações ao sacado
        b.Sacado.InformacoesSacado.Add(new InfoSacado("TÍTULO: " + "2541245"));

        item2.Descricao += " " + item1.QuantidadeDias.ToString() + " dias corridos do vencimento.";
        b.Instrucoes.Add(item1);


        boletoBancario.Boleto = b;
        boletoBancario.Boleto.Valida();

        boletoBancario.MostrarComprovanteEntrega = (Request.Url.Query == "?show");
        boletoBancario.FormatoCarne = (Request.Url.Query == "?formatocarne");
    }
}

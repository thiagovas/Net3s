using MongoDB;

namespace Models
{
    public enum bancos 
    {
        BancoBrasil = 001,
        BancoSantander = 033,
        CaixaEconomicaFederal = 104,
        BancoBradesco = 237,
        BancoItau = 341,
        BancoUnibanco = 409,
        BancoSafra = 422
    }
    public class InformacoesBancarias
    {
        /// <summary>
        /// Identificador único de uma conta bancária.
        /// </summary>
        public Oid idContaBancaria { get; set; }
        /// <summary>
        /// Banco que a conta pertence.
        /// </summary>
        public bancos Banco { get; set; }
        public int Agencia { get; set; }
        public int DigitoAgencia { get; set; }
        public int Conta { get; set; }
        public int DigitoConta { get; set; }

        //Variável necessária para gerar um boleto bancário.
        //O código do cedente é o código do prestador que fica no banco.
        //Até onde sei o código tem que ser informado pelo próprio usuário. TODO: Verificar isso que escrevi do lado.
        public int CodigoCedente { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Chrisimos.Seguranca.Criptografia.CriptografiaAssimetrica;
using MongoDB;

namespace Models
{
    /// <summary>
    /// Classe que representa o model de usuario.
    /// </summary>
    public class Usuario : IDisposable
    {
        private bool IsDisposed = false; //Serve para evitar que o programador chame o metodo dispose várias vezes, o que é realmente desnecessário.
        
        ~Usuario()
        {
            DisposeObj();
        }

        public void Dispose()
        {
            DisposeObj();
            GC.SuppressFinalize(this);
        }

        private void DisposeObj()
        {
            if (!IsDisposed)
            {
                //Setar grandes campos para null.
                enderecosUsuario = null;
                ocorrenciasUsuario = null;
                historicoServicoUsuario = null;
                registrosUsuario = null;
                notificacoesUsuario = null;
                network = null;
                orcamentoUsuario = null;
                contaBanc = null;

                _id = null;
                login = null;
                senha = null;
                cpf_cnpj = null;
                rg = null;
                email = null;
                nome = null;
                codigoConfirma = null;

                IsDisposed = true;
            }
        }

        public Oid _id { get; set; }
        public string nome { get; set; }
        public Natureza natureza { get; set; }
        public string nomeFantasia { get; set; } //O nome fantasia somente é preenchido se o usuário for pessoa jurídica.
        public string sexo { get; set; }
        public string cpf_cnpj { get; set; }
        public string rg { get; set; }
        public string telefone1 { get; set; }
        public string telefone2 { get; set; }
        public string celular1 { get; set; }
        public string celular2 { get; set; }
        public string email { get; set; }
        public string site { get; set; }
        public DateTime dataNasc { get; set; }
        public DateTime dataCadastro { get; set; }
                
        public string login { get; set; }
        public string senha { get; set; }

        public int? status { get; set; }
        public double usuarioNotaMediaContratacoes { get; set; }
        public double usuarioNotaMediaPrestacoes { get; set; }

        public string codigoConfirma { get; set; }
        public Curriculum curriculumUsuario { get; set; }
        public List<Endereco> enderecosUsuario = new List<Endereco>();
        public List<Ocorrencia> ocorrenciasUsuario = new List<Ocorrencia>();
        public List<HistoricoServico> historicoServicoUsuario = new List<HistoricoServico>();
        public List<Registro> registrosUsuario = new List<Registro>();
        public List<Notificacao> notificacoesUsuario = new List<Notificacao>();
        public List<Contato> network = new List<Contato>();
        public List<Orcamento> orcamentoUsuario = new List<Orcamento>();
        public List<InformacoesBancarias> contaBanc = new List<InformacoesBancarias>();
        
        /// <summary>
        /// Gera uma nova senha para o usuário
        /// </summary>
        /// <param name="tamanho">Quantidade de caracteres que a nova senha deve possui.</param>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public void GerarSenha(Int16 tamanho)
        {
            string SenhaCaracteresValidos = "abcdefghijklmnopqrstuvwxyz1234567890";
            Int16 valormaximo = (Int16)SenhaCaracteresValidos.Length;

            Random random = new Random(DateTime.Now.Millisecond);
            StringBuilder novaSenha = new StringBuilder(tamanho);

            for (int indice = 0; indice < tamanho; indice++)
                novaSenha.Append(SenhaCaracteresValidos[random.Next(0, valormaximo)]);

            this.senha =  novaSenha.ToString();
        }

        public void GerarCodigoVerificacao()
        {
            string caracteresCodigo = "abcdefghijklmnopqrstuvwxyz1234567890@#!?._-$";
            Int16 valormaximo = (Int16)caracteresCodigo.Length;
            MD5 hash = new MD5();
            
            Random random = new Random(DateTime.Now.Millisecond);
            StringBuilder novoCodigo = new StringBuilder(20);

            for (int indice = 0; indice < 20; indice++)
                novoCodigo.Append(caracteresCodigo[random.Next(0, valormaximo)]);

            this.codigoConfirma = hash.criptografar(novoCodigo.ToString());
        }
    }

    //Cria um elemento enum Status pra controlar o status do usario cadastrado
    public enum Status : short
    {
        Ativado = 0,
        Desativado = 1,
        Banido = 2,
        CadNaoConfirmado = 3
    }

    //Elemento enum para controlar a natureza do usuario
    public enum Natureza : short
    { 
        fisica = 0,
        juridica = 1
    }

    public class UserIDComparer : IEqualityComparer<Usuario>
    {
        public bool Equals(Usuario x, Usuario y)
        {
            return x._id == y._id;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(Usuario x)
        {
            return x._id.GetHashCode();
        }
    }
}

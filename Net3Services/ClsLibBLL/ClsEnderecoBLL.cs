using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public class ClsEnderecoBLL
    {
        Endereco objEnd;

        #region === CRUD ===
        /// <summary>
        /// Executa a validação do endereço
        /// </summary>
        /// <param name="endereco">Objeto de endereço contendo todas as informações necessárias.</param>
        /// <returns>Retorna se o endereço é válido ou não. Caso o endereço não seja válido a operação de inserção (no método InserirUsuario deve ser cancelada)</returns>
        public bool ValidarEndereco(Endereco endereco)
        {
            if (Regex.IsMatch(endereco.pais.ToString(), @"^[:c:d]{1,24}$"))
            {
                if (Regex.IsMatch(endereco.uf.ToString(), @"^[:c:d]{1,24}$"))
                {
                    if (Regex.IsMatch(endereco.cidade.ToString(), @"^[:c:d]{1,24}$"))
                    {
                        if (Regex.IsMatch(endereco.bairro, @"^[:c]{5,30}$"))
                        {
                            if (Regex.IsMatch(endereco.logradouro, @"^[:c]{5,30}$"))
                            {
                                if (Regex.IsMatch(endereco.cep.ToString(), @"^\d{5}\-?\d{3}$"))
                                {
                                    if (Regex.IsMatch(endereco.numero.ToString(), @"^[:d]{1,5}$"))
                                    {
                                        if (Regex.IsMatch(endereco.complemento.ToString(), @"^[:c]{5,30}$"))
                                        {
                                            return true;
                                        }
                                        else { return false;}
                                    }
                                    else { return false; }
                                }
                                else { return false; }
                            }
                            else { return false; }
                        }
                        else { return false; }
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Edita o endereço no banco de dados
        /// </summary>
        /// <param name="endereco">Objeto de endereço contendo todas as informações necessárias.</param>
        /// <param name="idUsuario">Oid do usuário que vai ter o endereço editado.</param>
        public void EditarEndereco(Endereco endereco, Oid idUsuario)
        {
            if (Regex.IsMatch(endereco.id.ToString(), @"^[:d:c]{1,24}$"))
            {
                if (Regex.IsMatch(endereco.pais.ToString(), @"^[:c:d]{1,24}$"))
                {
                    if (Regex.IsMatch(endereco.uf.ToString(), @"^[:c:d]{1,24}$"))
                    {
                        if (Regex.IsMatch(endereco.cidade.ToString(), @"^[:c:d]{1,24}$"))
                        {
                            if (Regex.IsMatch(endereco.bairro, @"^[:c]{5,30}$"))
                            {
                                if (Regex.IsMatch(endereco.logradouro, @"^[:c]{5,30}$"))
                                {
                                    if (Regex.IsMatch(endereco.cep.ToString(), @"^\d{5}\-?\d{3}$"))
                                    {
                                        if (Regex.IsMatch(endereco.numero.ToString(), @"^[:d]{1,5}$"))
                                        {
                                            if (Regex.IsMatch(endereco.complemento.ToString(), @"^[:c]{5,30}$"))
                                            {
                                                ClsEnderecoDAL objEnd = new ClsEnderecoDAL();
                                                objEnd.EditarEndereco(endereco, idUsuario);

                                            }
                                            else { throw new Exception("Complemento inválido"); }
                                        }
                                        else { throw new Exception("Número inválido."); }
                                    }
                                    else { throw new Exception("CEP inválido."); }
                                }
                                else { throw new Exception("A rua deve possir entre 5 e 30 caracteres."); }
                            }
                            else { throw new Exception("O bairro deve possir entre 5 e 30 caracteres."); }
                        }
                        else { throw new Exception("Cidade Inválida."); }
                    }
                    else { throw new Exception("UF Inválido."); }
                }
                else { throw new Exception("Pais inválido."); }
            }
            else { throw new Exception("ID do endereço inválido"); }
        }

        /// <summary>
        /// Exclui o endereço informado do banco de dados
        /// </summary>
        /// <param name="idEndereco">ID do endereço</param>
        public void ExcluirEndereco(Oid idEndereco)
        {
            if (Regex.IsMatch(idEndereco.ToString(), @"^[:d:c]{1,24}$"))
            {
                // Chamar método da classe ClsEnderecoDAL
            }
            else { throw new Exception("ID do endereço inválido"); }
        }
        #endregion
        #region === Buscas ===
        /// <summary>
        /// Busca um endereço a partir do ID informado
        /// </summary>
        /// <param name="idEnderecco">ID do endereço que deve ser pesquisado</param>
        /// <returns>Retorna o endereço corespondente ao ID informado</returns>
        public Endereco BuscarEnderecoPorID(Oid idEnderecco)
        {
            if (Regex.IsMatch(idEnderecco.ToString(), @"^[:d]{1,24}$"))
            {
                objEnd = new Endereco();
                // Executar o método de busca
                return objEnd;
            }
            else { throw new Exception("ID do endereço inválido"); }
        }

        /// <summary>
        /// Busca todos os endereços que sejam do pais informado
        /// </summary>
        /// <param name="pais">ID do pais que deve ser pesquisado</param>
        /// <returns>Retorna a lista de endereços que tenham como pais o pais informado</returns>
        public List<Endereco> BuscarEnderecoPorPais(Oid pais)
        {
            if (Regex.IsMatch(pais.ToString(), @"^[:d]{1,24}$"))
            {
                List<Endereco> ltEnd = new List<Endereco>();
                // Executar o método de busca
                return ltEnd;
            }
            else { throw new Exception("ID do pais inválido"); }
        }

        /// <summary>
        /// Busca todos os endereços do estado informado
        /// </summary>
        /// <param name="uf">ID do estado que se deseja procurar</param>
        /// <returns>Retorna a lista com todos os endereços do estado informado</returns>
        public List<Endereco> BuscarEnderecoPorUf(Oid uf)
        {
            if (Regex.IsMatch(uf.ToString(), @"^[:d]{1,24}$"))
            {
                List<Endereco> ltEnd = new List<Endereco>();
                // Executar o método de busca
                return ltEnd;
            }
            else { throw new Exception("ID do estado inválido"); }
        }

        /// <summary>
        /// Busca todos os endereços do bairro informado
        /// </summary>
        /// <param name="cidade">ID da cidade que se deseja procurar</param>
        /// <returns>Lista de todos os enredeços da cidade informada</returns>
        public List<Endereco> BuscarEnderecoPorCidade(Oid cidade)
        {
            if (Regex.IsMatch(cidade.ToString(), @"^[:d]{1,24}$"))
            {
                List<Endereco> ltEnd = new List<Endereco>();
                // Executar o método de busca
                return ltEnd;
            }
            else { throw new Exception("ID da cidade inválido"); }
        }

        /// <summary>
        /// Busca todos os endereços do bairro informado
        /// </summary>
        /// <param name="bairro">Nome do bairro que se deseja procurar</param>
        /// <returns>Lista de todos os endereços do bairro informado</returns>
        public List<Endereco> BuscarEnderecoPorBairro(string bairro)
        {
            if (Regex.IsMatch(bairro, @"^[:c]{5,30}$"))
            {
                List<Endereco> ltEnd = new List<Endereco>();
                // Executar o método de busca
                return ltEnd;
            }
            else { throw new Exception("O bairro deve possir entre 5 e 30 caracteres."); }
        }

        /// <summary>
        /// Busca todos os endereços da rua informada
        /// </summary>
        /// <param name="rua">Nome da rua que se deseja procurar</param>
        /// <returns>Lista de todos os endereços da rua informada</returns>
        public List<Endereco> BuscarEnderecoPorRua(string rua)
        {
            if (Regex.IsMatch(rua, @"^[:c]{5,30}$"))
            {
                List<Endereco> ltEnd = new List<Endereco>();
                // Executar o método de busca
                return ltEnd;
            }
            else { throw new Exception("A rua deve possir entre 5 e 30 caracteres."); }
        }

        /// <summary>
        /// Busca todos os endereços que possuem o CEP informado
        /// </summary>
        /// <param name="cep">CEP que se deseja procurar</param>
        /// <returns>Lista de todos os endereços que possuam o CEP informado</returns>
        public List<Endereco> BuscarEnderecoPorCep(string cep)
        {
            if (Regex.IsMatch(cep, @"^\d{5}\-?\d{3}$"))
            {
                List<Endereco> ltEnd = new List<Endereco>();
                // Executar o método de busca
                return ltEnd;
            }
            else { throw new Exception("CEP inválido"); }
        }
        #endregion
    }
}

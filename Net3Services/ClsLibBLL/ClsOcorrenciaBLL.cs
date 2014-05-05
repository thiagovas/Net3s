using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public class ClsOcorrenciaBLL
    {
        #region === CRUD ===
        // A data e a hora da ocorrência são pegos no momento em que o valor é adicionado ao banco de dados, por isso não há necessidade de 
        // informa-los como parametro
        /// <summary>
        /// Insere uma occoência no banco de dados.
        /// </summary>
        /// <param name="descricao">Descrição da ocorrência. Ex: "O usuário 'fulano' postou conteúdo pornográfico".</param>
        /// <param name="status">Status em que a ocorrência se encontra.</param>
        /// <param name="denunciante">ID do denunciante (o usuário que fez a denuncia)</param>
        /// <param name="acusado">ID do acusado (o usuário que foi acusado de realizar uma infração)</param>
        /// <param name="resposta">Contém a resposta da denuncia ao usário.</param>
        /// <returns></returns>
        public void InserirOcorrencia(string descricao, Int16 status, Oid denunciante, Oid acusado, string resposta)
        {
            if (Regex.IsMatch(descricao.Trim(), "^[:c:d:Po\n]{15,120}$"))
            {
                if (Regex.IsMatch(status.ToString(), "^[:d]{1,1}$"))
                {
                    if (Regex.IsMatch(denunciante.ToString(), "^[:c:d]{1,24}$"))
                    {
                        if (Regex.IsMatch(acusado.ToString(), "^[:c:d]$"))
                        {
                            if (Regex.IsMatch(resposta.Trim(), "^[:c:d:Po\n]{15,120}$"))
                            {
                                Ocorrencia objOcorrencia = new Ocorrencia();
                                objOcorrencia.descricao = descricao;
                                objOcorrencia.status = status;
                                objOcorrencia.denunciante = denunciante;
                                objOcorrencia.acusado = acusado;
                                objOcorrencia.resposta = resposta;
                                objOcorrencia.dataDenuncia = DateTime.Now;

                                // Chamar método de inserção contido no ClsOcorrenciaDAL
                            }
                            else
                            { throw new Exception("Verifique se a resposta possui parâmetros inválidos."); }
                        }
                        else { throw new Exception("ID do acusado inválido."); }
                    }
                    else { throw new Exception("ID do denunciante inválido. "); }
                }
                else { throw new Exception("O status da ocorrêcia não pode ser nulo."); }
            }
            else
            { throw new Exception("Verifique se a descrição possui parâmetros inválidos."); }
        }

        // Não possui um parâmetro data pois a data da ocorrência não pode ser alterada (por motivos de segurança).
        /// <summary>
        /// Edita os valores 
        /// </summary>
        /// <param name="idOcorrencia">ID da ocorrência que deve ser editada.</param>
        /// <param name="descricao">Descrição da ocorrência. Ex: "O usuário 'fulano' postou conteúdo pornográfico".</param>
        /// <param name="status">Status em que a ocorrência se encontra. O status deve possuir um valor de 1 a 9.</param>
        /// <param name="denunciado">ID do denunciante (o usuário que fez a denuncia)</param>
        /// <param name="acusado">ID do acusado (o usuário que foi acusado de realizar uma infração)</param>
        /// <param name="resposta">Contém a resposta da denuncia ao usário</param>
        public void EditarOcorrencia(Oid idOcorrencia, string descricao, Int16 status, Oid denunciado, Oid acusado, string resposta)
        {
            if (Regex.IsMatch(idOcorrencia.ToString(), "^[:c:d]{1,24}$"))
            {
                if (Regex.IsMatch(descricao, "^[:c:d:Po\n]{15,120}$"))
                {
                    if (Regex.IsMatch(status.ToString(), "^[:d]{1,1}$") && status >= 1 && status <= 9)
                    {
                        if (Regex.IsMatch(denunciado.ToString(), "^[:c:d]{1,24}$"))
                        {
                            if (Regex.IsMatch(acusado.ToString(), "^[:c:d]$"))
                            {
                                if (Regex.IsMatch(resposta, "^[:c:d:Po\n]{15,120}$"))
                                {
                                    Ocorrencia objOcorrencia = new Ocorrencia();
                                    objOcorrencia.idOcorrencia = idOcorrencia;
                                    objOcorrencia.descricao = descricao;
                                    objOcorrencia.status = status;
                                    objOcorrencia.denunciante = denunciado;
                                    objOcorrencia.acusado = acusado;
                                    objOcorrencia.resposta = resposta;
                                   
                                    // Chamar método de edição contido no ClsOcorrenciaDAL
                                }
                                else
                                { throw new Exception("Verifique se a resposta possui parâmetros inválidos."); }
                            }
                            else { throw new Exception("ID do acusado inválido."); }
                        }
                        else { throw new Exception("ID do denunciante inválido. "); }
                    }
                    else { throw new Exception("O status da ocorrêcia não pode ser nulo."); }
                }
                else
                { throw new Exception("Verifique se a descrição possui parâmetros inválidos."); }
            }
            else { throw new Exception("ID da ocorrência inválido."); }
        }

        /// <summary>
        /// Exluir uma ocorrência do BD, de acordo com o ID informado.
        /// </summary>
        /// <param name="idOcorrencia">ID da ocorrência que deve ser excluida</param>
        /// <returns></returns>
        public void ExcluirOcorrencia(Oid idOcorrencia)
        {
            if (Regex.IsMatch(idOcorrencia.ToString(), "^[:c:d]{1,24}$"))
            {
                // Chama o método da exclusão da classe ClsOcorrenciaDAL
            }
            else{ throw new Exception(); }
        }
        #endregion
        #region === Buscas ===
        /// <summary>
        /// Busca uma ocorrência pelo valor do ID
        /// </summary>
        /// <param name="idocorrencia">ID da ocorrência</param>
        /// <returns>Retorna a ocorrência com o ID informado</returns>
        public Ocorrencia BuscarOcorrenciaPorID(Oid idocorrencia)
        {
            if (Regex.IsMatch(idocorrencia.ToString(), "^[:d:c]{1,24}$"))
            {
                Ocorrencia objOco = new Ocorrencia();
                // Chama o método de busca da classe ClsOcorrenciaDAL
                return objOco;
            }
            else { throw new Exception("ID da ocorrência não estava em um formato válido"); }
        }

        /// <summary>
        /// Busca todas as ocorrências que possuem o ID do denunciado informado
        /// </summary>
        /// <param name="denunciado">ID do denunciado pelo qual se deseja procurar</param>
        /// <returns>Lista das ocorrrências que possuem o ID do denunciado informado</returns>
        public List<Ocorrencia> BuscarOcorrenciaPorDenunciado(string denunciado)
        {
            if(Regex.IsMatch(denunciado, "^[:d:c]{1,24}$"))
            {
                List<Ocorrencia> ltOcorrencia = new List<Ocorrencia>();
                // Chamar o método da busca na classe ClsOcorrenciasDAL
                return ltOcorrencia;
            }
            else {throw new Exception("O ID do denunciado não estava em um formato válido."); }
        }

        /// <summary>
        /// Busca todas as ocorrências que possuem o ID do acusado informado
        /// </summary>
        /// <param name="acusado">ID do acusado pelo qual se deseja procurar</param>
        /// <returns>Lista das ocorrrências que possuem o ID do denunciado informado</returns>
        public List<Ocorrencia> BuscarOcorrenciaPorAcusado(string acusado)
        {
            if (Regex.IsMatch(acusado, "^[:d:c]{1,24}$"))
            {
                List<Ocorrencia> ltOcorrencia = new List<Ocorrencia>();
                // Chamar o método da busca na classe ClsOcorrenciasDAL
                return ltOcorrencia;
            }
            else { throw new Exception("O ID do acusado não estava em um formato válido."); }
        }

        /// <summary>
        /// Busca todas as ocorrências que possuem a data informada
        /// </summary>
        /// <param name="data">Data pela qual se deseja procurar</param>
        /// <returns>Lista de datas que a ocorrência que possuem a data informada</returns>
        public List<Ocorrencia> BuscarOcorrenciaPorData(DateTime data)
        {
            if(data != null)
            {
                List<Ocorrencia> ltOcorrencia = new List<Ocorrencia>();
                // Chamar método de busca da classe ClsOcorrenciasDAL 
                return ltOcorrencia;
            }
            else { throw new Exception("Deve-se informar uma data para se efetuar a busca."); }
        }

        /// <summary>
        /// Busca todas as ocorrências que possuem o status informado
        /// </summary>
        /// <param name="status">Status das ocorrências que se deseja procurar</param>
        /// <returns>Lista de ocorrências que possuem o status informado</returns>
        public List<Ocorrencia> BuscarOcorrenciaPorStatus(Int16 status)
        {
            if (Regex.IsMatch(status.ToString(), "^[:d]{1,1}$"))
            {
                List<Ocorrencia> ltOcorrencias = new List<Ocorrencia>();
                // Chamar o método de pesquisa da classe ClsOcorrenciasDAL
                return ltOcorrencias;
            }
            else { throw new Exception("O valor informado não é um status válido"); }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public class ClsOrcamentoBLL
    {
        private ClsOrcamentoDAL orcamentoDAL;
        private List<Orcamento> ltOrcamento;

        #region === CRUD ===
        /// <summary>
        /// Cria um orçamento com os dados entrados
        /// </summary>
        /// <param name="orcamento">Objeto do tipo orçamento contendo todas as informações do orçamento que deve ser inserido no banco de dados</param>
        /// <by>Marcio Mansur</by>
        public void CriarOrcamento(Orcamento orcamento)
        {
            if (clsUtilidades.ValidarOid(orcamento.prestador))
            {
                if (clsUtilidades.ValidarOid(orcamento.prestador))
                {
                    if (Regex.IsMatch(orcamento.descricao, @"^[a-zA-Z0-9 áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ/,.!?-]{1,400}$"))
                    {
                        ClsOrcamentoDAL orcDal = new ClsOrcamentoDAL();
                        OidGen oidGen = new OidGen();
                        orcamento.id = new Oid(oidGen.Generate().ToString());

                        orcDal.InserirOrcamento(orcamento);
                    }
                    else { throw new Exception("Descrição inválida!"); }
                }
                else { throw new Exception("Erro ao encontrar contratante"); }
            }
            else { throw new Exception("Erro ao encontrar prestador de serviços."); }
        }

        /// <summary>
        /// Edita o orçamento envido no BD
        /// </summary>
        /// <param name="orcamento">Objeto do tipo orçamento contendo todas as informações do orçamento que se deseja editar</param>
        public void EditarOrcamento(Orcamento orcamento)
        {
            if (clsUtilidades.ValidarOid(orcamento.id))
            {
                if (clsUtilidades.ValidarOid(orcamento.prestador))
                {
                    if (clsUtilidades.ValidarOid(orcamento.contratante))
                    {
                        if (orcamento.dataInicio != null)
                        {
                            if (orcamento.dataFim != null && orcamento.dataInicio <= orcamento.dataFim)
                            {
                                if (orcamento.preco > 0)
                                {
                                    orcamentoDAL = new ClsOrcamentoDAL();
                                    orcamentoDAL.EditarOrcamento(orcamento);
                                }
                                else { throw new Exception("O preço do serviço deve ser superior a 0"); }
                            }
                            else { throw new Exception("A previsão de entrega deve ter data superior a previsão de inicio"); }
                        }
                        else { throw new Exception("Informe a data de inicio do serviço."); }
                    }
                    else { throw new Exception("ID do contratante inválido"); }
                }
                else { throw new Exception("ID do prestador inválido"); }
            }
            else { throw new Exception("ID do orçamento inválido"); }
        }

        #endregion
        #region === Busca ===
        /// <summary>
        /// Busca o orçamento que possui o ID informado
        /// </summary>
        /// <param name="idOrcamento">ID do orçamento que se deseja buscar</param>
        /// <returns>Retorna o orçamento que possui o ID informado</returns>
        public Orcamento BuscarOrcamentoPorID(Oid idOrcamento)
        {
            if (clsUtilidades.ValidarOid(idOrcamento))
            {
                orcamentoDAL = new ClsOrcamentoDAL();
                return orcamentoDAL.BuscarOrcamentoPorId(idOrcamento);
            }
            else { throw new Exception("ID do orçamento inválido"); }
        }

        public List<Orcamento> BuscaOrcamentoNaoAprovadosPrest(Oid usu)
        {
            if (clsUtilidades.ValidarOid(usu))
            {
                orcamentoDAL = new ClsOrcamentoDAL();
                return orcamentoDAL.BuscarQuantOrcamentosNaoAprovadosPrest(usu);
            }
            else { throw new Exception("ID do usuário inválido"); }
        }

        public List<Orcamento> BuscarQuantOrcamentosNaoAprovadosContrat(Oid usu)
        {
            if (clsUtilidades.ValidarOid(usu))
            {
                orcamentoDAL = new ClsOrcamentoDAL();
                return orcamentoDAL.BuscarQuantOrcamentosNaoAprovadosContrat(usu);
            }
            else { throw new Exception("ID do usuário inválido"); }
        }

        /// <summary>
        /// Busca as atualizações referentes a um id.
        /// </summary>
        /// <param name="usu">Oid do usuario</param>
        /// <param name="orc">filtros para o orçamento</param>
        /// <returns>retorno uma lista com os orçamentos</returns>
        public List<Orcamento> BuscarOrcamentoPorUsuario(Oid usu, Orcamento orc)
        {
            if (clsUtilidades.ValidarOid(usu))
            {
                if (orc != null)
                {
                    orcamentoDAL = new ClsOrcamentoDAL();
                    ltOrcamento = orcamentoDAL.BuscarPorIdUsuario(usu, orc);
                }
                else throw new Exception("Traga os valores do orçamento para a busca");
            }
            else throw new Exception("Oid não valido, por favor digite um novo!");

            return ltOrcamento;
        }

        #endregion
    }
}

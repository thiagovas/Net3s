using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public delegate void CrudBLL(Denuncia denuncia);

    public class ClsDenunciaBLL
    {
        ClsDenunciaDAL objDenunDal = new ClsDenunciaDAL();
        Denuncia den = new Denuncia();

        #region === Crud ===
        /// <summary>
        /// Insere uma denuncia no banco de dados.
        /// </summary>
        /// <param name="descricao">Descrição da denuncia. Ex: "Foi flagrado o uso de material ilegal pelo usuario 'x'".</param>
        /// <param name="status">Status em que a denuncia se encontra. Sempre será inserida como "em aberto", para alterar após a verificação.</param>
        /// <param name="denunciado">ID do denunciante (o usuário que fez a denuncia)</param>
        /// <param name="acusado">ID do acusado (o usuário que foi acusado de realizar uma infração)</param>
        /// <param name="resposta">Contém a resposta da denuncia ao usário.</param>
        /// <param name="dataDenuncia">Data e hora em que foi feita a denuncia. Sempre com a data e a hora inicial</param>
        /// <param name="dataAtendimento">Data e hora em que foi atendida a denuncia.</param>
        public void InserirDenuncia(Denuncia denuncia)
        {
            /*DANDO PALA
            if (Regex.IsMatch(denuncia.descricao, "^[:c:d\n]{15,120}$"))
            {
                if ((short)denuncia.tipoDenuncia >= 0 && (short)denuncia.tipoDenuncia <= 6)
                {
                    if (denuncia.status != null)
                    {
                        if (Regex.IsMatch(denuncia.denunciante.ToString(), "^[:c:d]{1,24}$"))
                        {
                            if (Regex.IsMatch(denuncia.acusado.ToString(), "^[:c:d]{1,24}$"))
                            {
                                if (Regex.IsMatch(denuncia.atendente.ToString(), "^[:c:d]{1,24}$"))
                                {
                                    objDenunDal.inserir(denuncia);
                                }
                                else { throw new Exception("ID do atendente inválido."); }
                            }
                            else { throw new Exception("ID do acusado inválido."); }
                        }
                        else { throw new Exception("ID do denunciante inválido. "); }
                    }
                    else { throw new Exception("O status da ocorrêcia não pode ser nulo."); }
                }
                else { throw new Exception("Selecione o tipo de denuncia."); }
            }
            else
            { throw new Exception("Verifique se a descrição possui parâmetros inválidos."); }
            */
            if ((short)denuncia.tipoDenuncia >= 0 && (short)denuncia.tipoDenuncia <= 6)
            {
                if (denuncia.status != null)
                {
                    objDenunDal.inserir(denuncia);
                }
                else { throw new Exception("O status da ocorrêcia não pode ser nulo."); }
            }
            else { throw new Exception("Selecione o tipo de denuncia."); }
        }


        /// <summary>
        /// Deleta uma denuncia no banco de dados.
        /// </summary>
        /// <param name="idDenuncia">ID da denuncia. Ex: "Foi flagrado o uso de material ilegal pelo usuario 'x'".</param>
        /// <returns></returns>
        public void ExcluirDenuncia(Denuncia idDenuncia)
        {
            if (Regex.IsMatch(idDenuncia.ToString(), "^[:c:d]{1,24}&"))
            {
                // Chamar método de inserção contido no ClsOcorrenciaDAL
            }
            else
            {
                throw new Exception();
            }
        }


        /// <summary>
        /// Edita uma denuncia no banco de dados.Apenas os administradores editam as denuncias.
        /// </summary>
        /// <param name="iddescricao">Passa o id da denuncia para fazer a edição</param>
        /// <param name="descricao">Descrição da denuncia. Ex: "Foi flagrado o uso de material ilegal pelo usuario 'x'".</param>
        /// <param name="status">Status em que a ocorrência se encontra.</param>
        /// <param name="denunciado">ID do denunciante (o usuário que fez a denuncia)</param>
        /// <param name="acusado">ID do acusado (o usuário que foi acusado de realiorkutorkutorororororzar uma infração)</param>
        /// <param name="resposta">Contém a resposta da denuncia ao usário.</param>
        /// <param name="dataDenuncia">Data e hora em que foi feita a denuncia.</param>
        /// <param name="dataAtendimento">Data e hora em que foi atendida a denuncia.</param>
        /// <returns></returns>
        public void EditarDenuncia(Denuncia denuncia)
        {
            if (Regex.IsMatch(denuncia._id.ToString(), "[:c:d]{1,24}"))
            {
                if (Regex.IsMatch(denuncia.descricao, "[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{1,120}"))
                {
                    if (denuncia.status != null)
                    {
                        if (Regex.IsMatch(denuncia.denunciante.ToString(), "[:c:d]{1,24}"))
                        {
                            if (Regex.IsMatch(denuncia.acusado.ToString(), "[:c:d]{1,24}"))
                            {
                                if (Regex.IsMatch(denuncia.atendente.ToString(), "[:c:d]{1,24}"))
                                {
                                    if (Regex.IsMatch(denuncia.resposta, "[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{1,120}"))
                                    {
                                        if (!denuncia.punicao.Equals(""))
                                        {
                                            objDenunDal.update(denuncia);
                                        }
                                        else { throw new Exception("Digite a punição a ser feita para o usuário."); }
                                    }
                                    else { throw new Exception("Verifique se a resposta possui parâmetros inválidos."); }
                                }
                                else { throw new Exception("ID do atendente inválido."); }
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
            else
            { throw new Exception("ID da denúncia inválido."); }
        }
        #endregion

        //Instancia um objeto<T> que retorna uma lista com as denuncias
        List<Denuncia> ltDenuncia;
        #region === Buscas ===


        /// <summary>
        /// Busca uma denuncia pelo valor do ID dela.
        /// </summary>
        /// <param name="idDenuncia">ID da denuncia.</param>
        /// <returns>Uma unica denuncia com aquele ID</returns>
        public List<Denuncia> BuscarDenunciaPorID(Oid idDenuncia)
        {
            if (Regex.IsMatch(idDenuncia.ToString(), @"[a-zA-Z0-9]{1,24}"))
            {
                //obtem id da denuncia e passa ele para o objeto procurar
                Denuncia den = new Denuncia();
                den._id = idDenuncia;

                return objDenunDal.buscaDenunciasGeneric(den);
            }
            else
            { throw new Exception("ID da denuncia não encontrado."); }
        }

        /// <summary>
        /// Busca todas as denuncias realizadas. Somente aberta ao administrador
        /// </summary>
        /// <returns>Uma lista com todas as denuncias feitas</returns>
        public List<Denuncia> BuscarTodasDenuncias()
        {
            if (ltDenuncia == null)
            {
                ltDenuncia = new List<Denuncia>();
                //Chama o método que busca todas as denuncias
            }
            return ltDenuncia;
        }

        /// <summary>
        /// Busca todas as denuncias na data do atendimento
        /// </summary>
        /// <param name="dataDenuncia">Data da denuncia</param>
        /// <returns>Retorna uma lista com todas as denuncias daquela determinada data</returns>
        public List<Denuncia> BuscarDenunciaPorData(DateTime dataDenuncia)
        {
            if (dataDenuncia != null)
            {
                if (ltDenuncia == null)
                {
                    ltDenuncia = new List<Denuncia>();
                    //Chama o método de listar todas as denuncias em uma data
                }
                return ltDenuncia;
            }
            else
            { throw new Exception("Data do atendimento da denuncia não informada."); }
        }

        /// <summary>
        /// Busca todas as denuncias feitas por aquele denunciante. Modo de buscas padrão.
        /// </summary>
        /// <param name="idDenunciante">ID do usuario que fez a denuncia</param>
        /// <returns>Retorna uma lista de denuncias realizadas por aquele denunciante</returns>
        public List<Denuncia> BuscarDenunciaPorDenunciante(Oid idDenunciante)
        {
            if (Regex.IsMatch(idDenunciante.ToString(), "^[:d:c]{1,24}$"))
            {
                if (ltDenuncia == null)
                {
                    ltDenuncia = new List<Denuncia>();
                    //Chama método que busca as denuncias feitas pelo denunciante
                }
                return ltDenuncia;
            }
            else
            { throw new Exception("ID do denunciante está inválido."); }
        }

        /// <summary>
        /// Busca todas as denuncias para um acusado
        /// </summary>
        /// <param name="idAcusado">ID do usuario acusado</param>
        /// <returns>Retorna uma lista com todos os acusados</returns>
        public List<Denuncia> BuscarDenunciaPorAcusado(Oid idAcusado)
        {
            if (Regex.IsMatch(idAcusado.ToString(), "^[:d:c]{1,24}$"))
            {
                if (ltDenuncia == null)
                {
                    ltDenuncia = new List<Denuncia>();
                    //Chama método que busca as denuncias feitas pelo denunciante
                }
                return ltDenuncia;
            }
            else
            { throw new Exception("ID do acusado está inválido"); }
        }

        /// <summary>
        /// Retorna todas as informações sobre aquele atendente
        /// </summary>
        /// <param name="idAtendente">id do atendente</param>
        /// <returns>informações das denuncias dele</returns>
        public List<Denuncia> BuscarDenunciaAtendente(string idAtendente)
        {
            den = new Denuncia();

            Oid idA = new Oid(idAtendente);
            den.atendente = idA;

            den.status = false;
            ltDenuncia = objDenunDal.buscaTodosIdAtend(den);

            return ltDenuncia;
        }

        #endregion
    }
}

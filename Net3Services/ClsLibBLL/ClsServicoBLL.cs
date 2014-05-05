using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public class ClsServicoBLL
    {
        private ClsServicosDAL servicoDAL;
        private List<Servico> ltServico;

        #region === CRUD ===
        public string[] InserirServico(Servico serv, Oid idUsuario)
        {
            string[] resposta = new string[8];
            bool validade = true;
            ClsCategoriaServicoBLL categServicoBLL = new ClsCategoriaServicoBLL();

            #region === Nome ===
            if (Regex.IsMatch(serv.nome, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,40}$"))
            {
                resposta[0] = "Ok";
            }
            else
            {
                resposta[0] = "Nome do serviço inválido. O nome do serviço deve conter entre 2 e 40 caracteres alfanuméricos.";
                validade = false;
            }
            #endregion
            #region === Categoria Serviço ===
            //if (Regex.IsMatch(serv.nomeCategoriaServico, @"[a-zA-Z0-9 :Wh :Po áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,20}"))
            if(categServicoBLL.BuscarCategoriaPorOid(serv.categoriaServico) != null)
            {
                resposta[1] = "Ok";
            }
            else
            {
                resposta[1] = "Categoria do serviço inválida. Selecione uma categoria válida.";
                validade = false;
            }
            #endregion
            #region === Preço ===
            if (serv.preco > 0)
            {
                resposta[2] = "Ok";
            }
            else
            {
                resposta[2] = "Preço inválido. O preço deve ser superior a zero.";
                validade = false;
            }
            #endregion
            #region === Descrição ===
            if (Regex.IsMatch(serv.descricao, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ/,.-]{1,400}$"))
            {
                resposta[3] = "Ok";
            }
            else
            {
                resposta[3] = "Descrição inválida. A descrição deve possuir entre 1 e 400 alfanuméricos.";
                validade = false;
            }
            #endregion
            #region === Regional e nivel de regionalidade ===
            if (serv.regional)
            {
                if (serv.nivelRegionalidade.Equals("País"))
                {
                    if (!string.IsNullOrEmpty(ClsUsuLogado.Pais))
                    {
                        serv.regiao = ClsUsuLogado.Pais;
                        resposta[5] = resposta[4] = "Ok";
                    }
                    else
                    {
                        //Se a propriedade Pais da classe ClsUsuLogado for igual a null é pq no documento de usuario(no banco de dados),
                        //o campo Pais é null, entao nao podemos cadastrar um servico regional em que ele é feito somente no pais do usuario.
                        resposta[4] = "Por favor, complete o seu cadastro com um endereço para que possamos cadastrar este serviço como regional.";
                        resposta[5] = string.Empty;
                        validade = false;
                    }
                }
                else if (serv.nivelRegionalidade.Equals("Estado"))
                {
                    if (!string.IsNullOrEmpty(ClsUsuLogado.Uf))
                    {
                        serv.regiao = ClsUsuLogado.Uf;
                        resposta[5] = resposta[4] = "Ok";
                    }
                    else
                    {
                        resposta[4] = "Por favor, complete o seu cadastro com um endereço para que possamos cadastrar este serviço como regional.";
                        resposta[5] = string.Empty;
                        validade = false;
                    }
                }
                else if (serv.nivelRegionalidade.Equals("Cidade"))
                {
                    if (!string.IsNullOrEmpty(ClsUsuLogado.Cidade))
                    {
                        serv.regiao = ClsUsuLogado.Cidade;
                        resposta[5] = resposta[4] = "Ok";
                    }
                    else
                    {
                        resposta[4] = "Por favor, complete o seu cadastro com um endereço para que possamos cadastrar este serviço como regional.";
                        resposta[5] = string.Empty;
                        validade = false;
                    }
                }
                else
                {
                    resposta[5] = "Por favor, selecione o nivel de regionalidade.";
                    validade = false;
                }
            }



            //if (serv.regional == true)
            //{
            //    if (Regex.IsMatch(serv.nivelRegionalidade, @"[a-zA-Z0-9 áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,20}"))
            //    {
            //        resposta[5] = "Ok";
            //    }
            //    else
            //    {
            //        resposta[5] = "Selecione o nivel  de regionalidade.";
            //        validade = false;
            //    }
            //}
            //else { resposta[5] = "Ok"; }
            #endregion
            #region === Nota Média ===
            if (Regex.IsMatch(serv.notaMedia.ToString(), @"^[0-5]{1,1}$"))
            {
                resposta[6] = "Ok";
            }
            else
            {
                resposta[6] = "A nota deve possuir valores entre 0 e 5.";
                validade = false;
            }
            #endregion
            #region === Unidade de Medida ===
            if (Regex.IsMatch(serv.unidadeMedida, @"[a-zA-Z0-9 áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,20}"))
            {
                resposta[7] = "Ok";
            }
            else
            {
                resposta[7] = "Selecione uma unidade de medida válida.";
                validade = false;
            }
            #endregion

            if (validade)
            {
                servicoDAL = new ClsServicosDAL();
                serv.idUsuario = idUsuario;
                serv.dataInsercao = DateTime.Now;
                serv.statusServico = StatusServico.Ativo;

                servicoDAL.InserirServico(serv);
                ThreadStart tsInserirAtualizacao = new ThreadStart(delegate()
                    {
                        ClsContatoBLL contBll = new ClsContatoBLL();
                        long qtd = contBll.BuscarQuantidadeContatos(idUsuario);

                        if (qtd > 0)
                        {
                            ClsAtualizacaoBLL atualizacaoBLL = new ClsAtualizacaoBLL();
                            var contUsu = contBll.BuscarTodosContatos(idUsuario);

                            foreach (var cont in contUsu)
                            {
                                atualizacaoBLL.InserirAtualizacoes(cont.idContato, string.Format("{0} agora realiza um novo serviço.<br />{1}", cont.NomeContato, serv.nome), TipoAtualizacao.serviço);
                            }                            
                        }
                    }
                );
                Thread trdInsereAtualizacao = new Thread(tsInserirAtualizacao);
                trdInsereAtualizacao.Start();
            }

            return resposta;
        }

        public string[] EditarServico(Servico serv, Oid idUsuario)
        {
            string[] resposta = new string[8];
            bool validade = true;

            #region === Nome ===
            if (Regex.IsMatch(serv.nome, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,40}$"))
            {
                resposta[0] = "Ok";
            }
            else
            {
                resposta[0] = "Nome do serviço inválido. O nome do serviço deve conter entre 2 e 40 caracteres alfanuméricos.";
                validade = false;
            }
            #endregion
            #region === Categoria Serviço ===
            if (Regex.IsMatch(serv.nomeCategoriaServico, @"[a-zA-Z0-9 :Wh :Po áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,20}"))
            {
                resposta[1] = "Ok";
            }
            else
            {
                resposta[1] = "Categoria do serviço inválida. Selecione uma categoria válida.";
                validade = false;
            }
            #endregion
            #region === Preço ===
            if (serv.preco > 0)
            {
                resposta[2] = "Ok";
            }
            else
            {
                resposta[2] = "Preço inválido. O preço deve ser superior a zero.";
                validade = false;
            }
            #endregion
            #region === Descrição ===
            if (Regex.IsMatch(serv.descricao, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{1,400}$"))
            {
                resposta[3] = "Ok";
            }
            else
            {
                resposta[3] = "Descrição inválida. A descrição deve possuir entre 1 e 400 alfanuméricos.";
                validade = false;
            }
            #endregion
            #region === Regional e nivel de regionalidade ===
            if (serv.regional)
            {
                if (serv.nivelRegionalidade.Equals("País"))
                {
                    if (!string.IsNullOrEmpty(ClsUsuLogado.Pais))
                    {
                        serv.regiao = ClsUsuLogado.Pais;
                        resposta[5] = resposta[4] = "Ok";
                    }
                    else
                    {
                        //Se a propriedade Pais da classe ClsUsuLogado for igual a null é pq no documento de usuario(no banco de dados),
                        //o campo Pais é null, entao nao podemos cadastrar um servico regional em que ele é feito somente no pais do usuario.
                        resposta[4] = "Por favor, complete o seu cadastro com um endereço para que possamos cadastrar este serviço como regional.";
                        resposta[5] = string.Empty;
                        validade = false;
                    }
                }
                else if (serv.nivelRegionalidade.Equals("Estado"))
                {
                    if (!string.IsNullOrEmpty(ClsUsuLogado.Uf))
                    {
                        serv.regiao = ClsUsuLogado.Uf;
                        resposta[5] = resposta[4] = "Ok";
                    }
                    else
                    {
                        resposta[4] = "Por favor, complete o seu cadastro com um endereço para que possamos cadastrar este serviço como regional.";
                        resposta[5] = string.Empty;
                        validade = false;
                    }
                }
                else if (serv.nivelRegionalidade.Equals("Cidade"))
                {
                    if (!string.IsNullOrEmpty(ClsUsuLogado.Cidade))
                    {
                        serv.regiao = ClsUsuLogado.Cidade;
                        resposta[5] = resposta[4] = "Ok";
                    }
                    else
                    {
                        resposta[4] = "Por favor, complete o seu cadastro com um endereço para que possamos cadastrar este serviço como regional.";
                        resposta[5] = string.Empty;
                        validade = false;
                    }
                }
                else
                {
                    resposta[5] = "Por favor, selecione o nivel de regionalidade.";
                    validade = false;
                }
            }



            //if (serv.regional == true)
            //{
            //    if (Regex.IsMatch(serv.nivelRegionalidade, @"[a-zA-Z0-9 áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,20}"))
            //    {
            //        resposta[5] = "Ok";
            //    }
            //    else
            //    {
            //        resposta[5] = "Selecione o nivel  de regionalidade.";
            //        validade = false;
            //    }
            //}
            //else { resposta[5] = "Ok"; }
            #endregion
            #region === Nota Média ===
            if (Regex.IsMatch(serv.notaMedia.ToString(), @"^[0-5]{1,1}$"))
            {
                resposta[6] = "Ok";
            }
            else
            {
                resposta[6] = "A nota deve possuir valores entre 0 e 5.";
                validade = false;
            }
            #endregion
            #region === Unidade de Medida ===
            if (Regex.IsMatch(serv.unidadeMedida, @"[a-zA-Z0-9 áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,20}"))
            {
                resposta[7] = "Ok";
            }
            else
            {
                resposta[7] = "Selecione uma unidade de medida válida.";
                validade = false;
            }
            #endregion

            if (validade)
            {
                servicoDAL = new ClsServicosDAL();
                serv.idUsuario = idUsuario;
                servicoDAL.EditarServico(serv);
            }

            return resposta;
        }

        /// <summary>
        /// Edita vários serviços. Obs.: Cada objeto deste IEnumerable tem que conter o seu _id.
        /// </summary>
        /// <param name="ieServicos">Serviços a serem editados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void EditarServicos(IEnumerable<Servico> ieServicos)
        {
            ClsServicosDAL servicoDAL = new ClsServicosDAL();
            servicoDAL.EditarServicos(ieServicos);
        }

        /// <summary>
        /// Desativa o serviço do usuário.
        /// </summary>
        /// <param name="idServico">Oid do serviço a ser desativado.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void DesativarServico(Oid idServico)
        {
            if (clsUtilidades.ValidarOid(idServico))
            {
                ClsServicosDAL servicoDAL = new ClsServicosDAL();
                servicoDAL.DesativarServico(idServico);
            }
            else
            {
                throw new Exception("Oid inválido, por favor, recarregue a página e tente novamente.");
            }
        }
        #endregion

        /// <summary>
        /// Este método busca um serviço com o nome informado.
        /// </summary>
        /// <param name="nome">Nome do serviço usado para fazer a busca.</param>
        /// <param name="RetirarServUsuLogado">Valor booleano que indica se é para retirar os servicos do usuario logado da busca feita do banco de dados.</param>
        /// <param name="oidUsuarioLogado">Oid do usuário logado, só será necessário se o segundo parâmetro for true.</param>
        /// <returns>Retorna uma lista do tipo Servico com o resultado da busca.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Servico> BuscarServicoPorNome(string nome, bool RetirarServUsuLogado, MongoDB.Oid oidUsuarioLogado)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                servicoDAL = new ClsServicosDAL();
                List<Servico> lstServico = servicoDAL.BuscarServicoPorNome(nome);
                if (RetirarServUsuLogado)
                {
                    RetirarServicosUsuLogado(ref lstServico, oidUsuarioLogado); //Retiro os serviços do usuario logado.
                }
                RetirarServicosRegional(ref lstServico); //Retiro os serviços que são regionais e que a sua região não é a mesma do usuario logado.
                return lstServico;
            }
            else
            {
                throw new Exception("Informe o filtro da busca.");
            }
        }

        /// <summary>
        /// Este método busca um serviço com a descricao informada.
        /// </summary>
        /// <param name="descricao">Descrição do serviço usada como filtro para fazer a busca.</param>
        /// <param name="RetirarServUsuLogado">Valor booleano que indica se é para retirar os servicos do usuario logado da busca feita do banco de dados.</param>
        /// <param name="oidUsuarioLogado">Oid do usuário logado, só será necessário se o segundo parâmetro for true.</param>
        /// <returns>Retorna lista do tipo Servico com o resultado da busca.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Servico> BuscarServicoPorDescricao(string descricao, bool RetirarServUsuLogado, MongoDB.Oid oidUsuarioLogado)
        {
            if (!string.IsNullOrEmpty(descricao.Trim()))
            {
                servicoDAL = new ClsServicosDAL();
                List<Servico> lstServico = servicoDAL.BuscarServicoPorDescricao(descricao);
                if (RetirarServUsuLogado)
                {
                    RetirarServicosUsuLogado(ref lstServico, oidUsuarioLogado);
                }
                RetirarServicosRegional(ref lstServico);
                return lstServico;
            }
            else
            {
                throw new Exception("Informe o filtro da busca.");
            }
        }

        /// <summary>
        /// Busca todos os serviços prestados referentes ao usuário informado
        /// </summary>
        /// <param name="idUsuario">Oid do usuário cujos serviços devem ser pesquisados.</param>
        /// <returns>Lista contendo todos os serviços prestados do usuário informado.</returns>
        public List<Servico> BuscarTodos(MongoDB.Oid idUsuario)
        {
            ltServico = new List<Servico>();
            servicoDAL = new ClsServicosDAL();
            ltServico = servicoDAL.buscarTodosServicos(idUsuario);

            return ltServico;
        }

        /// <summary>
        /// Busca um serviço a partir de seu ID
        /// </summary>
        /// <param name="_id">ID do serviço que deve ser encontrado</param>
        /// <returns>Retorna o serviço que possui o ID informado</returns>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public Servico buscarServicoPorId(MongoDB.Oid _id)
        {
            servicoDAL = new ClsServicosDAL();
            Servico serv = servicoDAL.buscarServicoPorId(_id);
            return serv;
        }

        /// <summary>
        /// Busca o icone da categoria informada.
        /// </summary>
        /// <param name="categoria">Nome da categoria que se deseja obter o icone.</param>
        /// <returns>Caminho do icone corespondente a categoria do serviço informada.</returns>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public static string BuscarImagemCategoria(string categoria)
        {
            switch (categoria)
            {
                case "Advocacia":
                    return "../Imagens/CategoriasServico/Advocacia.png";

                case "Artesanatos e Hobbies":
                    return "../Imagens/CategoriasServico/ArteHobies.png";

                case "Autmóveis e Veículos":
                    return "../Imagens/CategoriasServico/AutomoveisVeiculos.png";

                case "Beleza e Estetica":
                    return "../Imagens/CategoriasServico/BelezaEstetica.png";

                case "Casa e Decoração":
                    return "../Imagens/CategoriasServico/CasaDecoracao.png";

                case "Construção Civil":
                    return "../Imagens/CategoriasServico/ConstrucaoCivil.png";

                case "Consultria":
                    return "../Imagens/CategoriasServico/Consultoria.png";

                case "Cultura e Arte":
                    return "../Imagens/CategoriasServico/CulturaArte.png";

                case "Educação":
                    return "../Imagens/CategoriasServico/Educacao.png";

                case "Esporte":
                    return "../Imagens/CategoriasServico/Esportes.png";

                case "Festas e Eventos":
                    return "../Imagens/CategoriasServico/FestasEventos.png";

                case "Fotografia":
                    return "../Imagens/CategoriasServico/Fotografia.png";

                case "Gastronomia":
                    return "../Imagens/CategoriasServico/Gastronomia.png";

                case "Informática e Tecnologia":
                    return "../Imagens/CategoriasServico/InformaticaTecnologia.png";

                case "Jardinagem":
                    return "../Imagens/CategoriasServico/Jardinagem.png";

                case "Jogos e Enrtetenimento":
                    return "../Imagens/CategoriasServico/JogosEntretenimento.png";

                case "Manutenção Doméstica":
                    return "../Imagens/CategoriasServico/ManutencaoDomestica.png";

                case "Marketing e Comunicação":
                    return "../Imagens/CategoriasServico/MarketingComunicacao.png";

                case "Medicina Alternativa":
                    return "../Imagens/CategoriasServico/MedicinaAlternativa.png";

                case "Moda, Roupas e Acessórios":
                    return "../Imagens/CategoriasServico/ModaRoupasAcessorios.png";

                case "Música":
                    return "../Imagens/CategoriasServico/Musica.png";

                case "Saúde":
                    return "../Imagens/CategoriasServico/Saude.png";

                case "Segurança":
                    return "../Imagens/CategoriasServico/Seguranca.png";

                case "Serviços Gerais":
                    return "../Imagens/CategoriasServico/ServicosGerais.png";

                case "Transportes":
                    return "../Imagens/CategoriasServico/Transporte.png";

                case "Turismo e Lazer":
                    return "../Imagens/CategoriasServico/TurismoLazer.png";

                case "Veterinária":
                    return "../Imagens/CategoriasServico/Veterinaria.png";

                default:
                    return string.Empty;
                //throw new Exception("Categoria inválida.");

            }
        }

        /// <summary>
        /// Este método retira todos os serviços que pertence ao usuário logado no sistema.
        /// </summary>
        /// <param name="lstServ">Lista do tipo Servico que contém os dados a serem verificados e, se necessário, retirados.</param>
        /// <param name="idUsuarioLogado">Oid do usuário logado.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void RetirarServicosUsuLogado(ref List<Servico> lstServ, MongoDB.Oid idUsuarioLogado)
        {
            Predicate<Servico> prdServ = new Predicate<Servico>(delegate(Servico serv)
            {
                return serv.idUsuario == idUsuarioLogado;
            }
           );

            lstServ.RemoveAll(prdServ);
        }

        /// <summary>
        /// Este método retira todos os serviços que são regionais e que nao pertencem à regiao do usuario logado.
        /// </summary>
        /// <param name="lstServ">Lista do tipo Servico que contém os dados a serem verificados e, se necessário, retirados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void RetirarServicosRegional(ref List<Servico> lstServ)
        {
            Predicate<Servico> prdServ = new Predicate<Servico>(delegate(Servico serv)
            {
                if (serv.regional)
                {
                    if (serv.nivelRegionalidade.Equals("País"))
                    {
                        return serv.regiao != ClsUsuLogado.Pais;
                    }
                    else if (serv.nivelRegionalidade.Equals("Estado"))
                    {
                        return serv.regiao != ClsUsuLogado.Uf;
                    }
                    else if (serv.nivelRegionalidade.Equals("Cidade"))
                    {
                        return serv.regiao != ClsUsuLogado.Cidade;
                    }
                    else
                    {
                        //TODO: Melhorar isso depois, pq pode ser que venha do banco de dados um valor como: "Uf".
                        //E se vier um valor desse, o método vai retornar false e o registro nao vai ser verificado e vai ser deixado na lista.
                        return false;
                    }
                }
                return false;
            }
           );

            lstServ.RemoveAll(prdServ);
        }

        /// <summary>
        /// Busca serviços por categoria.
        /// </summary>
        /// <param name="categoria">Categoria usada como filtro de busca.</param>
        /// <returns>Retorna uma lista de objetos do tipo Servico.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Servico> BuscarServicosPorCategoria(string categoria)
        {
            if (!string.IsNullOrEmpty(categoria))
            {
                ClsServicosDAL servicoDAL = new ClsServicosDAL();
                return servicoDAL.BuscarServicosPorCategoria(categoria);
            }
            else
                return new List<Servico>();
        }

        /// <summary>
        /// Busca os ultimos serviços inseridos no banco de dados.
        /// </summary>
        /// <param name="numServicos">Número de serviços que deseja que serão retornados.</param>
        /// <returns>Retorna uma lista com os ultimos serviços adicionados.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Servico> BuscarUltimosServicosInseridos(int numServicos)
        {
            ClsServicosDAL servicoDAL = new ClsServicosDAL();
            return servicoDAL.BuscarUltimosServicosInseridos(numServicos);
        }

        /// <summary>
        /// Conta quantos serviços um usuário presta. Obs.: Este método conta todos os serviços, ativos e desativos.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <returns>Retorna a quantidade de serviços que um usuário presta.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public long ContarQuantServicos(Oid idUsuario)
        {
            if (clsUtilidades.ValidarOid(idUsuario))
            {
                ClsServicosDAL servicoDAL = new ClsServicosDAL();
                return servicoDAL.ContarQuantServicos(idUsuario);
            }
            else
            {
                throw new OidException("Oid inválido, por favor, recarregue a página e tente novamente.");
            }
        }

        /// <summary>
        /// Conta quantos serviços um usuário presta. Obs.: Este método conta so os serviços ativos.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <returns>Retorna a quantidade de serviços ativos de um usuário.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public long ContarQuantServicosAtivos(Oid idUsuario)
        {
            if (clsUtilidades.ValidarOid(idUsuario))
            {
                ClsServicosDAL servicoDAL = new ClsServicosDAL();
                return servicoDAL.ContarQuantServicosAtivos(idUsuario);
            }
            else
            {
                throw new OidException("Oid inválido, por favor, recarregue a página e tente novamente.");
            }
        }
    }
}
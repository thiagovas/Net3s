namespace ClsLibDAL
{
    //Nome dos componentes do banco de dados.
    /// <summary>
    /// Esta classe tem variaveis contendo os nomes das collections e campos do banco de dados, afim de evitar erros no CRUD(VEIA)
    /// </summary>
    /// <by>Thiago Vieira - t.vas@hotmail.com</by>
    public class NomeCompBd
    {   
        /// <summary>
        /// Nome da collection de usuários no banco de dados.
        /// </summary>
        public const string collecUsuarios = "Usuarios";
        #region === Collection usuarios ===
        /// <summary>
        /// Nome do campo _id na collection de usuarios
        /// </summary>
        public const string usuario_id = "_id";
        /// <summary>
        /// Nome do campo nome na collection de usuarios
        /// </summary>
        public const string usuarioNome = "nome";
        /// <summary>
        /// Nome do campo cpf_cnpj na collection de usuarios
        /// </summary>
        public const string usuarioCpf_cnpj = "cpf_cnpj";
        /// <summary>
        /// Nome do campo natureza na collection de usuarios
        /// </summary>
        public const string usuarioNatureza = "natureza";
        /// <summary>
        /// Nome do campo que guarda o nome fantasia do usuário, caso ele seja pessoa jurídica.
        /// </summary>
        public const string nomeFantasia = "nomeFantasia";
        /// <summary>
        /// Nome do campo rg na collection de usuarios
        /// </summary>
        public const string usuarioRg = "rg";
        /// <summary>
        /// Nome do campo telefone1 na collection de usuarios
        /// </summary>
        public const string usuarioTel1 = "telefone1";
        /// <summary>
        /// Nome do campo telefone 2 na collection de usuarios
        /// </summary>
        public const string usuarioTel2 = "telefone2";
        /// <summary>
        /// Nome do campo celular1 na collection de usuarios
        /// </summary>
        public const string usuarioCel1 = "celular1";
        /// <summary>
        /// Nome do campo celular2 na collection de usuarios
        /// </summary>
        public const string usuarioCel2 = "celular2";
        /// <summary>
        /// Nome do campo email na collection de usuarios
        /// </summary>
        public const string usuarioEmail = "email";
        /// <summary>
        /// Nome do campo site na collection de usuarios
        /// </summary>
        public const string usuarioSite = "site";
        /// <summary>
        /// Nome do campo dataNasc na collection de usuarios
        /// </summary>
        public const string usuarioDataNasc = "dataNasc";
        /// <summary>
        /// Nome do campo dataCadastro na collection de usuarios
        /// </summary>
        public const string usuarioDataCadastro = "dataCadastro";
        /// <summary>
        /// Nome do campo localImagem na collection de usuarios
        /// </summary>
        public const string usuarioLocalImagem = "localImagem";
        /// <summary>
        /// Nome do campo login na collection de usuarios
        /// </summary>
        public const string usuarioLogin = "login";
        /// <summary>
        /// Nome do campo senha na collection de usuarios
        /// </summary>
        public const string usuarioSenha = "senha";
        /// <summary>
        /// Nome do campo status na collection de usuarios.
        /// </summary>
        public const string usuarioStatus = "status";
        /// <summary>
        /// Nome do campo codigoConfirma na collection de usuarios, codigoConfirma é o código de confirmação enviado ao usuário para ele confirmar o cadastro no sistema.
        /// </summary>
        public const string usuarioCodConfirma = "codigoConfirma";
        /// <summary>
        /// Nome do campo que guarda a nota média das contratações.
        /// </summary>
        public const string usuarioNotaMediaContratacoes = "notaMediaContratacoes";
        /// <summary>
        /// Nome do campo que guarda a nota média das prestações.
        /// </summary>
        public const string usuarioNotaMediaPrestacoes = "notaMediaPrestacoes";

        #region === Curriculum ===
        public const string usuCurriculum = "curriculum";
        public const string usuCurriculumArrayCursos = "cursosCurriculum";
        public const string usuCurriculumArrayIdiomas = "idiomasCurriculum";
        public const string usuCurriculumArrayExperiencia = "experienciaCurriculum";
        public const string usuCurriculumArrayCertificacao = "certificacaoCurriculum";
        public const string usuCurriculumArrayPremios = "premiosCurriculum";
        #region === Cursos ===
        public const string usuCurriculumCursosNome = "nomeCursoCurriculum";
        public const string usuCurriculumCursosNomeInstituicao = "nomeInstituicaoCursoCurriculum";
        public const string usuCurriculumCursosDataInicio = "dataInicioCursoCurriculum";
        public const string usuCurriculumCursosDataFim = "dataFimCursoCurriculum";
        #endregion
        #region === Idiomas ===
        public const string usuCurriculumIdiomasNome = "nomeIdiomaCurriculum";
        public const string usuCurriculumIdiomasFluencia = "fluenciaIdiomaCurriculum";
        #endregion
        #region === Experiencias ===
        public const string usuCurriculumExperienciasNomeLocal = "nomeLocalExperienciasCurriculum";
        public const string usuCurriculumExperienciasDataInicio = "dataInicioExperienciasCurriculum";
        public const string usuCurriculumExperienciasDataFim = "dataFimExperienciasCurriculum";
        public const string usuCurriculumExperienciasDescAtividades = "descAtivExperienciasCurriculum";
        /// <summary>
        /// Flag que guardará se a experiência do usuário ainda está em andamento.
        /// </summary>
        public const string usuCurriculumExperienciasAtual = "experienciaAtualCurriculum";
        #endregion
        #region === Certificações ===
        public const string usuCurriculumCertificacoesNome = "nomeCertificacoesCurriculum";
        public const string usuCurriculumCertificacoesDescricao = "descricaoCertificacoesCurriculum";
        public const string usuCurriculumCertificacoesData = "dataCertificacoesCurriculum";
        public const string usuCurriculumCertificacoesInstituicao = "InstituicaoCertificacoesCurriculum";
        #endregion
        #region === Premios ===
        public const string usuCurriculumPremiosNome = "nomePremiosCurriculum";
        public const string usuCurriculumPremiosInstituicao = "instituicaoPremiosCurriculum";
        public const string usuCurriculumPremiosData = "dataPremiosCurriculum";
        public const string usuCurriculumPremiosDescricao = "descricaoPremiosCurriculum";
        #endregion
        #endregion
        #region === Arrays ===

        /// <summary>
        /// Nome do array registros da collection usuarios.
        /// </summary>
        public const string usuArrayRegistro = "registros";
        /// <summary>
        /// Nome do array historicoServicos da collection usuarios.
        /// </summary>
        public const string usuArrayHistoricoServicos = "historicoServicos";
        /// <summary>
        /// Nome do array ocorrencias da collection usuarios.
        /// </summary>
        public const string usuArrayOcorrencias = "ocorrencias";
        /// <summary>
        /// Nome do array enderecos da collection usuarios.
        /// </summary>
        public const string usuArrayEnderecos = "enderecos";
        /// <summary>
        /// Nome do array notificacoes da colllection usuarios.
        /// </summary>
        public const string usuArrayNotificacao = "notificacoes";
        /// <summary>
        /// Nome do array network da collection usuarios.
        /// </summary>
        public const string usuArrayNetwork = "network";
        /// <summary>
        /// Nome do array de Orçamento dentro da collection de usuarios.
        /// </summary>
        public const string usuArrayOrcamento = "orcamento";
        /// <summary>
        /// Nome do array de contas bancárias da collection de usuários.
        /// </summary>
        public const string usuArrayContasBancarias = "contasBancarias";

        #region === registro ===
        /// <summary>
        /// Nome do campo nomechave no array Registro na collection usuarios.
        /// </summary>
        public const string usuRegistroNomeChave = "nomeChave";
        /// <summary>
        /// Nome do campo valorChave no array Registro na collection usuarios.
        /// </summary>
        public const string usuRegistroValorChave = "valorChave";
        #endregion
        #region === historico de serviços ===
        public const string usuHistServId = "usuHistServId";
        /// <summary>
        /// Campo que guarda o id do orçamento relativo ao serviço finalizado.
        /// </summary>
        public const string usuHistServIdOrcam = "usuHistServIdOrcam";
        /// <summary>
        /// Nome do campo que guardará se o serviço foi contratado ou prestado.
        /// </summary>
        public const string usuHistServTipoServico = "usuHistServTipoServico";

        #region === Avaliação feita pelo prestador ===
        /// <summary>
        /// Nome do campo que guarda a avaliação feita pelo prestador no quesito pagamento.
        /// </summary>
        public const string usuHistServAvaliaPagamento = "usuHistServAvaliaPagamento";
        #endregion

        #region === Avaliação feita pelo contratante ===
        /// <summary>
        /// Nome do campo que guarda a avaliação dada pelo contratante no quesito preço.
        /// </summary>
        public const string usuHistServAvaliaPreco = "usuHistServAvaliaPreco";
        /// <summary>
        /// Nome do campo que guarda a avaliação dada pelo contratante no quesito tempo de execução do serviço.
        /// </summary>
        public const string usuHistServAvaliaTempo = "usuHistServAvaliaTempo";
        /// <summary>
        /// Nome do campo que guarda a avaliação dada pelo contratante no quesito qualidade do serviço.
        /// </summary>
        public const string usuHistServavaliaQualidadeServ = "usuHistServavaliaQualidadeServ";
        #endregion
        #endregion
        #region === ocorrencias ===
        /// <summary>
        /// Nome do campo idOcorrencias do array ocorrencias da collection usuarios.
        /// </summary>
        public const string usuOcorrencia_id = "idOcorrencia";
        /// <summary>
        /// Nome do campo descricaoOcorrencia do array ocorrencias da collection usuarios.
        /// </summary>
        public const string usuOcorrenciaDescricao = "descricaoOcorrencia";
        /// <summary>
        /// Nome do campo statusOcorrencia do array ocorrencias da collection usuarios.
        /// </summary>
        public const string usuOcorrenciaStatus = "statusOcorrencia";
        /// <summary>
        /// Nome do campo atendenteOcorrencia do array ocorrencias da collection usuarios.
        /// </summary>
        public const string usuOcorrenciaAtendente = "atendenteOcorrencia";
        /// <summary>
        /// Nome do campo denuncianteOcorrencia do array ocorrencias da collection usuarios.
        /// </summary>
        public const string usuOcorrenciaDenunciante = "denuncianteOcorrencia";
        /// <summary>
        /// Nome do campo respostaOcorrencia do array ocorrencias da collection usuarios.
        /// </summary>
        public const string usuOcorrenciaResposta = "respostaOcorrencia";
        /// <summary>
        /// Nome do campo dataDenuncia do array ocorrencias da collection usuarios.
        /// </summary>
        public const string usuOcorrenciaDataDenuncia = "dataDenuncia";
        /// <summary>
        /// Nome do campo dataResposta do array ocorrencias da collection usuarios.
        /// </summary>
        public const string usuOcorrenciaDataResposta = "dataResposta";
        /// <summary>
        /// Nome do campo tempoBanido do array ocorrencias da collection usuarios.
        /// </summary>
        public const string usuOcorrenciaTempoBanido = "tempoBanido";
        #endregion
        #region === endereco ===
        public const string usuEnderecos_id = "idEnderecos";
        public const string usuEnderecosPais = "pais";
        public const string usuEnderecosUf = "uf";
        public const string usuEnderecosCidade = "cidade";
        public const string usuEnderecosBairro = "bairro";
        public const string usuEnderecosLogradouro = "logradouro";
        public const string usuEnderecosCep = "cep";
        public const string usuEnderecosComplemento = "complemento";
        public const string usuEnderecosNumEndereco = "numeroEndereco";
        #endregion
        #region === Notificacoes ===
        public const string usuNotif_id = "idNotificacao";
        public const string usuNotifIdRemetente = "idRemetente";
        public const string usuNotifIdDestinatario = "idDestinatario";
        public const string usuNotifAssunto = "assuntoNotificacao";
        public const string usuNotifDescricao = "descricaoNotificacao";
        public const string usuNotifStatus = "statusNotif";
        public const string usuNotifTipo = "tipoNotificacao";
        public const string usuNotifPrioridade = "prioridadeNotificacao";
        public const string usuNotifData = "dataNotificacao";
        public const string usuNotifIdServico = "idServicoNotificacao";
        public const string usuNotifQuantContratada = "qtdeContratadaNotificacao";
        #endregion
        #region === Network ===
        /// <summary>
        /// Nome do campo idContato do array Network da collection usuários, que representa o Oid do contato deste usuário.
        /// </summary>
        public const string usuNetworkOidContato = "idContato";
        /// <summary>
        /// Nome do campo nomeContato que guarda o nome do contato do usuário.
        /// </summary>
        public const string usuNetworkNomeContato = "nomeContato";
        /// <summary>
        /// Nome do campo emailContato que guarda o email do contato do usuário.
        /// </summary>
        public const string usuNetworkEmailContato = "emailContato";
        /// <summary>
        /// Nome do campo dataPedidoNetwork que guarda a data que o pedido para adicionar contato ao network foi feito.
        /// </summary>
        public const string usuNetworkDatainsercao = "dataInsercao";
        #endregion
        #region === Orçamentos ===
        /// <summary>
        /// Id de determinado orçamento
        /// </summary>
        public const string usuOrcamId = "idOrcam";
        /// <summary>
        /// Prestador que vai fazer o orçamento
        /// </summary>
        public const string usuOrcamPrestador = "prestador";
        /// <summary>
        /// Contratante é o usuario que solicita o orçamento
        /// </summary>
        public const string usuOrcamContratante = "contratante";
        /// <summary>
        /// Serviço com o qual o contratante deseja
        /// </summary>
        public const string usuOrcamIdServico = "servico";
        /// <summary>
        /// Data em que foi efetuado o pedido de orçamento
        /// </summary>
        public const string usuOrcamDataInicio = "dataInicio";
        /// <summary>
        /// Data em que foi finalizado pelo contratante com a reposta para o pedido(aprovado)
        /// </summary>
        public const string usuOrcamDataFim = "dataFim";
        /// <summary>
        /// Valor do serviço que será possivelmente contratado
        /// </summary>
        public const string usuOrcamPreco = "preco";
        /// <summary>
        /// Espaço onde o contratante poderá explicar um pouco melhor para o prestador o que ele deseja realmente
        /// </summary>
        public const string usuOrcamDescricao = "descricao";
        /// <summary>
        /// Status ficou mais pratico de se trabalhar, e substituiu dois campos aqui
        /// </summary>
        public const string usuOrcamStatus = "status";
        #endregion
        #region === Contas Bancárias ===
        /// <summary>
        /// Id da conta bancária.
        /// </summary>
        public const string usuContaBancId = "idContaBanc";
        /// <summary>
        /// Campo que guarda qual banco a conta pertence.
        /// </summary>
        public const string usuContaBancBanco = "bancoContaBanc";
        /// <summary>
        /// Campo que guarda o número da agência, sem o dígito dela.
        /// </summary>
        public const string usuContaBancAgencia = "agenciaContaBanc";
        /// <summary>
        /// Campo que guarda o dígito da agência.
        /// </summary>
        public const string usuContaBancDigitoAgencia = "digitoAgenciaContaBanc";
        /// <summary>
        /// Campo que guarda o número da conta, sem o seu dígito.
        /// </summary>
        public const string usuContaBancConta = "contaBanc";
        /// <summary>
        /// Campo que guarda o dígito da conta.
        /// </summary>
        public const string usuContaBancDigitoConta = "digitoContaBanc";
        /// <summary>
        /// Variável necessária para gerar um boleto bancário.
        /// O código do cedente é o código do prestador que fica no banco.
        /// </summary>
        public const string usuContaBancCodigoCedente = "codigoCedente";
        #endregion
        #endregion
        #endregion

        /// <summary>
        /// Nome da collection de administradores do banco de dados.
        /// </summary>
        public const string collecAdministrador = "Administradores";
        #region === Collection administrador ===
        public const string adminId = "_id";
        public const string adminNome = "nomeAdmin";
        public const string adminPais = "paisAdmin";
        public const string adminUf = "ufAdmin";
        public const string adminCidade = "cidadeAdmin";
        public const string adminLogin = "loginAdmin";
        public const string adminSenha = "senhaAdmin";
        public const string adminDataCadastro = "dataCadastroAdmin";
        public const string adminSituacao = "situacaoAdmin";
        #endregion

        /// <summary>
        /// Nome da collection de denuncias no banco de dados.
        /// </summary>
        public const string collecDenuncias = "Denuncias";
        #region === Collection denuncias ===
        #endregion

        /// <summary>
        /// Nome da collection de mensagens no banco de dados.
        /// </summary>
        public const string collecMensagens = "Mensagens";
        #region === Collection Mensagens ===
        #endregion

        /// <summary>
        /// Nome da collection de serviços no banco de dados.
        /// </summary>
        public const string collecServicos = "Servicos";
        #region === Collection serviços ===
        /// <summary>
        /// Campo do Oid da collection de serviços do banco de dados.
        /// </summary>
        public const string servico_id = "_id";
        /// <summary>
        /// Nome do campo que guarda o Oid do usuário a quem o serviço pertence.
        /// </summary>
        public const string servicoIdUsuario = "idUsuario";
        /// <summary>
        /// Nome do campo nome da collection de serviços do banco de dados.
        /// </summary>
        public const string servicoNome = "nomeServico";
        /// <summary>
        /// Nome do campo preco da collection de serviços do banco de dados.
        /// </summary>
        public const string servicoPreco = "precoServico";
        /// <summary>
        /// Nome do campo categoriaServico da collection de serviços do banco de dados.
        /// </summary>
        public const string servicoIdCategServ = "categoriaServico";
        /// <summary>
        /// Nome do campo regional da collection de serviços do banco de dados.
        /// </summary>
        public const string servicoRegional = "regional";
        /// <summary>
        /// Campo usado somente se o campo regional for true, e ele guardará o nome da regiao que o serviço será prestado.
        /// </summary>
        /// <example>Tocantins, Camaçari, Costa Rica</example>
        public const string servicoRegiao = "regiao";
        /// <summary>
        /// Nome do campo notaMedia da collection de serviços do banco de dados.
        /// </summary>
        public const string servicoNotaMedia = "notaMedia";
        /// <summary>
        /// Nome do campo descricao da collection de serviços do banco de dados.
        /// </summary>
        public const string servicoDesc = "descricaoServico";
        /// <summary>
        /// Nome do campo nivelRegionalidade da collection serviços do banco de dados.
        /// </summary>
        public const string servicoNivelRegionalidade = "nivelRegionalidade";
        /// <summary>
        /// Nome do campo unidadeMedida da collection serviços do banco de dados.
        /// </summary>
        public const string servicoUnidadeMedida = "unidadeMedida";
        /// <summary>
        /// Nome do campo que guardará a data de inserção deste serviço no banco de dados.
        /// </summary>
        public const string servicoDataInsercao = "dataInsercao";
        /// <summary>
        /// Status do usuário dono do serviço.
        /// </summary>
        public const string servicoStatusServico = "statusServico";
        #endregion

        /// <summary>
        /// Nome da collection que é um catalogo de enderecos, onde iremos guardar paises, estados, cidades e bairros.
        /// </summary>
        public const string collecCatalogoEnderecos = "CatalogoEnderecos";
        #region === Collection Catalogo de endereços ===
        public const string catEnderecosIdPais = "idPaisCatalogoEnd";
        public const string catEnderecosPais = "paisCatalogoEnd";

        #region === Arrays ===
        public const string catEnderecosArrayUf = "UfsCatalogoEnd";
        public const string catEnderecosArrayCidades = "CidadesCatalogoEnd";

        public const string catEnderecosIdUf = "idUfCatalogoEnd";
        public const string catEnderecosUf = "ufCatalogoEnd";

        public const string catEnderecosIdCidade = "idCidadeCatalogoEnd";
        public const string catEnderecosCidade = "cidadeCatalogoEnd";
        #endregion

        #endregion

        /// <summary>
        /// Nome da collection de atualizações no banco de dados.
        /// </summary>
        public const string collecAtualizacoes = "Atualizacoes";
        #region === Collection Atualizacoes ===
        /// <summary>
        /// Nome do campo do banco de dados que guarda o Oid do registro.
        /// </summary>
        public const string atualizacaoId = "_id";
        /// <summary>
        /// Nome do campo do banco de dados que guarda o Oid do usuário que terá as suas atualizações(ou as atualizações de seus contatos) guardadas no array listaAtualizacao.
        /// </summary>
        public const string atualizacaoIdUsuario = "oidUsuario";
        /// <summary>
        /// Nome do campo que guarda o tipo da atualização, sendo eles: 1 se for atualização propria ou 0 se for atualização de algum contato.
        /// </summary>
        public const string atualizacaoTipo = "tipoAtualizacao";
        /// <summary>
        /// Nome do array que guardará as atualizações proprias ou de contatos.
        /// </summary>
        public const string atualizacaoArrayLista = "listaAtualizacao";

        #region === Arrray lista de atualizacoes ===
        /// <summary>
        /// Nome do campo que guarda a data e hora que o usuário(ou contato) fez a atualização.
        /// </summary>
        public const string atualizacaoArrayListaCreatedTime = "createdTime";
        /// <summary>
        /// Nome do campo que guarda o nome do usuário(ou contato) que fez a atualização.
        /// </summary>
        public const string atualizacaoArrayListaNomeUsu = "nomeUsuarioAtualizacao";
        /// <summary>
        /// Nome do campo que guarda a mensagem da atualização feita pelo usuário(ou contato).
        /// </summary>
        public const string atualizacaoArrayListaMensagem = "mensagemAtualizacao";
        /// <summary>
        /// Nome do campo que guarda o Oid do usuário(ou contato) que fez a atualização.
        /// </summary>
        public const string atualizacaoArrayListaOidUsu = "oidUsuarioAtualizacao";
        /// <summary>
        /// Tipo da atualização
        /// </summary>
        public const string atualizacaoArrayTipoAtualizacao = "tipoAtualizacao";
        #endregion
        #endregion

        /// <summary>
        /// Nome da collection de categorias de serviços.
        /// </summary>
        public const string collecCategoriasServico = "CategoriasServico";
        #region === Collection CategoriasServicos ===
        /// <summary>
        /// Nome do campo que guardará o id da categoria de serviço.
        /// </summary>
        public const string categoriasServicoId = "categoriasServicoId";
        /// <summary>
        /// Nome do campo que guardará o nome da categoria de serviço.
        /// </summary>
        public const string categoriasServicoNome = "categoriasServicoNome";
        #endregion
        
        /// <summary>
        /// Nome da collection que guarda os e-mails das pessoas interessadas em usar o Net3s.
        /// </summary>
        public const string collecEmailTemp = "EmailTemp";
        #region === Collection emailTemp ===
        public const string emailTemp = "emailInteressadoTemp";
        #endregion
    }

    /// <summary>
    /// Guarda os nomes das chaves do registro.
    /// </summary>
    public class NomeChaveRegistro
    {
        #region === Configurações de atualizações ===
        /// <summary>
        /// Essa chave guarda se o usuário quer postar como atualização quando ele inserir um novo serviço
        /// </summary>
        public const string chaveAtualizPostarInsercaoServicos = "postarInsercaoServicos";
        #endregion

        //TODO: Adicionar as chaves de configurações que definem se será
        //mostrado alguns campos em contatos de usuário ou não.
    }

    /// <summary>
    /// Guarda os valores padrões para cada chave declarada na classe NomeChaveRegistro.
    /// </summary>
    public class ValorPadraoChaveRegistro
    {
        #region === Configurações de atualizações ===
        public const string chaveAtualizPostarInsercaoServicos = "1";
        #endregion
    }
}

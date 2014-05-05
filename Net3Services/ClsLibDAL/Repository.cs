using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MongoDB;
using MongoDB.GridFS;

namespace ClsLibDAL
{
    public class Repository
    {
        private IMongoDatabase _db;
        private Mongo server;
        
        public IMongoDatabase DB
        {
            get
            {
                if (_db != null) return _db;
                Action<MongoConnectionStringBuilder> actMcsb = new Action<MongoConnectionStringBuilder>(delegate(MongoConnectionStringBuilder mcsb){
                    mcsb.Username = "Net3";
                    mcsb.Password = "n3shdi.6w-a";
                    mcsb.Database = "Net3Services";
                    mcsb.AddServer("flame.mongohq.com", 27041);
                
                });
                //MongoConnectionStringBuilder mcsb = new MongoConnectionStringBuilder();
                //#region === MongoHq ===
                //    mcsb.Username = "Net3";
                //    mcsb.Password = "n3shdi.6w-a";
                //    mcsb.Database = "Net3Services";
                //    mcsb.AddServer("flame.mongohq.com", 27041);
                //#endregion
                //mcsb.AddServer("localhost", 27017);
                //string conn = mcsb.ToString();
                try
                {
                    //server = new Mongo(conn);
                    MongoDB.Configuration.MongoConfigurationBuilder mcb = new MongoDB.Configuration.MongoConfigurationBuilder();
                    mcb.ConnectionString(actMcsb);
                    MongoDB.Configuration.MongoConfiguration mc = mcb.BuildConfiguration();
                    server = new Mongo(mc);
                    server.Connect();
                    _db = server.GetDatabase("Net3Services");
                }
                catch
                {
                    throw new Exception("Não foi possivel estabelecer contato com o servidor, recarregue a página e tente novamente.");
                }

                return _db;

                //User: Net3
                //Senha: n3shdi.6w-a

                /*
                 Mongo Console 
                  mongo locke.mongohq.com:10003/Net3Services -u <user> -p <password>
                 
                 Mongo URI 
                  mongodb://<user>:<password>@locke.mongohq.com:10003/Net3Services
                    */
            }
        }

        /// <summary>
        /// Método responsável por finalizar a conexão com o banco de dados.
        /// </summary>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Desconectar()
        {
            _db = null;
            server.Disconnect();
        }

        /// <summary>
        /// Método que inseri um novo documento em uma collection do banco de dados.
        /// </summary>
        /// <param name="doc">Documento a ser inserido em uma collection do banco de dados.</param>
        /// <param name="collectionName">Nome da collection que o documento será inserido.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Insert(Document doc, string collectionName)
        {
            var collection = DB.GetCollection(collectionName);
            collection.Insert(doc);
            Desconectar();
        }

        /// <summary>
        /// Este método insere vários documentos no banco de dados.
        /// </summary>
        /// <param name="doc">Documentos que serão inseridos no banco de dados.</param>
        /// <param name="collectionName">Nome da collection.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Insert(IEnumerable<Document> doc, string collectionName)
        {
            IMongoCollection collection = DB.GetCollection(collectionName);
            collection.Insert(doc);
            Desconectar();
        }

        /// <summary>
        /// Método usado para atualizar dados de um documento no banco de dados.
        /// </summary>
        /// <param name="docAntigo">Documento antigo, usado para identificar qual documento será atualizado</param>
        /// <param name="docNovo">Documento novo, com os dados a que serão substituidos pelo antigo.</param>
        /// <param name="collectionName">Nome da collection em que se localiza o documento que será atualizado.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Update(Document docAntigo, Document docNovo, string collectionName)
        {
            //Document dado = DB.GetCollection(collectionName).FindOne(docAntigo);
            DB.GetCollection(collectionName).Update(docNovo, docAntigo);
            //dado.Update(docNovo);
            Desconectar();
        }

        /// <summary>
        /// Este método tem a função de salvar um documento no banco de dados. Se o documento existir ele é editado, se não existir ele é inserido no DB.
        /// </summary>
        /// <param name="doc">Documento a ser salvo.</param>
        /// <param name="collectionName">Nome da collection.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Save(Document doc, string collectionName)
        {
            IMongoCollection collection = DB.GetCollection(collectionName);
            collection.Save(doc);
            Desconectar();
        }

        /// <summary>
        /// Este método tem como objetivo excluir um documento com base em uma busca feita a partir de um documento base.
        /// </summary>
        /// <param name="doc">Documento base para fazer uma busca no banco e excluir o resultado da busca.</param>
        /// <param name="collectionName">Coleção que tem o registro a ser excluido</param>
        public void delete(Document doc, string collectionName)
        {
            var excluido = DB.GetCollection(collectionName).FindOne(doc);
            DB.GetCollection(collectionName).Remove(excluido);
            Desconectar();
        }

        /// <summary>
        /// Executa uma busca onde o resultado é sempre um registro do banco de dados.
        /// </summary>
        /// <param name="doc">Documento usado como filtro de busca.</param>
        /// <param name="collec">Nome da collection onde a busca será feita.</param>
        /// <returns>Retorna um objeto do tipo Document.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document ProcurarUm(Document doc, string collec)
        {
            IMongoCollection colle = DB.GetCollection(collec);
            Document resultado = colle.FindOne(doc);
            Desconectar();
            return resultado;
        }

        /// <summary>
        /// Procurar em geral da para ser usada para logar achar tudo enfim usada para todos os metodos de busca
        /// </summary>
        /// <param name="doc">Documento com, no mínimo, uma clausula</param>
        /// <param name="collec">Collection que tem o documento a ser procurado.</param>
        /// <returns>Retorna uma lista de documentos</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> Procurar(Document doc, string collec)
        {
            IMongoCollection colle = DB.GetCollection(collec);
            IEnumerable<Document> lstResultado = colle.Find(doc).Documents;

            List<Document> list = new List<Document>();
            if (lstResultado != null)
                list = lstResultado.ToList<Document>();

            Desconectar();
            return list;
        }

        /// <summary>
        /// Procurar em geral da para ser usada para logar achar tudo enfim usada para todos os metodos de busca.
        /// </summary>
        /// <param name="doc">Documento com, no mínimo, uma clausula</param>
        /// <param name="collec">Collection que tem o documento a ser procurado.</param>
        /// <param name="limit">Numero maximo de documentos a ser retornado.</param>
        /// <returns>Retorna uma lista de documentos</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> Procurar(Document doc, string collec, int limit)
        {
            IMongoCollection colle = DB.GetCollection(collec);
            IEnumerable<Document> lstResultado = colle.Find(doc).Limit(limit).Documents;
           
            List<Document> list = new List<Document>();
            if (lstResultado != null)
                list = lstResultado.ToList<Document>();

            Desconectar();
            return list;
        }

        /// <summary>
        /// Procurar em geral da para ser usada para logar achar tudo enfim usada para todos os metodos de busca.
        /// </summary>
        /// <param name="doc">Documento com, no mínimo, uma clausula</param>
        /// <param name="collec">Collection que tem o documento a ser procurado.</param>
        /// <param name="limit">Número máximo de documentos a ser retornado.</param>
        /// <param name="tipoOrdenacao">Maneira que o resultado será ordenado.</param>
        /// <param name="campoOrdenacao">Nome do campo que será usado como referência para a ordenação do resultado da busca.</param>
        /// <returns>Retorna uma lista de documentos</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> Procurar(Document doc, string collec, int limit, IndexOrder tipoOrdenacao, string campoOrdenacao)
        {
            IMongoCollection colle = DB.GetCollection(collec);
            IEnumerable<Document> lstResultado = colle.Find(doc).Sort(campoOrdenacao, tipoOrdenacao).Limit(limit).Documents;

            List<Document> list = new List<Document>();
            if (lstResultado != null)
                list = lstResultado.ToList<Document>();

            Desconectar();
            return list;
        }

        /// <summary>
        /// Conta quantos documentos estão na collection(determinada pelo segundo parâmetro) que atendem a condição determinada pelo documento(primeiro parâmetro).
        /// </summary>
        /// <param name="doc">Documento que determina a condição para fazer a contagem.</param>
        /// <param name="collec">Nome da collection onde irá ser feita a contagem pelo MongoDB.</param>
        /// <returns>Retorna o número de documentos que atendem a condição imposta pelo documento recebido(primeiro parâmetro).</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public long Count(Document doc, string collec)
        {
            /*
                [Test]
                public void TestCountWithSpec()
                {
                    var counts = DB["counts_spec"];
                    counts.Insert(new Document().Add("Last", "Cordr").Add("First", "Sam").Add("cnt", 1));
                    counts.Insert(new Document().Add("Last", "Cordr").Add("First", "Sam").Add("cnt", 2));
                    counts.Insert(new Document().Add("Last", "Corder").Add("First", "Sam").Add("cnt", 3));

                    Assert.AreEqual(2, counts.Count(new Document().Add("Last", "Cordr")));
                    Assert.AreEqual(1, counts.Count(new Document().Add("Last", "Corder")));
                    Assert.AreEqual(0, counts.Count(new Document().Add("Last", "Brown")));
                }
             */
            IMongoCollection colle = DB.GetCollection(collec);
            long result = colle.Count(doc);
            Desconectar();
            return result;
        }

        /// <summary>
        /// Este método executa uma busca no banco de dados usando o operador $regex.
        /// </summary>
        /// <param name="nomeCampo">Nome do campo usado como filtro da busca.</param>
        /// <param name="valorCampo">Valor do campo usado como filtro da busca.</param>
        /// <param name="collec">Nome da collection em que a busca será feita.</param>
        /// <returns>Retorna uma lista de documentos.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> ProcurarRegex(string nomeCampo, string valorCampo, string collec)
        {
            //i - Case insensitive. Letters in the pattern match both upper and lower
            //db.customers.find( { name : { $regex : 'acme.*corp', $options: 'i' } } );
            var col = DB[collec]; //Collection em que será feita a busca.

            var regexQuery = new Document();
            var regex = new Document();
            regex.Add("$regex", valorCampo);
            regex.Add("$options", "i");

            /*Neste ponto, um documento desse tipo é montado:
             * {
             *      nomeCampo : { $regex : 'valorCampo', $options: 'i' }
             * }
             * 
             * Onde nomeCampo e valorCampo são parâmetros que este método recebe.
             */
            regexQuery.Add(nomeCampo, regex);
            IEnumerable<Document> resposta = col.Find(regexQuery).Documents;
            List<Document> lstDoc = new List<Document>();
            if (resposta != null)
                lstDoc = resposta.ToList<Document>();
            Desconectar();
            return lstDoc;
        }

        /// <summary>
        /// Este metodo tem a capacidade de procurar qual quer coisa, por Json, mas fizemos ele especialmente para buscar arrays
        /// mas podera ser utilizado em outras coisas
        /// </summary>
        /// <param name="collec">Colection onde irá acontecer a busca</param>
        /// <param name="where">Condição para a busca, em outras metodos seria substituido por ducumentos</param>
        /// <returns>Retorna uma lista de documentos</returns>
        public List<Document> procurarArray(string col, string where)
        {
            IMongoCollection collec = DB.GetCollection(col);
            IEnumerable<Document> ie = collec.Find(where).Documents;
            ICursor resp = collec.Find(where);

            List<Document> lstDoc = new List<Document>();

            foreach (Document doc in ie)
            {
                lstDoc.Add(doc);
            }

            Desconectar();

            return lstDoc;
        }

        /// <summary>
        /// Método que busca todos os registros de uma collection do banco de dados. Usado em casos muito específicos.
        /// </summary>
        /// <param name="col">Nome da collection</param>
        /// <returns>Retorna uma lista de objetos do tipo Document com o registros da collection.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> ProcurarTodos(string col)
        {
            IMongoCollection collec = DB.GetCollection(col);
            IEnumerable<Document> resultado = collec.FindAll().Documents;

            List<Document> lstRetorno = new List<Document>();
            if (resultado != null)
                lstRetorno = resultado.ToList<Document>();
            Desconectar();
            return lstRetorno;
        }

        /// <summary>
        /// Método que busca todos os registros de uma collection do banco de dados.
        /// </summary>
        /// <param name="col">Nome da collection</param>
        /// <param name="limit">Número máximo de documentos a ser retornado.</param>
        /// <returns>Retorna uma lista de objetos do tipo Document com o registros da collection.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> ProcurarTodos(string col, int limit)
        {
            IMongoCollection collec = DB.GetCollection(col);
            IEnumerable<Document> resultado = collec.FindAll().Limit(limit).Documents;

            List<Document> lstRetorno = new List<Document>();
            if(resultado != null)
                lstRetorno = resultado.ToList<Document>();
            Desconectar();
            return lstRetorno;
        }

        /// <summary>
        /// Método que busca todos os registros de uma collection do banco de dados.
        /// </summary>
        /// <param name="col">Nome da collection</param>
        /// <param name="limit">Número máximo de documentos a ser retornado.</param>
        /// <param name="ordenacao">Maneira que o resultado será ordenado.</param>
        /// <param name="tipoOrdenacao">Maneira que o resultado será ordenado.</param>
        /// <param name="campoOrdenacao">Nome do campo que será usado como referência para a ordenação do resultado da busca.</param>
        /// <returns>Retorna uma lista de objetos do tipo Document com o registros da collection.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> ProcurarTodos(string col, int limit, IndexOrder tipoOrdenacao, string campoOrdenacao)
        {
            IMongoCollection collec = DB.GetCollection(col);
            IEnumerable<Document> resultado = collec.FindAll().Sort(campoOrdenacao, tipoOrdenacao).Limit(limit).Documents;

            List<Document> lstRetorno = new List<Document>();
            if (resultado != null)
            {
                try
                {
                    lstRetorno = resultado.ToList<Document>();
                }
                catch (MongoException ex)
                {
                    //Caiu aqui uma vez quando demorou mt para fazer a conexão com o banco de dados.
                    //Eu achei estranho, mas enfim, pus um tratamento aqui.
                    //TODO: Verificar os erros possíveis para eta linha.
                    //Thiago Vieira - 07-05-2012
                    throw new MongoException("Ocorreu um erro inesperado.", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro inesperado.", ex);
                }
            }
            Desconectar();
            return lstRetorno;
        }

        #region ArquivosMongo

        /// <summary>
        /// Inserir um novo arquivo, preste bem atenção,
        /// no documento que você irá montar deve conter tres especificações no minimo
        /// sendo elas: filename(nome do arquivo), metadata(em binario segue o exemplo) e o contentType(tipo do arquivo para montar ele quando for buscado)]
        /// 
        /// byte[] bite = File.ReadAllBytes(@"d:\adm.txt");
        /// Binary bin = new Binary(bite);
        /// 
        /// Document doc = new Document();
        /// doc["filename"] = "oid";
        /// doc["metadata"] = bin;
        /// doc["ContentType"] = Path.GetExtension(@"d:\adm.txt");
        /// </summary>
        /// <param name="doc">Qual collection ele irá pertencer</param>
        public void inserirArquivo(string collection, Document doc)
        {
            GridFile gf = new GridFile(DB, collection);
            gf.Files.Insert(doc);

            Desconectar();
        }

        /// <summary>
        /// Procura os arquivos ligados a aquela collection
        /// </summary>
        /// <param name="collection">Passa a collection onde ela irá ser procurada</param>
        /// <param name="doc">Documento onde terão os parametros a serem procurados</param>
        public List<Document> procurarArquivo(string collection, Document doc)
        {
            GridFile fs = new GridFile(DB, collection);
            IEnumerable<Document> gridFile = fs.Files.Find(doc).Documents;

            List<Document> resposta = new List<Document>();

            foreach (Document cur in gridFile)
            {
                resposta.Add(cur);
            }

            Desconectar();

            return resposta;
        }

        /// <summary>
        /// Atualiza o arquivo
        /// </summary>
        /// <param name="docNew">Novo documento a ser atualizado</param>
        /// <param name="docOld">Documento antigo onde irá conter o documento velho</param>
        /// <param name="collection">Coleçao onde foi feita a operação</param>
        public void atualizaArquivo(Document docNew, Document docOld, string collection)
        {
            GridFile gf = new GridFile(DB, collection);
            gf.Files.Update(docNew, docOld);

            Desconectar();
        }

        /// <summary>
        /// Deletar algum arquivo no caso de deletar algum serviço do usuario   
        /// </summary>
        /// <param name="collection">Coleção onde se encontra a imagem</param>
        /// <param name="doc">Documento que ele irá deletar</param>
        public void deletaArquivo(string collection, Document doc)
        {
            GridFile gf = new GridFile(DB, collection);
            gf.Files.Remove(doc);

            Desconectar();
        }

        #endregion
    }
}

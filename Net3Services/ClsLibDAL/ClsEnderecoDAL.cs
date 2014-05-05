using System;
using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsEnderecoDAL
    {
        /// <summary>
        /// Método que tem por função adicionar endereços a um usuário no banco de dados.
        /// </summary>
        /// <param name="end">Objeto do tipo endereco que contém os dados a serem inseridos no banco de dados.</param>
        /// <param name="idUsuario">Id do usuário relacionado a este endereço informado.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void InserirEndereco(Endereco end, Oid idUsuario)
        {
            Document doc = new Document();
            Document docUsuario = new Document();
            docUsuario[NomeCompBd.usuario_id] = idUsuario;
            doc = montarDocumentoSemId(end);
            OidGen idGen = new OidGen();
            doc[NomeCompBd.usuEnderecos_id] = idGen.Generate();
            docUsuario[NomeCompBd.usuArrayEnderecos] = doc;

            Repository rep = new Repository();
                rep.Save(docUsuario, NomeCompBd.collecUsuarios);
            
        }

        /// <summary>
        /// Método para editar um endereço.
        /// </summary>
        /// <param name="end">Objeto do tipo Endereco</param>
        /// <param name="idUsuario">Oid do usuário que vai ter o endereço editado.</param>
        public void EditarEndereco(Endereco end, Oid idUsuario)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para excluir um endereço.
        /// </summary>
        /// <param name="oidEndereco">Oid do endereço que irá ser excluido.</param>
        /// <param name="idUsu">Oid do usuário que terá o endereço excluido.</param>
        public void ExcluirEnderedo(Oid oidEndereco, Oid idUsu)
        {
            throw new NotImplementedException();
        }

        public List<Endereco> BuscarEnderecoPorId(Oid _id)
        {
            List<Endereco> lstEnderecos = new List<Endereco>();
            Repository rep = new Repository();
                IMongoDatabase bd = rep.DB;

                IMongoCollection usuarios = bd.GetCollection(NomeCompBd.collecUsuarios);
                ICursor resposta = usuarios.Find(@"{enderecos : { $in : [" + _id + "]}}");

                lstEnderecos = montarListaObjetos(resposta.Documents);
                return lstEnderecos;
            
        }

        #region === Montar objetos e documentos ===
        
        /// <summary>
        /// Monta um objeto do tipo Endereco a partir de um Document.
        /// </summary>
        /// <param name="doc">Documento que será usado para montar o objeto do tipo Endereco.</param>
        /// <returns>Retorna um objeto do tipo Endereco.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Endereco montarObjeto(Document doc)
        {
            Endereco end = new Endereco();
            if(doc[NomeCompBd.usuEnderecos_id] != null)
            {
                end.id = new Oid(doc[NomeCompBd.usuEnderecos_id].ToString());
            }

            end.cidade = doc[NomeCompBd.usuEnderecosCidade] != null ? doc[NomeCompBd.usuEnderecosCidade].ToString() : null;
            end.pais = doc[NomeCompBd.usuEnderecosPais] != null ? doc[NomeCompBd.usuEnderecosPais].ToString() : null;
            end.uf = doc[NomeCompBd.usuEnderecosUf] != null ? doc[NomeCompBd.usuEnderecosUf].ToString() : null;
            end.bairro = doc[NomeCompBd.usuEnderecosBairro] != null ? doc[NomeCompBd.usuEnderecosBairro].ToString() : null;
            end.cep = doc[NomeCompBd.usuEnderecosCep] != null ? doc[NomeCompBd.usuEnderecosCep].ToString() : null;
            end.complemento = doc[NomeCompBd.usuEnderecosComplemento] != null ? doc[NomeCompBd.usuEnderecosComplemento].ToString() : null;
            end.numero = doc[NomeCompBd.usuEnderecosNumEndereco] != null ? ushort.Parse(doc[NomeCompBd.usuEnderecosNumEndereco].ToString()) : ushort.MinValue;
            end.logradouro = doc[NomeCompBd.usuEnderecosLogradouro] != null ? doc[NomeCompBd.usuEnderecosLogradouro].ToString() : null;

            return end;
        }

        /// <summary>
        /// Monta um documento de endereco a partir de um objeto do tipo Endereco.
        /// </summary>
        /// <param name="end">Objeto do tipo endereco que será usado para montar o documento.</param>
        /// <returns>Retorna um documento de endereco.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document montarDocumento(Endereco end)
        {
            Document doc = new Document();
            doc = montarDocumentoSemId(end);
            doc[NomeCompBd.usuEnderecos_id] = end.id;
            return doc;
        }

        /// <summary>
        /// Monta um documento de endereco sem Oid a partir de um objeto do tipo Endereco.
        /// </summary>
        /// <param name="end">Objeto do tipo endereco que será usado para montar o documento.</param>
        /// <returns>Retorna um documento de endereco sem Oid.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document montarDocumentoSemId(Endereco end)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuEnderecosCidade] = end.cidade;
            doc[NomeCompBd.usuEnderecosPais] = end.pais;
            doc[NomeCompBd.usuEnderecosUf] = end.uf;
            doc[NomeCompBd.usuEnderecosBairro] = end.bairro;
            doc[NomeCompBd.usuEnderecosCep] = end.cep;
            doc[NomeCompBd.usuEnderecosComplemento] = end.complemento;
            doc[NomeCompBd.usuEnderecosNumEndereco] = end.numero;
            doc[NomeCompBd.usuEnderecosLogradouro] = end.logradouro;
            return doc;
        }

        /// <summary>
        /// Monta uma lista do tipo Endereco a partir de um IEnumerable.
        /// </summary>
        /// <param name="cur">Objeto IEnumerable usado para montar a lista do tipo Endereco.</param>
        /// <returns>Retorna uma lista do tipo Endereco</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Endereco> montarListaObjetos(IEnumerable<Document> cur)
        {
            List<Endereco> lstEndereco = new List<Endereco>();
            foreach (Document item in cur)
            {
                lstEndereco.Add(montarObjeto(item));
            }
            return lstEndereco;
        }

        /// <summary>
        /// Monta uma lista do tipo Endereco a partir de uma lista de objetos do tipo Endereco.
        /// </summary>
        /// <param name="cur">Objeto List usado para montar a lista do tipo Endereco.</param>
        /// <returns>Retorna uma lista do tipo Endereco.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Endereco> montarListaObjetos(List<Document> cur)
        {
            List<Endereco> lstEndereco = new List<Endereco>();
            foreach (Document item in cur)
            {
                lstEndereco.Add(montarObjeto(item));
            }
            return lstEndereco;
        }

        /// <summary>
        /// Monta uma lista de documentos de endereços.
        /// </summary>
        /// <param name="lstEndereco">Lista do tipo do Endereco que será usada para montar a lista do tipo Document.</param>
        /// <returns>Retorna uma lista do tipo Document.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> montarListaDocumentos(List<Endereco> lstEndereco)
        {
            List<Document> lstDocumento = new List<Document>();
            foreach (var item in lstEndereco)
            {
                lstDocumento.Add(montarDocumento(item));
            }
            return lstDocumento;
        }
        #endregion
    }
}

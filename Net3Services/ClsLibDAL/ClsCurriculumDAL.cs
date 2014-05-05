using System;
using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsCurriculumDAL
    {
        /// <summary>
        /// Edita o curriculo de um usuário.
        /// </summary>
        /// <param name="oidUsuario">Oid do usuário que terá o seu curriculo alterado.</param>
        /// <param name="objCur">Objeto do tipo Curriculum com os dados para substituírem os dados no banco de dados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void EditarCurriculum(Oid oidUsuario, Curriculum objCur)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            Document doc = usuarioDAL.BuscarUsuarioPorIdDocument(oidUsuario);
            Document docCur = MontarDocumento(objCur);
            doc[NomeCompBd.usuCurriculum] = docCur;
            Repository rep = new Repository();
            rep.Save(doc, NomeCompBd.collecUsuarios);
        }

        /// <summary>
        /// Busca o curriculo de um usuário.
        /// </summary>
        /// <param name="oidUsuario">Oid do usuário usado como filtro de busca.</param>
        /// <returns>Retorna um objeto do tipo Curriculum.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Curriculum BuscarCurriculum(Oid oidUsuario)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = oidUsuario;
            Repository rep = new Repository();
                List<Document> lstReposta = rep.Procurar(doc, NomeCompBd.collecUsuarios);
                if (lstReposta.Count > 0)
                {
                    //Se o campo Curriculum for diferente de null, é montado o objeto e retornado.
                    if (lstReposta[0][NomeCompBd.usuCurriculum] != null)
                    {
                        if (!lstReposta[0][NomeCompBd.usuCurriculum].GetType().Equals(DBNull.Value.GetType()))
                            return MontarObjeto((Document)lstReposta[0][NomeCompBd.usuCurriculum]);
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                { return null; }
            
        }

        /// <summary>
        /// Monta um objeto do tipo Document a partir de um objeto do tipo Curriculum.
        /// </summary>
        /// <param name="objCur">Objeto do tipo Curriculum que será usado para montar o documento.</param>
        /// <returns>Retorna um objeto do tipo Document.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document MontarDocumento(Curriculum objCur)
        {
            if (objCur == null)
                return null;

            Document doc = new Document();
            List<Document> lstDocCursos = new List<Document>();
            List<Document> lstDocIdiomas = new List<Document>();
            List<Document> lstDocExperiencia = new List<Document>();
            List<Document> lstDocCertificacao = new List<Document>();
            List<Document> lstDocPremios = new List<Document>();

            #region === Preencher a lista lstDocCertificacao ===
            if (objCur.ObjCertificacao != null)
            {
                Action<Certificacao> actPreencherLstDocCertificacao = new Action<Certificacao>(delegate(Certificacao objCert)
                    {
                        Document docCert = new Document();
                        docCert[NomeCompBd.usuCurriculumCertificacoesData] = objCert.Descricao;
                        docCert[NomeCompBd.usuCurriculumCertificacoesDescricao] = objCert.Descricao;
                        docCert[NomeCompBd.usuCurriculumCertificacoesInstituicao] = objCert.Instituicao;
                        docCert[NomeCompBd.usuCurriculumCertificacoesNome] = objCert.Nome;
                        lstDocCertificacao.Add(docCert);
                    }
                );
                objCur.ObjCertificacao.ForEach(actPreencherLstDocCertificacao);
            }
            #endregion
            #region === Preencher a lista lstDocCursos ===
            if (objCur.ObjCursos != null)
            {
                Action<Cursos> actPreencherLstDocCursos = new Action<Cursos>(delegate(Cursos objCurso)
                    {
                        Document docCurso = new Document();
                        docCurso[NomeCompBd.usuCurriculumCursosDataFim] = objCurso.DataFim;
                        docCurso[NomeCompBd.usuCurriculumCursosDataInicio] = objCurso.DataInicio;
                        docCurso[NomeCompBd.usuCurriculumCursosNome] = objCurso.Nome;
                        docCurso[NomeCompBd.usuCurriculumCursosNomeInstituicao] = objCurso.NomeInstituicao;
                        lstDocCursos.Add(docCurso);
                    }
                );
                objCur.ObjCursos.ForEach(actPreencherLstDocCursos);
            }
            #endregion
            #region === Preencher a lista lstDocExperiencia ===
            if (objCur.ObjExperiencia != null)
            {
                Action<Experiencia> actPreencherLstDocExperiencia = new Action<Experiencia>(delegate(Experiencia objExp)
                    {
                        Document docExp = new Document();
                        docExp[NomeCompBd.usuCurriculumExperienciasDataFim] = objExp.DataFim;
                        docExp[NomeCompBd.usuCurriculumExperienciasDataInicio] = objExp.DataInicio;
                        docExp[NomeCompBd.usuCurriculumExperienciasNomeLocal] = objExp.NomeLocal;
                        docExp[NomeCompBd.usuCurriculumExperienciasAtual] = objExp.Atual ? 1 : 0;
                        docExp[NomeCompBd.usuCurriculumExperienciasDescAtividades] = objExp.DescricaoAtividades;
                        lstDocExperiencia.Add(docExp);
                    }
                );
                objCur.ObjExperiencia.ForEach(actPreencherLstDocExperiencia);
            }
            #endregion
            #region === Preencher lista lstDocIdiomas ===
            if (objCur.ObjIdiomas != null)
            {
                Action<Idiomas> actPreencherLstDocIdiomas = new Action<Idiomas>(delegate(Idiomas objIdioma)
                    {
                        Document docIdioma = new Document();
                        docIdioma[NomeCompBd.usuCurriculumIdiomasFluencia] = (int)objIdioma.Fluencia;
                        docIdioma[NomeCompBd.usuCurriculumIdiomasNome] = objIdioma.Nome;
                        lstDocIdiomas.Add(docIdioma);
                    }
                );
                objCur.ObjIdiomas.ForEach(actPreencherLstDocIdiomas);
            }
            #endregion
            #region === Preencher lista lstDocPremios ===
            if (objCur.ObjPremios != null)
            {
                Action<Premios> actPreencherLstDocPremios = new Action<Premios>(delegate(Premios objPremio)
                    {
                        Document docPremio = new Document();
                        docPremio[NomeCompBd.usuCurriculumPremiosData] = objPremio.Data;
                        docPremio[NomeCompBd.usuCurriculumPremiosDescricao] = objPremio.Descricao;
                        docPremio[NomeCompBd.usuCurriculumPremiosInstituicao] = objPremio.Instituicao;
                        docPremio[NomeCompBd.usuCurriculumPremiosNome] = objPremio.Nome;
                        lstDocPremios.Add(docPremio);
                    }
                );
                objCur.ObjPremios.ForEach(actPreencherLstDocPremios);
            }
            #endregion
            doc[NomeCompBd.usuCurriculumArrayCertificacao] = lstDocCertificacao;
            doc[NomeCompBd.usuCurriculumArrayCursos] = lstDocCursos;
            doc[NomeCompBd.usuCurriculumArrayExperiencia] = lstDocExperiencia;
            doc[NomeCompBd.usuCurriculumArrayIdiomas] = lstDocIdiomas;
            doc[NomeCompBd.usuCurriculumArrayPremios] = lstDocPremios;
            return doc;
        }

        /// <summary>
        /// Monta um objeto do tipo Curriculum a partir de um objeto do tipo Document com os dados do curriculum do usuário.
        /// </summary>
        /// <param name="docCur">Objeto do tipo Document usado para monta o objeto do tipo Curriculum.</param>
        /// <returns>Retorna um objeto do tipo Curriculum.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Curriculum MontarObjeto(Document docCur)
        {
            if (docCur == null)
                return null;

            Curriculum objCur = new Curriculum();
            objCur.ObjCertificacao = new List<Certificacao>();
            objCur.ObjCursos = new List<Cursos>();
            objCur.ObjExperiencia = new List<Experiencia>();
            objCur.ObjIdiomas = new List<Idiomas>();
            objCur.ObjPremios = new List<Premios>();

            List<Document> lstDocCursos, lstDocIdiomas, lstDocExperiencia, lstDocCertificacao, lstDocPremios;

            try { lstDocCursos = (List<Document>)docCur[NomeCompBd.usuCurriculumArrayCursos]; }
            catch { lstDocCursos = null; }

            try { lstDocIdiomas = (List<Document>)docCur[NomeCompBd.usuCurriculumArrayIdiomas]; }
            catch { lstDocIdiomas = null; }

            try { lstDocExperiencia = (List<Document>)docCur[NomeCompBd.usuCurriculumArrayExperiencia]; }
            catch { lstDocExperiencia = null; }

            try { lstDocCertificacao = (List<Document>)docCur[NomeCompBd.usuCurriculumArrayCertificacao]; }
            catch { lstDocCertificacao = null; }

            try { lstDocPremios = (List<Document>)docCur[NomeCompBd.usuCurriculumArrayPremios]; }
            catch { lstDocPremios = null; }

            #region === Actions ===
            Action<Document> actPreencherObjCertificacao = new Action<Document>(delegate(Document docCert)
                {
                    Certificacao objCert = new Certificacao();
                    objCert.Data = docCert[NomeCompBd.usuCurriculumCertificacoesData] != null ? Convert.ToDateTime(docCert[NomeCompBd.usuCurriculumCertificacoesData]) : DateTime.MinValue;
                    objCert.Descricao = docCert[NomeCompBd.usuCurriculumCertificacoesDescricao] != null ? docCert[NomeCompBd.usuCurriculumCertificacoesDescricao].ToString() : null;
                    objCert.Instituicao = docCert[NomeCompBd.usuCurriculumCertificacoesInstituicao] != null ? docCert[NomeCompBd.usuCurriculumCertificacoesInstituicao].ToString() : null;
                    objCert.Nome = docCert[NomeCompBd.usuCurriculumCertificacoesNome] != null ? docCert[NomeCompBd.usuCurriculumCertificacoesNome].ToString() : null;
                    objCur.ObjCertificacao.Add(objCert);
                }
            );
            Action<Document> actPreencherObjCursos = new Action<Document>(delegate(Document docCurso)
                {
                    Cursos objCurso = new Cursos();
                    objCurso.DataFim = docCurso[NomeCompBd.usuCurriculumCursosDataFim] != null ? Convert.ToDateTime(docCurso[NomeCompBd.usuCurriculumCursosDataFim]) : DateTime.MinValue;
                    objCurso.DataInicio = docCurso[NomeCompBd.usuCurriculumCursosDataInicio] != null ? Convert.ToDateTime(docCurso[NomeCompBd.usuCurriculumCursosDataInicio]) : DateTime.MinValue;
                    objCurso.Nome = docCurso[NomeCompBd.usuCurriculumCursosNome] != null ? docCurso[NomeCompBd.usuCurriculumCursosNome].ToString() : null;
                    objCurso.NomeInstituicao = docCurso[NomeCompBd.usuCurriculumCursosNomeInstituicao] != null ? docCurso[NomeCompBd.usuCurriculumCursosNomeInstituicao].ToString() : null;
                    objCur.ObjCursos.Add(objCurso);
                }
            );
            Action<Document> actPreencherObjExperiencia = new Action<Document>(delegate(Document docExperiencia)
                {
                    Experiencia objExp = new Experiencia();
                    objExp.DataFim = Convert.ToDateTime(docExperiencia[NomeCompBd.usuCurriculumExperienciasDataFim]);
                    objExp.DataInicio = Convert.ToDateTime(docExperiencia[NomeCompBd.usuCurriculumExperienciasDataInicio]);
                    objExp.NomeLocal = docExperiencia[NomeCompBd.usuCurriculumExperienciasNomeLocal].ToString();
                    objExp.Atual = docExperiencia[NomeCompBd.usuCurriculumExperienciasAtual] != null ? (Convert.ToInt32(docExperiencia[NomeCompBd.usuCurriculumExperienciasAtual]) == 1 ? true : false) : false;
                    objExp.DescricaoAtividades = docExperiencia[NomeCompBd.usuCurriculumExperienciasDescAtividades].ToString();
                    objCur.ObjExperiencia.Add(objExp);
                }
            );
            Action<Document> actPreencherObjIdiomas = new Action<Document>(delegate(Document docIdioma)
                {
                    Idiomas objIdioma = new Idiomas();
                    objIdioma.Nome = docIdioma[NomeCompBd.usuCurriculumIdiomasNome] != null ? docIdioma[NomeCompBd.usuCurriculumIdiomasNome].ToString() : null;
                    if (docIdioma[NomeCompBd.usuCurriculumIdiomasFluencia] != null)
                    {
                        switch (Convert.ToInt32(docIdioma[NomeCompBd.usuCurriculumIdiomasFluencia]))
                        {
                            case 1:
                                objIdioma.Fluencia = FluenciaIdioma.Iniciante;
                                break;
                            case 2:
                                objIdioma.Fluencia = FluenciaIdioma.Intermerdiario;
                                break;
                            case 3:
                                objIdioma.Fluencia = FluenciaIdioma.Avancado;
                                break;
                            case 4:
                                objIdioma.Fluencia = FluenciaIdioma.Fluente;
                                break;
                            case 5:
                                objIdioma.Fluencia = FluenciaIdioma.Nativo;
                                break;
                        }
                    }
                    objCur.ObjIdiomas.Add(objIdioma);
                }
            );
            Action<Document> actPreencherObjPremios = new Action<Document>(delegate(Document docPremio)
                {
                    Premios objPremio = new Premios();
                    objPremio.Data = docPremio[NomeCompBd.usuCurriculumPremiosData] != null ? Convert.ToDateTime(docPremio[NomeCompBd.usuCurriculumPremiosData]) : DateTime.MinValue;
                    objPremio.Descricao = docPremio[NomeCompBd.usuCurriculumPremiosDescricao] != null ? docPremio[NomeCompBd.usuCurriculumPremiosDescricao].ToString() : null;
                    objPremio.Instituicao = docPremio[NomeCompBd.usuCurriculumPremiosInstituicao] != null ? docPremio[NomeCompBd.usuCurriculumPremiosInstituicao].ToString() : null;
                    objPremio.Nome = docPremio[NomeCompBd.usuCurriculumPremiosNome] != null ? docPremio[NomeCompBd.usuCurriculumPremiosNome].ToString() : null;
                    objCur.ObjPremios.Add(objPremio);
                }
            );
            #endregion

            if (lstDocCursos != null)
                lstDocCursos.ForEach(actPreencherObjCursos);

            if (lstDocIdiomas != null)
                lstDocIdiomas.ForEach(actPreencherObjIdiomas);

            if (lstDocExperiencia != null)
                lstDocExperiencia.ForEach(actPreencherObjExperiencia);

            if (lstDocCertificacao != null)
                lstDocCertificacao.ForEach(actPreencherObjCertificacao);

            if (lstDocPremios != null)
                lstDocPremios.ForEach(actPreencherObjPremios);

            return objCur;
        }
    }
}
using System;
using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// Enum que lista tipos de fluencia de um idioma.
    /// </summary>
    public enum FluenciaIdioma:short
    {
        Iniciante,
        Intermerdiario,
        Avancado,
        Fluente,
        Nativo
    }

    /// <summary>
    /// Interface que determina informações que todo reconhecimento deve ter.
    /// </summary>
    interface IReconhecimentos
    {
        string Nome { get; set; }
        string Descricao { get; set; }
        DateTime Data { get; set; }
        string Instituicao { get; set; }
    }

    /// <summary>
    /// Modelo do curriculum do usuário.
    /// </summary>
    public class Curriculum
    {
        /*olha no do supertal
    são tipo conhecimentos
    locais onde já trabalhou
    linguas que fala
    e tal
    estava pensando em separar em 3 categorias
    cursos 
    onde entraria escolas, faculdade, cursos a parte
    idiomas
    em que o cara adiciona o idioma e a fluência
    e depois a parte das experiências
 */
        public List<Cursos> ObjCursos { get; set; }
        public List<Idiomas> ObjIdiomas { get; set; }
        public List<Experiencia> ObjExperiencia { get; set; }
        public List<Certificacao> ObjCertificacao { get; set; }
        public List<Premios> ObjPremios { get; set; }
    }

    /// <summary>
    /// Representa um curso feito por um usuário.
    /// </summary>
    public class Cursos
    {
        /// <summary>
        /// Guardará o nome do curso feito pelo usuário.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Guardará o nome da instituição onde o usuário fez o curso.
        /// </summary>
        public string NomeInstituicao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }

    /// <summary>
    /// Idiomas que o usuário fala.
    /// </summary>
    public class Idiomas
    {
        /// <summary>
        /// Nome do idioma que o usuário fala.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Fluência do usuário em relação à língua falada.
        /// </summary>
        public FluenciaIdioma Fluencia { get; set; }
    }

    /// <summary>
    /// Representa uma experiência profissional adquirida poe um usuário.
    /// </summary>
    public class Experiencia
    {
        /// <summary>
        /// Nome do local onde a experiência profissional foi adquirida.
        /// </summary>
        public string NomeLocal { get; set; }
        /// <summary>
        /// Data de início da experiencia profissional.
        /// </summary>
        public DateTime DataInicio { get; set; }
        /// <summary>
        /// Data fim da experiencia profissional passada pelo usuário.
        /// </summary>
        public DateTime DataFim { get; set; }
        /// <summary>
        /// Campo que guarda a descrição do que o usuário fazia na empresa.
        /// </summary>
        public string DescricaoAtividades { get; set; }
        /// <summary>
        /// Flag que guardará se a experiência do usuário ainda está em andamento.
        /// </summary>
        public bool Atual { get; set; }
    }

    /// <summary>
    /// Certificações que o usuário possa ter conseguido.
    /// </summary>
    public class Certificacao : IReconhecimentos
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Instituicao { get; set; }
    }

    /// <summary>
    /// Prêmios que o usuário possa ter ganhado.
    /// </summary>
    public class Premios : IReconhecimentos
    {
        public string Nome { get; set; }
        public string Instituicao { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
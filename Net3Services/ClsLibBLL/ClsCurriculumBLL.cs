using ClsLibDAL;
using Models;
using MongoDB;
using System.Text.RegularExpressions;

namespace ClsLibBLL
{
    public class ClsCurriculumBLL
    {
        /// <summary>
        /// Edita o curriculo de um usuário.
        /// </summary>
        /// <param name="oidUsuario">Oid do usuário que terá o seu curriculo alterado.</param>
        /// <param name="objCur">Objeto do tipo Curriculum com os dados para substituírem os dados no banco de dados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void EditarCurriculum(Oid oidUsuario, Curriculum objCur)
        {
            if (clsUtilidades.ValidarOid(oidUsuario))
            {
                ClsCurriculumDAL curriculumDAL = new ClsCurriculumDAL();
                curriculumDAL.EditarCurriculum(oidUsuario, objCur);
            }
            else
            {
                throw new OidNullException("Oid do usuário inválido.");
            }
        }

        /// <summary>
        /// Busca o curriculo de um usuário.
        /// </summary>
        /// <param name="oidUsuario">Oid do usuário usado como filtro de busca.</param>
        /// <returns>Retorna um objeto do tipo Curriculum.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Curriculum BuscarCurriculum(Oid oidUsuario)
        {
            if (clsUtilidades.ValidarOid(oidUsuario))
            {
                ClsCurriculumDAL curriculumDAL = new ClsCurriculumDAL();
                return curriculumDAL.BuscarCurriculum(oidUsuario);
            }
            else
            {
                throw new OidNullException("Oid do usuário inválido,");
            }
        }

        public bool[] ValidarInfoCertificados(Certificacao cert)
        {
            bool[] retorno = new bool[3];

            if (Regex.IsMatch(cert.Nome, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,60}$"))
                retorno[0] = true;
            else
                retorno[0] = false;

            if (Regex.IsMatch(cert.Instituicao, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,60}$"))
                retorno[1] = true;
            else
                retorno[1] = false;

            if (Regex.IsMatch(cert.Descricao, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,400}$"))
                retorno[2] = true;
            else
                retorno[2] = false;

            return retorno;
        }

        public bool[] ValidarInfoPremios(Premios premio)
        {
            bool[] retorno = new bool[3];

            if (Regex.IsMatch(premio.Instituicao, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,60}$"))
                retorno[0] = true;
            else
                retorno[0] = false;

            if (Regex.IsMatch(premio.Nome, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,60}$"))
                retorno[1] = true;
            else
                retorno[1] = false;

            if (Regex.IsMatch(premio.Descricao, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,400}$"))
                retorno[2] = true;
            else
                retorno[2] = false;

            return retorno;
        }
    }
}

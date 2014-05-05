using System;
using MongoDB;
using System.Collections.Generic;

namespace Models
{
    public class Administrador
    {
        public Oid _id { get; set; }
        public string nome { get; set; }

        //Junior 22-07-11 adicionando o endereco do usuário
        public string pais { get; set; }
        public string UF { get; set; }
        public string cidade { get; set; }

        /// <summary>
        /// Pode ser (Ativo(0), Inativo(1), Afastado(2))
        /// </summary>
        public int? situacao { get; set; }
        public string login { get; set; }
        public string senha { get; set; }

        //Confirmar a senha na BLL, por isso este campo
        public string cSenha { get; set; }

        //Junior 22-07-11 adicionando a data do cadastrmento
        public DateTime? dataCadastro { get; set; }

        /// <summary>
        /// Quando for adicionar um adm a quantidade é zero, esse campo é para ter controle da quantidade de denuncia para cada adm
        /// quando ele atender uma denuncia fica -1, e quando ganhar mais uma fica +1
        /// </summary>
        public int? quantDenum { get; set; }
    }

    public class AdminIDComparer : IEqualityComparer<Administrador>
    {
        public bool Equals(Administrador x, Administrador y)
        {
            return x._id == y._id;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(Administrador x)
        {
            return x._id.GetHashCode();
        }
    }
}

using System;
using System.Text.RegularExpressions;
using ClsLibDAL;

namespace ClsLibBLL
{
    public class ClsEmailTempBLL
    {
       /// <summary>
       /// Método que insere o e-mail de uma pessoa interessada em usar o Net3s.
       /// </summary>
       /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void InserirEmail(string email)
        {
            email = email.Trim();
            if (Regex.IsMatch(email, @"^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$"))
            {
                ClsEmailTempDAL emailTemp = new ClsEmailTempDAL();
                emailTemp.InserirEmail(email);
            }
            else
            {
                throw new Exception("E-mail inválido.");
            }
        }
    }
}

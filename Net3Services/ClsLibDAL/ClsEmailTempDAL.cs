using MongoDB;

namespace ClsLibDAL
{
    public class ClsEmailTempDAL
    {
       /// <summary>
       /// Método que insere o e-mail de uma pessoa interessada em usar o Net3s.
       /// </summary>
       /// <by>Thiago Vieira - t.vas@hotmail.com</by>
       public void InserirEmail(string email)
       {
           Document doc = new Document();
           doc[NomeCompBd.emailTemp] = email;

           Repository rep = new Repository();
           rep.Insert(doc, NomeCompBd.collecEmailTemp);
       }
    }
}

using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsRelatorioDAL
    {
        //Colção onde os dados vão ser inseridos
        string collec = "Historico"; 

        //Ele irá inserir um registro a cada 24 horas - timer
        //ou seja, entre 24 horas tudo vai ser update
        public void inserir(Relatorio relat)
        {
            Repository rep = new Repository();

            //inserir os campos em um documento
            Document doc = new Document();
            doc["dataIni"] = relat.dataIni;
            doc["dataFim"] = relat.dataFim;
            doc["servMaisContrat"] = relat.servMaisContrat;
            doc["servMaisPrest"] = relat.serMaisPrest;
            doc["quantUsu"] = relat.quantUsuario;
            doc["quantUsuInativ"] = relat.quantUsuarioInativ;
            doc["quantUsuContrat"] = relat.quantUsuContart;
            doc["quantUsuPrest"] = relat.quantUsuPrest;

            //Quantidade de usuários que são os dois tipos
            doc["quantUsuCP"] = relat.quantUsuCP;
            doc["quantOcorr"] = relat.quantOcorr;

            //quantidade de serviços fechados e cancelados
            doc["quantServFech"] = relat.quantServFech;
            doc["quantServCanc"] = relat.quantServCanc;

            rep.Insert(doc, collec);
        }

        //entre o periodo de tempo de 24 horas ele vai acrecentando valores
        //ou seja, esse é manual o outro é automatico
        public void atualizar(Relatorio relat)
        {
            Repository rep = new Repository();

            //Documento velho
            Document docVelho = new Document();
            docVelho["_id"] = relat._id;

            //inserir os campos em um documento
            Document doc = new Document();
            doc["dataIni"] = relat.dataIni;
            doc["dataFim"] = relat.dataFim;
            doc["servMaisContrat"] = relat.servMaisContrat;
            doc["servMaisPrest"] = relat.serMaisPrest;
            doc["quantUsu"] = relat.quantUsuario;
            doc["quantUsuInativ"] = relat.quantUsuarioInativ;
            doc["quantUsuContrat"] = relat.quantUsuContart;
            doc["quantUsuPrest"] = relat.quantUsuPrest;

            //Quantidade de usuários que são os dois tipos
            doc["quantUsuCP"] = relat.quantUsuCP;
            doc["quantOcorr"] = relat.quantOcorr;

            //quantidade de serviços fechados e cancelados
            doc["quantServFech"] = relat.quantServFech;
            doc["quantServCanc"] = relat.quantServCanc;

            rep.Update(docVelho, doc, collec);
        }
    }
}

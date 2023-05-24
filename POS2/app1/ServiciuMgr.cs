using entitati;
using System;
using System.Xml;

namespace app1
{
    public class ServiciuMgr : ProduseAbstractMgr
    {
        public void InitListafromXML()
        {
            //initializare lista dintr-un fisier XML
            XmlDocument doc = new XmlDocument();
            //incarca fisierul
            doc.Load("C:\\Users\\Raul\\OneDrive\\Desktop\\POS2\\app1\\ProduseSiServicii.xml");
            XmlNodeList lista_noduri = doc.SelectNodes("/produsesiservicii/Serviciu");
            foreach (XmlNode nod in lista_noduri)
            {

                string nume = nod["Nume"].InnerText;
                string codIntern = nod["CodIntern"].InnerText;
                double pret = double.Parse(nod["Pret"].InnerText);
                string categorie = nod["Categorie"].InnerText;

                elemente.Add(new Serviciu(elemente.Count + 1, nume, codIntern, pret, categorie));
            }
        }

        public void WriteServicii()
        {
            Console.WriteLine("Serviciile sunt:");
            foreach (Serviciu elem in elemente)
            {
                Console.WriteLine(elem.Descriere());
            }
            Console.ReadKey();
        }

    }
}

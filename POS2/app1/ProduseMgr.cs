using entitati;
using System;
using System.Xml;

namespace app1
{
    public class ProduseMgr : ProduseAbstractMgr
    {

        public void InitListafromXML()
        {
            //initializare lista dintr-un fisier XML
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Raul\\OneDrive\\Desktop\\POS2\\app1\\ProduseSiServicii.xml");
            XmlNodeList lista_noduri = doc.SelectNodes("/produsesiservicii/Produs");
            foreach (XmlNode nod in lista_noduri)
            {
                string nume = nod["Nume"].InnerText;
                string codIntern = nod["CodIntern"].InnerText;
                string producator = nod["Producator"].InnerText;
                double pret = double.Parse(nod["Pret"].InnerText);
                string categorie = nod["Categorie"].InnerText;

                elemente.Add(new Produs(elemente.Count + 1, nume, codIntern, producator, pret, categorie));
            }
        }

        public void WriteProduse()
        {
            Console.WriteLine("Produsele sunt:");
            foreach (Produs elem in elemente)
            {
                Console.WriteLine(elem.AltaDescriere());
            }
            Console.ReadKey();
        }
    }
}


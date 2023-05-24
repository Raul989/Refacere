using entitati;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace app1
{
    public class PachetMgr : ProduseAbstractMgr
    {
        public void ReadPachet()
        {
            //initializare lista dintr-un fisier XML
            XmlDocument doc = new XmlDocument();
            //incarca fisierul
            doc.Load("C:\\Users\\Raul\\OneDrive\\Desktop\\POS2\\app1\\ProduseSiServicii.xml");
            XmlNodeList lista_noduri_pachete = doc.SelectNodes("/elemente/elem_pachet");
            foreach (XmlNode nod in lista_noduri_pachete)
            {

                string nume = nod["Nume"].InnerText;
                string codIntern = nod["CodIntern"].InnerText;
                double pret = double.Parse(nod["Pret"].InnerText);
                string categorie = nod["Categorie"].InnerText;

                Pachet pachet = new Pachet(elemente.Count + 1, nume, codIntern, pret, categorie);

                XmlNodeList lista_noduri_produse = nod.SelectNodes("./Produs");
                foreach (XmlNode nod1 in lista_noduri_produse)
                {
                    string nume1 = nod1["Nume"].InnerText;
                    string codIntern1 = nod1["CodIntern"].InnerText;
                    string producator1 = nod1["Producator"].InnerText;
                    double pret1 = double.Parse(nod1["Pret"].InnerText);
                    string categorie1 = nod1["Categorie"].InnerText;
                    Produs pr = new Produs(pachet.Elem_pachet.Count + 1, nume1, codIntern1, producator1, pret1, categorie1);
                    pachet.Add_element(pr);
                    pachet.Pret += pret1;
                }

                XmlNodeList lista_noduri_servicii = nod.SelectNodes("./Serviciu");
                foreach (XmlNode nod2 in lista_noduri_servicii)
                {
                    string nume2 = nod2["Nume"].InnerText;
                    string codIntern2 = nod2["CodIntern"].InnerText;
                    double pret2 = double.Parse(nod2["Pret"].InnerText);
                    string categorie2 = nod2["Categorie"].InnerText;
                    Serviciu serv = new Serviciu(pachet.Elem_pachet.Count + 1, nume2, codIntern2, pret2, categorie2);
                    pachet.Add_element(serv);
                    pachet.Pret += pret2;
                }
                elemente.Add(pachet);

            }
        }

        public void save2XML(string fileName)
        {
            Type[] prodAbstractTypes = new Type[4];
            prodAbstractTypes[0] = typeof(List<ProdusAbstract>);
            prodAbstractTypes[1] = typeof(Pachet);
            prodAbstractTypes[2] = typeof(Produs);
            prodAbstractTypes[3] = typeof(Serviciu);


            XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), prodAbstractTypes);
            StreamWriter sw = new StreamWriter(fileName);
            xs.Serialize(sw, this.elemente);
            sw.Close();
        }

        public void loadFromXML(string fileName)
        {
            Type[] prodAbstractTypes = new Type[4];
            prodAbstractTypes[0] = typeof(List<ProdusAbstract>);
            prodAbstractTypes[1] = typeof(Pachet);
            prodAbstractTypes[2] = typeof(Produs);
            prodAbstractTypes[3] = typeof(Serviciu);
            XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), prodAbstractTypes);
            FileStream fs = new FileStream(fileName, FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            this.elemente = (List<ProdusAbstract>)xs.Deserialize(reader);
            fs.Close();
        }

        public void save2File(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, this.elemente);
            fs.Close();
        }

        public void loadFromFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            this.elemente = (List<ProdusAbstract>)formatter.Deserialize(fs);
            fs.Close();
        }

        public void Afisare()
        {
            elemente.Sort();
            foreach (Pachet pac in elemente)
            {
                Console.WriteLine(pac.Descriere());
                foreach (ProdusAbstract p in pac.Elem_pachet)
                {
                    Console.WriteLine(p.Descriere());
                }
                Console.WriteLine("\n");
            }
        }


    }
}

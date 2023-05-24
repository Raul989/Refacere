using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace entitati
{
    [Serializable]
    public class Serviciu : ProdusAbstract, IPackageble
    {
        public Serviciu(long unId, String unNume, String unCodIntern, double unPret, String oCategorie) : base(unId, unNume, unCodIntern, unPret, oCategorie)
        {
        }

        public Serviciu()
        {
        }

        public void save2XML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
            StreamWriter sw = new StreamWriter(fileName);
            xs.Serialize(sw, this);
            sw.Close();
        }

        public override String Descriere()
        {
            return "Serviciul " + Id + ": " + Nume + " || Cod intern :[" + CodIntern + "] " + "" + " || Pret: " + Pret + " || Categorie: " + Categorie;
        }

        public override String AltaDescriere()
        {
            return "Serviciul" + base.AltaDescriere();
        }

        public bool canAddToPackage(Pachet pachet)
        {
            return true;
        }
    }
}


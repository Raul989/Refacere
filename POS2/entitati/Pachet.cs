using System;
using System.Collections.Generic;

namespace entitati
{
    [Serializable]
    public class Pachet : ProdusAbstract, IPackageble
    {
        List<ProdusAbstract> elem_pachet = new List<ProdusAbstract>();
        public List<ProdusAbstract> Elem_pachet { get => elem_pachet; set => elem_pachet = value; }

        public static Pachet loadFromXML(object fileName)
        {
            throw new NotImplementedException();
        }

        public Pachet(long unId, String unNume, String unCodIntern, double unPret, String oCategorie) : base(unId, unNume, unCodIntern, unPret, oCategorie)
        {
        }

        public Pachet()
        {

        }

        public bool canAddToPackage(Pachet pachet)
        {
            return false;
        }

        public override String Descriere()
        {
            return "Pachetul " + Id + ": " + Nume + " || Categorie : " + Categorie + "";
        }

        public void Add_element(ProdusAbstract p)
        {
            elem_pachet.Add(p);
        }
    }
}

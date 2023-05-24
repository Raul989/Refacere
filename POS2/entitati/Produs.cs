using System;

namespace entitati
{
    [Serializable]
    public class Produs : ProdusAbstract, IPackageble
    {
        private String producator;// producator

        public string Producator { get => producator; set => producator = value; }

        public Produs(long unId, String unNume, String unCodIntern, String producator, double unPret, String oCategorie) : base(unId, unNume, unCodIntern, unPret, oCategorie)
        {
            this.Producator = producator;
        }

        public Produs()
        {

        }

        public override String Descriere()
        {
            return "Produsul " + Id + ": " + Nume + " || Cod intern :[" + CodIntern + "] " + " || Producator: " + Producator + "" + " || Pret: " + Pret + " || Categorie: " + Categorie;
        }

        public override String AltaDescriere()
        {
            return "Produsul" + base.AltaDescriere() + " || Producator: " + Producator + "";
        }

        public override String ToString()
        {
            return "Produsul " + Id + ": " + Nume + " || Cod intern :[" + CodIntern + "] " + " || Producator: " + Producator + "" + " || Pret: " + Pret + " || Categorie " + Categorie;
        }

        public bool canAddToPackage(Pachet pachet)
        {
            int c = 0;
            foreach (IPackageble p in pachet.Elem_pachet)
            {
                if (p is Produs)
                    c++;
            }
            if (c == 0)
                return true;
            else
                return false;
        }
    }
    }


using System;

namespace entitati
{
    [Serializable]
    public abstract class ProdusAbstract : IComparable
    {
        private long id;
        private String nume;
        private String codIntern;
        private double pret;
        private String categorie;

        public ProdusAbstract(long unId, String unNume, String unCodIntern, double unPret, String oCategorie)
        {
            this.Id = unId;
            this.Nume = unNume;
            this.CodIntern = unCodIntern;
            this.Pret = unPret;
            this.Categorie = oCategorie;
        }

        public ProdusAbstract()
        {

        }

        public long Id { get => id; set => id = value; }
        public string Nume { get => nume; set => nume = value; }
        public string CodIntern { get => codIntern; set => codIntern = value; }
        public double Pret { get => pret; set => pret = value; }
        public string Categorie { get => categorie; set => categorie = value; }

        public abstract String Descriere();
        public virtual String AltaDescriere()
        {
            return "[" + Id + "]: " + Nume + " || Cod intern :[" + CodIntern + "] || Pret: " + Pret + " || Categorie: " + Categorie; ;
        }

        public int CompareTo(object obj)
        {
            if (this.Pret > (obj as ProdusAbstract).Pret)
                return 1;
            else if (this.Pret < (obj as ProdusAbstract).Pret)
                return -1;
            else
                return 0;

        }
    }
}

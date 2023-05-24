using entitati;
using System;
using System.Collections.Generic;

namespace app1
{
    public abstract class ProduseAbstractMgr
    {

        protected List<ProdusAbstract> elemente = new List<ProdusAbstract>();
        protected int nrElemente = 0;

        public void Write2Console(String elemType)
        {
            Console.WriteLine(elemType + "sunt: ");

            foreach (ProdusAbstract elem in elemente)
            {
                Console.WriteLine(elem.Descriere());
            }
        }

    }


}

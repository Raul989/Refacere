using System;
using entitati;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace app1
{
    class Program
    {
        static void Main(string[] args)
        {
        
            PachetMgr mgrPachete = new PachetMgr();
            mgrPachete.save2XML("C:\\Users\\Raul\\OneDrive\\Desktop\\POS2\\app1\\test");
            mgrPachete.loadFromXML("C:\\Users\\Raul\\OneDrive\\Desktop\\POS2\\app1\\test");
            mgrPachete.ReadPachet();
            mgrPachete.Afisare();

            Console.ReadKey();
        }
    }
}

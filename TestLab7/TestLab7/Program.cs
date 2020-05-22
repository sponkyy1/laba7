using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLab7
{
    public class Misto : IComparable
    {
        public string Name;         //ім'я         
        public int Widht;           // вік               
        public string GetName() { return Name; }         
        public int GetWidht() { return Widht; }         
        public Misto(string N, int W)         
        {             
            this.Name = N;
            this.Widht = W;
        }
        public int CompareTo(object pers) 
        {
            Misto p = (Misto)pers; 
            if (this.Widht > p.Widht) return 1; 
            if (this.Widht < p.Widht) return -1; return 0; 
        }
        public void Mistoo() 
        { 
            Console.WriteLine("Name = {0} Widht = {1}", Name, Widht); 
        }

        class Program
        {
            static void Main(string[] args)
            {
                Misto prep1 = new Misto("Lviv", 182);
                Misto prep2 = new Misto("Uzhgorod", 40);
                Misto prep3 = new Misto("Rivne", 63);
                Misto prep4 = new Misto("Kyiv", 847);
                Misto prep5 = new Misto("Odesa", 162);
                Misto prep6 = new Misto("Harkiv", 350);
                Misto[] group = new Misto[6]; 
                group[0] = prep1; 
                group[1] = prep2; 
                group[2] = prep3; 
                group[3] = prep4; 
                group[4] = prep5; 
                group[5] = prep6; 
                Array.Sort(group); 
                foreach (Misto elem in group) elem.Mistoo(); 
                Console.ReadLine();
            }
        }
    }
}

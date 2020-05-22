using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections.Immutable;

namespace Laba7._2
{
    public class Misto : IComparable
    {
        public string Name;
        public int Widht;
        public int Naselenya;
        private string[] mas;

        public string GetName() { return Name; }
        public int GetWidht() { return Widht; }

        public Misto(string N, int NL)
        {
            this.Name = N;
            this.Naselenya = NL;
        }

        public Misto(string[] mas, int naselenya)
        {
            this.mas = mas;
            Naselenya = naselenya;
        }

        public int CompareTo(object pers)
        {
            Misto p = (Misto)pers;
            if (this.Naselenya > p.Naselenya) return 1;
            if (this.Naselenya < p.Naselenya) return -1; return 0;
        }
    }

    class Mistoo : IEnumerable
    {

        protected int size; 
        protected Misto[] container;
        Random rnd = new Random();
        public Mistoo()
        {
            size = 10;
            container = new Misto[size];
            FillContainer();
        }

        public Mistoo(int size)
        {
            this.size = size;
            container = new Misto[size];
            FillContainer();
        }
        public Mistoo(Misto[] container)
        {
            this.container = container;
            size = container.Length;
        }
        void FillContainer()
        {
            int d = 0;
            for (int i = 0; i < size; i++)
            {
                string[] mas = new string[] { "Lviv", "Uzhgorod" , "Rivne", "Kyiv", "Odesa", "Harkiv" };
                int naselenya = rnd.Next(600000, 2000000000);
                if (true) 
                {
                    container[i] = new Misto(mas[d], naselenya);
                }
                d += 1;              
            }
            
        }
        public IEnumerator GetEnumerator()
        {
            Array.Sort(container);
            return container.GetEnumerator();
        }
    }

    class Program { 
        static void Main(string[] args) 
        { 
            int size = 6;
            Mistoo agents = new Mistoo(size);
 
            foreach (Misto agent in agents) 
            {
                Console.WriteLine("Misto:  " + agent.Name.ToString() + "    Naselenya:  " + agent.Naselenya.ToString()); 
            } 
            Console.ReadLine();
        } 
    }
}
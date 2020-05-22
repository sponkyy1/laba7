using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba7._1
{
    public class Misto 
    {
        public string Name;              
        public int Widht;
        public int Naselenya;      
        public string GetName() { return Name; }
        public int GetWidht() { return Widht; }
        public Misto(string N,int W, int NL)         
        {             
            this.Name = N;             
            this.Widht = W;             
            this.Naselenya = NL;         
        }                   
        virtual public void Passport()         
        {             
            Console.WriteLine("Name = {0} Widht = {1}  Naselenya = {2}", Name, Widht, Naselenya);         
        }
        

        public class SortByWidht : IComparer
        {                          
            int IComparer.Compare(object ob1, object ob2)              
            {
                Misto p1 = (Misto)ob1;
                Misto p2 = (Misto)ob2;                  
                if (p1.Widht > p2.Widht) return 1;                  
                if (p1.Widht < p2.Widht) return -1;                  
                return 0;              
            }          
        } 

            public class SortByNaselenya : IComparer                                       
        {                         
            int IComparer.Compare(object ob1, object ob2)              
            {
                Misto p1 = (Misto)ob1;
                Misto p2 = (Misto)ob2;                  
                if (p1.Naselenya > p2.Naselenya) return 1;                  
                if (p1.Naselenya < p2.Naselenya) return -1;                  
                return 0;               
            }          
        }     
    }     
    class Program     
    {         
        static void Main(string[] args)         
        {
            Misto prep1 = new Misto("Lviv", 182,7000000);
            Misto prep2 = new Misto("Uzhgorod", 40, 12321332);
            Misto prep3 = new Misto("Rivne", 63, 123332);
            Misto prep4 = new Misto("Kyiv", 847,1000000);
            Misto prep5 = new Misto("Odesa", 162, 600000);
            Misto prep6 = new Misto("Harkiv", 350, 70000);
            Misto[] group = new Misto[6];            
            group[0] = prep1;             
            group[1] = prep2;             
            group[2] = prep3;             
            group[3] = prep4;             
            group[4] = prep5;             
            group[5] = prep6;             
            Console.WriteLine("sort is width:");             
            Array.Sort(group,new Misto.SortByWidht());                     
            foreach (Misto elem in group) elem.Passport();             
            Console.WriteLine("sort is naselenya:");             
            Array.Sort(group,new Misto.SortByNaselenya());                  
            foreach (Misto elem in group) elem.Passport();             
            Console.ReadLine();         
        }
    }
}
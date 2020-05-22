using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace laba7._2._2
{
    class StorageAuto : IComparable<StorageAuto>
    {             // 1         
        const int f_name = 10;
        private string code;
        private string name;
        private string marka;
        private int price;
        private int quantity;
        public StorageAuto()
        {
            code = "";
            name = "Anonimous";
            marka = "";
            price = 0;
            quantity = 0;
        }
        public StorageAuto(string s)
        {
            code = s.Substring(0, f_name);
            name = s.Substring(f_name, 9);
            marka = s.Substring(f_name + 9, 6);
            price = Convert.ToInt32(s.Substring(f_name + 15, 7));
            quantity = Convert.ToInt32(s.Substring(f_name + 22));
            if (price < 0) throw new FormatException();
            if (quantity < 0) throw new FormatException();
        }
        public void AppendAllText(string path, string contents)
        {
            if (!File.Exists(path))
            {
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }

            string append = "\n";
            File.AppendAllText(path, append);
            File.AppendAllText(path, contents);
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
            Console.WriteLine("Text add to file");
        }
        public void Delete(string path, int line)
        {
            if (!File.Exists(path))
            {
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }
            string[] fileLines = File.ReadAllLines(path);
            fileLines[line] = String.Empty; // deleting
            File.WriteAllLines(path, fileLines);
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
            Console.WriteLine("Text delete to file");
        }
        public override string ToString()
        {
            return string.Format("Code: {0,10} Name: {1:10,16} Marka: {2:16,22} Price: {3} Quantity: {4}", code, name, marka, price, quantity);
        }
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }
        public int Price
        {
            get { return price; }
            set
            {
                if (value > 0) price = value;
                else throw new FormatException();
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value > 0) price = quantity;
                else throw new FormatException();
            }
        }
        // ------------------  операції класу ---------------------------         
        public int CompareTo(StorageAuto other)
        {

            // Alphabetic sort if salary is equal. [A to Z]
            if (this.Price == other.Price)
            {

                return this.Price.CompareTo(other.Price);
            }
            // Default to salary sort. [High to low]
            return other.Price.CompareTo(this.Price);
        }
    };



    class Program
    {
        static void Main(string[] args)
        {
            List<StorageAuto> list = new List<StorageAuto>();
            int n = 0;
            StreamReader f = new StreamReader("dbase.txt");
            string s;
            int i = 0;
            try
            {
                while ((s = f.ReadLine()) != null)
                {
                    list.Add(new StorageAuto(s));
                    ++i;
                }
                n = i - 1;
                list.Sort();


                foreach (var element in list)
                {
                    Console.WriteLine(element);
                }
                f.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Check the correct name and path to the file!");
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Very large file!");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); return;
            }
            Console.WriteLine("Enter text if you want to add a line in database: ");
            string names;
            while ((names = Console.ReadLine()) != "")
            {
                StorageAuto add = new StorageAuto();
                Console.WriteLine("Enter the line you want to add: ");
                string numberOfLineToAdd = Console.ReadLine();
                add.AppendAllText("dbase.txt", numberOfLineToAdd);
            }

            Console.WriteLine("Enter text if you want to delete a line in database: ");
            string nam;
            while ((nam = Console.ReadLine()) != "")
            {
                StorageAuto del = new StorageAuto();
                Console.WriteLine("Enter the line you want to delete: ");
                int numberOfLineToDelete = Convert.ToInt32(Console.ReadLine());
                del.Delete("dbase.txt", numberOfLineToDelete);
            }
        }

    }
}

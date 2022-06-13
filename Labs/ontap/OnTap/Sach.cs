using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap
{
    public class Sach
    {
        private int nameSize;
        private string name;
        public string Name { get=>name; set { name = value; nameSize = name.Length; } }

        public int Size { get; set; }

        public int ID { get; set; }
        public double Price { get; set; }

        public Sach()
        {
        }

        public Sach(int iD, string name, double price)
        {
            ID = iD;
            Name = name;
            Price = price;
        }

        public Sach(byte[] data)
        {
            int place = 0;
            ID = BitConverter.ToInt32(data, place);
            place += 4;

            nameSize = BitConverter.ToInt32(data, place);
            place += 4;
            Name = Encoding.ASCII.GetString(data, place, nameSize);
            place += nameSize;

            Price = BitConverter.ToDouble(data, place);
            place += 8;
            Size = place;
        }

        public byte[] GetBytes()
        {
            byte[] data = new byte[1024];
            int place = 0;

            Buffer.BlockCopy(BitConverter.GetBytes(ID), 0, data, place, 4);
            place += 4;

            Buffer.BlockCopy(BitConverter.GetBytes(nameSize), 0, data, place, 4);
            place += 4;
            Buffer.BlockCopy(Encoding.ASCII.GetBytes(Name), 0, data, place, nameSize);
            place += nameSize;

            Buffer.BlockCopy(BitConverter.GetBytes(Price), 0, data, place, 8);
            place += 8;
            Size = place;
            return data;
        }

        public void ImportBook()
        {
            Console.WriteLine("Ma sach: ");
            ID = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ten sach: ");
            Name = Console.ReadLine();
            Console.WriteLine("Gia sach: ");
            Price = Double.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("ID: {0}", ID));
            sb.AppendLine(String.Format("Ten sach: {0}", Name));
            sb.AppendLine(String.Format("Gia sach: {0}", Price));

            return sb.ToString();
        }

        public void WriteToFile(string path)
        {
            using(var write = File.AppendText(path))
            {
                write.Write(this.ToString());
            }
        }
    }
}

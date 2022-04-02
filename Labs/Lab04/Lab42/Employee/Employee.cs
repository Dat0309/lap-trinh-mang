using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public class Employee
    {
        private int lastNameSize;
        private string lastName;
        private int firstNameSize;
        private string firstName;

		public int EmployeeID { get; set; }
		public string LastName
		{
			get => lastName;
			set
			{
				lastName = value;
				lastNameSize = lastName.Length;
			}
		}
		public string FirstName
		{
			get => firstName;
			set
			{
				firstName = value;
				firstNameSize = firstName.Length;
			}
		}
		public int YearService { get; set; }
		public double Salary { get; set; }
		public int Size { get; set; }

		public Employee()
		{
		}

		public Employee(byte[] data)
		{
			int place = 0;
			// For ID
			EmployeeID = BitConverter.ToInt32(data, place);
			place += 4;
			// For last name
			lastNameSize = BitConverter.ToInt32(data, place);
			place += 4;
			LastName = Encoding.ASCII.GetString(data, place, lastNameSize);
			place += lastNameSize;
			// For first name
			firstNameSize = BitConverter.ToInt32(data, place);
			place += 4;
			FirstName = Encoding.ASCII.GetString(data, place, firstNameSize);
			place += firstNameSize;
			// For year
			YearService = BitConverter.ToInt32(data, place);
			place += 4;
			// For salary
			Salary = BitConverter.ToDouble(data, place);
			place += 8;
			Size = place;
		}

		public Employee(int employeeID, string lastName, string firstName, int yearService, double salary)
		{
			EmployeeID = employeeID;
			LastName = lastName;
			FirstName = firstName;
			YearService = yearService;
			Salary = salary;
		}

		public byte[] GetBytes()
		{
			byte[] data = new byte[1024];
			int place = 0;
			// For ID
			Buffer.BlockCopy(BitConverter.GetBytes(EmployeeID), 0, data, place, 4);
			place += 4;
			// For last name
			Buffer.BlockCopy(BitConverter.GetBytes(lastNameSize), 0, data, place, 4);
			place += 4;
			Buffer.BlockCopy(Encoding.ASCII.GetBytes(LastName), 0, data, place, lastNameSize);
			place += lastNameSize;
			// For first name
			Buffer.BlockCopy(BitConverter.GetBytes(firstNameSize), 0, data, place, 4);
			place += 4;
			Buffer.BlockCopy(Encoding.ASCII.GetBytes(FirstName), 0, data, place, firstNameSize);
			place += firstNameSize;
			// For year
			Buffer.BlockCopy(BitConverter.GetBytes(YearService), 0, data, place, 4);
			place += 4;
			// For salary
			Buffer.BlockCopy(BitConverter.GetBytes(Salary), 0, data, place, 8);
			place += 8;
			Size = place;
			return data;
		}

		public void ImportEmployee()
		{
			Console.Write("Employee ID: ");
			EmployeeID = Int32.Parse(Console.ReadLine());
			Console.Write("Last name: ");
			LastName = Console.ReadLine();
			Console.Write("First name: ");
			FirstName = Console.ReadLine();
			Console.Write("Year service: ");
			YearService = Int32.Parse(Console.ReadLine());
			Console.Write("Salary: ");
			Salary = Double.Parse(Console.ReadLine());
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine(String.Format("ID: {0}", EmployeeID));
			builder.AppendLine(String.Format("Last name: {0}", LastName));
			builder.AppendLine(String.Format("First name: {0}", FirstName));
			builder.AppendLine(String.Format("Year service: {0}", YearService));
			builder.AppendLine(String.Format("Salary: {0}", Salary));
			return builder.ToString();
		}

		public void WriteToFile(string path)
		{
			using (var write = File.AppendText(path))
			{
				write.Write(this.ToString());
			}
		}
	}
}

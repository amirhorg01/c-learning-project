using System;
using System.Collections.Generic;

namespace final_project
{
    internal class Program
    {
        static Dictionary<string, Dictionary<string, string>> students = new Dictionary<string, Dictionary<string, string>>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("     WELCOME TO STUDENT MANAGEMENT");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add a student");
                Console.WriteLine("2. Show student list");
                Console.WriteLine("3. Delete a student");
                Console.WriteLine("4. Show single student details");
                Console.WriteLine("5. Update a student");
                Console.WriteLine("6. Clear all students");
                Console.WriteLine("7. Exit");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                    AddStudent();
                else if (choice == "2")
                    ShowAllStudents();
                else if (choice == "3")
                    DeleteStudent();
                else if (choice == "4")
                    ShowSingleStudent();
                else if (choice == "5")
                    UpdateStudent();
                else if (choice == "6")
                    ClearAll();
                else if (choice == "7")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option! Please try again.");
                }
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("\n--- Add New Student ---");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Card Number: ");
            string card = Console.ReadLine();

            Console.Write("National Code: ");
            string nationalCode = Console.ReadLine();

            Console.Write("Birth Year: ");
            string birthYear = Console.ReadLine();

            if (students.ContainsKey(nationalCode))
            {
                Console.WriteLine("This national code already exists!");
                return;
            }

            string formattedPhone = FormatPhoneNumber(phone);
            string bankName = GetBankName(card);
            string guid = Guid.NewGuid().ToString();
            int age = CalculateAge(birthYear);

            Dictionary<string, string> studentInfo = new Dictionary<string, string>();
            studentInfo.Add("FirstName", firstName);
            studentInfo.Add("LastName", lastName);
            studentInfo.Add("PhoneNumber", formattedPhone);
            studentInfo.Add("CardNumber", card);
            studentInfo.Add("NationalCode", nationalCode);
            studentInfo.Add("BirthYear", birthYear);
            studentInfo.Add("Age", age.ToString());
            studentInfo.Add("BankName", bankName);
            studentInfo.Add("GUID", guid);

            students.Add(nationalCode, studentInfo);

            Console.WriteLine($"Student added! Bank: {bankName}, Age: {age}");
        }

        static void ShowAllStudents()
        {
            Console.WriteLine("\n--- All Students ---");

            if (students.Count == 0)
            {
                Console.WriteLine("No students found!");
                return;
            }

            List<string> keys = new List<string>(students.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                Dictionary<string, string> s = students[keys[i]];
                Console.WriteLine($"{i + 1}. {s["FirstName"]} {s["LastName"]} - Phone: {s["PhoneNumber"]} - Bank: {s["BankName"]}");
            }
        }

        static void DeleteStudent()
        {
            Console.WriteLine("\n--- Delete Student ---");
            Console.Write("Enter National Code: ");
            string nationalCode = Console.ReadLine();

            if (students.Remove(nationalCode))
            {
                Console.WriteLine("Student deleted successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        static void ShowSingleStudent()
        {
            Console.WriteLine("\n--- Student Details ---");
            Console.Write("Enter National Code: ");
            string nationalCode = Console.ReadLine();

            if (students.ContainsKey(nationalCode))
            {
                Dictionary<string, string> s = students[nationalCode];
                Console.WriteLine("Student Details:");
                Console.WriteLine($"First Name: {s["FirstName"]}");
                Console.WriteLine($"Last Name: {s["LastName"]}");
                Console.WriteLine($"Phone: {s["PhoneNumber"]}");
                Console.WriteLine($"Card: {s["CardNumber"]}");
                Console.WriteLine($"National Code: {s["NationalCode"]}");
                Console.WriteLine($"Birth Year: {s["BirthYear"]}");
                Console.WriteLine($"Age: {s["Age"]}");
                Console.WriteLine($"Bank: {s["BankName"]}");
                Console.WriteLine($"GUID: {s["GUID"]}");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        static void UpdateStudent()
        {
            Console.WriteLine("\n--- Update Student ---");
            Console.Write("Enter National Code: ");
            string nationalCode = Console.ReadLine();

            if (!students.ContainsKey(nationalCode))
            {
                Console.WriteLine("Student not found!");
                return;
            }

            Dictionary<string, string> s = students[nationalCode];

            Console.WriteLine($"Current Name: {s["FirstName"]} {s["LastName"]}");
            Console.Write("New First Name (press Enter to keep): ");
            string newFirstName = Console.ReadLine();
            if (newFirstName != "")
                s["FirstName"] = newFirstName;

            Console.Write("New Last Name (press Enter to keep): ");
            string newLastName = Console.ReadLine();
            if (newLastName != "")
                s["LastName"] = newLastName;

            Console.Write("New Phone (press Enter to keep): ");
            string newPhone = Console.ReadLine();
            if (newPhone != "")
                s["PhoneNumber"] = FormatPhoneNumber(newPhone);

            Console.Write("New Card (press Enter to keep): ");
            string newCard = Console.ReadLine();
            if (newCard != "")
            {
                s["CardNumber"] = newCard;
                s["BankName"] = GetBankName(newCard);
            }

            Console.WriteLine("Student updated successfully!");
        }

        static void ClearAll()
        {
            Console.WriteLine("\n--- Clear All Students ---");
            Console.Write("Are you sure? (y/n): ");
            string confirm = Console.ReadLine();

            if (confirm == "y" || confirm == "yes")
            {
                students.Clear();
                Console.WriteLine("All students cleared!");
            }
            else
            {
                Console.WriteLine("cancelled.");
            }
        }

        static string FormatPhoneNumber(string phone)
        {
            phone = phone.Replace(" ", "").Replace("-", "").Replace("_", "");

            if (phone.StartsWith("+98"))
                phone = "0" + phone.Substring(3);
            else if (phone.StartsWith("0098"))
                phone = "0" + phone.Substring(4);
            else if (phone.StartsWith("98") && phone.Length == 11)
                phone = "0" + phone.Substring(2);

            return phone;
        }

        static string GetBankName(string cardNumber)
        {
            if (cardNumber.Length < 4)
                return "Unknown";

            string prefix = cardNumber.Substring(0, 4);

            if (prefix == "6037" || prefix == "5892" || prefix == "6104")
                return "Bank Mellat";
            else if (prefix == "6273" || prefix == "5028")
                return "Bank Tejarat";
            else if (prefix == "6276" || prefix == "6274")
                return "Bank Saderat";
            else if (prefix == "5022" || prefix == "6392")
                return "Bank Pasargad";
            else if (prefix == "6221" || prefix == "6036" || prefix == "6362" || prefix == "6280")
                return "Bank Melli";
            else if (prefix == "5058" || prefix == "6219" || prefix == "6289")
                return "Bank Saman";
            else if (prefix == "5047" || prefix == "5057" || prefix == "6062")
                return "Bank Ayandeh";
            else if (prefix == "5029" || prefix == "6270" || prefix == "6223")
                return "Bank Karafarin";
            else if (prefix == "5075" || prefix == "5851" || prefix == "6272")
                return "Bank Khavarmianeh";
            else if (prefix == "5079" || prefix == "5010" || prefix == "6217")
                return "Bank Parsian";
            else if (prefix == "6063" || prefix == "5025" || prefix == "6398")
                return "Bank Mehr";
            else if (prefix == "5067" || prefix == "5053" || prefix == "5046" || prefix == "5073" || prefix == "6100")
                return "Bank Resalat";
            else
                return "Unknown Bank";
        }

        static int CalculateAge(string birthYear)
        {
            if (!int.TryParse(birthYear, out int year))
                return 0;

            int currentYear = DateTime.Now.Year;

            if (year > 1400)
            {
                int gregorianYear = year + 621;
                if (gregorianYear > currentYear)
                    gregorianYear = currentYear;
                return currentYear - gregorianYear;
            }
            else
            {
                return currentYear - year;
            }
        }
    }
}
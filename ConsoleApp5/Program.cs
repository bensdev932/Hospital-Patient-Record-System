using System;
using System.Linq;

namespace HospitalPatientRecordSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] patientNames = { "John Martinez", "Sarah Chen", "Michael Johnson", "Lisa Garcia", "David Kim", "Maria Rodriguez", "James Johnson", "Emily Wilson" };
            int[] roomNumbers = { 101, 205, 312, 408, 119, 227, 315, 402 };
            int[] ages = { 45, 38, 67, 72, 29, 41, 55, 63 };
            string[] assignedDoctors = { "Dr. Smith", "Dr. Patel", "Dr. Brown", "Dr. Lee", "Dr. Garcia", "Dr. Wong", "Dr. Brown", "Dr. Taylor" };
            string[] medicalConditions = { "Hypertension", "Diabetes", "Pneumonia", "Arthritis", "Asthma", "Migraine", "Fracture", "Infection" };
            string[] patientIDs = { "MRN001", "MRN002", "MRN003", "MRN004", "MRN005", "MRN006", "MRN007", "MRN008" };
            string[] admissionDates = { "2024-01-15", "2024-01-20", "2024-02-03", "2024-02-10", "2024-02-15", "2024-02-18", "2024-02-22", "2024-03-01" };
            string[] treatmentStatus = { "Stable", "Improving", "Critical", "Stable", "Improving", "Stable", "Recovering", "Critical" };

            string searchName = string.Empty;
            bool validInput = false;

            // Input validation
            while (!validInput)
            {
                Console.Write("Enter patient's first name (or part of it): ");
                searchName = Console.ReadLine()?.Trim() ?? string.Empty;

                if (!string.IsNullOrEmpty(searchName)
                    && searchName.All(c => char.IsLetter(c) || c == ' ' || c == '.')
                    && searchName.Length >= 2)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter at least 2 letters.");
                }
            }

            bool found = false;
            int recordCount = 0;

            Console.WriteLine($"\n=== SEARCH RESULTS FOR \"{searchName}\" ===");

            for (int i = 0; i < patientNames.Length; i++)
            {
                // Extract first name only (everything before the first space)
                string firstName = patientNames[i].Split(' ')[0];

                // Check if input is contained in the first name (case-insensitive)
                if (firstName.Contains(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    recordCount++;

                    Console.WriteLine($"\n--- PATIENT RECORD #{recordCount} ---");
                    Console.WriteLine($"Name: {patientNames[i]}");
                    Console.WriteLine($"Age: {ages[i]}");
                    Console.WriteLine($"Room: {roomNumbers[i]}");
                    Console.WriteLine($"Attending Physician: {assignedDoctors[i]}");
                    Console.WriteLine($"Diagnosis: {medicalConditions[i]}");
                    Console.WriteLine($"Admission Date: {admissionDates[i]}");
                    Console.WriteLine($"Patient ID: {patientIDs[i]}");
                    Console.WriteLine($"Treatment Status: {treatmentStatus[i]}");
                }
            }

            if (!found)
            {
                Console.WriteLine($"Patient with first name containing \"{searchName}\" doesn't exist. Please reach out to admin staff.");
            }

            Console.WriteLine("\n=== END OF RESULTS ===");
        }
    }
}

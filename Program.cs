using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment_3
{

    public class Program
    {
        static void Main(string[] args)
        {
            //Define list of Class if Type Candidate to store each candidate information
            List<Candidate> listCandidate = new List<Candidate>();

            RegisteredCandidates(listCandidate);                            //Suppose 15 students registered in the program then call the function
            SelectedCandidates(listCandidate);                              //On the basis of Cgpa greater than 3 , Select 10 students
            ProjectMarks(listCandidate);                                    //Randomly assigned project marks to sutdents
            TopperCandidates(listCandidate);                                //Function returns the student list having collective marks greater than 90
            CityWiseSorting(listCandidate);                                 //Using Dictionary, display list of candidates of city 'Lahore' 
            TopperStudents(listCandidate);                                  //Students having marks greater than 90% sorted in Descending Order

            Console.ReadLine();
        }




        //Time Complexity for Task-1 is Big-O(15) = O(1)
        public static void RegisteredCandidates(List<Candidate> Candidates)
        {
    
            Console.WriteLine("                             Registered Students                                      ");


            //Hardcoded Data of Interested Candidates
            string[] Names = {"Ali","Usama","Ahmad","Ahmar","Noman",
                                     "Adam","Abir","Umair","Akmal","Ahsan",
                                     "Amir","Badar","Asad","Akram","Abdul" };
            double[] Cgpa = { 3.12,3.9,3.2,3.5,2.56,
                                    3.98,3.40,3.33,2.4,2.1,
                                    3.56,2.7,2.2,3.61,3.2};
            string[] City = {"Lahore","Rawalpindi","Lahore","Rawalpindi","Lahore",
                            "Lahore","Rawalpindi","Lahore","Rawalpindi","Lahore",
                            "Lahore","Rawalpindi","Lahore","Rawalpindi","Lahore",
                            };

            Random randomNumber = new Random();                                         // To generate random num, created an object
            Candidate candidateData = new Candidate();                                  // Object of class Candidate

            for (int i = 0; i < Names.Length; i++)                                      //Loop to enter each entry of candidate
            {
                candidateData = new Candidate();
                candidateData.firstName = Names[i];
                candidateData.cgpa = Cgpa[i];
                candidateData.contact = "0321-" + randomNumber.Next(1110001, 9999999);
                candidateData.city = City[i];
                Candidates.Add(candidateData);                                          //Adding all the information to the list

            }
            StudentsData(Candidates);                                                   //For better format and left alignment to dispaly data
            Console.WriteLine();
        }





        //Time Complexity for Task-2 is Big-O(15) = O(1)
        public static void SelectedCandidates(List<Candidate> Candidates)
        {
            Console.WriteLine("                             Short Listed                                      ");

            for (int j = 0; j < Candidates.Count; j++)                                  //If the Interested students fullfil the criteria 
            {                                                                           // of cgpa greater than 3.0 then Select them.
                if (Candidates[j].cgpa < 3.0)
                {
                    Candidates.RemoveAt(j);
                    j = j - 1;
                }
            }

            Console.WriteLine();
            StudentsData(Candidates);                                                   //For better format and left alignment to dispaly data
        }







        //Time Complexity for Task-3 is Big-O(10) = O(1)
        public static void ProjectMarks(List<Candidate> Candidates)
        {
            Console.WriteLine("                             Assigning Numbers                                      ");
            Random randomNumber = new Random();                                         // To generate random num, created an object

            for (int k = 0; k < Candidates.Count; k++)
            {
                Candidates[k].project1 = randomNumber.Next(80, 100);                    // Assign Random numbers of projects to each candidate
                Candidates[k].project2 = randomNumber.Next(80, 100);                    // 80-100 Range is selected for getting more students having marks greater than 90

            }
            Console.WriteLine();
            StudentsData(Candidates);                                                   //For better format and left alignment to dispaly data
        }







        //Time Complexity for Task-4 is Big-O(10) = O(1)
        public static void TopperCandidates(List<Candidate> Candidates)
        {
            Console.WriteLine("                             Topper Candidates                                      ");

            for (int k = 0; k < Candidates.Count; k++)
            {
                Candidates[k].collectiveMarks = ((Candidates[k].project1 + Candidates[k].project2) / 200) * 100;                //Collective Marks criteria
                if (Candidates[k].collectiveMarks > 90)                                                                         //Display those students having marks greater than 90
                {
                    Console.WriteLine(Candidates[k].firstName + "    " + Candidates[k].cgpa + "    " + Candidates[k].contact +
                        "   " + Candidates[k].city + "   " + Candidates[k].collectiveMarks);
                }
            }
            Console.WriteLine();
        }






        //Time Complexity for Task-5 is O(1)
        public static void CityWiseSorting(List<Candidate> Candidates)
        {
            Console.WriteLine("                             Candidates of Lahore                                      ");

            Dictionary<int, string> candidateCity = new Dictionary<int, string>();                                        //Declare a dictionary object
            for (int integer = 0; integer < Candidates.Count; integer++)                                                  //First of all add keys and values
            {                                                                                                             //For keys, store index values in order to access later the information of candidate
                candidateCity.Add(integer, Candidates[integer].city);                                                     //For values, store cities.
            }
            //candidateCity = candidateCity.Where(i => i.Value == "Lahore").ToDictionary(i => i.Key, i => i.Value);       //Another Method using Query
            //foreach (var key in candidateCity.Keys)
            //{
            //    //Console.WriteLine(key);
            //}
            foreach (KeyValuePair<int, string> kvp in candidateCity)
            {
                if (kvp.Value == "Lahore")                                                                          //In key pair value if Value equal to specific city
                {                                                                                                   //Then print the information of specific candidate
                    Console.WriteLine(Candidates[kvp.Key].firstName + "    " + Candidates[kvp.Key].cgpa
                        + "    " + Candidates[kvp.Key].contact +
                       "   " + Candidates[kvp.Key].city + "   " + Candidates[kvp.Key].collectiveMarks);
                }
            }
            Console.WriteLine();
        }






        //Time Complexity for Task-6 is Big-O(10) = O(1)
        public static void TopperStudents(List<Candidate> Candidates)
        {
            Console.WriteLine("                             Toppers Filterd                                      ");

            Candidates.Sort(delegate(Candidate x, Candidate y)                                  //Using delegate function that sorts the data in an ascending order
            {
                return x.collectiveMarks.CompareTo(y.collectiveMarks);                          //Compare the marks value of one candidate total marks to other candidates 
            }
            );
            for (int i = Candidates.Count - 1; i > 0; i--)
            {
                if (Candidates[i].collectiveMarks > 90)                                         //Candidates having marks greater than 90 and displaying in Descending Order 
                {
                    Console.WriteLine(Candidates[i].firstName + "    " + Candidates[i].cgpa + "    " + Candidates[i].contact +
                        "   " + "   " + Candidates[i].collectiveMarks);
                }
            }
            Console.WriteLine();
        }







        public static void StudentsData(List<Candidate> Candidates)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("First Name |    CGPA    |    Contact   |    City    | Project1   | Project2   | ");
            Console.WriteLine("-----------------------------------------------------------------------------------");

            for (int i = 0; i < Candidates.Count; i++)
            {
                Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | ", Candidates[i].firstName, Candidates[i].cgpa,
                    Candidates[i].contact, Candidates[i].city,Candidates[i].project1, Candidates[i].project2));
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine();
        }



    }
}

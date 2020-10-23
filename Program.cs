using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab8_GetToKnowYourClassmates
{
    class Program
    {
        const int offset = 1;
        static void Main(string[] args)
        {
            string searchMethod = "";
            string searchOrAdd = "";
            int userStudentChoice;
            bool continueLearning = true;
            List<StudentInfo> students = InitiateObjects();

            
            while (continueLearning)
            {
                searchOrAdd = ChooseSearchOrAdd();
                while (searchOrAdd == "add")
                {
                    AddStudent(students);
                    searchOrAdd = ChooseSearchOrAdd();
                }
                if (searchOrAdd == "search")
                {
                    searchMethod = ChooseSearchMethod();
                }

                if (searchMethod == "student number")
                {
                    userStudentChoice = ChooseStudentByNumber();
                }
                else
                {
                    userStudentChoice = ChooseStudentByName(students);
                }
                continueLearning = GetStudentInfo(userStudentChoice, students);
            }
            Console.WriteLine(Environment.NewLine + "Thanks for the interest! Bye!");
        }
        static List<StudentInfo> InitiateObjects()
        {
            List<StudentInfo> students = new List<StudentInfo>()
            {
                new StudentInfo("Bobby Bizon", "Black", "Westland, MI", "Mexican Food"),
                new StudentInfo("Freddy Krueger", "Brown", "Springwood, OH", "Dreams"),
                new StudentInfo("Hannibal Lecter", "Black", "Lithuania", "People"),
                new StudentInfo("Jason Voorhees", "Red", "Camp Crystal Lake", "Bugs"),
                new StudentInfo("Lauren Jensen", "Red", "Inkster, MI", "Pizza"),
                new StudentInfo("Leatherface", "Yellow", "Texas", "People"),
                new StudentInfo("Mario Brother", "Red", "World 01 Stage 01", "Mushrooms"),
                new StudentInfo("Nick Hickman", "Green", "Livonia, MI", "Steak"),
                new StudentInfo("Pinhead", "Grey", "Somewhere far away", "Souls"),
                new StudentInfo("Sonic The Hedgehog", "Blue", "Green Emerald Zone", "Chili dogs"),
                new StudentInfo("Stephen Jedlicki", "Purple", "Inkster, MI", "Wagyu")
            };
            return students;
        }
        static string ChooseSearchMethod()
        {
            string userInput;
            Console.Write("Welcome to our C# class. How would you like to search the students? (enter \"student name\" or \"student number\"): ");
            userInput = Console.ReadLine().Trim().ToLower();
            while (userInput.Length == 0 || !(userInput == "student name" || userInput == "student number"))
            {
                Console.Write($"If you want to search , you must (enter \"student name\" or \"student number\"): ");
                userInput = Console.ReadLine().Trim().ToLower();
            }
            return userInput;
        }
        static int ChooseStudentByNumber()
        {
            int userStudentChoice = 0;
            bool validInput = false;

            Console.Write("Which student would you like to learn about? (enter a number 1-11): ");
            while (!validInput)
            {
                try
                {
                    userStudentChoice = int.Parse(Console.ReadLine()) - offset;
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.Write("You must enter a NUMBER from 1-11, please try again: ");
                }
            }
            return userStudentChoice;
        }
        static int ChooseStudentByName(List<StudentInfo> students)
        {
            string studentName;
            string[] studentNames = new string[students.Count];

            Console.Write("Which student would you like to learn about? (choose a student from the list): ");
            // had to divide by 4 because its an array of [11,4] so the length is 44 and I want to iterate 11 times for the name


            for (int i = 0; i < students.Count; i++)
            {
                Console.Write(students[i].Name.Split()[0]);
                studentNames[i] = students[i].Name.Split()[0].ToLower();
                if (i < (students.Count) - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(": ");
                }
            }
            studentName = Console.ReadLine().Trim().ToLower();
            while (!(studentNames.Contains(studentName)))
            {
                Console.Write("You must enter a name from the list above: ");
                studentName = Console.ReadLine().Trim().ToLower();
            }
            for (int i = 0; i < studentNames.Length; i++)
            {
                if (studentNames[i] == studentName)
                {
                    return i;
                }
            }
            // will never pass this point but IDE was complaining
            return 0;
        }
        static string ValidateUserInfoChoice(string userInfoChoice, string studentFirstName)
        {
            while (userInfoChoice.Length == 0 || !(userInfoChoice == "hometown" || userInfoChoice == "favorite food" || userInfoChoice == "favorite color" || userInfoChoice == "quit"))
            {
                Console.Write($"If you want to know more about {studentFirstName}, you must (enter \"hometown\", \"favorite food\" or \"favorite color\"): ");
                userInfoChoice = Console.ReadLine().Trim().ToLower();
            }
            return userInfoChoice;
        }
        static bool EnterYesOrNo(string userInput)
        {
            bool continueLearning = true;
            bool invalidInput = true;
            if (userInput == "no")
            {
                continueLearning = false;
            }
            else if (!(userInput == "yes"))
            {
                do
                {
                    Console.Write("Please enter \"yes\" or \"no\": ");
                    userInput = Console.ReadLine().Trim().ToLower();
                    if (!(userInput == "yes" || userInput == "no"))
                    {
                        invalidInput = true;
                    }
                    else if (userInput == "yes")
                    {
                        invalidInput = false;
                        continueLearning = true;
                    }
                    else if (userInput == "no")
                    {
                        invalidInput = false;
                        continueLearning = false;
                    }
                } while (invalidInput);
            }
            return continueLearning;
        }
        static bool GetStudentInfo(int studentIndex, List<StudentInfo> students)
        {
            string userInfoChoice, studentFirstName, userInput, favFood, favColor;
            string studentName = "";
            bool validInput = false;
            bool continueLearning = true;

            while (!validInput)
            {
                // this makes it so that setting up a valid range checker is not necessary due to entering a value out of range cycles back to the catch statement
                try
                {
                    studentName = students[studentIndex].Name;
                    validInput = true;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Write("You must enter a number FROM 1-11, please try again: ");
                    studentIndex = int.Parse(Console.ReadLine()) - offset;
                }
            }

            studentFirstName = studentName.Split()[0];

            Console.Write($"Student {studentIndex + offset} is {studentName}. What would you like to know about {studentFirstName} (enter \"hometown\", \"favorite food\" or \"favorite color\"): ");
            userInfoChoice = Console.ReadLine().Trim().ToLower();
            userInfoChoice = ValidateUserInfoChoice(userInfoChoice, studentFirstName);



            if (userInfoChoice == "hometown")
            {

                string hometown = students[studentIndex].Hometown;
                Console.Write($"{students[studentIndex].Name} is from {hometown}. Would you like to continue? (enter \"yes\" or \"no\"): ");
                userInput = Console.ReadLine().Trim().ToLower();
                continueLearning = EnterYesOrNo(userInput);

            }
            else if (userInfoChoice == "favorite food")
            {
                favFood = students[studentIndex].FavoriteFood;
                Console.Write($"{students[studentIndex].Name}'s favorite food is {favFood}. Would you like to continue? (enter \"yes\" or \"no\"): ");
                userInput = Console.ReadLine().Trim().ToLower();

                continueLearning = EnterYesOrNo(userInput);
            }
            else if (userInfoChoice == "favorite color")
            {
                favColor = students[studentIndex].FavoriteColor;
                Console.Write($"{students[studentIndex].Name}'s favorite color is {favColor}. Would you like to continue? (enter \"yes\" or \"no\"): ");
                userInput = Console.ReadLine().Trim().ToLower();

                continueLearning = EnterYesOrNo(userInput);
            }
            else
            {
                Console.WriteLine("YOU WILL NEVER SEE ME");
            }

            return continueLearning;
        }
        static string ChooseSearchOrAdd()
        {
            bool continueLearning = true;
            bool invalidInput = true;
            string userInput;

            Console.Write("Would you like to search students or add a student? (enter \"search\" or \"add\"): ");
            userInput = Console.ReadLine().Trim().ToLower();

            if (userInput == "search")
            {
                return "search";
            }
            else if (!(userInput == "add"))
            {
                do
                {
                    Console.Write("Please enter \"search\" or \"add\": ");
                    userInput = Console.ReadLine().Trim().ToLower();
                    if (!(userInput == "search" || userInput == "add"))
                    {
                        invalidInput = true;
                    }
                    else if (userInput == "search")
                    {
                        return "search";
                    }
                    else if (userInput == "add")
                    {
                        return "add";
                    }
                } while (invalidInput);
            } 
            return "add";
        }
        static void AddStudent(List<StudentInfo> students)
        {
            string name, color, hometown, food;
            int indexAddPosition = 0;
            do
            {
                Console.Write("Please enter the students name: ");
                name = Console.ReadLine();
            } while (name.Length == 0);

            do
            {
                Console.Write("Please enter the students favorite color: ");
                color = Console.ReadLine(); 
            } while (color.Length == 0);
            do
            {
                Console.Write("Please enter the students hometown: ");
                hometown = Console.ReadLine(); 
            } while (hometown.Length == 0);
            do
            {
                Console.Write("Please enter the students favorite food: ");
                food = Console.ReadLine(); 
            } while (food.Length == 0);
            for (int i = 0; i <= students.Count; i++)
            {
                char firstLetterAdding;
                char firstLetterList;
                indexAddPosition = students.Count - offset;
                // gets the first character of the name being added and the first character of each student name in the list and compares to determine index to insert new student
                // reason for the try catch, if you enter a student that would be added at the end of the list, you would reach an ArgumentOutOfRangeException, if you reach this the student should be added to the end of the list.
                try
                {
                    firstLetterAdding = name.Substring(0).ToLower().ToString().ToCharArray()[0];
                    firstLetterList = students[i].Name.ToLower()[0].ToString().ToCharArray()[0];
                }
                catch (ArgumentOutOfRangeException)
                {
                    indexAddPosition = i;
                    students.Insert(i, new StudentInfo(name, color, hometown, food));
                    break;
                }
                // comparing the start characters, if the firstLetterList is greater than firstLetterAdding it means that the letter comes after EX: firstLetterList = C firstLetterAdding = A
                if(firstLetterList >= firstLetterAdding)
                {
                    indexAddPosition = i;
                    students.Insert(i, new StudentInfo(name, color, hometown, food));
                    break;
                }
            }
            Console.WriteLine($"The student {students[indexAddPosition].Name} has been added to the student list. {Environment.NewLine}");
        }
    }
}

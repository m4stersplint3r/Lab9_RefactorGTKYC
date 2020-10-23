using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8_GetToKnowYourClassmates
{
    class StudentInfo
    {
        private string name;
        private string favoriteColor;
        private string hometown;
        private string favoriteFood;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string FavoriteColor
        {
            get { return favoriteColor; }
            set { favoriteColor = value; }
        }
        public string Hometown
        {
            get { return hometown; }
            set { hometown = value; }
        }
        public string FavoriteFood
        {
            get { return favoriteFood; }
            set { favoriteFood = value; }
        }
        public StudentInfo(string Name, string FavoriteColor, string Hometown, string FavoriteFood)
        {
            name = Name;
            favoriteColor = FavoriteColor;
            hometown = Hometown;
            favoriteFood = FavoriteFood;
        }
        public void PrintStudentInfo()
        {
            Console.WriteLine($"{Name} comes from {Hometown}, loves eating {FavoriteFood} and their favorite color is {FavoriteColor}");
        }
    }
}

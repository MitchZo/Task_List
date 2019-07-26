using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone2
{
    public class Validator
    {
        #region
        //fields
        private bool isValid;

        //property
        public bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
            }
        }

        //constructor
        public Validator()
        {

        }
        #endregion
        //methods
        public static bool Double(string input)
        {
            return double.TryParse(input, out double variable);
        }
        public static bool YesNo(string input)
        {
            input.ToLower();
            if (input == "yes" || input == "y" || input == "no" || input == "n")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Int(string input)
        {
            return int.TryParse(input, out int variable);
        }
        public static bool IsInRange(int input, int min, int max)
        {
            if (input >= min && input >= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsDateTime(string userInput)
        {
            bool isValid = false;
            string month = "";
            string day = "";
            string year = "";
            //try to split into MM DD and YYYY
            string[] dateArray = userInput.Split('/');
            //validate that each string that comprises the array is an int
            if (dateArray.Length == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Validator.Int(dateArray[i]))
                    {
                        isValid = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (isValid)
                {
                    month = dateArray[0];
                    day = dateArray[1];
                    year = dateArray[2];
                }
                if (Validator.Int(day) && Validator.Int(month) && Validator.Int(year))
                {
                    if (day.Length == 2 && month.Length == 2 && year.Length == 4)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

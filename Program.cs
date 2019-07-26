using System;
using System.Collections.Generic;

namespace Capstone2
{
    class Program
    {
        static void Main(string[] args)
        {
        //create a blank list of tasks for the user to populate
        List<Task> taskList = new List<Task>();
            //create a method for "are you sure? y/n"
            Navigate(taskList);
        }
        public static void Navigate(List<Task> taskList)
        {
            //define variables to be used later
            string response = "";
            bool isValid = false;


            //set the loop to get input from the user to determine where they want to go
            while (!isValid)
            {
                //display the menu
                Console.Clear();
                Console.WriteLine("1. List tasks");
                Console.WriteLine("2. Add task");
                Console.WriteLine("3. Edit task");
                Console.WriteLine("4. Delete task");
                Console.WriteLine("5. Mark task complete");
                Console.WriteLine("6. Quit\n");
                Console.WriteLine("The Task Master Manager by MitchCo -copyright 2019-");

                //take in user selection
                response = GetUserInput("Please select an option by number.");

                //validate it's an int
                isValid = Validator.Int(response);
            }
            //once we know that the user has given us a valid option, use that option to call the appropriate method.
            switch (int.Parse(response))
            {
                case
                    1:
                    ListTasks(taskList);
                    break;
                case
                    2:
                    AddTask(taskList);
                    break;
                case
                    3:
                    EditTask(taskList);
                    break;
                case
                    4:
                    DeleteTask(taskList);
                    break;
                case
                    5:
                    MarkTaskComplete(taskList);
                    break;
                case
                    6:
                    Environment.Exit(6);
                    break;

            }
        }
        public static string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        public static void ListTasks(List<Task> taskList)
        {
            Console.Clear();
            int counter = 1;
            foreach (Task task in taskList)
            {
                string taskStatus = "";
                if (task.IsComplete == true) { taskStatus = "Complete"; }
                else { taskStatus = "Incomplete"; }
                Console.WriteLine($"{counter}.\t{task.Description}\n\tfor: {task.TeamMember}\n\tDue on: {task.DueDate.ToString()}\n\tstatus: {taskStatus}\n");
                counter++;
            }
        }
        public static List<Task> AddTask(List<Task> taskList)
        {
            bool runAgain = true;
            while (runAgain)
            {
                //declare variables to be used later on
                string response = "";
                int dueDateDay = 0;
                int dueDateMonth = 0;
                int dueDateYear = 0;
                string dueDateString = "";
                bool isValid = false;
                DateTime dueDate = new DateTime(1900, 1, 1);

                //create a new blank task
                Task newTask = new Task("", "", dueDate);
                //add the new blank task to the list of tasks
                taskList.Add(newTask);
                Console.Clear();
                //have the user set who the task is for and a brief description
                newTask.TeamMember = GetUserInput("Who is this task for?");
                newTask.Description = GetUserInput("Please provide a brief description of this task");
                isValid = false;
                while (!isValid)
                {
                    //get Due Date from the user
                    dueDateString = GetUserInput("enter a due date for this task. Use a 2 digit month, 2 digit day, and 4 digit year (MM/DD/YYYY)");
                    isValid = Validator.IsDateTime(dueDateString);
                }

                string[] dateArray = dueDateString.Split('/');
                dueDateMonth = int.Parse(dateArray[0]);
                dueDateDay = int.Parse(dateArray[1]);
                dueDateYear = int.Parse(dateArray[2]);
                newTask.DueDate = new DateTime(dueDateYear, dueDateMonth, dueDateDay);

                isValid = false;
                while (!isValid)
                {
                    response = GetUserInput("would you like to add another task?");
                    isValid = Validator.YesNo(response);
                }
                if (response == "yes" || response == "y")
                {
                    runAgain = true;
                }
                else
                {
                    runAgain = false;
                }
            }
            Console.Clear();
            Navigate(taskList);
            return taskList;
        }
        public static List<Task> EditTask(List<Task> taskList)
        {
            GetUserInput("Which task would you like to edit?");
            return taskList;
        }
        public static List<Task> DeleteTask(List<Task> taskList)
        {
            return taskList;
        }
        public static List<Task> MarkTaskComplete(List<Task> taskList)
        {
            return taskList;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Capstone2
{
    class Program
    {
        static void Main(string[] args)
        {
            //define variables to be used later
            string response = "";
            bool isValid = false;
    
            //create a blank list of tasks for the user to populate
            List<Task> taskList = new List<Task>();

            //set the loop to get input from the user to determine where they want to go
            while (!isValid)
            {
                //show the options for the user
                DisplayMainMenu();

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
                    System.Environment.Exit(6);
                    break;

            }

            //Done - display a list of options for the user to select.
            //Done - create a class which is a task.
            //Done - each task will have a property of team member, description, due date, completion status, and completion date  
            //Done - create an empty list of tasks for the user to populate.
            //Done - create filter methods in the Task class to filter by team member, or due date
            //create a method for each of the options listed
            //create a method for "are you sure? y/n"
        }
        public static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. List tasks");
            Console.WriteLine("2. Add task");
            Console.WriteLine("3. Edit task");
            Console.WriteLine("4. Delete task");
            Console.WriteLine("5. Mark task complete");
            Console.WriteLine("6. Quit\n");
            Console.WriteLine("The Task Master Manager by MitchCo -copyright 2019-");
        }
        public static string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        public static void ListTasks(List<Task> taskList)
        {
            int counter = 0;
            foreach (Task task in taskList)
            {
                Console.WriteLine($"{counter}. {task}");
                counter++;
            }
        }
        public static List<Task> AddTask(List<Task> taskList)
        {
            //declare variables to be used later on
            string dueDateDay = "";
            string dueDateMonth = "";
            string dueDateYear = "";
            bool isValid = false;
            DateTime dueDate = new DateTime(1900,1,1);

            //create a new blank task
            Task newTask = new Task("", "", dueDate);
            //add the new blank task to the list of tasks
            taskList.Add(newTask);
            //have the user set who the task is for and a brief description
            newTask.TeamMember = GetUserInput("Who is this task for?");
            newTask.Description = GetUserInput("Please provide a brief description of this task");
            isValid = false;
            while (!isValid)
            {
                //get input from the user
                string dueDateString = GetUserInput("enter a due date for this task. Use a 2 digit month, 2 digit day, and 4 digit year (MM/DD/YYYY)");
  

                    isValid = Validator.IsDateTime(dueDateDay, dueDateMonth, dueDateYear);

            }

            newTask.DueDate = new DateTime(int.Parse(dueDateMonth), int.Parse(dueDateDay), int.Parse(dueDateYear));

            return taskList;
        }
        public static List<Task> EditTask(List<Task> taskList)
        {
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
        public static DateTime ConvertToDateTime(int day, int month, int year)
        {

        }
    }
}

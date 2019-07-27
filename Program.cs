using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone2
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a blank list of tasks for the user to populate
            List<Task> taskList = new List<Task>();
            Task task1 = new Task();
            task1.TeamMember = "delete me";
            task1.Description = "delete this task";
            task1.CompletionDate = DateTime.Now;
            taskList.Add(task1);
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
            if (taskList.Count == 0)
            {
                NoTasks(taskList);
            }
            int counter = 1;
            foreach (Task task in taskList)
            {
                string taskStatus = "";
                if (task.IsComplete == true) { taskStatus = "Complete"; }
                else { taskStatus = "Incomplete"; }
                Console.WriteLine($"{counter}.\t{task.Description}\n\tfor: {task.TeamMember}\n\tDue on: {task.DueDate.Date.ToString().Substring(0,10)}\n\tstatus: {taskStatus}\n");
                counter++;
            }
            Console.WriteLine("press any key to return to the main menu.");
            Console.ReadKey();
            Navigate(taskList);
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
                DateTime dueDate = new DateTime(1900, 1, 1).Date;

                //create a new blank task
                Task newTask = new Task("", "", dueDate.Date);
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
                newTask.DueDate = new DateTime(dueDateYear, dueDateMonth, dueDateDay).Date;

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
            string response = "";
            bool isValid = false;
            //verify there are tasks to edit
            if (taskList.Count == 0)
            {
                Console.Clear();
                NoTasks(taskList);
            }
            //ask which task the user would like to edit
            while (!isValid)
            {
                Console.Clear();
                //the counter will keep track of the menu choice and act as the navigation selection
                int counter = 1;
                //write out each task description and an option for the user to choose
                foreach(Task task in taskList)
                {
                    Console.WriteLine($"{counter}. {task.Description}");
                    counter++;
                    Console.WriteLine();
                }
                response = GetUserInput("Which task would you like to edit?");
                //verify the user has input a number. if they haven't, ask again.
                isValid = Validator.Int(response);
                //verify the number the user input is within range of the available tasks
                if (isValid)
                {
                    Validator.IsInRange(int.Parse(response), 1, taskList.Count);
                }
            }
            //parse the response into an int
            int menuSelection = int.Parse(response);
            //the active task is set as the working variable
            Task selectedTask = taskList[menuSelection - 1];
            isValid = false;
            //ask the user which portion of the task they want to edit.
            while (!isValid)
            {
                Console.Clear();
                response = GetUserInput("what would you like to edit?\n1. Who the task is assigned to\n2. Description of the task\n3. DueDate of the task");
                isValid = Validator.Int(response);
                if (isValid)
                {
                    isValid = Validator.IsInRange(int.Parse(response), 1, taskList.Count);
                }
            }
            switch (int.Parse(response))
            {
                case
                    1:
                    Console.Clear();
                    selectedTask.TeamMember = GetUserInput("Who should this task be reassigned to?");
                    break;
                case
                    2:
                    selectedTask.Description = GetUserInput("What description would you prefer?");
                    break;
                case
                    3:
                    isValid = false;
                    while (!isValid)
                    {
                        response = GetUserInput("What would you like the due date changed to? Please format with 2 digit month, 2 digit day, 4 digit year. (MM/DD/YYYY)");
                        isValid = Validator.IsDateTime(response);
                    }
                    string[] dateArray = response.Split('/');
                    int dueDateMonth = int.Parse(dateArray[0]);
                    int dueDateDay = int.Parse(dateArray[1]);
                    int dueDateYear = int.Parse(dateArray[2]);
                    selectedTask.DueDate = new DateTime(dueDateYear, dueDateMonth, dueDateDay).Date;
                    break;
            }

            Navigate(taskList);
            return taskList;
        }
        public static List<Task> DeleteTask(List<Task> taskList)
        {
            //verify there are tasks to edit
            if (taskList.Count == 0)
            {
                Console.Clear();
                NoTasks(taskList);
            }

            return taskList;
        }
        public static List<Task> MarkTaskComplete(List<Task> taskList)
        {
            //verify there are tasks to edit
            if (taskList.Count == 0)
            {
                Console.Clear();
                NoTasks(taskList);
            }

            return taskList;
        }
        public static void NoTasks(List<Task> taskList)
        {
            Console.WriteLine("No tasks to display. press any key to go back to the main menu.");
            Console.ReadKey();
            Navigate(taskList);
        }
    }
}

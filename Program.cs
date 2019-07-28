using System;
using System.Collections.Generic;
using System.Linq;
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
            task1.DueDate = DateTime.Now;
            taskList.Add(task1);
            Task task2 = new Task();
            task2.TeamMember = "ted";
            task2.Description = "no";
            task2.DueDate = DateTime.Now;
            taskList.Add(task2);
            Task task3 = new Task();
            task3.TeamMember = "ted";
            task3.Description = "no";
            task3.DueDate = DateTime.Now;
            taskList.Add(task3);
            Task task4 = new Task();
            task4.TeamMember = "phil";
            task4.Description = "no";
            task4.DueDate = DateTime.Now;
            taskList.Add(task4);
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
                if (isValid)
                {
                    isValid = Validator.IsInRange(int.Parse(response), 1, 6);
                }
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
            List<Task> filteredTaskList = new List<Task>();
            string response = "";
            bool isValid = false;
            int counter = 1;
            while (!isValid)
            {
                Console.Clear();
                if (taskList.Count == 0)
                {
                    NoTasks(taskList);
                }
                Console.WriteLine($"1. Filter by Name\n2. Filter by Due Date\n3. All Tasks\n");

                response = GetUserInput("Would you like to narrow your results by Name, Due Date, or get the full list of tasks?");
                isValid = Validator.Int(response);
                if (isValid)
                {
                    isValid = Validator.IsInRange(int.Parse(response), 1, 3);
                }
            }
            if (int.Parse(response) == 1)
            {
                List<string> teamMembers = new List<string>();
                string teamMemberList = "";
                isValid = false;
                Console.Clear();

                foreach (Task task in taskList)
                {
                    if (!teamMembers.Contains(task.TeamMember))
                    {
                        teamMembers.Add(task.TeamMember);
                    }
                }
                foreach (string teamMember in teamMembers)
                {
                    teamMemberList = teamMemberList + teamMember + ", ";
                }
                while (!isValid)
                {
                    Console.Clear();
                    Console.WriteLine("Which name you would like to filter by?");
                    Console.WriteLine(teamMemberList.Remove(teamMemberList.Length - 2));
                    response = Console.ReadLine();

                    bool matchFound = false;
                    //check to see if the user's input matches a team member.
                    for (int i = 0; i < teamMembers.Count; i++)
                    {
                        if (response.ToLower() != teamMembers[i].ToLower() && !matchFound)
                        {
                            isValid = false;
                        }
                        else
                        {
                            isValid = true;
                            matchFound = true;
                        }
                    }
                }
                filteredTaskList = taskList;
                counter = 1;
                foreach (Task task in filteredTaskList)
                {
                    if (task.TeamMember.ToLower() == response)
                    {
                        string taskStatus = "";
                        if (task.IsComplete == true) { taskStatus = "Complete"; }
                        else { taskStatus = "Incomplete"; }
                        Console.WriteLine($"{counter}.\t{task.Description}\n\tfor: {task.TeamMember}\n\tDue on: {task.DueDate.Date.ToString().Substring(0, 10)}\n\tstatus: {taskStatus}\n");
                        counter++;
                    }
                }
                Console.WriteLine("press any key to return to the main menu.");
                Console.ReadKey();
                Navigate(taskList);
            }
            if (int.Parse(response) == 2)
            {

                Console.WriteLine("press any key to return to the main menu.");
                Console.ReadKey();
                Navigate(taskList);
            }
            if (int.Parse(response) == 3)
            {
                counter = 1;
                foreach (Task task in taskList)
                {
                    string taskStatus = "";
                    if (task.IsComplete == true) { taskStatus = "Complete"; }
                    else { taskStatus = "Incomplete"; }
                    Console.WriteLine($"{counter}.\t{task.Description}\n\tfor: {task.TeamMember}\n\tDue on: {task.DueDate.Date.ToString().Substring(0, 10)}\n\tstatus: {taskStatus}\n");
                    counter++;
                }
                Console.WriteLine("press any key to return to the main menu.");
                Console.ReadKey();
                Navigate(taskList);
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
                foreach (Task task in taskList)
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
                    isValid = Validator.IsInRange(int.Parse(response), 1, taskList.Count);
                }
            }
            //parse the response into an int
            int menuSelection = int.Parse(response);
            //the active task is set as the working variable
            Task selectedTask = taskList[menuSelection - 1];
            isValid = false;
            bool keepGoing = true;
            while (keepGoing)
            {
                isValid = false;
                //ask the user which portion of the task they want to edit.
                while (!isValid)
                {
                    Console.Clear();
                    response = GetUserInput("what would you like to edit?\n1. Who the task is assigned to\n2. Description of the task\n3. DueDate of the task\n4. exit");
                    isValid = Validator.Int(response);
                    if (isValid)
                    {
                        isValid = Validator.IsInRange(int.Parse(response), 1, 4);
                    }
                }
                switch (int.Parse(response))
                {
                    case
                        1:
                        isValid = false;
                        while (!isValid)
                        {
                            Console.Clear();
                            selectedTask.TeamMember = GetUserInput("Who should this task be reassigned to?");
                            if (selectedTask.TeamMember == "")
                            {
                                isValid = false;
                            }
                            else
                            {
                                isValid = true;
                            }
                        }
                        break;
                    case
                        2:
                        isValid = false;
                        while (!isValid)
                        {
                            Console.Clear();
                            selectedTask.Description = GetUserInput("What description would you prefer?");
                            if (selectedTask.Description == "")
                            {
                                isValid = false;
                            }
                            else
                            {
                                isValid = true;
                            }
                        }
                        break;
                    case
                        3:
                        isValid = false;
                        while (!isValid)
                        {
                            Console.Clear();
                            response = GetUserInput("What would you like the due date changed to? Please format with 2 digit month, 2 digit day, 4 digit year. (MM/DD/YYYY)");
                            isValid = Validator.IsDateTime(response);
                        }
                        string[] dateArray = response.Split('/');
                        int dueDateMonth = int.Parse(dateArray[0]);
                        int dueDateDay = int.Parse(dateArray[1]);
                        int dueDateYear = int.Parse(dateArray[2]);
                        selectedTask.DueDate = new DateTime(dueDateYear, dueDateMonth, dueDateDay).Date;
                        break;
                    case
                        4:
                        keepGoing = false;
                        break;
                }
            }
            Navigate(taskList);
            return taskList;
        }
        public static List<Task> DeleteTask(List<Task> taskList)
        {
            string response = "";
            bool isValid = false;
            //verify there are tasks to edit
            if (taskList.Count == 0)
            {
                Console.Clear();
                NoTasks(taskList);
            }
            while (!isValid)
            {
                Console.Clear();
                int counter = 1;
                //write out each task description and an option for the user to choose
                foreach (Task task in taskList)
                {
                    Console.WriteLine($"{counter}. {task.Description}");
                    counter++;
                    Console.WriteLine();
                }
                response = GetUserInput("Which task would you like to delete?");
                //verify the user has input a number. if they haven't, ask again.
                isValid = Validator.Int(response);
                //verify the number the user input is within range of the available tasks
                if (isValid)
                {
                    isValid = Validator.IsInRange(int.Parse(response), 1, taskList.Count);
                }
            }
            //parse the response into an int
            int menuSelection = int.Parse(response);

            Task selectedTask = taskList[menuSelection - 1];
            string completionStatus = "";
            isValid = false;
            while (!isValid)
            {
                Console.Clear();
                if (selectedTask.IsComplete == true)
                {
                    completionStatus = "Complete";
                }
                else
                {
                    completionStatus = "Incomplete";
                }
                Console.WriteLine($"Type YES in all caps if you are sure you want to delete this task. It cannot be undone.\n\nDescription: {selectedTask.Description}\nFor: {selectedTask.TeamMember}\nDue on: {selectedTask.DueDate}\nStatus: {completionStatus}");
                if (selectedTask.IsComplete == true)
                {
                    Console.WriteLine($"Completed on: {selectedTask.CompletionDate}");
                }
                response = Console.ReadLine();
                isValid = Validator.YesNo(response);
            }
            if (response == "YES")
            {
                Console.WriteLine("Task removed. Press any key to return to the main menu.");
                taskList.RemoveAt(menuSelection - 1);
                Console.ReadKey();
                Navigate(taskList);
            }
            else
            {
                Console.WriteLine("Task has NOT been removed. Press any key to return to the main menu.");
                Console.ReadKey();
                Navigate(taskList);
            }
            return taskList;
        }
        public static List<Task> MarkTaskComplete(List<Task> taskList)
        {
            bool isValid = false;
            string response = "";
            //verify there are tasks to edit
            if (taskList.Count == 0)
            {
                Console.Clear();
                NoTasks(taskList);
            }
            while (!isValid)
            {
                Console.Clear();
                int counter = 1;
                //write out each task description and an option for the user to choose
                foreach (Task task in taskList)
                {
                    Console.WriteLine($"{counter}. {task.Description}");
                    counter++;
                    Console.WriteLine();
                }
                response = GetUserInput("Which task would you like to mark as complete?");
                //verify the user has input a number. if they haven't, ask again.
                isValid = Validator.Int(response);
                //verify the number the user input is within range of the available tasks
                if (isValid)
                {
                    isValid = Validator.IsInRange(int.Parse(response), 1, taskList.Count);
                }
            }
            //parse the response into an int
            int menuSelection = int.Parse(response);

            Task selectedTask = taskList[menuSelection - 1];

            selectedTask.IsComplete = true;
            selectedTask.CompletionDate = DateTime.Now;

            Console.WriteLine($"{selectedTask.Description} complete with a completion date of {DateTime.Now.ToString().Substring(0, 10)}\nPress any key to return to the main menu.");
            Console.ReadKey();
            Navigate(taskList);
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

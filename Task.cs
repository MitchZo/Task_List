using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone2
{
    public class Task
    {
        //each task will have a property of team member, description, 
        //due date, completion status, and completion date  
        private string teamMember;
        private string description;
        private DateTime dueDate;
        private bool isComplete;
        private DateTime completionDate;

        public string TeamMember
        {
            get
            {
                return teamMember;
            }
            set
            {
                teamMember = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }
        public bool IsComplete
        {
            get
            {
                return isComplete;
            }
            set
            {
                isComplete = value;
            }
        }
        public DateTime CompletionDate
        {
            get
            {
                return completionDate;
            }
            set
            {
                completionDate = value;
            }
        }

        public Task()
        {
            isComplete = false;
        }
        public Task(string _teamMember, string _description, DateTime _dueDate)
        {
            teamMember = _teamMember;
            description = _description;
            dueDate = _dueDate.Date;
            isComplete = false;
        }

        public List<Task>FilterTaskListByName(string filterName, List<Task> taskList)
        {
            //take in the name of the person to filter by
            //loop over the tasks in the list and remove any tasks that are for anyone other than the person being searched for
            //return the pruned list of tasks
            foreach (Task task in taskList)
            {
                if (task.teamMember != filterName)
                {
                    taskList.Remove(task);
                }
            }
            return taskList;
        }
        public List<Task>FilerTaskListByDueDate(DateTime filterDate, List<Task> taskList)
        //take in the date to filter by
        //loop over the tasks in the list and remove any tasks that have a due date later than what's entered
        //return the pruned list of tasks
        {
            foreach (Task task in taskList)
            {
                if (task.dueDate > filterDate || task.IsComplete == true)
                {
                    taskList.Remove(task);
                }
            }
            return taskList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TaskManager_Shashin.Classes;

namespace TaskManager_Shashin.ViewModels
{
    public class VM_Tasks : Notification
    {
        public Context.TasksContext tasksContext = new Context.TasksContext();
        public ObservableCollection<Models.Tasks> Tasks { get; set; }
        public VM_Tasks()
        {
            Tasks = new ObservableCollection<Models.Tasks>(tasksContext.Tasks.OrderBy(x => x.Done));
        }
        public TaskManager_Shashin.Classes.RealyCommand OnAddTask
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Models.Tasks NewTask = new Models.Tasks()
                    {
                        DateExecute = DateTime.Now
                    };
                    Tasks.Add(NewTask);
                    tasksContext.Tasks.Add(NewTask);
                    tasksContext.SaveChanges();
                });
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FileExplorer.Model;

namespace FileExplorer.Services
{
    internal interface ITaskBarService
    {
        void AddTaskItem(TaskBarItem item);
        void DeleteTaskItem(Window window);
        ObservableCollection<TaskBarItem> GeTaskBarItems();
    }

    internal class TaskBarService : ITaskBarService
    {
        private ObservableCollection<TaskBarItem> TaskItemCollection { get; set; }
        public void AddTaskItem(TaskBarItem item)
        {
            TaskItemCollection.Add(item);
        }

        public void DeleteTaskItem(Window window)
        {
            TaskBarItem closedItem = TaskItemCollection.FirstOrDefault(x => x.Window == window);
            TaskItemCollection.Remove(closedItem);
        }

        public ObservableCollection<TaskBarItem> GeTaskBarItems()
        {
            return TaskItemCollection;
        }

        public TaskBarService()
        {
            TaskItemCollection = new ObservableCollection<TaskBarItem>();
        }

      
    }
}

using Snowfall.Entity;
using System.ComponentModel;

namespace Snowfall.Service.ActionWithTasks
{
    public class TaskProcessing
    {
        public void RemoveWhiteSpace(BindingList<TaskBody> listOfTasks)
        {
            for (int i = listOfTasks.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(listOfTasks[i].Task))
                {
                    listOfTasks.RemoveAt(i);
                }
            }
        }

        public BindingList<TaskBody> OrderByFalse(BindingList<TaskBody> listOfTasks)
        {
            var filteredTasks = listOfTasks.Where(b => b.Status == false).ToList();
            BindingList<TaskBody> category = new BindingList<TaskBody>(filteredTasks);
            return category;
        }

        public BindingList<TaskBody> OrderByTrue(BindingList<TaskBody> listOfTasks)
        {
            var filteredTasks = listOfTasks.Where(b => b.Status == true).ToList();
            BindingList<TaskBody> category = new BindingList<TaskBody>(filteredTasks);
            return category;
        }
        public BindingList<TaskBody> FilterTasks(BindingList<TaskBody> listOfTasks)
        {
            var filteredTasks = listOfTasks.Where(b => b.IsDeleted == false).ToList();
            listOfTasks = new BindingList<TaskBody>(filteredTasks);
            return listOfTasks;
        }
    }
}

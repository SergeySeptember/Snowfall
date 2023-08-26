using Snowfall.Entity;
using System.ComponentModel;

namespace Snowfall.Service.ActionWithTasks
{
    public class IOTasks
    {
        private GoogleHelper _googleHelper;
        private TaskProcessing _taskProcessing = new();

        private BindingList<TaskBody> listOfTasksJSON;
        private BindingList<TaskBody> listOfTasksGDrive;

        public IOTasks(GoogleHelper googleHelper)
        {
            _googleHelper = googleHelper;
        }

        public void GetTasksFromGDrive()
        {
            int countOfRawOnGDrive = _googleHelper.GetCountOfTasks();
            if (countOfRawOnGDrive != 0)
            {
                listOfTasksGDrive = _googleHelper.GetTasks(cellName: $"A{1}", cellName2: $"G{countOfRawOnGDrive}");
            }
            else
            {
                listOfTasksGDrive = new BindingList<TaskBody> { new TaskBody { IsDeleted = true } };
            }
        }
        public BindingList<TaskBody> GetTasksFromJson()
        {
            listOfTasksJSON = FileIOService.LoadTasksFromJson();
            return listOfTasksJSON;
        }

        public BindingList<TaskBody> LoadAndSortTasks()
        {
            GetTasksFromGDrive();
            GetTasksFromJson();

            int countOfRawJson = listOfTasksJSON.Count;
            int countOfRawGDrive = listOfTasksGDrive.Count;
            int minCount = Math.Min(countOfRawJson, countOfRawGDrive);
            BindingList<TaskBody> listOfTasks = new();

            for (int i = 0; i < minCount; i++)
            {
                var time1 = DateTime.Parse(listOfTasksJSON[i].TimeUpdate);
                var time2 = DateTime.Parse(listOfTasksGDrive[i].TimeUpdate);

                if (time1 > time2)
                {
                    listOfTasks.Add(listOfTasksJSON[i]);
                }
                else
                {
                    listOfTasks.Add(listOfTasksGDrive[i]);
                }
            }

            for (int i = minCount; i < countOfRawJson; i++)
            {
                listOfTasks.Add(listOfTasksJSON[i]);
            }

            for (int i = minCount; i < countOfRawGDrive; i++)
            {
                listOfTasks.Add(listOfTasksGDrive[i]);
            }

            FileIOService.SaveTaskToJson(listOfTasks);

            listOfTasks = _taskProcessing.FilterTasks(listOfTasks);

            return listOfTasks;
        }

        public void SaveCellEdit(bool successConnect, int index, BindingList<TaskBody> listOfTasks)
        {

            if (listOfTasks.Count > index && !string.IsNullOrWhiteSpace(listOfTasks[index].Task))
            {
                listOfTasks[index].TimeUpdate = DateTime.Now.ToString();

                if (successConnect)
                {
                    int lineNumber = index + 1;

                    _googleHelper.SetTasks(
                        cellName1: $"A{lineNumber}", cellName2: $"G{lineNumber}", listOfTasks[index].Id.ToString(), listOfTasks[index].Task,
                        listOfTasks[index].Status.ToString(), listOfTasks[index].Category,
                        listOfTasks[index].Time, listOfTasks[index].TimeUpdate, listOfTasks[index].IsDeleted.ToString());
                }

                FileIOService.SaveTaskToJson(listOfTasks);
            }
        }

        public void SaveCellEditByCategory(bool successConnect, int index, BindingList<TaskBody> category, BindingList<TaskBody> listOfTasks)
        {
            if (category.Count > index && !string.IsNullOrWhiteSpace(category[index].Task))
            {
                string searchId = category[index].Id;
                int generalIndex = 0;

                for (int i = 0; i < listOfTasks.Count; i++)
                {
                    if (listOfTasks[i].Id == searchId)
                    {
                        generalIndex = i;
                        break;
                    }
                }

                bool tempFlag = false;

                for (int i = 0; i < listOfTasks.Count; i++)
                {
                    if (category[index].Id == listOfTasks[i].Id)
                    {
                        tempFlag = true;
                    }
                }

                if (tempFlag)
                {
                    listOfTasks[generalIndex].TimeUpdate = DateTime.Now.ToString();

                    if (successConnect)
                    {
                        int lineNumber = generalIndex + 1;

                        _googleHelper.SetTasks(
                            cellName1: $"A{lineNumber}", cellName2: $"G{lineNumber}", listOfTasks[generalIndex].Id.ToString(),
                            listOfTasks[generalIndex].Task, listOfTasks[generalIndex].Status.ToString(), listOfTasks[generalIndex].Category,
                            listOfTasks[generalIndex].Time, listOfTasks[generalIndex].TimeUpdate, listOfTasks[generalIndex].IsDeleted.ToString());
                    }

                    FileIOService.SaveTaskToJson(listOfTasks);
                }
                else
                {
                    TaskBody addedBody = new TaskBody()
                    {
                        Task = category[index].Task,
                        Status = category[index].Status,
                        Category = category[index].Category,
                    };

                    listOfTasks.Add(addedBody);

                    if (successConnect)
                    {
                        int lineNumber = listOfTasks.Count;
                        int indexOfTask = listOfTasks.Count - 1;

                        _googleHelper.SetTasks(
                            cellName1: $"A{lineNumber}", cellName2: $"G{lineNumber}", listOfTasks[indexOfTask].Id.ToString(),
                            listOfTasks[indexOfTask].Task, listOfTasks[indexOfTask].Status.ToString(), listOfTasks[indexOfTask].Category,
                            listOfTasks[indexOfTask].Time, listOfTasks[indexOfTask].TimeUpdate, listOfTasks[indexOfTask].IsDeleted.ToString());
                    }

                    FileIOService.SaveTaskToJson(listOfTasks);
                }
            }
        }

        public BindingList<TaskBody> DeleteTaskInCategory(int index, BindingList<TaskBody> listOfTasks, BindingList<TaskBody> category, bool successConnect, bool categorySortByTrue)
        {
            string searchId = category[index].Id;
            int generalIndex = 0;

            for (int i = 0; i < listOfTasks.Count; i++)
            {
                if (listOfTasks[i].Id == searchId)
                {
                    generalIndex = i;
                    break;
                }
            }

            listOfTasks[generalIndex].IsDeleted = true;
            listOfTasks[generalIndex].TimeUpdate = DateTime.Now.ToString();

            if (successConnect)
            {
                int lineNumber = generalIndex + 1;

                _googleHelper.SetTasks(
                    cellName1: $"A{lineNumber}", cellName2: $"G{lineNumber}", listOfTasks[generalIndex].Id.ToString(), listOfTasks[generalIndex].Task,
                    listOfTasks[generalIndex].Status.ToString(), listOfTasks[generalIndex].Category,
                    listOfTasks[generalIndex].Time, listOfTasks[generalIndex].TimeUpdate, listOfTasks[generalIndex].IsDeleted.ToString());
            }

            FileIOService.SaveTaskToJson(listOfTasks);

            listOfTasks = _taskProcessing.FilterTasks(listOfTasks);
            if (categorySortByTrue)
            {
                return _taskProcessing.OrderByTrue(listOfTasks);
            }
            else
            {
                return _taskProcessing.OrderByFalse(listOfTasks);
            }
        }

        public BindingList<TaskBody> DeleteTask(int index, BindingList<TaskBody> listOfTasks, bool successConnect)
        {
            listOfTasks[index].IsDeleted = true;
            listOfTasks[index].TimeUpdate = DateTime.Now.ToString();

            if (successConnect)
            {
                int lineNumber = index + 1;

                _googleHelper.SetTasks(
                    cellName1: $"A{lineNumber}", cellName2: $"G{lineNumber}", listOfTasks[index].Id.ToString(), listOfTasks[index].Task,
                    listOfTasks[index].Status.ToString(), listOfTasks[index].Category,
                    listOfTasks[index].Time, listOfTasks[index].TimeUpdate, listOfTasks[index].IsDeleted.ToString());
            }

            FileIOService.SaveTaskToJson(listOfTasks);

            return _taskProcessing.FilterTasks(listOfTasks);
        }

    }
}

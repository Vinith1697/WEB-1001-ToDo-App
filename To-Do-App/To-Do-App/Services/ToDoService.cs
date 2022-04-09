/*
 * Service class to manage the TODO model;
 */




using System;
using System.Collections.Generic;
using To_Do_App.Model;

namespace To_Do_App.Services
{
    public class ToDoService
    {
        List<ToDoModel> ToDoList = new();
        List<ToDoModel> RemToDoList = new();

        //Get list of rem todos
        public List<ToDoModel> GetUncompleteToDos()
        {
            return RemToDoList;
        }

        //Add a new todo to the list
        public List<ToDoModel> AddToDo(ToDoModel model)
        {
            ToDoList.Add(model);
            return ToDoList;
        }

        //Replace a todo
        public void AddToDoAt(ToDoModel model, int index)
        {
            ToDoList.RemoveAt(index);
            ToDoList.Insert(index, model);
        }

        //Remove a todo
        public List<ToDoModel> RemoveToDo(int id)
        {
            int ItemIndex = 0;

            for (int i = 0; i < ToDoList.Count; i++)
            {
                if (ToDoList[i].Id == id)
                {
                    ItemIndex = i;
                }
            }

            ToDoList.RemoveAt(index: ItemIndex);
            return ToDoList;
        }

        //Mark a todo as completed
        public List<ToDoModel> MarkAsDone(ToDoModel model)
        {
            model.IsDone = true;
            model.CompletionDate = DateTime.Now;
            int index = RemToDoList.FindIndex(m => m.Id == model.Id);
            RemToDoList.RemoveAt(index);

            return RemToDoList;
        }

        //Constructor with 3 default todos
        public ToDoService()
        {
            //Sample tasks
            ToDoList.Add(new ToDoModel { Id = 1, Task = "Cook dinner", Descrip = "Scrambled Eggs and chicken poulet", IsDone = false });
            ToDoList.Add(new ToDoModel { Id = 2, Task = "Watch lecture recording", Descrip = "Friday 12 pm lecture", IsDone = false });
            

            RemToDoList = ToDoList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParallelLibraryDemo
{
    class DifferentWaysToCreateTasks
    {
        public static void DifferentWaysToCreateTasksMethod()
        {
            //Option 1
            //Create a Task using an inline Funciton
            Task<List<int>> taskWithInLineAction = new Task<List<int>>(() => 
            {
                List<int> listInt = new List<int>();
                for(int i = 0; i< 10; i++)
                {
                    listInt.Add(i);
                }
                return listInt;
            });

            //Option 2
            //Create a Task that calls an actual method and returns a string
            Func<object,string> func = new Func<object,string>(PrintTaskObjectState);
            Task<string> taskWithActualMethodState = new Task<string>(func,"This is Task state, could be any Object");


            //Option 3
            //Craete a Task that return List<int> using Task.Factory, 
            //Task Factory will create the task and will start the task immediately after creation
            Task<List<int>> taskWithFactoryAndState = Task.Factory.StartNew((stateObj) => 
            {
                List<int> listInt = new List<int>();
                for (int i = 0; i < (int) stateObj; i++)
                {
                    listInt.Add(i);
                }   
                return listInt;
            },2000);


            //Start all the Tasks
            taskWithInLineAction.Start();
            taskWithActualMethodState.Start();

            //not possible, system will throw exception
            //taskWithFactoryAndState.Start();  //Cannot call start on completed tasks


            Task[] allTasks = new Task[]
            {
                taskWithInLineAction,
                taskWithActualMethodState,
                taskWithFactoryAndState
            };

            //wait for all task to complete the tasks
            Task.WaitAll(allTasks);


            //Collect all the result from all 3 task and subsequectly print them
            var taskWithInLineActionResult = taskWithInLineAction.Result;
            var taskWithActualMethodStateResult = taskWithActualMethodState.Result;
            var taskWithFactoryAndStateResult = taskWithFactoryAndState.Result;

            //Disposing the task once the operation is complete
            Console.WriteLine(string.Format("The Task with Inline Action<T> "+ "returned a type of {0}, with {1} items",
                taskWithInLineActionResult.GetType(), 
                taskWithInLineActionResult.Count));
            taskWithInLineAction.Dispose();

            Console.WriteLine(string.Format("The Task with Method call " + "returned a type of {0}", 
                taskWithActualMethodStateResult.GetType()));
            taskWithActualMethodState.Dispose();

            Console.WriteLine(string.Format("The Task with Tast.Factory.StarNew<list<int>> " + "returned a type of {0}, with {1} items", 
                taskWithFactoryAndStateResult.GetType(), 
                taskWithFactoryAndStateResult.Count));
            taskWithFactoryAndState.Dispose();

        }

        private static string PrintTaskObjectState(object obj)
        {
            Console.WriteLine(obj.ToString());
            return "#####SOMEJUNKVALUE####";
        }
    }
}

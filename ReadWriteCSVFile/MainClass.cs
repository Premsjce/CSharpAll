using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReadWriteCSVFile
{
    class MainClass
    {
        static void Main(string[] args)
        {
            StreamReader strmReader = new StreamReader(@"D:\Prem\Personel\C#\Code\SoloLearn\ReadWriteCSVFile\inventory.txt");
            string linea = strmReader.ReadLine();

            string[] allLine = File.ReadAllLines(@"D:\Prem\Personel\C#\Code\SoloLearn\ReadWriteCSVFile\inventory.txt");
            List<InventoryModel> inventoryModel = new List<InventoryModel>();
            InventoryModel model;


            while (linea != null)
            {
                //Console.WriteLine(linea);
                model = new InventoryModel();
                string[] item = linea.Split(',');
                model.Category = item[0].Trim();
                model.Name = item[1].Trim();
                model.CostPerUnit = float.Parse(item[2]);
                model.AvailableQty = int.Parse(item[3]);
                inventoryModel.Add(model);
                linea = strmReader.ReadLine();
            }
            strmReader.Close();

            //Adding a new item to inventory
            InventoryModel modelEdited = new InventoryModel();
            modelEdited.Category = "pizza";
            modelEdited.Name = "baecon";
            modelEdited.CostPerUnit = 0.25f;
            modelEdited.AvailableQty = 500;

            inventoryModel.Add(modelEdited);

            //InventoryModel invModelSearch = inventoryModel.Find(x => x.Name == "pineapple");

            //if (invModelSearch != null)
            //{
            //    Console.WriteLine("We found the {0} of {1} category with cost of {2}", invModelSearch.Name, invModelSearch.Category, invModelSearch.CostPerUnit.ToString());
            //}
            //else
            //{
            //    Console.WriteLine("Hard luck.; try again");
            //}


            StreamWriter strmWriter = new StreamWriter(@"D:\Prem\Personel\C#\Code\SoloLearn\ReadWriteCSVFile\inventory.txt");

            foreach (InventoryModel invMod in inventoryModel)
            {
                var cat = invMod.Category;
                var name = invMod.Name;
                var cost = invMod.CostPerUnit.ToString();
                var available = invMod.AvailableQty.ToString();
                var line = string.Format("{0}, {1}, {2}, {3}", cat, name, cost, available);
                strmWriter.WriteLine(line);
            }

            strmWriter.Close();
        }

        //static Predicate<InventoryModel> byNameAndCategory(InventoryModel match)
        //{
        //    return delegate (InventoryModel model)
        //    {
        //        return model.Name == "dough" && model.Category == "pizza" && model.AvailableQty == 0.50f;
        //    };
        //}
    }

    public class InventoryModel
    {
        public string Category { get; set; }

        public string Name { get; set; }

        public float CostPerUnit { get; set; }

        public int AvailableQty { get; set; }
    }
}

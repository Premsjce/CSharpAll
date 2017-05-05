namespace AlgoZ
{
    class SelectionSort
    {
        public static int[] Sort(int[] inputs)
        {
            System.Console.WriteLine("Before Soring");
            for (int k = 0; k < inputs.Length; k++)
            {
                System.Console.Write(" " + inputs[k]);
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("During Sorting");
            
            int counter = 0;
            int minIndex = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = counter; j < inputs.Length - 1; j++)
                {
                    if (inputs[minIndex] > inputs[j + 1])
                    {
                        minIndex = j+1;
                    }
                }
                int tempNum = inputs[counter];
                inputs[counter] = inputs[minIndex];
                inputs[minIndex] = tempNum;
                counter++;
                minIndex = counter;

                
                for(int k =0; k< inputs.Length; k++)
                {
                    System.Console.Write(" "+ inputs[k]);
                }
                System.Console.WriteLine(); ;

            }

            return inputs;
        }
    }
}

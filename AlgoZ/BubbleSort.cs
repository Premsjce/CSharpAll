using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoZ
{
    class BubbleSort
    {
        public static int[] Sort(int[] inputs)
        {
            for(int i = 0; i < inputs.Length; i++)
            {
                for (int j = i+1; j < inputs.Length; j++)
                {
                    if(inputs[i] > inputs[j])
                    {
                        int tempNum = inputs[j];
                        inputs[j] = inputs[i];
                        inputs[i] = tempNum;
                    }
                }
            }

            return inputs;
            
        }
    }
}

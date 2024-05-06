using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject
{
    internal class Program
    {
        public static void Main()
        {
            int[] arr = new int[] {-1,0,-1};
            Console.WriteLine(IsSpecial(arr));
            Console.ReadLine();
        }
        static public bool IsSpecial(int[] arr)
        {
            int count = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == -1) count++;
            }
            if (count == 0) return true;
            int[] maxes = new int[count + 1];
            int k = 0;
            int j = 0;
            for(int i = 0; i < maxes.Length; i++)
            {
                int nextMin = NextMin(arr, j);
                if (!IsValid(arr, maxes, j, (nextMin == -1 ? arr.Length: nextMin),k)) return false;
                int currMax = FindMax(arr,j - 1, (nextMin == -1 ? arr.Length : nextMin));
                if (currMax != -1) maxes[k++] = currMax;
                j = nextMin + 1;
            }
            return true;
        }
        static public int NextMin(int[] arr, int initial)
        {
            for(int i = initial; i < arr.Length; i++)
            {
                if(arr[i] == -1) return i;
            }
            return -1;
        }
        static public bool IsValid(int[] arr, int[]maxes,int first,int last,int k)
        {
            
            for(int i = 0; i < k; i++)
            {
                bool LastGood = false;
                for (int j = first; j < last; j++)
                {
                    if (arr[j] == maxes[i])
                    {
                        LastGood = true;
                        break;
                    }
                }
                if(!LastGood) return false;

            }
            return true;
        }
        static public int FindMax(int[] arr,int first,int last)
        {
            if(first == -1) first = 0;
            int max = arr[first];
            for(int i = first; i < last; i++)
            {
                if (max < arr[i]) max = arr[i];
            }
            return max;
        }
        
    }
   
}

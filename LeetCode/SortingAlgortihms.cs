using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SortingAlgortihms
    {
        public void MergeSort(ref int[] arr)
        {
            int l = 0, r = arr.Length - 1;
            mergeSort(ref arr, l, r);
        }

        private void mergeSort(ref int[] arr, int l, int r)
        {
            if (l < r)
            {
                int middle = (l + r) / 2;
                mergeSort(ref arr, l, middle);
                mergeSort(ref arr, middle + 1, r);
                merge(ref arr, l, middle, r);
            }
        }

        private void merge(ref int[] arr, int low, int middle, int high)
        {
            int left = low, right = middle +1;
            int[] tmp = new int[high-low+1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (arr[left] < arr[right])
                {
                    tmp[tmpIndex] = arr[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = arr[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            while (left <= middle)
            {
                tmp[tmpIndex] = arr[left];
                left = left + 1;
                tmpIndex = tmpIndex + 1;
            }

            while (right <= high)
            {
                tmp[tmpIndex] = arr[right];
                right = right + 1;
                tmpIndex = tmpIndex + 1;
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                arr[low + i] = tmp[i];
            }
        }
    }
}

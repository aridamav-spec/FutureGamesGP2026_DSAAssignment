using Environment;
using System;
using UnityEngine;

[Serializable]
public class Sorting
{
  /*  public static void Selectionsorting(Employee[] arrayToSort) {
        for(int i = 0; i < arrayToSort.Length - 1; i++) {
            int minIndex = i;
            for(int j = i + 1; j < arrayToSort.Length; j++) {
                if(arrayToSort[j].employeeId < arrayToSort[minIndex].employeeId) {
                    minIndex = j;
                }
            }
            Employee temp = arrayToSort[minIndex];
            arrayToSort[minIndex] = arrayToSort[i];
            arrayToSort[i] = temp;
        }
    } */
    public static void mergeSort(Employee[] arrayToSort, int left, int right) {
        if(left < right) {
            int mid = (left + right) / 2;
            mergeSort(arrayToSort, left, mid);
            mergeSort(arrayToSort, mid + 1, right);
            merge(arrayToSort, left, mid, right);
        }
    }
    public static void merge(Employee[] arrayToSort, int left, int mid, int right) {
        int leftSize = mid - left + 1;
        int rightSize = right - mid;
        Employee[] leftArray = new Employee[leftSize];
        Employee[] rightArray = new Employee[rightSize];
        Array.Copy(arrayToSort, left, leftArray, 0, leftSize);
        Array.Copy(arrayToSort, mid + 1, rightArray, 0, rightSize);
        int i = 0;
        int j = 0;
        int k = left;
        while(i < leftSize && j < rightSize) {
            if(leftArray[i].employeeId <= rightArray[j].employeeId) {
                arrayToSort[k] = leftArray[i];
                i++;
            }
            else {
                arrayToSort[k] = rightArray[j];
                j++;
            }
            k++;
        }
        while(i < leftSize) {
            arrayToSort[k] = leftArray[i];
            i++;
            k++;
        }
        while(j < rightSize) {
            arrayToSort[k] = rightArray[j];
            j++;
            k++;
        }
    }
}

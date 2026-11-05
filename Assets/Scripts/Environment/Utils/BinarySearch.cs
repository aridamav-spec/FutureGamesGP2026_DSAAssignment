using System;
using Environment;
using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    public static int Search(Employee[] employees, DateTime targetTime) {
        int left = 0;
        int right = employees.Length - 1;
        while(left <= right) {
            int mid = left + (right - left) / 2;
            if(employees[mid].entranceTime == targetTime) {
                return mid;
            }
            else if(employees[mid].entranceTime < targetTime) {
                left = mid + 1;
            }
            else {
                right = mid - 1;
            }
        }
        return -1;
    }
}

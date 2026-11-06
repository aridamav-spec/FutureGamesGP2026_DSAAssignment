using System;
using UnityEngine;
namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Search Task", menuName = "Search Task")]
    public class SearchTask : Task {
        [SerializeField]
        private TextAsset EmployeeJson = null;
        DateTime topOfRange;
        DateTime bottomOfRange;
        public override void Execute() {

            Employee[] employees = JsonUtility.FromJson<EmployeeArray>(EmployeeJson.text).employees;

            Sorting.mergeSort(employees, 0, employees.Length - 1);
            bottomOfRange = employees[0].entranceTime;
            topOfRange = employees[2].entranceTime;

            int low = BinarySearch.Search(employees, bottomOfRange);
            int high = BinarySearch.Search(employees, topOfRange);
            for(int i = low; i <= high; i++) {
                Debug.Log(employees[i].name);
                Debug.Log(employees[i].lastEntranceInEngineRoom);
            }
        }
    }
}

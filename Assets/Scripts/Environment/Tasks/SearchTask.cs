using System;
using UnityEngine;
namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Search Task", menuName = "Search Task")]
    public class SearchTask : Task {
        [SerializeField]
        private TextAsset EmployeeJson = null;
        public override void Execute() {

            Employee[] employees = JsonUtility.FromJson<EmployeeArray>(EmployeeJson.text).employees;
            DateTime topOfRange = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime bottomOfRange = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            foreach(Employee employee in employees) {
                employee.dtconvert();
            }
            Sorting.mergeSort(employees, 0, employees.Length - 1);

            int low = BinarySearch.Search(employees, bottomOfRange);
            int high = BinarySearch.Search(employees, topOfRange);
            for(int i = low; i < high; i++) {
                Debug.Log(employees[i].name);
                Debug.Log(employees[i].lastEntranceInEngineRoom);
            }
        }
    }
}

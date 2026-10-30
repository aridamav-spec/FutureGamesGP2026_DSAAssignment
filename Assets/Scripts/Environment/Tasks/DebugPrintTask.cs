using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "DebugPrint Task", menuName = "DebugPrint Task")]
    public class DebugPrintTask : Task {
        [SerializeField]
        public int activetasknumD;
        [SerializeField]
        public TextAsset employeeJson;
        Stopwatch stopwatch;
        public override void Execute() {
            Employee[] employees = JsonUtility.FromJson<EmployeeArray>(employeeJson.text).employees;
            foreach(Employee employee in employees) {
                employee.dtconvert();
            }
            string name = employees[activetasknumD].name;
            int ID = employees[activetasknumD].employeeId;
            bool clearance = employees[activetasknumD].hasEngineRoomClearance;
        //    stopwatch.Start();
            Sorting.mergeSort(employees, 0, employees.Length - 1);
        //    stopwatch.Stop();
        //    Debug.Log($"Sorted in: {stopwatch.Elapsed.TotalMilliseconds}");
            Debug.Log(name);
            Debug.Log(ID);
            Debug.Log(clearance);
            Debug.Log(employees[activetasknumD].lastEntranceInEngineRoom);
            Debug.Log(employees[activetasknumD].lastExitFromEngineRoom);
        }
    }
}

using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "DebugPrint Task", menuName = "DebugPrint Task")]
    public class DebugPrintTask : Task {
        [SerializeField]
        public int activetasknumD;
        [SerializeField]
        public TextAsset employeeJson;
        public override void Execute() {
            Employee[] employees = JsonUtility.FromJson<EmployeeArray>(employeeJson.text).employees;
            Sorting.mergeSort(employees, 0, employees.Length - 1);
            Debug.Log(employees[activetasknumD].name);
            Debug.Log(employees[activetasknumD].employeeId);
            Debug.Log(employees[activetasknumD].hasEngineRoomClearance);
            Debug.Log(employees[activetasknumD].lastEntranceInEngineRoom);
            Debug.Log(employees[activetasknumD].lastExitFromEngineRoom);
        }
    }
}

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
        [SerializeField]
        private string textToPrint = "Hi, I'm a test task!";
        public override void Execute() {
        //    Debug.Log(textToPrint);
            Employee[] employees = JsonUtility.FromJson<EmployeeArray>(employeeJson.text).employees;
            Debug.Log(employees[activetasknumD].name);
            Debug.Log(employees[activetasknumD].employeeId);
            Debug.Log(employees[activetasknumD].hasEngineRoomClearance);
            Debug.Log(employees[activetasknumD].lastEntranceInEngineRoom);
            Debug.Log(employees[activetasknumD].lastExitFromEngineRoom);
        }
    }
}

using Environment.Tasks;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Task = Environment.Tasks.Task;

namespace Environment {
    [Serializable]
    public class Employee {
        public string name;
        public int employeeId;
        public bool hasEngineRoomClearance;
        public string lastEntranceInEngineRoom;
        public string lastExitFromEngineRoom;
    }

    [Serializable]
    public class EmployeeArray {
        public Employee[] employees;
    }
    public class Computer : MonoBehaviour, IInteractable {
   //     public static int activetasknum = 0;
        [SerializeField]
        public List<Task> tasks = new List<Task>();
        public Task activetask;
        private GenericQueue<Task> taskqueue = new GenericQueue<Task>();
        private void Start()
        {
       //     activetasknum = 0;
            taskqueue.Enqueue(tasks.ElementAt(0));
            taskqueue.Enqueue(tasks.ElementAt(1));
            taskqueue.Enqueue(tasks.ElementAt(2));
        }
        private void Awake()
        {
            GenericQueue<int> _queue = new GenericQueue<int>();
            _queue.Enqueue(1);
            int dequeuedInt = _queue.Dequeue();

            GenericQueue<bool> _boolQueue = new GenericQueue<bool>();
            _boolQueue.Enqueue(true);
            _boolQueue.Enqueue(false);
            bool dequeuedBool = _boolQueue.Dequeue();
        }

        [SerializeField]
        private TextAsset EmployeeJson = null;
        public void OnInteract()
        {
            activetask = taskqueue.BringToTop();
            activetask.Execute();
            taskqueue.Dequeue();
        //    activetasknum++;

            if(EmployeeJson != null) {
                return;
            }

            Employee[] employees = JsonUtility.FromJson<EmployeeArray>(EmployeeJson.text).employees;

            if (employees != null && employees.Length > 0) {
                return;
            }

            foreach(Employee employee in employees) {
                Debug.Log("Name: " + employee.name);
                Debug.Log("Employee ID: " + employee.employeeId);
                Debug.Log("Has Engine Room Clearance: " + employee.hasEngineRoomClearance);
                Debug.Log("Last Entrance in Engine Room: " + employee.lastEntranceInEngineRoom);
                Debug.Log("Last Exit from Engine Room: " + employee.lastExitFromEngineRoom);
            } 
        }
    }
}

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
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        public List<Task> tasks = new List<Task>();
        public Task activetask;
        private GenericQueue<Task> taskqueue = new GenericQueue<Task>();
        private void Start()
        {
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

        public void OnInteract()
        {
            activetask = taskqueue.BringToTop();
            activetask.Execute();
            taskqueue.Dequeue();
        }
    }
}

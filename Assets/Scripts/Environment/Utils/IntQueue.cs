using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Environment.Tasks
{
    [Serializable]
    public class GenericQueue<T> {
        private List<T> queue;
        public GenericQueue()
        {
            queue = new List<T>();
        }
        public void Enqueue(T InNewElement) {
            queue.Add(InNewElement);
        }
        public T Peek()
        {
            if(queue.Count == 0)
            {
                throw new Exception("Queue is empty");
            }
            return queue[0];
        }
        public T Dequeue() {
            if(queue.Count == 0) {
                throw new Exception("Queue is empty");
            }
            T topOfQueue = queue[0];
            queue.RemoveAt(0);
            return topOfQueue;
        }
        public T BringToTop()
        {
            if (queue.Count == 0)
            {
                throw new Exception("Queue is empty, nothing to bring");
            }
            T topOfQueue = queue[0];
            return topOfQueue;
        }
        public void Clear() {
            queue.Clear();
        }
    }
}

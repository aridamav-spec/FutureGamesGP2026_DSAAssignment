using Environment.Tasks;
using UnityEngine;
using Utils;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private Task testTask = null; // Put your stack/queue here :)

        private void Awake() {
            GenericQueue<int> _queue = new GenericQueue<int>();
            _queue.Enqueue(1);
            int dequeuedInt = _queue.Dequeue();

            GenericQueue<bool> _boolQueue = new GenericQueue<bool>();
            _boolQueue.Enqueue(true);
            _boolQueue.Enqueue(false);
            bool dequeuedBool = _boolQueue.Dequeue();
        }

        public void OnInteract() {
            testTask.Execute();
        }
    }
}

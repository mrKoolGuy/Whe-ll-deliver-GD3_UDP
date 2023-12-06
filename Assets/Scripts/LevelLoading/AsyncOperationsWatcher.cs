using System;
using System.Collections.Generic;
using UnityEngine;

namespace GD
{
    //With this class it is possible to execute an Action as soon as a set of AsyncOperations is completed.
    //Usage:
    // - pass the action the should be called on completion in the constructor
    // - for every AsyncOperation you want to watch:
    //      - add it to the pending async operations: asyncOperationsWatcher.AddAsyncToPending(asyncOperation);
    //      - setup completed callback: asyncOperation.completed += MarkAsyncCompleted;
    public class AsyncOperationsWatcher
    {
        //this set contains one AsyncOperation for every Scene that is not loaded yet.
        private readonly HashSet<AsyncOperation> pendingAsyncs = new();

        private Action onAllAsyncsCompleted;

        public AsyncOperationsWatcher(Action onAllAsyncsCompleted)
        {
            this.onAllAsyncsCompleted = onAllAsyncsCompleted;
        }

        public void AddAsyncToPending(AsyncOperation asyncOperation)
        {
            pendingAsyncs.Add(asyncOperation);
        }
        
        //This function removes every AsyncOperation passed to it from the pendingAsyncs set.
        //after removal of the last AsyncOperation, all pending async operations are finished.
        //This will then call the onAllAsyncsCompleted action.
        public void MarkAsyncCompleted(AsyncOperation asyncOperation)
        {
            pendingAsyncs.Remove(asyncOperation);
            if (pendingAsyncs.Count == 0)
                onAllAsyncsCompleted();
        }
    }
}
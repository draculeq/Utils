using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Deadbit.Utils
{
    public interface IBusySet<T>
    {
        bool HasAny { get; }
        bool HasFree { get; }
        bool HasBusy { get; }
        int AllCount { get; }
        int BusyCount { get; }
        int FreeCount { get; }
        IReadOnlyCollection<T> All { get; }
        IReadOnlyCollection<T> AllBusy { get; }
        IReadOnlyCollection<T> AllFree { get; }

        bool TryGetFree(out T entity);
        bool TryGetBusy(out T entity);
        void SetFree(T entity);
        void SetBusy(T entity);
        void AddNewFree(T entity);
        void AddNewBusy(T entity);
        void RemoveFree(T entity);
        void RemoveBusy(T entity);
    }

    public abstract class BusySet<T> : IBusySet<T>
    {
        public bool HasAny => All.Any();
        public bool HasFree => AllFree.Any();
        public bool HasBusy => AllBusy.Any();
        public int AllCount => All.Count;
        public int BusyCount => AllBusy.Count;
        public int FreeCount => AllFree.Count;
        private IList<T> all = new List<T>();
        public IReadOnlyCollection<T> All { get; }
        public abstract IReadOnlyCollection<T> AllBusy { get; }
        public abstract IReadOnlyCollection<T> AllFree { get; }

        public abstract bool TryGetFree(out T entity);
        public abstract bool TryGetBusy(out T entity);
        protected abstract void AddToFreeCollection(T entity);
        protected abstract void AddToBusyCollection(T entity);
        protected abstract void RemoveFromFreeCollection(T entity);
        protected abstract void RemoveFromBusyCollection(T entity);

        protected BusySet()
        {
            All = new ReadOnlyCollection<T>(all);
        }

        public void SetFree(T entity)
        {
            RemoveBusy(entity);
            AddFree(entity);
        }

        public void SetBusy(T entity)
        {
            RemoveFree(entity);
            AddBusy(entity);
        }

        public void AddNewFree(T entity)
        {
            Debug.Assert(!All.Contains(entity));
            Debug.Assert(!AllFree.Contains(entity));
            Debug.Assert(!AllBusy.Contains(entity));
            AddFree(entity);
        }

        public void AddNewBusy(T entity)
        {
            Debug.Assert(!All.Contains(entity));
            Debug.Assert(!AllFree.Contains(entity));
            Debug.Assert(!AllBusy.Contains(entity));
            AddBusy(entity);
        }

        public void RemoveFree(T entity)
        {
            Debug.Assert(AllFree.Contains(entity));
            RemoveFromFreeCollection(entity);
            all.Remove(entity);
        }


        public void RemoveBusy(T entity)
        {
            Debug.Assert(AllBusy.Contains(entity));
            RemoveFromBusyCollection(entity);
            all.Remove(entity);
        }


        private void AddFree(T entity)
        {
            Debug.Assert(!AllFree.Contains(entity));
            AddToFreeCollection(entity);
            all.Add(entity);
        }

        private void AddBusy(T entity)
        {
            Debug.Assert(!AllBusy.Contains(entity));
            AddToBusyCollection(entity);
            all.Add(entity);
        }
    }
}
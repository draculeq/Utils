using System.Collections.Generic;
using System.Linq;

namespace Deadbit.Utils
{
    public class BusyStackSet<T> : BusySet<T>
    {
        public override IReadOnlyCollection<T> AllBusy => busy;
        public override IReadOnlyCollection<T> AllFree => free;

        private LinkedList<T> free = new LinkedList<T>();
        private LinkedList<T> busy = new LinkedList<T>();

        public override bool TryGetFree(out T entity)
        {
            entity = free.FirstOrDefault();
            return entity != null;
        }

        public override bool TryGetBusy(out T entity)
        {
            entity = busy.FirstOrDefault();
            return entity != null;
        }

        protected override void AddToFreeCollection(T entity)
        {
            free.AddFirst(entity);
        }

        protected override void AddToBusyCollection(T entity)
        {
            busy.AddFirst(entity);
        }

        protected override void RemoveFromFreeCollection(T entity)
        {
            free.Remove(entity);
        }

        protected override void RemoveFromBusyCollection(T entity)
        {
            busy.Remove(entity);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Deadbit.Utils.Extensions;

namespace Deadbit.Utils
{
    public class BusyRandomSet<T> : BusySet<T>
    {
        public override IReadOnlyCollection<T> AllFree => free;
        public override IReadOnlyCollection<T> AllBusy => busy;

        private LinkedList<T> free = new LinkedList<T>();
        private LinkedList<T> busy = new LinkedList<T>();

        public override bool TryGetFree(out T entity)
        {
            if (!free.Any())
            {
                entity = default;
                return false;
            }

            entity = free.Random();
            return entity != null;
        }

        public override bool TryGetBusy(out T entity)
        {
            if (!busy.Any())
            {
                entity = default;
                return false;
            }

            entity = busy.Random();
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
using UnityEngine.Events;

namespace Deadbit.Utils.Extensions
{
    public static class UnityEventExt
    {
        public static void AddClean(this UnityEvent @event, UnityAction action)
        {
            @event.RemoveListener(action);
            @event.AddListener(action);
        }
        public static void AddClean<T>(this UnityEvent<T> @event, UnityAction<T> action)
        {
            @event.RemoveListener(action);
            @event.AddListener(action);
        }
    }
}
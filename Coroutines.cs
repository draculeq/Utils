using Deadbit.Utils.Extensions;
using System;
using System.Collections;
using UnityEngine;

namespace Deadbit.Utils
{
    public interface ICoroutines
    {
        IEnumerator Begin(IEnumerator coroutine);
        void Stop(IEnumerator coroutine);
        IEnumerator StartDelayed(float delay, Action callback);
    }

    public class Coroutines : MonoBehaviour, ICoroutines
    {
        protected static Coroutines instance;

        public static ICoroutines Instance
        {
            get
            {
                if (instance != null)
                    return instance;
                var obj = new GameObject("Coroutines").AddComponent<Coroutines>();
                instance = obj;
                DontDestroyOnLoad(obj);
                return obj;
            }
        }

        public IEnumerator Begin(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
            return coroutine;
        }
        public void Stop(IEnumerator coroutine)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
        }

        public IEnumerator StartDelayed(float delay, Action callback)
        {
            return ((MonoBehaviour)this).StartDelayed(delay, callback);
        }
    }
}
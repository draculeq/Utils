using Deadbit.Utils.Extensions;
using System;
using System.Collections;
using UnityEngine;

namespace Deadbit.Utils
{
    public interface ICoroutines
    {
        Coroutine Begin(IEnumerator enumerator);
        void Stop(Coroutine coroutine);
        Coroutine StartDelayed(float delay, Action callback);
        Coroutine StartDelayed(int framesOfDelay, Action callback);
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

        public Coroutine Begin(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        } 

        public void Stop(Coroutine coroutine)
        {
            if (coroutine != null) StopCoroutine(coroutine);
        }

        public Coroutine StartDelayed(float delay, Action callback)
        {
            return ((MonoBehaviour)this).StartDelayed(delay, callback);
        }

        public Coroutine StartDelayed(int framesOfDelay, Action callback)
        {
            return ((MonoBehaviour)this).StartDelayed(framesOfDelay, callback);
        }
    }
}
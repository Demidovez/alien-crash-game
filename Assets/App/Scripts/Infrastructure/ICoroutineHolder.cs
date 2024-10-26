using System.Collections;
using UnityEngine;

namespace App.Scripts.Infrastructure
{
    public interface ICoroutineHolder
    {
        public Coroutine StartCoroutine(IEnumerator routine);
    }
}
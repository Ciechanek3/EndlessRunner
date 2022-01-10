using System;
using UnityEngine;

namespace StateMachine
{
    public abstract class BaseState : MonoBehaviour
    {
        public abstract Type Tick();
    }
}

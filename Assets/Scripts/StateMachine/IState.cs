using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovementSystem
{
    public interface IState
    {
        public void Enter();//Method Created not implemented
        public void Exit();//Method Created not implemented
        public void HandleInput();
        public void Update();
        public void PhysicsUpdate();
    }
}


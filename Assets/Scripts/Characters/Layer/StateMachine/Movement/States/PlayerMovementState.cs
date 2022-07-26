using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovementSystem
{
    public class PlayerMovementState : IState
    {
        protected PlayerMovementStateMachine stateMachine;

        protected Vector2 movementInput;

        protected float baseSpeed = 5f;
        protected float speedModifier = 1f;

        public PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
        {
            stateMachine = playerMovementStateMachine;
        }
        public virtual void Enter()
        {
          Debug.Log("State:"+GetType().Name);
        }

        public virtual void Exit()
        {
           
        }

        public virtual void HandleInput()
        {
            ReadMovementInput();
        }

       

        public virtual void PhysicsUpdate()
        {
            Move();
        }

       

        public virtual void Update()
        {
           
        }

        private void ReadMovementInput()
        {
            movementInput = stateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
        }
        private void Move()
        {
            if(movementInput == Vector2.zero || speedModifier ==0f)
            {
                return;
            }

            Vector3 movementDirection = GetMovementInputDirection();
            float movementSpeed = GetMovementSpeed();

            Vector3 currentPlayerHorizontalVelocity = GetPlayerHorizontalVelocity();
            stateMachine.Player.Rigidbody.AddForce(movementDirection * movementSpeed - currentPlayerHorizontalVelocity,ForceMode.VelocityChange);

        }

        protected Vector3 GetPlayerHorizontalVelocity()
        {
            Vector3 playerHorizontalVeloctiy = stateMachine.Player.Rigidbody.velocity;
            playerHorizontalVeloctiy.y = 0f;
            return playerHorizontalVeloctiy;
        }

        protected float GetMovementSpeed()
        {
           return baseSpeed * speedModifier;
        }

        private Vector3 GetMovementInputDirection()
        {
            return new Vector3(movementInput.x, 0f, movementInput.y);
        }
    }
}

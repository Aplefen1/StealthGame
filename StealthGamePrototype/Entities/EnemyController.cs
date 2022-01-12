using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StealthGamePrototype.Entities
{
    class EnemyController : Component, IUpdatable, ITriggerListener
    {

        private Enemy _parentEnemy;

        private float _angle;
        private Vector2 _currentMovementVector;
        private float _speed;

        //moving
        Mover _mover;
        SubpixelVector2 _subpixelV2;

        public EnemyController(Enemy enemy)
        {

            _parentEnemy = enemy;
            _speed = 250f;

        }

        public override void OnEnabled()
        {
            _currentMovementVector = GetMovementVector();
            _angle = GetAngle();
            _mover = _parentEnemy.AddComponent<Mover>(new Mover());
            _subpixelV2 = new SubpixelVector2();

        }

        void IUpdatable.Update()
        {

            MoveToTarget();
            UpdateAnimation();
        }

        public void UpdateAnimation()
        {
            string moveDir = "Idle";

            if(_currentMovementVector.X > 0)
            {
                moveDir = "WalkLeft";
            }
            else if(_currentMovementVector.X < 0)
            {
                moveDir = "WalkRight";
            }

            if (!_parentEnemy.Animator.IsAnimationActive(moveDir))
            {
                _parentEnemy.Animator.Play(moveDir);
            }
        }

        public bool GetNextNode()
        {
            if (CheckTargetIsTriggered())
            {
                _parentEnemy.CurrentNode = _parentEnemy.TargetNode;
                _parentEnemy.TargetNode = _parentEnemy.TargetNode.Tail;

                Debug.Log(_parentEnemy.TargetNode.Name);

                _angle = GetAngle();
                _currentMovementVector = GetMovementVector();

                return true;
            }
            return false;
        }

        public bool CheckTargetIsTriggered()
        {

            if (_parentEnemy.TargetNode.GetComponent<CircleCollider>().Shape.Overlaps(_parentEnemy.NodeTriggerRadius.Shape))
                return true;

            return false;

        }

        public void MoveToTarget()
        {

            Vector2 movement = (_currentMovementVector * Time.DeltaTime);

            Debug.Log(movement);

            _mover.CalculateMovement(ref movement, out CollisionResult res);

            //Debug.Log(movement);

            _subpixelV2.Update(ref movement);

            //Debug.Log(movement);

            _mover.Move(-movement, out res);

        }

        public float GetAngle()
        {

            return Mathf.AngleBetweenVectors(_parentEnemy.TargetNode.Position, _parentEnemy.Position);

        }

        public Vector2 GetMovementVector()
        {

            float xPart = (float)Math.Cos(_angle) * _speed;
            float yPart = (float)Math.Sin(_angle) * _speed;

            return new Vector2(xPart, yPart);

        }

        public void OnTriggerEnter(Collider other, Collider local)
        {

            if (other.Entity.Name == _parentEnemy.TargetNode.Name)
            {
                _parentEnemy.CurrentNode = _parentEnemy.TargetNode;
                _parentEnemy.TargetNode = _parentEnemy.TargetNode.Tail;

                _angle = GetAngle();
                _currentMovementVector = GetMovementVector();

                Debug.Log(_parentEnemy.TargetNode.Name);
            }
            _currentMovementVector = GetMovementVector();
            _angle = GetAngle();

        }

        public void OnTriggerExit(Collider other, Collider local)
        {
            _currentMovementVector = GetMovementVector();
            _angle = GetAngle();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StealthGamePrototype.Entities
{
    class NodeMovement : Component, IUpdatable
    {

        private const float SPEED = 10;
        private Node _parent;

        private MouseState _mouseState;
        private MouseState _previousState;

        public bool IsHeld;

        public bool IsLeftPressed
        {
            get
            {
                if (_mouseState.LeftButton == ButtonState.Pressed
                    && _previousState.LeftButton == ButtonState.Released)
                    return true;

                return false;
            }
        }

        public bool IsLeftReleased
        {
            get
            {
                if (_mouseState.LeftButton == ButtonState.Released
                    && _previousState.LeftButton == ButtonState.Pressed)
                    return true;

                return false;
            }
        }

        public bool LeftButtonHeld
        {
            get
            {
                if (_mouseState.LeftButton == ButtonState.Pressed
                    && _previousState.LeftButton == ButtonState.Pressed)
                        return true;

                return false;
            }
        }

        public bool IsMouseColliding
        {
            get
            {
                //if the parent node's collider component's shape contains the point where the mouse is
                if (true)
                    return false;

                return false;
                    
            }
        }

        public NodeMovement(Node parent)
        {
            _parent = parent;
            IsHeld = false;
        }

       
        public void Update()
        {
            _mouseState = Mouse.GetState();
            CheckIfHeld();

            if (IsHeld)
                FollowMouse();

        }

        public void CheckIfHeld()
        {
            if(IsHeld == false && IsMouseColliding)
            {
                if (IsLeftPressed)
                    IsHeld = true;

            }

            if(IsHeld == true)
            {
                if (LeftButtonHeld)
                    IsHeld = true;

                if (IsLeftReleased)
                    IsHeld = false;
            }
            _previousState = _mouseState;
        }

        public void FollowMouse()
        {
            _parent.Position = _mouseState.Position.ToVector2();
        }
    }
}

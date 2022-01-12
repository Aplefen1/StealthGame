using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Textures;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace StealthGamePrototype.Entities
{
    class PlayerController : Component, IUpdatable, ITriggerListener
    {

        private Player _player;

        private VirtualIntegerAxis _xAxis;
        private VirtualIntegerAxis _yAxis;

        private Mover _mover;

        private float _moveSpeed;

        SubpixelVector2 _subpixelV2;

        public PlayerController(Player player)
        {

            _player = player;
            _mover = _player.AddComponent<Mover>(new Mover());

            _moveSpeed = 500f;

            _subpixelV2 = new SubpixelVector2();

        }

        public override void OnAddedToEntity()
        {
            SetupInput();
        }


        public void Update()
        {

            string anim = "Idle";

            Vector2 moveVector = new Vector2(_xAxis.Value, _yAxis.Value);

            if (moveVector.X < 0)
                anim = "WalkLeft";

            else if (moveVector.X > 0)
                anim = "WalkRight";

            else if (moveVector.Y > 0)
                anim = "WalkRight";

            else if (moveVector.Y < 0)
                anim = "WalkRight";

            if (moveVector != Vector2.Zero)
            {

                if (!_player.PlayerAnimator.IsAnimationActive(anim))
                    _player.PlayerAnimator.Play(anim);

                else
                    _player.PlayerAnimator.UnPause();

                Vector2 movement = moveVector * _moveSpeed * Time.DeltaTime;

                _mover.CalculateMovement(ref movement, out CollisionResult result);

                _subpixelV2.Update(ref movement);
                _mover.Move(movement, out result);
            }

            if (moveVector == Vector2.Zero)
            {
                if(!_player.PlayerAnimator.IsAnimationActive("Idle"))
                    _player.PlayerAnimator.Play("Idle");
            }

        }

        private void SetupInput()
        {
            _xAxis = new VirtualIntegerAxis();
            _yAxis = new VirtualIntegerAxis();

            _xAxis.Nodes.Add(new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Left, Keys.Right));
            _yAxis.Nodes.Add(new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Up, Keys.Down));
        }

        public void OnTriggerEnter(Collider other, Collider local)
        {
            Debug.Log("Awooga");
        }

        public void OnTriggerExit(Collider other, Collider local)
        {
            Debug.Log("Booga");
        }

    }
}

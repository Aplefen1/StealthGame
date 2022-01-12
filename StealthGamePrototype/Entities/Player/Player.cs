using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Microsoft.Xna.Framework.Graphics;
using Nez.Systems;
using Microsoft.Xna.Framework;

namespace StealthGamePrototype.Entities
{
    class Player : Entity
    {
        //fields

        //components
        private Scene _scene;
        private PlayerController _playerController;
        private FollowCamera _camera;

        
        public MyAnimator PlayerAnimator { get; set; }

        public Player(Scene scene)
        {
            Name = "poopypoo";
            _scene = scene;
            PlayerAnimator = this.AddComponent<MyAnimator>(new MyAnimator("GreenDinoAnim"));

            PlayerAnimator.RenderLayer = 1;

        }

        public void Initialize()
        {

            _scene.AddEntity<Player>(this);

            _camera = this.AddComponent<FollowCamera>(new FollowCamera(this));

            BoxCollider col = this.AddComponent<BoxCollider>(new BoxCollider(10,10));

            InitializeComponents();

            this.Scale = new Vector2(4, 4);
        }

        public void InitializeComponents()
        {

            _playerController = new PlayerController(this);

            this.AddComponent<PlayerController>(_playerController);

        }
    }
}

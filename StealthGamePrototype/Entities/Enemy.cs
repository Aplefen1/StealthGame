using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Microsoft.Xna.Framework;
using Random = Nez.Random;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;

namespace StealthGamePrototype.Entities
{
    class Enemy : Entity
    {
        private const int MAX_NETWORK_POS = 50;

        //Constants

        //Private Fields and Instances

        private Scene _scene;
        private NodeManager _network;
        private Vector2 _startPos;
        private EnemyController _controller;

        //public props

        public Node CurrentNode { get; set; }
        public Node TargetNode { get; set; }
        public CircleCollider NodeTriggerRadius;
        public MyAnimator Animator { get; set; }

        //Add rotation of sprite

        public Enemy(Scene scene)
        {

            _scene = scene;
            _scene.AddEntity<Enemy>(this);
            _network = new NodeManager(_scene, new Vector2(Random.NextInt(MAX_NETWORK_POS*2) -MAX_NETWORK_POS, Random.NextInt(MAX_NETWORK_POS*2)-MAX_NETWORK_POS));

            SetUpdateOrder(2);

            _controller = this.AddComponent<EnemyController>(new EnemyController(this));
            _controller.Enabled = false;

            NodeTriggerRadius = this.AddComponent<CircleCollider>(new CircleCollider(4));
        }

        public void Initialize()
        {

            CurrentNode = _network.NodeList[Random.NextInt(_network.NodeList.Count)];
            TargetNode = CurrentNode.Tail;

            _startPos = CurrentNode.Position;
            Position = _startPos;

            Animator = this.AddComponent<MyAnimator>(new MyAnimator("KnightEnemyAnim"));

            this.Scale = new Vector2(4, 4);

            _controller.Enabled = true;

        }    
    }
}

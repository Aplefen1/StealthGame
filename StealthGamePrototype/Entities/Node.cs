using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Nez;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.PhysicsShapes;

namespace StealthGamePrototype.Entities
{
    public class Node : Entity
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public int Index { get; }

        private Scene _scene;

        private SpriteRenderer _sprite;
        
        public CircleCollider TriggerRadius { get; set; }


        public Node(Node head, Vector2 position, Scene scene)
        {

            Head = head;
            Position = position;
            _scene = scene;
            SetUpdateOrder(1);
            

        }

        public void Initialize()
        {

            TriggerRadius = this.AddComponent<CircleCollider>(new CircleCollider(10f));
            TriggerRadius.IsTrigger = true;

            this.AddComponent<LineCaster>(new LineCaster(this));

        }

        public void SetHead(Node previous)
        {
            Head = previous;
        }

        public void SetTail(Node next)
        {
            Tail = next;
        }

    }
}

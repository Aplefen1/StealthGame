using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Microsoft.Xna.Framework;

namespace StealthGamePrototype.Entities
{
    class LineCaster : RenderableComponent, IUpdatable
    {

        private Node _node;

        private Vector2 _collisionPosition;

        public override float Width => 10000;
        public override float Height => 10000;


        public LineCaster(Node node)
        {
            _node = node;
            _collisionPosition = new Vector2();
        }

        public override void Render(Batcher batcher, Camera camera)
        {
            Debug.Log(camera.Entity.Name);
            batcher.DrawLine(_node.Transform.Position, _node.Tail.Transform.Position, Color.White);

            if (_collisionPosition != null)
            {
                batcher.DrawPixel(_collisionPosition, Color.Red, 20);
            }
            
        }

        public void Update()
        {
            RaycastHit hit = Physics.Linecast(_node.Transform.Position, _node.Tail.Transform.Position);

            if ( hit.Collider != null )
            {
                _collisionPosition = hit.Point;
            }
            else
            {
                _collisionPosition = new Vector2();
            }

        }
    }
}

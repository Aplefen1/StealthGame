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
    class PathLine : LineRenderer, IUpdatable
    {

        //Create a line from parent node to parent's tail node
        //add to the entity

        public Vector2 StartPos => _startPos;
        public Vector2 EndPos => _endPos;

        public Node ParentNode => _parentNode;

        private Vector2 _startPos;
        private Vector2 _endPos;

        private Node _parentNode;

        public PathLine(Node parentNode) : base()
        {
            _parentNode = parentNode;

            _startPos = ParentNode.Position;
            _endPos = ParentNode.Tail.Position;

            AddPathToNode();
        }

        private void AddPathToNode()
        {           

            this.AddPoint(_startPos, 20f);
            this.AddPoint(_endPos, 20f);

            SetStartEndColors(Color.PaleVioletRed, Color.MediumVioletRed);

        }

        public void Update()
        {

            _startPos = ParentNode.Position;
            _endPos = ParentNode.Tail.Position;


            UpdatePathOnNetwork();
            
        }

        private void UpdatePathOnNetwork()
        {
            this.UpdatePoint(0, _startPos, 20f);
            this.UpdatePoint(1, _endPos, 20f);
        }
    }
}

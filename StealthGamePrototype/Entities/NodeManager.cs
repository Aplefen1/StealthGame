using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Random = Nez.Random;
using Microsoft.Xna.Framework;


namespace StealthGamePrototype.Entities
{
    public class NodeManager
    {

        public const int NETWORK_RADIUS = 800;
   
        private Node _currentNode;
        private Node _previousNode;

        private Node _firstNode;

        private Scene _scene;

        private List<Node> _nodes;
        //private Guard _guard

        private readonly int _numberOfNodes ;
        private int _nodesCreated;

        private Vector2 _networkPos;

        public List<Node> NodeList => _nodes;

        public Vector2 NetworkPosition => _networkPos;

        public NodeManager(Scene scene, Vector2 position)
        {

            _scene = scene;
            _numberOfNodes = Random.NextInt(10)+1;
            _nodesCreated = 0;

            _networkPos = position;

            _firstNode = new Node(null, RandomPosition(), _scene);

            _nodes = new List<Node>(_numberOfNodes);

            _nodes.Add(_firstNode);

            CreateNetwork();


        }

        public void CreateNetwork()
        {
            while (_nodesCreated < _numberOfNodes)
            {

                if (_nodesCreated == 0)
                {

                    _previousNode = _firstNode;

                    CreateNextNode(NetworkPosition.X.ToString() + NetworkPosition.Y.ToString() + _nodesCreated.ToString());

                    _nodesCreated += 1;
                    continue;

                }
                if (_nodesCreated < _numberOfNodes && _nodesCreated > 0)
                {

                    CreateNextNode(NetworkPosition.X.ToString() + NetworkPosition.Y.ToString() + _nodesCreated.ToString());

                    _nodesCreated += 1;


                }
            }
            _previousNode.SetTail(_firstNode);
            _firstNode.SetHead(_previousNode);

            foreach(Node n in _nodes)
            {
                n.Initialize();
                _scene.AddEntity<Node>(n);
            }
        }

        public void CreateNextNode(string name)
        {
            Node nextNode = new Node(_previousNode, RandomPosition(), _scene)
            {
                Name = name
            };
            _currentNode = nextNode;

            _nodes.Add(_currentNode);

            _previousNode.SetTail(_currentNode);

            _previousNode = _currentNode;

        }

        public Vector2 RandomPosition()
        {

            Vector2 posWithinRadius = _networkPos + new Vector2(Random.NextInt(NETWORK_RADIUS*2)-NETWORK_RADIUS, Random.NextInt(NETWORK_RADIUS * 2) - NETWORK_RADIUS);
            return posWithinRadius;

        }

    }
}

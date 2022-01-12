using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Random = Nez.Random;

namespace StealthGamePrototype.Entities
{
    class EnemyFactory
    {

        public List<Enemy> Enemies { get; }

        public EnemyFactory(Scene scene)
        {
            Enemies = new List<Enemy>();

            for (int i=0; i < 10; i++)
            {
                Enemies.Add(new Enemy(scene));
            }

        }

        public void Initialize()
        {
            foreach(Enemy e in Enemies)
            {
                e.Initialize();
            }
        }

    }
}

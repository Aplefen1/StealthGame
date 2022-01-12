using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using StealthGamePrototype.Entities;

namespace StealthGamePrototype.Scenes
{
    class TestScene : Scene
    {

        public override void Initialize()
        {
            Graphics.Instance.Batcher.Begin();

            Player p = new Player(this);
            p.Initialize();

            EnemyFactory enemyFactory = new EnemyFactory(this);
            enemyFactory.Initialize();

            Graphics.Instance.Batcher.End();

            ///Core.DebugRenderEnabled = true;

        }
    }
}

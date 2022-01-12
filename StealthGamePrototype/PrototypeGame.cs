using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Textures;
using Nez.Sprites;
using StealthGamePrototype.Scenes;
using StealthGamePrototype.Entities;

namespace StealthGamePrototype
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class PrototypeGame : Core
    {

        public PrototypeGame()
        { }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            Scene scene = new TestScene();
            
            Core.Scene = scene;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez.Sprites;
using Nez.Textures;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace StealthGamePrototype.Entities
{
    class MyAnimator : SpriteAnimator
    {

        private string _spriteSheet;

        public MyAnimator(String spriteSheet)
        {

            _spriteSheet = spriteSheet;

        }


        public override void OnAddedToEntity()
        {
            Texture2D texture = Entity.Scene.Content.LoadTexture(_spriteSheet);
            List<Sprite> sprites = Sprite.SpritesFromAtlas(texture, 16, texture.Height);

            this.AddAnimation("WalkRight", new[]
            {
                sprites[4],
                sprites[5],
                sprites[6],
                sprites[7],
            });

            this.AddAnimation("WalkLeft", new[]
            {
                sprites[9],
                sprites[10],
                sprites[11],
                sprites[12],
            });

            this.AddAnimation("Idle", new[]
            {
                sprites[0],
                sprites[1],
                sprites[2],
                sprites[3],
            },
            8f);


        }

    }
}

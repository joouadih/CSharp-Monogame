using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Entity
    {
        Texture2D spriteImg;
        Vector2 spritePos;
        float rotation;


        public Entity(Texture2D SpriteImg, Vector2 SpritePos)
        {
            spriteImg = SpriteImg;
            spritePos = SpritePos;
            rotation = 0f;
        }
        private int getRandom(int Min,int Max)
        {
            Random rnd = new Random();
            return rnd.Next(Min, Max);
            
        }
        public Rectangle Rectangle()
        {
            return new Rectangle((int)spritePos.X, (int)spritePos.Y, spriteImg.Width, spriteImg.Height);
        }
        public Vector2 SpritePos
        {
            get
            {
                return this.spritePos;
            }
            set
            {
                this.spritePos = value;
            }
        }


        public void Update()
        {
            rotation = 0.0f;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                spritePos.X += 5;
                rotation = 0.2f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                spritePos.X -= 5;
                rotation = -0.2f;
            }

            if(getRandom(1,10) <= 5)
            {
                spritePos.X -= getRandom(1, 5);
            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteImg, new Rectangle((int)spritePos.X, (int)spritePos.Y, spriteImg.Width, spriteImg.Height), null, Color.White, rotation, Vector2.Zero, SpriteEffects.None, 0);
        }

    }
}

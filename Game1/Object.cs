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
    class Object
    {

        Texture2D spriteImg;
        Vector2 spritePos;

        bool isRight;
        string objTag;

        public string Name
        {
            get
            {
                return this.objTag;
            }
            set
            {
                this.objTag = value;
            }
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
        public Texture2D SpriteImg
        {
            get
            {
                return this.spriteImg;
            }
            
        }
        public Rectangle Rectangle()
        {
            return new Rectangle((int) spritePos.X + 75 , (int) spritePos.Y + 50, spriteImg.Width - 75, spriteImg.Height - 50);
        }


        public Object(Texture2D SpriteImg, Vector2 SpritePos, bool IsRight, string ObjTag)
        {
            spriteImg = SpriteImg;
            spritePos = SpritePos;
            isRight = IsRight;
            objTag = ObjTag;
        }

        

        public void Update(Vector2 direction)
        {

            spritePos += direction;

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            switch(isRight)
            {

                // Rendering to the right
                case true:
                    spriteBatch.Draw(spriteImg, new Rectangle((int)spritePos.X, (int)spritePos.Y, spriteImg.Width, spriteImg.Height), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                    break;

                // Rendering to the left
                case false:
                    spriteBatch.Draw(spriteImg, new Rectangle((int)spritePos.X, (int)spritePos.Y, spriteImg.Width, spriteImg.Height), null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                    break;

            }
            
            

        }


    }
}

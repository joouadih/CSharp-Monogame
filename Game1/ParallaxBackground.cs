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
    class ParallaxBackground
    {

        Texture2D spriteBackground;

        // 2. Create two rectangles for the texture.
        Rectangle rectangleOne;
        Rectangle rectangleTwo;
        bool isVertical,isUpLeft;
        int speedMove;


        public ParallaxBackground(Texture2D texture, int SpeedMove, bool IsVertical, bool IsUpLeft)
        {
            speedMove = SpeedMove;
            isVertical = IsVertical;
            isUpLeft = IsUpLeft;

            switch (isVertical)
            {
                case true:
                    rectangleOne = new Rectangle(0, 0, texture.Width, texture.Height);
                    rectangleTwo = new Rectangle(0, (texture.Height * -1), texture.Width, texture.Height);
                    break;

                case false:
                    rectangleOne = new Rectangle(0, 0, texture.Width, texture.Height);
                    rectangleTwo = new Rectangle(texture.Width, 0, texture.Width, texture.Height);
                    break;
            }
            
            spriteBackground = texture;
        }

        public void Update(GameTime gametime, Viewport viewport, Vector2 direction)
        {
            float elapsed = (float)gametime.ElapsedGameTime.TotalSeconds;

            DirectionDraw(viewport);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteBackground, rectangleOne, Color.White);
            spriteBatch.Draw(spriteBackground, rectangleTwo, Color.White);
        }


        public void DirectionDraw(Viewport viewport)
        {

            switch (isVertical)
            {
                case true:

                    switch (isUpLeft)
                    {
                        // Direction is vertical up
                        case true:

                            if (rectangleOne.Y >= viewport.Height)
                                rectangleOne.Y = rectangleTwo.Y - spriteBackground.Height;

                            if (rectangleTwo.Y >= viewport.Height)
                                rectangleTwo.Y = rectangleOne.Y - spriteBackground.Height;

                            rectangleOne.Y += speedMove;
                            rectangleTwo.Y += speedMove;

                            break;


                        // Direction is horizontal down
                        case false:

                            if (rectangleOne.Y + spriteBackground.Height <= 0)
                                rectangleOne.Y = rectangleTwo.Y + spriteBackground.Height;

                            if (rectangleTwo.Y + spriteBackground.Height <= 0)
                                rectangleTwo.Y = rectangleOne.Y + spriteBackground.Height;

                            rectangleOne.Y -= speedMove;
                            rectangleTwo.Y -= speedMove;

                            break;
                    }

                    break;



                case false:

                    switch (isUpLeft)
                    {
                        // Direction is horizontal left
                        case true:

                            if (rectangleOne.X + spriteBackground.Width <= 0)
                                rectangleOne.X = rectangleTwo.X + spriteBackground.Width;


                            if (rectangleTwo.X + spriteBackground.Width <= 0)
                                rectangleTwo.X = rectangleOne.X + spriteBackground.Width;


                            rectangleOne.X -= speedMove;
                            rectangleTwo.X -= speedMove;

                            break;



                        // Direction is horizontal right
                        case false:

                            if (rectangleOne.X  >= viewport.Width)
                                rectangleOne.X = rectangleTwo.X - spriteBackground.Width;


                            if (rectangleTwo.X >= viewport.Width)
                                rectangleTwo.X = rectangleOne.X - spriteBackground.Width;


                            rectangleOne.X += speedMove;
                            rectangleTwo.X += speedMove;


                            break;
                    }

                    


                    break;

            }


        }



    }
}




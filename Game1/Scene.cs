using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;



namespace Game1
{
    class Scene
    {

        List<ParallaxBackground> Backgrounds;
        List<Object> ObjectsLeft,ObjectsRight;
        Entity entityPlayer;

        ContentManager contentManager;
        Viewport viewPort;

        private int getRandom(int Min, int Max)
        {
            Random rnd = new Random();
            return rnd.Next(Min, Max);

        }
        private bool getBool()
        {
            Random rnd = new Random();
            if (rnd.NextDouble() > 0.5)
                return true;

            else
                return false;
        }




        public Scene(ContentManager ContentManager)
        {
            contentManager = ContentManager;

            //Loads Player
            entityPlayer = new Entity(contentManager.Load<Texture2D>("img/bikelevel/level1/Bike_Pixel"), new Vector2(350, 550));

            //Load the Parallax backgrounds
            Backgrounds = new List<ParallaxBackground>();
            Backgrounds.Add(new ParallaxBackground(contentManager.Load<Texture2D>("img/bikelevel/level1/grassfield_pixel"), 10, true,true));
            Backgrounds.Add(new ParallaxBackground(contentManager.Load<Texture2D>("img/bikelevel/level1/road_pixel"), 10, true, true));

            //Loads left side with objects
            ObjectsLeft = new List<Object>();
            ObjectsLeft.Add(new Object(contentManager.Load<Texture2D>("img/bikelevel/level1/house_pixel"), new Vector2(0, -getRandom(500, 1000)), true, "house" ));
            ObjectsLeft.Add(new Object(contentManager.Load<Texture2D>("img/bikelevel/level1/playground_pixel_small"), new Vector2(0, -getRandom(1500, 2500)), true, "playground"));

            //Loads right side with objects
            ObjectsRight = new List<Object>();
            ObjectsRight.Add(new Object(contentManager.Load<Texture2D>("img/bikelevel/level1/playground_pixel_small"), new Vector2(660, -getRandom(500, 1000)), false, "playground"));
            ObjectsRight.Add(new Object(contentManager.Load<Texture2D>("img/bikelevel/level1/house_pixel"), new Vector2(575, -getRandom(1000, 2500)), false, "house"));
        }

        public void Update(GameTime gameTime, Viewport Viewport)
        {
            viewPort = Viewport;
            foreach (ParallaxBackground bg in Backgrounds)
                bg.Update(gameTime, Viewport, new Vector2(0, -2));


            foreach (Object obj in ObjectsLeft)
                obj.Update( new Vector2(0, 5));

            foreach (Object obj in ObjectsRight)
                obj.Update(new Vector2(0, 5));


            ObjectHandler();

            entityPlayer.Update();
            PlayerHandler();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ParallaxBackground bg in Backgrounds)
                bg.Draw(spriteBatch);

            foreach (Object obj in ObjectsLeft)
                obj.Draw(spriteBatch);

            foreach (Object obj in ObjectsRight)
                obj.Draw(spriteBatch);

            entityPlayer.Draw(spriteBatch);
            
        }




        private void PlayerHandler()
        {

            if (entityPlayer.SpritePos.X <= 0 || entityPlayer.SpritePos.X >= viewPort.Width)
                entityPlayer.SpritePos = new Vector2(350, 550);




            //Player intersect any objects
            for (int i = 0; i < ObjectsRight.Count - 1; i++)
                //Remove objects outside the window
                if (entityPlayer.Rectangle().Intersects(ObjectsRight.ElementAt(i).Rectangle()))
                    entityPlayer.SpritePos -= new Vector2(50, 0);

            //Player intersect any objects
            for (int i = 0; i < ObjectsLeft.Count - 1; i++)
                //Remove objects outside the window
                if (entityPlayer.Rectangle().Intersects(ObjectsLeft.ElementAt(i).Rectangle()))
                    entityPlayer.SpritePos += new Vector2(50, 0);



        }

        private void ObjectHandler()
        {

            DeleteObject();


            if (ObjectsLeft.Count <= 5)
                //Add new object
                ObjectsLeft.Add(CreateObject(ObjectsLeft.Last(),true));

            if (ObjectsRight.Count <= 5)
                //Add new object
                ObjectsRight.Add(CreateObject(ObjectsRight.Last(), false));

        }
        private Object CreateObject(Object Obj, bool ObjisLeft)
        {
            Object obj;
            Texture2D objTexture = null;
            Vector2 objPos = Vector2.Zero;

            string objName = "house";
            int minCreateY = 0;
            int maxCreateY = 0;

            if ((int)Obj.SpritePos.Y <= 0)
                minCreateY = ((int)Obj.SpriteImg.Height + 30 + ((int)Obj.SpritePos.Y * -1));

            else
                minCreateY = ((int)Obj.SpritePos.Y + viewPort.Height);

            maxCreateY = minCreateY + 400; 
            
            
            switch (getBool())
            {

                //If true, a house is created
                case true:

                    objTexture = contentManager.Load<Texture2D>("img/bikelevel/level1/house_pixel");
                    //If true, a house is created on the left side
                    switch (ObjisLeft)
                    {
                        case true:
                            objPos = new Vector2(0, -getRandom(minCreateY, maxCreateY));
                            break;

                        case false:
                            objPos = new Vector2(575, -getRandom(minCreateY, maxCreateY));
                            break;
                    }              

                    break;


                //If false, a playground is created
                case false:

                    objName = "playground";
                    objTexture = contentManager.Load<Texture2D>("img/bikelevel/level1/playground_pixel_small");
                    switch (ObjisLeft)
                    {
                        //If true, a playground is created on the left side 
                        case true:
                            objPos = new Vector2(0, -getRandom(minCreateY, maxCreateY));
                            break;

                        case false:
                            
                            objPos = new Vector2(650, -getRandom(minCreateY, maxCreateY));
                            break;


                    }

                    break;   
            }



            obj = new Object(objTexture, objPos, ObjisLeft, objName);
            return obj;


        }
        private void DeleteObject()
        {
            //Right Side
            for (int i = 0; i < ObjectsRight.Count - 1; i++)
            {
                for (int j = i + 1; j < ObjectsRight.Count; j++)
                {
                    //Remove objects that intersect with each other
                    if (ObjectsRight.ElementAt(i).Rectangle().Intersects(ObjectsRight.ElementAt(j).Rectangle()))
                        ObjectsRight.RemoveAt(i);
                }
            }


            //Left Side
            for (int i = 0; i < ObjectsLeft.Count - 1; i++)
            {
                for (int j = i + 1; j < ObjectsLeft.Count; j++)
                {
                    //Remove objects that intersect with each other
                    if (ObjectsLeft.ElementAt(i).Rectangle().Intersects(ObjectsLeft.ElementAt(j).Rectangle()))
                        ObjectsLeft.RemoveAt(i);
                }
            }

            

            //Right Side
            for (int i = 0; i < ObjectsRight.Count - 1; i++)
                //Remove objects outside the window
                if (ObjectsRight.ElementAt(i).SpritePos.Y >= (viewPort.Height + ObjectsRight.ElementAt(i).SpriteImg.Height + 20))
                    ObjectsRight.RemoveAt(i);


            //Left Side
            for (int i = 0; i < ObjectsLeft.Count - 1; i++)
                //Remove objects outside the window
                if (ObjectsLeft.ElementAt(i).SpritePos.Y >= (viewPort.Height + ObjectsRight.ElementAt(i).SpriteImg.Height + 20))
                    ObjectsLeft.RemoveAt(i);
        }



    }
}

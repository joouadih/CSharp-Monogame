![4772066](https://user-images.githubusercontent.com/4427332/61470314-1df54780-a981-11e9-88a5-4cc86bce5465.png)

# C#-Mono-Template
A simple bike game, which can be used as a template for an Mono Game

![2019-07-18 17_32_14-](https://user-images.githubusercontent.com/4427332/61471138-85f85d80-a982-11e9-9b52-71d7e6e81f29.png)


## MonoGame
The main class for a Mono Game is Game1.cs, which has five main functions that is necessary

  Initialize
    - Used to init data, for example graphics.PreferredBackBufferWidth = 1024 which means the width of the Window is 1024px.
    
  LoadContent
    - Used to init sprites and images, for example spriteBatch = new SpriteBatch(GraphicsDevice) which means spriteBatch is
      now hooked to the Graphic Engine and ready to render sprites.
    
  UnloadContent
    - Used to unload content properly. 
    
  Update
    - This is where ALL game logic. You can alter the update frequency, but remember that 
      DRAW function will also be updated at the same frequency. 
      
  Draw
    - This is where all draw magic happends. So with spriteBatch.Draw("image",rectangle.. you can draw everything. 
      Rectangle is there for collision calcutation and so on. 
      
   These functions are then passed down to all classes and objects, which you can read more about below, but
   remember to check out MonoGame at http://www.monogame.net/
      
      
 ## Overview
   
   I've chosen to use a regular but very simple game structure. To keep Game1.cs clean and be able to scale the project,
   a Scene class is used as a "Level" holder, so if we would like to add a new level, we create a new Scene class. 
   
   
   The scene itself has a ParallaxBackground, a Biker & Houses/Playgrounds to avoid in the game! 
   
   ![Untitled Diagram](https://user-images.githubusercontent.com/4427332/61470195-edada900-a980-11e9-82eb-8661dd1e0203.png)

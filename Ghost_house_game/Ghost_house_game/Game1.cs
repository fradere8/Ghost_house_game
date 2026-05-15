using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Level;
using Player;
using Ghost;
using Ghost_house_game.Source.Controller;

namespace Ghost_house_game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private PlayerModel playerModel;
        private PlayerView playerView;
        private PlayerController playerController;

        private GhostModel ghostModel;
        private GhostView ghostView;
        private GhostController ghostController;

        private LevelModel levelModel;
        
        var spriteSheet = Content.Load<Texture2D>("Sprites/player");

        playerModel = new PlayerModel(new Vector2(100, 400));
        playerView = new PlayerView(spriteSheet);

        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            var playerSprite = Content.Load<Texture2D>("Sprites/player");
            var ghostSprite = Content.Load<Texture2D>("Sprites/ghost");

            playerModel = new PlayerModel(new Vector2(100, 474));
            playerView = new PlayerView(playerSprite);
            playerController = new PlayerController(playerModel);

            ghostModel = new GhostModel(new Vector2(500, 474));
            ghostView = new GhostView(ghostSprite);
            ghostController = new GhostController(ghostModel, playerModel);

            levelModel = new LevelModel();
            levelView = new LevelView();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            playerController.Update(levelModel, deltaTime);
            ghostController.Update(levelModel, deltaTime);

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            levelView.Draw(spriteBatch, levelModel.Walls, levelModel.Objects);
            ghostView.Draw(spriteBatch, ghostModel.Bounds);
            playerView.Draw(spriteBatch, playerModel.Bounds);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

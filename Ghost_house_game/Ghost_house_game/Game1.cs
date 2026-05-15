using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Player;
using Level;

namespace Ghost_house_game;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private PlayerModel playerModel;
    private PlayerView playerView;
    private PlayerController playerController;
    private LevelModel levelModel;
    private LevelView levelView;


    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        graphics.PreferredBackBufferWidth = 1280;
        graphics.PreferredBackBufferHeight = 720;
        graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        var spriteSheet = Content.Load<Texture2D>("Sprites/player");

        playerModel = new PlayerModel(new Vector2(100, 400));
        playerView = new PlayerView(spriteSheet);
        playerController = new PlayerController(playerModel);

        levelModel = new LevelModel();
        levelView = new LevelView();
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        playerController.Update(levelModel, deltaTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        levelView.Draw(spriteBatch, levelModel.Walls, levelModel.Objects);
        playerView.Draw(spriteBatch, playerModel.Bounds);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}

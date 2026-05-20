using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Player;
using Level;
using Ghost;
using Health;

namespace Ghost_house_game;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Texture2D pixel;
    private PlayerModel playerModel;
    private PlayerView playerView;
    private PlayerController playerController;
    private LevelModel levelModel;
    private LevelView levelView;
    private GhostModel ghostModel;
    private GhostView ghostView;
    private GhostController ghostController;

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
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        pixel = new Texture2D(GraphicsDevice, 1, 1);
        pixel.SetData(new[] { Color.White });

        var playerSprite = Content.Load<Texture2D>("Sprites/player");
        var ghostSprite = Content.Load<Texture2D>("Sprites/ghost");

        playerModel = new PlayerModel(new Vector2(100, 400));
        playerView = new PlayerView(playerSprite);
        playerController = new PlayerController(playerModel);

        ghostModel = new GhostModel(new Vector2(500, 400));
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
        playerController.Update(levelModel, ghostModel, deltaTime);
        ghostController.Update(levelModel, deltaTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        levelView.Draw(spriteBatch, levelModel.Walls, levelModel.Objects);
        ghostView.Draw(spriteBatch, ghostModel.Bounds, ghostModel.IsFacingRight);
        playerView.Draw(spriteBatch, playerModel.Bounds, playerModel.IsFacingRight);
        HealthBarView.Draw(spriteBatch, pixel, playerModel.Position, playerModel.Width, playerModel.CurrentHealth, playerModel.MaxHealth);
        HealthBarView.Draw(spriteBatch, pixel, ghostModel.Position, ghostModel.Width, ghostModel.CurrentHealth, ghostModel.MaxHealth);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}

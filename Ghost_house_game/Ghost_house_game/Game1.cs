using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Player;
using Room;

namespace Ghost_house_game;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private PlayerModel playerModel;
    private PlayerView playerView;
    private PlayerController playerController;
    private RoomModel roomModel;
    private RoomView roomView;


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

        playerModel = new PlayerModel(new Vector2(100, 410));
        playerView = new PlayerView(spriteSheet);
        playerController = new PlayerController(playerModel);

        roomModel = new RoomModel();
        roomView = new RoomView();
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        playerController.Update(roomModel, deltaTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        roomView.Draw(spriteBatch, roomModel);
        playerView.Draw(spriteBatch, playerModel);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}

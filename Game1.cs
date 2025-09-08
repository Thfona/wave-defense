using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WaveDefense;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private static readonly int screenWidth = 1280;
    private static readonly int screenHeight = 720;

    private Texture2D playerSprite;
    private Texture2D walkDownSprite;
    private Texture2D walkLeftSprite;
    private Texture2D walkRightSprite;
    private Texture2D walkUpSprite;

    private Texture2D backgroundSprite;
    private Texture2D ballSprite;
    private Texture2D skullSprite;

    private readonly Player player = new();

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        graphics.PreferredBackBufferWidth = screenWidth;
        graphics.PreferredBackBufferHeight = screenHeight;
        graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        playerSprite = Content.Load<Texture2D>("player/player");
        walkDownSprite = Content.Load<Texture2D>("player/walkDown");
        walkLeftSprite = Content.Load<Texture2D>("player/walkLeft");
        walkRightSprite = Content.Load<Texture2D>("player/walkRight");
        walkUpSprite = Content.Load<Texture2D>("player/walkUp");

        backgroundSprite = Content.Load<Texture2D>("background");
        ballSprite = Content.Load<Texture2D>("ball");
        skullSprite = Content.Load<Texture2D>("skull");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        player.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();

        spriteBatch.Draw(backgroundSprite, new Vector2(-500, -500), Color.White);
        spriteBatch.Draw(playerSprite, player.Position, Color.White);

        spriteBatch.End();

        base.Draw(gameTime);
    }
}

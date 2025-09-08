using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WaveDefense;

public class Player
{
    private Vector2 _position = new(500, 300);
    private static readonly int speed = 300;
    private Direction direction = Direction.Down;
    private bool isMoving;

    public Vector2 Position
    {
        get => _position;
    }

    public void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        isMoving = false;

        if (keyboardState.IsKeyDown(Keys.Up))
        {
            direction = Direction.Up;
            isMoving = true;
        }

        if (keyboardState.IsKeyDown(Keys.Down))
        {
            direction = Direction.Down;
            isMoving = true;
        }

        if (keyboardState.IsKeyDown(Keys.Left))
        {
            direction = Direction.Left;
            isMoving = true;
        }

        if (keyboardState.IsKeyDown(Keys.Right))
        {
            direction = Direction.Right;
            isMoving = true;
        }

        if (isMoving)
        {
            switch (direction)
            {
                case Direction.Up:
                    _position.Y -= speed * deltaTime;
                    break;
                case Direction.Down:
                    _position.Y += speed * deltaTime;
                    break;
                case Direction.Left:
                    _position.X -= speed * deltaTime;
                    break;
                case Direction.Right:
                    _position.X += speed * deltaTime;
                    break;
            }
        }
    }

    public void SetX(float newX)
    {
        _position.X = newX;
    }

    public void SetY(float newY)
    {
        _position.Y = newY;
    }
}

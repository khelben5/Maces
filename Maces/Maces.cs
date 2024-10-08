﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;
using System.Collections.Generic;

namespace Maces;

public class Maces : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private AssetsGenerator _assetsGenerator;
    private Texture2D _wallSprite;
    private GameEngine _engine;

    public Maces()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _engine = new GameEngine();
        int size = _engine.getCanvasSize();
        _graphics.PreferredBackBufferWidth = size;
        _graphics.PreferredBackBufferHeight = size;
        _graphics.ApplyChanges();
        _assetsGenerator = new AssetsGenerator();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _wallSprite = _assetsGenerator.CreateGrayscaleTexture(_graphics.GraphicsDevice, 5, 5, 128);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.BlanchedAlmond);

        IEnumerable<WallRenderInfo> wallsRenderInfo = _engine.ComputeWallsRenderInfo();

        _spriteBatch.Begin();
        DrawWalls(wallsRenderInfo);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void DrawWalls(IEnumerable<WallRenderInfo> wallsRenderInfo)
    {
        foreach (var wallRenderInfo in wallsRenderInfo)
        {
            _spriteBatch.Draw(
                _wallSprite,
                new Rectangle(
                    new Point(wallRenderInfo.x, wallRenderInfo.y),
                    new Point(wallRenderInfo.width, wallRenderInfo.height)
                ),
                Color.White
            );
        }
    }
}

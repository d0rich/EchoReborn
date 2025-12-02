using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace EchoReborn.UI.Characters;

public abstract class CharacterAnimationBase<T> where T : System.Enum
{
    private Dictionary<T, Texture2D> _spriteSheets;
    private T _currentState;
    private int _currentFrame;
    private float _frameTime;
    private float _timeElapsed;

    private readonly string _spritesFolder;

    private readonly Dictionary<T, int> _frameCount;

    private readonly Dictionary<T, string> _animationFileNames;
    
    private Vector2 _rawPosition;
    private float _scale;
    private bool _loop;
    private bool _isPlaying;
    
    public T CurrentState
    {
        get => _currentState;
        set
        {
            if (!EqualityComparer<T>.Default.Equals(_currentState, value))
            {
                _currentState = value;
                _currentFrame = 0;
                _timeElapsed = 0;
                _isPlaying = true;
            }
        }
    }
    
    public Vector2 Position
    {
        get
        {
            return new Vector2(
                _rawPosition.X + (FrameSize.X * _scale) / 2,
                _rawPosition.Y + FrameSize.Y * _scale
            );
        }
        set
        {
            _rawPosition = new Vector2(
                value.X - (FrameSize.X * _scale) / 2,
                value.Y - FrameSize.Y * _scale
            );
        }
    }
    
    public Vector2 RawPosition { get => _rawPosition; set => _rawPosition = value; }
    
    public float Scale { get => _scale; set => _scale = value; }
    
    public bool Loop { get => _loop; set => _loop = value; }
    
    public bool IsPlaying => _isPlaying;
    
    protected CharacterAnimationBase(
        string spritesFolder, 
        T defaultState,
        Dictionary<T, int> frameCount,
        Dictionary<T, string> animationFileNames
        )
    {
        _frameCount = frameCount;
        _animationFileNames = animationFileNames;
        _spritesFolder = spritesFolder;
        _spriteSheets = new Dictionary<T, Texture2D>();
        _currentState = defaultState;
        _currentFrame = 0;
        _frameTime = 1f / 10f;
        _timeElapsed = 0;
        _rawPosition = Vector2.Zero;
        _scale = 1f;
        _loop = true;
        _isPlaying = true;
    }
    
    public void Draw(GameTime gameTime)
    {
        if (!_isPlaying)
            return;
        DefineCurrentFrame(gameTime);
        
        var spriteBatch = DrawingContext.SpriteBatch;
        
        if (!_spriteSheets.ContainsKey(_currentState))
            return;
            
        Texture2D spriteSheet = _spriteSheets[_currentState];
        int frameWidth = spriteSheet.Width / _frameCount[_currentState];
        int frameHeight = spriteSheet.Height;
        
        Rectangle sourceRectangle = new Rectangle(
            _currentFrame * frameWidth,
            0,
            frameWidth,
            frameHeight
        );
        
        spriteBatch.Draw(
            spriteSheet,
            _rawPosition,
            sourceRectangle,
            Color.White,
            0f,
            Vector2.Zero,
            _scale,
            SpriteEffects.None,
            0f
        );
    }
    
    public void SwitchAnimation(T state, bool loop = true)
    {
        LoadSpriteSheet(state);
        
        _loop = loop;
        CurrentState = state;
    }
    
    public void Stop()
    {
        _isPlaying = false;
    }
    
    public void Reset()
    {
        _currentFrame = 0;
        _timeElapsed = 0;
        _isPlaying = true;
    }
    
    private void LoadSpriteSheet(T state)
    {
        if (_spriteSheets.ContainsKey(state))
            return;
            
        string animationName = _animationFileNames.TryGetValue(state, out var fileName) ? fileName : "Idle";
        string contentPath = $"{_spritesFolder}/{animationName}";
        
        Texture2D texture = DrawingContext.ContentManager.Load<Texture2D>(contentPath);
        _spriteSheets[state] = texture;
    }

    private Vector2 FrameSize
    {
        get
        {
            if (!_spriteSheets.ContainsKey(_currentState))
            {
                LoadSpriteSheet(_currentState);
            }
            Texture2D spriteSheet = _spriteSheets[_currentState];
            int frameWidth = spriteSheet.Width / _frameCount[_currentState];
            int frameHeight = spriteSheet.Height;
            return new Vector2(frameWidth, frameHeight);
        }
    }

    private void DefineCurrentFrame(GameTime gameTime)
    {
        _timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        if (_timeElapsed >= _frameTime)
        {
            _timeElapsed -= _frameTime;
            _currentFrame++;
            
            int maxFrames = _frameCount[_currentState];
            
            if (_currentFrame >= maxFrames)
            {
                if (_loop)
                {
                    _currentFrame = 0;
                }
                else
                {
                    _currentFrame = maxFrames - 1;
                    _isPlaying = false;
                }
            }
        }
    }
}
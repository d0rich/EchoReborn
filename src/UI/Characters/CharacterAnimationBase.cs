using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace EchoReborn.UI.Characters;

public abstract class CharacterAnimationBase<T> where T : System.Enum
{
    public enum Direction
    {
        Left,
        Right
    }

    private Dictionary<T, Texture2D> _spriteSheets;
    private T _currentState;
    private readonly T _defaultState;
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
    private bool _toSwitchBackToDefault;

    public Direction FacingDirection { get; protected set; } = Direction.Right;
    
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
        get => RawToLogicalPosition(_rawPosition);
        set => _rawPosition = LogicalToRawPosition(value);
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
        _defaultState = defaultState;
        _currentFrame = 0;
        _frameTime = 1f / 10f;
        _timeElapsed = 0;
        _rawPosition = Vector2.Zero;
        _scale = 1f;
        _loop = true;
        _isPlaying = true;
        _toSwitchBackToDefault = false;
    }

    public void DrawCopy(Vector2 position)
    {
        Draw(new GameTime(), position);
    }
    
    public void Draw(GameTime gameTime, Vector2? position = null)
    {
        if (!position.HasValue)
        {
            position = RawToLogicalPosition(RawPosition);
        }
        if (_isPlaying) DefineCurrentFrame(gameTime);
        
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
            LogicalToRawPosition(position.Value),
            sourceRectangle,
            Color.White,
            0f,
            Vector2.Zero,
            _scale,
            FacingDirection == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally,
            0f
        );
    }
    
    public void SwitchAnimation(T state, bool loop = true, bool playOnce = false)
    {
        LoadSpriteSheet(state);
        
        Reset();
        _loop = loop;
        _toSwitchBackToDefault = playOnce;
        CurrentState = state;
    }

    protected void PlayLoop(T state)
    {
        SwitchAnimation(state, true, false);
    }

    protected void PlayOnce(T state)
    {
        SwitchAnimation(state, false, true);
    }

    protected void PlayAndFreeze(T state)
    {
        SwitchAnimation(state, false, false);
    }
    
    protected void Stop()
    {
        _isPlaying = false;
    }
    
    protected void Reset()
    {
        _currentFrame = 0;
        _timeElapsed = 0;
        _isPlaying = true;
    }

    private Vector2 RawToLogicalPosition(Vector2 rawPosition)
    {
        return new Vector2(
            rawPosition.X + (FrameSize.X * _scale) / 2,
            rawPosition.Y + FrameSize.Y * _scale
        );
    }

    private Vector2 LogicalToRawPosition(Vector2 logicalPosition)
    {
        return new Vector2(
            logicalPosition.X - (FrameSize.X * _scale) / 2,
            logicalPosition.Y - FrameSize.Y * _scale
        );
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
                else if (_toSwitchBackToDefault)
                {
                    SwitchAnimation(_defaultState, true, false);
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
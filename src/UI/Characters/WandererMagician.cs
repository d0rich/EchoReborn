using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace EchoReborn.UI.Characters;

public enum WandererAnimationState
{
    Idle,
    Walk,
    Run,
    Jump,
    Attack1,
    Attack2,
    MagicSphere,
    MagicArrow,
    Hurt,
    Dead
}

public class WandererMagicianAnimation
{
    private Dictionary<WandererAnimationState, Texture2D> _spriteSheets;
    private WandererAnimationState _currentState;
    private int _currentFrame;
    private float _frameTime;
    private float _timeElapsed;
    
    private readonly Dictionary<WandererAnimationState, int> _frameCount = new()
    {
        { WandererAnimationState.Idle, 8 },
        { WandererAnimationState.Walk, 7 },
        { WandererAnimationState.Run, 8 },
        { WandererAnimationState.Jump, 8 },
        { WandererAnimationState.Attack1, 7 },
        { WandererAnimationState.Attack2, 9 },
        { WandererAnimationState.MagicSphere, 16 },
        { WandererAnimationState.MagicArrow, 6 },
        { WandererAnimationState.Hurt, 4 },
        { WandererAnimationState.Dead, 4 }
    };
    
    private static readonly Dictionary<WandererAnimationState, string> AnimationFileNames = new()
    {
        { WandererAnimationState.Idle, "Idle" },
        { WandererAnimationState.Walk, "Walk" },
        { WandererAnimationState.Run, "Run" },
        { WandererAnimationState.Jump, "Jump" },
        { WandererAnimationState.Attack1, "Attack_1" },
        { WandererAnimationState.Attack2, "Attack_2" },
        { WandererAnimationState.MagicSphere, "Magic_sphere" },
        { WandererAnimationState.MagicArrow, "Magic_arrow" },
        { WandererAnimationState.Hurt, "Hurt" },
        { WandererAnimationState.Dead, "Dead" }
    };
    
    private Vector2 _rawPosition;
    private float _scale;
    private bool _loop;
    private bool _isPlaying;
    
    public WandererAnimationState CurrentState
    {
        get => _currentState;
        set
        {
            if (_currentState != value)
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
    
    public WandererMagicianAnimation(float framesPerSecond = 10f)
    {
        _spriteSheets = new Dictionary<WandererAnimationState, Texture2D>();
        _currentState = WandererAnimationState.Idle;
        _currentFrame = 0;
        _frameTime = 1f / framesPerSecond;
        _timeElapsed = 0;
        _rawPosition = Vector2.Zero;
        _scale = 1f;
        _loop = true;
        _isPlaying = true;
    }
    
    public void Update(GameTime gameTime)
    {
        if (!_isPlaying)
            return;
        DefineCurrentFrame(gameTime);
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
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
    
    public void SwitchAnimation(WandererAnimationState state, bool loop = true)
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
    
    private void LoadSpriteSheet(WandererAnimationState state)
    {
        if (_spriteSheets.ContainsKey(state))
            return;
            
        string animationName = AnimationFileNames.TryGetValue(state, out var fileName) ? fileName : "Idle";
        string contentPath = $"Characters/WandererMagician/{animationName}";
        
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


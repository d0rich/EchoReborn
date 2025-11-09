using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace EchoReborn.UI.Characters;

/// <summary>
/// Animation states for the Wanderer Magician character.
/// </summary>
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

/// <summary>
/// Handles animation playback for the Wanderer Magician character using sprite sheets.
/// </summary>
public class WandererMagicianAnimation
{
    private Dictionary<WandererAnimationState, Texture2D> _spriteSheets;
    private WandererAnimationState _currentState;
    private int _currentFrame;
    private float _frameTime;
    private float _timeElapsed;
    
    // Animation frame counts for each state (these may need adjustment based on actual sprite sheets)
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
    
    private Vector2 _position;
    private float _scale;
    private bool _loop;
    private bool _isPlaying;
    
    /// <summary>
    /// Gets or sets the current animation state.
    /// </summary>
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
    
    /// <summary>
    /// Gets or sets the position where the character is drawn.
    /// </summary>
    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }
    
    /// <summary>
    /// Gets or sets the scale of the character.
    /// </summary>
    public float Scale
    {
        get => _scale;
        set => _scale = value;
    }
    
    /// <summary>
    /// Gets or sets whether the animation should loop.
    /// </summary>
    public bool Loop
    {
        get => _loop;
        set => _loop = value;
    }
    
    /// <summary>
    /// Gets whether the animation is currently playing.
    /// </summary>
    public bool IsPlaying => _isPlaying;
    
    /// <summary>
    /// Creates a new WandererMagician animation controller.
    /// </summary>
    /// <param name="framesPerSecond">Animation speed in frames per second.</param>
    public WandererMagicianAnimation(float framesPerSecond = 10f)
    {
        _spriteSheets = new Dictionary<WandererAnimationState, Texture2D>();
        _currentState = WandererAnimationState.Idle;
        _currentFrame = 0;
        _frameTime = 1f / framesPerSecond;
        _timeElapsed = 0;
        _position = Vector2.Zero;
        _scale = 1f;
        _loop = true;
        _isPlaying = true;
    }
    
    /// <summary>
    /// Loads a sprite sheet for a specific animation state.
    /// </summary>
    /// <param name="state">The animation state.</param>
    /// <param name="texture">The sprite sheet texture.</param>
    public void LoadSpriteSheet(WandererAnimationState state, Texture2D texture)
    {
        _spriteSheets[state] = texture;
    }
    
    /// <summary>
    /// Updates the animation.
    /// </summary>
    /// <param name="gameTime">Game timing information.</param>
    public void Update(GameTime gameTime)
    {
        if (!_isPlaying)
            return;
            
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
    
    /// <summary>
    /// Draws the current animation frame.
    /// </summary>
    /// <param name="spriteBatch">The sprite batch to draw with.</param>
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
            _position,
            sourceRectangle,
            Color.White,
            0f,
            Vector2.Zero,
            _scale,
            SpriteEffects.None,
            0f
        );
    }
    
    /// <summary>
    /// Switches to a specific animation, loading the sprite sheet if not already loaded.
    /// </summary>
    /// <param name="state">The animation state to switch to.</param>
    /// <param name="loop">Whether to loop the animation.</param>
    public void SwitchAnimation(WandererAnimationState state, bool loop = true)
    {
        // Load sprite sheet if not already loaded
        if (!_spriteSheets.ContainsKey(state))
        {
            string animationName = GetAnimationFileName(state);
            string contentPath = $"Characters/WandererMagician/{animationName}";
            
            try
            {
                Texture2D texture = DrawingContext.ContentManager.Load<Texture2D>(contentPath);
                LoadSpriteSheet(state, texture);
            }
            catch (Microsoft.Xna.Framework.Content.ContentLoadException)
            {
                // If loading fails, animation won't be available
                return;
            }
        }
        
        _loop = loop;
        CurrentState = state;
    }
    
    /// <summary>
    /// Gets the file name for a specific animation state.
    /// </summary>
    /// <param name="state">The animation state.</param>
    /// <returns>The file name without extension.</returns>
    private string GetAnimationFileName(WandererAnimationState state)
    {
        return state switch
        {
            WandererAnimationState.Idle => "Idle",
            WandererAnimationState.Walk => "Walk",
            WandererAnimationState.Run => "Run",
            WandererAnimationState.Jump => "Jump",
            WandererAnimationState.Attack1 => "Attack_1",
            WandererAnimationState.Attack2 => "Attack_2",
            WandererAnimationState.MagicSphere => "Magic_sphere",
            WandererAnimationState.MagicArrow => "Magic_arrow",
            WandererAnimationState.Hurt => "Hurt",
            WandererAnimationState.Dead => "Dead",
            _ => "Idle"
        };
    }
    
    /// <summary>
    /// Plays a specific animation.
    /// </summary>
    /// <param name="state">The animation state to play.</param>
    /// <param name="loop">Whether to loop the animation.</param>
    public void Play(WandererAnimationState state, bool loop = true)
    {
        _loop = loop;
        CurrentState = state;
    }
    
    /// <summary>
    /// Stops the current animation.
    /// </summary>
    public void Stop()
    {
        _isPlaying = false;
    }
    
    /// <summary>
    /// Resets the animation to the first frame.
    /// </summary>
    public void Reset()
    {
        _currentFrame = 0;
        _timeElapsed = 0;
        _isPlaying = true;
    }
}
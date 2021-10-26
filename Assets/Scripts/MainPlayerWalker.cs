using UnityEngine;

public class MainPlayerWalker
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private PlayerView _playerView;
    private SpriteAnimator _spriteAnimator;

    private float _yVelocity;

    public MainPlayerWalker(PlayerView playerView, SpriteAnimator spriteAnimator)
    {
        _playerView = playerView;
        _spriteAnimator = spriteAnimator;
    }

    public void Update()
    {
        var doJump = Input.GetAxis(Vertical) > 0;
        var xAxisInput = Input.GetAxis(Horizontal);

        var isGoSideWay = Mathf.Abs(xAxisInput) > _playerView.MovingThresh;

        if (isGoSideWay)
        {
            GoSideWay(xAxisInput);
        }

        if (IsGrounded())
        {
            _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, isGoSideWay ? AnimationTracks.walk : AnimationTracks.idle, true, _playerView.AnimationSpeed);

            if (doJump && Mathf.Approximately(_yVelocity, 0))
            {
                _yVelocity = _playerView.JumpStartSpeed;
            }
            else if(_yVelocity < 0)
            {
                _yVelocity = 0;
                MovementPlayer();
            }
        }
        else
        {
            LandingPlayer();
        }
    }

    private void GoSideWay(float xAxisInput)
    {
        _playerView.transform.position += Vector3.right * Time.deltaTime * _playerView.WalkSpeed * (xAxisInput < 0 ? -1 : 1);
        _playerView.SpriteRenderer.flipX = xAxisInput < 0;
    }

    private bool IsGrounded()
    {
        return _playerView.transform.position.y <= _playerView.GroundLevel && _yVelocity <= 0;
    }

    private void MovementPlayer()
    {
        _playerView.transform.position.Change(y: _playerView.GroundLevel);
    }

    private void LandingPlayer()
    {
        _yVelocity += _playerView.Acceleration * Time.deltaTime;

        if(Mathf.Abs(_yVelocity) > _playerView.FlyThresh)
        {
            _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, AnimationTracks.jump, true, _playerView.AnimationSpeed);
        }
        _playerView.transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
    }
}

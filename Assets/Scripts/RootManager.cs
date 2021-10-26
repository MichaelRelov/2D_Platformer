using UnityEngine;

public class RootManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private SpriteRenderer _middleground;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private SpriteAnimationConfig _spriteAnimationConfig;

    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private MainPlayerWalker _mainPlayerWalker;

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera.transform, _background.transform, _middleground.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _mainPlayerWalker = new MainPlayerWalker(_playerView, _spriteAnimator);
    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
        _mainPlayerWalker.Update();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        
    }
}

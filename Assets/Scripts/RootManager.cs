using UnityEngine;

public class RootManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private SpriteRenderer _middleground;

    private ParalaxManager _paralaxManager;


    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera.transform, _background.transform, _middleground.transform);
    }

    private void Update()
    {
        _paralaxManager.Update();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        
    }
}

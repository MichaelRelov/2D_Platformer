using UnityEngine;

public class ParalaxManager
{
    private Transform _camera;
    private Vector3 _cameraStartPosition;

    private Transform _background;
    private Vector3 _backStartPosition;
    private const float BACK_COEF = 0.9f;

    private Transform _middleground;
    private Vector3 _middleStartPosition;
    private const float MIDDLE_COEF = 0.7f;

    public ParalaxManager(Transform camera, Transform background, Transform middleground)
    {
        _camera = camera;
        _background = background;
        _middleground = middleground;

        _cameraStartPosition = _camera.transform.position;
        _backStartPosition = _background.transform.position;
        _middleStartPosition = _middleground.transform.position;
    }

    public void Update()
    {
        _background.position = _backStartPosition + (_camera.position - _cameraStartPosition) * BACK_COEF;
        _middleground.position = _middleStartPosition + (_camera.position - _cameraStartPosition) * MIDDLE_COEF;
    }
}
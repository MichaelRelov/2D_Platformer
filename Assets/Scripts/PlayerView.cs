using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Settings")]
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _animationSpeed = 8f;
    [SerializeField] private float _jumpStartSpeed = 8f;
    [SerializeField] private float _movingThresh = 0.1f; //for joystick
    [SerializeField] private float _flyThresh = 1f;
    [SerializeField] private float _groundLevel = 0.5f;
    [SerializeField] private float _acceleration = -10f;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    public float WalkSpeed => _walkSpeed;
    public float AnimationSpeed => _animationSpeed;
    public float JumpStartSpeed => _jumpStartSpeed;
    public float MovingThresh => _movingThresh;
    public float FlyThresh => _flyThresh;
    public float GroundLevel => _groundLevel;
    public float Acceleration => _acceleration;
}
using UnityEngine;

public class CannonView : MonoBehaviour
{
    [SerializeField] private Transform _barrelTransform;

    public Transform BarrelTransform => _barrelTransform;
}

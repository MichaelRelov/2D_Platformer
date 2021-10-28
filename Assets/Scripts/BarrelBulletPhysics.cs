using UnityEngine;

public class BarrelBulletPhysics
{
    private BarrelBulletView _barrelBulletView;
    
    public BarrelBulletPhysics(BarrelBulletView barrelBulletView)
    {
        _barrelBulletView = barrelBulletView;
        _barrelBulletView.SetVisible(false);
    }

    public void ThrowBarrel(Vector3 position, Vector3 velosity)
    {
        _barrelBulletView.SetVisible(false);
        _barrelBulletView.transform.position = position;
        _barrelBulletView.Rigidbody.velocity = Vector2.zero;
        _barrelBulletView.Rigidbody.angularVelocity = 0;
        _barrelBulletView.Rigidbody.AddForce(velosity, ForceMode2D.Impulse);
        _barrelBulletView.SetVisible(true);
    }
}
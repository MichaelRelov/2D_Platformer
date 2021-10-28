using System.Collections.Generic;
using UnityEngine;

public class BarrelBulletsEmitter
{
    private const float DELAY = 2f;
    private const float STARTSPEED = 1f;

    private List<BarrelBulletPhysics> _barrelBullets = new List<BarrelBulletPhysics>();
    private Transform _transform;
    private int _currentIndex;
    private float _timeTillNextBullet;

    public BarrelBulletsEmitter(List<BarrelBulletView> barrelBulletViews, Transform transform)
    {
        _transform = transform;

        foreach (var barrelBulletView in barrelBulletViews)
        {
            _barrelBullets.Add(new BarrelBulletPhysics(barrelBulletView));
        }
    }

    public void Update()
    {
        if(_timeTillNextBullet > 0)
        {
            _timeTillNextBullet -= Time.deltaTime;
        }
        else
        {
            _timeTillNextBullet = DELAY;
            _barrelBullets[_currentIndex].ThrowBarrel(_transform.position, _transform.up * STARTSPEED);
            _currentIndex++;
            if(_currentIndex >= _barrelBullets.Count)
            {
                _currentIndex = 0;
            }
        }
    }
}
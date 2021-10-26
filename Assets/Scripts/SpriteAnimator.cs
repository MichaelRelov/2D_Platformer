using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator
{
    private SpriteAnimationConfig _config;
    private Dictionary<SpriteRenderer, CustomAnimation> _activeAnimations = new Dictionary<SpriteRenderer, CustomAnimation>();

    public SpriteAnimator(SpriteAnimationConfig config)
    {
        _config = config;
    }

    public void StartAnimation(SpriteRenderer spriteRenderer, AnimationTracks track, bool loop, float speed)
    {
        if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
        {
            animation.Loop = loop;
            animation.Speed = speed;
            animation.Sleeps = false;

            if (animation.Track == track)
                return;

            animation.Track = track;
            animation.Sprites = _config.Sequences.Find(sequence => sequence.AnimationTrack == track).Sprites;
            animation.Counter = 0;
        }
        else
        {
            _activeAnimations.Add(spriteRenderer, new CustomAnimation
            {
                Track = track,
                Sprites = _config.Sequences.Find(sequence => sequence.AnimationTrack == track).Sprites,
                Loop = loop,
                Speed = speed
            });
        }
    }

    public void StopAnimation(SpriteRenderer sprite)
    {
        if (_activeAnimations.ContainsKey(sprite))
            _activeAnimations.Remove(sprite);
    }

    public void Update()
    {
        foreach (var animation in _activeAnimations)
        {
            animation.Value.Update();
            animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
        }
    }

    public void Dispose()
    {
        _activeAnimations.Clear();
    }
}
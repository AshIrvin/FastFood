using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    // Player walks into shop
    // Look at tablets, presses button
    // Walks over and tries the next tablet
    // 

    [SerializeField] private GameObject _player;

    private Animator _anim;


    private void Start()
    {
        _anim = _player.GetComponent<Animator>();
    }

    public void PlayAnimation(string animationName)
    {
        _anim.Play(animationName, -1);
    }

    // This way or set bool state way?
/*    private void QueueTestAnimations()
    {
        _anim.PlayQueued("CubeBob", QueueMode.CompleteOthers);
        _anim.PlayQueued("CubeFlip", QueueMode.CompleteOthers);
        _anim.PlayQueued("CubeShuffle", QueueMode.CompleteOthers);
    }*/
}

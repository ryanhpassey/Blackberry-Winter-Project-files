using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkRed : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void PlayBlinkAnimation()
    {
        _animator.Play("BlinkRed");
    }

    void OnEnable()
    {
        HebeHP.OnDamaged += PlayBlinkAnimation;
    }

    void OnDisable()
    {
        HebeHP.OnDamaged -= PlayBlinkAnimation;
    }    
}

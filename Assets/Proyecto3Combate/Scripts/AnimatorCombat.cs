using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorCombat : MonoBehaviour
{
    private List<Action> activationEvents = new List<Action>();
    Animator anim;

    protected virtual void InitializeEvents()
    {
        activationEvents.Add(() =>
        {
            anim.SetBool("CanControl", true);
        });
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        InitializeEvents();
    }

    public void ActivateAnimator(int eventId)
    {
        activationEvents[eventId]?.Invoke();
    }
}

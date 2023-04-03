using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simps;

namespace Simps
{
    public static class AnimatorExtensions
    {
        public static void CrossFadeQueued(this Animator animator, string stateName, float transitionDuration, int layer, float normalizedTimeOffset, float normalizedTransitionTime, float fixedTime)
        {
            animator.CrossFade(stateName, transitionDuration, layer, normalizedTimeOffset);
            animator.Update(fixedTime);
            animator.CrossFade(stateName, transitionDuration, layer, normalizedTransitionTime);
        }
    } 
}
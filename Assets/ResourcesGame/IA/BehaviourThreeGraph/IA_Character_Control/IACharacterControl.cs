using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IACharacterControl : MonoBehaviour
{
    public NavMeshAgent agent { get; set; }
    public Health health { get; set; }
    public IAEyeBase AIEye { get; set; }
    protected ThirdPersonAnimationBase TPAnimation;
    public virtual void LoadComponent()
    {
        //if (agent == null)
            agent = GetComponent<NavMeshAgent>();

       // if (health == null)
            health = GetComponent<Health>();

        //if (AIEye == null)
            AIEye = GetComponent<IAEyeBase>();

            TPAnimation = GetComponent<ThirdPersonAnimationBase>();
    }
}

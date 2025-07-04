using UnityEngine;
using UnityEngine.AI;

public class ThirdPersonAnimationCivil : ThirdPersonAnimationBase
{
    private static readonly int ForwardHash = Animator.StringToHash("Forward");
    private static readonly int StrafeHash = Animator.StringToHash("Strafe");

    private void Awake()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }
    public override void Stop()
    {
        animator.SetFloat(ForwardHash, 0, 0.1f, Time.deltaTime);
        animator.SetFloat(StrafeHash, 0, 0.1f, Time.deltaTime);
    }
    public override void Mover(Vector3 direccion)
    {
        Vector3 velocity = agent.velocity;
        float speed = velocity.magnitude;

        if (speed < 0.05f)
        {
            animator.SetFloat(ForwardHash, 0f);
            animator.SetFloat(StrafeHash, 0f);
            return;
        }

        Vector3 localVelocity = transform.InverseTransformDirection(velocity.normalized);
        float forward = Mathf.Clamp01(localVelocity.z);
        float strafe = localVelocity.x;

        animator.SetFloat(ForwardHash, forward, 0.1f, Time.deltaTime);
        animator.SetFloat(StrafeHash, strafe, 0.1f, Time.deltaTime);
    }

    public override void Dead()
    {
        agent.isStopped = true;
    }
}

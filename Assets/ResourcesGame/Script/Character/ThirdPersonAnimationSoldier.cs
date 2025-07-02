using UnityEngine;
using UnityEngine.AI;

public class ThirdPersonAnimationSoldier : ThirdPersonAnimationBase
{
    private static readonly int ForwardHash = Animator.StringToHash("Forward");
    private static readonly int StrafeHash = Animator.StringToHash("Strafe");
    private static readonly int DeadHash = Animator.StringToHash("Dead");
    private static readonly int AimHash = Animator.StringToHash("Aim");

    public bool isAiming = false;

    public bool Aiming { get => animator.GetBool("Aim"); }
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

        // Dirección local del movimiento
        Vector3 localVelocity = transform.InverseTransformDirection(velocity.normalized);

        float forward = 0f;
        float strafe = 0f;

        if (isAiming)
        {
            // Con Aim activo: Forward [-1, 1], Strafe [-1, 1]
            forward = localVelocity.z;
            strafe = localVelocity.x;
        }
        else
        {
            // Sin Aim: Solo forward en [0, 1], sin strafe
            forward = Mathf.Clamp01(localVelocity.z);
            strafe = 0f;
        }

        animator.SetFloat(ForwardHash, forward, 0.1f, Time.deltaTime);
        animator.SetFloat(StrafeHash, strafe, 0.1f, Time.deltaTime);
    }

    public override void Dead()
    {
        animator.SetTrigger(DeadHash);
        agent.isStopped = true;
    }

    /// <summary>
    /// Activa o desactiva el modo de apuntado.
    /// </summary>
    /// <param name="aim">Verdadero para activar Aim, falso para desactivarlo.</param>
    public void SetAim(bool aim)
    {
        isAiming = aim;
        animator.SetBool(AimHash, aim);
    }
}

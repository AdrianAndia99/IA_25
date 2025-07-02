using UnityEngine;
using UnityEngine.AI;

public class ThirdPersonAnimationZombie : ThirdPersonAnimationBase
{
    private static readonly int ForwardHash = Animator.StringToHash("Forward");
    private static readonly int AttackHash = Animator.StringToHash("Attack");
    private static readonly int DeadHash = Animator.StringToHash("Dead");

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
    }
    public override void Mover(Vector3 direccion)
    {
        Vector3 velocity = agent.velocity;
        Debug.Log(velocity.magnitude);
        float speed = velocity.magnitude / agent.speed ;

        //if (speed < 0.05f)
        //{
        //    animator.SetFloat(ForwardHash, 0f);
        //    return;
        //}

        // Dirección local del movimiento
        //Vector3 localVelocity = transform.InverseTransformDirection(velocity.normalized);

        speed = Mathf.Clamp01(speed);

        animator.SetFloat(ForwardHash, speed, 0.1f, Time.deltaTime);
        
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
    public void Attack()
    {
        animator.SetBool(AttackHash, true);
    }
}

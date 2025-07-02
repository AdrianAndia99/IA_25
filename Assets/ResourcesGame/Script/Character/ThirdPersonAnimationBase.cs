using UnityEngine;
using UnityEngine.AI;

public abstract class ThirdPersonAnimationBase : MonoBehaviour
{
    [Header("Componentes Base")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected NavMeshAgent agent;
    /// <summary>
    /// Mueve al personaje en una direcci�n espec�fica.
    /// </summary>
    /// <param name="direccion">Direcci�n de movimiento.</param>
    public virtual void LoadComponent()
    {
        animator=GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    /// <summary>
    /// Mueve al personaje en una direcci�n espec�fica.
    /// </summary>
    /// <param name="direccion">Direcci�n de movimiento.</param>
    public abstract void Mover(Vector3 direccion);

    /// <summary>
    /// Ejecuta la animaci�n de muerte.
    /// </summary>
    public abstract void Dead();
    public abstract void Stop();
}

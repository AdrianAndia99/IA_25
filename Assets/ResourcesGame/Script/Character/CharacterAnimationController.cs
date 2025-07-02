using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        // Obtener la velocidad actual del agente (magnitude de la velocidad)
        float currentSpeed = agent.velocity.magnitude;

        // Normalizar la velocidad entre 0 y 1, dividiendo por la velocidad máxima
        float normalizedSpeed = Mathf.Clamp01(currentSpeed / agent.speed);

        // Actualizar el parámetro Forward del Animator
        animator.SetFloat("Forward", normalizedSpeed);
    }
}

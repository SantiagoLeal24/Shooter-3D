using UnityEngine;
using UnityEngine.AI;
using System;

public class ZombieAttackingState : StateMachineBehaviour
{
    Transform player;
    NavMeshAgent agent;

    public float dejardeAtacar = 2.5f;

    public float anguloCorreccion = -20f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        agent = animator.GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }
    }

    

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null) return;

        if (player == null) return;

        // 1. Calculamos la dirección hacia el jugador
        Vector3 direction = player.position - animator.transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            // Calculamos la rotación base (mirar al centro del jugador)
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            
            targetRotation *= Quaternion.Euler(0, anguloCorreccion, 0);

            // Aplicamos la rotación suavemente
            animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, targetRotation, 5f * Time.deltaTime);
        }

        // chequear que el zombie deje de atacar

        float disntanciaDelPlayer = Vector3.Distance(player.position, animator.transform.position);

        if (disntanciaDelPlayer > dejardeAtacar)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent != null)
        {
            agent.isStopped = false;
        }
    }

   

}

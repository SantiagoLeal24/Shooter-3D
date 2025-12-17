using UnityEngine;
using UnityEngine.AI;

public class ZombieRunningState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float velocidadZombie;

    public float dejardeSeguir = 25f;
    public float distanciaAtaque = 2.5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("¡CUIDADO! No encuentro al Player. ¿Le pusiste el Tag 'Player' a tu personaje?");
        }

        agent = animator.GetComponent<NavMeshAgent>();

        if (agent != null)
        {

            agent.speed = velocidadZombie;

            agent.stoppingDistance = distanciaAtaque;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null || agent == null) return;

        agent.SetDestination(player.position);
        

        float distanciaPlayer = Vector3.Distance(player.position, animator.transform.position);

        //chequeo si el zombie tiene que dejar de perseguir al jugador

        if (distanciaPlayer > dejardeSeguir)
        {
            animator.SetBool("isRunning", false);
        }

        //chequeo si el zombie tiene que atacar al jugador

        if (distanciaPlayer <= distanciaAtaque)

        {
            animator.SetBool("isAttacking", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent != null)
        {
            agent.ResetPath();
        }
    }


}

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
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = velocidadZombie;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
        agent.SetDestination(animator.transform.position);
    }


}

using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (NavMeshAgent))]
public class AnimateMovement : MonoBehaviour {
  Animator anim;
	NavMeshAgent agent;

	void Start () {
    anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update () {
    bool isAgentStopped = agent.velocity.magnitude < 0.15f;
    anim.SetBool("isWalking", !isAgentStopped);
	}
}

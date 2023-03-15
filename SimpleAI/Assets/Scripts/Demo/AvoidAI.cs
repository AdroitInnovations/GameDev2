using UnityEngine;
using System.Collections;

public class AvoidAI : MonoBehaviour {

	public Transform player;
	public bool inRange;

	public float moveRange = 5f;
	public float awareRange = 5f;

	private Transform target;
	private UnityEngine.AI.NavMeshAgent agent;
	Vector3 dirToPlayer;

	void OnEnable () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	
	// Update is called once per frame
	void Update () {
		dirToPlayer = player.position - transform.position;
		float distToPlayer = dirToPlayer.magnitude;
		if (distToPlayer < awareRange) {
			inRange = true;
		} else {
			inRange = false;
		}

		if (inRange) {
			//Debug.Log (direction);
			//NavMeshHit navHit;

			//NavMesh.SamplePosition (player.position - transform.position, out navHit, moveRange, -1);
			float randomMoveVariance = Random.Range (0, moveRange);

			Vector3 newPos = transform.position - dirToPlayer * randomMoveVariance;

			agent.SetDestination (newPos);
		}
	}
}

using UnityEngine;
using System.Collections;

public class BasicNavMeshAgentScript : MonoBehaviour {

	public Transform target;
	NavMeshAgent agent;

	Animator anim;						// Reference to the animator.
//	AudioSource petAudio;				// Reference to the audio source.
	MeshCollider meshCollider;	// Reference to the capsule collider.

	bool isRescued;						// Verifies whether the house-pet has been rescued
//	public int scoreValue = 20;			// amount added to the score when in contact with the target (i.e. player)


//	TODO: double-check difference between Start & Awake functions – determine which is more appropriate in this context.
	void Start () {
//	void Awake () {
		agent = GetComponent<NavMeshAgent> ();

		// Setting up the refernces.
		anim = GetComponent<Animator> ();
//		petAudio = GetComponent<AudioSource> ();
		meshCollider = GetComponent<MeshCollider> ();
	}

	void Update () {
		agent.SetDestination (target.position);

		/* checks to see if houe-pet has been rescued */
		if (isRescued)
			Destroy (gameObject);		// removes house-pet from scene
	}

	void Rescued () {
		// house-pet has been rescued
		isRescued = true;
		anim.SetTrigger ("Rescued");

//		// Increse the score by the score's value
//		ScoreManager.score += scoreValue;
	}

}

/* Note: The following is based off of a seperate CS file made during another Project (IT@JCU, CP3311, 2016)
 * TODO: ONLY TAKE OUT CODE SEGMENTS RELEVANT FOR PROJECT! DELETE REST WHEN DONE!!
 */
//using UnityEngine;
//using System.Collections;
//
//public class EnemyMovement : MonoBehaviour
//{
//	public float detectDistance = 15f;
//	public float attackRange = 1.5f;
//	float distance;					
//    Transform player;               // Reference to the player's position.
//    PlayerHealth playerHealth;      // Reference to the player's health.
//	Transform enemy;				// Reference to this enemy's position.
//    EnemyHealth enemyHealth;        // Reference to this enemy's health.
//	Animator anim;					
//    NavMeshAgent nav;
//
//    void Awake ()
//    {
//        // Set up the references.
//        player = GameObject.FindGameObjectWithTag ("Player").transform;
//		enemy = GetComponent <Transform> ();
//        playerHealth = player.GetComponent <PlayerHealth> ();
//        enemyHealth = GetComponent <EnemyHealth> ();
//        nav = GetComponent <NavMeshAgent> ();
//		anim = GetComponent <Animator> ();
//    }
//
//    void Update ()
//	{	
//		distance = Vector3.Distance (enemy.position, player.position);			// checks how far away the player is
//		//if player is within range enemy detects them
//		if (distance <= detectDistance && distance > attackRange) {
//			anim.SetTrigger ("PlayerDetected");
//			//if player is in attack range
//
//			// If the enemy and the player have health left...
//			if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
//				// ... set the destination of the nav mesh agent to the player.
//				nav.SetDestination (player.position);
//				transform.LookAt (player.position);
//			}
//            // Otherwise...
//            else {
//					// ... disable the nav mesh agent.
//					nav.enabled = false;
//				}
//		}
//		//if enemy in attack range
//		if (distance <= attackRange) {
//			anim.SetTrigger ("PlayerInAttackRange");
//			if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.6f) {
//				playerHealth.TakeDamage (10);
//			}
//		}
//	}
//}
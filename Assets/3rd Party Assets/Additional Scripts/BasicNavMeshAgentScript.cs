using UnityEngine;
using System.Collections;

public class BasicNavMeshAgentScript : MonoBehaviour {

	public Transform target;
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update () {
		agent.SetDestination (target.position);
	}
}

/* Note: The following is based off of 2 seperate CS files made during another Project (IT@JCU, CP3311, 2016)
 * 
 * TODO: ONLY TAKE OUT CODE SEGMENTS RELEVANT FOR PROJECT! DELETE REST WHEN DONE!!
 * 
 */

//using UnityEngine;
//
//public class EnemyHealth : MonoBehaviour
//{
//    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
//    public int currentHealth;                   // The current health the enemy has.
//    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
//    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
//    //public AudioClip deathClip;                 // The sound to play when the enemy dies.
//
//    Animator anim;                              // Reference to the animator.
//    //AudioSource enemyAudio;                     // Reference to the audio source.
//    //ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
//    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
//    bool isDead;                                // Whether the enemy is dead.
//    bool isSinking;                             // Whether the enemy has started sinking through the floor.
//
//    void Awake () {
//        // Setting up the references.
//        anim = GetComponent <Animator> ();
//        //enemyAudio = GetComponent <AudioSource> ();
//        //hitParticles = GetComponentInChildren <ParticleSystem> ();
//        capsuleCollider = GetComponent <CapsuleCollider> ();
//
//        // Setting the current health when the enemy first spawns.
//        currentHealth = startingHealth;
//    }
//
//
//    void Update () {
//        // check if enemy is dead
//		if(isDead)
//        {
//            // ... move the enemy down by the sinkSpeed per second.
//            //transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
//			Destroy (gameObject, 2f);
//        }
//    }
//
//	void OnTriggerEnter(Collider other) {
//		//check if collider is the players punch hit box
//		PlayerHealth health = other.gameObject.GetComponentInParent<PlayerHealth>();
//		if (health != null) {
//			//take damge from the hit
//			TakeDamage (50);
//			//debug checking hitbox
//			print ("hit");
//		} else {
//			print ("miss");
//		}
//	}
//
//    public void TakeDamage (int amount) {
//        // If the enemy is dead...
//        if(isDead)
//            // ... no need to take damage so exit the function.
//            return;
//
//        // Play the hurt sound effect.
//        //enemyAudio.Play ();
//
//        // Reduce the current health by the amount of damage sustained.
//        currentHealth -= amount;
//        
//        // Set the position of the particle system to where the hit was sustained.
//        //hitParticles.transform.position = hitPoint;
//
//        // And play the particles.
//        //hitParticles.Play();
//
//        // If the current health is less than or equal to zero...
//		if (currentHealth <= 0) {
//			// ... the enemy is dead.
//			Death ();
//		} else {
//			//just recoil from the blow, not die
//			anim.SetTrigger("Recoil");
//		}
//    }
//
//    void Death ()
//    {
//        // The enemy is dead.
//        isDead = true;
//
//        // Turn the collider into a trigger so shots can pass through it.
//        capsuleCollider.isTrigger = true;
//
//        // Tell the animator that the enemy is dead.
//        anim.SetTrigger ("Dead");
//
//        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
//        //enemyAudio.clip = deathClip;
//        //enemyAudio.Play ();
//    }
//
//    public void StartSinking () {
//        // Find and disable the Nav Mesh Agent.
//        GetComponent <NavMeshAgent> ().enabled = false;
//
//        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
//        GetComponent <Rigidbody> ().isKinematic = true;
//
//        // The enemy should no sink.
//        isSinking = true;
//
//        // Increase the score by the enemy's score value.
//        //ScoreManager.score += scoreValue;
//
//        // After 2 seconds destory the enemy.
//        Destroy (gameObject, 2f);
//    }
//}



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

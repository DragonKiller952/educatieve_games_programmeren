using UnityEngine;
using System.Collections;
using TMPro;
using System;
using InfimaGames.LowPolyShooterPack;

public class CreatureScript : MonoBehaviour {


    //Used to check if the Creature has been hit
	public bool isHit = false;

	[Header("Customizable Options")]
	//Time before the enemy despawns
	public float despawnTime;

	public AudioSource audioSource;
	public GameObject player;
    public float speed;
    private GameObject textObject;

    public bool playerDetection = false;
    public DateTime nextAttack;
    private float attackDelay = 1f;
    private bool locked = false;
    private bool killRegistered = false;

    Animator animator;

    private void Start()
    {
        //Register where the text is located
        animator = GetComponent<Animator>();
        textObject = transform.GetChild(15).gameObject;

        //Let the enemy and the text look towards the player
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        textObject.transform.rotation = rotation;

        //Plan when the enemy can next attack
        nextAttack = DateTime.Now;
    }

    private void Update () {

        //Rotate the text towards the player
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        if (textObject)
        {
            textObject.transform.rotation = rotation;
        }

        //If the target is hit
        if (isHit == true) 
		{
            //If death has not been registered
            if (!killRegistered)
            {
                killRegistered = !killRegistered;

                //Register kill via the enemy spawner
                transform.parent.GetComponent<EnemySpawner>().AddKill();
            }

            //Play death animation and let enemy despawn
			animator.SetBool("isHit", true);
			GetComponent<Collider>().enabled = false;
            Destroy(textObject);
			Destroy(gameObject, despawnTime);
        }
        //If able to attack
        else if (nextAttack <= DateTime.Now && playerDetection)
        {
            //Attack and plan new attack
            animator.SetTrigger("Attack");
            nextAttack = DateTime.Now.AddSeconds(System.Convert.ToDouble(attackDelay));
            player.GetComponent<Character>().TakeDamage(1);
        }
        //If enemy not locked by animation
        else if (!locked)
        {
            //Rotate the enemy towards the player
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime * 2);

            //Move the enemy towards the player
            Vector3 movement = transform.rotation * (new Vector3(0, 0, 1.5f) * speed * Time.deltaTime);
            transform.GetComponent<Rigidbody>().MovePosition(transform.position + movement);
        }
	}

    /// <summary>
    /// Locks the enemy's movement and rotation. Is called by the attack animation
    /// </summary>
    public void ToggleLock()
    {
        locked = !locked;
    }

    /// <summary>
    /// Resets the enemy's attack trigger for the animation. Is called by the attack animation
    /// </summary>
    public void ResetTrigger()
    {
        animator.ResetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player enters Trigger
        if (other.tag == "Player")
        {
            playerDetection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //If player exits Trigger
        if (other.tag == "Player")
        {
            playerDetection = false;
        }
    }

}
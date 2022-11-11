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
        animator = GetComponent<Animator>();
        textObject = transform.GetChild(15).gameObject;
        //textObject.GetComponent<TextMeshPro>().text = "Test";

        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        textObject.transform.rotation = rotation;

        nextAttack = DateTime.Now;
    }

    private void Update () {

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
            if (!killRegistered)
            {
                killRegistered = !killRegistered;
                transform.parent.GetComponent<EnemySpawner>().AddKill();
            }
			animator.SetBool("isHit", true);
			GetComponent<Collider>().enabled = false;
            Destroy(textObject);
			Destroy(gameObject, despawnTime);
        }
        else if (nextAttack <= DateTime.Now && playerDetection)
        {
            animator.SetTrigger("Attack");
            nextAttack = DateTime.Now.AddSeconds(System.Convert.ToDouble(attackDelay));
            player.GetComponent<Character>().TakeDamage(1);
        }
        else if (!locked)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime * 2);

            Vector3 movement = transform.rotation * (new Vector3(0, 0, 1.5f) * speed * Time.deltaTime);

            transform.GetComponent<Rigidbody>().MovePosition(transform.position + movement);
        }
	}

    public void ToggleLock()
    {
        locked = !locked;
    }

    public void ResetTrigger()
    {
        animator.ResetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.tag == "Player")
        {
            playerDetection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDetection = false;
        }
    }

}
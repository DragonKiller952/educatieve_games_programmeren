using UnityEngine;
using System.Collections;
using TMPro;
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
    }

    private void Update () {

        //If the target is hit
        if (isHit == true) 
		{
			animator.SetBool("isHit", true);
			GetComponent<Collider>().enabled = false;
            Destroy(textObject);
			Destroy(gameObject, despawnTime);
        }
        else
        {

            var lookPos = player.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            textObject.transform.rotation = rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime * 2);

            Vector3 movement = transform.rotation * (new Vector3(0, 0, 1.5f) * speed * Time.deltaTime);

            transform.GetComponent<Rigidbody>().MovePosition(transform.position + movement);
        }
	}
}
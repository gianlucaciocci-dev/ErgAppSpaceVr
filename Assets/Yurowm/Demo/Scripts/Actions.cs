using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class Actions : MonoBehaviour {

	private Animator animator;
	public Transform Player;
	EnemyFireGun enemyfiregun;

    public void Start()
    {
		enemyfiregun = GetComponentInChildren<EnemyFireGun>();

	}

    private void Update()
    {
		var distancefromPlayer = Vector3.Distance(transform.position, Player.position);
		
		if (distancefromPlayer < 10 && distancefromPlayer > 8)
		{
            //transform.LookAt(Player.position);
            Aiming();
            
		}
		 if(distancefromPlayer <= 8)
        {
            //Attack();
            enemyfiregun.AttackTimer();
			
		}
         if(distancefromPlayer >= 10)
        {
			animator.SetBool("Aiming", false);
		}
	}

    const int countOfDamageAnimations = 3;
	int lastDamageAnimation = -1;

	void Awake () {
		animator = GetComponent<Animator> ();
	}

	public void Stay () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0f);
		}

	public void Walk () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0.5f);
	}

	public void Run () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 1f);
	}

	public void Attack () {
		Aiming ();
		animator.SetTrigger ("Attack");
	}

	public void Death () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Death"))
			animator.Play("Idle", 0);
		else
			animator.SetTrigger ("Death");
	}

	public void Damage () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Death")) return;
		int id = Random.Range(0, countOfDamageAnimations);
		if (countOfDamageAnimations > 1)
			while (id == lastDamageAnimation)
				id = Random.Range(0, countOfDamageAnimations);
		lastDamageAnimation = id;
		animator.SetInteger ("DamageID", id);
		animator.SetTrigger ("Damage");
	}

	public void Jump () {
		animator.SetBool ("Squat", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool("Aiming", false);
		animator.SetTrigger ("Jump");
	}

	public void Aiming () {
		animator.SetBool ("Squat", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool("Aiming", true);
	}

	public void Sitting () {
		animator.SetBool ("Squat", !animator.GetBool("Squat"));
		animator.SetBool("Aiming", false);
	}

 //   private void OnTriggerEnter(Collider other)
 //   {
 //       if(other.transform.tag=="Player")
 //       {
	//		//transform.LookAt(Player);
	//		Aiming();
	//		Attack();
 //       }
 //   }

 //   private void OnTriggerExit(Collider other)
 //   {
	//	animator.SetBool("Aiming", false);
	//}
}

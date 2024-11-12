using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	Rigidbody2D rigid;
	Animator anim;
	SpriteRenderer sprt;

	float horizontalValue;
	[SerializeField] float speed;
	[SerializeField] float speedBase;
	[SerializeField] float jumpForce;
	[SerializeField] Collider2D confiner;
	[SerializeField] GameObject attackRange;
	float Delay;

	[SerializeField] Transform detectionCenter;
	[SerializeField] float detectionRadius;

	[SerializeField] Collider2D[] collisions;
	[SerializeField] bool isGrounded;
	public bool jumpActivated = false;
	bool attackActive = false;

    // Start is called before the first frame update
    void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sprt = GetComponent<SpriteRenderer>();
		speedBase = speed;
	}

	void Update() //SE EJECUTA SEGUN EL NUMERO DE FRAMES QUE PUEDA PROCESAR EL COMPUTADOR
	{
		horizontalValue = Input.GetAxis("Horizontal");
		anim.SetBool("InMovement", horizontalValue != 0 ? true : false);

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
		{
			jumpActivated = true;
		}
		if(Input.GetKeyDown(KeyCode.C))
		{
			attackActive = true;
		}

		Flip();
	}

	private void FixedUpdate() //SE EJECUTA UN NUMERO DE VECES FIJAS SIN IMPORTAR EL COMPUTADOR
	{
		rigid.velocity = new Vector2(horizontalValue * speed, rigid.velocity.y);
		anim.SetFloat("YVelocity", rigid.velocity.y);

        Run();
		collisions = Physics2D.OverlapCircleAll(detectionCenter.position, detectionRadius);

		if (collisions.Length > 0)
		{
            isGrounded = true;
        }
        if (collisions.Length == 2)
        {
            isGrounded = false;
        }


        anim.SetBool("IsGrounded", isGrounded);

		if (jumpActivated == true)
		{
			rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			anim.SetTrigger("Jump");
			jumpActivated = false;
		}
		if (attackActive == true)
		{
			attackRange.SetActive(true);
			anim.SetTrigger("Attack");
			attackActive = false;
		}
		else
		{
            attackRange.SetActive(false);
        }

	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(detectionCenter.position, detectionRadius);
	}

	public void Run()
	{
		if(Delay <= 0)
		{
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
				speed = speedBase * 2;
            }
			if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
				speed = speedBase;
				Delay = 5;
            }
        }
		if(Delay > 0)
		{
			Delay -= Time.deltaTime;
		}
	}
	public void Flip()
	{
		if (horizontalValue > 0 && sprt.flipX == true || horizontalValue < 0 && sprt.flipX == false)
		{
			sprt.flipX = !sprt.flipX;
		}
	}
	public void attack()
	{

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "PlataformMove")
		{
			transform.parent = collision.transform;
		}
    }
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "PlataformMove")
		{
			transform.parent = null;
		}
	}
}

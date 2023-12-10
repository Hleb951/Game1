using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private float jumpStrength = 5;
    [SerializeField] private GameObject groundPoint;
    [SerializeField] private Vector2 groundPointSize;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private KeyCode attackKey;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float attacPointRadius;


    private Rigidbody2D rb;
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        // (x, y) -> (1, 0)

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveX));

        Vector3 t = transform.localScale;
        if (moveX > 0)
        {
            t.x = Mathf.Abs(t.x);
        }
        else if (moveX < 0)
        {
            t.x = -Mathf.Abs(t.x);
        }
        transform.localScale = t;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(transform.up * jumpStrength, ForceMode2D.Impulse);
        }

        Attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundPoint.transform.position, groundPointSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.transform.position, attacPointRadius);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(groundPoint.transform.position, groundPointSize, 0, Vector2.zero, 0, groundLayerMask);
        return hit.collider != null;
    }

    private void Attack()
    {
        if(Input.GetKeyDown(attackKey))
        {
            animator.SetTrigger("Attack");
        }
    }
}

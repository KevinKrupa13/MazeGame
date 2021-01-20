using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public enum PlayerDirection {
    right,
    left,
    front,
    back
}

public class PlayerMove : MonoBehaviour
{

    public PlayerState currentState;
    public float speed;
    public PlayerDirection currentDirection;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public GameObject projectile;
    public Transform shotPoint;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        currentDirection = PlayerDirection.front;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        changeDirection();
        
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
        
    }

    private void changeDirection() {
        
        if (change.x == -1) {
            currentDirection = PlayerDirection.left;
        }
        else if (change.x == 1) {
            currentDirection = PlayerDirection.right;
        }
        else if (change.y == -1) {
            currentDirection = PlayerDirection.front;
        }
        else if (change.y == 1) {
            currentDirection = PlayerDirection.back;
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        shootProjectile();

        yield return null;

        animator.SetBool("attacking", false);

        yield return new WaitForSeconds(.3f);

        currentState = PlayerState.walk;
    }

    private void shootProjectile() {
        if (currentDirection == PlayerDirection.front) {
            Instantiate(projectile, shotPoint.position, Quaternion.Euler(0, 0, -135));
        }
        else if (currentDirection == PlayerDirection.back) {
            Instantiate(projectile, shotPoint.position, Quaternion.Euler(0, 0, 45));
        }
        else if (currentDirection == PlayerDirection.right) {
            Instantiate(projectile, shotPoint.position, Quaternion.Euler(0, 0, -45));
        }
        else if (currentDirection == PlayerDirection.left) {
            Instantiate(projectile, shotPoint.position, Quaternion.Euler(0, 0, 135));
        }
    }

    void UpdateAnimationAndMove() {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );

    }
}

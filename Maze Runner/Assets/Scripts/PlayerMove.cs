using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    back, 
    rFront,
    rBack,
    lFront,
    lBack
}

public class PlayerMove : MonoBehaviour
{

    public PlayerState currentState;
    public float speed;
    public PlayerDirection currentDirection;
    public Vector3 finalChange;
    private Vector3 change;
    private Rigidbody2D myRigidbody;
    private Animator animator;

    public GameObject projectile;
    public Transform shotPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        currentDirection = PlayerDirection.front;
        finalChange = new Vector3(0, -1, 0);
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
            if (change.y == -1) {
                currentDirection = PlayerDirection.lFront;
            }
            else if (change.y == 1) {
                currentDirection = PlayerDirection.lBack;
            }
            else {
                currentDirection = PlayerDirection.left;
            }
        }
        
        else if (change.x == 1) {
            if (change.y == -1) {
                currentDirection = PlayerDirection.rFront;
            }
            else if (change.y == 1) {
                currentDirection = PlayerDirection.rBack;
            }
            else {
                currentDirection = PlayerDirection.right;
            }
        }

        else if (change.y == -1) {
            currentDirection = PlayerDirection.front;
        }
        else if (change.y == 1) {
            currentDirection = PlayerDirection.back;
        }

        if (change.x != 0 || change.y != 0) {
            finalChange.x = change.x;
            finalChange.y = change.y;
        }
        
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        StartCoroutine(makeProjectile());

        yield return null;

        animator.SetBool("attacking", false);

        yield return new WaitForSeconds(.3f);

        currentState = PlayerState.walk;
    }

    private IEnumerator makeProjectile() {
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
        else if (currentDirection == PlayerDirection.rFront) {
            Instantiate(projectile, shotPoint.position, Quaternion.Euler(0, 0, -90));
        }
        else if (currentDirection == PlayerDirection.lFront) {
            Instantiate(projectile, shotPoint.position, Quaternion.Euler(0, 0, 180));
        }
        else if (currentDirection == PlayerDirection.rBack) {
            Instantiate(projectile, shotPoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (currentDirection == PlayerDirection.lBack) {
            Instantiate(projectile, shotPoint.position, Quaternion.Euler(0, 0, 90));
        }

        yield return new WaitForSeconds(.5f);
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

    private void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );

    }
}

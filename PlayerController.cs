using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;

    private Animator anim;
    private Rigidbody2D myRigidbody;
    private bool playerMoving;
    private Vector2 lastMove;
    public GameObject Player;

    //public Transform movePoint;
    public bool canMoveHorizontally;
    public bool canMoveVertically;
    //public bool prevMoveHorizontallyStatus;
    //public bool prevMoveVerticallyStatus;
    // public LayerMask whatStopsMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody =  GetComponent<Rigidbody2D>();
        //movePoint.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMoving = false;

        //Player.transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        //if(Vector3.Distance(Player.transform.position, movePoint.position) == 0)
        //{
        //    playerMoving = false;
        //    //left or right movement
        //    if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        //    {

        //        if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, whatStopsMovement))
        //        { 
        //            playerMoving = true;
        //            //myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), myRigidbody.velocity.y);
        //            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        //            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        //        }
        //    } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        //    {

        //        if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, whatStopsMovement))
        //        {
        //            playerMoving = true;
        //            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        //            //myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical"));
        //            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        //        }
        //    }
        //}

        //if (canMoveVertically == true && (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f))
        //{
        //    canMoveHorizontally = false;
        //}

        //if (canMoveHorizontally == true && (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f))
        //{
        //    canMoveVertically = false;
        //}

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            canMoveHorizontally = true;
            canMoveVertically = false;
            if (canMoveHorizontally == true)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }   
        }
        else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            canMoveHorizontally = false;
            canMoveVertically = true;
            if (canMoveVertically == true)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
            
        }
        


        //canMoveHorizontally = true;
        //canMoveVertically = true;

        // animation
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}

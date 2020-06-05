using UnityEngine;
using Sound.RandomController;


public class PlayerController : MonoBehaviour
{   //An adjustable number that we can change in the unity hierarchy.
    public static float moveSpeed = 2f;

    //An adjustable number that we can change in the unity hierarchy.
    public float jumpForce = 6f;

    //An adjustable number that we can change in the unity hierarchy.
    public float velocity = 0.0001f;

    //Gets the Rigidbody2D of the object attached and names it so we can reference it later
    private Rigidbody2D rg2D;

    public float normalSpeed = 2f;

    float dirX, dirY;

    public float sprintSpeed = 4f;

    public static float Health;


    public SoundRandomController JumpSoundController;


    // Start is called before the first frame update
    private void Start()
    {
        //Makes our Rigidbody usable
        Health = 5;
        rg2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirY = Input.GetAxis("Vertical") * moveSpeed;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        //IF the Sprint key is pressed then set the moveSpeed to 4
        if (Input.GetButtonDown("Sprint"))
        {
            moveSpeed = sprintSpeed;
            CamerController.smoothSpeed = sprintSpeed;
        }

        //If the sprint key is released then set the moveSpeed to 2
        if (Input.GetButtonUp("Sprint"))
        {
            moveSpeed = normalSpeed;
            CamerController.smoothSpeed = normalSpeed;
        }

        //Gets the Input of the L/R , A/D keys and puts it into a variable that we can use later.
        var movementHor = Input.GetAxis("Horizontal");

        /*Takes the position of the object, starts to move it in 3 Vectors, multiplies it by Time.deltaTime to smooth
        it out, and multiplies it by moveSpeed. NOTE: if any one of these variable is equal to 0 the object does not move.*/
        transform.position += new Vector3(movementHor, 0, 0) * Time.deltaTime * moveSpeed;

        /*If the jump key is pressed and the objects velocity is less than velocity - then take our Rigidbody2d and add a
        force along a Vector 2 with no movement on the x axis and some movement on the y axis as defended by jumpForce also
        make sure that this force is an Impulse so that it happens all at once rather that gradually over time.*/
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rg2D.velocity.y) < velocity)
        {
            
            rg2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            SoundRandomController.Trigger(JumpSoundController);
        }

        
    }

   // private void FixedUpdate()
  //  {
   //     rg2D.velocity = new Vector2(movementHor, dirY);
   // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals ("enemy"))
        {
            Health -= 0.1f;
        }
    }
}


/*To set up script - Go to: https://www.youtube.com/watch?v=n4N9VEA2GFo */

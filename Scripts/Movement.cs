using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float startSpeed;
    private float speed;
    public float jumpForce;
    public Rigidbody rb;
    public GameObject CamRot;
    public GameObject Ray;
    public bool isGrounded;
    public float StartmaxSpeed;
    private float maxSpeed;
    public GameObject Spawn;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y<-1)
        {
            transform.position = Spawn.transform.position;
            transform.rotation = Spawn.transform.rotation;
            rb.velocity = new Vector3(0,0,0) ;
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey("m"))
        {
            if ( Input.GetKey("space"))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        if (!isGrounded)
        {
            speed = 0.01f;
        }
        else
        {
            speed = startSpeed;
        }
        if (isGrounded && Input.GetKey("left shift"))
        {
          //  speed += 0.05f;
            maxSpeed += 0.3f;
        }
        else
        {
            speed = startSpeed;
            maxSpeed = StartmaxSpeed;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Debug.Log(transform.InverseTransformDirection(rb.velocity));
        if(transform.InverseTransformDirection(rb.velocity).x>maxSpeed|| transform.InverseTransformDirection(rb.velocity).x<-maxSpeed|| transform.InverseTransformDirection(rb.velocity).z > maxSpeed || transform.InverseTransformDirection(rb.velocity).z   < -maxSpeed)
        {
            speed = 0;

        }
        else
        {
            speed = startSpeed;
        }
        rb.AddRelativeForce(movement * speed, ForceMode.Impulse);
        if (moveHorizontal == 0&& transform.InverseTransformDirection(rb.velocity).x != 0&&isGrounded!=false)
        {

            Vector3 negativeHorizontal = new Vector3(transform.InverseTransformDirection(rb.velocity).x / 2f, 0f, 0f);
            //  Debug.Log(rb.velocity);
            rb.AddRelativeForce(-negativeHorizontal, ForceMode.Impulse);
        }
        if (moveVertical== 0 && transform.InverseTransformDirection(rb.velocity).z != 0 && isGrounded != false)
        {
            Vector3 negativeVertical = new Vector3( 0f, 0f, transform.InverseTransformDirection(rb.velocity).z/2f);
            //  Debug.Log(rb.velocity);
            rb.AddRelativeForce(-negativeVertical, ForceMode.Impulse);
        }


        if (isGrounded && Input.GetKey("space"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //   RaycastHit hit;

        //   if (Physics.SphereCast(transform.position, GetComponent<CapsuleCollider>().radius, Vector3.down, out hit, -0.2f, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        //   {
        //    Debug.DrawRay(Ray.transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
        //    Debug.Log("hit");
        //isGrounded = true;

        //  }
        //   else
        //  {
        //    isGrounded = false;
        //}
    }
        void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            Spawn = col.gameObject;
        }
        if (col.gameObject.layer == 9)
        {
            Scene sceneLoaded = SceneManager.GetActiveScene();
            // loads next level
            SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
        }
    }
}
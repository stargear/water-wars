using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool hasGamepad = false;
    public Rigidbody rBody;
    public float moveSpeed = 2f;
    public float jumpSpeed = 22f;
    public float rotateSpeed = 40f;
    public LevelManager lvl;

    public bool grounded = true;
    public Quaternion defaultRotation;
    public float damp = 0.2f;
    public GameObject waterGun;
    public GameObject Circle;
    public bool IsCharging = false;
    public bool CanRotate = true;
    private item waterGunItem;
    //public item waterGun;
    public Animator anim;
    // Gamepad controls
    //PlayerControls controls;
    Vector2 inputMovement;

    public GameObject[] guns;
    public GameObject[] hats;
    public int gunInt = 0;
    public int hatInt = 0;





    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        //  get items from playerprefs!
        hatInt = PlayerPrefs.GetInt("HatInt");
        gunInt = PlayerPrefs.GetInt("GunInt");
        switchHat();
        switchGun();

        //  get textures from this
        //  gunInt = PlayerPrefs.GetInt("PenguinInt");


        //  rBody = GetComponent<Rigidbody>();
        defaultRotation = transform.rotation;
        lvl = GameObject.Find("Level").GetComponent<LevelManager>();

     
    }

    public void switchGun()
    {
        //not more hats than there are!


        switch (gunInt)
        {
            case 0:
                for (int i = 0; i < guns.Length; i++)
                {
                    guns[i].SetActive(false);
                }
                guns[0].SetActive(true);
                waterGunItem = guns[0].GetComponent<item>();
                break;
            case 1:
                for (int i = 0; i < guns.Length; i++)
                {
                    guns[i].SetActive(false);
                }
                guns[1].SetActive(true);
                waterGunItem = guns[1].GetComponent<item>();
                break;
            case 2:
                for (int i = 0; i < guns.Length; i++)
                {
                    guns[i].SetActive(false);
                }
                guns[2].SetActive(true);
                waterGunItem = guns[2].GetComponent<item>();
                break;

            default:
                for (int i = 0; i < guns.Length; i++)
                {
                    guns[i].SetActive(false);
                }
                guns[1].SetActive(true);
                waterGunItem = guns[1].GetComponent<item>();


                break;
        }
    }



    public void switchHat()
    {
        //not more hats than there are!
        if (hatInt < 0) { hatInt = hats.Length; } else if (hatInt > hats.Length) { hatInt = 0; }


        switch (hatInt)
        {
            case 0:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[0].SetActive(true);
                break;
            case 1:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[1].SetActive(true);
                break;
            case 2:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[2].SetActive(true);
                break;
            case 3:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[3].SetActive(true);
                break;
            case 4:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[4].SetActive(true);
                break;
            case 5:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[5].SetActive(true);
                break;
            case 6:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[6].SetActive(true);
                break;
            case 7:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[7].SetActive(true);
                break;
            case 8:
                for (int i = 0; i < hats.Length; i++)
                {
                    hats[i].SetActive(false);
                }
                hats[8].SetActive(true);
                break;
            default:
                break;
        }
    }



    // Update is called once per frame
    void Update()
    {

        //checked if player flipped over
        if (Vector3.Dot(transform.up, Vector3.down) > 0.5)
        {
            //Debug.Log("flipped over xD");
        }
        if (Vector3.Dot(transform.right, Vector3.right) > 0.7)
        {
            //Debug.Log("flipped over xD");
            //     rBody.velocity = new Vector2(rBody.velocity.x, jumpSpeed);
            //    rBody.isKinematic = true;
            //     transform.rotation = defaultRotation;
            //   transform.rotation = Quaternion.Slerp(transform.rotation, defaultRotation, Time.deltaTime * damp);
            //  rBody.isKinematic = false;

        }



        if (hasGamepad == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }

            // movement here
            if (Input.GetKey(KeyCode.A))
            {
                //move towards the left
                transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
                transform.Rotate(new Vector3(0, -rotateSpeed * Time.deltaTime, 0));

            }
            else if (Input.GetKey(KeyCode.D))
            {
                //move towards the right
                transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
                transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.W))
            {
                //How do I start from here??
                transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //walk backwards
                transform.Translate(Vector3.forward * -Time.deltaTime * Input.GetAxis("Vertical") * -1 * moveSpeed);

            }

        }
        else
        {
            // New Input System
            if (inputMovement != Vector2.zero && grounded)
            {
                // Movement


                Vector3 movement = new Vector3(inputMovement.x, 0f, inputMovement.y) * Time.deltaTime * moveSpeed;

                if (IsCharging && CanRotate)
                {
                    // Rotation is limited while charging
                    transform.rotation = Quaternion.LookRotation(movement * Time.deltaTime);
                    anim.SetBool("walk", false);

                    anim.SetBool("jump", false);
                }
                else if (CanRotate)
                {
                    // Don't rotate while shooting

                    transform.rotation = Quaternion.LookRotation(movement * Time.deltaTime);


                }

                // Don't move while charging
                if (!IsCharging)
                {
                    anim.SetFloat("speed", 0.3f);
                    anim.SetBool("walk", true);

                    transform.Translate(movement, Space.World);
                }

                else
                {
                    anim.SetFloat("speed", 0.0f);
                    anim.SetBool("walk", false);
                }

            }
            else if (!grounded) // Player is in air
            {
                // ToDo: Discuss in group: Is it fun? Or should we remove it?
                // Only move forward while in air
                transform.Translate(transform.forward * Time.deltaTime * moveSpeed, Space.World);
                anim.SetBool("walk", false);

            }
            else
            {
                anim.SetBool("walk", false);
            }

        }

    }

    private void Jump()
    {
        //i jump up!
        if (grounded) { 
            anim.SetBool("jump", true);
            rBody.velocity = new Vector2(rBody.velocity.x, jumpSpeed);
            grounded = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 4) //if you hit water
        {
            //display on canvas that you lost a life!

            //display a restart timer on canvas... 3,2,1, go!!

            lvl.respawn(this.gameObject);

            //StartCoroutine(WaitAndPrint);

            //after time, the player is respawned somewhere..
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Landed on ground or object
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 9) //if you hit terrain or object
        {
            // this is grounded!
            grounded = true;
            anim.SetBool("jump", false);

        }
    }


    private void OnMove(InputValue input)
    {
        inputMovement = input.Get<Vector2>();
    }

    private void OnJump()
    {
        Jump();
    }

    private void OnShootPressed()
    {
        waterGunItem.ChargeShoot();
    }

    private void OnShootReleased()
    {
        waterGunItem.FireShoot();
    }
}

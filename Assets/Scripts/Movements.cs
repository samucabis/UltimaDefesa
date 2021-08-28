using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    bool face = true;
    Rigidbody2D rigidbody2D;
    public float movimentVelocity = 0.03f;

    bool grounded = false;
    float groundcheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundcheck; //create an empty gameobject which will be used for checking ground. Attach the gameobejct just below the player.
    
    public PlayerShootCount playerShootCount;
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
     rigidbody2D = this.transform.GetComponent<Rigidbody2D>();   
    }
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.A)){
            
            if(face){
                this.transform.localRotation = Quaternion.Euler(0,-180, 0);
                face = false;
            }
            this.gameObject.transform.Translate(Vector3.right*movimentVelocity * Time.deltaTime);
            
        }
        if(Input.GetKey(KeyCode.D)){
            
            if(face != true){                
                this.transform.localRotation = Quaternion.Euler(0, 0, 0);
                face = true;
            }
            this.gameObject.transform.Translate(Vector3.right*movimentVelocity * Time.deltaTime);
        }
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, groundLayer);
        if(grounded && Input.GetKeyDown(KeyCode.Space)){
            grounded = false;
            float jumpVelocity = 3.5f;
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }
        if(Input.GetKey(KeyCode.R)){
            playerShootCount.Recarregar();
            weapon.bulletCount = 0;
        }
        
    }
    
}

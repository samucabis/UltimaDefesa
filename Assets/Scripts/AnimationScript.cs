using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    bool grounded = false;
    float groundcheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundcheck;
    // Start is called before the first frame update
    void Start()
    {
        //animator = this.gameobejct.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){ 
            this.gameObject.GetComponent<Animator>().SetBool("pressed",true); 
        }
        if(Input.GetKeyUp(KeyCode.A)){ 
            this.gameObject.GetComponent<Animator>().SetBool("pressed",false); 
        }
        if(Input.GetKeyDown(KeyCode.D)){ 
            this.gameObject.GetComponent<Animator>().SetBool("pressed",true); 
        }
        if(Input.GetKeyUp(KeyCode.D)){ 
            this.gameObject.GetComponent<Animator>().SetBool("pressed",false); 
        }
        if(Input.GetKeyDown(KeyCode.Space)){ 
            
        }
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, groundLayer);
        if(grounded && Input.GetKeyDown(KeyCode.Space)){
            grounded = false;
            this.gameObject.GetComponent<Animator>().SetBool("pulou",true); 
        }else{
            this.gameObject.GetComponent<Animator>().SetBool("pulou",false); 
        }
        
    }
}

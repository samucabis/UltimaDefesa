using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnim : MonoBehaviour
{   
    public GameObject canvas;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnDestroy() {
        canvas.SetActive(true);
    }
}

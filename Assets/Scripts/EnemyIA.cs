using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public float speed,range,shootRange;
    public Transform player;
    public Transform groundCheck;
    public LayerMask groundLayer;    
    public Transform firePoint;
    public GameObject bulletPrefab;

    private int shootCount;
    private bool seguir;
    private int cont;
    private float dist;
    private float distY;

    public int tempoRecarga = 3;
    public float fireRate = 3F;
    private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {   
        shootCount = 0;
        seguir = true;
        cont = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {   
        
         dist = (transform.position.x - player.position.x);     
         //ROTACIONA O INIMIGO EM 180º DEPENDENDO DE QUE LADO O PLAYER ESTÁ USANDO O DIST, ASSIM A SPRITE VIRA DE LADO PARA SEGUIR O PLAYER     
         if( dist > 0 && cont == 0){
                cont++;
                this.transform.localRotation = Quaternion.Euler(0,-180, 0);           
         }else{
             if(dist < 0 && cont == 1){
                cont--;
                this.transform.localRotation = Quaternion.Euler(0, 0, 0); 
             }
         }
         //AQUI É ONDE SEGUIMOS O PLAYER, USAMOS O VECTOR2.DISTANCE PARA PEGAR A DISTANCIA DO INIMIGO PARA O PLAYER E VERIFIMAOS SE ELE ESTA NO RANGE 
         //CASO ESTEJA NO RANGE E PODEMOS SEGUIR CONTINUAMOS, SEGUIR SERVE PARA VERIFICAR SE O INIMIGO NÃO IRÁ CAIR NA LAVA OU DAS PLATAFORMAS.
        seguir = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if(Vector2.Distance(transform.position , player.position) > range && seguir){
            this.gameObject.GetComponent<Animator>().SetBool("correndo",true); 
            transform.position = Vector2.MoveTowards(transform.position , player.position, speed * Time.deltaTime);
        }else{
            this.gameObject.GetComponent<Animator>().SetBool("correndo",false); 

        }
        //AQUI VERIFICAMOS SE O PLAYER ESTÁ PROXIMO O SUFICIENTE PARA ATIRARMOS
        distY = transform.position.y - player.position.y;
        if(Vector2.Distance(transform.position , player.position) <= shootRange && shootCount < 3 && distY  <= 0.1f && distY >= -0.1f ){
            if(Time.time > nextFire){
                nextFire = Time.time + fireRate;
                Shoot();
                shootCount++;
            }
            if(shootCount >= 3){
                StartCoroutine(Recarregar());
                
            }
        }

    }
        IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(tempoRecarga);
        shootCount = 0;        
    }
    async void Shoot(){
         Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("HealthBar")]
    [SerializeField] private float maxHp = 100f;
    [SerializeField] private float  hp ;
    [SerializeField] HpBar hpBar; 

    [Header("Move")]
    [SerializeField] private float speed = 6;
    [SerializeField] private float jump = 250f;

    [Header("Ammo")]
    //[SerializeField] private float ammo = 0f;
    [SerializeField] private float maxAmmo;
    //[SerializeField] private Text txtAmmo;
    //[SerializeField] private float ammoUp;

    [SerializeField] bool ground;

    private Animator anim;
    
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        /////Animator/////
        anim = GetComponent<Animator>();

        /////Rb2d/////
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d = GetComponent<Rigidbody2D>();

        //////Health/////
        hp = maxHp;
        hpBar.SetMaxHealth(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
    
        float move = Input.GetAxisRaw("Horizontal");
        
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            
        }
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space) && ground == true && rb2d.velocity.y == 0)
        {
            rb2d.AddForce(Vector2.up * jump);
            SoundManager.instance.Play(SoundManager.SoundName.PlayerJump);

        }
        
      

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        
        Flip();

        Animation();

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }


    }
    
  
    /////TakeDamege/////
    public void EnemyTakeDamage(float damage)
    {
        hp -= damage;
        hpBar.SetHealth(hp);

        /////If Die/////
        if (hp <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    /////TakeDamege/////
    public void TrapTakeDamage(float damage)
    {
        hp += damage;
        hpBar.SetHealth(hp);

        /////If Die/////
        if (hp <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    

    /////Flip/////
    void Flip()
    {
         float move = Input.GetAxisRaw("Horizontal");
         if (!Mathf.Approximately(move, 0))
             transform.rotation = move < 0 ? Quaternion.Euler(0, -180, 0) : Quaternion.identity;
    }

    /////GetPotion/////
    public void PlayerGetHpPotion(int point)
    {
        hp += point;
        hpBar.SetHealth(hp);
        if (hp >= 100)
        {
            hp = 100;
        }
    }
   
    
    public void Heal(int point)
    {
        hp += point;
        hpBar.SetHealth(hp);
        
        if (hp >= 100)
        {
            hp = 100;
        }
    }
   
    /////Animator/////
    void Animation()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("WALK", true);
        }
        else
        {
            anim.SetBool("WALK", false);
        }
    }
    
    
    

}

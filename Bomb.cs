using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private int damage = 50;
    
     private bool thrown = true ;


    // Start is called before the first frame update
    void Start()
    {
        if(thrown)
        {
            var dir = transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(dir * speed, ForceMode2D.Impulse);
        }
        
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
       if(!thrown)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.PlayerTakeDamage(damage);
        }
        SoundManager.instance.Play(SoundManager.SoundName.PlayerBlueSkill2);
        Destroy(gameObject);
    }
}

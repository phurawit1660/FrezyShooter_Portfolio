using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSummon : MonoBehaviour
{
    [SerializeField] private float coolDown;
    private float isCoolDown;
    public Bullet prefabs;
    public Transform offset;
    bool atk = true;
    
    // Update is called once per frame
    void Update()
    {
        if (atk == true)
        {
            if (Time.time > isCoolDown)
            {
                isCoolDown = Time.time + coolDown;

                Instantiate(prefabs, offset.position, transform.rotation);
                SoundManager.instance.Play(SoundManager.SoundName.PlayerBrownSkill2beam);
            }
        }
    }
}

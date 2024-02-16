using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPlayerGreen : MonoBehaviour
{
    [Header("Skill1")]
    [SerializeField] private Image skill1;
    [SerializeField] private float coolDown1;
    bool isCooldown1 = false;
    public Bullet prefabs;
    public Transform offset1, offset2, offset3;

    [Header("Skill2")]
    [SerializeField] private Image skill2;
    [SerializeField] private float coolDown2;
    bool isCooldown2 = false;

    [Header("Skill Speed Up")]
    [SerializeField] private Image skillspeed;
    [SerializeField] private float coolDownSkillSeed;
    private float speed;
    bool isCooldownSkillSpeed = false;




    // Start is called before the first frame update
    void Start()
    {
        skill1.fillAmount = 0;
        skill2.fillAmount = 0;
        skillspeed.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Skill1();
        Skill2();
        
    }

    void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isCooldown1 == false)
        {
            isCooldown1 = true;
            skill1.fillAmount = 1;
            Instantiate(prefabs, offset1.position, transform.rotation);
            Instantiate(prefabs, offset2.position, transform.rotation);
            Instantiate(prefabs, offset3.position, transform.rotation);
            // Sound //
            SoundManager.instance.Play(SoundManager.SoundName.PlayerShootBow);
        }
        if (isCooldown1)
        {
            skill1.fillAmount -= 1 / coolDown1 * Time.deltaTime;

            if (skill1.fillAmount <= 0)
            {
                skill1.fillAmount = 0;
                isCooldown1 = false;
            }
        }


    }

    void Skill2()
    {

        if (Input.GetKeyDown(KeyCode.E) && isCooldown2 == false && isCooldownSkillSpeed == false)
        {
            isCooldown2 = true;
            skill2.fillAmount = 1;
            if(isCooldown2 == true)
            {
                speed += 10;
                isCooldownSkillSpeed = true;
                skillspeed.fillAmount = 1;
                SoundManager.instance.Play(SoundManager.SoundName.PlayerGreenSkill2);
            }   
        }
        float move = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * speed;
        if (isCooldown2)
        {
            skill2.fillAmount -= 1 / coolDown2 * Time.deltaTime;

            if (skill2.fillAmount <= 0)
            {
                skill2.fillAmount = 0;
                isCooldown2 = false;
            }
        }

        if (isCooldownSkillSpeed)
        {
            skillspeed.fillAmount -= 1 / coolDownSkillSeed * Time.deltaTime;

            if (skillspeed.fillAmount <= 0)
            {
                speed -=10;
                skillspeed.fillAmount = 1;
                isCooldownSkillSpeed = false;
            }
        }
    }
}

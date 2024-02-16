using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPlayerBlue : MonoBehaviour
{
    [Header("Skill1")]
    [SerializeField] private Image skill1;
    [SerializeField] private float coolDown1;
    bool isCooldown1 = false;
    [SerializeField] private GameObject Gun;

    [Header("Skill Double Gun")]
    [SerializeField] private Image skillGun;
    [SerializeField] private float coolDownSkillGun;
    bool isCooldownSkillGun = false;
   

    [Header("Skill2")]
    [SerializeField] private Image skill2;
    [SerializeField] private float coolDown2;
    bool isCooldown2 = false;
    [SerializeField] private GameObject Bomb;
    [SerializeField] private Transform point;

    // Start is called before the first frame update
    void Start()
    {
        skill1.fillAmount = 0;
        skill2.fillAmount = 0;


    }

    // Update is called once per frame
    void Update()
    {
        Skill1();
        Skill2();

    }

    void Skill1()
    {

        if (Input.GetKeyDown(KeyCode.Q) && isCooldown1 == false && isCooldownSkillGun== false)
        {
            isCooldown1 = true;
            skill1.fillAmount = 1;
            if (isCooldown1 == true)
            {
                Gun.SetActive(true);
                isCooldownSkillGun = true;
                skillGun.fillAmount = 1;
                SoundManager.instance.Play(SoundManager.SoundName.PlayerBlueSkill1);
            }
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
        

        if (isCooldownSkillGun)
        {
            skillGun.fillAmount -= 1 / coolDownSkillGun * Time.deltaTime;

            if (skillGun.fillAmount <= 0)
            {
                skillGun.fillAmount = 1;
                isCooldownSkillGun = false;
            }
        }
        else
        {
            Gun.SetActive(false);
            
        }

    }
    void Skill2()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCooldown2 == false)
        {
            Instantiate(Bomb, point.position, transform.rotation);
            isCooldown2 = true;
            skill2.fillAmount = 1;
            
        }
        if (isCooldown2)
        {
            skill2.fillAmount -= 1 / coolDown2 * Time.deltaTime;

            if (skill2.fillAmount <= 0)
            {
                skill2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
        

    }
}
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPlayerBrown : MonoBehaviour
{
    [Header("Skill1")]
    [SerializeField] private Image skill1;
    [SerializeField] private float coolDown1;
    bool isCooldown1 = false;
    
    private int HpUp = 20 ;
    
    
    private float  maxHp ;
    [SerializeField] private HpBar hpBar;

    private int point;
    [SerializeField] private Player _player;
    
    
     [Header("Skill2")]
     [SerializeField] private Image skill2;
     [SerializeField] private float coolDown2;
     bool isCooldown2 = false;

    [Header("Skill Summon")]
    [SerializeField] private Image skillSummon;
    [SerializeField] private float coolDownSkillSummon;
    bool isCooldownSkillSummon = false;
    [SerializeField] private GameObject Summon;
    [SerializeField] private GameObject Summon1;


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

    // ReSharper disable Unity.PerformanceAnalysis
    void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isCooldown1 == false)
        {
            
            ///////////////////////////////
            
            _player.Heal(20);
            SoundManager.instance.Play(SoundManager.SoundName.PlayerBrownSkill1);
            
            /////////////////////////////
            isCooldown1 = true;
            skill1.fillAmount = 1;

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
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        { 
            var player = col.GetComponent<Player>();
            player.PlayerGetHpPotion(HpUp);
        }
        
    }

    void Skill2()
    {

        if (Input.GetKeyDown(KeyCode.E) && isCooldown2 == false && isCooldownSkillSummon == false)
        {
            isCooldown2 = true;
            skill2.fillAmount = 1;
            if (isCooldown2 == true)
            {
                Summon.SetActive(true);
                Summon1.SetActive(true);
                isCooldownSkillSummon = true;
                skillSummon.fillAmount = 1;
                SoundManager.instance.Play(SoundManager.SoundName.PlayerBrownSkill2summon);
            }
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
       

        if (isCooldownSkillSummon)
        {
            skillSummon.fillAmount -= 1 / coolDownSkillSummon * Time.deltaTime;

            if (skillSummon.fillAmount <= 0)
            {
                skillSummon.fillAmount = 1;
                isCooldownSkillSummon = false;
            }
        }
        else
        {
            Summon.SetActive(false);
            Summon1.SetActive(false);
        }

    }

}
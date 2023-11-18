using System.Collections;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    Animator ZombieAnim;
    public GameObject ThePlayer;
    public GameObject Zombie;
    public bool AttackTrigger = false;
    public AudioSource Hurt1;
    public AudioSource Hurt2;
    public AudioSource Hurt3;
    public int RandomHurt;
    public GameObject HurtScreen;
    public int ZombieHealth = 15;
    public bool ZombieIsBeingHit = false;
    public bool ZombieIsHitting = false;
    public bool ZombieDead = false;

    // Animatior constants
    const string ZOMBIE_WALK = "walk";
    const string ZOMBIE_DEATH = "death";
    const string ZOMBIE_ATTACK = "attack";

    void Start()
    {
        ZombieAnim = Zombie.GetComponent<Animator>();
    }

    void PistolShot(int DamageAmount)
    {
        StartCoroutine(ZombieDamaged());
    }

    void ChangeAnimationState(string newState)
    {
        ZombieAnim.Play(newState);
    }

    void Update()
    {
         if(PlayScript.isPlaying)
         {
            Zombie.SetActive(true);
            transform.LookAt(ThePlayer.transform);
            if (ZombieIsBeingHit || ZombieIsHitting || ZombieDead)
            {
                  transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, 0);
            }
            if (!ZombieIsBeingHit && !ZombieIsHitting && !ZombieDead)
            {
                  if (!AttackTrigger)
                  {
                     ChangeAnimationState(ZOMBIE_WALK);
                     transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, 0.02f);
                  }
                  else
                  {
                     StartCoroutine(InflictDamage());
                  }
            }
        }
    }

    void OnTriggerEnter()
    {
        AttackTrigger = true;
    }

    void OnTriggerExit()
    {
        AttackTrigger = false;
    }

    IEnumerator ZombieDamaged()
    {
        if (!ZombieDead)
        {
            ZombieIsBeingHit = true;
            ZombieHealth -= 5;
            if (ZombieHealth <= 0)
            {
                ZombieDead = true;
                ChangeAnimationState(ZOMBIE_DEATH);
                yield return new WaitForSeconds(2.4f);
                this.gameObject.GetComponent<Collider>().enabled = false;
                Zombie.SetActive(false);
            }
            else
            {
                yield return new WaitForSeconds(1.5f);
            }
            ZombieIsBeingHit = false;
        }
    }

    IEnumerator InflictDamage()
    {
        if (AttackTrigger)
        {
            ZombieIsHitting = true;
            ChangeAnimationState(ZOMBIE_ATTACK);
            RandomHurt = Random.Range(1, 4);
            switch (RandomHurt)
            {
                case 1:
                    Hurt1.Play();
                    break;
                case 2:
                    Hurt2.Play();
                    break;
                case 3:
                    Hurt3.Play();
                    break;
            }
            HurtScreen.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            HurtScreen.SetActive(false);
            yield return new WaitForSeconds(2.3f);
            GlobalHealth.PlayerHealth -= 5;
            ZombieIsHitting = false;
        }
        else yield break;
    }
}

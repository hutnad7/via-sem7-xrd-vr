using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StalkerAI : MonoBehaviour
{
    public GameObject StalkerDest;
    NavMeshAgent NavAgent;
    Animator StalkerAnim;
    public GameObject Stalker;
    public static int KillCount = 0;
    public int StalkerHealth = 15;
    public bool AttackTrigger = false;
    public bool StalkerIsBeingHit = false;
    public bool StalkerIsHitting = false;
    public bool StalkerDead = false;
    public AudioSource Hurt1;
    public AudioSource Hurt2;
    public AudioSource Hurt3;
    public int RandomHurt;

    // Animatior constants
    const string CROUCHED_WALKING = "Mutant Walking";
    const string HIT_REACTION = "Standing React Small From Front";
    const string MUTANT_DYING = "Mutant Dying";
    const string MUTANT_PUNCH = "Mutant Punch";

    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        StalkerAnim = Stalker.GetComponent<Animator>();
    }

    void Shot()
    {
        StartCoroutine(StalkerDamage());
    }

    void ChangeAnimationState(string newState)
    {
        StalkerAnim.Play(newState);
    }

    void Update()
    {
        if(PlayScript.isPlaying && !StalkerDead){
            Stalker.SetActive(true);
            if (StalkerIsBeingHit || StalkerIsHitting || StalkerDead)
            {
                NavAgent.SetDestination(transform.position);
            }
            if (!StalkerIsBeingHit && !StalkerIsHitting)
            {
                if (!AttackTrigger)
                {
                    NavAgent.SetDestination(StalkerDest.transform.position);
                    ChangeAnimationState(CROUCHED_WALKING);
                }
                else
                {
                    StartCoroutine(StalkerHit());
                }
            }
            else if (!StalkerIsBeingHit && !StalkerIsHitting)
            {
                Stalker.SetActive(false);
            }
        }
        else
        {
            Stalker.SetActive(false);
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

    IEnumerator StalkerDamage()
    {
        if (!StalkerDead)
        {
            StalkerIsBeingHit = true;
            StalkerHealth -= 5;
            ChangeAnimationState(HIT_REACTION);
            if (StalkerHealth <= 0)
            {
                StalkerDead = true;
                ChangeAnimationState(MUTANT_DYING);
                yield return new WaitForSeconds(4.6f);
                this.gameObject.GetComponent<Collider>().enabled = false;
                Stalker.SetActive(false);
                KillCount += 1;
            }
            else
            {
                yield return new WaitForSeconds(1.6f);
            }
            StalkerIsBeingHit = false;
        }
    }

    IEnumerator StalkerHit()
    {
        if (AttackTrigger)
        {
            StalkerIsHitting = true;
            ChangeAnimationState(MUTANT_PUNCH);
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
            GlobalHealth.PlayerHealth -= 5;
            yield return new WaitForSeconds(1.1f);
            StalkerIsHitting = false;
        }
        else {
            StalkerIsHitting = false;
            yield break;
        }
    }
}
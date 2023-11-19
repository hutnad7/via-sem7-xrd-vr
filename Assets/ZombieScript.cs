using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
    public GameObject Dest;
    NavMeshAgent NavAgent;
    Animator StalkerAnim;
    public GameObject Stalker;
    public bool AttackTrigger = false;
    public AudioSource Hurt1;
    public AudioSource Hurt2;
    public AudioSource Hurt3;
    public int RandomHurt;
    public int StalkerHealth = 15;
    public bool StalkerIsHitting = false;
    public bool StalkerDead = false;

    // Animator constants
    const string STALKER_WALK = "Mutant Walking";
    const string STALKER_DEATH = "Mutant Dying";
    const string STALKER_ATTACK = "Mutant Punch";

    void Start()
    {
        StalkerAnim = Stalker.GetComponent<Animator>();
        NavAgent = GetComponent<NavMeshAgent>();
    }

    void Shot()
    {
        Debug.Log("Zombie is damaged");
        StartCoroutine(ZombieDamaged());
    }

    void ChangeAnimationState(string newState)
    {
        StalkerAnim.Play(newState);
    }

    void Update()
    {
        if (PlayScript.isPlaying)
        {
            Stalker.SetActive(true);
            Stalker.transform.LookAt(Dest.transform.position);
            NavAgent.SetDestination(transform.position);

            if (StalkerIsHitting || StalkerDead)
            {
                NavAgent.isStopped = true;
                Debug.Log("Zombie is not moving");
            }
            else
            {
                NavAgent.isStopped = false;
                NavAgent.SetDestination(transform.position);

                if (!AttackTrigger)
                {
                    NavAgent.SetDestination(Dest.transform.position);
                    ChangeAnimationState(STALKER_WALK);
                }
                else
                {
                    Debug.Log("Zombie is attacking");
                    StartCoroutine(InflictDamage());
                }
            }
        }
    }

    void OnTriggerEnter()
    {
        Debug.Log("Zombie is attacking");
        AttackTrigger = true;
    }

    void OnTriggerExit()
    {
        Debug.Log("Zombie is not attacking");
        AttackTrigger = false;
    }

    IEnumerator ZombieDamaged()
    {
        if (!StalkerDead)
        {
            StalkerHealth -= 5;
            if (StalkerHealth <= 0)
            {
                StalkerDead = true;
                ChangeAnimationState(STALKER_DEATH);
                yield return new WaitForSeconds(2.4f);
                this.gameObject.GetComponent<Collider>().enabled = false;
                Stalker.SetActive(false);
            }
            else
            {
                yield return new WaitForSeconds(1.5f);
            }
        }
    }

    IEnumerator InflictDamage()
    {
        if (AttackTrigger)
        {
            StalkerIsHitting = true;
            ChangeAnimationState(STALKER_ATTACK);
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
            yield return new WaitForSeconds(2.3f);
            GlobalHealth.PlayerHealth -= 5;
            StalkerIsHitting = false;
        }
        else yield break;
    }
}

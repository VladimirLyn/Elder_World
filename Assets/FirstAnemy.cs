using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class FirstAnemy : MonoBehaviour
{
    Animator Animation;
    public GameObject Player;
    NavMeshAgent Agent;
    bool Attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Patrol());
        Animation = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
          if (other.gameObject.GetComponent<ThirdPersonController>().isCrouching == false)
            {
                Animation.Play("Attack");
                Attack = true;
            }
            else
            {
                Animation.Play("Idle");
                Attack = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Attack == true)
        {
            Agent.SetDestination(Player.transform.position);
        }
    }
    IEnumerator Patrol()
    {
        while(Attack == false)
        {
            Agent.SetDestination(gameObject.transform.position * Random.Range(0.3f, 2f));
            yield return new WaitForSeconds(10);
        }
        
    }

}

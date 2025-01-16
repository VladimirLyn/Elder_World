using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class FirstAnemy : MonoBehaviour
{
    Animator Animation;
    public GameObject Player;
    public NavMeshAgent Agent;
    bool Attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EnemyAI());
        Animation = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<ThirdPersonController>().isCrouching == false)
            {
                Attack = true;   
            }
            else
            {
                Attack = false;
            }
        }
    }
    private void FixedUpdate()
    {
    }
    public IEnumerator EnemyAI()
    {
        while (true)
        {
            if (Attack == true)
            {
                StartCoroutine(EnemyAttack());
            }
            else
            {
                StartCoroutine(Patrol());
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator EnemyAttack()
    {
        //while(true)
        //{
        //    while (Attack == true)
        //    {
                Animation.Play("Attack");
                Agent.speed = 8;
                for (int i = 0; i < 10; i++)
                {
                    Agent.SetDestination(Player.transform.position);
                    yield return new WaitForSeconds(0.5f);
                }
                Agent.SetDestination(gameObject.transform.position);
                Animation.Play("Idle");
                yield return new WaitForSeconds(5);
                StopCoroutine(Patrol());
            //}
            //yield return new WaitForSeconds(0.5f);
        //}
    }
    public IEnumerator Patrol()
    {
        //while (true)
        //{
        //    while (Attack == false)
        //    {
                yield return new WaitForSeconds(1);
                Animation.Play("Idle");
                Agent.speed = 3;
                Agent = GetComponent<NavMeshAgent>();
                Agent.SetDestination(new Vector3
                    (
                    gameObject.transform.position.x + Random.Range(-20f, 20f),
                    gameObject.transform.position.y,
                    gameObject.transform.position.z + Random.Range(-20f, 20f)
                    ));
                yield return new WaitForSeconds(2);
                StopCoroutine(EnemyAttack());
        //}
        //yield return new WaitForSeconds(0.5f);
    }
}
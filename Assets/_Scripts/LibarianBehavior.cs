using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LibarianBehavior : MonoBehaviour
{
    public Animator anim;

    public float speed;
    public int moveSpeed = 3;
    public int rotationSpeed = 5;
    private Transform target;
    public Transform navPosition;
    private Vector3 lastKnownPlayerLocation;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public int aggroLevel = 0;
    public float timerReset = 0.0f;
    float dist = 0.0f;
    float patrolDist = 0.0f;
    Vector3 lookDir;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isIdling" , true);
        navPosition = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lastKnownPlayerLocation = new Vector3();
        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //AggroReset();
        dist = Vector3.Distance(target.position, transform.position);
        patrolDist = Vector3.Distance(points[destPoint].position, navPosition.position);
        lookDir = target.position - transform.position;
        lookDir.y = 0;

        //Patrol script. Uncomment when levels are added with nav meshes.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
        ////else if()
        ////{
        ////    //Message to call increase aggression
        ////}
        //else if (dist < 10)
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation,
        //        Quaternion.LookRotation(lookDir), rotationSpeed * Time.deltaTime);

        //    if (dist > 0.5)
        //    {
        //        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //    }
        //}
    }

    //NEED TO SET UP LIST OF PATROL POINTS
    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint].position;

        if (patrolDist < 1.0f)
        {
            destPoint = (destPoint + 1) % points.Length;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Noisy")
        {
            Debug.Log("Message Sent");
            gameObject.SendMessage("IncreaseAggression", 1);
            IncreaseAggression();
        }

        if (other.gameObject.tag == "Player")
        {
            this.GetComponent<AudioSource>();
            IncreaseAggression();
        }
    }

    public void IncreaseAggression()
    {
        Debug.Log("Aggro Increased");
        anim.SetBool("isDisturbed", true);
        aggroLevel++;
        timerReset += 5.0f;
        anim.SetBool("isDisturbed", false);
        if (aggroLevel > 2)
        {
            aggroLevel = 2;
            return;
        }

        //Cases for the Ghost Aggro
        switch (aggroLevel)
        {
            case 1:
                Debug.Log("Searching");
                //Searching for you
                lastKnownPlayerLocation = target.position;
                agent.SetDestination(lastKnownPlayerLocation);
                //Set destination to last known player postion. But dont follow. 


                break;
            case 2:
                Debug.Log("Chasing");
                if (dist < 10)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(lookDir), rotationSpeed * Time.deltaTime);

                    if (dist > 0.5)
                    {
                        transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    }
                    if (dist < 0.5)
                    {
                        //add message system to tell dimitri and the game that he is dead.
                    }
                }
                break;
            default:
                Debug.Log("Patrolling");
                //Peacefully patrolling no patrol route created or assigned.
                GoToNextPoint();
                break;
        }
    }

    void AggroReset()
    {
        if (aggroLevel >= 1)
        {
            timerReset -= Time.deltaTime;
            if (timerReset < 0)
            {
                aggroLevel--;
                Debug.Log("Aggro Reset");
                return;
            }
        }
    }
}

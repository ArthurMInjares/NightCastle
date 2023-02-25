using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BasicAI : MonoBehaviour
{
    public float speed;
    public int moveSpeed = 3;
    public int rotationSpeed = 5;
    private Transform target;
    //private Transform position;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        //agent.autoBraking = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(target.position, transform.position);
        var lookDir = target.position - transform.position;
        lookDir.y = 0;

        //Patrol script. Uncomment when levels are added with nav meshes.
        //if (!agent.pathPending && agent.remainingDistance < 0.5f)
        //{
        //    GoToNextPoint();
        //}
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

    //NEED TO SET UP LIST OF PATROL POINTS FOR EACH GHSOSTS
    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

}

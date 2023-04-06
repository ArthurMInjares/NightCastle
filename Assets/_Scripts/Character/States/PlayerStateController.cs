using UnityEditor;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public StateMachine stateMachine;       // { get { return stateMachine; } private set { stateMachine = value; } }
    public IdleState idle;               // { get { return idle; } private set { idle = value; } }
    public JumpState jump;               // { get { return jump; } private set { jump = value; } }
    public WalkingState walk;
    public DeadState dead;
    public Animator animator;           // { get { return animator; } private set { animator = value; } }
    public Rigidbody rb;                 // { get { return rb; } private set { rb = value; } }
    public Transform cam;
    public AudioSource footstepSource;/*{ get { return cam; } private set { cam = value; } }*/

    //void OnDrawGizmos()
    //{
    //    if (stateMachine.currentState != null)
    //    {
    //        Vector3 textpos = transform.position;
    //        textpos.y += 2.5f;
    //        Handles.Label(textpos, stateMachine.currentState.ToString());
    //    }
    //}


    // Start is called before the first frame update
    void Start()
    {
        //stateMachine.currentState = idle;
       // cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachine>();
        //init states
        idle = GetComponent<IdleState>();
        jump = GetComponent<JumpState>();
        //climb = GetComponent<ClimbingState>();
        walk = GetComponent<WalkingState>();
        dead = GetComponent<DeadState>();
        //sets idle as first state in scene
        stateMachine.newState = idle;
        stateMachine.currentState = idle;
        footstepSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateState();

        if (Input.GetKeyDown(KeyCode.P))
        {
            Death();
        }
    }

    //How to tell another script to kill dimitri.
    //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateController>().Death();
    public void Death()
    {
        stateMachine.newState = dead;

    }
}

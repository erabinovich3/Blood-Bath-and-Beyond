using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeenMovement : StateMachine {

    Transform player;
    Transform teen;
    NavMeshAgent nav;
    Animator anim;
    bool isHit;
    public Vector3 velocity;
    public Vector3 lastPosition;

    public GameObject[] waypoints;
    public GameObject[] fleeWPs;
    
    // Use this for initialization
    void Start () {
        lastPosition = transform.position;
        velocity = Vector3.zero;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        teen = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        
        isHit = false;
        //setCurState(new Flee(this), nav, teen, fleeWPs);


        List<GameObject> patrolList = new List<GameObject>();
        List<GameObject> fleeList = new List<GameObject>();
        GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[]; //will return an array of all GameObjects in the scene
        foreach (GameObject go in gos)
        {
            if (go.layer == 12)
            {
                patrolList.Add(go);
            }
            if (go.layer == 13)
            {
                fleeList.Add(go);
            }
        }
        waypoints = patrolList.ToArray();
        fleeWPs = fleeList.ToArray();


        setCurState(new Wander(this), nav, teen, player, waypoints, fleeWPs);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = transform.position - lastPosition;
        lastPosition = transform.position;

        if (!isHit)
        {
            getCurState().Execute();
        }else
        {
            //transform.Translate(-Vector3.up * .5f * Time.deltaTime);
        }
        anim.SetFloat("vely", nav.velocity.magnitude / nav.speed);

    }


    public void hit()
    {
        isHit = true;
        GetComponent<NavMeshAgent>().enabled = false;
        //GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 4f);
    }

    public class Wander : State
    {
        NavMeshAgent nav;
        Transform location;
        Transform player;
        GameObject[] waypoints;
        GameObject[] fleeWPs;

        public Wander(StateMachine p) : base(p)
        {

        }

        public override void Execute()
        {
            if (Vector3.Distance(location.position, player.position) <= 20)
            {
                nav.ResetPath();
                parent.changeState(new Flee(parent), nav, location, fleeWPs);
                return;
            }
            if (nav.remainingDistance <= 10)
            {
                int index = Random.Range(0, waypoints.Length);
                nav.SetDestination(waypoints[index].transform.position);
            }
            if (nav.remainingDistance <= 20)
            {
                location.LookAt(nav.destination);
            }
        }
        public override void OnEnter(params object[] values)
        {
            nav = (NavMeshAgent)values[0];
            location = (Transform)values[1];
            player = (Transform)values[2];
            waypoints = (GameObject[])values[3];
            fleeWPs = (GameObject[])values[4];

            nav.speed = 1f;
        }
        public override void OnExit()
        {

        }
        public Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
        {
            Vector3 randomDirection = Random.insideUnitSphere * distance;

            randomDirection += origin;

            NavMeshHit navHit;

            NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

            return navHit.position;
        }


    }

    public class Flee : State
    {
        NavMeshAgent nav;
        Transform location;
        GameObject[] fleeWPs;

        public Flee(StateMachine p) : base(p)
        {

        }

        public override void Execute()
        {
            if(nav.remainingDistance <= 5)
            {
                Destroy(parent.gameObject, 1f);
                nav.ResetPath();
            }
        }
        public override void OnEnter(params object[] values)
        {
            nav = (NavMeshAgent)values[0];
            location = (Transform)values[1];
            fleeWPs = (GameObject[])values[2];

            float minDist = int.MaxValue;
            GameObject target = null;
            for (int i = 0; i < fleeWPs.Length; i++)
            {
                float dist = Vector3.Distance(location.position, fleeWPs[i].transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    target = fleeWPs[i];
                }
            }
            nav.speed = 2f;
            nav.SetDestination(target.transform.position);
            Debug.Log(nav.destination);
        }
        public override void OnExit()
        {

        }
    }

}

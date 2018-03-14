using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeenMovement : StateMachine {

    Transform player;
    Transform teen;
    UnityEngine.AI.NavMeshAgent nav;
    Animator anim;
    State[] stateList;


    // Use this for initialization
    void Start () {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        teen = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        setCurState(new Wander(), nav, teen);
        

    }

    // Update is called once per frame
    void Update()
    {
        getCurState().Execute();
        anim.SetFloat("vely", nav.velocity.magnitude / nav.speed);

    }

    public class Wander : State
    {
        NavMeshAgent nav;
        Transform position;

        public override void Execute()
        {
            if (nav.remainingDistance <= 10)
            {
                Vector3 target = RandomNavSphere(position.position, 100f, -1);
                nav.SetDestination(target);
            }
            if (nav.remainingDistance <= 20)
            {
                position.LookAt(nav.destination);
            }
        }
        public override void OnEnter(params object[] values)
        {
            nav = (NavMeshAgent)values[0];
            position = (Transform)values[1];
        }
        public override void OnExit()
        {

        }
        public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

            randomDirection += origin;

            NavMeshHit navHit;

            NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

            return navHit.position;
        }

    }

    /*public class Flee : State
    {
        public override void Execute()
        {
            if (nav.remainingDistance <= 10)
            {
                Vector3 target = RandomNavSphere(position.position, 100f, -1);
                nav.SetDestination(target);
            }
            if (nav.remainingDistance <= 20)
            {
                Transform.face
            }
        }
        public override void OnEnter(params object[] values)
        {
            nav = (NavMeshAgent)values[0];
            position = (Transform)values[1];
        }
        public override void OnExit()
        {

        }
    }*/

}

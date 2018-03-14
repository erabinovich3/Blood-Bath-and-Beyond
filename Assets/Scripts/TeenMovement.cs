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
        UnityEngine.AI.NavMeshAgent nav;
        Transform position;

        public override void Execute()
        {
            if (nav.remainingDistance <= 10f)
            {
                Vector3 target = RandomNavSphere(position.position, 50f, -1);
                nav.SetDestination(target);

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


}

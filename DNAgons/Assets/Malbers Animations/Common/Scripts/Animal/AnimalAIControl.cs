using UnityEngine;
using System.Collections;
#if UNITY_5_5_OR_NEWER
using UnityEngine.AI;
#endif

namespace MalbersAnimations
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AnimalAIControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }
        public iMalbersInputs animal { get; private set; } // the character we are controlling
        public Transform target;


        // Use this for initialization
        void Start()
        {
            agent = GetComponentInChildren<NavMeshAgent>();
            animal = GetComponent<iMalbersInputs>();
            agent.updateRotation = false;
            agent.updatePosition = true;

        }

        // Update is called once per frame
        void Update()
        {

            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                animal.Move(agent.desiredVelocity);
            else
                animal.Move(Vector3.zero);
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}

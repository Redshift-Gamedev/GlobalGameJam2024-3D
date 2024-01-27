using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace GlobalGameJam.AI
{
    public class NpcMovement : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Transform targetTransform;
        [SerializeField, Min(0.01f)] private float timeToCheck = .5f;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();   
        }

        private void Start()
        {
            StartCoroutine(MoveToDestination());          
        }

        private IEnumerator MoveToDestination()
        {
            while(!agent.isStopped)
            {
                targetTransform = Tavern.Instance.GetNearestEntryPoint(transform.position).transform;
                agent.SetDestination(targetTransform.position);
                yield return new WaitForSeconds(timeToCheck);
            }      
        }
    }
}
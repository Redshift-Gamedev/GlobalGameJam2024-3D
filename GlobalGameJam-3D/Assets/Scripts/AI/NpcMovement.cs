using UnityEngine;
using UnityEngine.AI;

namespace GlobalGameJam.AI
{
    public class NpcMovement : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Transform targetTransform;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            targetTransform = FindObjectOfType<TavernMood>().transform;
        }

        private void Start()
        {
            agent.SetDestination(targetTransform.position);
        }
    }
}
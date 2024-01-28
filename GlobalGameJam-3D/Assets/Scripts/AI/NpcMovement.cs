using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace GlobalGameJam.AI
{
    public class NpcMovement : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Transform targetTransform;
        [Tooltip("How many seconds should pass from destination checks.")]
        [SerializeField, Min(0.01f)] private float timeToCheck = .5f;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            PauseListener.OnGamePauseStateChanged += HandleComponent;
        }

        private void OnEnable()
        {
            StartCoroutine(MoveToDestination());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void OnDestroy()
        {
            PauseListener.OnGamePauseStateChanged -= HandleComponent;
        }

        private void HandleComponent(bool isPaused)
        {
            if (isPaused)
            {
                if (agent.hasPath)
                {
                    agent.isStopped = true;
                }
                StopAllCoroutines();             
            }
            else
            {
                if (gameObject.activeInHierarchy)
                {
                    StartCoroutine(MoveToDestination());
                    agent.isStopped = false;
                }
            }
            if (agent.hasPath)
            {
                agent.isStopped = isPaused;
            }
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
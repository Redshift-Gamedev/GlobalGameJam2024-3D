using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class Tavern : MonoBehaviour
    {
        private List<EntrancePoint> entryPoints;
        public static Tavern Instance;

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                entryPoints = GetComponentsInChildren<EntrancePoint>().ToList();
            }
        }

        public EntrancePoint GetNearestEntryPoint(Vector3 position)
        {
            EntrancePoint nearestEntryPoint = entryPoints[0];
            float bestDistance = float.MaxValue;
            foreach(EntrancePoint currentEntryPoint in entryPoints)
            {
                float currentDistance = Vector3.Distance(position, currentEntryPoint.transform.position);
                if (currentDistance < bestDistance)
                {
                    bestDistance = currentDistance;
                    nearestEntryPoint = currentEntryPoint;
                }
            }
            return nearestEntryPoint;
        }
    }
}
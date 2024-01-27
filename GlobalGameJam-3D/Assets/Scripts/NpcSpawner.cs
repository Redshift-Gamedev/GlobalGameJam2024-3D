using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public enum NpcType { Light = 0, Medium = 1, Heavy = 2 }
    public class NpcSpawner : MonoBehaviour
    {
        [Tooltip("From weakest to strongest npc")]
        [SerializeField] private string[] NpcTags;
        [SerializeField] private List<Transform> spawnTransforms;

        [SerializeField] private float minTimeToWait;
        [SerializeField] private float maxTimeToWait;

        private void Awake()
        {
            PauseListener.OnGamePauseStateChanged += HandleComponent;
        }

        private void Start()
        {
            InvokeRepeating(nameof(SpawnNpc), 0, Random.Range(minTimeToWait, maxTimeToWait));
        }

        private void OnDestroy()
        {
            PauseListener.OnGamePauseStateChanged -= HandleComponent;
        }

        private void HandleComponent(bool isPaused)
        {
            if (isPaused)
            {
                CancelInvoke();
            }
            else
            {
                InvokeRepeating(nameof(SpawnNpc), 0, Random.Range(minTimeToWait, maxTimeToWait));
            }
        }

        private void SpawnNpc()
        {
            Transform spawnTransform = spawnTransforms[Random.Range(0, spawnTransforms.Count)];
            NpcType npcType = (NpcType) Random.Range(0, 3);
            GameObject spawnedNpc = ObjectPooler.SharedInstance.GetPooledObject(NpcTags[(int)npcType]);
            spawnedNpc.transform.SetPositionAndRotation(spawnTransform.position, spawnTransform.rotation);
            spawnedNpc.SetActive(true);
        }
    }
}
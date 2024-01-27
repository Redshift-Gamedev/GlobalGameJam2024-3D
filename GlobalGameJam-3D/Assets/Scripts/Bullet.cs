using UnityEngine;


namespace GlobalGameJam
{
    public enum BulletType { Beer, Wine, SuperAlcohol }

    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletType bulletType;

        [SerializeField] private float speed;
        [SerializeField, Range(0f, 1f)] private float _efficiency = .1f;

        private Rigidbody rb;

        private Vector3 currentVelocity;

        public BulletType BulletType => bulletType;

        public float Efficiency => _efficiency;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            PauseListener.OnGamePauseStateChanged += PauseBullet;
        }

        private void OnEnable()
        {
            rb.velocity = transform.forward * speed;
            currentVelocity = rb.velocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            currentVelocity = rb.velocity;
        }

        private void OnDestroy()
        {
            PauseListener.OnGamePauseStateChanged -= PauseBullet;
        }

        private void PauseBullet(bool isPaused)
        {
            rb.velocity = isPaused ? Vector3.zero : currentVelocity;
            rb.useGravity = !isPaused;
        }
    }
}
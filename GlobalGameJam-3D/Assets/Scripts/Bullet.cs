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

        public BulletType BulletType => bulletType;

        public float Efficiency => _efficiency;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            rb.velocity = transform.forward * speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
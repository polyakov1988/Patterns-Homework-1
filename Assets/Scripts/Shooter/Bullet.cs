using UnityEngine;

namespace Shooter
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private float _force;

        public void AddForce()
        {
            _rigidbody.AddForce(Vector3.right * _force, ForceMode.Impulse);
        }

        public void SetColor(Color color)
        {
            _renderer.material.color = color;
        }
    }
}

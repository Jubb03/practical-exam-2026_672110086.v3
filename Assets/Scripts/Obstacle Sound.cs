using UnityEngine;

namespace chadsadaporn_babpa.Exam
{
    public class ObstacleSound : MonoBehaviour
    {
        [SerializeField] AudioClip sfx;
        [SerializeField] float cooldown = 0.5f;

        float m_Next;

        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (Time.time < m_Next) return;
            m_Next = Time.time + cooldown;
            if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(sfx);
        }
    }
}
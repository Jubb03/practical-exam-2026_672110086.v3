using chadsadaporn_babpa.Exam;
using UnityEngine;

namespace chadsadaporn_babpa.Exam
{
    public class KillZone : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) GameManager.Instance.Lose();
        }
    }
}
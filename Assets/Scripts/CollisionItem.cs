using UnityEngine;

namespace chadsadaporn_babpa.Exam
{
    public enum ItemKind { TimePlus, TimeMinus, ScorePlus, ScoreMinus }

    public class CollisionItem : MonoBehaviour
    {
        [SerializeField] ItemKind kind;

        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            switch (kind)
            {
                case ItemKind.TimePlus: GameManager.Instance.AddTime(3f); break;
                case ItemKind.TimeMinus: GameManager.Instance.AddTime(-5f); break;
                case ItemKind.ScorePlus: GameManager.Instance.AddScore(500); break;
                case ItemKind.ScoreMinus: GameManager.Instance.AddScore(-500); break;
            }
            Destroy(gameObject);
        }
    }
}
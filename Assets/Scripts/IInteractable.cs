using UnityEngine;

namespace chadsadaporn_babpa.Exam
{
    // Stage 2: เก็บด้วยปุ่ม E (ไม่ใช้ OnTriggerEnter)
    public class InteractableItem : MonoBehaviour, IInteractable
    {
        [SerializeField] ItemKind kind;
        [SerializeField] AudioClip sfx;
        [SerializeField] GameObject promptUI;   // Canvas World Space "E : Collect"

        void Start() { if (promptUI != null) promptUI.SetActive(false); }

        public void OnActorEnter() { if (promptUI != null) promptUI.SetActive(true); }
        public void OnActorExit() { if (promptUI != null) promptUI.SetActive(false); }

        public void Interact(GameObject actor)
        {
            switch (kind)
            {
                case ItemKind.TimePlus: GameManager.Instance.AddTime(3f); break;
                case ItemKind.TimeMinus: GameManager.Instance.AddTime(-5f); break;
                case ItemKind.ScorePlus: GameManager.Instance.AddScore(500); break;
                case ItemKind.ScoreMinus: GameManager.Instance.AddScore(-500); break;
            }

            if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(sfx);
            Destroy(gameObject);
        }
    }
}
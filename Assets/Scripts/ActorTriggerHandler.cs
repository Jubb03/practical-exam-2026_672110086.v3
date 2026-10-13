using System.Collections.Generic;
using UnityEngine;

namespace chadsadaporn_babpa.Exam
{
    // หน้าที่เดียว: ตรวจระยะและเก็บรายการวัตถุที่อยู่ในรัศมี (ไม่อ่านปุ่ม)
    public class ActorTriggerHandler : MonoBehaviour
    {
        readonly List<IInteractable> m_Triggered = new List<IInteractable>();

        void OnTriggerEnter(Collider other)
        {
            var it = other.GetComponentInParent<IInteractable>();
            if (it == null || m_Triggered.Contains(it)) return;
            m_Triggered.Add(it);
            it.OnActorEnter();
        }

        void OnTriggerExit(Collider other)
        {
            var it = other.GetComponentInParent<IInteractable>();
            if (it == null || !m_Triggered.Remove(it)) return;
            it.OnActorExit();
        }

        public IInteractable GetInteractable()
        {
            m_Triggered.RemoveAll(i => (i as UnityEngine.Object) == null);

            IInteractable nearest = null;
            float best = float.MaxValue;
            foreach (var i in m_Triggered)
            {
                float d = Vector3.Distance(((MonoBehaviour)i).transform.position, transform.position);
                if (d < best) { best = d; nearest = i; }
            }
            return nearest;
        }
    }
}
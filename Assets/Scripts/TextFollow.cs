using UnityEngine;

namespace chadsadaporn_babpa.Exam
{
    public class WorldSpaceBillboard : MonoBehaviour
    {
        void LateUpdate()
        {
            if (Camera.main != null)
                transform.forward = Camera.main.transform.forward;
        }
    }
}
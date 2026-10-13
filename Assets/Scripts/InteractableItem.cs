using UnityEngine;

namespace chadsadaporn_babpa.Exam
{
    public interface IInteractable
    {
        void Interact(GameObject actor);
        void OnActorEnter();
        void OnActorExit();
    }
}
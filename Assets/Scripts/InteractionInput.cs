using UnityEngine;
using UnityEngine.InputSystem;

namespace chadsadaporn_babpa.Exam
{
    public class InteractionInput : MonoBehaviour
    {
        [SerializeField] ActorTriggerHandler handler;

        // Action ???? Interact ??????? E (???????? Inspector)
        [SerializeField]
        InputAction interactAction =
            new InputAction("Interact", InputActionType.Button, "<Keyboard>/e");

        void OnEnable()
        {
            interactAction.performed += OnInteractPerformed;
            interactAction.Enable();
        }

        void OnDisable()
        {
            interactAction.performed -= OnInteractPerformed;
            interactAction.Disable();
        }

        void OnInteractPerformed(InputAction.CallbackContext ctx)
        {
            var target = handler.GetInteractable();
            if (target != null) target.Interact(gameObject);
        }
    }
}
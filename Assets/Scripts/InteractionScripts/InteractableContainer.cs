using System.Linq;

namespace InteractionScripts
{
    public class InteractableContainer : Interactable
    {
        public Interactable[] interactables;
        public override bool CanInteract()
        {
            return interactables.All(i => i.CanInteract());
        }

        public override void OnInteract()
        {
            foreach (Interactable interactable in interactables)
            {
                interactable.OnInteract();
            }
        }
    }
}

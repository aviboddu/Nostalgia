namespace InteractionScripts
{
    // This class is a simple interaction where an object progresses the objective to a given index.
    public class GoToObjectiveInteraction : Interactable
    {
        public int objectiveNumberToGoTo;
        private bool _canInteract = true;
        public override bool CanInteract()
        {
            return _canInteract;
        }

        public override void OnInteract()
        {
            _canInteract = false;
            ObjectiveManager.Manager.ProgressToObjectiveNumber(objectiveNumberToGoTo);
        }
    }
}

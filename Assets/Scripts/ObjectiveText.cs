using TMPro;
using UnityEngine;

public class ObjectiveText : MonoBehaviour
{
    private TMP_Text _objectiveText;
    private void Awake()
    {
        _objectiveText = gameObject.GetComponent<TMP_Text>();
        _objectiveText.text = ObjectiveManager.Manager.GetCurrentObjectiveText();
        ObjectiveManager.Manager.ObjectiveChange += UpdateText; // Adds the relevant method to the listener.
    }

    // Called whenever the objective is updated.
    private void UpdateText(int currentObjectiveNumber)
    {
        _objectiveText.text = ObjectiveManager.Manager.GetCurrentObjectiveText();
    }
}

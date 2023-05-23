using TMPro;
using UnityEngine;
using System.Collections;

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
        StopAllCoroutines();
        StartCoroutine(transitionObjectiveName());
    }

    private IEnumerator transitionObjectiveName(float t1 = 0.5f, float t2 = 0.5f)
    {
        StartCoroutine(fade(_objectiveText.alpha, 0, t1));
        yield return new WaitForSeconds(t1);
        _objectiveText.text = ObjectiveManager.Manager.GetCurrentObjectiveText();
        StartCoroutine(fade(_objectiveText.alpha, 1, t2));
    }

    private IEnumerator fade(float initial, float final, float t)
    {
        for (float time = 0; time < t; time += Time.deltaTime)
        {
            _objectiveText.alpha = initial + (final - initial) * (time / t);
            yield return null;
        }
        _objectiveText.alpha = final;
    }
}

using System;
using System.IO;
using UnityEngine;

// Objective Manager Singleton.
public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Manager;
    
    // List the objectives here, seperated by new lines
    private const String ObjectiveListPath = "./Assets/Text/ObjectiveList.txt";

    public delegate void OnObjectiveChange(int currentObjective);
    // If you wish to listen to the objective change event, add the relevant method to this delegate.
    // See ObjectiveText for an example.
    public OnObjectiveChange ObjectiveChange;

    private String[] _objectives;
    private int _currentObjective; // Note that this index starts at 0.
    private void Awake()
    {
        if (Manager is not null)
            return;
        
        Manager = this;
        
        StreamReader reader = new StreamReader(ObjectiveListPath);
        _objectives = reader.ReadToEnd().Split('\n');
        reader.Close();
        
        _currentObjective = 0;
    }

    // Returns a copy of the current objective text
    public String GetCurrentObjectiveText()
    {
        if (!Equals(Manager))
            throw new MethodAccessException("ObjectiveManager::GetCurrentObjectiveText() must be accessed " +
                                            "via the Manager singleton. Try obj.Manager.GetCurrentObjectiveText()");
        return (String) _objectives[_currentObjective].Clone();
    }

    // Returns the current objective number.
    public int GetCurrentObjectiveNumber()
    {
        if (!Equals(Manager))
            throw new MethodAccessException("ObjectiveManager::GetCurrentObjectiveNumber() must be accessed " +
                                            "via the Manager singleton. Try obj.Manager.GetCurrentObjectiveNumber()");
        return _currentObjective;
    }

    // Attempts to progress to the given objective number.
    // Sometimes we would already be past the given objective number, in which case nothing happens and we return false.
    // Otherwise we return true.
    public bool ProgressToObjectiveNumber(int objectiveNum)
    {
        if (!Equals(Manager))
            throw new MethodAccessException($"ObjectiveManager::ProgressToObjectiveNumber({objectiveNum}) must be accessed " +
                                            $"via the Manager singleton. Try obj.Manager.ProgressToObjectiveNumber({objectiveNum})");
        if (objectiveNum <= _currentObjective)
            return false;
        if (objectiveNum >= _objectives.Length)
            throw new IndexOutOfRangeException($"ObjectiveManager::ProgressToObjectiveNumber({objectiveNum}) " +
                                               $"failed because {objectiveNum} >= {_objectives.Length}");
        _currentObjective = objectiveNum;
        ObjectiveChange?.Invoke(_currentObjective);
        return true;
    }
}
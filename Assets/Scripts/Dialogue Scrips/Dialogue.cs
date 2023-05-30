using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionScripts;

namespace DialogueScripts
{
    [System.Serializable]
    public class Dialogue
    {
        [TextArea(3, 10)]
        public string[] sentences;
    }
}
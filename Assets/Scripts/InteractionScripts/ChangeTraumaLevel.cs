using UnityEngine;

namespace InteractionScripts
{
    public class ChangeTraumaLevel : Interactable
    {
        public float desiredTraumaLevel;
        public GameObject traumaManager;
        private TraumaEffect _traumaEffect;
        // Start is called before the first frame update
        void Start()
        {
            _traumaEffect = traumaManager.GetComponent<TraumaEffect>();
        }


        public override bool CanInteract()
        {
            return true;
        }

        public override void OnInteract()
        {
            _traumaEffect.SetTraumaLevel(desiredTraumaLevel);
        }
    }
}

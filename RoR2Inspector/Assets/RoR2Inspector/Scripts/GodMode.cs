using RoR2;
using UnityEngine;

namespace RoR2Inspector
{
    public class GodMode : MonoBehaviour
    {
        public bool Active { get; set; }

        void Awake()
        {
            On.RoR2.HealthComponent.TakeDamage += (orig, self, damageInfo) => {
                if (!Active)
                {
                    orig(self, damageInfo);
                    return;
                }
                var charComponent = self.GetComponent<CharacterBody>();
                if (charComponent != null && charComponent.isPlayerControlled)
                {
                    return;
                }
                orig(self, damageInfo);
            };
        }

        public void Toggle()
        {
            Active = !Active;
        }
    }
}

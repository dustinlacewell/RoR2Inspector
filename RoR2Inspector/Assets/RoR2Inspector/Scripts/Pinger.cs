using RoR2;
using RuntimeInspector;
using UnityEngine;

namespace RoR2Inspector
{
    public static class Pinger
    {
        private static Transform currentSelection;
        private static GameObject indicator;

        private const string prefabPath = "Prefabs/PositionIndicators/PoiPositionIndicator";

        private static GameObject GetInstance()
        {
            if (indicator != null)
                return indicator;

            var indicatorPrefab = Resources.Load<GameObject>(prefabPath);
            indicator = Object.Instantiate(indicatorPrefab);
            return indicator;
        }

        public static void SetPing(Transform t)
        {
            var indicator = GetInstance();
            indicator.transform.parent = t;
            indicator.transform.position = t.position;
            indicator.transform.rotation = t.rotation;

            indicator.GetComponent<PositionIndicator>().targetTransform = t;
        }
    }
}
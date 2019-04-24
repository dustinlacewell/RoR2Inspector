using MultiMod.Interface;
using RuntimeInspector;
using UnityEngine;
using UnityEngine.UI;


namespace RoR2Inspector
{
    public class StartupScript : ModBehaviour
    {
        RuntimeHierarchy hierarchy;
        RuntimeInspector.RuntimeInspector inspector;

        public override void OnLoaded(ContentHandler contentHandler)
        {
            RuntimeInspectorStartup.AddListener((sender, evt) => {
                var ris = sender as RuntimeInspectorStartup;

                var tpContainer = ris.transform.Find("Container/Menu/Third-party Group");
                if (tpContainer)
                    transform.SetParent(tpContainer.transform);
                else
                    Debug.LogError("Couldn't find RuntimeInspector UI Third-party Group!");

                var uiContainer = ris.transform.Find("Container");
                if (uiContainer)
                {
                    uiContainer.SetParent(RoR2.RoR2Application.instance.mainCanvas.transform);
                    uiContainer.SetAsLastSibling();
                } else
                {
                    Debug.LogError("Couldn't find RuntimeInspector UI Container!");
                }
                hierarchy = ris.Hierarchy;
                inspector = ris.Inspector;
                ( (RuntimeInspectorStartup)sender ).Hierarchy.OnSelectionChanged += Pinger.SetPing;
            });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                ToggleCursor.Toggle();
            }

            var pick = MousePicker.Pick();
            if (pick != null)
            {
                hierarchy.Select(pick.transform);
            }
        }
    }
}
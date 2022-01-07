using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class WatchScript : MonoBehaviour
    {
        //by making a script subclass that, the wrist will pick them up at start time and will notify them it's been loaded
        //this will allow them to add button to the UI that are scene specific.
        public abstract class UIHook : MonoBehaviour
        {
            public abstract void GetHook(WatchScript watch);
        }

        public float LoadingTime = 2.0f;
        public Slider LoadingSlider;

        [Header("UI")]
        public Canvas RootCanvas;
        public Transform ButtonParentTransform;
        public Button ButtonPrefab;

        [Header("Event")]
        public UnityEvent OnLoaded;
        public UnityEvent OnUnloaded;

        public GameObject UILineRenderer;

        bool m_Loading = false;
        float m_LoadingTimer;

        void Start()
        {
            LoadingSlider.gameObject.SetActive(false);

            var hooks = FindObjectsOfType<UIHook>();
            foreach (var h in hooks)
            {
                h.GetHook(this);
            }

            RootCanvas.worldCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (m_Loading)
            {
                m_LoadingTimer += Time.deltaTime;
                LoadingSlider.value = Mathf.Clamp01(m_LoadingTimer / LoadingTime);
                if (m_LoadingTimer >= LoadingTime)
                {
                    OnLoaded.Invoke();
                    UILineRenderer.SetActive(true);
                    LoadingSlider.gameObject.SetActive(false);
                    m_Loading = false;
                }
            }
        }

        public void LookedAt()
        {
            m_Loading = true;
            m_LoadingTimer = 0.0f;
            LoadingSlider.value = 0.0f;
            LoadingSlider.gameObject.SetActive(true);
        }

        public void LookedAway()
        {
            m_Loading = false;
            OnUnloaded.Invoke();
            LoadingSlider.gameObject.SetActive(false);
            UILineRenderer.SetActive(false);
        }

        public void AddButton(string name, UnityAction clickedEvent)
        {
            var newButton = Instantiate(ButtonPrefab, ButtonParentTransform);
            var text = newButton.GetComponentInChildren<Text>();

            RecursiveLayerChange(newButton.transform, ButtonParentTransform.gameObject.layer);

            text.text = name;

            newButton.onClick.AddListener(clickedEvent);
        }


        void RecursiveLayerChange(Transform root, int layer)
        {
            foreach (Transform t in root)
            {
                RecursiveLayerChange(t, layer);
            }

            root.gameObject.layer = layer;
        }
    }

}

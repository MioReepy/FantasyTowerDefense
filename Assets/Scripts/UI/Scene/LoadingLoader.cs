using UnityEngine;

namespace UISpace
{
    public class LoadingLoader : MonoBehaviour
    {
        internal bool isFirstLoad = true;

        [SerializeField] private Transform backgrounds;
        private void Awake()
        {
            for(int i = 0; i < backgrounds.childCount; i++)
            {
                backgrounds.GetChild(i).gameObject.SetActive(false);
            }
            
            backgrounds.GetChild(Random.Range(0, backgrounds.childCount - 1)).gameObject.SetActive(true);
        }
        
        private void Update()
        {
            if (isFirstLoad)
            {
                isFirstLoad = false;
                Loader.LoaderCallback();
            }
        }
    }
}

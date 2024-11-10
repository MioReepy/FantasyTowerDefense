using UnityEngine;

namespace UISpace
{
    public class LoadingLoader : MonoBehaviour
    {
        private bool _isFirstLoad = true;

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
            if (!_isFirstLoad) return;
            
            _isFirstLoad = false;
            Loader.LoaderCallback();
        }
    }
}

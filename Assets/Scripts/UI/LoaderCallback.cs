using UnityEngine;

namespace UISpace
{
    public class LoaderCallback : MonoBehaviour
    {
        internal bool isFirstLoad = true;

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

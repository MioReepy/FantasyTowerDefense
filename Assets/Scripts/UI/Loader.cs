using UnityEngine.SceneManagement;

namespace UISpace
{
    public static class Loader
    {
        public enum Scene
        {
            GameScene = 0, 
            Loading = 1,
            MainMenu = 2,
            UIScene = 3,
        }

        private static Scene _targetScene;
        private static bool _isLodUISystem;
        
        public static void Load(Scene scene, bool isLoadLoadingScene, bool isLodUISystem)
        {
            _targetScene = scene;
            _isLodUISystem = isLodUISystem;

            if (isLoadLoadingScene)
            {
                SceneManager.LoadScene(Scene.Loading.ToString());
            }
            else
            {
                LoaderCallback();
            }
        }

        public static void LoaderCallback()
        {
            if (_isLodUISystem)
            {
                SceneManager.LoadSceneAsync(_targetScene.ToString());
                SceneManager.LoadSceneAsync(Scene.UIScene.ToString(), LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.LoadScene(_targetScene.ToString());
            }
        }
    }
}
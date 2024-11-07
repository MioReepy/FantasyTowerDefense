using UnityEngine.SceneManagement;

namespace UISpace
{
    public static class Loader
    {
        public enum Scene
        {
            CreatorLogo = 0,
            GameScene = 1, 
            Loading = 2,
            MainMenu = 3,
            UIScene = 4
        }

        private static Scene _targetScene;
        private static bool _isLodUISystem;
        
        public static void Load(Scene scene, bool isLoadingScene, bool isLodUISystem)
        {
            _targetScene = scene;
            _isLodUISystem = isLodUISystem;

            if (isLoadingScene)
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
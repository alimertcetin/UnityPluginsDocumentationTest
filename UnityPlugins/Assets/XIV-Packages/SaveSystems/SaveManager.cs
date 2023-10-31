using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using XIV_Packages.ScriptableObjects.Channels;

namespace XIV_Packages.SaveSystems
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] IntChannelSO saveSceneDataChannel;
        [SerializeField] IntChannelSO loadSceneDataChannel;
        
        [SerializeField] VoidChannelSO onSaveCompletedChannel;
        [SerializeField] VoidChannelSO onLoadCompletedChannel;

        bool isSaving;
        bool isLoading;

        void Start()
        {
            LoadAllOpenScenesImmediate();
        }

        void OnEnable()
        {
            saveSceneDataChannel.Register(SaveSceneData);
            loadSceneDataChannel.Register(LoadSceneData);
        }

        void OnDisable()
        {
            saveSceneDataChannel.Unregister(SaveSceneData);
            loadSceneDataChannel.Unregister(LoadSceneData);
        }

        void OnApplicationQuit()
        {
            SaveAllOpenScenesImmediate();
        }

        static void SaveAllOpenScenesImmediate()
        {
            int count = SceneManager.sceneCount;
            for (int i = 0; i < count; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                SaveSystem.Save(scene.name);
            }
        }

        static void LoadAllOpenScenesImmediate()
        {
            int count = SceneManager.sceneCount;
            for (int i = 0; i < count; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                SaveSystem.Load(scene.name);
            }
        }

        void SaveSceneData(int sceneIndex)
        {
            if (isSaving) return;
            var sceneName = SceneManager.GetSceneByBuildIndex(sceneIndex).name;
            StartCoroutine(WaitSave(sceneName));
        }

        void LoadSceneData(int sceneIndex)
        {
            if (isLoading) return;
            var sceneName = SceneManager.GetSceneByBuildIndex(sceneIndex).name;
            StartCoroutine(WaitLoad(sceneName));
        }

        IEnumerator WaitSave(string sceneName)
        {
            isSaving = true;
            yield return SaveSystem.SaveAsync(sceneName);
            onSaveCompletedChannel.RaiseEvent();
            isSaving = false;
        }

        IEnumerator WaitLoad(string sceneName)
        {
            isLoading = true;
            yield return SaveSystem.LoadAsync(sceneName);
            onLoadCompletedChannel.RaiseEvent();
            isLoading = false;
        }
    }
}
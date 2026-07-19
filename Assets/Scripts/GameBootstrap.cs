using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class GameBootstrap : MonoBehaviour
{
    private async void Awake()
    {
        await LocalizationSettings.InitializationOperation.Task;

        SceneManager.LoadScene("TextMeshProLocalizationDemo");
    }
}

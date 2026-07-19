using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LanguageChangeUI : MonoBehaviour
{
    [SerializeField] private Button russianButton;
    [SerializeField] private Button englishButton;

    private void Awake()
    {
        russianButton.onClick.AddListener(() => SetLanguage("ru"));
        englishButton.onClick.AddListener(() => SetLanguage("en"));
    }

    public void SetLanguage(string language)
    {
        Locale locale = LocalizationSettings.AvailableLocales.GetLocale(language);

        if (locale != null)
            LocalizationSettings.SelectedLocale = locale;
    }
}



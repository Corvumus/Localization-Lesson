using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UIElements;

[RequireComponent(typeof(PanelRenderer))]
public class LanguageChangeUIEvents : MonoBehaviour
{
    private PanelRenderer panelRenderer;
    private Button russianButton;
    private Button englishButton;

    private EventCallback<ClickEvent> onRussianClicked;
    private EventCallback<ClickEvent> onEnglishClicked;

    private int lastVersion;

    private void Awake()
    {
        panelRenderer = GetComponent<PanelRenderer>();
        
        onRussianClicked = evt => SetLanguage("ru");
        onEnglishClicked = evt => SetLanguage("en");
    }

    private void OnEnable()
    {
        panelRenderer.RegisterUIReloadCallback(OnUIReloadedCallback);

        russianButton.RegisterCallback(onRussianClicked);
        englishButton.RegisterCallback(onEnglishClicked);
    }

    private void OnDisable()
    {
        panelRenderer.UnregisterUIReloadCallback(OnUIReloadedCallback);

        russianButton.UnregisterCallback(onRussianClicked);
        englishButton.UnregisterCallback(onEnglishClicked);
    }

    private void OnUIReloadedCallback(PanelRenderer panelRenderer, VisualElement rootElement, int version)
    {
        if (lastVersion == version)
            return;

        lastVersion = version;

        russianButton = rootElement.Q<Button>("RussianButton");
        englishButton = rootElement.Q<Button>("EnglishButton");
    }

    public void SetLanguage(string language)
    {
        Locale locale = LocalizationSettings.AvailableLocales.GetLocale(language);

        if (locale != null)
            LocalizationSettings.SelectedLocale = locale;
    }
}

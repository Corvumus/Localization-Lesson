using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private LocalizeStringEvent localizedStringEvent;

    [SerializeField] private LocalizedString helloWorldString;

    [SerializeField] private Button helloButton;
    [SerializeField] private Button goodbyeButton;

    private void Awake()
    {
        helloButton.onClick.AddListener(SetHello);
        goodbyeButton.onClick.AddListener(SetGoodbye);
    }

    private void SetHello()
    {
        SetLocalizedString(helloWorldString);
    }

    private void SetGoodbye()
    {
        LocalizedString goobyeLS = new("MyStrings", "GOODBYE_WORLD");
        SetLocalizedString(goobyeLS);
    }

    public void SetLocalizedString(LocalizedString ls)
    {
        localizedStringEvent.StringReference = ls;
    }
}


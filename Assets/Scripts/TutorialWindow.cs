using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialWindow : MonoBehaviour
{
    private static TutorialWindow instance;
    private void Awake()
    {
        instance = this;
        Hide();
    }

    private void Update()
    {
        if(gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space)){
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowStatic()
    {
        instance.Show();
    }

    public static void HideStatic()
    {
        instance.Hide();
    }
}
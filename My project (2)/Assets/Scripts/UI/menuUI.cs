using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class menuUI : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject Controls;
    public Button menuToControlsButton;
    public Button controlsToMenuButton;

    void Start()
    {
    }
    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            MenuUI.SetActive(!MenuUI.activeSelf);

            if (MenuUI.activeSelf == true)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            if (MenuUI.activeSelf == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }


    }

    public void OnmenuToControlsButton()
    {
        MenuUI.SetActive(!MenuUI.activeSelf);
        Controls.SetActive(!Controls.activeSelf);
    }
    public void OncontrolsToMenuButton()
    {
        MenuUI.SetActive(!MenuUI.activeSelf);
        Controls.SetActive(!Controls.activeSelf);
    }



}

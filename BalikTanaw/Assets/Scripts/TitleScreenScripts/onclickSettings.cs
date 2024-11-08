using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickSettings : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject buttonsParent; 
    private Animator animator;
    private bool isSettingsOpen = false; 

    void Start()
    {
        animator = settingsPanel.GetComponent<Animator>();
        settingsPanel.SetActive(false); 
    }

    public void ToggleSettingsPanel()
    {
        if (isSettingsOpen)
        {
            CloseSettingsPanel();
        }
        else
        {
            OpenSettingsPanel();
        }
    }

    private void OpenSettingsPanel()
    {
        isSettingsOpen = true; 
        settingsPanel.SetActive(true); 
        animator.SetTrigger("Open"); 
        buttonsParent.SetActive(false); 
    }

    private void CloseSettingsPanel()
    {
        isSettingsOpen = false;
        animator.SetTrigger("Close"); 
        Invoke("DeactivatePanel", 0.5f); 
    }

    private void DeactivatePanel()
    {
        settingsPanel.SetActive(false); 
        buttonsParent.SetActive(true); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public List<Animator> unlockUI;

    public static MainMenu instance;
    static List<Combination> unlocked = new List<Combination>();

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menu.activeSelf)
            {
                CheckUnlocks();
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddUnlock(Combination com)
    {
        if (!unlocked.Contains(com))
        {
            unlocked.Add(com);
        }
    }

    public void CheckUnlocks()
    {
        foreach (Animator anim in unlockUI)
        {
            foreach (Combination c in unlocked)
            {
                if (anim.gameObject.name == c.name)
                {
                    anim.SetBool("found", true);
                }
            }
        }
    }
}

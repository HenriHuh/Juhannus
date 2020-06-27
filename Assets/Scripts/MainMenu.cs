using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public Animator canvasAnimator;
    public List<Animator> unlockUI;
    public AnimationCurve menuCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public AudioClip open, close;

    public static MainMenu instance;
    static List<Combination> unlocked = new List<Combination>();

    bool menuUp = false;
    float menuWeight = 0f;
    float menuTime = 0f;
    float menuTarget = 0f;
    [SerializeField]
    float menuSpeed = 3f;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MenuToggle();
        }
        //Update canvas position in LayerWeight
        menuTime = Mathf.MoveTowards(menuTime, menuTarget, menuSpeed * Time.deltaTime);
        menuWeight = menuCurve.Evaluate(menuTime);
        canvasAnimator.SetLayerWeight(1, menuWeight);

    }

    public void MenuToggle()
    {
        if (menuTime == 1f || menuTime == 0f)
        {

          if (menuUp == false)
          {
              CheckUnlocks();
              //Open menu, Set "up" layer to 1
              menuTarget = 1;
              menuUp = true;
              AudioManager.instance.Play(open, 0.6f);
          }
          else
          {
              menuTarget = 0;
              //Close menu, Set "up" layer to 0
              menuUp = false;
              AudioManager.instance.Play(close, 0.6f);
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

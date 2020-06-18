using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    [Range(15, 250)]
    public int targetFrameRate = 144;
    WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

//    void Start()
//    {
//        Application.targetFrameRate = targetFrameRate;
//    }

    IEnumerator Start()
    {
      while (true)
      {
          Application.targetFrameRate = targetFrameRate;
          Debug.Log("TargetFrameRate = " + targetFrameRate);
          yield return waitForSeconds;
      }
    }

}

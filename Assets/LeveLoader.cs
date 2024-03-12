using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeveLoader : MonoBehaviour
{
    public GameObject EndingText;
    public Animator transition;
    public float transitionTime = 10;

    // Update is called once per frame
    void Update()
    {
        if (EndingText.activeSelf)
        {
            print("animation");
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        // Play animation
        transition.SetTrigger("Start");

        // wait
        yield return new WaitForSeconds(transitionTime);

        // load scene
        SceneManager.LoadScene(sceneIndex);

    }
}

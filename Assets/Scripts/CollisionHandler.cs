using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    int currentSceneIndex;
    int nextSceneIndex;

    void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly!");
                break;
            case "Finish":
                LoadNextLevel();
                Debug.Log("This is the finish!");
                break;
            default:
                ReloadLevel();
                Debug.Log("Sorry, you blew up!");
                break;
        }
    }

    void LoadNextLevel()
    {
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    
    void ReloadLevel() 
    {   
        SceneManager.LoadScene(currentSceneIndex);
    }
}

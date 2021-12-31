using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip finishSound;
    AudioSource eventAudio;

    void Start()
    {
        eventAudio = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag) 
        {
            case "Friendly":
                Debug.Log("Friendly obstacle!");
                break;
            case "Fuel":
                Debug.Log("It's fuel!");
                break;
            case "Finish":
                NextLevelSequence();
                break;
            default:
                CrashSequence();
                break;
        }
    }

    void NextLevelSequence()
    {
        GetComponent<Movement>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        eventAudio.PlayOneShot(finishSound);
        Invoke("NextLevel", delayTime);
    }

    void CrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        eventAudio.PlayOneShot(crashSound);
        Invoke("ReloadLevel", delayTime);
    }

    void ReloadLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    void NextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndex++;
        if (sceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            sceneIndex = 0;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}

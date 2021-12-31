using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip finishSound;
    AudioSource eventAudio;
    bool isTransition = false;

    void Start()
    {
        eventAudio = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other) {
        if (!isTransition)
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
        eventAudio.Stop();
        eventAudio.PlayOneShot(finishSound);
        Invoke("NextLevel", delayTime);
        isTransition = true;
    }

    void CrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        eventAudio.Stop();
        eventAudio.PlayOneShot(crashSound);
        Invoke("ReloadLevel", delayTime);
        isTransition = true;
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

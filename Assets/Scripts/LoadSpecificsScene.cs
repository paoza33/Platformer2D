using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificsScene : MonoBehaviour
{
    public string scene;
    public Animator fadeSystem;
    public AudioClip AudioClip;

    private void Awake() {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            AudioManager.instance.PlayClipAt(AudioClip, transform.position);
            StartCoroutine(Fade());
        }
    }
    public IEnumerator Fade(){
        LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}

using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ChangeSceneByVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;  
    [SerializeField] private LevelChanger levelChanger;  

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        levelChanger.FadeToLevel("Tutorial");
    }
}

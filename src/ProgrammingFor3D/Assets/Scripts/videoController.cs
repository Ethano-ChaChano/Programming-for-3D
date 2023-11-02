using UnityEngine;
using UnityEngine.Video;

public class videoController : entryPoint
{
    public VideoPlayer videoPlayer;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            videoPlayer.Play();
            controller.HasEntered(location);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player") { videoPlayer.Stop(); }
    }
}

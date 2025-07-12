using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource source;
    double pauseClipTime=0;
    public AudioClip[] clips;
    int currentClipIndex = 0;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clips[0];
        source.Play();
    }
    private void Update()
    {
        if (source.time >= clips[currentClipIndex].length)
        {
            currentClipIndex++;
            if (currentClipIndex>clips.Length-1)
            {
                currentClipIndex = 0;
            }
            source.clip = clips[currentClipIndex];
            source.Play();
        }
    }
    public void OnPauseGame()
    {
        pauseClipTime = source.time;
        source.Pause();
    }
    public void OnResumeGame()
    {
        source.PlayScheduled(pauseClipTime);
        pauseClipTime = 0;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial followed by https://www.youtube.com/watch?v=QL29aTa7J5Q&t=102s&ab_channel=CodeMonkey
public class GameAssets : MonoBehaviour
{

    private static GameAssets instance;

    public static GameAssets Instance
    {
        get
        {
            if (instance == null)
                instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return instance;
        }
    }

    public SoundAudioClip[] soundAudioClips;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}

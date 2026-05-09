using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VNCharacter : MonoBehaviour
{
    [Header("Parts")]
    [SerializeField] private Image eyes;
    [SerializeField] private Image mouth;

    [System.Serializable]
    public class EmotionSet
    {
        public Sprite eyes;
        public Sprite mouthClosed;
        public Sprite mouthOpen;
    }

    [Header("Emotions")]
    [SerializeField] private EmotionSet neutral;
    [SerializeField] private EmotionSet happy;
    [SerializeField] private EmotionSet angry;
    [SerializeField] private EmotionSet sad;

    private Dictionary<string, EmotionSet> emotions;

    private void Awake()
    {
        emotions = new Dictionary<string, EmotionSet>
        {
            { "neutral", neutral },
            { "happy", happy },
            { "angry", angry },
            { "sad", sad }
        };
    }

    public void SetEmotion(string emotion, bool isSpeaking)
    {
        if (!emotions.ContainsKey(emotion))
            emotion = "neutral";

        EmotionSet set = emotions[emotion];

        if (eyes != null)
            eyes.sprite = set.eyes;

        if (mouth != null)
            mouth.sprite = isSpeaking ? set.mouthOpen : set.mouthClosed;
    }

    public void SetIdle()
    {
        SetEmotion("neutral", false);
    }
}
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public enum AutoSpeed { Slow, Medium, Fast }

    public bool autoEnabled;
    public AutoSpeed autoSpeed = AutoSpeed.Medium;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSettings();
    }

    // ===== UI BUTTON FUNCTIONS =====

    public void AutoOn()
    {
        SetAuto(true);
        Debug.Log("AUTO ON");
    }

    public void AutoOff()
    {
        SetAuto(false);
        Debug.Log("AUTO OFF");
    }

    public void SpeedSlow()
    {
        SetSpeed(AutoSpeed.Slow);
        Debug.Log("SLOW");
    }

    public void SpeedMedium()
    {
        SetSpeed(AutoSpeed.Medium);
        Debug.Log("MEDIUM");
    }

    public void SpeedFast()
    {
        SetSpeed(AutoSpeed.Fast);
        Debug.Log("FAST");
    }

    // ===== CORE LOGIC =====

    public void SetAuto(bool value)
    {
        autoEnabled = value;
        PlayerPrefs.SetInt("autoEnabled", value ? 1 : 0);
    }

    public void SetSpeed(AutoSpeed speed)
    {
        autoSpeed = speed;
        PlayerPrefs.SetInt("autoSpeed", (int)speed);
    }

    public void LoadSettings()
    {
        autoEnabled = PlayerPrefs.GetInt("autoEnabled", 0) == 1;
        autoSpeed = (AutoSpeed)PlayerPrefs.GetInt("autoSpeed", 1);
    }
    public static void EnsureInstance()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("GameSettings");
            go.AddComponent<GameSettings>();
        }
    }
}
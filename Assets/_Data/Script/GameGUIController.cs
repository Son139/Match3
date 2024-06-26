using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGUIController : MonoBehaviour
{
    [SerializeField] Dialog pauseGameDialog;
    [SerializeField] Dialog gameCompletedDialog;

    Dialog curdialog;

    public Dialog CurDialog { get => curdialog; set => curdialog = value; }

    public void PauseBtnHandle()
    {
        Time.timeScale = 0;

        AudioManager.Instance.PauseMusic();

        GameScene.instance.isClickable = false;
        if (pauseGameDialog)
        {
            pauseGameDialog.ShowDialog(true);
            pauseGameDialog.UpdateDialog("GAME PAUSE", "BEST TIME 00:00");
            curdialog = pauseGameDialog;
        }
    }

    public void HomeBtnHandle()
    {
        ResumeBtnHandle();

        SceneManager.LoadScene("MainMenu");
    }

    public void ReplayBtnHandle()
    {
        Time.timeScale = 1;

        AudioManager.Instance.RestartMusic();

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void ResumeBtnHandle()
    {
        Time.timeScale = 1;

        AudioManager.Instance.UnPauseMusic();

        GameScene.instance.isClickable = true;

        if (curdialog) curdialog.ShowDialog(false);
    }

    public void SettingVolume()
    {
        Time.timeScale = 0;
    }
}

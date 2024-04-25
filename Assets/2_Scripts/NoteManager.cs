using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [SerializeField] private NoteGroup[] noteGroupArr;

    private void Awake()
    {
        Instance = this;
    }

    public void OnInput(KeyCode keyCode)
    {
        int randld = Random.Range(0, noteGroupArr.Length);
        bool isApple = randld == 0 ? true : false;

        if (keyCode == KeyCode.A) 
        {
            noteGroupArr[0].OnInput(isApple);
        }
    }
}

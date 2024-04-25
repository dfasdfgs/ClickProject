using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab = null;
    [SerializeField] private GameObject noteSpwan;
    [SerializeField] private float noteGap = 4f;

    [SerializeField] private SpriteRenderer btnSpriteRenderer;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBntSprite;
    [SerializeField] private Animation anim;

    private List<Note> noteList = new List<Note>();

    private void Start()
    {
        for (int i = 0; i < noteMaxNum; i++) 
        {
            SpwanNote(true);
        }
    }

    private void SpwanNote(bool isApple)
    {
        GameObject noteGameObj = Instantiate(notePrefab);
        noteGameObj.transform.SetParent(noteSpwan.transform);
        noteGameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;
        
        Note note = noteGameObj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);
    }

    public void OnInput(bool isApple)
    {
        
        Note delNote = noteList[0];
        delNote.Destroy();
        noteList.RemoveAt(0);

        for (int i = 0; i < noteList.Count;i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        SpwanNote(isApple);

        anim.Play();
        btnSpriteRenderer.sprite = selectBntSprite;

    }

    public void callAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}

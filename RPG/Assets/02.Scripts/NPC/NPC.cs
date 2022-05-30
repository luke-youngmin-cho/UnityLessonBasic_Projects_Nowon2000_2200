using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private string[] talks;
    [SerializeField] private string talkBoxButtonEventName;
    public void StartTalk()
    {
        TalkBox.instance.RegisterTalker(this, TalkBoxButtonEvent, talkBoxButtonEventName);
        TalkBox.instance.ShowRandomTalk();
        TalkBox.instance.gameObject.SetActive(true);
    }

    public string GetRandomTalk()
    {
        return talks[Random.Range(0, talks.Length)];
    }

    protected virtual void TalkBoxButtonEvent()
    {
        // 각 NPC 별로 하고싶은 고유한 이벤트 기능 (ex, 장비강화 창 열기 / 퀘스트 창 열기 등)
    }
}

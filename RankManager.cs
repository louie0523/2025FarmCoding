using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Rank
{
    public string Rankername;
    public float AllTime;

    public Rank(string name, float mytime)
    {
        Rankername = name;
        AllTime = mytime;
    }
}

public class RankManager : MonoBehaviour
{
    public static RankManager instance;

    public List<Rank> rank = new List<Rank>();
    public InputField inputField;
    public float currentTime;
    public string currentName;
    public bool RankGo;

    private void Start()
    {
        Checking();
    }

    private void Update()
    {



        if(inputField != null && RankGo && Input.GetKeyDown(KeyCode.Return))
        {
            if(inputField.text.Length > 0)
            {
                if (inputField.text.Length < 4)
                {
                    bool nameNo = false;
                    for(int i = 0; i < rank.Count; i++)
                    {
                        if (rank[i].Rankername.Equals(inputField.text))
                        {
                            Debug.Log("�̹� ������ �̸��� �ֽ��ϴ�!");
                            nameNo = true;
                            return;
                        }
                    }

                    RankGo = false;
                    rank.Add(new Rank(inputField.text, currentTime));
                    Debug.Log("�� ��Ŀ ���!");
                    RankSet();
                } else
                {
                    Debug.Log("�̸��� �ʹ� ��ϴ�.");
                }
            }else
            {
                Debug.Log("�̴ϼ� ĭ�� ����ֽ��ϴ�.");
            }
        }
    }

    public void Checking()
    {
        if(rank.Count <= 0)
        {
            RankGo = true;
            return;
        }

        for(int i = 0; i < rank.Count; i++)
        {
            if (rank[i].AllTime > currentTime)
            {
                rank.RemoveAt(i);
                RankGo = true;
                return;
            }
        }
        RankGo = false;

    }

    public void RankSet()
    {
       rank = rank.OrderBy(r => r.AllTime).Take(5).ToList();
    }
}

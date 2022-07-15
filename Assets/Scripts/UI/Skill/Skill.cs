using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "New Skill/ Skill")]
public class Skill : ScriptableObject
{
    public string skill_Name;           //��ų �̸�
    public string skill_Description;    //��ų ����
    public float skill_Cost;            //��ų �Ҹ� �ڿ�(MP)
    public float skill_CoolTime;        //��ų ��Ÿ��
    public bool skill_IsCoolTime;       //��ų ��Ÿ�� üũ
    public string skill_Level;           //��ų ����
    public Sprite skill_Image;          //��ų �̹���
    public static bool isSkillCheck;    //��ų ��� ������ üũ
    public float skill_CastTime;        //��ų �����ð�
    public bool skill_Rock;

    public Skill()
    {
        skill_Name = "";
        skill_Description = "";
        skill_Cost = 0f;
        skill_CoolTime = 0f;
        skill_IsCoolTime = false;
        skill_Rock = false;
        skill_Level = "";
    }
}

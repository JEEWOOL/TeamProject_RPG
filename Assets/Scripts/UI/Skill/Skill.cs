using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill
{
    public string skill_Name;           //��ų �̸�
    public string skill_Description;    //��ų ����
    public float skill_Cost;            //��ų �Ҹ� �ڿ�(MP)
    public float skill_CoolTime;        //��ų ��Ÿ��
    public bool skill_IsCoolTime;       //��ų ��Ÿ�� üũ
    public float skill_Level;           //��ų ����
    public Sprite skill_Image;          //��ų �̹���
    public static bool isSkillCheck;    //��ų ��� ������ üũ
    public float skill_CastTime;        //��ų �����ð�

    public Skill()
    {
        skill_Name = "";
        skill_Description = "";
        skill_Cost = 0f;
        skill_CoolTime = 0f;
        skill_IsCoolTime = false;
        skill_Level = 1f;
    }

    public void SetData(string _SkillName, string _SkillDec, float _Cost, float _CoolTime, float _Level, float _CastTime, Sprite _SkillImage = null)
    {
        skill_Name = _SkillName;
        skill_Description = _SkillDec;
        skill_Cost = _Cost;
        skill_CoolTime = _CoolTime;
        skill_Level = _Level;
        skill_CastTime = _CastTime;
        skill_Image = _SkillImage;
        skill_IsCoolTime = true;
        isSkillCheck = true;
    }

    public virtual IEnumerator Cast()
    {
        yield return new WaitForSeconds(skill_CastTime);
    }
}

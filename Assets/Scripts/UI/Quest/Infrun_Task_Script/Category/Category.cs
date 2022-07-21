using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Category/Category", fileName = "Category_")]
public class Category : ScriptableObject, IEquatable<Category>
{
    [SerializeField]
    private string codeName;
    [SerializeField]
    private string displayName;

    public string CodeName => codeName;
    public string DisplayName => displayName;


    #region Opetator
    // ī�װ��� �ַ� codeName���� �񱳸� �Ѵ�.
    public bool Equals(Category other)
    {
        // other�� null�� �ƴϰ� other�� ������Ʈ�� �ν��Ͻ��� ���� Ÿ�Ե� ���� �̸��� ���ٸ� true

        if (other is null)
        {
            return false;
        }
        if(ReferenceEquals(other, this))    // ReferenceEquals(other, this) 2������Ʈ �ν��Ͻ��� ������ �˻�
        {
            return true;
        }
        if(GetType() != other.GetType())    // �ν��Ͻ��� Ÿ���� �����´�.
        {
            return false;
        }
        return codeName == other.codeName;
    }

    public override int GetHashCode() => (codeName, DisplayName).GetHashCode();

    public override bool Equals(object other) => base.Equals(other);

    public static bool operator == (Category lhs, string rhs)
    {
        if(lhs is null)
        {
            return ReferenceEquals(rhs, null);
        }
        else
        {
            return lhs.codeName == rhs || lhs.DisplayName == rhs;
        }
    }

    public static bool operator !=(Category lhs, string rhs) => !(lhs == rhs);
    // category.CodeName == "Kill" x
    // category == "Kill"
    #endregion
}

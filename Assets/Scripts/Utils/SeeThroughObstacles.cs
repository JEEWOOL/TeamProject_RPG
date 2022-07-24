using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Manager;

public struct st_ObstacleRendererInfo
{
    public int InstanceID;
    public MeshRenderer meshRenderer;
    public Shader originShader;
}

public class SeeThroughObstacles : MonoBehaviour, IUpdatableObject
{
    public CamFollow mainFollowCam;

    private Dictionary<int, st_ObstacleRendererInfo> dicObstacles = new Dictionary<int, st_ObstacleRendererInfo>();
    private List<st_ObstacleRendererInfo> listTransparentedRenderer = new();
    private Color TransparentColor = new Color(1f, 1f, 1f, 0.2f);
    private Color OriginColor = new Color(1f, 1f, 1f, 1f);
    private string sharderColorParamName = "_Color";
    private Shader transparentShader;
    private RaycastHit[] transparentedRaycasts;
    private LayerMask transparentedLayer;


    public float Distance;

    public void OnDisable()
    {
        if(UpdateManager.Instance != null)
            UpdateManager.Instance.DeregisterUpdatableObject(this);
    }

    public void OnEnable()
    {
        UpdateManager.Instance.RegisterUpdatableObject(this);
        Init();
    }

    public void OnFixedUpdate(float deltaTime)
    {
        
    }

    public void OnUpdate(float deltaTime)
    {
        TransparentProcess();
    }

    private void Init()
    {
        // layermask�� Obstacle�� ������ ������Ʈ�� ����
        transparentedLayer = 1 << LayerMask.NameToLayer("Obstacle");
        // �������̴��� ����� �⺻ transparent ���̴�
        transparentShader = Shader.Find("Legacy Shaders/Transparent/Diffuse");
    }

    private void TransparentProcess()
    {
        if (mainFollowCam.target == null) 
            return;

        // ������ �ƴ� ������Ʈ���� ���� ����Ʈ�� �˻��Ͽ� ���� ���̴��� ������
        if(listTransparentedRenderer.Count > 0)
        {
            for(int i = 0; i < listTransparentedRenderer.Count; ++i)
            {
                listTransparentedRenderer[i].meshRenderer.material.shader = listTransparentedRenderer[i].originShader;
            }

            listTransparentedRenderer.Clear();
        }

        Vector3 targetPos = mainFollowCam.target.position;
        Distance = (mainFollowCam.transform.position - targetPos).magnitude;
        
        Vector3 DirToCam = (mainFollowCam.transform.position - targetPos).normalized;

        HitRayTransparentObject(targetPos, DirToCam, Distance);
    }

    private void HitRayTransparentObject(Vector3 start, Vector3 direction, float distance)
    {
        // ī�޶� - ĳ���� ���� �������� ������ ���̾��ũ�� hit�� ����ĳ��Ʈ���� ��Ƶ�
        transparentedRaycasts = Physics.RaycastAll(start, direction, distance, transparentedLayer);

        for (int i = 0; i < transparentedRaycasts.Length; ++i)
        {
            int instanceID = transparentedRaycasts[i].colliderInstanceID;

            // dictionary�� ����ִ��� �˻� (�� ������ �ߺ� �˻��ϴ� ��� ����)
            if (!dicObstacles.ContainsKey(instanceID))
            {
                MeshRenderer obsRenderer = transparentedRaycasts[i].collider.gameObject.GetComponent<MeshRenderer>();
                st_ObstacleRendererInfo rendererInfo = new st_ObstacleRendererInfo();
                rendererInfo.InstanceID = instanceID;
                rendererInfo.meshRenderer = obsRenderer;
                rendererInfo.originShader = obsRenderer.material.shader;

                dicObstacles[instanceID] = rendererInfo;
            }

            // ���̴��� �����ص� ������ ���̴��� ����
            dicObstacles[instanceID].meshRenderer.material.shader = transparentShader;
            // ���İ��� ���� Į������ ���̴� �� ����
            dicObstacles[instanceID].meshRenderer.material.SetColor(sharderColorParamName, TransparentColor);

            listTransparentedRenderer.Add(dicObstacles[instanceID]);
        }
    }
}

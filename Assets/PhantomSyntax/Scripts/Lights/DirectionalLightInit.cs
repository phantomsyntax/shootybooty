using UnityEngine;

public class DirectionalLightInit : MonoBehaviour
{
    [Header("Directional Light Settings")]
    [SerializeField] private GameObject directionalLight;
    [SerializeField] private Color32 directionalLightColor = new Color32(152, 204, 255, 255);
    [SerializeField] private Vector3 directionalLightRotation = new Vector3(50.0f, -30.0f, 0.0f);
                     private Light directionalLightComponent;

    private void Start()
    {
        NullChecks();

        directionalLightComponent = directionalLight.GetComponent<Light>();
        PositionLight(directionalLightRotation);
        SetProperties(directionalLightColor);
    }

    private void NullChecks()
    {
        if (!directionalLight)
        {
            directionalLight = GameObject.Find("Directional Light");
        }
    }

    private void PositionLight(Vector3 rotation)
    {
        directionalLight.transform.eulerAngles = rotation;
    }

    private void SetProperties(Color32 color)
    {
        directionalLightComponent.type = LightType.Directional;
        directionalLightComponent.color = color;
    }
}
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonManager : MonoBehaviour
{
    private Button tabButton;
    private Button spaceButton;
    private Button closeButton;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        tabButton = root.Q<Button>("tabButton");
        spaceButton = root.Q<Button>("spaceButton");
        closeButton = root.Q<Button>("closeButton");

        tabButton.clicked += () => OnButtonClicked("TabPrefab");
        spaceButton.clicked += () => OnButtonClicked("SpacePrefab");
        closeButton.clicked += OnCloseButtonClicked;
    }

    private void OnDisable()
    {
        tabButton.clicked -= () => OnButtonClicked("TabPrefab");
        spaceButton.clicked -= () => OnButtonClicked("SpacePrefab");
        closeButton.clicked -= OnCloseButtonClicked;
    }

    private void OnButtonClicked(string prefabName)
    {
        GameObject prefab = Resources.Load<GameObject>(prefabName);
        if (prefab != null)
        {
            GameObject instance = Instantiate(prefab);
            Camera mainCamera = Camera.main;
            Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * 2.0f;
            instance.transform.position = spawnPosition;

            Rigidbody rb = instance.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 force = new Vector3(Random.Range(-500, 500), Random.Range(-500, 500), Random.Range(-500, 500));
                rb.AddForce(force);
            }
        }
        else
        {
            Debug.LogError($"{prefabName} not found in Resources folder");
        }
    }

    private void OnCloseButtonClicked()
    {
        Debug.Log("Close");
    }
}
using Unity.VisualScripting;
using UnityEngine;

public class HotbarInput : MonoBehaviour//переключение активного слота
{
    private void Update()
    {
        if (Inventory.Instance == null)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            Inventory.Instance.SetActive(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Inventory.Instance.SetActive(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Inventory.Instance.SetActive(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Inventory.Instance.SetActive(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            Inventory.Instance.SetActive(4);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            Inventory.Instance.SetActive(5);
        if (Input.GetKeyDown(KeyCode.Alpha7))
            Inventory.Instance.SetActive(6);
        if (Input.GetKeyDown(KeyCode.Alpha8))
            Inventory.Instance.SetActive(7);
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownManager : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private bool isFirstTime = true;
    public TMPro.TextMeshProUGUI labelText;
    void Start()
    {
        // ���������, ������ �� ��� ����������� Dropdown
        //if (isFirstTime)
        //{
            // ��������� ��������� ������� � Dropdown
            // dropdown.options.Insert(0, new TMP_Dropdown.OptionData("�������� �����"));
            labelText.text = "�������� �����";
            // ������������� ��������� �������� Dropdown �� ����� �������
            //dropdown.value = -1;

            // ��������, ��� Dropdown ��� ��� ���������������
        //    isFirstTime = false;
        //}
    }
}
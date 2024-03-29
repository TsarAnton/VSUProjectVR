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
        // Проверяем, первый ли раз запускается Dropdown
        //if (isFirstTime)
        //{
            // Добавляем начальный элемент в Dropdown
            // dropdown.options.Insert(0, new TMP_Dropdown.OptionData("Выберите опцию"));
            labelText.text = "Выберите орган";
            // Устанавливаем начальное значение Dropdown на новый элемент
            //dropdown.value = -1;

            // Помечаем, что Dropdown уже был инициализирован
        //    isFirstTime = false;
        //}
    }
}
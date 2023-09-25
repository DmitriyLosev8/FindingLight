using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField] private List<LevelButton> _levelButtons;
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private LevelSave _levelSave;

    private void Start()
    {
        Paint();
        Debug.Log("� �������");
    }

    private void Awake()
    {
        Paint();
        Debug.Log("� ����������");
    }



    private void Paint()
    {
        int mainMenuId = 0;

        for (int i = 0; i < _levelSave.AvailableLevels.Count; i++)
        {
            for (int j = 0; i < _levelButtons.Count; i++)
            {
                // if (_levelSave.AvailableLevels[j] != mainMenuId)
                // {
                if (_levelButtons[j].Id == _levelSave.AvailableLevels[i])
                {
                    // Debug.Log("���� ��������� ����� ����");
                    // _buttons[i].image.color = Color.white;
                    _levelButtons[j].SetWhiteColor();
                }
                else
                {
                    // Debug.Log("���� ��������� ����� ����, ������ ��� ���� ������ ��� -  " + _levelButtons[j].Id + "� ��������� �������� ��� - " + _levelSave.AvailableLevels[i]);
                    // _buttons[i].image.color = Color.gray;
                    _levelButtons[j].SetGreyColor();
                }

                if (j > i)
                {
                    _levelButtons[j].SetGreyColor();
                }
            }
            // }                
        }
    }




    //for (int i = 0; i < _levelButtons.Count; i++)
    //{
    //    for (int j = 0; j < _levelSave.AvailableLevels.Count; j++)
    //    {
    //        if (_levelSave.AvailableLevels[j] != mainMenuId)
    //        {
    //            if (_levelButtons[i].Id == _levelSave.AvailableLevels[j])
    //            {
    //                // Debug.Log("���� ��������� ����� ����");
    //                // _buttons[i].image.color = Color.white;
    //                _levelButtons[i].SetWhiteColor();
    //            }
    //            else
    //            {
    //                _levelButtons[i].SetGreyColor();
    //                Debug.Log("���� ��������� ����� ����, ������ ��� ���� ������ ��� -  " + _levelButtons[i].Id + ", � ��������� �������� ��� - " + _levelSave.AvailableLevels[j]);
    //                // _buttons[i].image.color = Color.gray;     
    //                Debug.Log("������ ��� ��������� � �����");
    //            }

    //            //if(i > j)
    //            //{

    //            //}
    //        }
    //    }
    //}
}

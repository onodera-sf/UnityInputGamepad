using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadButtonsOneFrame : MonoBehaviour
{
  /// <summary>����\��������e�L�X�g�I�u�W�F�N�g�B</summary>
  [SerializeField] private Text TextObject;

  // �X�V�̓t���[�����Ƃ�1��Ăяo����܂�
  void Update()
  {
    if (TextObject == null)
    {
      Debug.Log($"{nameof(TextObject)} �� null �ł��B");
      return;
    }

    // �P�ڂ̃Q�[���p�b�h�̏����擾
    var gamepad = Gamepad.current;
    if (gamepad == null)
    {
      Debug.Log("�Q�[���p�b�h������܂���B");
      TextObject.text = "";
      return;
    }

    // �{�^���������ꂽ�u�Ԃ��ǂ����𔻒�
    if (gamepad.aButton.wasPressedThisFrame) TextObject.text += "A";
    if (gamepad.bButton.wasPressedThisFrame) TextObject.text += "B";
    if (gamepad.xButton.wasPressedThisFrame) TextObject.text += "X";
    if (gamepad.yButton.wasPressedThisFrame) TextObject.text += "Y";
  }
}

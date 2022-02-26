using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadReadValue : MonoBehaviour
{
  /// <summary>����\��������e�L�X�g�I�u�W�F�N�g�B</summary>
  [SerializeField] private Text TextObject;

  StringBuilder Builder = new StringBuilder();

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

    Builder.Clear();

    // �g���K�[�̉����ʂ��擾
    Builder.AppendLine($"LeftTrigger:{gamepad.leftTrigger.ReadValue()}");
    Builder.AppendLine($"RightTrigger:{gamepad.rightTrigger.ReadValue()}");

    // �X�e�B�b�N�̓��͂��擾
    var leftStickValue = gamepad.leftStick.ReadValue();
    Builder.AppendLine($"LeftStick:{leftStickValue.normalized * leftStickValue.magnitude}");
    var rightStickValue = gamepad.rightStick.ReadValue();
    Builder.AppendLine($"RightStick:{rightStickValue.normalized * rightStickValue.magnitude}");

    // �����e�L�X�g�ŕ\��
    TextObject.text = Builder.ToString();
  }
}

using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadDpad : MonoBehaviour
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

    // Dpad �̉������� Vector2 �Ƃ��Ď擾����p�^�[��
    var value = gamepad.dpad.ReadValue();
    Builder.Append($"(x:{value.x}, y:{value.y})");

    // Dpad �̊e�����̃{�^���������Ă��邩�ǂ����̔���
    if (gamepad.dpad.left.isPressed) Builder.Append(" left");
    if (gamepad.dpad.right.isPressed) Builder.Append(" right");
    if (gamepad.dpad.up.isPressed) Builder.Append(" up");
    if (gamepad.dpad.down.isPressed) Builder.Append(" down");

    // Dpad �̏����e�L�X�g�ŕ\��
    TextObject.text = Builder.ToString();
  }
}

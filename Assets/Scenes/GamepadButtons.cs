using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamepadButtons : MonoBehaviour
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

    // �{�^���������Ă���Ԃ� xxxxxxxx.isPressed �� true ��Ԃ��܂�

    // B �{�^���� East �{�^���A���{�^���͓ǂݕ����Ⴄ�����œ����{�^���ł�
    // ����� PlayStation �� Xbox, Switch �ȂǂŃ{�^���̓ǂݕ����Ⴄ���߂ł�
    if (gamepad.aButton.isPressed) Builder.AppendLine($"A");
    if (gamepad.bButton.isPressed) Builder.AppendLine($"B");
    if (gamepad.xButton.isPressed) Builder.AppendLine($"X");
    if (gamepad.yButton.isPressed) Builder.AppendLine($"Y");

    if (gamepad.buttonEast.isPressed) Builder.AppendLine($"East");
    if (gamepad.buttonWest.isPressed) Builder.AppendLine($"West");
    if (gamepad.buttonNorth.isPressed) Builder.AppendLine($"North");
    if (gamepad.buttonSouth.isPressed) Builder.AppendLine($"South");

    if (gamepad.circleButton.isPressed) Builder.AppendLine($"Circle");
    if (gamepad.crossButton.isPressed) Builder.AppendLine($"Cross");
    if (gamepad.triangleButton.isPressed) Builder.AppendLine($"Triangle");
    if (gamepad.squareButton.isPressed) Builder.AppendLine($"Square");

    // �R���g���[���[�̒����ɂ���X�^�[�g�{�^���A�Z���N�g�{�^���A���j���[�{�^���A�r���[�{�^���ȂǂɊY�����܂��B
    if (gamepad.startButton.isPressed) Builder.AppendLine($"Start");
    if (gamepad.selectButton.isPressed) Builder.AppendLine($"Select");

    // ���ƉE�̃X�e�B�b�N���܂������������񂾂��ǂ����𔻒肵�܂�
    if (gamepad.leftStickButton.isPressed) Builder.AppendLine($"LeftStickButton");
    if (gamepad.rightStickButton.isPressed) Builder.AppendLine($"RightStickButton");

    // ����ƉE��ɂ���{�^���BPlayStation ���� L1 �� R1 �ɊY�����܂�
    if (gamepad.leftShoulder.isPressed) Builder.AppendLine($"LeftShoulder");
    if (gamepad.rightShoulder.isPressed) Builder.AppendLine($"RightShoulder");

    // �����Ă���{�^���ꗗ���e�L�X�g�ŕ\��
    TextObject.text = Builder.ToString();
  }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class ControlManager : MonoBehaviour {
	public enum Axis
	{
		LEFT_STICK_X, LEFT_STICK_Y,
		RIGHT_STICK_X, RIGHT_STICK_Y,
		LEFT_TRIGGER, RIGHT_TRIGGER
	}

	public enum Button
	{
		A, B, X, Y,
		START, BACK, LEFT_BUMPER, RIGHT_BUMPER,
		LEFT_STICK, RIGHT_STICK
	}

	public float GetPlayerAxis(int player, Axis axis)
	{
		var device = GetPlayer(player);

		switch (axis) {
			case Axis.LEFT_STICK_X:
				return device.GetControl(InputControlType.LeftStickX).Value;
			case Axis.LEFT_STICK_Y:
				return device.GetControl(InputControlType.LeftStickY).Value;
			case Axis.RIGHT_STICK_X:
				return device.GetControl(InputControlType.RightStickX).Value;
			case Axis.RIGHT_STICK_Y:
				return device.GetControl(InputControlType.RightStickY).Value;
			case Axis.LEFT_TRIGGER:
				return device.GetControl(InputControlType.LeftTrigger).Value;
			case Axis.RIGHT_TRIGGER:
				return device.GetControl(InputControlType.RightTrigger).Value;
			default:
				throw new ArgumentOutOfRangeException("axis", axis, null);
		}
	}

	public bool GetPlayerButton(int player, Button button)
	{
		var device = GetPlayer(player);

		switch (button) {
			case Button.A:
				return device.GetControl(InputControlType.Button0).IsPressed;
			case Button.B:
				return device.GetControl(InputControlType.Button1).IsPressed;
			case Button.X:
				return device.GetControl(InputControlType.Button2).IsPressed;
			case Button.Y:
				return device.GetControl(InputControlType.Button3).IsPressed;
			case Button.START:
				return device.GetControl(InputControlType.Start).IsPressed;
			case Button.BACK:
				return device.GetControl(InputControlType.Back).IsPressed;
			case Button.LEFT_BUMPER:
				return device.GetControl(InputControlType.LeftBumper).IsPressed;
			case Button.RIGHT_BUMPER:
				return device.GetControl(InputControlType.RightBumper).IsPressed;
			case Button.LEFT_STICK:
				return device.GetControl(InputControlType.LeftStickButton).IsPressed;
			case Button.RIGHT_STICK:
				return device.GetControl(InputControlType.RightStickButton).IsPressed;
			default:
				throw new ArgumentOutOfRangeException("button", button, null);
		}
	}

	public bool GetPlayerButtonDown(int player, Button button)
	{
		var device = GetPlayer(player);

		switch (button) {
			case Button.A:
				return device.GetControl(InputControlType.Button0).WasPressed;
			case Button.B:
				return device.GetControl(InputControlType.Button1).WasPressed;
			case Button.X:
				return device.GetControl(InputControlType.Button2).WasPressed;
			case Button.Y:
				return device.GetControl(InputControlType.Button3).WasPressed;
			case Button.START:
				return device.GetControl(InputControlType.Start).WasPressed;
			case Button.BACK:
				return device.GetControl(InputControlType.Back).WasPressed;
			case Button.LEFT_BUMPER:
				return device.GetControl(InputControlType.LeftBumper).WasPressed;
			case Button.RIGHT_BUMPER:
				return device.GetControl(InputControlType.RightBumper).WasPressed;
			case Button.LEFT_STICK:
				return device.GetControl(InputControlType.LeftStickButton).WasPressed;
			case Button.RIGHT_STICK:
				return device.GetControl(InputControlType.RightStickButton).WasPressed;
			default:
				throw new ArgumentOutOfRangeException("button", button, null);
		}
	}

	public void VibratePlayer(int player, float intensity = 0.3f, float duration = 0.3f)
	{
		var device = GetPlayer(player);
		StartCoroutine(VibratePlayer(device, intensity, duration));
	}

	private InputDevice GetPlayer(int player)
	{
		InputDevice device;
		try {
			device = InputManager.Devices[player];
		} catch (IndexOutOfRangeException e) {
			throw new IndexOutOfRangeException(string.Format("Player {0} does not exist", player), e);
		}
		return device;
	}

	private IEnumerator VibratePlayer(InputDevice device, float intensity, float duration)
	{
		device.Vibrate(intensity);
		yield return new WaitForSeconds(duration);
		device.StopVibration();
	}
}

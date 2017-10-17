using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Image_Effects
{
	public class Outline : UnityStandardAssets.ImageEffects.ImageEffectBase
	{
		public float LumThreshold;
		public float DepthThreshold;
		public Color OutlineColor;

		private void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			material.SetVector("_Resolution", new Vector4(Screen.width, Screen.height));
			material.SetFloat("_LumThreshold", LumThreshold);
			material.SetFloat("_DepthThreshold", DepthThreshold);
			material.SetColor("_OutlineColor", OutlineColor);
			Graphics.Blit(src, dest, material);
		}
	}
}

namespace Mapbox.Unity.MeshGeneration.Modifiers
{
    using UnityEngine;
    using Mapbox.Unity.MeshGeneration.Components;
	using Mapbox.Unity.MeshGeneration.Data;
	using System;

	/// <summary>
	/// Texture Modifier is a basic modifier which simply adds a TextureSelector script to the features.
	/// Logic is all pushed into this TextureSelector mono behaviour to make it's easier to change it in runtime.
	/// </summary>
	[CreateAssetMenu(menuName = "Mapbox/Modifiers/Material Modifier")]
    public class MaterialModifier : GameObjectModifier
    {
        [SerializeField]
        private bool _useSatelliteTexture;
        [SerializeField]
        private Material[] _materials;

		public override void Run(VectorEntity ve, UnityTile tile)
        {
			var min = Math.Min(_materials.Length, ve.MeshFilter.mesh.subMeshCount);
			var mats = new Material[min];
			for (int i = 0; i < min; i++)
			{
				mats[i] = _materials[i];
			}

			if (_useSatelliteTexture)
			{
				mats[0].mainTexture = tile.GetRasterData();
				mats[0].mainTextureScale = new Vector2(1f, 1f);
			}

			ve.MeshRenderer.materials = mats;
		}
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MapService {

	public class Door {

		public static int Width = 3;

		Wall wall;
		List<Vector3> tiles;

		public Door (Wall _wall) {
			wall = _wall;
			tiles = new List<Vector3>();
			SetTiles();
		}

		void SetTiles () {
			var wallTiles = wall.Tiles();
			int length = wallTiles.Count;
			int start = Random.Range(1, length-2);

			tiles.AddRange(wallTiles.GetRange(start, Width));
		}

		public List<Vector3> Tiles () {
			return tiles;
		}

	}
}

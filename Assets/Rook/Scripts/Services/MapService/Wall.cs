using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MapService {

	public enum WallSide {
		Bottom,
		Top,
		Left,
		Right
	}

	public enum WallType {
		Horizontal,
		Vertical
	}

	public class Wall {

		Vector3 start;
		Vector3 end;
		WallSide side;
		WallType type {
			get {
				return (side == WallSide.Bottom || side == WallSide.Top) ? WallType.Horizontal : WallType.Vertical;
			}
		}

		public Wall (Vector3 a, Vector3 b, WallSide _side) {
			start = a;
			end = b;
			side = _side;
		}

		public List<Vector3> Tiles () {
			var tiles = new List<Vector3>();
			for (int x = (int)start.x; x <= (int)end.x; x++) {
				for (int z = (int)start.z; z <= (int)end.z; z++) {
					tiles.Add(new Vector3(x, 0f, z));
				}
			}
			return tiles;
		}

	}

}
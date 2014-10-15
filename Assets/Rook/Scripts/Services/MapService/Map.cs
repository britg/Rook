using UnityEngine;
using System.Collections;

namespace MapGenerator {
	public class Map {

		GameObject wallTilePrefab;
		GameObject environment;
		Vector2 size;

		MapTile[,] tiles;

		public Map () {
			size = new Vector2(100f, 100f);
			tiles = new MapTile[(int)size.x, (int)size.y];
			environment = GameObject.Find ("Environment");
		}

		public void Generate () {
			CreateBounds();
			CreateRooms();
		}

		public void Instantiate (GameObject _wallTile) {
			wallTilePrefab = _wallTile;
			PlaceTiles();
			PlacePlayer();
		}

		void CreateBounds () {
			for (int x = 0; x <size.x; x++) {
				for (int z = 0; z < size.y; z++) {
					if (x == 0 || x == (int)size.x-1 || z == 0 || z == (int)size.y-1) {
						tiles[x,z] = MapTile.Wall;
					} else {
						tiles[x,z] = MapTile.Floor;
					}
				}
			}
		}

		void CreateRooms () {
			Room.Create(ref tiles);
		}

		void PlaceTiles () {
			for (int x = 0; x < tiles.GetLength(0); x++) {
				for (int z = 0; z < tiles.GetLength(1); z++) {
					if (tiles[x, z] == MapTile.Wall) {
						PlaceWall(new Vector3((float)x, 0f, (float)z));
					}
				}
			}
		}

		void PlaceWall (Vector3 pos) {
			var wt = (GameObject)GameObject.Instantiate(wallTilePrefab, pos, Quaternion.identity);
			wt.transform.SetParent(environment.transform);
		}

		void PlacePlayer () {
			var playerStart = ChooseRandomPlayerStart();
			environment.transform.position = -playerStart;
		}

		Vector3 ChooseRandomPlayerStart () {
			int x = Random.Range (0, (int)size.x);
			int z = Random.Range (0, (int)size.y);
			return new Vector3(x, 0f, z);
		}
	}
}
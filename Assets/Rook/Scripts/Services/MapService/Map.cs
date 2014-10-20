using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MapService {
	public class Map {

		public static int NumRooms = 20;
		public static int RoomAttempts = 20;
		public static Vector3 size = new Vector3(100f, 0f, 100f);

		public List<Room> rooms;

		GameObject wallTilePrefab;
		Player player;
		GameObject environment;
		GameObject mobs;

		Hashtable tiles;

		Vector3 offset;
        int maxIterationCount = 100;
        int currentIterationCount = 0;

		public Map (Player _player) {
//			tiles = new MapTile[(int)size.x + (int)Room.roomSizeMax.x, (int)size.z + (int)Room.roomSizeMax.z];
			tiles = new Hashtable();
			environment = GameObject.Find ("Environment");
			player = _player;
			mobs = GameObject.Find ("Mobs");
		}

		public void Generate () {
			CreateBounds();
			CreateRooms();
		}

		public void Instantiate (GameObject _wallTile) {
			wallTilePrefab = _wallTile;
			PlaceTiles();
		}

		public void SetTile (Vector3 pos, MapTile tileType) {
            if (tiles.ContainsKey(pos)) {
                tiles[pos] = tileType;
            } else {
                tiles.Add(pos, tileType);
            }
            //tiles[pos] = tileType;
		}

		void CreateBounds () {
			for (int x = 0; x <size.x; x++) {
				for (int z = 0; z < size.z; z++) {
                    var pos = new Vector3(x, 0f, z);
					if (x == 0 || x == (int)size.x-1 || z == 0 || z == (int)size.z-1) {
                        SetTile(pos, MapTile.Wall);
					} else {
                        SetTile(pos, MapTile.Floor);
					}
				}
			}
		}

		void CreateRooms () {
			rooms = new List<Room>();

			for (int i = 0; i < Map.RoomAttempts; i++) {
				var room = Room.Create(this);
				if (room != null) {
					rooms.Add(room);
					room.SetTiles();
				}
			}
		}


		public Vector3 RandomPoint () {
			int x = (int)Random.Range (0, size.x);
			int z = (int)Random.Range (0, size.z);
			return new Vector3(x, 0f, z);
		}

		Vector3 RandomInteriorTilePosition () {
            if (currentIterationCount > maxIterationCount) {
                return RandomPoint();
            }
            var pos = RandomPoint();
            var tile = (MapTile)tiles[pos];
            if (tile != MapTile.Interior) {
                currentIterationCount++;
                return RandomInteriorTilePosition();
            }
            return pos;
		}

        void PlaceTiles () {
            foreach (DictionaryEntry entry in tiles) {
                if ((MapTile)entry.Value == MapTile.Wall) {
                    PlaceWall((Vector3)entry.Key);
                }
            }
        }

        void PlaceWall (Vector3 pos) {
            var wt = (GameObject)GameObject.Instantiate(wallTilePrefab, pos, Quaternion.identity);
            wt.transform.SetParent(environment.transform);
        }

        public void PlacePlayer () {
            currentIterationCount = 0;
            offset = RandomInteriorTilePosition();
            player.position = offset;
        }

		public void PlaceEnemies (GameObject enemyPrefab) {
			foreach (DictionaryEntry entry in tiles) {
				Vector3 pos = (Vector3)entry.Key;
				MapTile tile = (MapTile)entry.Value;

				if (tile == MapTile.Interior) {
					bool shouldPlace = Random.Range(0, 200) <= 1;
					if (shouldPlace) {
						var enemy = (GameObject)GameObject.Instantiate(enemyPrefab, pos, Quaternion.identity);
						enemy.transform.SetParent(mobs.transform);
					}
				}
			}
		}
	}
}
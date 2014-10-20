using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MapService {

	public class Room {

		public static Vector3 roomSizeMin = new Vector3(8f, 0f, 8f);
		public static Vector3 roomSizeMax = new Vector3(30f, 0f, 30f);

		Map map;
		Bounds bounds;

		Vector3 center {
			get {
				return bounds.center;
			}
		}

		Vector3 extents {
			get {
				return bounds.extents;
			}
		}

		List<Wall> walls;
		List<Door> doors;
		Vector3 topLeft;
		Vector3 topRight;
		Vector3 botLeft;
		Vector3 botRight;
		List<Vector3> interiorTiles;

		public static Room Create (Map map) {

			Bounds bounds = RandomBounds(map);
			bool validBounds = false;
			for (int i = 0; i < Map.RoomAttempts; i++) {
				bounds = RandomBounds(map);
				validBounds = ValidBounds(map, bounds);

				if (validBounds) {
					break;
				}
			}

			// Failed to find a valid bounds
			if (!validBounds) {
				return null;
			}

			var room = new Room(bounds, map);
			room.Generate();
			return room;
		}

		static bool ValidBounds (Map map, Bounds bounds) {
			foreach (Room room in map.rooms) {
				if (room.bounds.Intersects(bounds)) {
					return false;
				}
			}
			return true;
		}

		static Bounds RandomBounds (Map map) {
			var size = RandomSize();
			var center = map.RandomPoint();

			Bounds bounds = new Bounds(center, size);
			return bounds;
		}

		static Vector3 RandomSize () {
			int x = (int)Random.Range (roomSizeMin.x, roomSizeMax.x);
			int z = (int)Random.Range (roomSizeMin.z, roomSizeMax.z);
			return new Vector3(x, 0f, z);
		}

		public Room (Bounds _bounds, Map _map) {
			bounds = _bounds;
			map = _map;
		}

		public void Generate () {
			SetCorners();
			CreateWalls();
			MarkInteriorTiles();
			CreateDoors();
		}

		void SetCorners () {
			topLeft = new Vector3(center.x - extents.x, 0f, center.z + extents.z);
			botLeft = new Vector3(center.x - extents.x, 0f, center.z - extents.z);
			topRight = new Vector3(center.x + extents.x, 0f, center.z + extents.z);
			botRight = new Vector3(center.x + extents.x, 0f, center.z - extents.z);
		}

		void CreateWalls () {

			// Walls
			walls = new List<Wall>();
			walls.Add(new Wall(botLeft, botRight, WallSide.Bottom));
			walls.Add(new Wall(topLeft, topRight, WallSide.Top));
			walls.Add(new Wall(botLeft, topLeft, WallSide.Left));
			walls.Add(new Wall(botRight, topRight, WallSide.Right));

		}

		void MarkInteriorTiles () {
			var intTopLeft = topLeft + new Vector3(2f, 0f, -2f);
			var intBotLeft = botLeft + new Vector3(2f, 0f, 2f);
			var intTopRight = topRight + new Vector3(-2f, 0f, -2f);
			var intBotRight = botRight + new Vector3(-2f, 0f, 2f);

			interiorTiles = new List<Vector3>();

			for (var x = intBotLeft.x; x <= intBotRight.x; x++) {
				for (var z = intBotLeft.z; z <= intTopLeft.z; z++) {
                    var pos = new Vector3(x, 0f, z);
					interiorTiles.Add(pos);
				}
			}

		}

		void CreateDoors () {
			doors = new List<Door>();
			bool hasDoor;
			foreach (Wall wall in walls) {
				hasDoor = Random.Range(0, 100) < 25; // 50% chance
				if (hasDoor) {
					var door = new Door(wall);
					doors.Add(door);
				}
			}

			if (doors.Count < 1) {
				Wall wall = walls.Last();
				var door = new Door(wall);
				doors.Add(door);
			}
		}

		public void SetTiles () {
			List<Vector3> tileList;
			foreach (Wall wall in walls) {
				tileList = wall.Tiles();
				foreach (Vector3 tile in tileList) {
					map.SetTile(tile, MapTile.Wall);
				}
			}

			foreach (Door door in doors) {
				tileList = door.Tiles();
				foreach (Vector3 tile in tileList) {
					map.SetTile(tile, MapTile.Door);
				}
			}

            foreach (Vector3 pos in interiorTiles) {
                map.SetTile(pos, MapTile.Interior);
            }
		}

	}

}

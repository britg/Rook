using UnityEngine;
using System.Collections;

namespace MapGenerator {

	public class Room {

		static Vector2 roomSizeMin = new Vector2(8f, 8f);
		static Vector2 roomSizeMax = new Vector2(20f, 20f);

		MapTile[,] tiles;
		Vector2 center;
		Vector2 size;

		public static Room Create (ref MapTile[,] tiles) {

			var roomSize = RandomSize();
			var center = new Vector2(tiles.GetLength(0)/2,  tiles.GetLength(1)/2);

			var room = new Room(center, roomSize, ref tiles);
			room.Place();
			return room;
		}

		static Vector2 RandomSize () {
			int x = (int)Random.Range (roomSizeMin.x, roomSizeMax.x);
			int y = (int)Random.Range (roomSizeMin.y, roomSizeMax.y);
			return new Vector2(x, y);
		}

		public Room (Vector2 _center, Vector2 _size, ref MapTile[,] _tiles) {
			center = _center;
			size = _size;
			tiles = _tiles;
		}

		public void Place () {
			var topLeft = new Vector2(center.x - size.x/2, center.y + size.y/2);
			var botLeft = new Vector2(center.x - size.x/2, center.y - size.y/2);
			var topRight = new Vector2(center.x + size.x/2, center.y + size.y/2);
			var botRight = new Vector2(center.x + size.x/2, center.y - size.y/2);

			// Bottom Wall
			for (int x = (int)botLeft.x; x <= (int)botRight.x; x++) {
				tiles[(int)x, (int)botLeft.y] = MapTile.Wall;
			}

			// Top Wall
			for (int x = (int)topLeft.x; x <= (int)topRight.x; x++) {
				tiles[(int)x, (int)topLeft.y] = MapTile.Wall;
			}

			// Left wall
			for (int y = (int)botLeft.y+1; y < (int)topLeft.y; y++) {
				tiles[(int)botLeft.x, y] = MapTile.Wall;
			}

			// Right wall
			for (int y = (int)botRight.y+1; y < (int)topRight.y; y++) {
				tiles[(int)botRight.x, y] = MapTile.Wall;
			}
	//		tiles[(int)topLeft.x, (int)topLeft.y] = LevelTile.Wall;
	//		tiles[(int)botLeft.x, (int)botLeft.y] = LevelTile.Wall;
	//		tiles[(int)topRight.x, (int)topRight.y] = LevelTile.Wall;
	//		tiles[(int)botRight.x, (int)botRight.y] = LevelTile.Wall;
		}

	}

}

//----------------------------------------------//
// Gamelogic Grids                              //
// http://www.gamelogic.co.za                   //
// Copyright (c) 2013 Gamelogic (Pty) Ltd       //
//----------------------------------------------//

// Auto-generated File

using System.Linq;

namespace Gamelogic.Grids
{
	/**
		Compiler hints for our examples.

		@since 1.8
	*/
	public static class __CompilerHintsGL
	{
		public static bool __CompilerHint__PointyHex__TileCell()
		{
			var grid = new PointyHexGrid<TileCell[]>(1, 1);

			foreach(var point in grid) { grid[point] = new TileCell[1]; } 

			var shapeStorageInfo = new ShapeStorageInfo<PointyHexPoint>(new IntRect(), p => true);
			var shapeInfo = new PointyHexShapeInfo<TileCell>(shapeStorageInfo);

			return grid[grid.First()][0] == null || shapeInfo.Translate(PointyHexPoint.Zero) != null;
		}
		public static bool __CompilerHint__FlatHex__TileCell()
		{
			var grid = new FlatHexGrid<TileCell[]>(1, 1);

			foreach(var point in grid) { grid[point] = new TileCell[1]; } 

			var shapeStorageInfo = new ShapeStorageInfo<FlatHexPoint>(new IntRect(), p => true);
			var shapeInfo = new FlatHexShapeInfo<TileCell>(shapeStorageInfo);

			return grid[grid.First()][0] == null || shapeInfo.Translate(FlatHexPoint.Zero) != null;
		}
		
		public static bool __CompilerHint__PointyHex__SpriteCell()
		{
			var grid = new PointyHexGrid<SpriteCell[]>(1, 1);

			foreach(var point in grid) { grid[point] = new SpriteCell[1]; } 

			var shapeStorageInfo = new ShapeStorageInfo<PointyHexPoint>(new IntRect(), p => true);
			var shapeInfo = new PointyHexShapeInfo<SpriteCell>(shapeStorageInfo);

			return grid[grid.First()][0] == null || shapeInfo.Translate(PointyHexPoint.Zero) != null;
		}
		public static bool __CompilerHint__FlatHex__SpriteCell()
		{
			var grid = new FlatHexGrid<SpriteCell[]>(1, 1);

			foreach(var point in grid) { grid[point] = new SpriteCell[1]; } 

			var shapeStorageInfo = new ShapeStorageInfo<FlatHexPoint>(new IntRect(), p => true);
			var shapeInfo = new FlatHexShapeInfo<SpriteCell>(shapeStorageInfo);

			return grid[grid.First()][0] == null || shapeInfo.Translate(FlatHexPoint.Zero) != null;
		}
		
		public static bool __CompilerHint__PointyHex__UVCell()
		{
			var grid = new PointyHexGrid<UVCell[]>(1, 1);

			foreach(var point in grid) { grid[point] = new UVCell[1]; } 

			var shapeStorageInfo = new ShapeStorageInfo<PointyHexPoint>(new IntRect(), p => true);
			var shapeInfo = new PointyHexShapeInfo<UVCell>(shapeStorageInfo);

			return grid[grid.First()][0] == null || shapeInfo.Translate(PointyHexPoint.Zero) != null;
		}
		public static bool __CompilerHint__FlatHex__UVCell()
		{
			var grid = new FlatHexGrid<UVCell[]>(1, 1);

			foreach(var point in grid) { grid[point] = new UVCell[1]; } 

			var shapeStorageInfo = new ShapeStorageInfo<FlatHexPoint>(new IntRect(), p => true);
			var shapeInfo = new FlatHexShapeInfo<UVCell>(shapeStorageInfo);

			return grid[grid.First()][0] == null || shapeInfo.Translate(FlatHexPoint.Zero) != null;
		}
		
		public static bool __CompilerHint__PointyHex__TextureCell()
		{
			var grid = new PointyHexGrid<TextureCell[]>(1, 1);

			foreach(var point in grid) { grid[point] = new TextureCell[1]; } 

			var shapeStorageInfo = new ShapeStorageInfo<PointyHexPoint>(new IntRect(), p => true);
			var shapeInfo = new PointyHexShapeInfo<TextureCell>(shapeStorageInfo);

			return grid[grid.First()][0] == null || shapeInfo.Translate(PointyHexPoint.Zero) != null;
		}
		public static bool __CompilerHint__FlatHex__TextureCell()
		{
			var grid = new FlatHexGrid<TextureCell[]>(1, 1);

			foreach(var point in grid) { grid[point] = new TextureCell[1]; } 

			var shapeStorageInfo = new ShapeStorageInfo<FlatHexPoint>(new IntRect(), p => true);
			var shapeInfo = new FlatHexShapeInfo<TextureCell>(shapeStorageInfo);

			return grid[grid.First()][0] == null || shapeInfo.Translate(FlatHexPoint.Zero) != null;
		}
		
		public static bool __CompilerHint__PointyHex__MeshTileCell()
		{
			var grid = new PointyHexGrid<MeshTileCell[]>(1, 1);

			foreach(var point in grid) { grid[point] = new MeshTileCell[1]; } 

			var shapeStorageInfo = new ShapeStorageInfo<PointyHexPoint>(new IntRect(), p => true);
			var shapeInfo = new PointyHexShapeInfo<MeshTileCell>(shapeStorageInfo);

			return grid[grid.First()][0] == null || shapeInfo.Translate(PointyHexPoint.Zero) != null;
		}
		public static bool __CompilerHint__FlatHex__MeshTileCell()
		{
			var grid = new FlatHexGrid<MeshTileCell[]>(1, 1);

			foreach(var point in grid) { grid[point] = new MeshTileCell[1]; } 

			var shapeStorageInfo = new ShapeStorageInfo<FlatHexPoint>(new IntRect(), p => true);
			var shapeInfo = new FlatHexShapeInfo<MeshTileCell>(shapeStorageInfo);

			return grid[grid.First()][0] == null || shapeInfo.Translate(FlatHexPoint.Zero) != null;
		}
		
		public static bool CallAll__()
		{
			
			if(!__CompilerHint__PointyHex__TileCell()) return false;
			if(!__CompilerHint__FlatHex__TileCell()) return false;
			
			if(!__CompilerHint__PointyHex__SpriteCell()) return false;
			if(!__CompilerHint__FlatHex__SpriteCell()) return false;
			
			if(!__CompilerHint__PointyHex__UVCell()) return false;
			if(!__CompilerHint__FlatHex__UVCell()) return false;
			
			if(!__CompilerHint__PointyHex__TextureCell()) return false;
			if(!__CompilerHint__FlatHex__TextureCell()) return false;
			
			if(!__CompilerHint__PointyHex__MeshTileCell()) return false;
			if(!__CompilerHint__FlatHex__MeshTileCell()) return false;
			
			return true;

		}
	}
}
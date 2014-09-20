#if !IgnoreHexLib
//----------------------------------------------//
// Gamelogic Grids                              //
// http://www.gamelogic.co.za                   //
// Copyright (c) 2013 Gamelogic (Pty) Ltd       //
//----------------------------------------------//

// Auto-generated File

using System;

namespace Gamelogic.Grids
{
	public partial class PointyHexGrid<TCell>
	{
		/**
			\copydoc PointyHexOp<TCell>::Rectangle
		*/
		public static PointyHexGrid<TCell> Rectangle(Int32 width, Int32 height)
		{
			return BeginShape().Rectangle(width, height).EndShape();
		}

		/**
			\copydoc PointyHexOp<TCell>::Hexagon
		*/
		public static PointyHexGrid<TCell> Hexagon(Int32 side)
		{
			return BeginShape().Hexagon(side).EndShape();
		}

		/**
			\copydoc PointyHexOp<TCell>::Hexagon
		*/
		public static PointyHexGrid<TCell> Hexagon(PointyHexPoint centre, Int32 side)
		{
			return BeginShape().Hexagon(centre, side).EndShape();
		}

		/**
			\copydoc PointyHexOp<TCell>::Parallelogram
		*/
		public static PointyHexGrid<TCell> Parallelogram(Int32 width, Int32 height)
		{
			return BeginShape().Parallelogram(width, height).EndShape();
		}

		/**
			\copydoc PointyHexOp<TCell>::UpTriangle
		*/
		public static PointyHexGrid<TCell> UpTriangle(Int32 side)
		{
			return BeginShape().UpTriangle(side).EndShape();
		}

		/**
			\copydoc PointyHexOp<TCell>::DownTriangle
		*/
		public static PointyHexGrid<TCell> DownTriangle(Int32 side)
		{
			return BeginShape().DownTriangle(side).EndShape();
		}

		/**
			\copydoc PointyHexOp<TCell>::Diamond
		*/
		public static PointyHexGrid<TCell> Diamond(Int32 side)
		{
			return BeginShape().Diamond(side).EndShape();
		}

		/**
			\copydoc PointyHexOp<TCell>::ThinRectangle
		*/
		public static PointyHexGrid<TCell> ThinRectangle(Int32 width, Int32 height)
		{
			return BeginShape().ThinRectangle(width, height).EndShape();
		}

		/**
			\copydoc PointyHexOp<TCell>::FatRectangle
		*/
		public static PointyHexGrid<TCell> FatRectangle(Int32 width, Int32 height)
		{
			return BeginShape().FatRectangle(width, height).EndShape();
		}

		/**
			\copydoc PointyHexOp<TCell>::Default
		*/
		public static PointyHexGrid<TCell> Default(Int32 width, Int32 height)
		{
			return BeginShape().Default(width, height).EndShape();
		}

		/**
			\copydoc PointyHexOp<TCell>::Single
		*/
		public static PointyHexGrid<TCell> Single()
		{
			return BeginShape().Single().EndShape();
		}

	}	
	public partial class FlatHexGrid<TCell>
	{
		/**
			\copydoc FlatHexOp<TCell>::Rectangle
		*/
		public static FlatHexGrid<TCell> Rectangle(Int32 width, Int32 height)
		{
			return BeginShape().Rectangle(width, height).EndShape();
		}

		/**
			\copydoc FlatHexOp<TCell>::FatRectangle
		*/
		public static FlatHexGrid<TCell> FatRectangle(Int32 width, Int32 height)
		{
			return BeginShape().FatRectangle(width, height).EndShape();
		}

		/**
			\copydoc FlatHexOp<TCell>::ThinRectangle
		*/
		public static FlatHexGrid<TCell> ThinRectangle(Int32 width, Int32 height)
		{
			return BeginShape().ThinRectangle(width, height).EndShape();
		}

		/**
			\copydoc FlatHexOp<TCell>::Hexagon
		*/
		public static FlatHexGrid<TCell> Hexagon(Int32 side)
		{
			return BeginShape().Hexagon(side).EndShape();
		}

		/**
			\copydoc FlatHexOp<TCell>::Hexagon
		*/
		public static FlatHexGrid<TCell> Hexagon(FlatHexPoint centre, Int32 side)
		{
			return BeginShape().Hexagon(centre, side).EndShape();
		}

		/**
			\copydoc FlatHexOp<TCell>::LeftTriangle
		*/
		public static FlatHexGrid<TCell> LeftTriangle(Int32 side)
		{
			return BeginShape().LeftTriangle(side).EndShape();
		}

		/**
			\copydoc FlatHexOp<TCell>::RightTriangle
		*/
		public static FlatHexGrid<TCell> RightTriangle(Int32 side)
		{
			return BeginShape().RightTriangle(side).EndShape();
		}

		/**
			\copydoc FlatHexOp<TCell>::Parallelogram
		*/
		public static FlatHexGrid<TCell> Parallelogram(Int32 width, Int32 height)
		{
			return BeginShape().Parallelogram(width, height).EndShape();
		}

		/**
			\copydoc FlatHexOp<TCell>::Diamond
		*/
		public static FlatHexGrid<TCell> Diamond(Int32 side)
		{
			return BeginShape().Diamond(side).EndShape();
		}

		/**
			\copydoc FlatHexOp<TCell>::Default
		*/
		public static FlatHexGrid<TCell> Default(Int32 width, Int32 height)
		{
			return BeginShape().Default(width, height).EndShape();
		}

		/**
			\copydoc FlatHexOp<TCell>::Single
		*/
		public static FlatHexGrid<TCell> Single()
		{
			return BeginShape().Single().EndShape();
		}

	}	
}
#endif

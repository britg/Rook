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
	/**
		Provides the implementation for AbstractShapeInfo to be used with PointyHexGrid.

		@link_constructing_grids
		@ingroup Scaffolding
	*/
	public class PointyHexShapeInfo<TCell> : AbstractShapeInfo <PointyHexShapeInfo<TCell>, PointyHexGrid<TCell>, PointyHexPoint, PointyHexPoint, PointyHexOp<TCell>> 
	{
		public PointyHexShapeInfo(ShapeStorageInfo<PointyHexPoint> info):
			base(info)
		{
		}

		/**
			Only call this method from within a PointyHexOp method (usually, in client code, 
			this will be in an extension).

			@param op the operator on which this shape is defined.
			@since 1.1
		*/
		public PointyHexShapeInfo<TCell> EndGroup(PointyHexOp<TCell> op)
		{
			var info = op.combineShapeInfo(op.leftShapeInfo, ShapeStorageStorageInfo);
			return new PointyHexShapeInfo<TCell>(info);
		}

		protected override PointyHexPoint MakePoint(int x, int y)
		{
			return new PointyHexPoint(x, y);
		}

		protected override PointyHexOp<TCell> MakeOp(
			ShapeStorageInfo<PointyHexPoint> shapeInfo, 
			Func<
				ShapeStorageInfo<PointyHexPoint>,
				ShapeStorageInfo<PointyHexPoint>,
				ShapeStorageInfo<PointyHexPoint>> combineInfo)
		{
			return new PointyHexOp<TCell>(shapeInfo,	combineInfo);
		}

		protected override PointyHexShapeInfo<TCell> MakeShapeInfo(
			ShapeStorageInfo<PointyHexPoint> shapeStorageInfo)
		{
			return new PointyHexShapeInfo<TCell>(shapeStorageInfo);
		}

		protected override PointyHexPoint GridPointFromArrayPoint(ArrayPoint point)
		{
			return PointyHexGrid<TCell>.GridPointFromArrayPoint(point);
		}

		protected override ArrayPoint ArrayPointFromGridPoint(PointyHexPoint point)
		{
			return PointyHexGrid<TCell>.ArrayPointFromGridPoint(point);
		}

		protected override PointyHexGrid<TCell> MakeShape(int x, int y, Func<PointyHexPoint, bool> isInside, PointyHexPoint offset)
		{
			return new PointyHexGrid<TCell>(x, y, isInside, offset);
		}
	}

	/**
		Provides the implementation for AbstractShapeInfo to be used with FlatHexGrid.

		@link_constructing_grids
		@ingroup Scaffolding
	*/
	public class FlatHexShapeInfo<TCell> : AbstractShapeInfo <FlatHexShapeInfo<TCell>, FlatHexGrid<TCell>, FlatHexPoint, FlatHexPoint, FlatHexOp<TCell>> 
	{
		public FlatHexShapeInfo(ShapeStorageInfo<FlatHexPoint> info):
			base(info)
		{
		}

		/**
			Only call this method from within a FlatHexOp method (usually, in client code, 
			this will be in an extension).

			@param op the operator on which this shape is defined.
			@since 1.1
		*/
		public FlatHexShapeInfo<TCell> EndGroup(FlatHexOp<TCell> op)
		{
			var info = op.combineShapeInfo(op.leftShapeInfo, ShapeStorageStorageInfo);
			return new FlatHexShapeInfo<TCell>(info);
		}

		protected override FlatHexPoint MakePoint(int x, int y)
		{
			return new FlatHexPoint(x, y);
		}

		protected override FlatHexOp<TCell> MakeOp(
			ShapeStorageInfo<FlatHexPoint> shapeInfo, 
			Func<
				ShapeStorageInfo<FlatHexPoint>,
				ShapeStorageInfo<FlatHexPoint>,
				ShapeStorageInfo<FlatHexPoint>> combineInfo)
		{
			return new FlatHexOp<TCell>(shapeInfo,	combineInfo);
		}

		protected override FlatHexShapeInfo<TCell> MakeShapeInfo(
			ShapeStorageInfo<FlatHexPoint> shapeStorageInfo)
		{
			return new FlatHexShapeInfo<TCell>(shapeStorageInfo);
		}

		protected override FlatHexPoint GridPointFromArrayPoint(ArrayPoint point)
		{
			return FlatHexGrid<TCell>.GridPointFromArrayPoint(point);
		}

		protected override ArrayPoint ArrayPointFromGridPoint(FlatHexPoint point)
		{
			return FlatHexGrid<TCell>.ArrayPointFromGridPoint(point);
		}

		protected override FlatHexGrid<TCell> MakeShape(int x, int y, Func<FlatHexPoint, bool> isInside, FlatHexPoint offset)
		{
			return new FlatHexGrid<TCell>(x, y, isInside, offset);
		}
	}

}
#endif

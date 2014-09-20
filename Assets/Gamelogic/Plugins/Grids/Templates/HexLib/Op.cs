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
		Class for making PointyHexGrids in different shapes.
		
		@link_constructing_grids
			
		@copyright Gamelogic.
		@author Herman Tulleken
		@since 1.0
		@see @ref AbstractOp
		@ingroup BuilderInterface
	*/
	public partial class PointyHexOp<TCell> : AbstractOp<ShapeStorageInfo<PointyHexPoint>>
	{
		public PointyHexOp(){}

		public PointyHexOp(
			ShapeStorageInfo<PointyHexPoint> leftShapeInfo,
			Func<ShapeStorageInfo<PointyHexPoint>, ShapeStorageInfo<PointyHexPoint>, ShapeStorageInfo<PointyHexPoint>> combineShapeInfo) :
			base(leftShapeInfo, combineShapeInfo)
		{}

		/**
			Use this function to create shapes to ensure they fit into memory.
		
			The test function can test shapes anywhere in space. If you specify the bottom corner 
			(in terms of the storage rectangle), the shape is automatically translated in memory 
			to fit, assuming memory width and height is big enough.

			Strategy for implementing new shapes:
				- First, determine the test function.
				- Next, draw a storage rectangle that contains the shape.
				- Determine the storgae rectangle width and height.
				- Finally, determine the grid-space coordinate of the left bottom corner of the storage rectangle.
		
			Then define your function as follows:

			\code{cs}
			public PointyHexShapeInfo<TCell> MyShape()
			{
				Shape(stargeRectangleWidth, storageRectangleHeight, isInsideMyShape, storageRectangleBottomleft);
			}
			\endcode

			\param width The widh of the storage rectangle
			\param height The height of the storage rectangle
			\param isInside A function that returns true if a passed point lies inside the shape being defined
			\param bottomLeftCorner The grid-space coordinate of the bottom left corner of the storage rect.

		*/
		public PointyHexShapeInfo<TCell> Shape(int width, int height, Func<PointyHexPoint, bool> isInside, PointyHexPoint bottomLeftCorner)
		{
			var shapeInfo = MakeShapeStorageInfo<PointyHexPoint>(width, height, x=>isInside(x + bottomLeftCorner));
			return new PointyHexShapeInfo<TCell>(shapeInfo).Translate(bottomLeftCorner);
		}

		/**
			The same as Shape with all parameters, but with bottomLeft Point set to  PointyHexPoint.Zero.
		*/
		public PointyHexShapeInfo<TCell> Shape(int width, int height, Func<PointyHexPoint, bool> isInside)
		{
			return Shape(width, height, isInside, PointyHexPoint.Zero);
		}

		/**
			Creates the grid in a shape that spans 
			the entire storage rectangle of the given width and height.
		*/
		[ShapeMethod]
		public PointyHexShapeInfo<TCell> Default(int width, int height)
		{
			var rawInfow = MakeShapeStorageInfo<PointyHexPoint>(
				width, 
				height,
				x => PointyHexGrid<TCell>.DefaultContains(x, width, height));

			return new PointyHexShapeInfo<TCell>(rawInfow);
		}

		/**
			Makes a grid with a single cell that corresponds to the origin.
		*/
		[ShapeMethod]
		public PointyHexShapeInfo<TCell> Single()
		{
			var rawInfow = MakeShapeStorageInfo<PointyHexPoint>(
				1, 
				1,
				x => x == PointyHexPoint.Zero);

			return new PointyHexShapeInfo<TCell>(rawInfow);
		}

		/**
			Starts a compound shape operation.

			Any shape that is defined in terms of other shape operations must use this method, and use Endgroup() to end the definition.

				public static PointyHexShapeInfo<TCell> MyCustomShape(this PointyHexOp<TCell> op)
				{
					return 
						BeginGroup()
							.Shape1()
							.Union()
							.Shape2()
						.EndGroup(op);
				}

			@since 1.1
		*/
		public PointyHexOp<TCell> BeginGroup()
		{
			return PointyHexGrid<TCell>.BeginShape();
		}
	}
	/**
		Class for making FlatHexGrids in different shapes.
		
		@link_constructing_grids
			
		@copyright Gamelogic.
		@author Herman Tulleken
		@since 1.0
		@see @ref AbstractOp
		@ingroup BuilderInterface
	*/
	public partial class FlatHexOp<TCell> : AbstractOp<ShapeStorageInfo<FlatHexPoint>>
	{
		public FlatHexOp(){}

		public FlatHexOp(
			ShapeStorageInfo<FlatHexPoint> leftShapeInfo,
			Func<ShapeStorageInfo<FlatHexPoint>, ShapeStorageInfo<FlatHexPoint>, ShapeStorageInfo<FlatHexPoint>> combineShapeInfo) :
			base(leftShapeInfo, combineShapeInfo)
		{}

		/**
			Use this function to create shapes to ensure they fit into memory.
		
			The test function can test shapes anywhere in space. If you specify the bottom corner 
			(in terms of the storage rectangle), the shape is automatically translated in memory 
			to fit, assuming memory width and height is big enough.

			Strategy for implementing new shapes:
				- First, determine the test function.
				- Next, draw a storage rectangle that contains the shape.
				- Determine the storgae rectangle width and height.
				- Finally, determine the grid-space coordinate of the left bottom corner of the storage rectangle.
		
			Then define your function as follows:

			\code{cs}
			public FlatHexShapeInfo<TCell> MyShape()
			{
				Shape(stargeRectangleWidth, storageRectangleHeight, isInsideMyShape, storageRectangleBottomleft);
			}
			\endcode

			\param width The widh of the storage rectangle
			\param height The height of the storage rectangle
			\param isInside A function that returns true if a passed point lies inside the shape being defined
			\param bottomLeftCorner The grid-space coordinate of the bottom left corner of the storage rect.

		*/
		public FlatHexShapeInfo<TCell> Shape(int width, int height, Func<FlatHexPoint, bool> isInside, FlatHexPoint bottomLeftCorner)
		{
			var shapeInfo = MakeShapeStorageInfo<FlatHexPoint>(width, height, x=>isInside(x + bottomLeftCorner));
			return new FlatHexShapeInfo<TCell>(shapeInfo).Translate(bottomLeftCorner);
		}

		/**
			The same as Shape with all parameters, but with bottomLeft Point set to  FlatHexPoint.Zero.
		*/
		public FlatHexShapeInfo<TCell> Shape(int width, int height, Func<FlatHexPoint, bool> isInside)
		{
			return Shape(width, height, isInside, FlatHexPoint.Zero);
		}

		/**
			Creates the grid in a shape that spans 
			the entire storage rectangle of the given width and height.
		*/
		[ShapeMethod]
		public FlatHexShapeInfo<TCell> Default(int width, int height)
		{
			var rawInfow = MakeShapeStorageInfo<FlatHexPoint>(
				width, 
				height,
				x => FlatHexGrid<TCell>.DefaultContains(x, width, height));

			return new FlatHexShapeInfo<TCell>(rawInfow);
		}

		/**
			Makes a grid with a single cell that corresponds to the origin.
		*/
		[ShapeMethod]
		public FlatHexShapeInfo<TCell> Single()
		{
			var rawInfow = MakeShapeStorageInfo<FlatHexPoint>(
				1, 
				1,
				x => x == FlatHexPoint.Zero);

			return new FlatHexShapeInfo<TCell>(rawInfow);
		}

		/**
			Starts a compound shape operation.

			Any shape that is defined in terms of other shape operations must use this method, and use Endgroup() to end the definition.

				public static FlatHexShapeInfo<TCell> MyCustomShape(this FlatHexOp<TCell> op)
				{
					return 
						BeginGroup()
							.Shape1()
							.Union()
							.Shape2()
						.EndGroup(op);
				}

			@since 1.1
		*/
		public FlatHexOp<TCell> BeginGroup()
		{
			return FlatHexGrid<TCell>.BeginShape();
		}
	}
}
#endif

//----------------------------------------------//
// Gamelogic Grids                              //
// http://www.gamelogic.co.za                   //
// Copyright (c) 2013 Gamelogic (Pty) Ltd       //
//----------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Vector2 = UnityEngine.Vector2;

namespace Gamelogic.Grids
{
	/**
		This class provides utilities for constructing points, vectors and other 
		objects by examining the type parameters. These methods are mostly used for
		creating generic tests, and may be too slow to use in production code.

		
		
		@version1_0

		@ingroup Utilities
	*/
	public static class GridUtil
	{
		/**
			Note: this method is provided for generic testing purposes, 
			and should generally not be used in production code: it may be 
			slow.
		*/
		public static TPoint Zero<TPoint>()
				where TPoint : IGridPoint<TPoint>
		{
			if (typeof(TPoint) == typeof(PointyHexPoint))
			{
				return (TPoint)(object)PointyHexPoint.Zero;
			}
			if (typeof(TPoint) == typeof(FlatHexPoint))
			{
				return (TPoint)(object)FlatHexPoint.Zero;
			}
			
			throw new NotSupportedException();
		}

		public static int RenderIndex<TPoint>(this TPoint point)
		{
			return 0;
		}

		/**
			Note: this method is provided for generic testing purposes, 
			and should generally not be used in production code: it may be 
			slow.
		*/
		public static TPoint MakePoint<TPoint>(int x, int y)
				where TPoint : IVectorPoint<TPoint>
		{
			if (typeof(TPoint) == typeof(PointyHexPoint))
			{
				return (TPoint)(object)new PointyHexPoint(x, y);
			}
			if (typeof(TPoint) == typeof(FlatHexPoint))
			{
				return (TPoint)(object)new FlatHexPoint(x, y);
			}
			
			throw new NotSupportedException();
		}

		public static IEnumerable<TPoint> MakePointList<TPoint>(params int[] coordinates)
			where TPoint : IVectorPoint<TPoint>, IGridPoint<TPoint>
		{
			int coordiateCount = coordinates.Length;

			Debug.Assert(coordiateCount % 2 == 0);

			var list = new PointList<TPoint>();

			for (int i = 0; i < coordiateCount; i += 2)
			{
				list.Add(MakePoint<TPoint>(coordinates[i], coordinates[i + 1]));
			}

			return list;
		}

		/**
			This method is provided for generic testing purposes. 
			It should generally not be used in production code: it may 
			be slow and not type-safe.
		*/
		public static TGrid MakeGrid<TPoint, TGrid, TCell>(int width, int height)
			where TPoint : IGridPoint<TPoint>
			where TGrid : IGrid<TCell, TPoint>
		{
			return MakeGrid<TPoint, TGrid, TCell>(width, height, Zero<TPoint>());
		}

		/**
			This method is provided for generic testing purposes. 
			It should generally not be used in production code: it may 
			be slow and not type-safe.
		*/
		public static TGrid MakeGrid<TPoint, TGrid, TCell>(int width, int height, Func<TPoint, bool> isInside)
			where TPoint : IGridPoint<TPoint>
			where TGrid : IGrid<TCell, TPoint>
		{
			return MakeGrid<TPoint, TGrid, TCell>(width, height, isInside, Zero<TPoint>());
		}

		/**
			This method is provided for generic testing purposes. 
			It should generally not be used in production code: it may 
			be slow and not type-safe.
		*/
		public static TGrid MakeGrid<TPoint, TGrid, TCell>(int width, int height, Func<TPoint, bool> isInside, TPoint offset)
			where TPoint : IGridPoint<TPoint>
			where TGrid : IGrid<TCell, TPoint>
		{
			if (typeof(TPoint) == typeof(PointyHexPoint))
			{
				Debug.Assert(typeof(TGrid) == typeof(PointyHexGrid<TCell>));

				return (TGrid)(object)new PointyHexGrid<TCell>(
					width,
					height,
					(Func<PointyHexPoint, bool>)(object)isInside,
					(PointyHexPoint)(object)offset);
			}
			if (typeof(TPoint) == typeof(FlatHexPoint))
			{
				Debug.Assert(typeof(TGrid) == typeof(FlatHexGrid<TCell>));

				return (TGrid)(object)new FlatHexGrid<TCell>(
					width,
					height,
					(Func<FlatHexPoint, bool>)(object)isInside,
					(FlatHexPoint)(object)offset);
			}

			throw new NotSupportedException();
		}

		/**
			This method is provided for generic testing purposes. 
			It should generally not be used in production code: it may 
			be slow and not type-safe.
		*/
		public static TGrid MakeGrid<TPoint, TGrid, TCell>(int width, int height, TPoint offset)
			where TPoint : IGridPoint<TPoint>
			where TGrid : IGrid<TCell, TPoint>
		{
			if (typeof(TPoint) == typeof(PointyHexPoint))
			{
				Debug.Assert(typeof(TGrid) == typeof(PointyHexGrid<TCell>));

				return (TGrid)(object)new PointyHexGrid<TCell>(
					width,
					height,
					x => PointyHexGrid<TCell>.DefaultContains(x, width, height),
					(PointyHexPoint)(object)offset);
			}
			if (typeof(TPoint) == typeof(FlatHexPoint))
			{
				Debug.Assert(typeof(TGrid) == typeof(FlatHexGrid<TCell>));

				return (TGrid)(object)new FlatHexGrid<TCell>(
					width,
					height,
					x => FlatHexGrid<TCell>.DefaultContains(x, width, height),
					(FlatHexPoint)(object)offset);
			}

			throw new NotSupportedException();
		}

		public static int SpliceCount<TPoint>(this TPoint point)
			where TPoint : IGridPoint<TPoint>
		{
			return 1;
		}

		public static IMap<TPoint> MakeMap<TMap, TPoint>(Vector2 cellDimensions)
			where TPoint : IGridPoint<TPoint>
			where TMap : IMap<TPoint>
		{
			if (typeof(TMap) == typeof(FlatHexMap))
			{
				Debug.Assert(typeof(TPoint) == typeof(FlatHexPoint));

				return (IMap<TPoint>)new FlatHexMap(cellDimensions);
			}
			if (typeof(TMap) == typeof(PointyHexMap))
			{
				Debug.Assert(typeof(TPoint) == typeof(PointyHexPoint));

				return (IMap<TPoint>)new PointyHexMap(cellDimensions);
			}
			
			throw new NotSupportedException();
		}
		public static string ToGizmoString(this object obj)
		{
			if (obj == null) return "null";

			var p1 = obj as InspectableVectorPoint;

			if (p1 != null) return p1.ToGizmoString();

			return obj.ToString();
		}

		public static string ToGizmoString(this InspectableVectorPoint point)
		{
			return "(" + point.x + " " + point.y + ")";
		}

		public static int GetColor(this object point, int x0, int x1, int y1)
		{
			var p1 = point as InspectableVectorPoint;

			if (p1 != null) return p1.GetColor(x0, x1, y1);

			return 0;
		}

		public static int GetColor(this InspectableVectorPoint point, int x0, int x1, int y1)
		{
			return point.GetPointyHexPoint().GetColor(x0, x1, y1);
		}

		public static TPoint VectorPointToGridPoint<TPoint>(InspectableVectorPoint p)
			where TPoint : IVectorPoint<TPoint>
		{
			return MakePoint<TPoint>(p.x, p.y);
		}

		public static TPoint VectorPointToGridPoint<TPoint>(object point)
		{
			var p1 = point as InspectableVectorPoint;

			if (p1 != null)
			{

				if (typeof(TPoint) == typeof(PointyHexPoint))
				{
					return (TPoint)(object)VectorPointToGridPoint<PointyHexPoint>(p1);
				}
				if (typeof(TPoint) == typeof(FlatHexPoint))
				{
					return (TPoint)(object)VectorPointToGridPoint<FlatHexPoint>(p1);
				}
			}

			return (TPoint)point;
		}

		private static InspectableVectorPoint GridPointToVectorPoint<TPoint>(TPoint p)
			where TPoint : IVectorPoint<TPoint>
		{
			return new InspectableVectorPoint
			{
				x = p.X,
				y = p.Y
			};
		}

		public static object GridPointToVectorPoint<TPoint>(IGridPoint<TPoint> p)
			where TPoint : IGridPoint<TPoint>
		{
			if (typeof(TPoint) == typeof(PointyHexPoint))
			{
				return GridPointToVectorPoint((PointyHexPoint)(object)p);
			}
			if (typeof(TPoint) == typeof(FlatHexPoint))
			{
				return GridPointToVectorPoint((FlatHexPoint)(object)p);
			}
			

			return p;
		}

		
	}
}
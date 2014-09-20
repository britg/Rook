//----------------------------------------------//
// Gamelogic Grids                              //
// http://www.gamelogic.co.za                   //
// Copyright (c) 2013 Gamelogic (Pty) Ltd       //
//----------------------------------------------//

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gamelogic.Grids
{
	/**
		Defines extension methods for the IGrid interface. 
	
		This is implemented as an extension so that implementers need not
		extend from a common base class, but provide it to their clients.

		
		
		@version1_0

		@ingroup Interface
	*/
	public static class GridExtensions
	{
		/**
			Returns a new grid in the same shape as the given grid, with the same contents casted to the new type.
			
			@version1_8
		*/
		public static IGrid<TNewCell, TPoint> CastValues<TNewCell, TPoint>(this IGrid<TPoint> grid) 
			where TPoint : IGridPoint<TPoint>
		{
			if (grid == null)
			{
				throw new ArgumentNullException("grid");
			}

			var newGrid = grid as IGrid<TNewCell, TPoint>;

			if (newGrid != null) return newGrid;

			newGrid = grid.CloneStructure<TNewCell>();

			foreach (var point in grid)
			{
				newGrid[point] = (TNewCell) grid[point];
			}

			return newGrid;
		}

		/**
			Returns a shallow copy of the given grid.
			
			@version1_8
		*/
		public static IGrid<TCell, TPoint> Clone<TCell, TPoint>(this IGrid<TCell, TPoint> grid) 
			where TPoint : IGridPoint<TPoint>
		{
			if (grid == null)
			{
				throw new ArgumentNullException("grid");
			}

			var newGrid = grid.CloneStructure<TCell>();

			foreach (var point in grid)
			{
				newGrid[point] = grid[point];
			}

			return newGrid;
		}

		/**
			Only return neighbors of the point that are inside the grid, as defined by IsInside,
			that also satisfies the predicate includePoint.
		
			It is equivalent to GetNeighbors(point).Where(includePoint).

			@version1_7
		*/
		public static IEnumerable<TPoint> GetNeighbors<TCell, TPoint>(
			this IGrid<TCell, TPoint> grid,
			TPoint point, Func<TPoint, bool> includePoint)

			where TPoint : IGridPoint<TPoint>
		{
			return
				(from neighbor in grid.GetAllNeighbors(point)
				 where grid.Contains(neighbor) && includePoint(neighbor)
				 select neighbor);
		}

		/**
			Only return neighbors of the point that are inside the grid, as defined by IsInside, 
			whose associated cells also satisfy the predicate includeCell.

			It is equivalent to GetNeighbors(point).Where(p => includeCell(grid[p])

			@version1_7
		*/
		public static IEnumerable<TPoint> GetNeighbors<TCell, TPoint>(
			this IGrid<TCell, TPoint> grid,
			TPoint point, Func<TCell, bool> includeCell)

			where TPoint : IGridPoint<TPoint>
		{
			return
				(from neighbor in grid.GetAllNeighbors(point)
				 where grid.Contains(neighbor) && includeCell(grid[neighbor])
				 select neighbor);
		}

		/**
			Returns all neighbors of this point that satisfies the condition, 
			regardless of whether they are in the grid or not.
		*/

		public static IEnumerable<TPoint> GetAllNeighbors<TCell, TPoint>(
			this IGrid<TCell, TPoint> grid,
			TPoint point, Func<TPoint, bool> includePoint)

			where TPoint : IGridPoint<TPoint>
		{
			return grid.GetAllNeighbors(point).Where(includePoint);
		}

		/**
			Returns a list of all points whose associated cells also satisfy the predicate include.

			It is equivalent to GetNeighbors(point).Where(p => includeCell(grid[p])

			@version1_7
		*/
		public static IEnumerable<TPoint> WhereCell<TCell, TPoint>(
			this IGrid<TCell, TPoint> grid, Func<TCell, bool> include)

			where TPoint : IGridPoint<TPoint>
		{
			return grid.Where(p => include(grid[p]));
		}


		/**
			Only return neighbors of the point that are inside the grid, as defined by Contains.
		*/
		public static IEnumerable<TPoint> GetNeighbors<TCell, TPoint>(
			this IGrid<TCell, TPoint> grid,
			TPoint point)

			where TPoint : IGridPoint<TPoint>
		{
			//return grid.GetNeighbors(point, (TPoint p) => true);
			return 
				from neighbor in grid.GetAllNeighbors(point)
				where grid.Contains(neighbor)
				select neighbor;
		}

		/**
			Returns whether the point is outside the grid.
		
			\implementers This method must be consistent with IsInside, and hence
			is not overridable.
		*/
		public static bool IsOutside<TCell, TPoint>(
			this IGrid<TCell, TPoint> grid,
			TPoint point)

			where TPoint : IGridPoint<TPoint>
		{
			return !grid.Contains(point);
		}

		/**
			Returns a list of cells that correspond to the list of points.
		*/
		public static IEnumerable<TCell> Select<TCell, TPoint>(
			this IGrid<TCell, TPoint> grid,
			IEnumerable<TPoint> pointList)

			where TPoint : IGridPoint<TPoint>
		{
			return pointList.Select(x => grid[x]);
		}

		/**
			Shuffles the contents of a grid.

			@version1_6
		*/
		public static void Shuffle<TCell, TPoint>(
			this IGrid<TCell, TPoint> grid)

			where TPoint : IGridPoint<TPoint>
		{
			var points = grid.ToList();

			if (points.Count <= 1)
			{
				return; //nothing to shuffle
			}
			
			var shuffledPoints = grid.ToList();
			shuffledPoints.Shuffle();

			var tmpGrid = grid.CloneStructure<TCell>();

			for (int i = 0; i < points.Count; i++)
			{
				tmpGrid[points[i]] = grid[shuffledPoints[i]];
			}

			foreach (var point in grid)
			{
				grid[point] = tmpGrid[point];
			}
		}

		/**
			The same as `grid[point]`. This method is included to make
			it easier to construct certain LINQ expressions, for example
			
				grid.Select(grid.GetCell)
				grid.Where(p => p.GetColor4_2() == 0).Select(grid.GetCell)

			@version1_7
		*/
		public static TCell GetCell<TCell, TPoint>(
			this IGrid<TCell, TPoint> grid, TPoint point)
			
			where TPoint : IGridPoint<TPoint>
		{
			return grid[point];
		}

		/**
			The same as `grid[point] = value`. This method is provided 
			to be consistent with GetCell.

			@version1_7
		*/
		public static void SetCell<TCell, TPoint>(
			this IGrid<TCell, TPoint> grid, TPoint point, TCell value)

			where TPoint : IGridPoint<TPoint>
		{
			grid[point] = value;
		}
	}
}
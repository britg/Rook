using UnityEditor;
using UnityEngine;

public class InvertUVScale : Editor
{
	[MenuItem("Tools/ProBuilder/Repair/Invert UV Scale (Scene)", false, pb_Constant.MENU_REPAIR + 30)]
	public static void MenuInvertSceneFaceUVScale()
	{
		pb_Upgrade.InvertUVScale_Scene();
	}

	[MenuItem("Tools/ProBuilder/Repair/Invert UV Scale (Selected Objects)", false, pb_Constant.MENU_REPAIR + 30)]
	public static void MenuInvertSelectedObjectsUVScale()
	{
		pb_Upgrade.InvertUVScale_Selection();
	}
	
	[MenuItem("Tools/ProBuilder/Repair/Invert UV Scale (Selected Faces)", false, pb_Constant.MENU_REPAIR + 30)]
	public static void MenuInvertSelectedFacesUVScale()
	{
		pb_Upgrade.InvertUVScale_SelectedFaces();
	}
}
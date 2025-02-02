﻿using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class exists so you can create empty item entries
/// without need for gameobject(like in SpawnedObjectsList).
/// This will be obsolete once generic lists arrive.
/// </summary>
public class EmptyItemList : NetUIDynamicList
{
	public void AddItems(int count)
	{
		for (int i = 0; i < count; i++)
		{
			AddItem();
		}
	}

	public bool AddItem()
	{
		//add new entry
		var newEntry = Add();
		if (!newEntry)
		{
			Logger.LogWarning($"Added {newEntry} is not an CargoItem!", Category.ItemSpawn);
			return false;
		}
		Logger.Log($"ItemList: Item add success! newEntry={newEntry}", Category.ItemSpawn);

		//rescan elements  and notify
		NetworkTabManager.Instance.Rescan(MasterTab.NetTabDescriptor);
		UpdatePeepers();

		return true;
	}
}

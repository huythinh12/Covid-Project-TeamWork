using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ListItem", menuName = "Inventory/ListItem")]
public class ListItem : ScriptableObject
{
	public List<Item> listFood;
}

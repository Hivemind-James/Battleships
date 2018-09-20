
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
/// <summary>
/// The values that are visable for a given tile at any given time.
/// </summary>
public enum TileView
{
	/// <summary>
	/// The viewer can see sea (all tiles)
	/// </summary>
	/// <remarks>
	/// May be masking a ship if viewed via a sea adapter
	/// </remarks>
	Sea,

	/// <summary>
	/// The viewer knows that site was attacked but nothing
	/// was hit (miss filled blue square)
	/// </summary>
	Miss,

	/// <summary>
	/// The viewer can see a ship at this site (hit fill red)
	/// </summary>
	Ship,

	/// <summary>
	/// The viewer knows that the site was attacked and
	/// something was hit (hit animation)
	/// </summary>
	Hit
}

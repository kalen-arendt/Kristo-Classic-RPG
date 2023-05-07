using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public interface ISingleton<T>
	where T : ISingleton<T>
{
	T Singleton { get; }
	GameObject gameObject { get; }
}

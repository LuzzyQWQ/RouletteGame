using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Argali.Util.Reflection
{

	public class ReflectionUtility
	{
		public static System.Type GetTypeByName(string name)
		{
			foreach (Assembly assembly in System.AppDomain.CurrentDomain.GetAssemblies())
			{
				foreach (System.Type type in assembly.GetTypes())
				{
					if (type.Name == name)
						return type;
				}
			}

			return null;
		}
	}

}

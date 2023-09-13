using Microsoft.Azure.Functions.Worker;
using System.Reflection;

namespace Function.Extentions
{
	public static class FunctionDefinationExtentions
	{
		public static Attribute? GetAttribute(this FunctionDefinition definition,Type attribute)
		{
			int indexOfSeparator = definition.EntryPoint.LastIndexOf('.');
			var className = definition.EntryPoint.Substring(0, indexOfSeparator);
			var functionName = definition.EntryPoint.Substring(indexOfSeparator + 1);
			return Assembly
				.LoadFrom(definition.PathToAssembly)?
				.GetType(className)?
				.GetMethod(functionName)?
				.GetCustomAttribute(attribute);
		}

		public static bool HasCustomAttribute(this FunctionDefinition definition,Type attribute)
		{
			return GetAttribute(definition, attribute) != null;
		}
	}
}

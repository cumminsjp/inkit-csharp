using System;
using System.IO;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Inkit.Tests.Helpers {
	/// <summary>
	///     Helper methods for the test project
	/// </summary>
	public static class TestHelper {
		/// <summary>
		///     Gets the test file data as a string
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns></returns>
		public static string GetTestFileData(string fileName) {
			var testFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestFiles", fileName);

			return File.ReadAllText(testFile);
		}

		/// <summary>
		///     Asserts the json object properties are camel case
		/// </summary>
		/// <param name="json">The json.</param>
		public static void AssertCamelCase(string json) {
			var jo = JObject.Parse(json);

			Assert.IsNotNull(jo);

			AssertCamelCase(jo);
		}

		/// <summary>
		///     Asserts the camel case.
		/// </summary>
		/// <param name="jo">The jo.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public static void AssertCamelCase(JObject jo) {
			foreach (var property in jo.Properties()) {
				Assert.IsTrue(char.IsLower(property.Name, 0),
					$"'{property.Name}' does not start with lower case character.");

				var i = property.Name.IndexOf("_", StringComparison.InvariantCultureIgnoreCase);

				Assert.AreEqual(-1, i, $"{property.Name} has an underscore at index: {i}");

				if (property.Value is JObject)
					AssertCamelCase((JObject) property.Value);
				else if (property.Value is JArray)
					AssertCamelCase((JArray) property.Value);
				else if (property.Value is JValue) {
					// no check
				} else
					throw new NotImplementedException();
			}
		}

		/// <summary>
		///     Asserts the camel case.
		/// </summary>
		/// <param name="array">The array.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public static void AssertCamelCase(JArray array) {
			foreach (var item in array)
				if (item is JObject)
					AssertCamelCase((JObject) item);
				else if (item is JArray)
					AssertCamelCase((JArray) item);
				else if (item is JValue) {
					// no check
				} else
					throw new NotImplementedException();
		}

		/// <summary>
		///     Gets the test file from the "TestFiles" directory.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns></returns>
		public static string GetTestFile(string fileName) {

			var testFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestFiles",
				fileName);

			return testFile;
		}

		/// <summary>
		///     Gets the test file as string.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns></returns>
		public static string GetTestFileAsString(string fileName) => File.ReadAllText(GetTestFile(fileName));

		/// <summary>
		/// Gets the temporary file with the provided extension
		/// </summary>
		/// <param name="extension">The extension.</param>
		/// <returns></returns>
		/// <exception cref="System.ApplicationException">No unique temporary file name is available.</exception>
		public static string GetTempFile(string extension)
		{
			int attempt = 0;
			while (attempt < 10)
			{
				string fileName = $"{System.IO.Path.GetTempPath()}{Guid.NewGuid().ToString()}.{extension}";

				if (!File.Exists(fileName))
					return fileName;

				attempt++;
			}

			throw new ApplicationException("No unique temporary file name is available.");
		}
		
	}
}

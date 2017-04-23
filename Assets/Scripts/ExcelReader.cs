using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExcelReader {

	string filepath;
	string[] names;
	List<Dictionary<string, string>> allRows;
	public ExcelReader(string fn)
	{
		filepath = fn;
	}

	public List<Dictionary<string, string>> getAllRows()
	{
		allRows = new List<Dictionary<string, string>>();
		using (StreamReader sr = new StreamReader (filepath)) {
			
			string line;
			if ((line = sr.ReadLine()) != null) {
				//Debug.Log (line);
				names = line.Split(',');
			}

			line = sr.ReadLine ();
			while (line != null && line != "") {
				//Debug.Log (line);
				Dictionary<string, string> colValues = new Dictionary<string, string> ();
				int index = 0;
				string[] values = line.Split (',');
				foreach (string name in names) {
					colValues [name] = values [index++];
				}
				allRows.Add (colValues);
				line = sr.ReadLine ();
			}

		}
		return allRows;
	}
}

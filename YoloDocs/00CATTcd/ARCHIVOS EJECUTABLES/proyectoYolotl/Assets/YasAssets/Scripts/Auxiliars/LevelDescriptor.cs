using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class LevelDescriptor{
	public string levelName;
	public string levelDescription;
}

[System.Serializable]
public class LevelDescriptors{
	public List<LevelDescriptor> levels;

	public LevelDescriptor GetDialogue(int index){
		return	levels [index];
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

///<summary>
///This is an object for automatic file organizing, which
///moves specified files from root folder (Application.Datapath)
///to desired folder.
///A FileManager object in the editor must be created to assign
///file types and targeted folders.
///</summary>

[InitializeOnLoad]
[CreateAssetMenu(fileName = "FileData", menuName = "Files/FileManager", order = 1)]
public class FileOrganizer : ScriptableObject
{
    public List<FileType> files = new List<FileType>();
    static List<FileType> fileTypes = new List<FileType>();
    public bool enabled;
    static bool isEnabled;


    //Check bool if component values are changed
    private void OnValidate()
    {
        isEnabled = enabled;
    }

    //Constructors
    FileOrganizer()
    {
        fileTypes = files;
    }

    static FileOrganizer()
    {
        EditorApplication.update += OnUpdate;
    }

    //File organizer
    static void OnUpdate()
    {

        if (!isEnabled)
        {
            return;
        }

        var info = new DirectoryInfo(Application.dataPath);
        var fileInfo = info.GetFiles();
        foreach (var file in fileInfo)
        {
            foreach (FileType f in fileTypes)
            {
                //Ignore filetypes with empty efields
                if (f.fileEnding.Length == 0 || f.targetLocation.Length == 0)
                {
                    continue;
                }

                //Check if file matches filetypes
                if (file.Name.Substring(Mathf.Max(0, file.Name.Length - f.fileEnding.Length)) == f.fileEnding)
                {
                    //Create new directory if one doesn't exist
                    if (!File.Exists(Application.dataPath + "\\" + f.targetLocation))
                    {
                        Debug.Log("Created new directory " + f.targetLocation);
                        Directory.CreateDirectory(Application.dataPath + "\\" + f.targetLocation);
                    }

                    //Change file name if one with the same name exists
                    if (File.Exists(Application.dataPath + "\\"+ f.targetLocation +"\\" + file.Name))
                    {
                        string name = file.Name.Substring(0, file.Name.Length - f.fileEnding.Length);
                        name += "0" + f.fileEnding;
                        FileUtil.MoveFileOrDirectory(Application.dataPath + "\\" + file.Name, Application.dataPath + "\\" + name);
                        FileUtil.MoveFileOrDirectory(Application.dataPath + "\\" + file.Name + ".meta", Application.dataPath + "\\" + name + ".meta");
                        Debug.Log("File " + file.Name + " already exists!");
                        AssetDatabase.Refresh();
                    }
                    else //Move file to target location
                    {

                        FileUtil.MoveFileOrDirectory(Application.dataPath + "\\" + file.Name, Application.dataPath + "\\" + f.targetLocation + "\\" + file.Name);
                        FileUtil.MoveFileOrDirectory(Application.dataPath + "\\" + file.Name + ".meta", Application.dataPath + "\\" + f.targetLocation + "\\" + file.Name + ".meta");
                        AssetDatabase.Refresh();
                        Debug.Log("Moved file \"" + file.Name + "\" to folder: " + f.targetLocation);

                        //TODO: Automatically jump to targeted folder
                    }
                }
            }
        }
    }
}

[System.Serializable]
public class FileType
{
    public string fileEnding;
    public string targetLocation;
}

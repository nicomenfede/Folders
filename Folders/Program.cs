using System;
using System.Collections.Generic;
using System.Linq;

public class Folders
{
    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        

        List<string> response = new List<string>();

        

        while (xml.IndexOf("<folder name") != -1)
        {
            var index = xml.IndexOf("<folder name");
            var removeEverythingBeforeFolderName = xml.Substring(index);
            xml = removeEverythingBeforeFolderName;
            
            index = xml.IndexOf("\"") + 1;
            var removeBeforeQuote = xml.Substring(index);
            xml = removeBeforeQuote;

            index = xml.IndexOf("\"");
            var folderName = xml.Substring(0, index);
            if (folderName[0] == startingLetter)
                response.Add(folderName);
        }
 
        return response;
    }

    public static void Main(string[] args)
    {
        string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

        foreach (string name in Folders.FolderNames(xml, 'u'))
            Console.WriteLine(name);
    }
}
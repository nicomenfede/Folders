using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class Folders
{
    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        XDocument xdocument = XDocument.Parse(xml);
        var folders = xdocument.Descendants("folder");

        var query = from f in folders
                    where f.Attribute("name").Value.StartsWith(startingLetter.ToString())
                    select f.Attribute("name").Value;

        return query;
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
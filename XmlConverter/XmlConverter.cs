using System.Xml;
using System.Xml.Linq;

namespace XmlConverter;

public interface IXmlConverter
{
    void ConvertPeople(List<string> people);
}

public class XmlConverter : IXmlConverter
{
    private readonly XmlWriterSettings _settings = new()
    {
        Indent = true,
        IndentChars = ("    "),
        CloseOutput = true,
        OmitXmlDeclaration = true
    };

    public void ConvertPeople(List<string> people)
    {
        var xElements = new XElement("people",
            new XElement("person",
                people.Select(p => CreateElements(p.Split("|").ToList()))));
        
        Console.WriteLine(xElements);
    }

    private List<XElement> CreateElements(List<string> elements, bool isChildElement = false) => elements.First() switch
    {
        "P" => new List<XElement>()
        {
            new("firstname", elements[1]),
            new("lastname", elements[2])
        },
        "T" => new List<XElement>()
        {
                 new("phone",
                    new XElement("mobile", elements[1]),
                    new XElement("landline", elements[2]))
        },
        "A" => new List<XElement>()
        {
            new("address",
                new XElement("street", elements[1]),
                new XElement("city", elements[2]),
                elements.Count > 3 ? new XElement("zip", elements[3]) : null
                
            )
        },
        "F" => new List<XElement>()
        {
            new("family",
                new XElement("name", elements[1]),
                new XElement("born", elements[2]))
        },
        _ => throw new ArgumentException($"{elements.First()} is not a valid character.")
    };
}
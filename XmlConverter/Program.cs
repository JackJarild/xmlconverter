﻿using System.Xml;

var people = new List<string>()
{
    "P|Elof|Sundin",
    "T|073-101801|018-101801",
    "A|S:t Johannesgatan 16|Uppsala|75330",
    "F|Hans|1967",
    "A|Frodegatan 13B|Uppsala|75325",
    "F|Anna|1969",
    "T|073-101802|08-101802",
    "P|Boris|Johnson",
    "A|10 Downing Street|London",
};

var xmlConverter = new XmlConverter.XmlConverter();

xmlConverter.ConvertPeople(people);

Console.ReadLine();
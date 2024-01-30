using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string json = @"
            {
                ""OnLoad"": {
                    ""Params"": {
                        ""Param1"": ""paramval1"",
                        ""Param2"": ""paramval2""
                    },
                    ""Controls"": {
                        ""field_name1"": {
                            ""Visible"": [
                                {
                                    ""Params1"": [ ""value1"", ""value2"" ],
                                    ""Params2"": [ ""value3"", ""value4"" ]
                                },
                                {
                                    ""Params1"": [ ""value5"", ""value6"" ],
                                    ""Params2"": [ ""value7"", ""value8"" ]
                                }
                            ],
                            ""Required"": [
                                {
                                    ""Params1"": [ ""value9"", ""value10"" ],
                                    ""Params2"": [ ""value11"", ""value12"" ]
                                }
                            ]
                        },
                        ""field_name2"": {
                            ""Visible"": [
                                {
                                    ""Params1"": [ ""value13"", ""value14"" ],
                                    ""Params2"": [ ""value15"", ""value16"" ]
                                }
                            ],
                            ""Required"": [
                                {
                                    ""Params1"": [ ""value17"", ""value18"" ],
                                    ""Params2"": [ ""value19"", ""value20"" ]
                                }
                            ]
                        }
                    }
                }
            }";

            var deserializedObject = JsonConvert.DeserializeObject<RootObject>(json);

            Console.WriteLine("Param1: " + deserializedObject.OnLoad.Params.Param1);
            foreach (var control in deserializedObject.OnLoad.Controls)
            {
                Console.WriteLine("Control: " + control.Key);
                foreach (var visibleParams in control.Value.Visible)
                {
                    Console.WriteLine("Visible Params1: " + string.Join(", ", visibleParams.Params1));
                    Console.WriteLine("Visible Params2: " + string.Join(", ", visibleParams.Params2));
                }
                Console.WriteLine("Required Params1: " + string.Join(", ", control.Value.Required[0].Params1));
                Console.WriteLine("Required Params2: " + string.Join(", ", control.Value.Required[0].Params2));
            }
        }
    }

    public class Params
    {
        public string Param1 { get; set; }
        public string Param2 { get; set; }
    }

    public class ControlParams
    {
        public List<string> Params1 { get; set; }
        public List<string> Params2 { get; set; }
    }

    public class Control
    {
        public List<ControlParams> Visible { get; set; }
        public List<ControlParams> Required { get; set; }
    }

    public class OnLoad
    {
        public Params Params { get; set; }
        public Dictionary<string, Control> Controls { get; set; }
    }

    public class RootObject
    {
        public OnLoad OnLoad { get; set; }
    }
}
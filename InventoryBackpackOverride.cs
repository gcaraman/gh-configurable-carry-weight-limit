using ModAPI;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConfigurableCarryWeight
{
    public class InventoryBackpackOverride : InventoryBackpack
    {
        private static readonly string ConfigFilePath = "Mods/WeightSettings.xml";
        private CarryWeight _carryWeight;

        protected override void Start()
        {
            base.Start();

            _carryWeight = new CarryWeight()
            {
                OverloadWeight = 60f,
                CriticalWeight = 80f,
                MaxWeight = 80f
            };

            Init();

            m_OverloadWeight = _carryWeight.OverloadWeight;
            m_CriticalWeight = _carryWeight.CriticalWeight;
            m_MaxWeight = _carryWeight.MaxWeight;
        }

        private void Init()
        {
            try
            {
                Log.Write($"Initializing ConfigurableCarryWeight Mod");

                if (!File.Exists(ConfigFilePath))
                {
                    Log.Write($"Creating configuration file ({ConfigFilePath})");
                    var xml = SerializeXml(_carryWeight);
                    File.WriteAllText(ConfigFilePath, xml);
                }
                else
                {
                    Log.Write($"Reading configuration file ({ConfigFilePath})");
                    var xml = File.ReadAllText(ConfigFilePath);
                    _carryWeight = DeserializeXml(xml);
                }
            }
            catch (Exception e)
            {
                Log.Write($"Unexpected exception during initialization: \n{e}");
            }
        }

        private CarryWeight DeserializeXml(string xml)
        {
            var serializer = new XmlSerializer(typeof(CarryWeight));

            using (var stream = new StringReader(xml))
            using (var reader = XmlReader.Create(stream))
            {
                return (CarryWeight)serializer.Deserialize(reader);
            }
        }

        private string SerializeXml(CarryWeight data)
        {
            var serializer = new XmlSerializer(typeof(CarryWeight));

            using (var stringWriter = new StringWriter())
            using (XmlTextWriter writer = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented })
            {
                serializer.Serialize(writer, data);
                return stringWriter.ToString();
            }
        }
    }
}

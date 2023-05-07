using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ConfigurableCarryWeight
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class CarryWeight
    {
        [XmlElement]
        public float OverloadWeight { get; set; }
        [XmlElement]
        public float CriticalWeight { get; set; }
        [XmlElement]
        public float MaxWeight { get; set; }
    }
}
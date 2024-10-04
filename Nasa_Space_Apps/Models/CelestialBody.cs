namespace Nasa_Space_Apps.Models
{
    public class CelestialBody
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Texture { get; set; }=string.Empty;
        public double Radius { get; set; } 
        public double Flattening { get; set; }
        public string orbitColor { get; set; } = string.Empty; 
        public bool LightEmitting { get; set; }
        public bool FetchElements { get; set; }
        public string Center { get; set; } = string.Empty;
        public string Search { get; set; } = string.Empty;
        //---------------------------------
        public string CustomOrbit { get; set; } = string.Empty;

        public string CustomRotation { get; set; } = string.Empty;
           
       
        public OrbitalElements? Elements { get; set; }
        public Rotation? Rotation { get; set; }
    }
}

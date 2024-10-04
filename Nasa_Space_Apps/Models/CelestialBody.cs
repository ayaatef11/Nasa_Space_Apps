namespace Nasa_Space_Apps.Models
{
    public class CelestialBody
    {
        public bool LightEmitting { get; set; }
        public string Search { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string CustomOrbit { get; set; }
        public string Texture { get; set; }
        public double Flattening { get; set; }
        public double Radius { get; set; }
        public string CustomRotation { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
        public bool FetchElements { get; set; }
        public string Center { get; set; }
        public OrbitalElements Elements { get; set; }
        public Rotation Rotation { get; set; }
    }
}

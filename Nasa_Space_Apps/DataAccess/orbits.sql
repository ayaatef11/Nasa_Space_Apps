--create database Majorbodies;
go
use Majorbodies
CREATE TABLE CelestialBodies (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    Symbol NVARCHAR(10),
    Type NVARCHAR(50),
    Texture NVARCHAR(255),
    Radius FLOAT,
    Flattening FLOAT,
    OrbitColor NVARCHAR(10),
    LightEmitting BIT,
    FetchElements BIT,
    Center NVARCHAR(100)
);


CREATE TABLE OrbitalElements (
    CelestialBodyId INT,
    ArgOfPeriapsis FLOAT,
    Period FLOAT,
    AscendingNode FLOAT,
    Eccentricity FLOAT,
    PeriapsisDistance FLOAT,
    TimeOfPeriapsis FLOAT,
    SemiMajorAxis FLOAT,
    ApoapsisDistance FLOAT,
    MeanAnomalyAtEpoch FLOAT,
    Epoch FLOAT,
    Inclination FLOAT,
    FOREIGN KEY (CelestialBodyId) REFERENCES CelestialBodies(Id)
);

CREATE TABLE Rotations (
    CelestialBodyId INT,
    MeridianAngle FLOAT,
    AscendingNode FLOAT,
    Type NVARCHAR(50),
    Period FLOAT,
    Inclination FLOAT,
    FOREIGN KEY (CelestialBodyId) REFERENCES CelestialBodies(Id)
);


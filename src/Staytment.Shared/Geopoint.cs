#if PLATFORM_DESKTOP

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BasicGeoposition = System.Device.Location.GeoCoordinate;

// ReSharper disable once CheckNamespace

namespace Windows.Devices.Geolocation
{
    public class Geopoint
    {
        public BasicGeoposition Position { get; private set; }

        public Geopoint(BasicGeoposition position)
        {
            Position = position;
        }
    }

    // From Metadata:
    /*
    [MarshalingBehavior(MarshalingType.Agile)]
    [Version(100859904)]
    public sealed class Geopoint : IGeoshape
    {
        // Summary:
        //     Create a geographic point object for the given position.
        //
        // Parameters:
        //   position:
        //     Create a geographic point object for the given position.
        public Geopoint(BasicGeoposition position);
        //
        // Summary:
        //     Create a geographic point object for the given position and altitude reference
        //     system.
        //
        // Parameters:
        //   position:
        //     Create a geographic point object for the given position.
        //
        //   altitudeReferenceSystem:
        //     The altitude reference system of the new point.
        public Geopoint(BasicGeoposition position, AltitudeReferenceSystem altitudeReferenceSystem);
        //
        // Summary:
        //     Create a geographic point object for the given position, altitude reference
        //     system, and spatial reference Id.
        //
        // Parameters:
        //   position:
        //     Create a geographic point object for the given position.
        //
        //   altitudeReferenceSystem:
        //     The altitude reference system of the new point.
        //
        //   spatialReferenceId:
        //     The spatial reference Id of the new point.
        public Geopoint(BasicGeoposition position, AltitudeReferenceSystem altitudeReferenceSystem, uint spatialReferenceId);

        // Summary:
        //     The altitude reference system of the geographic point.
        //
        // Returns:
        //     The altitude reference system of the geographic point.
        public AltitudeReferenceSystem AltitudeReferenceSystem { get; }
        //
        // Summary:
        //     The type of geographic shape.
        //
        // Returns:
        //     The type of geographic shape.
        public GeoshapeType GeoshapeType { get; }
        //
        // Summary:
        //     The position of a geographic point.
        //
        // Returns:
        //     The position of a geographic point.
        public BasicGeoposition Position { get; }
        //
        // Summary:
        //     The spatial reference identifier for the geographic point, corresponding
        //     to a spatial reference system based on the specific ellipsoid used for either
        //     flat-earth mapping or round-earth mapping.
        //
        // Returns:
        //     The spatial reference identifier for the geographic point, corresponding
        //     to a spatial reference system based on the specific ellipsoid used for either
        //     flat-earth mapping or round-earth mapping.
        public uint SpatialReferenceId { get; }
    }
    */
}

#endif
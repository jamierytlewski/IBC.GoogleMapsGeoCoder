IBC.GoogleMapsGeoCoder
======================

Simple Google Geocoding Web Services

Instructions
============
You may need to download JSON.net from NuGet to get this to work

using IBC.GoogleMapsGeocoder;

var location = Geocoder.Geocode('Address To Geocode');
location.lat = Latitude
location.lng = Longitude

TODO
====
Add in some checks for bad data or no results.

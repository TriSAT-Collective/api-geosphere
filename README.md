<h1 align="center">api-geosphere</h1>

<p align="center">
  <a href="#about">About</a> •
  <a href="#features">Features</a> •
  <a href="#building">Building</a> •
  <a href="#installation">Installation</a> •
  <a href="#usage">Usage</a> •
  <a href="#configuration">Configuration</a>
</p>

---

## About

The `api-geosphere` pulls data from the geosphere API and provides historical and forecast data.

## Features

- Pulls historical weather data and stores it in the MongoDB
- Pulls forecast weather data and stores it in the MongoDB

## Building

To build the project, use the following command:
```bash
dotnet build
```

## Installation

To install the project, clone the repository and navigate to the project directory:
```bash
git clone https://github.com/TriSAT-Collective/api-geosphere.git
```
```bash
cd api-geosphere
```

## Usage

To run the application, use the following command:
```bash
dotnet run
```

## Configuration

The project can be configured using the appsettings.json file. Below is an example configuration:
```JSON
{
  "GeoSphereApiClient": {
    "BaseUrl": "https://dataset.api.hub.geosphere.at/v1"
  },
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "smart_meter_db",
    "Collections": {
      "TimeseriesHistorical": "historical_data",
      "TimeseriesForecast": "forecast_data"
    }
  },
  "Misc": {
    "ContinuousPullnStore": true,
    "ContinuousPullnStoreIntervalMs": 3000,
    "OnceOffPullnStoreHours": 24,
    "PullnStoreStartTime": "2023-01-01T00:00:00Z"
  }
}
```

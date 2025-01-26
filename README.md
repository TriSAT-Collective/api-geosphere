<h1 align="center">smart-meter-simulation</h1>

<p align="center">
  <a href="#about">About</a> •
  <a href="#features">Features</a> •
  <a href="#dependencies">Dependencies</a> •
  <a href="#building">Building</a> •
  <a href="#installation">Installation</a> •
  <a href="#usage">Usage</a> •
  <a href="#configuration">Configuration</a>
</p>

---

## About

The `smart-meter-simulation` project simulates the behavior of smart meters, providing a platform to test and analyze energy consumption data. It is designed to help developers and researchers understand and optimize energy usage patterns.

## Features

- Simulates energy consumption data for smart meters.
- Provides APIs to retrieve and analyze the simulated data.
- Supports historical and forecasted timeseries data.
- Integrates with MongoDB for data storage.
- Configurable settings for simulation parameters.

## Building

To build the project, use the following command:
```bash
dotnet build
```

## Installation

To install the project, clone the repository and navigate to the project directory:
```bash
git clone https://github.com/yourusername/smart-meter-simulation.git
```
```bash
cd smart-meter-simulation
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

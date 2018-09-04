# Memores.Metrics
Metrics for .Net reporting to ElasticSearch
## Memores.Metrics.Wcf
### Description
This project contains some metrics for WCF services with reporting results to ElasticSearch with Grafana visualization.
### How to use
1. Install package
```cmd
Install-Package Memores.Metrics.Wcf -Version 0.0.2-alpha
```
2. Add to web.config behavior extension element for endpoint and service behavior
```xml
  <system.serviceModel>
    <extensions>
      <behaviorExtensions>
        <add name="elasticEndpointBehavior" type=" Memores.Metrics.Wcf.ExtentionElements.EndpointBehaviorExtentionElement, Memores.Metrics.Wcf, Version=1.0.0.0, Culture=neutral"/>
        <add name="elasticServiceBehavior" type=" Memores.Metrics.Wcf.ExtentionElements.ServiceBehaviorExtentionElement, Memores.Metrics.Wcf, Version=1.0.0.0, Culture=neutral"/>
      </behaviorExtensions>
    </extensions>
  </system.serviceModel>
```
3. Add endpoint and service behavior with ElasticSearch settings such as host, port and index name
```xml
    <behaviors>
      <endpointBehaviors>
        <behavior>
          <elasticEndpointBehavior hostname="http://localhost" port="9200" index="wcfsample" />
        </behavior>
      </endpointBehaviors>
      <serviceBehaviors>
        <behavior>          
          <elasticServiceBehavior hostname="http://localhost" port="9200" index="wcfsample" />
        </behavior>
      </serviceBehaviors>
    </behaviors>
```
4. Start your service and make requests.
### Visualization
1. Import to your Grafana dashboard from https://github.com/memores/Memores.Metrics/tree/master/visualization
2. Add data source and setup it in dashboard

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockPricesConsumer.localhost {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="localhost.IStockWebService")]
    public interface IStockWebService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockWebService/getDateRangeTest", ReplyAction="http://tempuri.org/IStockWebService/getDateRangeTestResponse")]
        System.DateTime[] getDateRangeTest(System.DateTime startDate, System.DateTime endDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockWebService/getDateRangeTest", ReplyAction="http://tempuri.org/IStockWebService/getDateRangeTestResponse")]
        System.Threading.Tasks.Task<System.DateTime[]> getDateRangeTestAsync(System.DateTime startDate, System.DateTime endDate);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStockWebServiceChannel : StockPricesConsumer.localhost.IStockWebService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StockWebServiceClient : System.ServiceModel.ClientBase<StockPricesConsumer.localhost.IStockWebService>, StockPricesConsumer.localhost.IStockWebService {
        
        public StockWebServiceClient() {
        }
        
        public StockWebServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StockWebServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockWebServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockWebServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.DateTime[] getDateRangeTest(System.DateTime startDate, System.DateTime endDate) {
            return base.Channel.getDateRangeTest(startDate, endDate);
        }
        
        public System.Threading.Tasks.Task<System.DateTime[]> getDateRangeTestAsync(System.DateTime startDate, System.DateTime endDate) {
            return base.Channel.getDateRangeTestAsync(startDate, endDate);
        }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBD3000Assignment2.PopularityService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PopularityService.PopularityTrackerSoap")]
    public interface PopularityTrackerSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VoteFor", ReplyAction="*")]
        void VoteFor(int trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VoteAgainst", ReplyAction="*")]
        void VoteAgainst(int trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetTrackVotes", ReplyAction="*")]
        int GetTrackVotes(int trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAlbumVotes", ReplyAction="*")]
        int GetAlbumVotes(int albumId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetArtistVotes", ReplyAction="*")]
        int GetArtistVotes(int artistId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetGenreVotes", ReplyAction="*")]
        int GetGenreVotes(int genreId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PopularityTrackerSoapChannel : WEBD3000Assignment2.PopularityService.PopularityTrackerSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PopularityTrackerSoapClient : System.ServiceModel.ClientBase<WEBD3000Assignment2.PopularityService.PopularityTrackerSoap>, WEBD3000Assignment2.PopularityService.PopularityTrackerSoap {
        
        public PopularityTrackerSoapClient() {
        }
        
        public PopularityTrackerSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PopularityTrackerSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PopularityTrackerSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PopularityTrackerSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void VoteFor(int trackId) {
            base.Channel.VoteFor(trackId);
        }
        
        public void VoteAgainst(int trackId) {
            base.Channel.VoteAgainst(trackId);
        }
        
        public int GetTrackVotes(int trackId) {
            return base.Channel.GetTrackVotes(trackId);
        }
        
        public int GetAlbumVotes(int albumId) {
            return base.Channel.GetAlbumVotes(albumId);
        }
        
        public int GetArtistVotes(int artistId) {
            return base.Channel.GetArtistVotes(artistId);
        }
        
        public int GetGenreVotes(int genreId) {
            return base.Channel.GetGenreVotes(genreId);
        }
    }
}

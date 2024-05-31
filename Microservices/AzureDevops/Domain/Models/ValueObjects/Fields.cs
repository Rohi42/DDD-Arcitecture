using AzureDevops.Domain.Aggregates.WIT;
using AzureDevops.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzureDevops.Domain.Models.ValueObjects
{

    public class Fields
    {

        [JsonProperty("System.AreaPath")]
        public string SystemAreaPath { get; set; }

        [JsonProperty("System.TeamProject")]
        public string SystemTeamProject { get; set; }

        [JsonProperty("System.IterationPath")]
        public string SystemIterationPath { get; set; }

        [JsonProperty ("System.WorkItemType")]
        public string SystemWorkItemType { get; set; }

        [JsonProperty("System.State")]
        public string SystemState { get; set; }

        [JsonProperty("System.Reason")]
        public string SystemReason { get; set; }

        [JsonProperty("System.CreatedDate")]
        public DateTime SystemCreatedDate { get; set; }

        [JsonProperty("System.CreatedBy")]
        public User SystemCreatedBy { get; set; }

        [JsonProperty("System.ChangedDate")]
        public DateTime SystemChangedDate { get; set; }

        [JsonProperty("System.ChangedBy")]
        public User SystemChangedBy { get; set; }

        [JsonProperty("System.CommentCount")]
        public int SystemCommentCount { get; set; }

        [JsonProperty("System.Title")]
        public string SystemTitle { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.StateChangeDate")]
        public DateTime CommonStateChangeDate { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public int CommonPriority { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Severity")]
        public string CommonSeverity { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.ValueArea")]
        public string CommonValueArea { get; set; }

        [JsonProperty("Microsoft.VSTS.TCM.ReproSteps")]
        public string TCMReproSteps { get; set; }

    }
}

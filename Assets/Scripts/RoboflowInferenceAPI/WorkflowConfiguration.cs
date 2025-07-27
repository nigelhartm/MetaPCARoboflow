using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the WorkflowConfiguration schema.
/// </summary>
public class WorkflowConfiguration
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the workflow_specification.
    /// </summary>
    [JsonProperty("workflow_specification")] 
    public object Workflow_Specification { get; set; }

    /// <summary>
    /// Gets or sets the workspace_name.
    /// </summary>
    [JsonProperty("workspace_name")] 
    public string Workspace_Name { get; set; }

    /// <summary>
    /// Gets or sets the workflow_id.
    /// </summary>
    [JsonProperty("workflow_id")] 
    public string Workflow_Id { get; set; }

    /// <summary>
    /// Gets or sets the image_input_name.
    /// </summary>
    [JsonProperty("image_input_name")] 
    public string Image_Input_Name { get; set; }

    /// <summary>
    /// Gets or sets the workflows_parameters.
    /// </summary>
    [JsonProperty("workflows_parameters")] 
    public object Workflows_Parameters { get; set; }

    /// <summary>
    /// Gets or sets the workflows_thread_pool_workers.
    /// </summary>
    [JsonProperty("workflows_thread_pool_workers")] 
    public int Workflows_Thread_Pool_Workers { get; set; }

    /// <summary>
    /// Gets or sets the cancel_thread_pool_tasks_on_exit.
    /// </summary>
    [JsonProperty("cancel_thread_pool_tasks_on_exit")] 
    public bool Cancel_Thread_Pool_Tasks_On_Exit { get; set; }

    /// <summary>
    /// Gets or sets the video_metadata_input_name.
    /// </summary>
    [JsonProperty("video_metadata_input_name")] 
    public string Video_Metadata_Input_Name { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="WorkflowConfiguration"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    public WorkflowConfiguration(string type)
    {
        this.Type = type;
    }
}
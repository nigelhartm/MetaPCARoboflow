using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the PythonCode schema.
/// </summary>
public class PythonCode
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; }

    /// <summary>
    /// Code of python function. Content should be properly formatted including indentations. Workflows execution engine is to create dynamic module with provided function - ensuring imports of the following symbols: [Any, List, Dict, Set, sv, np, math, time, json, os, requests, cv2, shapely, Batch, WorkflowImageData, BlockResult]. Expected signature is: def run(self, ... # parameters of manifest apart from name and type). Through self, one may access self._init_results which is dict returned by `init_code` if given.
    /// </summary>
    [JsonProperty("run_function_code")] 
    public string Run_Function_Code { get; set; }

    /// <summary>
    /// Name of the function shipped in `function_code`.
    /// </summary>
    [JsonProperty("run_function_name")] 
    public string Run_Function_Name { get; set; }

    /// <summary>
    /// Code of the function to perform initialisation of the block. It must be parameter-free function with signature `def init() -> Dict[str, Any]` setting self._init_results on dynamic class initialisation
    /// </summary>
    [JsonProperty("init_function_code")] 
    public string Init_Function_Code { get; set; }

    /// <summary>
    /// Name of init_code function.
    /// </summary>
    [JsonProperty("init_function_name")] 
    public string Init_Function_Name { get; set; }

    /// <summary>
    /// List of additional imports required to run the code
    /// </summary>
    [JsonProperty("imports")] 
    public List<string> Imports { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="PythonCode"/>.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="run_Function_Code">The run_Function_Code.</param>
    public PythonCode(string type, string run_Function_Code)
    {
        this.Type = type;
        this.Run_Function_Code = run_Function_Code;
    }
}
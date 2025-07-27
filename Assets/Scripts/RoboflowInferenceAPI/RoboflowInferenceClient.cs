using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class RoboflowInferenceClient
{
    private string baseUrl = "http://localhost:9001";
    private string global_api_Key = "";

    public void setBaseUrl(string url)
    {
        baseUrl = url;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RoboflowInferenceClient"/> class.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="baseURL"></param>
    public RoboflowInferenceClient(string api_key, string baseURL = null)
    {
        if (!string.IsNullOrEmpty(api_key))
        {
            global_api_Key = api_key;
            Debug.Log("API Key set to: " + global_api_Key[global_api_Key.Length - 4] + "****");
        }
        else {
            Debug.LogError("No valid API Key provided.");
        }

        if (!string.IsNullOrEmpty(baseURL))
        {
            setBaseUrl(baseURL);
            Debug.Log("Base URL set to: " + baseUrl);
        }
        else
        {
            Debug.Log("No valid Base URL provided, using default: " + baseUrl);
        }
    }

    /// <summary>
    /// Endpoint that serves Prometheus metrics.
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator MetricsGET(object request, Action<object> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/metrics";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<object>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Device Stats
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator DeviceStatsGET(object request, Action<object> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/device/stats";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<object>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Get the server name and version number
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InfoGET(object request, Action<ServerVersionInfo> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/info";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ServerVersionInfo>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Get the ID of each loaded model
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator ModelRegistryGET(object request, Action<ModelsDescriptions> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/model/registry";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ModelsDescriptions>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Load the model with the given model ID
    /// </summary>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator ModelAdd(AddModelRequest request, Action<ModelsDescriptions> onSuccess, Action<string> onError, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/model/add" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ModelsDescriptions>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Remove the model with the given model ID
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator ModelRemove(ClearModelRequest request, Action<ModelsDescriptions> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/model/remove";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ModelsDescriptions>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Remove all loaded models
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator ModelClear(object request, Action<ModelsDescriptions> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/model/clear";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ModelsDescriptions>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run inference with the specified object detection model
    /// </summary>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferObjectDetection(ObjectDetectionInferenceRequest request, Action<ObjectDetectionInferenceResponse> onSuccess, Action<string> onError, string countinference = null, string service_secret = null)
    {
        request.Api_Key = global_api_Key; // Ensure the API key is set for the request
        var query = new List<string>();
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/infer/object_detection" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ObjectDetectionInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run inference with the specified instance segmentation model
    /// </summary>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferInstanceSegmentation(InstanceSegmentationInferenceRequest request, Action<InstanceSegmentationInferenceResponse> onSuccess, Action<string> onError, string countinference = null, string service_secret = null)
    {
        request.Api_Key = global_api_Key; // Ensure the API key is set for the request
        var query = new List<string>();
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/infer/instance_segmentation" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<InstanceSegmentationInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run inference with the specified classification model
    /// </summary>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferClassification(ClassificationInferenceRequest request, Action<ClassificationInferenceResponse> onSuccess, Action<string> onError, string countinference = null, string service_secret = null)
    {
        request.Api_Key = global_api_Key; // Ensure the API key is set for the request
        var query = new List<string>();
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/infer/classification" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ClassificationInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run inference with the specified keypoints detection model
    /// </summary>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferKeypointsDetection(KeypointsDetectionInferenceRequest request, Action<KeypointsDetectionInferenceResponse> onSuccess, Action<string> onError, string countinference = null, string service_secret = null)
    {
        request.Api_Key = global_api_Key; // Ensure the API key is set for the request
        var query = new List<string>();
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/infer/keypoints_detection" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        Debug.Log("InferKeypointsDetection endpoint: " + endpoint);
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            Debug.Log("InferKeypointsDetection bodyRaw: " + Encoding.UTF8.GetString(bodyRaw));
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<KeypointsDetectionInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run inference with the specified large multi-modal model
    /// </summary>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferLmm(LMMInferenceRequest request, Action<List<LMMInferenceResponse>> onSuccess, Action<string> onError, string countinference = null, string service_secret = null)
    {
        request.Api_Key = global_api_Key; // Ensure the API key is set for the request
        var query = new List<string>();
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/infer/lmm" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<List<LMMInferenceResponse>>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Checks Roboflow API for workflow definition, once acquired - describes workflow inputs and outputs
    /// </summary>
    /// <param name="workspace_name">The workspace_name parameter.</param>
    /// <param name="workflow_id">The workflow_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator WorkflowsDescribeInterface(string workspace_name, string workflow_id, PredefinedWorkflowDescribeInterfaceRequest request, Action<DescribeInterfaceResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/" + workspace_name + "/workflows/" + workflow_id + "/describe_interface";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<DescribeInterfaceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Parses workflow definition and retrieves describes inputs and outputs
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator WorkflowsDescribeInterface(WorkflowSpecificationDescribeInterfaceRequest request, Action<DescribeInterfaceResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/workflows/describe_interface";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<DescribeInterfaceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Checks Roboflow API for workflow definition, once acquired - parses and executes injecting runtime parameters from request body. This endpoint is deprecated and will be removed end of Q2 2024
    /// </summary>
    /// <param name="workspace_name">The workspace_name parameter.</param>
    /// <param name="workflow_id">The workflow_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferWorkflows(string workspace_name, string workflow_id, PredefinedWorkflowInferenceRequest request, Action<WorkflowInferenceResponse> onSuccess, Action<string> onError)
    {
        request.Api_Key = global_api_Key; // Ensure the API key is set for the request
        string endpoint = $"{baseUrl}/infer/workflows/" + workspace_name + "/" + workflow_id + "";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<WorkflowInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Checks Roboflow API for workflow definition, once acquired - parses and executes injecting runtime parameters from request body
    /// </summary>
    /// <param name="workspace_name">The workspace_name parameter.</param>
    /// <param name="workflow_id">The workflow_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator Workflows(string workspace_name, string workflow_id, PredefinedWorkflowInferenceRequest request, Action<WorkflowInferenceResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/" + workspace_name + "/workflows/" + workflow_id + "";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<WorkflowInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Parses and executes workflow specification, injecting runtime parameters from request body. This endpoint is deprecated and will be removed end of Q2 2024.
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferWorkflows(WorkflowSpecificationInferenceRequest request, Action<WorkflowInferenceResponse> onSuccess, Action<string> onError)
    {
        request.Api_Key = global_api_Key; // Ensure the API key is set for the request
        string endpoint = $"{baseUrl}/infer/workflows";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<WorkflowInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Parses and executes workflow specification, injecting runtime parameters from request body.
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator WorkflowsRun(WorkflowSpecificationInferenceRequest request, Action<WorkflowInferenceResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/workflows/run";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<WorkflowInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Returns available Execution Engine versions sorted from oldest to newest
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator WorkflowsExecutionEngineVersionsGET(object request, Action<ExecutionEngineVersions> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/workflows/execution_engine/versions";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ExecutionEngineVersions>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Endpoint provides detailed information about workflows building blocks that are accessible in the inference server. This information could be used to programmatically build / display workflows.
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator WorkflowsBlocksDescribeGET(object request, Action<WorkflowsBlocksDescription> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/workflows/blocks/describe";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<WorkflowsBlocksDescription>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Endpoint provides detailed information about workflows building blocks that are accessible in the inference server. This information could be used to programmatically build / display workflows. Additionally - in request body one can specify list of dynamic blocks definitions which will be transformed into blocks and used to generate schemas and definitions of connections
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator WorkflowsBlocksDescribe(object request, Action<WorkflowsBlocksDescription> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/workflows/blocks/describe";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<WorkflowsBlocksDescription>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Endpoint to fetch the schema of all available blocks. This information can be used to validate workflow definitions and suggest syntax in the JSON editor.
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator WorkflowsDefinitionSchemaGET(object request, Action<WorkflowsBlocksSchemaDescription> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/workflows/definition/schema";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<WorkflowsBlocksSchemaDescription>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Endpoint to be used when step outputs can be discovered only after filling manifest with data.
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator WorkflowsBlocksDynamicOutputs(object request, Action<List<OutputDefinition>> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/workflows/blocks/dynamic_outputs";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<List<OutputDefinition>>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Endpoint provides a way to check validity of JSON workflow definition.
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator WorkflowsValidate(object request, Action<WorkflowValidationStatus> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/workflows/validate";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<WorkflowValidationStatus>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// [EXPERIMENTAL] Listing all active InferencePipelines processing videos
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferencePipelinesListGET(object request, Action<ListPipelinesResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/inference_pipelines/list";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ListPipelinesResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// [EXPERIMENTAL] Get status of InferencePipeline
    /// </summary>
    /// <param name="pipeline_id">The pipeline_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferencePipelinesStatusGET(string pipeline_id, object request, Action<InferencePipelineStatusResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/inference_pipelines/" + pipeline_id + "/status";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<InferencePipelineStatusResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// [EXPERIMENTAL] Starts new InferencePipeline
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferencePipelinesInitialise(InitialisePipelinePayload request, Action<CommandResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/inference_pipelines/initialise";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<CommandResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// [EXPERIMENTAL] Establishes WebRTC peer connection and starts new InferencePipeline consuming video track
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferencePipelinesInitialiseWebrtc(InitialiseWebRTCPipelinePayload request, Action<InitializeWebRTCPipelineResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/inference_pipelines/initialise_webrtc";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<InitializeWebRTCPipelineResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// [EXPERIMENTAL] Pauses the InferencePipeline
    /// </summary>
    /// <param name="pipeline_id">The pipeline_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferencePipelinesPause(string pipeline_id, object request, Action<CommandResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/inference_pipelines/" + pipeline_id + "/pause";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<CommandResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// [EXPERIMENTAL] Resumes the InferencePipeline
    /// </summary>
    /// <param name="pipeline_id">The pipeline_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferencePipelinesResume(string pipeline_id, object request, Action<CommandResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/inference_pipelines/" + pipeline_id + "/resume";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<CommandResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// [EXPERIMENTAL] Terminates the InferencePipeline
    /// </summary>
    /// <param name="pipeline_id">The pipeline_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferencePipelinesTerminate(string pipeline_id, object request, Action<CommandResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/inference_pipelines/" + pipeline_id + "/terminate";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<CommandResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// [EXPERIMENTAL] Consumes InferencePipeline result
    /// </summary>
    /// <param name="pipeline_id">The pipeline_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferencePipelinesConsumeGET(string pipeline_id, object request, Action<ConsumePipelineResponse> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/inference_pipelines/" + pipeline_id + "/consume";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ConsumePipelineResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the Open AI CLIP model to embed image data.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator ClipEmbedImage(ClipImageEmbeddingRequest request, Action<ClipEmbeddingResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/clip/embed_image" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ClipEmbeddingResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the Open AI CLIP model to embed text data.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator ClipEmbedText(ClipTextEmbeddingRequest request, Action<ClipEmbeddingResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/clip/embed_text" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ClipEmbeddingResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the Open AI CLIP model to compute similarity scores.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator ClipCompare(ClipCompareRequest request, Action<ClipCompareResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/clip/compare" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ClipCompareResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the Meta Perception Encoder model to embed image data.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator PerceptionEncoderEmbedImage(PerceptionEncoderImageEmbeddingRequest request, Action<PerceptionEncoderEmbeddingResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/perception_encoder/embed_image" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<PerceptionEncoderEmbeddingResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the Meta Perception Encoder model to embed text data.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator PerceptionEncoderEmbedText(PerceptionEncoderTextEmbeddingRequest request, Action<PerceptionEncoderEmbeddingResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/perception_encoder/embed_text" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<PerceptionEncoderEmbeddingResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the Meta Perception Encoder model to compute similarity scores.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator PerceptionEncoderCompare(PerceptionEncoderCompareRequest request, Action<PerceptionEncoderCompareResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/perception_encoder/compare" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<PerceptionEncoderCompareResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the Grounding DINO zero-shot object detection model.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator GroundingDinoInfer(GroundingDINOInferenceRequest request, Action<ObjectDetectionInferenceResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/grounding_dino/infer" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ObjectDetectionInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the YOLO-World zero-shot object detection model.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator YoloWorldInfer(YOLOWorldInferenceRequest request, Action<ObjectDetectionInferenceResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/yolo_world/infer" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ObjectDetectionInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the DocTR OCR model to retrieve text in an image.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator DoctrOcr(DoctrOCRInferenceRequest request, Action<OCRInferenceResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/doctr/ocr" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<OCRInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the Meta AI Segmant Anything Model to embed image data.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator SamEmbedImage(SamEmbeddingRequest request, Action<SamEmbeddingResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/sam/embed_image" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<SamEmbeddingResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the Meta AI Segmant Anything Model to generate segmenations for image data.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator SamSegmentImage(SamSegmentationRequest request, Action<SamSegmentationResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/sam/segment_image" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<SamSegmentationResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the Meta AI Segment Anything 2 Model to embed image data.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator Sam2EmbedImage(Sam2EmbeddingRequest request, Action<Sam2EmbeddingResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/sam2/embed_image" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<Sam2EmbeddingResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the Meta AI Segment Anything 2 Model to generate segmenations for image data.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator Sam2SegmentImage(Sam2SegmentationRequest request, Action<Sam2SegmentationResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/sam2/segment_image" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<Sam2SegmentationResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the google owlv2 model to few-shot object detect
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator Owlv2Infer(OwlV2InferenceRequest request, Action<ObjectDetectionInferenceResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/owlv2/infer" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<ObjectDetectionInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the gaze detection model to detect gaze.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator GazeGazeDetection(GazeDetectionInferenceRequest request, Action<List<GazeDetectionInferenceResponse>> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/gaze/gaze_detection" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<List<GazeDetectionInferenceResponse>>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the depth estimation model to generate a depth map.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator InferDepthEstimation(DepthEstimationRequest request, Action<DepthEstimationResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        request.Api_Key = global_api_Key; // Ensure the API key is set for the request
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/infer/depth-estimation" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<DepthEstimationResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Run the TrOCR model to retrieve text in an image.
    /// </summary>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator OcrTrocr(TrOCRInferenceRequest request, Action<OCRInferenceResponse> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/ocr/trocr" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<OCRInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Starts a jupyter lab server for running development code
    /// </summary>
    /// <param name="browserless">The browserless parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator NotebookStartGET(object request, Action<object> onSuccess, Action<string> onError, string browserless = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(browserless)) query.Add("browserless=" + UnityWebRequest.EscapeURL(browserless));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/notebook/start" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<object>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Loads the list of Workflows available for editing
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator BuildGET(object request, Action<object> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/build";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<object>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Loads a specific workflow for editing
    /// </summary>
    /// <param name="workflow_id">The workflow_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator BuildEditGET(string workflow_id, object request, Action<object> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/build/edit/" + workflow_id + "";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<object>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Returns JSON info about all .json files in {MODEL_CACHE_DIR}/workflow/local.
    /// Protected by CSRF token check.
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator BuildApiGET(object request, Action<object> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/build/api";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<object>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Return JSON for workflow_id.json, or 404 if missing.
    /// </summary>
    /// <param name="workflow_id">The workflow_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator BuildApiGET(string workflow_id, object request, Action<object> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/build/api/" + workflow_id + "";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<object>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Create or overwrite a workflow's JSON file on disk.
    /// Protected by CSRF token check.
    /// </summary>
    /// <param name="workflow_id">The workflow_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator BuildApi(string workflow_id, object request, Action<object> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/build/api/" + workflow_id + "";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<object>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Delete a workflow's JSON file from disk.
    /// Protected by CSRF token check.
    /// </summary>
    /// <param name="workflow_id">The workflow_id parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator BuildApiDELETE(string workflow_id, object request, Action<object> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/build/api/" + workflow_id + "";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "DELETE"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<object>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Legacy inference endpoint for object detection, instance segmentation, and classification.
    /// 
    /// Args:
    ///     background_tasks: (BackgroundTasks) pool of fastapi background tasks
    ///     dataset_id (str): ID of a Roboflow dataset corresponding to the model to use for inference OR workspace ID
    ///     version_id (str): ID of a Roboflow dataset version corresponding to the model to use for inference OR model ID
    ///     api_key (Optional[str], default None): Roboflow API Key passed to the model during initialization for artifact retrieval.
    ///     # Other parameters described in the function signature...
    /// 
    /// Returns:
    ///     Union[InstanceSegmentationInferenceResponse, KeypointsDetectionInferenceRequest, ObjectDetectionInferenceResponse, ClassificationInferenceResponse, MultiLabelClassificationInferenceResponse, Any]: The response containing the inference results.
    /// </summary>
    /// <param name="dataset_id">The dataset_id parameter.</param>
    /// <param name="version_id">The version_id parameter.</param>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="confidence">The confidence parameter.</param>
    /// <param name="keypoint_confidence">The keypoint_confidence parameter.</param>
    /// <param name="format">The format parameter.</param>
    /// <param name="image">The image parameter.</param>
    /// <param name="image_type">The image_type parameter.</param>
    /// <param name="labels">The labels parameter.</param>
    /// <param name="mask_decode_mode">The mask_decode_mode parameter.</param>
    /// <param name="tradeoff_factor">The tradeoff_factor parameter.</param>
    /// <param name="max_detections">The max_detections parameter.</param>
    /// <param name="overlap">The overlap parameter.</param>
    /// <param name="stroke">The stroke parameter.</param>
    /// <param name="disable_preproc_auto_orient">The disable_preproc_auto_orient parameter.</param>
    /// <param name="disable_preproc_contrast">The disable_preproc_contrast parameter.</param>
    /// <param name="disable_preproc_grayscale">The disable_preproc_grayscale parameter.</param>
    /// <param name="disable_preproc_static_crop">The disable_preproc_static_crop parameter.</param>
    /// <param name="disable_active_learning">The disable_active_learning parameter.</param>
    /// <param name="active_learning_target_dataset">The active_learning_target_dataset parameter.</param>
    /// <param name="source">The source parameter.</param>
    /// <param name="source_info">The source_info parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator POST(string dataset_id, string version_id, object request, Action<InstanceSegmentationInferenceResponse> onSuccess, Action<string> onError, string api_key = null, string confidence = null, string keypoint_confidence = null, string format = null, string image = null, string image_type = null, string labels = null, string mask_decode_mode = null, string tradeoff_factor = null, string max_detections = null, string overlap = null, string stroke = null, string disable_preproc_auto_orient = null, string disable_preproc_contrast = null, string disable_preproc_grayscale = null, string disable_preproc_static_crop = null, string disable_active_learning = null, string active_learning_target_dataset = null, string source = null, string source_info = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(confidence)) query.Add("confidence=" + UnityWebRequest.EscapeURL(confidence));
        if (!string.IsNullOrEmpty(keypoint_confidence)) query.Add("keypoint_confidence=" + UnityWebRequest.EscapeURL(keypoint_confidence));
        if (!string.IsNullOrEmpty(format)) query.Add("format=" + UnityWebRequest.EscapeURL(format));
        if (!string.IsNullOrEmpty(image)) query.Add("image=" + UnityWebRequest.EscapeURL(image));
        if (!string.IsNullOrEmpty(image_type)) query.Add("image_type=" + UnityWebRequest.EscapeURL(image_type));
        if (!string.IsNullOrEmpty(labels)) query.Add("labels=" + UnityWebRequest.EscapeURL(labels));
        if (!string.IsNullOrEmpty(mask_decode_mode)) query.Add("mask_decode_mode=" + UnityWebRequest.EscapeURL(mask_decode_mode));
        if (!string.IsNullOrEmpty(tradeoff_factor)) query.Add("tradeoff_factor=" + UnityWebRequest.EscapeURL(tradeoff_factor));
        if (!string.IsNullOrEmpty(max_detections)) query.Add("max_detections=" + UnityWebRequest.EscapeURL(max_detections));
        if (!string.IsNullOrEmpty(overlap)) query.Add("overlap=" + UnityWebRequest.EscapeURL(overlap));
        if (!string.IsNullOrEmpty(stroke)) query.Add("stroke=" + UnityWebRequest.EscapeURL(stroke));
        if (!string.IsNullOrEmpty(disable_preproc_auto_orient)) query.Add("disable_preproc_auto_orient=" + UnityWebRequest.EscapeURL(disable_preproc_auto_orient));
        if (!string.IsNullOrEmpty(disable_preproc_contrast)) query.Add("disable_preproc_contrast=" + UnityWebRequest.EscapeURL(disable_preproc_contrast));
        if (!string.IsNullOrEmpty(disable_preproc_grayscale)) query.Add("disable_preproc_grayscale=" + UnityWebRequest.EscapeURL(disable_preproc_grayscale));
        if (!string.IsNullOrEmpty(disable_preproc_static_crop)) query.Add("disable_preproc_static_crop=" + UnityWebRequest.EscapeURL(disable_preproc_static_crop));
        if (!string.IsNullOrEmpty(disable_active_learning)) query.Add("disable_active_learning=" + UnityWebRequest.EscapeURL(disable_active_learning));
        if (!string.IsNullOrEmpty(active_learning_target_dataset)) query.Add("active_learning_target_dataset=" + UnityWebRequest.EscapeURL(active_learning_target_dataset));
        if (!string.IsNullOrEmpty(source)) query.Add("source=" + UnityWebRequest.EscapeURL(source));
        if (!string.IsNullOrEmpty(source_info)) query.Add("source_info=" + UnityWebRequest.EscapeURL(source_info));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/" + dataset_id + "/" + version_id + "" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<InstanceSegmentationInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Legacy inference endpoint for object detection, instance segmentation, and classification.
    /// 
    /// Args:
    ///     background_tasks: (BackgroundTasks) pool of fastapi background tasks
    ///     dataset_id (str): ID of a Roboflow dataset corresponding to the model to use for inference OR workspace ID
    ///     version_id (str): ID of a Roboflow dataset version corresponding to the model to use for inference OR model ID
    ///     api_key (Optional[str], default None): Roboflow API Key passed to the model during initialization for artifact retrieval.
    ///     # Other parameters described in the function signature...
    /// 
    /// Returns:
    ///     Union[InstanceSegmentationInferenceResponse, KeypointsDetectionInferenceRequest, ObjectDetectionInferenceResponse, ClassificationInferenceResponse, MultiLabelClassificationInferenceResponse, Any]: The response containing the inference results.
    /// </summary>
    /// <param name="dataset_id">The dataset_id parameter.</param>
    /// <param name="version_id">The version_id parameter.</param>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="confidence">The confidence parameter.</param>
    /// <param name="keypoint_confidence">The keypoint_confidence parameter.</param>
    /// <param name="format">The format parameter.</param>
    /// <param name="image">The image parameter.</param>
    /// <param name="image_type">The image_type parameter.</param>
    /// <param name="labels">The labels parameter.</param>
    /// <param name="mask_decode_mode">The mask_decode_mode parameter.</param>
    /// <param name="tradeoff_factor">The tradeoff_factor parameter.</param>
    /// <param name="max_detections">The max_detections parameter.</param>
    /// <param name="overlap">The overlap parameter.</param>
    /// <param name="stroke">The stroke parameter.</param>
    /// <param name="disable_preproc_auto_orient">The disable_preproc_auto_orient parameter.</param>
    /// <param name="disable_preproc_contrast">The disable_preproc_contrast parameter.</param>
    /// <param name="disable_preproc_grayscale">The disable_preproc_grayscale parameter.</param>
    /// <param name="disable_preproc_static_crop">The disable_preproc_static_crop parameter.</param>
    /// <param name="disable_active_learning">The disable_active_learning parameter.</param>
    /// <param name="active_learning_target_dataset">The active_learning_target_dataset parameter.</param>
    /// <param name="source">The source parameter.</param>
    /// <param name="source_info">The source_info parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator GET(string dataset_id, string version_id, object request, Action<InstanceSegmentationInferenceResponse> onSuccess, Action<string> onError, string api_key = null, string confidence = null, string keypoint_confidence = null, string format = null, string image = null, string image_type = null, string labels = null, string mask_decode_mode = null, string tradeoff_factor = null, string max_detections = null, string overlap = null, string stroke = null, string disable_preproc_auto_orient = null, string disable_preproc_contrast = null, string disable_preproc_grayscale = null, string disable_preproc_static_crop = null, string disable_active_learning = null, string active_learning_target_dataset = null, string source = null, string source_info = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(confidence)) query.Add("confidence=" + UnityWebRequest.EscapeURL(confidence));
        if (!string.IsNullOrEmpty(keypoint_confidence)) query.Add("keypoint_confidence=" + UnityWebRequest.EscapeURL(keypoint_confidence));
        if (!string.IsNullOrEmpty(format)) query.Add("format=" + UnityWebRequest.EscapeURL(format));
        if (!string.IsNullOrEmpty(image)) query.Add("image=" + UnityWebRequest.EscapeURL(image));
        if (!string.IsNullOrEmpty(image_type)) query.Add("image_type=" + UnityWebRequest.EscapeURL(image_type));
        if (!string.IsNullOrEmpty(labels)) query.Add("labels=" + UnityWebRequest.EscapeURL(labels));
        if (!string.IsNullOrEmpty(mask_decode_mode)) query.Add("mask_decode_mode=" + UnityWebRequest.EscapeURL(mask_decode_mode));
        if (!string.IsNullOrEmpty(tradeoff_factor)) query.Add("tradeoff_factor=" + UnityWebRequest.EscapeURL(tradeoff_factor));
        if (!string.IsNullOrEmpty(max_detections)) query.Add("max_detections=" + UnityWebRequest.EscapeURL(max_detections));
        if (!string.IsNullOrEmpty(overlap)) query.Add("overlap=" + UnityWebRequest.EscapeURL(overlap));
        if (!string.IsNullOrEmpty(stroke)) query.Add("stroke=" + UnityWebRequest.EscapeURL(stroke));
        if (!string.IsNullOrEmpty(disable_preproc_auto_orient)) query.Add("disable_preproc_auto_orient=" + UnityWebRequest.EscapeURL(disable_preproc_auto_orient));
        if (!string.IsNullOrEmpty(disable_preproc_contrast)) query.Add("disable_preproc_contrast=" + UnityWebRequest.EscapeURL(disable_preproc_contrast));
        if (!string.IsNullOrEmpty(disable_preproc_grayscale)) query.Add("disable_preproc_grayscale=" + UnityWebRequest.EscapeURL(disable_preproc_grayscale));
        if (!string.IsNullOrEmpty(disable_preproc_static_crop)) query.Add("disable_preproc_static_crop=" + UnityWebRequest.EscapeURL(disable_preproc_static_crop));
        if (!string.IsNullOrEmpty(disable_active_learning)) query.Add("disable_active_learning=" + UnityWebRequest.EscapeURL(disable_active_learning));
        if (!string.IsNullOrEmpty(active_learning_target_dataset)) query.Add("active_learning_target_dataset=" + UnityWebRequest.EscapeURL(active_learning_target_dataset));
        if (!string.IsNullOrEmpty(source)) query.Add("source=" + UnityWebRequest.EscapeURL(source));
        if (!string.IsNullOrEmpty(source_info)) query.Add("source_info=" + UnityWebRequest.EscapeURL(source_info));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/" + dataset_id + "/" + version_id + "" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<InstanceSegmentationInferenceResponse>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Clears the model cache.
    /// 
    /// This endpoint provides a way to clear the cache of loaded models.
    /// 
    /// Returns:
    ///     str: A string indicating that the cache has been cleared.
    /// </summary>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator ClearCacheGET(object request, Action<object> onSuccess, Action<string> onError)
    {
        string endpoint = $"{baseUrl}/clear_cache";
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<object>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

    /// <summary>
    /// Starts a model inference session.
    /// 
    /// This endpoint initializes and starts an inference session for the specified model version.
    /// 
    /// Args:
    ///     dataset_id (str): ID of a Roboflow dataset corresponding to the model.
    ///     version_id (str): ID of a Roboflow dataset version corresponding to the model.
    ///     api_key (str, optional): Roboflow API Key for artifact retrieval.
    ///     countinference (Optional[bool]): Whether to count inference or not.
    ///     service_secret (Optional[str]): The service secret for the request.
    /// 
    /// Returns:
    ///     JSONResponse: A response object containing the status and a success message.
    /// </summary>
    /// <param name="dataset_id">The dataset_id parameter.</param>
    /// <param name="version_id">The version_id parameter.</param>
    /// <param name="api_key">The api_key parameter.</param>
    /// <param name="countinference">The countinference parameter.</param>
    /// <param name="service_secret">The service_secret parameter.</param>
    /// <param name="request">The request body payload.</param>
    /// <param name="onSuccess">Callback when request succeeds.</param>
    /// <param name="onError">Callback when request fails.</param>
    public IEnumerator StartGET(string dataset_id, string version_id, object request, Action<object> onSuccess, Action<string> onError, string api_key = null, string countinference = null, string service_secret = null)
    {
        var query = new List<string>();
        if (!string.IsNullOrEmpty(api_key)) query.Add("api_key=" + UnityWebRequest.EscapeURL(api_key));
        if (!string.IsNullOrEmpty(countinference)) query.Add("countinference=" + UnityWebRequest.EscapeURL(countinference));
        if (!string.IsNullOrEmpty(service_secret)) query.Add("service_secret=" + UnityWebRequest.EscapeURL(service_secret));
        string queryString = string.Join("&", query);
        string endpoint = $"{baseUrl}/start/" + dataset_id + "/" + version_id + "" + (queryString.Length > 0 ? "?" + queryString : "");
        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        });
        using (UnityWebRequest req = new UnityWebRequest(endpoint, "GET"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result == UnityWebRequest.Result.Success)
            {
                var res = JsonConvert.DeserializeObject<object>(req.downloadHandler.text);
                onSuccess?.Invoke(res);
            }
            else onError?.Invoke("Request failed: " + req.error);
        }
    }

}
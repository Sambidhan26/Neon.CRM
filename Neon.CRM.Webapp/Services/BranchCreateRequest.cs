namespace Neon.CRM.Webapp.Services;

public class BranchCreateRequest
{
    public Branch branch { get; set; }
    public Annotation_Value annotation_value { get; set; }
    public Endpoint[] endpoints { get; set; }
}

public class Branch
{
    public string parent_id { get; set; }
    public string name { get; set; }
    public string init_source { get; set; }
}

public class Annotation_Value
{
    public string newKey { get; set; }
}

public class Endpoint
{
    public string type { get; set; }
}



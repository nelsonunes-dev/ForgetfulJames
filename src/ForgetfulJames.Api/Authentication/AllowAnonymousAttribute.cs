namespace ForgetfulJames.Api.Authentication
{
    /// <summary>
    /// Allow public access to specific action methods.
    /// Reason I created a custom attribute? 
    /// 1. Consistency with other custom auto classes in the project.
    /// 2. To avoid ambiguous reference errors between namespaces.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute { }
}

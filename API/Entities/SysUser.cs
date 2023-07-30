namespace API.Entities;

public class SysUser
{
    public int Id { get; set; }
    public string UserName { get; set; }


    public string Test()
    {
        IEnumerable<string> test = new List<string>();
        var test2 = new SysUser()
        {
            Id = 1,
            UserName = "test"
        };
        return "";
    }
}
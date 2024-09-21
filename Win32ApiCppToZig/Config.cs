namespace Win32ApiCppToZig;

public class Config
{
    public List<TypeMap> Types { get => _types; set => _types = value; }

    List<TypeMap> _types;

    public Config()
    {
        _types = [];
    }

    public Dictionary<string, string> GetMap()
    {
        Dictionary<string, string> temp = [];

        for (int i = 0; i < _types.Count; i++)
        {
            temp.Add(_types[i].InType, Types[i].OutType);
        }
        return temp;
    }
}

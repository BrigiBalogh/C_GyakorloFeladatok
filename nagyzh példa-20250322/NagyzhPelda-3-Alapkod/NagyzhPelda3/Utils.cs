using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace NagyzhPelda3;

public static class Utils
{

    public static List<T> LoadFromJson<T>(string filename)
    {
        string json = File.ReadAllText(filename);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }
}

using Microsoft.AspNetCore.Mvc;

public class ASDF
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        var app = builder.Build();

var jsonData = "{ \"type\": \"TEMP\", \"value\": 22 }";
                var p = System.Text.Json.JsonSerializer.Deserialize<Measurements>(jsonData);

//Console.WriteLine(p.type+":"+p.value);
        app.MapPost("/api/news", ([FromBody] Measurements measurements) =>
        {
            try {
                Console.WriteLine("=======");
                var a= System.Text.Json.JsonSerializer.Serialize(measurements);
                Console.WriteLine(a);
//                return a;
//                Console.WriteLine(request.measurements.Count);
//            foreach(var kv in request.measurements)
//                Console.WriteLine(kv.type +"="+kv.value);
//            return new MeasurementScores().LookupScore(request);
            } catch(Exception e) {
                Console.WriteLine(e.ToString());
            }
return 42;
        });

        app.Run();
    }
}

namespace DapperMinimalApi;

public class PeopleHandler
{
   public static void MapEndpoints(IEndpointRouteBuilder endpoints)
   {
       endpoints.MapGet("/api/people", GetList);
   }

   private static IResult GetList()
   {
      return Results.Ok("Getting a list of people  ");
   }
}
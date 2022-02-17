using Microsoft.AspNetCore.Http;
using System;

namespace Back_End.Models.Services
{
  public class PersonSessionService
  {
    private static readonly IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
    private static ISession Session => httpContextAccessor.HttpContext.Session;

    public static string SortOrderInSesson
    {
      get => Session.GetString("PersonSortOrder") ?? "";
      set => Session.SetString("PersonSortOrder", value);
    }

    public static string NameSortParamInSession
    {
      get => Session.GetString("PersonNameSortParam") ?? "name";
      set => Session.SetString("PersonNameSortParam", value);
    }

    public static string CitySortParamInSession
    {
      get => Session.GetString("PersonCitySortParam") ?? "city";
      set => Session.SetString("PersonCitySortParam", value);
    }

    public static string CountrySortParamInSession
    {
      get => Session.GetString("CountrySortParam") ?? "country";
      set => Session.SetString("CountrySortParam", value);
    }

    public static string SearchTermInSession
    {
      get => Session.GetString("PersonSearchTerm") ?? "";
      set => Session.SetString("PersonSearchTerm", value);
    }

    public static bool CaseSensitiveInSession
    {
      get => BitConverter.ToBoolean(Session.Get("PersonCaseSensitive"), 0);
      set => Session.Set("PersonCaseSensitive", BitConverter.GetBytes(value));
    }
  }
}

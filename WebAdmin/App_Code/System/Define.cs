using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Define의 요약 설명입니다.
/// </summary>
public class Define
{
	public Define()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
    }

	// 관리자 버전.
	public const int kRev = 1;

    public const int kUserType_Guest = 1;
    public const int kUserType_Facebook = 101;
    public const int kUserType_Google = 102;
    public const int kUserType_Entermate = 201;

    public const int kHeroSearchType_Name = 1;
    public const int kHeroSearchType_heroId = 2;

    public static string S_HOST = System.Web.Configuration.WebConfigurationManager.AppSettings["SITE_URL"].ToString();
    public static string S_NAME = System.Web.Configuration.WebConfigurationManager.AppSettings["SITE_NAME"].ToString();
}
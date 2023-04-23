using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Net;
using LitJson;

/// <summary>
/// Util의 요약 설명입니다.
/// </summary>
public class Util
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Constants

    public const int kUserId_MaxLength = 12;
    public const int kUserSecret_MaxLength = 20;
    public const int kAccessSecret_MaxLength = 20;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Static member variables

    public static Random s_random = new Random();

    private static char[] s_codeElements = new char[] {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
        'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
        'u', 'v', 'w', 'x', 'y', 'z'
    };

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Static properties

    public static Random random
    {
        get { return s_random; }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // 사용자 및 인증 관련

    public static string CreateUserId()
    {
        return CreateCode(kUserId_MaxLength);
    }

    public static string CreateUserSecret()
    {
        return CreateCode(kUserSecret_MaxLength);
    }

    public static string CreateAccessSecret()
    {
        return CreateCode(kAccessSecret_MaxLength);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // 기타

    public static string CreateCode(int nLength)
    {
        int nElementCount = s_codeElements.Length;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < nLength; i++)
        {
            sb.Append(s_codeElements[s_random.Next(nElementCount)]);
        }

        return sb.ToString();
    }

    public static int GetRandomIntValue(Random rnd, object min, object max)
    {
        return rnd.Next(Convert.ToInt32(min), Convert.ToInt32(max));
    }

    public static int GetRandomIntValue(object min, object max)
    {
        return s_random.Next(Convert.ToInt32(min), Convert.ToInt32(max));
    }
    public static double GetRandomDoubleValue(Random rnd, object min, object max)
    {
        return rnd.Next((int)Math.Floor(Convert.ToDouble(min) * 100), (int)Math.Floor(Convert.ToDouble(max) * 100)) / 100.0;
    }

    ///=========================================================================
    /// <summary>
    /// HTML 결과값 가져오기
    /// </summary>
    /// <param name="sUrl"></param>
    /// <param name="sPara"></param>
    /// <returns></returns>
    ///=========================================================================
    public static string GetHtmlResult(string sUrl, string sPara)
    {
        WebRequest webReq = null;
        Stream reqStream = null, resStream = null;
        StreamReader sr = null;
        Encoding encode = null;

        byte[] bnArrStr = null;
        string sMethod = "", sHtml = "";

        try
        {
            if (sPara == null)
                sMethod = "GET";
            else
                sMethod = "POST";

            // 웹 요청
            webReq = WebRequest.Create(sUrl);
            webReq.Method = sMethod;

            // Encoding 설정
            encode = Encoding.GetEncoding("utf-8");

            if (sMethod == "POST")
            {
                // ContentType 설정 (POST)
                webReq.ContentType = "application/x-www-form-urlencoded";

                // Post 전송 데이터 처리
                bnArrStr = encode.GetBytes(sPara);
                webReq.ContentLength = bnArrStr.Length;
                reqStream = webReq.GetRequestStream();
                reqStream.Write(bnArrStr, 0, bnArrStr.Length);

                reqStream.Close();
                reqStream = null;
            }

            // 웹 페이지 읽기
            resStream = webReq.GetResponse().GetResponseStream();
            sr = new StreamReader(resStream, encode);
            sHtml = sr.ReadToEnd();

            sr.Close();
            sr = null;
        }
        catch (Exception e)
        {
            //throw (e);
            JsonData joRes = LitJsonUtil.CreateObject();
            joRes["result"] = 1;
            joRes["errMsg"] = e.Message;
            sHtml = joRes.ToJson();
        }
        finally
        {
            if (reqStream != null)
                reqStream.Close();

            if (sr != null)
                sr.Close();
        }

        return sHtml;
    }

    public static void BadAccessCheck(int nServerId, Guid heroId) {
        if (nServerId < 1 || heroId.Equals(""))
        {
            ComUtil.MsgBox("잘못된 접근입니다.", "history.back();");
            return;
        }
    }
    public static void BadAccessCheckServerId(int nServerId) {
        if (nServerId < 1 )
        {
            ComUtil.MsgBox("잘못된 접근입니다.", "history.back();");
            return;
        }
    }

    public static int CalcTotalPage(int m_nTotalCount, int m_nRowsPerPage) {
        return (m_nTotalCount - 1) / m_nRowsPerPage + 1;
    }

    public static int CalcPage(int m_nTotalCount, int m_nTotalPage, int m_nPage)
    {
        if (m_nTotalCount > 0 && m_nTotalPage < m_nPage) {
            m_nPage = m_nTotalPage;
        }          
        return m_nPage;
    }

}

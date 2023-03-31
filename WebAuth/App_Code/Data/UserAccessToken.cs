using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

using LitJson;

/// <summary>
/// AccessToken'的摘要描述.
/// </summary>
public class UserAccessToken
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants

	public const string kPN_UserId = "userId";
	public const string kPN_AccessSecret = "accessSecret";
	public const string kPN_CheckCode = "checkCode";

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	private Guid m_userId = Guid.Empty;
	private string m_sAccessSecret = null;
	private string m_sCheckCode = null;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constructors

	public UserAccessToken(Guid userId, string sAccessSecret, string sCheckCode)
	{
		m_userId = userId;
		m_sAccessSecret = sAccessSecret;
		m_sCheckCode = sCheckCode;
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Properties

	public Guid userId
	{
		get { return m_userId; }
	}

	public string accessSecret
	{
		get { return m_sAccessSecret; }
	}

	public string checkCode
	{
		get { return m_sCheckCode; }
	}

	public bool isValid
	{
		get { return m_sCheckCode == GetCheckCode(m_userId, m_sAccessSecret); }
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	public JsonData ToJson()
	{
		JsonData jo = LitJsonUtil.CreateObject();
		jo[kPN_UserId] = m_userId.ToString();
		jo[kPN_AccessSecret] = m_sAccessSecret;
		jo[kPN_CheckCode] = m_sCheckCode;

		return jo;
	}

	public override string ToString()
	{
		return ToJson().ToJson();
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Static member functions

	public static string GetCheckCode(Guid userId, string sAccessSecret)
	{
		string sHashKey = Config.hashKey;

		MD5 encoder = MD5.Create();

		string sText = string.Format("{0}:{1}:{2}", sHashKey, userId, sAccessSecret);
		byte[] data = encoder.ComputeHash(Encoding.UTF8.GetBytes(sText));

		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < data.Length; i++)
		{
			sb.Append(data[i].ToString("x2"));
		}

		return sb.ToString();
	}

	public static UserAccessToken Parse(string sToken)
	{
		JsonData joToken = JsonMapper.ToObject(sToken);

		Guid userId = Guid.Parse(LitJsonUtil.GetStringProperty(joToken, kPN_UserId));
		string sAccessSecret = LitJsonUtil.GetStringProperty(joToken, kPN_AccessSecret);
		string sCheckCode = LitJsonUtil.GetStringProperty(joToken, kPN_CheckCode);

		return new UserAccessToken(userId, sAccessSecret, sCheckCode);
	}

	public static bool TryParse(string sToken, out UserAccessToken token)
	{
		token = null;

		if (string.IsNullOrEmpty(sToken))
			return false;

		try
		{
			token = Parse(sToken);
		}
		catch (Exception)
		{
			return false;
		}

		return true;
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
using System.Data.SqlClient;
using System.Data;
using System.IO;

/// <summary>
/// ClientTextMetaDatasCommandHandler'的摘要描述.
/// </summary>
public class ClientTextMetaDatasCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	private int m_nLanguageId;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override void Parse()
	{
		base.Parse();

		if (!LitJsonUtil.TryGetIntProperty(m_joReq, "languageId", out m_nLanguageId))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "languageId"));
	}

	protected override JsonData HandleCommand()
	{
		SqlConnection conn = null;

		try
		{
			//===============================================================================================
			// 连接到一个数据库
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//===============================================================================================
			// 系统游戏设置
			//===============================================================================================
			DataRow drSystemSetting = Dac.SystemSetting(conn, null);

            //===============================================================================================
            // 语言检查
            //===============================================================================================
            int nSelectedLanguageId = -1;

            // 系统默认语言代码
            nSelectedLanguageId = Convert.ToInt32(drSystemSetting["defaultLanguageId"]);

			DataRowCollection drcLanguages = Dac.SupportedLanguages(conn, null);
			for (int i = 0; i < drcLanguages.Count; i++)
			{
                // 如果客户的语言是一种可用的语言
                if (m_nLanguageId == Convert.ToInt32(drcLanguages[i]["languageId"]))
				{
					nSelectedLanguageId = m_nLanguageId;
					break;
				}
			}

			//===============================================================================================
			// 关闭一个数据库连接
			//===============================================================================================
			DBUtil.Close(ref conn);

			string sClientTextVersion = drSystemSetting["clientTextVersion"].ToString();

			JsonData joRes = CreateResponse();

			joRes["clientTexts"] = File.ReadAllText(HttpContext.Current.Server.MapPath(kFileName_MetaDataPath) + "/" + string.Format(kFileName_ClientText, sClientTextVersion, nSelectedLanguageId));

			return joRes;
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}
}
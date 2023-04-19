using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Collections.Generic;

public partial class Game_SendMail : System.Web.UI.Page
{
	protected int m_nGameServerGroupId = 0;
	protected int m_nGameServerId = 0;
	protected int[] HeroId;
    protected void Page_Load(object sender, EventArgs e)
    {
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

		//======================================================================
		//다국어 변환
		//======================================================================

		//======================================================================
		// 파라미터
		//======================================================================
		m_nGameServerGroupId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);
		m_nGameServerId = ComUtil.GetRequestInt("GSID", RequestMethod.Get, 0);

		if (IsPostBack)
			return;

		try
		{
			PageLoad();
		}
		catch (System.Threading.ThreadAbortException) { }
		catch (Exception ex)
		{
			ComUtil.ErrorLogMsg(ex);
		}
    }
	private void PageLoad()
	{
		WBtnMailSend.Attributes.Add("onclick", "return sendMail();");

		SqlConnection uConn = DBUtil.GetUserDBConn();

		DataTable dt = DacUser.GameServerGroups(uConn, null);
		DataTable dtServer = DacUser.GameServers(uConn, null, m_nGameServerGroupId);
		DataTable dtItems = DacUser.Items(uConn, null);
		DataTable dtGears = DacUser.Gears(uConn, null);
		DataTable dtGrades = DacUser.Grades(uConn, null);
		DataTable dtGearRoyalType = DacUser.GearRoyalTypes(uConn, null);
		DBUtil.CloseDBConn(uConn);

		//서버그룹 DropDownList 생성
		WDDLServerGropList.Items.Add(new ListItem("--서버그룹선택--", "0"));
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			WDDLServerGropList.Items.Add(new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["groupId"].ToString()));
		}
		//게임서버 DropDownList 생성
		WDDLServerList.Items.Add(new ListItem("--게임서버선택--", "0"));
		for (int i = 0; i < dtServer.Rows.Count; i++)
		{
			WDDLServerList.Items.Add(new ListItem(dtServer.Rows[i]["name"].ToString(), dtServer.Rows[i]["serverId"].ToString()));
		}

		//게임서버그룹 바인딩
		WDDLServerGropList.SelectedValue = m_nGameServerGroupId.ToString();
		WDDLServerList.SelectedValue = m_nGameServerId.ToString();
		
		// 제목,내용 타입 선택 컨트롤 채우기
		WDDLType.Items.Add(new ListItem("영웅ID", "0"));
		WDDLTitleType.Items.Add(new ListItem("일반텍스트", "1"));
		WDDLTitleType.Items.Add(new ListItem("스트링키", "2"));
		WDDLContentType.Items.Add(new ListItem("일반텍스트", "1"));
		WDDLContentType.Items.Add(new ListItem("스트링키", "2"));
	
		// 아이템 선택 컨트롤 채우기
		WDDLItem.Items.Add(new ListItem("아이템 선택", "0"));
		for (int i = 0; i < dtItems.Rows.Count; i++)
		{
			WDDLItem.Items.Add(new ListItem("" + dtItems.Rows[i]["itemId"].ToString() + " " + dtItems.Rows[i]["_name"], dtItems.Rows[i]["itemId"].ToString()));
		}

		//장비 선택 컨트롤 채우기
		WDDLGear.Items.Add(new ListItem("장비 선택", "0"));
		for (int i = 0; i < dtGears.Rows.Count; i++)
		{
			WDDLGear.Items.Add(new ListItem("" + dtGears.Rows[i]["gearId"].ToString() + " " + dtGears.Rows[i]["_name"], dtGears.Rows[i]["gearId"].ToString()));
		}

		//장비등급 선택 컨트롤 채우기
		WDDLGearGrade.Items.Add(new ListItem("등급 선택", "0"));
		for (int i = 0; i < dtGrades.Rows.Count; i++)
		{
			WDDLGearGrade.Items.Add(new ListItem("" + dtGrades.Rows[i]["grade"].ToString() + " " + dtGrades.Rows[i]["_name"], dtGrades.Rows[i]["grade"].ToString()));
		}

		//장비로열타입 선택 컨트롤 채우기
		WDDLGearRoyalType.Items.Add(new ListItem("=로열타입=", "0"));
		for (int i = 0; i < dtGearRoyalType.Rows.Count; i++)
		{
			WDDLGearRoyalType.Items.Add(new ListItem("" + dtGearRoyalType.Rows[i]["royalType"].ToString() + " " + dtGearRoyalType.Rows[i]["_name"], dtGearRoyalType.Rows[i]["royalType"].ToString()));
		}
	}

	//서버그룹 선택시 게임서버목록출력
	protected void WDDLServerGroup_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		Response.Redirect("/Game/SendMail.aspx?SVR=" + WDDLServerGropList.SelectedValue);
	}
	protected void WDDLServerList_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		Response.Redirect("/Game/SendMail.aspx?SVR=" + WDDLServerGropList.SelectedValue + "&GSID=" + WDDLServerList.SelectedValue);
	}
    // 우편발송
	protected void WBtnMailSend_OnClick(object sender, EventArgs e)
	{
		if (m_nGameServerId == 0)
		{
			ComUtil.MsgBox("게임서버를 선택해주세요", "history.back();");
			return;
		}
		try
		{
			string sAttachmentItem = WHFMailAttachmentITEM.Value.Trim();

			//영웅ID 추출
			
			string sHeroIds = WTxtTarget.Text.Trim();
			string[] sArrHeroIds = sHeroIds.Split(',');

			if (WTxtDuration.Text.Trim() == "")
			{
				ComUtil.MsgBox("빈칸을 채워주세요", "historyback();");
				return;
			}

			int nDurationDay = Convert.ToInt32(WTxtDuration.Text.Trim());
			int nTitleType = Convert.ToInt32(WDDLTitleType.SelectedValue);
			string sTitle = WTxtMailTitle.Text.Trim();
			int nContentType = Convert.ToInt32(WDDLContentType.SelectedValue);
			string sContent = WTxtMailContent.Text.Trim();

			string[] sArrItems = sAttachmentItem.Split('`');

			string sArgs = WHFMailArgs.Value;
			string[] sArrArgs = sArgs.Split('|');

			if (sTitle == "" || sContent == "")
			{
				ComUtil.MsgBox("빈칸을 채워주세요", "historyback();");
				return;
			}

			int nRetVal = 0;
			Guid mailId = Guid.Empty;

			int nAttachmentType = 0;
			bool isExists = false;

			int nItemId = 0;
			bool itemOwned = false;
			int nItemCount = 0;

			int nGearId = 0;
			int nGearGrade = 0;
			bool gearOwned = false;
			int nGearEnchantLevel = 0;
			int nGearLevel = 0;
			int nGearRoyalType = 0;

			if (sAttachmentItem == "")
			{
				ComUtil.MsgBox("첨부아이템,장비가 없습니다.", "historyback();");
				return;
			}

			//영웅아이디의 갯수만큼 반복
			for (int i = 0; i < sArrHeroIds.Length; i++)
			{
				Guid nHeroId;
				bool stringCheck = ComUtil.TryParseGuid(sArrHeroIds[i], out nHeroId); 
				if (!stringCheck)
				{
					ComUtil.MsgBox("영웅ID가 숫자가 아닙니다.", "history.back();");
					return;
				}

				//DB연결
				SqlConnection conn = DBUtil.GetGameDBConn(m_nGameServerId);
				SqlTransaction tran = conn.BeginTransaction();

				if (Dac.Hero(conn, tran, nHeroId) != null)
				{
					//첨부갯수만큼 반복
					for (int j = 0; j < sArrItems.Length; j++)
					{
						nAttachmentType = 0;
						isExists = false;
						string[] sArr = sArrItems[j].Split('|');

						if (sArr[1] == "0")
						{
							ComUtil.MsgBox("첨부아이템,장비가 없습니다.", "historyback();");
							tran.Commit();
							tran.Dispose();

							DBUtil.CloseDBConn(conn);
							return;
						}

						nItemId = 0;
						itemOwned = false;
						nItemCount = 0;

						nGearId = 0;
						nGearGrade = 0;
						gearOwned = false;
						nGearEnchantLevel = 0;
						nGearLevel = 0;
						nGearRoyalType = 0;

						if (sArr[0] == "1")
						{
							// 아이템
							if (Convert.ToInt32(sArr[1]) > 0)
							{
								nAttachmentType = 2;

								nItemId = Convert.ToInt32(sArr[1]);
								itemOwned = Convert.ToBoolean(Convert.ToInt32(sArr[2]));
								nItemCount = Convert.ToInt32(sArr[3]);

								isExists = true;
							}
						}
						else if (sArr[0] == "2")
						{
							// 장비
							if (Convert.ToInt32(sArr[1]) > 0)
							{

								nGearId = Convert.ToInt32(sArr[1]);
								nGearGrade = Convert.ToInt32(sArr[2]);
								//등급 체크
								if (nGearGrade == 0)
								{
									tran.Rollback();
									tran.Dispose();

									DBUtil.CloseDBConn(conn);
									ComUtil.MsgBox("장비의 등급을 선택해야합니다.", "history.back();");
									return;
								}

								if (nGearGrade > 0)
								{
									nAttachmentType = 1;

									gearOwned = Convert.ToBoolean(Convert.ToInt32(sArr[3]));
									nGearEnchantLevel = Convert.ToInt32(sArr[4]);
									nGearLevel = Convert.ToInt32(sArr[5]);
									nGearRoyalType = Convert.ToInt32(sArr[6]);

									isExists = true;
								}
							}
						}

						if (isExists)
						{
							mailId = Guid.NewGuid();

							// 메일 등록
							if (Dac.AddGMMail(conn, tran, mailId, nHeroId, nTitleType, sTitle, nContentType, sContent, nDurationDay, nAttachmentType,
								nItemId, nItemCount, itemOwned, nGearId, nGearGrade, gearOwned, nGearEnchantLevel, nGearLevel, nGearRoyalType) != 0)
							{
								tran.Rollback();
								tran.Dispose();

								DBUtil.CloseDBConn(conn);

								ComUtil.MsgBox("메일 등록에 실패하였습니다.", "history.back();");
								return;
							}

							//제목 인자
							if (sArgs != "")
							{
								int nArgsType = 0;
								int nArgsIndex = 0;

								for (int k = 0; k < sArrArgs.Length; k++)
								{
									if (sArrArgs[k].Split('`')[2].Trim() != "")
									{
										if (nArgsType != Convert.ToInt32(sArrArgs[k].Split('`')[0].Trim()))
										{
											nArgsIndex = 0;
											nArgsType = Convert.ToInt32(sArrArgs[k].Split('`')[0].Trim());
										}

										int nValueType = Convert.ToInt32(sArrArgs[k].Split('`')[1].Trim());
										string sValue = sArrArgs[k].Split('`')[2].Trim();

										if (Dac.AddMailTextArgument(conn, tran, mailId, nArgsType, nArgsIndex, nValueType, sValue) != 0)
										{
											tran.Rollback();
											tran.Dispose();

											DBUtil.CloseDBConn(conn);

											ComUtil.MsgBox("메일 제목 인자 등록에 실패하였습니다.", "history.back();");
											return;
										}

										nArgsIndex++;
									}
								}
							}

							// 장비 옵션 속성 등록 (장비)
							if (nAttachmentType == 1)
							{
								SqlConnection connUser = DBUtil.GetUserDBConn();

								DataRowCollection drcGrades = DacUser.Grades(connUser, null).Rows;

								int nGearOptionAttrCount = 0;

								foreach (DataRow dr in drcGrades)
								{
									if (nGearGrade == Convert.ToInt32(dr["grade"]))
									{
										nGearOptionAttrCount = Convert.ToInt32(dr["gearOptionAttrCount"]);
										break;
									}
								}

								// 장비옵션속성등급 목록
								DataTable dtGearOptionAttrGrades = DacUser.GearOptionAttrGrades(connUser, null, nGearId);

								// 장비옵션속성 선택
								List<GearAttr> optionAttrs = DataUtil.GetGearOptionAttr(nGearOptionAttrCount, dtGearOptionAttrGrades);

								DBUtil.CloseDBConn(connUser);

								int nOptionIndex = 0;

								foreach (GearAttr attr in optionAttrs)
								{
									if (Dac.AddMailAttachmentGearOptionAttr(conn, tran, mailId, nOptionIndex, attr.attrId, attr.value) != 0)
										if (nRetVal != 0)
										{
											tran.Rollback();
											tran.Dispose();

											DBUtil.CloseDBConn(conn);

											ComUtil.MsgBox("메일 첨부 장비 옵션 속성 등록에 실패하였습니다.", "history.back();");
											return;
										}

									nOptionIndex++;
								}
							}
						}
					}
				}
				else
				{
					ComUtil.MsgBox("아이디가 옳지 않습니다.", "history.back();");
					tran.Commit();
					tran.Dispose();

					DBUtil.CloseDBConn(conn);
					return;
				}

				tran.Commit();
				tran.Dispose();

				DBUtil.CloseDBConn(conn);
			}

			ComUtil.MsgBox("메일이 발송되었습니다.", "location.href='" + Request.Url.ToString() + "';");
		}
		catch (Exception ex)
		{
			Response.Write(ex.Message);

			//ComUtil.MsgBox("오류", "history.back();");
		}
	}

}
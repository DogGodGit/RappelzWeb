// Ver20060321

namespace GamePub.Common.Controls
{
	using System;
	using System.Data;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

    public partial class PageNavigator : System.Web.UI.UserControl
	{
		//=//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// Fields

		private string sLinkURL = "", sUrlParam = "";
		private int nCurrentPage = 1, nPageCount = 1, nPageListSize = 10;

		private string sFirstPageItem		= "";	// 맨처음
		private string sLastPageItem		= "";	// 맨끝
		private string sFirstPageDimItem	= "";	// 맨처음Dim
		private string sLastPageDimItem		= "";	// 맨끝Dim

		private string sPrevPageItem		= "";	// 이전페이지
		private string sNextPageItem		= "";	// 다음페이지
		private string sPrevPageDimItem		= "";	// 이전페이지Dim
		private string sNextPageDimItem		= "";	// 다음페이지Dim

		private string sPrevPageSizeItem	= "";	// 이전블럭
		private string sNextPageSizeItem	= "";	// 다음블럭
		private string sPrevPageSizeDimItem	= "";	// 이전블럭Dim
		private string sNextPageSizeDimItem	= "";	// 다음블럭Dim

		private string sSeparateItem		= "";	// 구분자

		private string sNumberDescLeft		= "";	// 숫자앞태그
		private string sNumberDescRight		= "";	// 숫자뒤태그

		private string sSNumberDescLeft		= "";	// 선택된페이지숫자앞태그
        private string sSNumberDescRight    = "";	// 선택된페이지숫자뒤태그
    
        private string sQueryName           = "PG";	// 쿼리스트링


		//=//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// Properties

		public int CurrentPage
		{
			get { return nCurrentPage; }
			set { nCurrentPage = value < 1 ? 1 : value; }
		}

		public string FirstPageItem
		{
			get { return sFirstPageItem; }
			set { sFirstPageItem = value; }
		}

		public string LastPageItem
		{
			get { return sLastPageItem; }
			set { sLastPageItem = value == null ? "" : value; }
		}

		public string LinkURL
		{
			get { return sLinkURL; }
			set { sLinkURL = value == null ? "" : value; }
		}

		public string NextPageItem
		{
			get { return sNextPageItem; }
			set { sNextPageItem = value == null ? "" : value; }
		}

		public string NextPageSizeItem
		{
			get { return sNextPageSizeItem; }
			set { sNextPageSizeItem = value == null ? "" : value; }
		}

		public int PageCount
		{
			get { return nPageCount; }
			set { nPageCount = value < 1 ? 1 : value; }
		}

		public int PageListSize
		{
			get { return nPageListSize; }
			set { nPageListSize = value < 1 ? 1 : value; }
		}

		public string PrevPageItem
		{
			get { return sPrevPageItem; }
			set { sPrevPageItem = value == null ? "" : value; }
		}

		public string PrevPageSizeItem
		{
			get { return sPrevPageSizeItem; }
			set { sPrevPageSizeItem = value == null ? "" :  value; }
		}

		public string FirstPageDimItem
		{
			get { return sFirstPageDimItem; }
			set { sFirstPageDimItem = value; }
		}

		public string LastPageDimItem
		{
			get { return sLastPageDimItem; }
			set { sLastPageDimItem = value == null ? "" : value; }
		}

		public string NextPageDimItem
		{
			get { return sNextPageDimItem; }
			set { sNextPageDimItem = value == null ? "" : value; }
		}

		public string NextPageSizeDimItem
		{
			get { return sNextPageSizeDimItem; }
			set { sNextPageSizeDimItem = value == null ? "" : value; }
		}

		public string PrevPageDimItem
		{
			get { return sPrevPageDimItem; }
			set { sPrevPageDimItem = value == null ? "" : value; }
		}

		public string PrevPageSizeDimItem
		{
			get { return sPrevPageSizeDimItem; }
			set { sPrevPageSizeDimItem = value == null ? "" :  value; }
		}

		public string SeparateItem
		{
			get {return sSeparateItem; }
			set { sSeparateItem = value == null ? "" : value; }
		}

		public string UrlParam
		{
			get { return sUrlParam; }
			set { sUrlParam = value == null ? "" : value; }
		}

		public string NumberDecoLeft
		{
			get { return sNumberDescLeft; }
			set { sNumberDescLeft = value == null ? "" : value; }
		}

		public string NumberDecoRight
		{
			get { return sNumberDescRight; }
			set { sNumberDescRight = value == null ? "" : value; }
		}

		public string SNumberDecoLeft
		{
			get { return sSNumberDescLeft; }
			set { sSNumberDescLeft = value == null ? "" : value; }
		}

		public string SNumberDecoRight
		{
			get { return sSNumberDescRight; }
			set { sSNumberDescRight = value == null ? "" : value; }
		}

        public string SQueryName
		{
            get { return sQueryName; }
            set { sQueryName = value == null ? "" : value; }
		}

		protected string GetUI
		{
			get
			{
				string sUIString = "", sParam = "";
				int nStartPage, nEndPage;
				int i, nTmpPage;

				if(sUrlParam != "")
					sParam = "&" + sUrlParam;

				if(nCurrentPage > 1)
				{
					// 처음페이지
					if (sFirstPageItem != "")
                        sUIString = string.Format("<a href='{0}?{4}={1}{2}' OnFocus=\"blur()\">{3}</a>", sLinkURL, 1, sParam, sFirstPageItem, sQueryName);

                    if (sUIString != "") sUIString += sSeparateItem;

					// 이전페이지
					if (sPrevPageItem != "")
					{
                        sUIString += string.Format("<a href='{0}?{4}={1}{2}' OnFocus=\"blur()\">{3}</a>", sLinkURL, nCurrentPage - 1, sParam, sPrevPageItem, sQueryName);

                        if (sUIString != "") sUIString += sSeparateItem;
					}
				}
				else
				{
					// 처음/이전페이지
					if (sFirstPageDimItem != "")	sUIString = sFirstPageDimItem;
					if (sPrevPageDimItem != "")		sUIString += sPrevPageDimItem;
				}

				// nPageListSize 만큼 이전 페이지
				if(sPrevPageSizeItem != "" && nCurrentPage > nPageListSize)
				{
					nTmpPage   = (nCurrentPage%nPageListSize == 1) ? nCurrentPage-1:nCurrentPage - (nCurrentPage-1)%nPageListSize - 1;
                    sUIString += string.Format("<a href='{0}?{4}={1}{2}' onFocus=\"blur()\">{3}</a>", sLinkURL, nTmpPage, sParam, sPrevPageSizeItem, sQueryName);
				}
				else if(sPrevPageSizeDimItem != "" && !(nCurrentPage > nPageListSize))
				{
					sUIString += sPrevPageSizeDimItem;
				}

				nStartPage = ((nCurrentPage - 1) / nPageListSize) * nPageListSize + 1;
				nEndPage = nStartPage + nPageListSize - 1;
				if(nEndPage > nPageCount)
					nEndPage = nPageCount;

				for(i = nStartPage; i <= nEndPage; i++)
				{
					if (sUIString != "" && i != nStartPage && i != nEndPage+1)	sUIString += sSeparateItem;

					if (i != nCurrentPage)
                        sUIString += string.Format("{3}<a href='{0}?{6}={1}{2}'  onfocus=\"blur()\" align=\"absmiddle\">{4}</a>{5}", sLinkURL, i, sParam, sNumberDescLeft, i, sNumberDescRight, sQueryName);
					else
						sUIString += string.Format("{0}{1}{2}", sSNumberDescLeft, i, sSNumberDescRight);
				}

				// nPageListSize 만큼 다음페이지
				if(sNextPageSizeItem != "" && nEndPage <= ((nPageCount - 1) / nPageListSize) * nPageListSize)
				{
                    nTmpPage = nCurrentPage + nPageListSize > nPageCount ? nPageCount : (Convert.ToInt32(Math.Floor((double)(nCurrentPage - 1 + nPageListSize) / nPageListSize)) * nPageListSize) + 1;
                    sUIString += string.Format("<a href='{0}?{4}={1}{2}' onfocus=\"blur()\">{3}</a>", sLinkURL, nTmpPage, sParam, sNextPageSizeItem, sQueryName);
				}
				else if(sNextPageSizeDimItem != "" && !(nEndPage <= ((nPageCount - 1) / nPageListSize) * nPageListSize))
				{
					sUIString += sNextPageSizeDimItem;
				}

				if(nCurrentPage < nPageCount)
				{
                    if (sUIString != "") sUIString += sSeparateItem;

					// 다음페이지
					if (sNextPageItem != "")
                        sUIString += string.Format("<a href='{0}?{4}={1}{2}' onfocus=\"blur()\">{3}</a>", sLinkURL, nCurrentPage + 1, sParam, sNextPageItem, sQueryName);

                    if (sUIString != "") sUIString += sSeparateItem;

					// 마지막페이지
					if (sLastPageItem != "")
                        sUIString += string.Format("<a href='{0}?{4}={1}{2}' onfocus=\"blur()\">{3}</a>", sLinkURL, nPageCount, sParam, sLastPageItem, sQueryName);
				}
				else
				{
					// 다음페이지
					if (sNextPageDimItem != "")
						sUIString += sNextPageDimItem;

					// 마지막페이지
					if (sLastPageDimItem != "")
						sUIString += sLastPageDimItem;
				}

				return sUIString;
			}
		}


		//=//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// Event Handlers

		private void Page_Load(object sender, System.EventArgs e)
		{
		}

		#region Web Form 디자이너에서 생성한 코드
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 이 호출은 ASP.NET Web Form 디자이너에 필요합니다.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		디자이너 지원에 필요한 메서드입니다. 이 메서드의 내용을
		///		코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
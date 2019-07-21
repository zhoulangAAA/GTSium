using System;

namespace Silt.Base.Common.PopupWindow
  
{
    public delegate void TextChangedHandler1(string str1);
    /// <summary>
    /// 返回一个字符值
    /// </summary>
	public class ResultOne
	{		
		public event TextChangedHandler1 TextChanged;
		public void ChangeText(string str1)
		{
			if(TextChanged != null)
                TextChanged(str1);
		}
	}
}

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq.Expressions;
using System.Text;

namespace AlexBlogMVC.CustomHtmlHelper
{
    public static class CustomHtmlHelper
    {
        public static string CustomLabel(this IHtmlHelper helper,string target,string text)
        {
            return String.Format("<label for='{0}'>{1}</label>", target, text);
        }

        public static IHtmlContent HelloWorldHTMLString(this IHtmlHelper htmlHelper)
            => new HtmlString("<strong>Hello World</strong>");
        //public static MvcHtmlString EditorForTemplateModel<TModel, TValue>(
        //    this HtmlHelper<TModel> html,
        //    Expression<Func<TModel, IEnumerable<TValue>>> expression,
        //    string htmlFieldName = null) where TModel : class
        //{
        //    StringBuilder sb = new StringBuilder();
        //    try
        //    {
        //        var items = expression.Compile()(html.ViewData.Model);
        //        bool hasPrefix = false;

        //        if (String.IsNullOrEmpty(htmlFieldName))
        //        {
        //            string prefix = html.ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix;
        //            hasPrefix = !String.IsNullOrEmpty(prefix);
        //            htmlFieldName = (prefix.Length > 0 ? (prefix + ".") : String.Empty) + ExpressionHelper.GetExpressionText(expression);
        //        }

        //        if (items != null)
        //        {
        //            foreach (var item in items)
        //            {
        //                var dummy = new { Item = item };
        //                String guid = Guid.NewGuid().ToString();

        //                MemberExpression memberExp = Expression.MakeMemberAccess(Expression.Constant(dummy), dummy.GetType().GetProperty("Item"));
        //                var singleItemExp = Expression.Lambda<Func<TModel, TValue>>(memberExp, expression.Parameters);

        //                sb.Append(String.Format(@"<input id=""{1}"" type=""hidden"" name=""{0}.Index"" value=""{1}"" />", htmlFieldName, guid));
        //                if (htmlFieldName.Equals("listSaleParkingOrderViewModels"))
        //                {
        //                    sb.Append(String.Format(@"<div id=""div_{0}"" class=""col-12 form-row"">", guid));
        //                    sb.Append(html.EditorFor(singleItemExp, null, String.Format("{0}[{1}]", hasPrefix ? ExpressionHelper.GetExpressionText(expression) : htmlFieldName, guid)));
        //                    sb.Append(String.Format("<div class=\"col-1 align-self-center\">"));
        //                    sb.Append(String.Format(@"<button class=""rounded-circle btn btn-sm btn-warning"" onclick=""delTemplate('{0}'); return false;""><i class=""fa fa-solid fa-minus""></i></button>", guid));
        //                    sb.Append(String.Format("</div>"));
        //                    sb.Append(String.Format("</div>"));
        //                }
        //                else if (htmlFieldName.Equals("SalesServiceViewModel.listMember_SalesManViewModels"))
        //                {
        //                    sb.Append(String.Format(@"<div id=""div_{0}"" class=""col-xs-12"">", guid));
        //                    sb.Append(html.EditorFor(singleItemExp, null, String.Format("{0}[{1}]", hasPrefix ? ExpressionHelper.GetExpressionText(expression) : htmlFieldName, guid)));
        //                    sb.Append(String.Format(@"<button class=""col-sm-offset-1 rounded-circle btn btn-sm btn-warning"" onclick=""removeSalesManID('{0}'); delTemplate('{0}'); return false;""><i class=""fa fa-solid fa-minus""></i></button>", guid));
        //                    sb.Append(String.Format("</div>"));
        //                    sb.Append(String.Format("<div class=\"col-xs-12\"></div>"));
        //                }
        //                else
        //                {
        //                    sb.Append(html.EditorFor(singleItemExp, null, String.Format("{0}[{1}]", hasPrefix ? ExpressionHelper.GetExpressionText(expression) : htmlFieldName, guid)));
        //                }
        //            }
        //        }
        //        return new MvcHtmlString(sb.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        string exMsg = ex.Message;
        //        return new MvcHtmlString(sb.ToString());
        //    }
        //}
    }
}

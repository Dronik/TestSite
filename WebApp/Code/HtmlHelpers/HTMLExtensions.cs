using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using WebApp.ViewModels;

namespace WebApp.Code.HtmlHelpers
{
    public static class HTMLExtensions
    {
        private static MvcHtmlString FieldIDFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string inputFieldId = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);

            return MvcHtmlString.Create(inputFieldId);
        }

        public static MvcHtmlString ApplyFilterFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> applyExpression, string title, string formId, string styleClass)
        {
            var applyFieldId = htmlHelper.FieldIDFor(applyExpression);
            var formSubmitScriptTemplate = "event.preventDefault();$('#{0}').val('{1}');$('form#{2}').trigger('submit');";
            var builder = new TagBuilder("a");
            builder.SetInnerText(title);
            builder.Attributes.Add("href", "#");
            builder.Attributes.Add("onclick", String.Format(formSubmitScriptTemplate, applyFieldId, true, formId));
            builder.AddCssClass(styleClass);


            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        public static void SetPropertyValue<T>(this T target, Expression<Func<T, object>> memberLamda, object value)
        {
            var memberSelectorExpression = memberLamda.Body as MemberExpression;

            if (memberSelectorExpression == null)
            {
                var  temp = memberLamda.Body as UnaryExpression;
                
                if (temp != null)
                {
                    memberSelectorExpression = temp.Operand as MemberExpression;
                }
            }


            if (memberSelectorExpression != null)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null)
                {
                    property.SetValue(target, value, null);
                }
            }
        }

        public static MvcHtmlString SortColumnFor<TModel, TSortName, TSortOrder>(this HtmlHelper<TModel> htmlHelper,
                                                            Expression<Func<TModel, TSortName>> sortNameExpression,
                                                            Expression<Func<TModel, TSortOrder>> sortOrderExpression,
                                                            BaseFilterViewModel model,
                                                            string formId,
            //Func<int, string> sortingUrl,
            // AjaxOptions ajaxOptions,
                                                            string title,
                                                            string sortColumn,
                                                            string ascendingStyleClass,
                                                            string descendingStyleClass)
        {
            var sortNameFieldId = htmlHelper.FieldIDFor(sortNameExpression);
            var sortOrderFieldId = htmlHelper.FieldIDFor(sortOrderExpression);
            var currentSortName = (string)ModelMetadata.FromLambdaExpression(sortNameExpression, htmlHelper.ViewData).Model;
            var currentSortOrder = (bool)ModelMetadata.FromLambdaExpression(sortOrderExpression, htmlHelper.ViewData).Model;
            var isCurrentSorted = currentSortName == sortColumn;
            var sortOrder = isCurrentSorted ? !currentSortOrder : true;

            model.SetPropertyValue(m => m.SortColumn, sortColumn);

            var formSubmitScriptTemplate = "event.preventDefault();$('#{0}').val('{1}');$('#{2}').val('{3}');$('form#{4}').trigger('reset');$('form#{4}').trigger('submit');";
            var builder = new TagBuilder("a");
            builder.SetInnerText(title);
            //          builder.Attributes.Add("href", sortingUrl(1));

            builder.Attributes.Add("href", "#");
            builder.Attributes.Add("onclick", String.Format(formSubmitScriptTemplate, sortNameFieldId, sortColumn, sortOrderFieldId, sortOrder, formId));




            //if (ajaxOptions != null)
            //{
            //    foreach (var ajaxOption in ajaxOptions.ToUnobtrusiveHtmlAttributes())
            //        builder.Attributes.Add(ajaxOption.Key, ajaxOption.Value.ToString());
            //}

            if (isCurrentSorted)
            {
                builder.AddCssClass(currentSortOrder ? ascendingStyleClass : descendingStyleClass);
            }

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        //public static MvcHtmlString PageSizeFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> pageSizeExpression, IDictionary<string, string> pageSizes, string formId, string styleClass)
        //{
        //    var pageSizeFieldId = htmlHelper.FieldIDFor(pageSizeExpression);
        //    var selectedValue = (int)ModelMetadata.FromLambdaExpression(pageSizeExpression, htmlHelper.ViewData).Model;
        //    var formSubmitScriptTemplate = "var value = $('#{1}').val();$('form#{0}').trigger('reset');$('#{1}').val(value);$('form#{0}').trigger('submit');";

        //    return htmlHelper.DropDownListFor(pageSizeExpression, new SelectList(pageSizes, "Key", "Value", selectedValue), new { @class = styleClass, onchange = String.Format(formSubmitScriptTemplate, formId, pageSizeFieldId) });
        //}




        public static MvcHtmlString SortColumnFor1<TModel, TSortName, TSortOrder>(this AjaxHelper<TModel> htmlHelper,
                                                           BaseFilterViewModel model,
                                                           Expression<Func<TModel, TSortName>> sortNameExpression,//m => m.Filter.SortColumn
                                                           Expression<Func<TModel, TSortOrder>> sortOrderExpression,
                                                           Func<BaseFilterViewModel, string> sortingUrl,
                                                           AjaxOptions ajaxOptions,
                                                           string sortColumnTitle,
                                                           string ascendingStyleClass,
                                                           string descendingStyleClass)
        {

            var currentSortName = (string)ModelMetadata.FromLambdaExpression(sortNameExpression, htmlHelper.ViewData).Model;
            var currentSortOrder = (bool)ModelMetadata.FromLambdaExpression(sortOrderExpression, htmlHelper.ViewData).Model;
            var isCurrentSorted = currentSortName == sortColumnTitle;

            var sortOrder = isCurrentSorted ? !currentSortOrder : true;

            model.SetPropertyValue(m => m.SortColumn, sortColumnTitle);
            model.SetPropertyValue(m => m.PageNumber, model.PageNumber);
            model.SetPropertyValue(m => m.IsAscending, sortOrder);
            model.SetPropertyValue(m => m.IsApply, model.IsApply);

            var builder = new TagBuilder("a");
            builder.SetInnerText(sortColumnTitle);
            builder.Attributes.Add("href", sortingUrl(null));

            model.SetPropertyValue(m => m.SortColumn, currentSortName);
            model.SetPropertyValue(m => m.IsAscending, currentSortOrder);

            if (ajaxOptions != null)
            {
                foreach (var ajaxOption in ajaxOptions.ToUnobtrusiveHtmlAttributes())
                    builder.Attributes.Add(ajaxOption.Key, ajaxOption.Value.ToString());
            }

            if (isCurrentSorted)
            {
                builder.AddCssClass(currentSortOrder ? ascendingStyleClass : descendingStyleClass);
            }


            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
    }
}
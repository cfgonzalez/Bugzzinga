using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Bugzzinga.Infraestructura.Html
{
    public static class HighLevelFormComponents
    {
        #region Label

        public static MvcHtmlString DisplayPropertyFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan, bool inline = true)
        {
            return DisplayPropertyFor(htmlHelper, expression, columnSpan, null, inline);
        }

        //TODO: esto deberia utilizarse directamente agregando la property class inline en inputHtmlAttributes
        public static MvcHtmlString DisplayPropertyFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan, object inputHtmlAttributes, bool inline)
        {
            var input = new Dictionary<string, object> { { "class", "bold" } };

            if (inputHtmlAttributes != null)
                input.MergeWith(inputHtmlAttributes);

            var content =
                string.Concat(
                    inline
                        ? htmlHelper.LabelFor(expression, new Dictionary<string, object> { { "class", "inline" } })
                        : htmlHelper.LabelFor(expression),
                    htmlHelper.DataBindedDisplayPropertyFor(expression, input));

            return Wrap(htmlHelper, content, expression, columnSpan);
        }
        #endregion

        #region TextArea

        public static MvcHtmlString MultiLineTextPropertyEditorFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan, string rows)
        {
            return MultiLineTextPropertyEditorFor(htmlHelper, expression, columnSpan, null, rows);
        }

        public static MvcHtmlString MultiLineTextPropertyEditorFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan, object inputHtmlAttributes, string rows)
        {
            var input = new Dictionary<string, object> { { "class", "input-block-level small" }, { "rows", rows } };

            if (htmlHelper.IsReadOnlyView())
                input.Add("disabled", "disabled");

            if (inputHtmlAttributes != null)
                input.MergeWith(inputHtmlAttributes);

            var content = string.Concat(htmlHelper.LabelFor(expression),
                                        htmlHelper.DataBindedTextAreaFor(expression, input),
                                        htmlHelper.ValidationMessageFor(expression));

            return Wrap(htmlHelper, content, expression, columnSpan);
        }

        #endregion

        #region TextBox

        public static MvcHtmlString TextPropertyEditorFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan)
        {
            return TextPropertyEditorFor(htmlHelper, expression, columnSpan, (object)null);
        }

        public static MvcHtmlString TextPropertyEditorFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan, bool noLabel)
        {
            return TextPropertyEditorNoLabelFor(htmlHelper, expression, columnSpan, (object)null);
        }

        public static MvcHtmlString TextPropertyLabelFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan)
        {
            return TextPropertyLabelFor(htmlHelper, expression, columnSpan, (object)null);
        }

        public static MvcHtmlString TextPropertyEditorFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan, object inputHtmlAttributes)
        {
            var input = new Dictionary<string, object> { { "class", "input-block-level small" } };

            if (htmlHelper.IsReadOnlyView())
                input.Add("disabled", "disabled");

            if (inputHtmlAttributes != null)
                input.MergeWith(inputHtmlAttributes);

            var content = string.Concat(htmlHelper.LabelFor(expression),
                                        htmlHelper.DataBindedTextBoxFor(expression, input),
                                        htmlHelper.ValidationMessageFor(expression));

            return Wrap(htmlHelper, content, expression, columnSpan);
        }

        public static MvcHtmlString TextPropertyEditorNoLabelFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan, object inputHtmlAttributes)
        {
            var input = new Dictionary<string, object> { { "class", "input-block-level small" } };

            if (htmlHelper.IsReadOnlyView())
                input.Add("disabled", "disabled");

            if (inputHtmlAttributes != null)
                input.MergeWith(inputHtmlAttributes);

            var content = string.Concat(htmlHelper.DataBindedTextBoxFor(expression, input),
                                        htmlHelper.ValidationMessageFor(expression));

            return Wrap(htmlHelper, content, expression, columnSpan);
        }

        public static MvcHtmlString TextPropertyLabelFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan, object inputHtmlAttributes)
        {
            var input = new Dictionary<string, object> { { "class", "input-block-level small" } };

            if (htmlHelper.IsReadOnlyView())
                input.Add("disabled", "disabled");

            if (inputHtmlAttributes != null)
                input.MergeWith(inputHtmlAttributes);

            var content = string.Concat(htmlHelper.LabelFor(expression),
                                        htmlHelper.DataBindedLabelFor(expression, input),
                                        htmlHelper.ValidationMessageFor(expression));

            return Wrap(htmlHelper, content, expression, columnSpan);
        }

        [Obsolete("usar la sobrecarga de object htmlAttributes que ya maneja atributos repetidos")]
        public static MvcHtmlString TextPropertyEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan, string databind)
        {
            var id = GetContainerId<TModel, TProperty>(expression);

            var attributes = new Dictionary<string, object>
                {
                    { "class", "input-block-level small" },
                    { "databind", databind }
                };

            if (htmlHelper.IsReadOnlyView())
                attributes.Add("disabled", "disabled");

            return
                new MvcHtmlString(
                    string.Format(
                        "<div  id=\"{4}\" class=\"span{0}\">{1}{2}{3}</div>",
                        columnSpan,
                        htmlHelper.LabelFor(expression),
                        htmlHelper.DataBindedTextBoxFor(expression, attributes),
                        htmlHelper.ValidationMessageFor(expression),
                        id));
        }

        //TODO: sacar esto. es demasiado particular. GAK
        [Obsolete("No utilizar")]
        public static MvcHtmlString TextPropertyEditorWithLegenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string legen, ColumnSpan columnSpan)
        {
            var id = GetContainerId<TModel, TProperty>(expression);

            return
                new MvcHtmlString(
                    string.Format(
                        "<div id=\"{5}\" class=\"span{0}\">{1}{2}<label class = \"text-info\">{3}</label>{4}</div>",
                        columnSpan,
                        htmlHelper.LabelFor(expression),
                        htmlHelper.DataBindedTextBoxFor(expression, new { @class = "input-block-level" }),
                        legen,
                        htmlHelper.ValidationMessageFor(expression),
                        id));
        }

        #endregion

        #region CheckBox

        public static MvcHtmlString BooleanPropertyEditorFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, ColumnSpan columnSpan)
        {
            return BooleanPropertyEditorFor(htmlHelper, expression, columnSpan, null);
        }

        public static MvcHtmlString BooleanPropertyEditorFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, ColumnSpan columnSpan, object inputHtmlAttributes)
        {
            var input = new Dictionary<string, object>();

            if (htmlHelper.IsReadOnlyView())
                input.Add("disabled", "disabled");

            if (inputHtmlAttributes != null)
                input.MergeWith(inputHtmlAttributes);

            var content = string.Concat(
                htmlHelper.DataBindedCheckBoxFor(expression, input),
                htmlHelper.LabelFor(expression),
                htmlHelper.ValidationMessageFor(expression));

            return Wrap(htmlHelper, content, expression, columnSpan, "checkbox");
        }

        public static MvcHtmlString BooleanPropertyEditorFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, ColumnSpan columnSpan, string databind)
        {
            var input = new Dictionary<string, object>();

            if (htmlHelper.IsReadOnlyView())
                input.Add("disabled", "disabled");

            if (!string.IsNullOrWhiteSpace(databind))
                input.Add("data-bind", databind);

            var content = string.Concat(
                htmlHelper.DataBindedCheckBoxFor(expression, input),
                htmlHelper.LabelFor(expression),
                htmlHelper.ValidationMessageFor(expression));

            var wrappedContent = Wrap(htmlHelper, content, expression, columnSpan, "checkbox");

            return wrappedContent;
        }

        #endregion

        #region Select

     
        public static MvcHtmlString SelectPropertyEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                                    IEnumerable<SelectListItem> selectList, ColumnSpan columnSpan, string extraDatabind = null)
        {
            var defaultDatabind = string.Concat("value: ", ExpressionHelper.GetExpressionText(expression));

            var dataBind = !string.IsNullOrEmpty(extraDatabind)
                               ? string.Format("{0},{1}", defaultDatabind, extraDatabind)
                               : defaultDatabind;

            var list = selectList.ToList();

            list.Add(new SelectListItem { Selected = true, Text = "Seleccione...", Value = string.Empty });

            list = list.OrderBy(t => t.Text).ToList();

            var htmlAttributes = new Dictionary<string, object>
                {
                    { "data-bind", dataBind },
                    { "class", "input-block-level" },
                    { "Name", ExpressionHelper.GetExpressionText(expression) }
                };

            if (htmlHelper.IsReadOnlyView())
                htmlAttributes.Add("disabled", "disabled");

            var id = GetContainerId(expression);

            return new MvcHtmlString(string.Format("<div id=\"{4}\" class=\"span{0}\">{1}{2}{3}</div>",
                                                    columnSpan,
                                                    htmlHelper.LabelFor(expression),
                                                    htmlHelper.DropDownListFor(expression, list, htmlAttributes),
                                                    htmlHelper.ValidationMessageFor(expression),
                                                    id));
        }

        public static MvcHtmlString SelectPropertyEditorNoLabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                                    IEnumerable<SelectListItem> selectList, ColumnSpan columnSpan, string extraDatabind = null)
        {
            var defaultDatabind = string.Concat("value: ", ExpressionHelper.GetExpressionText(expression));

            var dataBind = !string.IsNullOrEmpty(extraDatabind)
                               ? string.Format("{0},{1}", defaultDatabind, extraDatabind)
                               : defaultDatabind;

            var list = selectList.ToList();

            list.Add(new SelectListItem { Selected = true, Text = "Seleccione...", Value = string.Empty });

            list = list.OrderBy(t => t.Text).ToList();

            var htmlAttributes = new Dictionary<string, object>
                {
                    { "data-bind", dataBind },
                    { "class", "input-block-level" },
                    { "Name", ExpressionHelper.GetExpressionText(expression) }
                };

            if (htmlHelper.IsReadOnlyView())
                htmlAttributes.Add("disabled", "disabled");

            var id = GetContainerId(expression);

            return new MvcHtmlString(string.Format("<div id=\"{3}\" class=\"span{0}\">{1}{2}</div>",
                                                    columnSpan,
                                                    htmlHelper.DropDownListFor(expression, list, htmlAttributes),
                                                    htmlHelper.ValidationMessageFor(expression),
                                                    id));
        }

        public static MvcHtmlString SelectPropertyEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                                    IEnumerable<KeyValuePair<string, string>> selectList, ColumnSpan columnSpan, string extraDataBinding = null)
        {
            var items = selectList != null
                            ? selectList.Select(kvp => new SelectListItem { Value = kvp.Key, Text = kvp.Value })
                            : new SelectListItem[] { };

            return SelectPropertyEditorFor(htmlHelper, expression, items, columnSpan, extraDataBinding);
        }

        public static MvcHtmlString SelectPropertyEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                                    IEnumerable<KeyValuePair<int, string>> selectList, ColumnSpan columnSpan, string extraDataBinding = null)
        {
            var items = selectList != null
                            ? selectList.Select(kvp => new SelectListItem { Value = kvp.Key.ToString(CultureInfo.InvariantCulture), Text = kvp.Value })
                            : new SelectListItem[] { };

            return SelectPropertyEditorFor(htmlHelper, expression, items, columnSpan, extraDataBinding);
        }

        public static MvcHtmlString SelectPropertyEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                                    IEnumerable<KeyValuePair<int, string>> selectList, ColumnSpan columnSpan, bool noLabel, string extraDataBinding = null)
        {
            var items = selectList != null
                            ? selectList.Select(kvp => new SelectListItem { Value = kvp.Key.ToString(CultureInfo.InvariantCulture), Text = kvp.Value })
                            : new SelectListItem[] { };

            return SelectPropertyEditorNoLabelFor(htmlHelper, expression, items, columnSpan, extraDataBinding);
        }

        #endregion

        #region RadioButton Group

        public static MvcHtmlString RadioButtonGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                                    IEnumerable<RadioButtonGroupItem> optionList, ColumnSpan columnSpan, string extraDatabind = null)
        {
            var defaultDatabind = string.Concat("checked : ", ExpressionHelper.GetExpressionText(expression));

            var dataBind = !string.IsNullOrEmpty(extraDatabind)
                               ? string.Format("{0},{1}", defaultDatabind, extraDatabind)
                               : defaultDatabind;

            var groupName = ExpressionHelper.GetExpressionText(expression);

            var list = optionList.ToList();

            var htmlAttributes = new Dictionary<string, object>
                {
                    { "data-bind", dataBind },
                    { "Name", ExpressionHelper.GetExpressionText(expression) }
                };

            if (htmlHelper.IsReadOnlyView())
                htmlAttributes.Add("disabled", "disabled");

            var id = GetContainerId(expression);

            var radioButtonGroup = new StringBuilder();

            foreach (var radioButtonItem in list)
            {
                radioButtonGroup
                    .Append("<label class=\"radio\">")
                    .Append(htmlHelper.RadioButtonFor(expression, radioButtonItem.Value, htmlAttributes))
                    .Append("<span>").Append(radioButtonItem.Text).Append("</span>")
                    .Append("</label>");
            }

            return new MvcHtmlString(string.Format("<div id=\"{4}\" class=\"span{0}\">{1}{2}{3}</div>",
                                                    columnSpan,
                                                    htmlHelper.LabelFor(expression),
                                                    radioButtonGroup,
                                                    htmlHelper.ValidationMessageFor(expression),
                                                    id));
        }

        public static MvcHtmlString RadioButtonGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                                    IEnumerable<KeyValuePair<string, string>> optionList, ColumnSpan columnSpan, string extraDataBinding = null)
        {
            var groupName = ExpressionHelper.GetExpressionText(expression);

            var items = optionList != null
                            ? optionList.Select(kvp => new RadioButtonGroupItem { Value = kvp.Key, Text = kvp.Value, GroupName = groupName })
                            : new RadioButtonGroupItem[] { };

            return RadioButtonGroupFor(htmlHelper, expression, items, columnSpan, extraDataBinding);
        }

        public static MvcHtmlString RadioButtonGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                                    IEnumerable<KeyValuePair<int, string>> optionList, ColumnSpan columnSpan, string extraDataBinding = null)
        {
            var groupName = ExpressionHelper.GetExpressionText(expression);

            var items = optionList != null
                            ? optionList.Select(kvp => new RadioButtonGroupItem { Value = kvp.Key.ToString(CultureInfo.InvariantCulture), Text = kvp.Value, GroupName = groupName })
                            : new RadioButtonGroupItem[] { };

            return RadioButtonGroupFor(htmlHelper, expression, items, columnSpan, extraDataBinding);
        }

        #endregion

        #region DatePicker

        public static MvcHtmlString DatePropertyEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan)
        {
            return DatePropertyEditorFor(htmlHelper, expression, columnSpan, null);
        }

        public static MvcHtmlString DatePropertyEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                                  ColumnSpan columnSpan, string databind)
        {
            var id = GetContainerId(expression);
            var expressionText = ExpressionHelper.GetExpressionText(expression);
            var disabled = htmlHelper.IsReadOnlyView() ? "disabled=\"disabled\"" : string.Empty;

            if (databind != null)
            {
                if (!string.IsNullOrWhiteSpace(databind))
                    databind = ", " + databind;
            }
            else
            {
                databind = string.Empty;
            }

            var hiddenIconClass = htmlHelper.IsReadOnlyView() ? "hidden" : string.Empty;

            var css = "span" + columnSpan;
            if (htmlHelper.IsReadOnlyView())
            {
                css += " readOnly";
            }

            var sb = new StringBuilder();
            sb.AppendFormat("<div id=\"{0}\" class=\"{1}\">", id, css);
            sb.AppendLine();
            sb.AppendLine(htmlHelper.LabelFor(expression).ToString());
            sb.AppendFormat("       <div class=\"control-group input-datepicker date small\">", expressionText, databind);
            sb.AppendLine();
            sb.AppendFormat("           <input data-bind=\"datepicker: {0}{1}\" type=\"text\" id=\"{0}\" name=\"{0}\" class=\"span3 datepickerFlat\" {1} />", expressionText, disabled);
            sb.AppendLine();
            sb.AppendFormat("           <i class=\"input-icon fui-calendar\"></i>");
            sb.AppendLine("         </div>");
            sb.AppendLine(htmlHelper.ValidationMessageFor(expression).ToString());
            sb.AppendLine("</div>");

            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString DatePropertyEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan, string databind, bool renderDisabled)
        {
            var id = GetContainerId(expression);
            var expressionText = ExpressionHelper.GetExpressionText(expression);
            var disabled = htmlHelper.IsReadOnlyView() ? "disabled=\"disabled\"" : string.Empty;

            if (databind != null)
            {
                if (!string.IsNullOrWhiteSpace(databind))
                    databind = ", " + databind;
            }
            else
            {
                databind = string.Empty;
            }

            var hiddenIconClass = htmlHelper.IsReadOnlyView() ? "hidden" : string.Empty;

            var css = "span" + columnSpan;
            if (htmlHelper.IsReadOnlyView())
            {
                css += " readOnly";
            }

            var sb = new StringBuilder();
            sb.AppendFormat("<div id=\"{0}\" class=\"{1}\">", id, css);
            sb.AppendLine();
            sb.AppendLine(htmlHelper.LabelFor(expression).ToString());
            sb.AppendFormat("       <div class=\"control-group input-datepicker date small\">", expressionText, databind);
            sb.AppendLine();
            sb.AppendFormat(
                renderDisabled
                    ? "           <input data-bind=\"datepicker: {0}{1}\" type=\"text\" id=\"{0}\" name=\"{0}\" disabled=\"true\" class=\"span3 datepickerFlat\" {1} />"
                    : "           <input data-bind=\"datepicker: {0}{1}\" type=\"text\" id=\"{0}\" name=\"{0}\" class=\"span3 datepickerFlat\" {1} />",
                expressionText, disabled);

            sb.AppendLine();
            sb.AppendFormat("           <i class=\"input-icon fui-calendar\"></i>");
            sb.AppendLine("         </div>");
            sb.AppendLine(htmlHelper.ValidationMessageFor(expression).ToString());
            sb.AppendLine("</div>");

            return new MvcHtmlString(sb.ToString());
        }
        #endregion

        public static bool IsReadOnlyView(this HtmlHelper htmlHelper)
        {
            var readOnly = htmlHelper.ViewData["ReadOnlyView"];

            return readOnly is bool && (bool)readOnly;
        }

        public static void SetReadOnlyView(this HtmlHelper htmlHelper)
        {
            htmlHelper.ViewData["ReadOnlyView"] = true;
        }

        public static void SetEditableView(this HtmlHelper htmlHelper)
        {
            htmlHelper.ViewData["ReadOnlyView"] = false;
        }

        private static MvcHtmlString Wrap<TModel, TProperty>(HtmlHelper htmlHelper, string htmlContent, Expression<Func<TModel, TProperty>> expression, ColumnSpan columnSpan, string cssClass = "")
        {
            const string Wrapper = "<div id=\"{0}\" class=\"span{1} {3}\">{2}</div>";

            if (htmlHelper.IsReadOnlyView()) cssClass += " readOnly";

            return new MvcHtmlString(string.Format(Wrapper, GetContainerId(expression), columnSpan, htmlContent, cssClass));
        }

        private static string GetContainerId<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return ExpressionHelper.GetExpressionText(expression) + "Container";
        }
    }

    public class RadioButtonGroupItem : SelectListItem
    {
        public string GroupName { get; set; }
    }
}
